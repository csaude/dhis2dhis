SELECT district.name || ' / ' || ou.name AS facility,
'0' || ou.code AS code,
/*Auto-Calculate*/
----------------------------------------------------------------------------------------
--QUARTERLY
----------------------------------------------------------------------------------------
/*HTS_TST_num*/
(
/*HTS_TST (Facility) - PITC Inpatient Services*/
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Inpatient_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_0_8_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_0_8_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_0_8_m_neg.value,0)+
*/
(COALESCE(HTS_TST_Inpatient_9_18_f_pos.value,0)+COALESCE(HTS_TST_Inpatient_19_4_f_pos.value,0))+
(COALESCE(HTS_TST_Inpatient_9_18_f_neg.value,0)+COALESCE(HTS_TST_Inpatient_19_4_f_neg.value,0))+
(COALESCE(HTS_TST_Inpatient_9_18_m_pos.value,0)+COALESCE(HTS_TST_Inpatient_19_4_m_pos.value,0))+
(COALESCE(HTS_TST_Inpatient_9_18_m_neg.value,0)+COALESCE(HTS_TST_Inpatient_19_4_m_neg.value,0))+
COALESCE(HTS_TST_Inpatient_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_5_9_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_5_9_m_neg.value,0)+
COALESCE(HTS_TST_Inpatient_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_10_14_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_10_14_m_neg.value,0)+
COALESCE(HTS_TST_Inpatient_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_15_19_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_15_19_m_neg.value,0)+
COALESCE(HTS_TST_Inpatient_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_20_24_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_20_24_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_20_24_m_neg.value,0)+
(COALESCE(HTS_TST_Inpatient_25_29_f_pos.value,0)+COALESCE(HTS_TST_Inpatient_30_49_f_pos.value,0))+
(COALESCE(HTS_TST_Inpatient_25_29_f_neg.value,0)+COALESCE(HTS_TST_Inpatient_30_49_f_neg.value,0))+
(COALESCE(HTS_TST_Inpatient_25_29_m_pos.value,0)+COALESCE(HTS_TST_Inpatient_30_49_m_pos.value,0))+
(COALESCE(HTS_TST_Inpatient_25_29_m_neg.value,0)+COALESCE(HTS_TST_Inpatient_30_49_m_neg.value,0))+
COALESCE(HTS_TST_Inpatient_35_39_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_35_39_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_35_39_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_35_39_m_neg.value,0)+
COALESCE(HTS_TST_Inpatient_40_44_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_40_44_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_40_44_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_40_44_m_neg.value,0)+
COALESCE(HTS_TST_Inpatient_45_49_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_45_49_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_45_49_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_45_49_m_neg.value,0)+
COALESCE(HTS_TST_Inpatient_50_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_50_f_neg.value,0)+
COALESCE(HTS_TST_Inpatient_50_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_50_m_neg.value,0)+
/*HTS_TST (Facility)-PITC Pediatric Services*/
COALESCE(HTS_TST_Pediatric_19_4_f_pos.value,0)+
COALESCE(HTS_TST_Pediatric_19_4_f_neg.value,0)+
COALESCE(HTS_TST_Pediatric_19_4_m_pos.value,0)+
COALESCE(HTS_TST_Pediatric_19_4_m_neg.value,0)+
/*HTS_TST (Facility)-PITC-TB Clinics*/
COALESCE(HTS_TST_TB_men1_f_pos.value,0)+
COALESCE(HTS_TST_TB_men1_f_neg.value,0)+
COALESCE(HTS_TST_TB_men1_m_pos.value,0)+
COALESCE(HTS_TST_TB_men1_m_neg.value,0)+
COALESCE(HTS_TST_TB_1_4_f_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_f_neg.value,0)+
COALESCE(HTS_TST_TB_1_4_m_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_m_neg.value,0)+
COALESCE(HTS_TST_TB_5_9_f_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_f_neg.value,0)+
COALESCE(HTS_TST_TB_5_9_m_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_m_neg.value,0)+
COALESCE(HTS_TST_TB_10_14_f_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_f_neg.value,0)+
COALESCE(HTS_TST_TB_10_14_m_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_m_neg.value,0)+
COALESCE(HTS_TST_TB_15_19_f_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_f_neg.value,0)+
COALESCE(HTS_TST_TB_15_19_m_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_m_neg.value,0)+
COALESCE(HTS_TST_TB_20_24_f_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_f_neg.value,0)+
COALESCE(HTS_TST_TB_20_24_m_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_m_neg.value,0)+
COALESCE(HTS_TST_TB_25_29_f_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_f_neg.value,0)+
COALESCE(HTS_TST_TB_25_29_m_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_m_neg.value,0)+
COALESCE(HTS_TST_TB_30_34_f_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_f_neg.value,0)+
COALESCE(HTS_TST_TB_30_34_m_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_m_neg.value,0)+
COALESCE(HTS_TST_TB_35_39_f_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_f_neg.value,0)+
COALESCE(HTS_TST_TB_35_39_m_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_m_neg.value,0)+
COALESCE(HTS_TST_TB_40_44_f_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_f_neg.value,0)+
COALESCE(HTS_TST_TB_40_44_m_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_m_neg.value,0)+
COALESCE(HTS_TST_TB_45_49_f_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_f_neg.value,0)+
COALESCE(HTS_TST_TB_45_49_m_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_m_neg.value,0)+
COALESCE(HTS_TST_TB_50_f_pos.value,0)+
COALESCE(HTS_TST_TB_50_f_neg.value,0)+
COALESCE(HTS_TST_TB_50_m_pos.value,0)+
COALESCE(HTS_TST_TB_50_m_neg.value,0)+
/*Known Negative*/
COALESCE(TB_STAT_kn_men1_f.value,0)+
COALESCE(TB_STAT_kn_men1_m.value,0)+
COALESCE(TB_STAT_kn_1_4_f.value,0)+
COALESCE(TB_STAT_kn_1_4_m.value,0)+
COALESCE(TB_STAT_kn_5_9_f.value,0)+
COALESCE(TB_STAT_kn_5_9_m.value,0)+
COALESCE(TB_STAT_kn_10_14_f.value,0)+
COALESCE(TB_STAT_kn_10_14_m.value,0)+
COALESCE(TB_STAT_kn_15_19_f.value,0)+
COALESCE(TB_STAT_kn_15_19_m.value,0)+
COALESCE(TB_STAT_kn_20_24_f.value,0)+
COALESCE(TB_STAT_kn_20_24_m.value,0)+
COALESCE(TB_STAT_kn_25_29_f.value,0)+
COALESCE(TB_STAT_kn_25_29_m.value,0)+
COALESCE(TB_STAT_kn_30_34_f.value,0)+
COALESCE(TB_STAT_kn_30_34_m.value,0)+
COALESCE(TB_STAT_kn_35_39_f.value,0)+
COALESCE(TB_STAT_kn_35_39_m.value,0)+
COALESCE(TB_STAT_kn_40_44_f.value,0)+
COALESCE(TB_STAT_kn_40_44_m.value,0)+
COALESCE(TB_STAT_kn_45_49_f.value,0)+
COALESCE(TB_STAT_kn_45_49_m.value,0)+
COALESCE(TB_STAT_kn_50_f.value,0)+
COALESCE(TB_STAT_kn_50_m.value,0)+
/*HTS_TST (Facility)-PITC PMTCT (ANC Only) Clinics*/
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0)+
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0)+
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0)+
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0)+
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0)+
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0)+
COALESCE(HTS_TST_PMTCT_25_pos.value,0)+
COALESCE(HTS_TST_PMTCT_25_neg.value,0)+
/*HTS_TST (Facility)-PITC PMTCT Post ANC*/
(COALESCE(mat_men1_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_0_8_f_pos.value,0))+
(COALESCE(mat_men1_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_0_8_f_neg.value,0))+
(COALESCE(mat_1_4_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_9_18_f_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_19_4_f_pos.value,0))+
(COALESCE(mat_1_4_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_9_18_f_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_19_4_f_neg.value,0))+
(COALESCE(mat_5_9_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_5_9_f_pos.value,0))+
(COALESCE(mat_5_9_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_5_9_f_neg.value,0))+
(COALESCE(mat_10_14_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_10_14_f_pos.value,0))+
(COALESCE(mat_10_14_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_10_14_f_neg.value,0))+
(COALESCE(mat_15_19_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_15_19_f_pos.value,0))+
(COALESCE(mat_15_19_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_15_19_f_neg.value,0))+
(COALESCE(mat_20_24_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_20_24_f_pos.value,0))+
(COALESCE(mat_20_24_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_20_24_f_neg.value,0))+
(COALESCE(mat_25_29_pos.value,0)+COALESCE(mat_30_34_pos.value,0)+COALESCE(mat_35_39_pos.value,0)+COALESCE(mat_40_44_pos.value,0)+COALESCE(mat_45_49_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_25_29_f_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_30_49_f_pos.value,0))+
(COALESCE(mat_25_29_neg.value,0)+COALESCE(mat_30_34_neg.value,0)+COALESCE(mat_35_39_neg.value,0)+COALESCE(mat_40_44_neg.value,0)+COALESCE(mat_45_49_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_25_29_f_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_30_49_f_neg.value,0))+
COALESCE(HTS_TST_PMTCT_POST_35_39_f_pos.value,0)+
COALESCE(HTS_TST_PMTCT_POST_35_39_f_neg.value,0)+
COALESCE(HTS_TST_PMTCT_POST_40_44_f_pos.value,0)+
COALESCE(HTS_TST_PMTCT_POST_40_44_f_neg.value,0)+
COALESCE(HTS_TST_PMTCT_POST_45_49_f_pos.value,0)+
COALESCE(HTS_TST_PMTCT_POST_45_49_f_neg.value,0)+
(COALESCE(mat_50_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_50_f_pos.value,0))+
(COALESCE(mat_50_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_50_f_neg.value,0))+
/*HTS_TST (Facility)-PITC Emergency Ward*/
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Emergency_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_0_8_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_0_8_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_0_8_m_neg.value,0)+
*/
(COALESCE(HTS_TST_Emergency_9_18_f_pos.value,0)+COALESCE(HTS_TST_Emergency_19_4_f_pos.value,0))+
(COALESCE(HTS_TST_Emergency_9_18_f_neg.value,0)+COALESCE(HTS_TST_Emergency_19_4_f_neg.value,0))+
(COALESCE(HTS_TST_Emergency_9_18_m_pos.value,0)+COALESCE(HTS_TST_Emergency_19_4_m_pos.value,0))+
(COALESCE(HTS_TST_Emergency_9_18_m_neg.value,0)+COALESCE(HTS_TST_Emergency_19_4_m_neg.value,0))+
COALESCE(HTS_TST_Emergency_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_5_9_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_5_9_m_neg.value,0)+
COALESCE(HTS_TST_Emergency_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_10_14_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_10_14_m_neg.value,0)+
COALESCE(HTS_TST_Emergency_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_15_19_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_15_19_m_neg.value,0)+
COALESCE(HTS_TST_Emergency_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_20_24_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_20_24_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_20_24_m_neg.value,0)+
(COALESCE(HTS_TST_Emergency_25_29_f_pos.value,0)+COALESCE(HTS_TST_Emergency_30_49_f_pos.value,0))+
(COALESCE(HTS_TST_Emergency_25_29_f_neg.value,0)+COALESCE(HTS_TST_Emergency_30_49_f_neg.value,0))+
(COALESCE(HTS_TST_Emergency_25_29_m_pos.value,0)+COALESCE(HTS_TST_Emergency_30_49_m_pos.value,0))+
(COALESCE(HTS_TST_Emergency_25_29_m_neg.value,0)+COALESCE(HTS_TST_Emergency_30_49_m_neg.value,0))+
COALESCE(HTS_TST_Emergency_35_39_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_35_39_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_35_39_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_35_39_m_neg.value,0)+
COALESCE(HTS_TST_Emergency_40_44_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_40_44_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_40_44_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_40_44_m_neg.value,0)+
COALESCE(HTS_TST_Emergency_45_49_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_45_49_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_45_49_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_45_49_m_neg.value,0)+
COALESCE(HTS_TST_Emergency_50_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_50_f_neg.value,0)+
COALESCE(HTS_TST_Emergency_50_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_50_m_neg.value,0)+
/*HTS_TST (Facility)-Other PITC*/
COALESCE(cpn_m_pos.value,0)+
COALESCE(cpn_m_neg.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Other_0_8_f_neg.value,0)+
COALESCE(HTS_TST_Other_0_8_m_pos.value,0)+
COALESCE(HTS_TST_Other_0_8_m_neg.value,0)+
*/
(COALESCE(HTS_TST_Other_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_19_4_f_pos.value,0))+
(COALESCE(HTS_TST_Other_9_18_f_neg.value,0)+COALESCE(HTS_TST_Other_19_4_f_neg.value,0))+
(COALESCE(HTS_TST_Other_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_19_4_m_pos.value,0))+
(COALESCE(HTS_TST_Other_9_18_m_neg.value,0)+COALESCE(HTS_TST_Other_19_4_m_neg.value,0))+
COALESCE(HTS_TST_Other_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Other_5_9_f_neg.value,0)+
COALESCE(HTS_TST_Other_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Other_5_9_m_neg.value,0)+
COALESCE(HTS_TST_Other_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Other_10_14_f_neg.value,0)+
COALESCE(HTS_TST_Other_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Other_10_14_m_neg.value,0)+
COALESCE(HTS_TST_Other_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Other_15_19_f_neg.value,0)+
COALESCE(HTS_TST_Other_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Other_15_19_m_neg.value,0)+
COALESCE(HTS_TST_Other_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Other_20_24_f_neg.value,0)+
COALESCE(HTS_TST_Other_20_24_m_pos.value,0)+
COALESCE(HTS_TST_Other_20_24_m_neg.value,0)+
(COALESCE(HTS_TST_Other_25_29_f_pos.value,0)+COALESCE(HTS_TST_Other_30_49_f_pos.value,0))+
(COALESCE(HTS_TST_Other_25_29_f_neg.value,0)+COALESCE(HTS_TST_Other_30_49_f_neg.value,0))+
(COALESCE(HTS_TST_Other_25_29_m_pos.value,0)+COALESCE(HTS_TST_Other_30_49_m_pos.value,0))+
(COALESCE(HTS_TST_Other_25_29_m_neg.value,0)+COALESCE(HTS_TST_Other_30_49_m_neg.value,0))+
COALESCE(HTS_TST_Other_35_39_f_pos.value,0)+
COALESCE(HTS_TST_Other_35_39_f_neg.value,0)+
COALESCE(HTS_TST_Other_35_39_m_pos.value,0)+
COALESCE(HTS_TST_Other_35_39_m_neg.value,0)+
COALESCE(HTS_TST_Other_40_44_f_pos.value,0)+
COALESCE(HTS_TST_Other_40_44_f_neg.value,0)+
COALESCE(HTS_TST_Other_40_44_m_pos.value,0)+
COALESCE(HTS_TST_Other_40_44_m_neg.value,0)+
COALESCE(HTS_TST_Other_45_49_f_pos.value,0)+
COALESCE(HTS_TST_Other_45_49_f_neg.value,0)+
COALESCE(HTS_TST_Other_45_49_m_pos.value,0)+
COALESCE(HTS_TST_Other_45_49_m_neg.value,0)+
(COALESCE(HTS_TST_Other_50_f_pos.value,0))+
(COALESCE(HTS_TST_Other_50_f_neg.value,0))+
COALESCE(HTS_TST_Other_50_m_pos.value,0)+
COALESCE(HTS_TST_Other_50_m_neg.value,0)+
/*HTS_TST (Facility)-VCT*/
/*REMOVING CHILD <1y
COALESCE(VCT_0_8_f_pos.value,0)+
COALESCE(VCT_0_8_f_neg.value,0)+
COALESCE(VCT_0_8_m_pos.value,0)+
COALESCE(VCT_0_8_m_neg.value,0)+
*/
(COALESCE(VCT_9_18_f_pos.value,0)+COALESCE(VCT_19_4_f_pos.value,0))+
(COALESCE(VCT_9_18_f_neg.value,0)+COALESCE(VCT_19_4_f_neg.value,0))+
(COALESCE(VCT_9_18_m_pos.value,0)+COALESCE(VCT_19_4_m_pos.value,0))+
(COALESCE(VCT_9_18_m_neg.value,0)+COALESCE(VCT_19_4_m_neg.value,0))+
COALESCE(VCT_5_9_f_pos.value,0)+
COALESCE(VCT_5_9_f_neg.value,0)+
COALESCE(VCT_5_9_m_pos.value,0)+
COALESCE(VCT_5_9_m_neg.value,0)+
COALESCE(VCT_10_14_f_pos.value,0)+
COALESCE(VCT_10_14_f_neg.value,0)+
COALESCE(VCT_10_14_m_pos.value,0)+
COALESCE(VCT_10_14_m_neg.value,0)+
COALESCE(VCT_15_19_f_pos.value,0)+
COALESCE(VCT_15_19_f_neg.value,0)+
COALESCE(VCT_15_19_m_pos.value,0)+
COALESCE(VCT_15_19_m_neg.value,0)+
COALESCE(VCT_20_24_f_pos.value,0)+
COALESCE(VCT_20_24_f_neg.value,0)+
COALESCE(VCT_20_24_m_pos.value,0)+
COALESCE(VCT_20_24_m_neg.value,0)+
(COALESCE(VCT_25_29_f_pos.value,0)+COALESCE(VCT_30_49_f_pos.value,0))+
(COALESCE(VCT_25_29_f_neg.value,0)+COALESCE(VCT_30_49_f_neg.value,0))+
(COALESCE(VCT_25_29_m_pos.value,0)+COALESCE(VCT_30_49_m_pos.value,0))+
(COALESCE(VCT_25_29_m_neg.value,0)+COALESCE(VCT_30_49_m_neg.value,0))+
COALESCE(VCT_35_39_f_pos.value,0)+
COALESCE(VCT_35_39_f_neg.value,0)+
COALESCE(VCT_35_39_m_pos.value,0)+
COALESCE(VCT_35_39_m_neg.value,0)+
COALESCE(VCT_40_44_f_pos.value,0)+
COALESCE(VCT_40_44_f_neg.value,0)+
COALESCE(VCT_40_44_m_pos.value,0)+
COALESCE(VCT_40_44_m_neg.value,0)+
COALESCE(VCT_45_49_f_pos.value,0)+
COALESCE(VCT_45_49_f_neg.value,0)+
COALESCE(VCT_45_49_m_pos.value,0)+
COALESCE(VCT_45_49_m_neg.value,0)+
COALESCE(VCT_50_f_pos.value,0)+
COALESCE(VCT_50_f_neg.value,0)+
COALESCE(VCT_50_m_pos.value,0)+
COALESCE(VCT_50_m_neg.value,0)+
/*Index Testing*/
COALESCE(cpn_index_contact_pos.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_f_pos.value,0)+COALESCE(VCT_index_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_0_8_m_pos.value,0)+COALESCE(VCT_index_0_8_m_pos.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_pos.value,0)+COALESCE(VCT_index_9_18_f_pos.value,0)+COALESCE(VCT_index_19_4_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_pos.value,0)+COALESCE(VCT_index_9_18_m_pos.value,0)+COALESCE(VCT_index_19_4_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_f_pos.value,0)+COALESCE(VCT_index_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_m_pos.value,0)+COALESCE(VCT_index_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_f_pos.value,0)+COALESCE(VCT_index_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_m_pos.value,0)+COALESCE(VCT_index_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_f_pos.value,0)+COALESCE(VCT_index_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_m_pos.value,0)+COALESCE(VCT_index_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_f_pos.value,0)+COALESCE(VCT_index_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_m_pos.value,0)+COALESCE(VCT_index_20_24_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_f_pos.value,0)+COALESCE(VCT_index_25_29_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_m_pos.value,0)+COALESCE(VCT_index_25_29_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_f_pos.value,0)+COALESCE(VCT_index_30_49_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_m_pos.value,0)+COALESCE(VCT_index_30_49_m_pos.value,0)+
(COALESCE(HTS_TST_Other_index_35_39_f_pos.value,0)+COALESCE(VCT_index_35_39_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_35_39_m_pos.value,0)+COALESCE(VCT_index_35_39_m_pos.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_f_pos.value,0)+COALESCE(VCT_index_40_44_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_m_pos.value,0)+COALESCE(VCT_index_40_44_m_pos.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_f_pos.value,0)+COALESCE(VCT_index_45_49_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_m_pos.value,0)+COALESCE(VCT_index_45_49_m_pos.value,0))+
COALESCE(HTS_TST_Other_index_50_f_pos.value,0)+COALESCE(VCT_index_50_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_50_m_pos.value,0)+COALESCE(VCT_index_50_m_pos.value,0)+
COALESCE(cpn_index_contact_neg.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_f_neg.value,0)+COALESCE(VCT_index_0_8_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_0_8_m_neg.value,0)+COALESCE(VCT_index_0_8_m_neg.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_f_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_neg.value,0)+COALESCE(VCT_index_9_18_f_neg.value,0)+COALESCE(VCT_index_19_4_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_9_18_m_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_neg.value,0)+COALESCE(VCT_index_9_18_m_neg.value,0)+COALESCE(VCT_index_19_4_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_5_9_f_neg.value,0)+COALESCE(VCT_index_5_9_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_5_9_m_neg.value,0)+COALESCE(VCT_index_5_9_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_10_14_f_neg.value,0)+COALESCE(VCT_index_10_14_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_10_14_m_neg.value,0)+COALESCE(VCT_index_10_14_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_15_19_f_neg.value,0)+COALESCE(VCT_index_15_19_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_15_19_m_neg.value,0)+COALESCE(VCT_index_15_19_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_20_24_f_neg.value,0)+COALESCE(VCT_index_20_24_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_20_24_m_neg.value,0)+COALESCE(VCT_index_20_24_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_25_29_f_neg.value,0)+COALESCE(VCT_index_25_29_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_25_29_m_neg.value,0)+COALESCE(VCT_index_25_29_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_30_49_f_neg.value,0)+COALESCE(VCT_index_30_49_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_30_49_m_neg.value,0)+COALESCE(VCT_index_30_49_m_neg.value,0)+
(COALESCE(HTS_TST_Other_index_35_39_f_neg.value,0)+COALESCE(VCT_index_35_39_f_neg.value,0))+
(COALESCE(HTS_TST_Other_index_35_39_m_neg.value,0)+COALESCE(VCT_index_35_39_m_neg.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_f_neg.value,0)+COALESCE(VCT_index_40_44_f_neg.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_m_neg.value,0)+COALESCE(VCT_index_40_44_m_neg.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_f_neg.value,0)+COALESCE(VCT_index_45_49_f_neg.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_m_neg.value,0)+COALESCE(VCT_index_45_49_m_neg.value,0))+
COALESCE(HTS_TST_Other_index_50_f_neg.value,0)+COALESCE(VCT_index_50_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_50_m_neg.value,0)+COALESCE(VCT_index_50_m_neg.value,0)+
COALESCE(PMTCT_STAT_10_14_repeat_pos.value,0)+
COALESCE(PMTCT_STAT_10_14_repeat_neg.value,0)+
COALESCE(PMTCT_STAT_15_19_repeat_pos.value,0)+
COALESCE(PMTCT_STAT_15_19_repeat_neg.value,0)+
COALESCE(PMTCT_STAT_20_24_repeat_pos.value,0)+
COALESCE(PMTCT_STAT_20_24_repeat_neg.value,0)+
COALESCE(PMTCT_STAT_25_repeat_pos.value,0)+
COALESCE(PMTCT_STAT_25_repeat_neg.value,0)
) AS HTS_TST_num,
/*Auto-Calculate*/
/*HTS_TST Positive*/
(
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Inpatient_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_0_8_m_pos.value,0)+
*/
(COALESCE(HTS_TST_Inpatient_9_18_f_pos.value,0)+COALESCE(HTS_TST_Inpatient_19_4_f_pos.value,0))+
(COALESCE(HTS_TST_Inpatient_9_18_m_pos.value,0)+COALESCE(HTS_TST_Inpatient_19_4_m_pos.value,0))+
COALESCE(HTS_TST_Inpatient_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_20_24_m_pos.value,0)+
(COALESCE(HTS_TST_Inpatient_25_29_f_pos.value,0)+COALESCE(HTS_TST_Inpatient_30_49_f_pos.value,0))+
(COALESCE(HTS_TST_Inpatient_25_29_m_pos.value,0)+COALESCE(HTS_TST_Inpatient_30_49_m_pos.value,0))+
COALESCE(HTS_TST_Inpatient_35_39_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_35_39_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_40_44_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_40_44_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_45_49_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_45_49_m_pos.value,0)+
COALESCE(HTS_TST_Inpatient_50_f_pos.value,0)+
COALESCE(HTS_TST_Inpatient_50_m_pos.value,0)+
COALESCE(HTS_TST_Pediatric_19_4_f_pos.value,0)+
COALESCE(HTS_TST_Pediatric_19_4_m_pos.value,0)+
COALESCE(HTS_TST_TB_men1_f_pos.value,0)+
COALESCE(HTS_TST_TB_men1_m_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_f_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_m_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_f_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_m_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_f_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_m_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_f_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_m_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_f_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_m_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_f_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_m_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_f_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_m_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_f_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_m_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_f_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_m_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_f_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_m_pos.value,0)+
COALESCE(HTS_TST_TB_50_f_pos.value,0)+
COALESCE(HTS_TST_TB_50_m_pos.value,0)+
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0)+
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0)+
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0)+
COALESCE(HTS_TST_PMTCT_25_pos.value,0)+
(COALESCE(mat_men1_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_0_8_f_pos.value,0))+
(COALESCE(mat_1_4_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_9_18_f_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_19_4_f_pos.value,0))+
(COALESCE(mat_5_9_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_5_9_f_pos.value,0))+
(COALESCE(mat_10_14_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_10_14_f_pos.value,0))+
(COALESCE(mat_15_19_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_15_19_f_pos.value,0))+
(COALESCE(mat_20_24_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_20_24_f_pos.value,0))+
(COALESCE(mat_25_29_pos.value,0)+COALESCE(mat_30_34_pos.value,0)+COALESCE(mat_35_39_pos.value,0)+COALESCE(mat_40_44_pos.value,0)+COALESCE(mat_45_49_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_25_29_f_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_30_49_f_pos.value,0))+
COALESCE(HTS_TST_PMTCT_POST_35_39_f_pos.value,0)+
COALESCE(HTS_TST_PMTCT_POST_40_44_f_pos.value,0)+
COALESCE(HTS_TST_PMTCT_POST_45_49_f_pos.value,0)+
(COALESCE(mat_50_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_50_f_pos.value,0))+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Emergency_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_0_8_m_pos.value,0)+
*/
(COALESCE(HTS_TST_Emergency_9_18_f_pos.value,0)+COALESCE(HTS_TST_Emergency_19_4_f_pos.value,0))+
(COALESCE(HTS_TST_Emergency_9_18_m_pos.value,0)+COALESCE(HTS_TST_Emergency_19_4_m_pos.value,0))+
COALESCE(HTS_TST_Emergency_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_20_24_m_pos.value,0)+
(COALESCE(HTS_TST_Emergency_25_29_f_pos.value,0)+COALESCE(HTS_TST_Emergency_30_49_f_pos.value,0))+
(COALESCE(HTS_TST_Emergency_25_29_m_pos.value,0)+COALESCE(HTS_TST_Emergency_30_49_m_pos.value,0))+
COALESCE(HTS_TST_Emergency_35_39_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_35_39_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_40_44_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_40_44_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_45_49_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_45_49_m_pos.value,0)+
COALESCE(HTS_TST_Emergency_50_f_pos.value,0)+
COALESCE(HTS_TST_Emergency_50_m_pos.value,0)+
COALESCE(cpn_m_pos.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Other_0_8_m_pos.value,0)+
*/
(COALESCE(HTS_TST_Other_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_19_4_f_pos.value,0))+
(COALESCE(HTS_TST_Other_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_19_4_m_pos.value,0))+
COALESCE(HTS_TST_Other_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Other_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Other_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Other_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Other_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Other_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Other_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Other_20_24_m_pos.value,0)+
(COALESCE(HTS_TST_Other_25_29_f_pos.value,0)+COALESCE(HTS_TST_Other_30_49_f_pos.value,0))+
(COALESCE(HTS_TST_Other_25_29_m_pos.value,0)+COALESCE(HTS_TST_Other_30_49_m_pos.value,0))+
COALESCE(HTS_TST_Other_35_39_f_pos.value,0)+
COALESCE(HTS_TST_Other_35_39_m_pos.value,0)+
COALESCE(HTS_TST_Other_40_44_f_pos.value,0)+
COALESCE(HTS_TST_Other_40_44_m_pos.value,0)+
COALESCE(HTS_TST_Other_45_49_f_pos.value,0)+
COALESCE(HTS_TST_Other_45_49_m_pos.value,0)+
(COALESCE(HTS_TST_Other_50_f_pos.value,0))+
COALESCE(HTS_TST_Other_50_m_pos.value,0)+
/*REMOVING CHILD <1y
COALESCE(VCT_0_8_f_pos.value,0)+
COALESCE(VCT_0_8_m_pos.value,0)+
*/
(COALESCE(VCT_9_18_f_pos.value,0)+COALESCE(VCT_19_4_f_pos.value,0))+
(COALESCE(VCT_9_18_m_pos.value,0)+COALESCE(VCT_19_4_m_pos.value,0))+
COALESCE(VCT_5_9_f_pos.value,0)+
COALESCE(VCT_5_9_m_pos.value,0)+
COALESCE(VCT_10_14_f_pos.value,0)+
COALESCE(VCT_10_14_m_pos.value,0)+
COALESCE(VCT_15_19_f_pos.value,0)+
COALESCE(VCT_15_19_m_pos.value,0)+
COALESCE(VCT_20_24_f_pos.value,0)+
COALESCE(VCT_20_24_m_pos.value,0)+
(COALESCE(VCT_25_29_f_pos.value,0)+COALESCE(VCT_30_49_f_pos.value,0))+
(COALESCE(VCT_25_29_m_pos.value,0)+COALESCE(VCT_30_49_m_pos.value,0))+
COALESCE(VCT_35_39_f_pos.value,0)+
COALESCE(VCT_35_39_m_pos.value,0)+
COALESCE(VCT_40_44_f_pos.value,0)+
COALESCE(VCT_40_44_m_pos.value,0)+
COALESCE(VCT_45_49_f_pos.value,0)+
COALESCE(VCT_45_49_m_pos.value,0)+
COALESCE(VCT_50_f_pos.value,0)+
COALESCE(VCT_50_m_pos.value,0)+
COALESCE(cpn_index_contact_pos.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_f_pos.value,0)+COALESCE(VCT_index_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_0_8_m_pos.value,0)+COALESCE(VCT_index_0_8_m_pos.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_pos.value,0)+COALESCE(VCT_index_9_18_f_pos.value,0)+COALESCE(VCT_index_19_4_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_pos.value,0)+COALESCE(VCT_index_9_18_m_pos.value,0)+COALESCE(VCT_index_19_4_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_f_pos.value,0)+COALESCE(VCT_index_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_m_pos.value,0)+COALESCE(VCT_index_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_f_pos.value,0)+COALESCE(VCT_index_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_m_pos.value,0)+COALESCE(VCT_index_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_f_pos.value,0)+COALESCE(VCT_index_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_m_pos.value,0)+COALESCE(VCT_index_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_f_pos.value,0)+COALESCE(VCT_index_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_m_pos.value,0)+COALESCE(VCT_index_20_24_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_f_pos.value,0)+COALESCE(VCT_index_25_29_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_m_pos.value,0)+COALESCE(VCT_index_25_29_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_f_pos.value,0)+COALESCE(VCT_index_30_49_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_m_pos.value,0)+COALESCE(VCT_index_30_49_m_pos.value,0)+
(COALESCE(HTS_TST_Other_index_35_39_f_pos.value,0)+COALESCE(VCT_index_35_39_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_35_39_m_pos.value,0)+COALESCE(VCT_index_35_39_m_pos.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_f_pos.value,0)+COALESCE(VCT_index_40_44_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_m_pos.value,0)+COALESCE(VCT_index_40_44_m_pos.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_f_pos.value,0)+COALESCE(VCT_index_45_49_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_m_pos.value,0)+COALESCE(VCT_index_45_49_m_pos.value,0))+
COALESCE(HTS_TST_Other_index_50_f_pos.value,0)+COALESCE(VCT_index_50_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_50_m_pos.value,0)+COALESCE(VCT_index_50_m_pos.value,0)+
COALESCE(PMTCT_STAT_10_14_repeat_pos.value,0)+
COALESCE(PMTCT_STAT_15_19_repeat_pos.value,0)+
COALESCE(PMTCT_STAT_20_24_repeat_pos.value,0)+
COALESCE(PMTCT_STAT_25_repeat_pos.value,0)
) AS HTS_TST_pos,
/*HTS_TST Key Population*/
COALESCE(HTS_TST_PWID_pos.value,0) AS HTS_TST_PWID_pos,
COALESCE(HTS_TST_PWID_neg.value,0) AS HTS_TST_PWID_neg,
COALESCE(HTS_TST_MSM_pos.value,0) AS HTS_TST_MSM_pos,
COALESCE(HTS_TST_MSM_neg.value,0) AS HTS_TST_MSM_neg,
COALESCE(HTS_TST_TG_pos.value,0) AS HTS_TST_TG_pos,
COALESCE(HTS_TST_TG_neg.value,0) AS HTS_TST_TG_neg,
COALESCE(HTS_TST_FSW_pos.value,0) AS HTS_TST_FSW_pos,
COALESCE(HTS_TST_FSW_neg.value,0) AS HTS_TST_FSW_neg,
COALESCE(HTS_TST_Closed_pos.value,0) AS HTS_TST_Closed_pos,
COALESCE(HTS_TST_Closed_neg.value,0) AS HTS_TST_Closed_neg,
/*Auto-Calculate*/
/*HTS_TST Index Testing*/
(
COALESCE(cpn_index_contact_pos.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_f_pos.value,0)+COALESCE(VCT_index_0_8_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_0_8_m_pos.value,0)+COALESCE(VCT_index_0_8_m_pos.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_pos.value,0)+COALESCE(VCT_index_9_18_f_pos.value,0)+COALESCE(VCT_index_19_4_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_pos.value,0)+COALESCE(VCT_index_9_18_m_pos.value,0)+COALESCE(VCT_index_19_4_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_f_pos.value,0)+COALESCE(VCT_index_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_m_pos.value,0)+COALESCE(VCT_index_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_f_pos.value,0)+COALESCE(VCT_index_10_14_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_m_pos.value,0)+COALESCE(VCT_index_10_14_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_f_pos.value,0)+COALESCE(VCT_index_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_m_pos.value,0)+COALESCE(VCT_index_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_f_pos.value,0)+COALESCE(VCT_index_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_m_pos.value,0)+COALESCE(VCT_index_20_24_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_f_pos.value,0)+COALESCE(VCT_index_25_29_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_m_pos.value,0)+COALESCE(VCT_index_25_29_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_f_pos.value,0)+COALESCE(VCT_index_30_49_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_m_pos.value,0)+COALESCE(VCT_index_30_49_m_pos.value,0)+
(COALESCE(HTS_TST_Other_index_35_39_f_pos.value,0)+COALESCE(VCT_index_35_39_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_35_39_m_pos.value,0)+COALESCE(VCT_index_35_39_m_pos.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_f_pos.value,0)+COALESCE(VCT_index_40_44_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_m_pos.value,0)+COALESCE(VCT_index_40_44_m_pos.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_f_pos.value,0)+COALESCE(VCT_index_45_49_f_pos.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_m_pos.value,0)+COALESCE(VCT_index_45_49_m_pos.value,0))+
COALESCE(HTS_TST_Other_index_50_f_pos.value,0)+COALESCE(VCT_index_50_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_50_m_pos.value,0)+COALESCE(VCT_index_50_m_pos.value,0) 
) AS Index_pos,
(
COALESCE(cpn_index_contact_neg.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_f_neg.value,0)+COALESCE(VCT_index_0_8_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_0_8_m_neg.value,0)+COALESCE(VCT_index_0_8_m_neg.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_f_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_neg.value,0)+COALESCE(VCT_index_9_18_f_neg.value,0)+COALESCE(VCT_index_19_4_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_9_18_m_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_neg.value,0)+COALESCE(VCT_index_9_18_m_neg.value,0)+COALESCE(VCT_index_19_4_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_5_9_f_neg.value,0)+COALESCE(VCT_index_5_9_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_5_9_m_neg.value,0)+COALESCE(VCT_index_5_9_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_10_14_f_neg.value,0)+COALESCE(VCT_index_10_14_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_10_14_m_neg.value,0)+COALESCE(VCT_index_10_14_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_15_19_f_neg.value,0)+COALESCE(VCT_index_15_19_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_15_19_m_neg.value,0)+COALESCE(VCT_index_15_19_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_20_24_f_neg.value,0)+COALESCE(VCT_index_20_24_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_20_24_m_neg.value,0)+COALESCE(VCT_index_20_24_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_25_29_f_neg.value,0)+COALESCE(VCT_index_25_29_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_25_29_m_neg.value,0)+COALESCE(VCT_index_25_29_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_30_49_f_neg.value,0)+COALESCE(VCT_index_30_49_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_30_49_m_neg.value,0)+COALESCE(VCT_index_30_49_m_neg.value,0)+
(COALESCE(HTS_TST_Other_index_35_39_f_neg.value,0)+COALESCE(VCT_index_35_39_f_neg.value,0))+
(COALESCE(HTS_TST_Other_index_35_39_m_neg.value,0)+COALESCE(VCT_index_35_39_m_neg.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_f_neg.value,0)+COALESCE(VCT_index_40_44_f_neg.value,0))+
(COALESCE(HTS_TST_Other_index_40_44_m_neg.value,0)+COALESCE(VCT_index_40_44_m_neg.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_f_neg.value,0)+COALESCE(VCT_index_45_49_f_neg.value,0))+
(COALESCE(HTS_TST_Other_index_45_49_m_neg.value,0)+COALESCE(VCT_index_45_49_m_neg.value,0))+
COALESCE(HTS_TST_Other_index_50_f_neg.value,0)+COALESCE(VCT_index_50_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_50_m_neg.value,0)+COALESCE(VCT_index_50_m_neg.value,0) 
) AS Index_neg,
/*HTS_TST (Facility)-PITC Inpatient Services*/
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Inpatient_0_8_f_pos.value,0) AS HTS_TST_Inpatient_men1_f_pos,
COALESCE(HTS_TST_Inpatient_0_8_f_neg.value,0) AS HTS_TST_Inpatient_men1_f_neg,
COALESCE(HTS_TST_Inpatient_0_8_m_pos.value,0) AS HTS_TST_Inpatient_men1_m_pos,
COALESCE(HTS_TST_Inpatient_0_8_m_neg.value,0) AS HTS_TST_Inpatient_men1_m_neg,
*/
0 AS HTS_TST_Inpatient_men1_f_pos,
0 AS HTS_TST_Inpatient_men1_f_neg,
0 AS HTS_TST_Inpatient_men1_m_pos,
0 AS HTS_TST_Inpatient_men1_m_neg,
(COALESCE(HTS_TST_Inpatient_9_18_f_pos.value,0)+COALESCE(HTS_TST_Inpatient_19_4_f_pos.value,0)) AS HTS_TST_Inpatient_1_4_f_pos,
(COALESCE(HTS_TST_Inpatient_9_18_f_neg.value,0)+COALESCE(HTS_TST_Inpatient_19_4_f_neg.value,0)) AS HTS_TST_Inpatient_1_4_f_neg,
(COALESCE(HTS_TST_Inpatient_9_18_m_pos.value,0)+COALESCE(HTS_TST_Inpatient_19_4_m_pos.value,0)) AS HTS_TST_Inpatient_1_4_m_pos,
(COALESCE(HTS_TST_Inpatient_9_18_m_neg.value,0)+COALESCE(HTS_TST_Inpatient_19_4_m_neg.value,0)) AS HTS_TST_Inpatient_1_4_m_neg,
COALESCE(HTS_TST_Inpatient_5_9_f_pos.value,0) AS HTS_TST_Inpatient_5_9_f_pos,
COALESCE(HTS_TST_Inpatient_5_9_f_neg.value,0) AS HTS_TST_Inpatient_5_9_f_neg,
COALESCE(HTS_TST_Inpatient_5_9_m_pos.value,0) AS HTS_TST_Inpatient_5_9_m_pos,
COALESCE(HTS_TST_Inpatient_5_9_m_neg.value,0) AS HTS_TST_Inpatient_5_9_m_neg,
COALESCE(HTS_TST_Inpatient_10_14_f_pos.value,0) AS HTS_TST_Inpatient_10_14_f_pos,
COALESCE(HTS_TST_Inpatient_10_14_f_neg.value,0) AS HTS_TST_Inpatient_10_14_f_neg,
COALESCE(HTS_TST_Inpatient_10_14_m_pos.value,0) AS HTS_TST_Inpatient_10_14_m_pos,
COALESCE(HTS_TST_Inpatient_10_14_m_neg.value,0) AS HTS_TST_Inpatient_10_14_m_neg,
COALESCE(HTS_TST_Inpatient_15_19_f_pos.value,0) AS HTS_TST_Inpatient_15_19_f_pos,
COALESCE(HTS_TST_Inpatient_15_19_f_neg.value,0) AS HTS_TST_Inpatient_15_19_f_neg,
COALESCE(HTS_TST_Inpatient_15_19_m_pos.value,0) AS HTS_TST_Inpatient_15_19_m_pos,
COALESCE(HTS_TST_Inpatient_15_19_m_neg.value,0) AS HTS_TST_Inpatient_15_19_m_neg,
COALESCE(HTS_TST_Inpatient_20_24_f_pos.value,0) AS HTS_TST_Inpatient_20_24_f_pos,
COALESCE(HTS_TST_Inpatient_20_24_f_neg.value,0) AS HTS_TST_Inpatient_20_24_f_neg,
COALESCE(HTS_TST_Inpatient_20_24_m_pos.value,0) AS HTS_TST_Inpatient_20_24_m_pos,
COALESCE(HTS_TST_Inpatient_20_24_m_neg.value,0) AS HTS_TST_Inpatient_20_24_m_neg,
COALESCE(HTS_TST_Inpatient_25_29_f_pos.value,0) AS HTS_TST_Inpatient_25_29_f_pos,
COALESCE(HTS_TST_Inpatient_25_29_f_neg.value,0) AS HTS_TST_Inpatient_25_29_f_neg,
COALESCE(HTS_TST_Inpatient_25_29_m_pos.value,0) AS HTS_TST_Inpatient_25_29_m_pos,
COALESCE(HTS_TST_Inpatient_25_29_m_neg.value,0) AS HTS_TST_Inpatient_25_29_m_neg,
COALESCE(HTS_TST_Inpatient_30_49_f_pos.value,0) AS HTS_TST_Inpatient_30_34_f_pos,
COALESCE(HTS_TST_Inpatient_30_49_f_neg.value,0) AS HTS_TST_Inpatient_30_34_f_neg,
COALESCE(HTS_TST_Inpatient_30_49_m_pos.value,0) AS HTS_TST_Inpatient_30_34_m_pos,
COALESCE(HTS_TST_Inpatient_30_49_m_neg.value,0) AS HTS_TST_Inpatient_30_34_m_neg,
COALESCE(HTS_TST_Inpatient_35_39_f_pos.value,0) AS HTS_TST_Inpatient_35_39_f_pos,
COALESCE(HTS_TST_Inpatient_35_39_f_neg.value,0) AS HTS_TST_Inpatient_35_39_f_neg,
COALESCE(HTS_TST_Inpatient_35_39_m_pos.value,0) AS HTS_TST_Inpatient_35_39_m_pos,
COALESCE(HTS_TST_Inpatient_35_39_m_neg.value,0) AS HTS_TST_Inpatient_35_39_m_neg,
COALESCE(HTS_TST_Inpatient_40_44_f_pos.value,0) AS HTS_TST_Inpatient_40_44_f_pos,
COALESCE(HTS_TST_Inpatient_40_44_f_neg.value,0) AS HTS_TST_Inpatient_40_44_f_neg,
COALESCE(HTS_TST_Inpatient_40_44_m_pos.value,0) AS HTS_TST_Inpatient_40_44_m_pos,
COALESCE(HTS_TST_Inpatient_40_44_m_neg.value,0) AS HTS_TST_Inpatient_40_44_m_neg,
COALESCE(HTS_TST_Inpatient_45_49_f_pos.value,0) AS HTS_TST_Inpatient_45_49_f_pos,
COALESCE(HTS_TST_Inpatient_45_49_f_neg.value,0) AS HTS_TST_Inpatient_45_49_f_neg,
COALESCE(HTS_TST_Inpatient_45_49_m_pos.value,0) AS HTS_TST_Inpatient_45_49_m_pos,
COALESCE(HTS_TST_Inpatient_45_49_m_neg.value,0) AS HTS_TST_Inpatient_45_49_m_neg,
COALESCE(HTS_TST_Inpatient_50_f_pos.value,0) AS HTS_TST_Inpatient_50_f_pos,
COALESCE(HTS_TST_Inpatient_50_f_neg.value,0) AS HTS_TST_Inpatient_50_f_neg,
COALESCE(HTS_TST_Inpatient_50_m_pos.value,0) AS HTS_TST_Inpatient_50_m_pos,
COALESCE(HTS_TST_Inpatient_50_m_neg.value,0) AS HTS_TST_Inpatient_50_m_neg,
/*HTS_TST (Facility)-PITC Pediatric Services*/
'' AS placeholder11,
'' AS placeholder12,
'' AS placeholder13,
'' AS placeholder14,
COALESCE(HTS_TST_Pediatric_19_4_f_pos.value,0) AS HTS_TST_Pediatric_1_4_f_pos,
COALESCE(HTS_TST_Pediatric_19_4_f_neg.value,0) AS HTS_TST_Pediatric_1_4_f_neg,
COALESCE(HTS_TST_Pediatric_19_4_m_pos.value,0) AS HTS_TST_Pediatric_1_4_m_pos,
COALESCE(HTS_TST_Pediatric_19_4_m_neg.value,0) AS HTS_TST_Pediatric_1_4_m_neg,
/*Auto-Calculate*/
/*HTS_TST (Facility)-PITC-TB Clinics*/
(
COALESCE(HTS_TST_TB_men1_f_pos.value,0)+
COALESCE(HTS_TST_TB_men1_m_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_f_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_m_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_f_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_m_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_f_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_m_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_f_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_m_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_f_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_m_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_f_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_m_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_f_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_m_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_f_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_m_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_f_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_m_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_f_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_m_pos.value,0)+
COALESCE(HTS_TST_TB_50_f_pos.value,0)+
COALESCE(HTS_TST_TB_50_m_pos.value,0) 
) AS HTS_TST_TB_pos,
(
COALESCE(HTS_TST_TB_men1_f_neg.value,0)+
COALESCE(HTS_TST_TB_men1_m_neg.value,0)+
COALESCE(HTS_TST_TB_1_4_f_neg.value,0)+
COALESCE(HTS_TST_TB_1_4_m_neg.value,0)+
COALESCE(HTS_TST_TB_5_9_f_neg.value,0)+
COALESCE(HTS_TST_TB_5_9_m_neg.value,0)+
COALESCE(HTS_TST_TB_10_14_f_neg.value,0)+
COALESCE(HTS_TST_TB_10_14_m_neg.value,0)+
COALESCE(HTS_TST_TB_15_19_f_neg.value,0)+
COALESCE(HTS_TST_TB_15_19_m_neg.value,0)+
COALESCE(HTS_TST_TB_20_24_f_neg.value,0)+
COALESCE(HTS_TST_TB_20_24_m_neg.value,0)+
COALESCE(HTS_TST_TB_25_29_f_neg.value,0)+
COALESCE(HTS_TST_TB_25_29_m_neg.value,0)+
COALESCE(HTS_TST_TB_30_34_f_neg.value,0)+
COALESCE(HTS_TST_TB_30_34_m_neg.value,0)+
COALESCE(HTS_TST_TB_35_39_f_neg.value,0)+
COALESCE(HTS_TST_TB_35_39_m_neg.value,0)+
COALESCE(HTS_TST_TB_40_44_f_neg.value,0)+
COALESCE(HTS_TST_TB_40_44_m_neg.value,0)+
COALESCE(HTS_TST_TB_45_49_f_neg.value,0)+
COALESCE(HTS_TST_TB_45_49_m_neg.value,0)+
COALESCE(HTS_TST_TB_50_f_neg.value,0)+
COALESCE(HTS_TST_TB_50_m_neg.value,0)+
/*Known Negative*/
COALESCE(TB_STAT_kn_men1_f.value,0)+
COALESCE(TB_STAT_kn_men1_m.value,0)+
COALESCE(TB_STAT_kn_1_4_f.value,0)+
COALESCE(TB_STAT_kn_1_4_m.value,0)+
COALESCE(TB_STAT_kn_5_9_f.value,0)+
COALESCE(TB_STAT_kn_5_9_m.value,0)+
COALESCE(TB_STAT_kn_10_14_f.value,0)+
COALESCE(TB_STAT_kn_10_14_m.value,0)+
COALESCE(TB_STAT_kn_15_19_f.value,0)+
COALESCE(TB_STAT_kn_15_19_m.value,0)+
COALESCE(TB_STAT_kn_20_24_f.value,0)+
COALESCE(TB_STAT_kn_20_24_m.value,0)+
COALESCE(TB_STAT_kn_25_29_f.value,0)+
COALESCE(TB_STAT_kn_25_29_m.value,0)+
COALESCE(TB_STAT_kn_30_34_f.value,0)+
COALESCE(TB_STAT_kn_30_34_m.value,0)+
COALESCE(TB_STAT_kn_35_39_f.value,0)+
COALESCE(TB_STAT_kn_35_39_m.value,0)+
COALESCE(TB_STAT_kn_40_44_f.value,0)+
COALESCE(TB_STAT_kn_40_44_m.value,0)+
COALESCE(TB_STAT_kn_45_49_f.value,0)+
COALESCE(TB_STAT_kn_45_49_m.value,0)+
COALESCE(TB_STAT_kn_50_f.value,0)+
COALESCE(TB_STAT_kn_50_m.value,0)
) AS HTS_TST_TB_neg,
/*Auto-Calculate*/
/*HTS_TST (Facility)-PITC PMTCT (ANC1 Only) Clinics*/
(
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0)+
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0)+
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0)+
COALESCE(HTS_TST_PMTCT_25_pos.value,0) 
) AS HTS_TST_PMTCT_pos,
(
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0)+
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0)+
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0)+
COALESCE(HTS_TST_PMTCT_25_neg.value,0) 
) AS HTS_TST_PMTCT_neg,
/*HTS_TST (Facility)-PITC PMTCT (Post ANC1)*/
(COALESCE(mat_10_14_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_10_14_f_pos.value,0)+COALESCE(PMTCT_STAT_10_14_repeat_pos.value,0)) AS HTS_TST_PMTCT_POST_10_14_pos,
(COALESCE(mat_10_14_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_10_14_f_neg.value,0)+COALESCE(PMTCT_STAT_10_14_repeat_neg.value,0)) AS HTS_TST_PMTCT_POST_10_14_neg,
(COALESCE(mat_15_19_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_15_19_f_pos.value,0)+COALESCE(PMTCT_STAT_15_19_repeat_pos.value,0)) AS HTS_TST_PMTCT_POST_15_19_pos,
(COALESCE(mat_15_19_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_15_19_f_neg.value,0)+COALESCE(PMTCT_STAT_15_19_repeat_neg.value,0)) AS HTS_TST_PMTCT_POST_15_19_neg,
(COALESCE(mat_20_24_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_20_24_f_pos.value,0)+COALESCE(PMTCT_STAT_20_24_repeat_pos.value,0)) AS HTS_TST_PMTCT_POST_20_24_pos,
(COALESCE(mat_20_24_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_20_24_f_neg.value,0)+COALESCE(PMTCT_STAT_20_24_repeat_neg.value,0)) AS HTS_TST_PMTCT_POST_20_24_neg,
(COALESCE(mat_25_29_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_25_29_f_pos.value,0)+COALESCE(PMTCT_STAT_25_repeat_pos.value,0) ) AS HTS_TST_PMTCT_POST_25_29_pos,
(COALESCE(mat_25_29_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_25_29_f_neg.value,0)+COALESCE(PMTCT_STAT_25_repeat_neg.value,0) ) AS HTS_TST_PMTCT_POST_25_29_neg,
(COALESCE(mat_30_34_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_30_49_f_pos.value,0)) AS HTS_TST_PMTCT_POST_30_34_pos,
(COALESCE(mat_30_34_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_30_49_f_neg.value,0)) AS HTS_TST_PMTCT_POST_30_34_neg,
(COALESCE(mat_35_39_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_35_39_f_pos.value,0)) AS HTS_TST_PMTCT_POST_35_39_pos,
(COALESCE(mat_35_39_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_35_39_f_neg.value,0)) AS HTS_TST_PMTCT_POST_35_39_neg,
(COALESCE(mat_40_44_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_40_44_f_pos.value,0)) AS HTS_TST_PMTCT_POST_40_44_pos,
(COALESCE(mat_40_44_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_40_44_f_neg.value,0)) AS HTS_TST_PMTCT_POST_40_44_neg,
(COALESCE(mat_45_49_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_45_49_f_pos.value,0)) AS HTS_TST_PMTCT_POST_45_49_pos,
(COALESCE(mat_45_49_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_45_49_f_neg.value,0)) AS HTS_TST_PMTCT_POST_45_49_neg,
(COALESCE(mat_50_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_50_f_pos.value,0)) AS HTS_TST_PMTCT_POST_50_pos,
(COALESCE(mat_50_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_50_f_neg.value,0)) AS HTS_TST_PMTCT_POST_50_neg,
/*HTS_TST (Facility)-PITC Emergency Ward*/
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Emergency_0_8_f_pos.value,0) AS HTS_TST_Emergency_men1_f_pos,
COALESCE(HTS_TST_Emergency_0_8_f_neg.value,0) AS HTS_TST_Emergency_men1_f_neg,
COALESCE(HTS_TST_Emergency_0_8_m_pos.value,0) AS HTS_TST_Emergency_men1_m_pos,
COALESCE(HTS_TST_Emergency_0_8_m_neg.value,0) AS HTS_TST_Emergency_men1_m_neg,
*/
0 AS HTS_TST_Emergency_men1_f_pos,
0 AS HTS_TST_Emergency_men1_f_neg,
0 AS HTS_TST_Emergency_men1_m_pos,
0 AS HTS_TST_Emergency_men1_m_neg,
(COALESCE(HTS_TST_Emergency_9_18_f_pos.value,0)+COALESCE(HTS_TST_Emergency_19_4_f_pos.value,0)) AS HTS_TST_Emergency_1_4_f_pos,
(COALESCE(HTS_TST_Emergency_9_18_f_neg.value,0)+COALESCE(HTS_TST_Emergency_19_4_f_neg.value,0)) AS HTS_TST_Emergency_1_4_f_neg,
(COALESCE(HTS_TST_Emergency_9_18_m_pos.value,0)+COALESCE(HTS_TST_Emergency_19_4_m_pos.value,0)) AS HTS_TST_Emergency_1_4_m_pos,
(COALESCE(HTS_TST_Emergency_9_18_m_neg.value,0)+COALESCE(HTS_TST_Emergency_19_4_m_neg.value,0)) AS HTS_TST_Emergency_1_4_m_neg,
COALESCE(HTS_TST_Emergency_5_9_f_pos.value,0) AS HTS_TST_Emergency_5_9_f_pos,
COALESCE(HTS_TST_Emergency_5_9_f_neg.value,0) AS HTS_TST_Emergency_5_9_f_neg,
COALESCE(HTS_TST_Emergency_5_9_m_pos.value,0) AS HTS_TST_Emergency_5_9_m_pos,
COALESCE(HTS_TST_Emergency_5_9_m_neg.value,0) AS HTS_TST_Emergency_5_9_m_neg,
COALESCE(HTS_TST_Emergency_10_14_f_pos.value,0) AS HTS_TST_Emergency_10_14_f_pos,
COALESCE(HTS_TST_Emergency_10_14_f_neg.value,0) AS HTS_TST_Emergency_10_14_f_neg,
COALESCE(HTS_TST_Emergency_10_14_m_pos.value,0) AS HTS_TST_Emergency_10_14_m_pos,
COALESCE(HTS_TST_Emergency_10_14_m_neg.value,0) AS HTS_TST_Emergency_10_14_m_neg,
COALESCE(HTS_TST_Emergency_15_19_f_pos.value,0) AS HTS_TST_Emergency_15_19_f_pos,
COALESCE(HTS_TST_Emergency_15_19_f_neg.value,0) AS HTS_TST_Emergency_15_19_f_neg,
COALESCE(HTS_TST_Emergency_15_19_m_pos.value,0) AS HTS_TST_Emergency_15_19_m_pos,
COALESCE(HTS_TST_Emergency_15_19_m_neg.value,0) AS HTS_TST_Emergency_15_19_m_neg,
COALESCE(HTS_TST_Emergency_20_24_f_pos.value,0) AS HTS_TST_Emergency_20_24_f_pos,
COALESCE(HTS_TST_Emergency_20_24_f_neg.value,0) AS HTS_TST_Emergency_20_24_f_neg,
COALESCE(HTS_TST_Emergency_20_24_m_pos.value,0) AS HTS_TST_Emergency_20_24_m_pos,
COALESCE(HTS_TST_Emergency_20_24_m_neg.value,0) AS HTS_TST_Emergency_20_24_m_neg,
COALESCE(HTS_TST_Emergency_25_29_f_pos.value,0) AS HTS_TST_Emergency_25_29_f_pos,
COALESCE(HTS_TST_Emergency_25_29_f_neg.value,0) AS HTS_TST_Emergency_25_29_f_neg,
COALESCE(HTS_TST_Emergency_25_29_m_pos.value,0) AS HTS_TST_Emergency_25_29_m_pos,
COALESCE(HTS_TST_Emergency_25_29_m_neg.value,0) AS HTS_TST_Emergency_25_29_m_neg,
COALESCE(HTS_TST_Emergency_30_49_f_pos.value,0) AS HTS_TST_Emergency_30_49_f_pos,
COALESCE(HTS_TST_Emergency_30_49_f_neg.value,0) AS HTS_TST_Emergency_30_49_f_neg,
COALESCE(HTS_TST_Emergency_30_49_m_pos.value,0) AS HTS_TST_Emergency_30_49_m_pos,
COALESCE(HTS_TST_Emergency_30_49_m_neg.value,0) AS HTS_TST_Emergency_30_49_m_neg,
COALESCE(HTS_TST_Emergency_35_39_f_pos.value,0) AS HTS_TST_Emergency_35_39_f_pos,
COALESCE(HTS_TST_Emergency_35_39_f_neg.value,0) AS HTS_TST_Emergency_35_39_f_neg,
COALESCE(HTS_TST_Emergency_35_39_m_pos.value,0) AS HTS_TST_Emergency_35_39_m_pos,
COALESCE(HTS_TST_Emergency_35_39_m_neg.value,0) AS HTS_TST_Emergency_35_39_m_neg,
COALESCE(HTS_TST_Emergency_40_44_f_pos.value,0) AS HTS_TST_Emergency_40_44_f_pos,
COALESCE(HTS_TST_Emergency_40_44_f_neg.value,0) AS HTS_TST_Emergency_40_44_f_neg,
COALESCE(HTS_TST_Emergency_40_44_m_pos.value,0) AS HTS_TST_Emergency_40_44_m_pos,
COALESCE(HTS_TST_Emergency_40_44_m_neg.value,0) AS HTS_TST_Emergency_40_44_m_neg,
COALESCE(HTS_TST_Emergency_45_49_f_pos.value,0) AS HTS_TST_Emergency_45_49_f_pos,
COALESCE(HTS_TST_Emergency_45_49_f_neg.value,0) AS HTS_TST_Emergency_45_49_f_neg,
COALESCE(HTS_TST_Emergency_45_49_m_pos.value,0) AS HTS_TST_Emergency_45_49_m_pos,
COALESCE(HTS_TST_Emergency_45_49_m_neg.value,0) AS HTS_TST_Emergency_45_49_m_neg,
COALESCE(HTS_TST_Emergency_50_f_pos.value,0) AS HTS_TST_Emergency_50_f_pos,
COALESCE(HTS_TST_Emergency_50_f_neg.value,0) AS HTS_TST_Emergency_50_f_neg,
COALESCE(HTS_TST_Emergency_50_m_pos.value,0) AS HTS_TST_Emergency_50_m_pos,
COALESCE(HTS_TST_Emergency_50_m_neg.value,0) AS HTS_TST_Emergency_50_m_neg,
/*HTS_TST (Facility)-Other PITC*/
'' AS placeholder17,
'' AS placeholder18,
COALESCE(cpn_m_pos.value,0) AS HTS_TST_Other_u_m_pos,
COALESCE(cpn_m_neg.value,0) AS HTS_TST_Other_u_m_neg,
/*REMOVING CHILD <1y
(COALESCE(HTS_TST_Other_0_8_f_pos.value,0)+COALESCE(mat_men1_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_0_8_f_pos.value,0)) AS HTS_TST_Other_men1_f_pos,
(COALESCE(HTS_TST_Other_0_8_f_neg.value,0)+COALESCE(mat_men1_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_0_8_f_neg.value,0)) AS HTS_TST_Other_men1_f_neg,
COALESCE(HTS_TST_Other_0_8_m_pos.value,0) AS HTS_TST_Other_men1_m_pos,
COALESCE(HTS_TST_Other_0_8_m_neg.value,0) AS HTS_TST_Other_men1_m_neg,
*/
0 AS HTS_TST_Other_men1_f_pos,
0 AS HTS_TST_Other_men1_f_neg,
0 AS HTS_TST_Other_men1_m_pos,
0 AS HTS_TST_Other_men1_m_neg,
(COALESCE(HTS_TST_Other_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_19_4_f_pos.value,0)+COALESCE(mat_1_4_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_9_18_f_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_19_4_f_pos.value,0)) AS HTS_TST_Other_1_4_f_pos,
(COALESCE(HTS_TST_Other_9_18_f_neg.value,0)+COALESCE(HTS_TST_Other_19_4_f_neg.value,0)+COALESCE(mat_1_4_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_9_18_f_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_19_4_f_neg.value,0)) AS HTS_TST_Other_1_4_f_neg,
(COALESCE(HTS_TST_Other_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_19_4_m_pos.value,0)) AS HTS_TST_Other_1_4_m_pos,
(COALESCE(HTS_TST_Other_9_18_m_neg.value,0)+COALESCE(HTS_TST_Other_19_4_m_neg.value,0)) AS HTS_TST_Other_1_4_m_neg,
(COALESCE(HTS_TST_Other_5_9_f_pos.value,0)+COALESCE(mat_5_9_pos.value,0)+COALESCE(HTS_TST_PMTCT_POST_5_9_f_pos.value,0)) AS HTS_TST_Other_5_9_f_pos,
(COALESCE(HTS_TST_Other_5_9_f_neg.value,0)+COALESCE(mat_5_9_neg.value,0)+COALESCE(HTS_TST_PMTCT_POST_5_9_f_neg.value,0)) AS HTS_TST_Other_5_9_f_neg,
COALESCE(HTS_TST_Other_5_9_m_pos.value,0) AS HTS_TST_Other_5_9_m_pos,
COALESCE(HTS_TST_Other_5_9_m_neg.value,0) AS HTS_TST_Other_5_9_m_neg,
COALESCE(HTS_TST_Other_10_14_f_pos.value,0) AS HTS_TST_Other_10_14_f_pos,
COALESCE(HTS_TST_Other_10_14_f_neg.value,0) AS HTS_TST_Other_10_14_f_neg,
COALESCE(HTS_TST_Other_10_14_m_pos.value,0) AS HTS_TST_Other_10_14_m_pos,
COALESCE(HTS_TST_Other_10_14_m_neg.value,0) AS HTS_TST_Other_10_14_m_neg,
COALESCE(HTS_TST_Other_15_19_f_pos.value,0) AS HTS_TST_Other_15_19_f_pos,
COALESCE(HTS_TST_Other_15_19_f_neg.value,0) AS HTS_TST_Other_15_19_f_neg,
COALESCE(HTS_TST_Other_15_19_m_pos.value,0) AS HTS_TST_Other_15_19_m_pos,
COALESCE(HTS_TST_Other_15_19_m_neg.value,0) AS HTS_TST_Other_15_19_m_neg,
COALESCE(HTS_TST_Other_20_24_f_pos.value,0) AS HTS_TST_Other_20_24_f_pos,
COALESCE(HTS_TST_Other_20_24_f_neg.value,0) AS HTS_TST_Other_20_24_f_neg,
COALESCE(HTS_TST_Other_20_24_m_pos.value,0) AS HTS_TST_Other_20_24_m_pos,
COALESCE(HTS_TST_Other_20_24_m_neg.value,0) AS HTS_TST_Other_20_24_m_neg,
COALESCE(HTS_TST_Other_25_29_f_pos.value,0) AS HTS_TST_Other_25_29_f_pos,
COALESCE(HTS_TST_Other_25_29_f_neg.value,0) AS HTS_TST_Other_25_29_f_neg,
COALESCE(HTS_TST_Other_25_29_m_pos.value,0) AS HTS_TST_Other_25_29_m_pos,
COALESCE(HTS_TST_Other_25_29_m_neg.value,0) AS HTS_TST_Other_25_29_m_neg,
COALESCE(HTS_TST_Other_30_49_f_pos.value,0) AS HTS_TST_Other_30_34_f_pos,
COALESCE(HTS_TST_Other_30_49_f_neg.value,0) AS HTS_TST_Other_30_34_f_neg,
COALESCE(HTS_TST_Other_30_49_m_pos.value,0) AS HTS_TST_Other_30_34_m_pos,
COALESCE(HTS_TST_Other_30_49_m_neg.value,0) AS HTS_TST_Other_30_34_m_neg,
COALESCE(HTS_TST_Other_35_39_f_pos.value,0) AS HTS_TST_Other_35_39_f_pos,
COALESCE(HTS_TST_Other_35_39_f_neg.value,0) AS HTS_TST_Other_35_39_f_neg,
COALESCE(HTS_TST_Other_35_39_m_pos.value,0) AS HTS_TST_Other_35_39_m_pos,
COALESCE(HTS_TST_Other_35_39_m_neg.value,0) AS HTS_TST_Other_35_39_m_neg,
COALESCE(HTS_TST_Other_40_44_f_pos.value,0) AS HTS_TST_Other_40_44_f_pos,
COALESCE(HTS_TST_Other_40_44_f_neg.value,0) AS HTS_TST_Other_40_44_f_neg,
COALESCE(HTS_TST_Other_40_44_m_pos.value,0) AS HTS_TST_Other_40_44_m_pos,
COALESCE(HTS_TST_Other_40_44_m_neg.value,0) AS HTS_TST_Other_40_44_m_neg,
COALESCE(HTS_TST_Other_45_49_f_pos.value,0) AS HTS_TST_Other_45_49_f_pos,
COALESCE(HTS_TST_Other_45_49_f_neg.value,0) AS HTS_TST_Other_45_49_f_neg,
COALESCE(HTS_TST_Other_45_49_m_pos.value,0) AS HTS_TST_Other_45_49_m_pos,
COALESCE(HTS_TST_Other_45_49_m_neg.value,0) AS HTS_TST_Other_45_49_m_neg,
COALESCE(HTS_TST_Other_50_f_pos.value,0) AS HTS_TST_Other_50_f_pos,
COALESCE(HTS_TST_Other_50_f_neg.value,0) AS HTS_TST_Other_50_f_neg,
COALESCE(HTS_TST_Other_50_m_pos.value,0) AS HTS_TST_Other_50_m_pos,
COALESCE(HTS_TST_Other_50_m_neg.value,0) AS HTS_TST_Other_50_m_neg,
/*HTS_TST (Facility)-VCT*/
/*REMOVING CHILD <1y
COALESCE(VCT_0_8_f_pos.value,0) AS HTS_TST_VCT_men1_f_pos,
COALESCE(VCT_0_8_f_neg.value,0) AS HTS_TST_VCT_men1_f_neg,
COALESCE(VCT_0_8_m_pos.value,0) AS HTS_TST_VCT_men1_m_pos,
COALESCE(VCT_0_8_m_neg.value,0) AS HTS_TST_VCT_men1_m_neg,
*/
0 AS HTS_TST_VCT_men1_f_pos,
0 AS HTS_TST_VCT_men1_f_neg,
0 AS HTS_TST_VCT_men1_m_pos,
0 AS HTS_TST_VCT_men1_m_neg,
(COALESCE(VCT_9_18_f_pos.value,0)+COALESCE(VCT_19_4_f_pos.value,0)) AS HTS_TST_VCT_1_4_f_pos,
(COALESCE(VCT_9_18_f_neg.value,0)+COALESCE(VCT_19_4_f_neg.value,0)) AS HTS_TST_VCT_1_4_f_neg,
(COALESCE(VCT_9_18_m_pos.value,0)+COALESCE(VCT_19_4_m_pos.value,0)) AS HTS_TST_VCT_1_4_m_pos,
(COALESCE(VCT_9_18_m_neg.value,0)+COALESCE(VCT_19_4_m_neg.value,0)) AS HTS_TST_VCT_1_4_m_neg,
COALESCE(VCT_5_9_f_pos.value,0) AS HTS_TST_VCT_5_9_f_pos,
COALESCE(VCT_5_9_f_neg.value,0) AS HTS_TST_VCT_5_9_f_neg,
COALESCE(VCT_5_9_m_pos.value,0) AS HTS_TST_VCT_5_9_m_pos,
COALESCE(VCT_5_9_m_neg.value,0) AS HTS_TST_VCT_5_9_m_neg,
COALESCE(VCT_10_14_f_pos.value,0) AS HTS_TST_VCT_10_14_f_pos,
COALESCE(VCT_10_14_f_neg.value,0) AS HTS_TST_VCT_10_14_f_neg,
COALESCE(VCT_10_14_m_pos.value,0) AS HTS_TST_VCT_10_14_m_pos,
COALESCE(VCT_10_14_m_neg.value,0) AS HTS_TST_VCT_10_14_m_neg,
COALESCE(VCT_15_19_f_pos.value,0) AS HTS_TST_VCT_15_19_f_pos,
COALESCE(VCT_15_19_f_neg.value,0) AS HTS_TST_VCT_15_19_f_neg,
COALESCE(VCT_15_19_m_pos.value,0) AS HTS_TST_VCT_15_19_m_pos,
COALESCE(VCT_15_19_m_neg.value,0) AS HTS_TST_VCT_15_19_m_neg,
COALESCE(VCT_20_24_f_pos.value,0) AS HTS_TST_VCT_20_24_f_pos,
COALESCE(VCT_20_24_f_neg.value,0) AS HTS_TST_VCT_20_24_f_neg,
COALESCE(VCT_20_24_m_pos.value,0) AS HTS_TST_VCT_20_24_m_pos,
COALESCE(VCT_20_24_m_neg.value,0) AS HTS_TST_VCT_20_24_m_neg,
COALESCE(VCT_25_29_f_pos.value,0) AS HTS_TST_VCT_25_29_f_pos,
COALESCE(VCT_25_29_f_neg.value,0) AS HTS_TST_VCT_25_29_f_neg,
COALESCE(VCT_25_29_m_pos.value,0) AS HTS_TST_VCT_25_29_m_pos,
COALESCE(VCT_25_29_m_neg.value,0) AS HTS_TST_VCT_25_29_m_neg,
COALESCE(VCT_30_49_f_pos.value,0) AS HTS_TST_VCT_30_34_f_pos,
COALESCE(VCT_30_49_f_neg.value,0) AS HTS_TST_VCT_30_34_f_neg,
COALESCE(VCT_30_49_m_pos.value,0) AS HTS_TST_VCT_30_34_m_pos,
COALESCE(VCT_30_49_m_neg.value,0) AS HTS_TST_VCT_30_34_m_neg,
COALESCE(VCT_35_39_f_pos.value,0) AS HTS_TST_VCT_35_39_f_pos,
COALESCE(VCT_35_39_f_neg.value,0) AS HTS_TST_VCT_35_39_f_neg,
COALESCE(VCT_35_39_m_pos.value,0) AS HTS_TST_VCT_35_39_m_pos,
COALESCE(VCT_35_39_m_neg.value,0) AS HTS_TST_VCT_35_39_m_neg,
COALESCE(VCT_40_44_f_pos.value,0) AS HTS_TST_VCT_40_44_f_pos,
COALESCE(VCT_40_44_f_neg.value,0) AS HTS_TST_VCT_40_44_f_neg,
COALESCE(VCT_40_44_m_pos.value,0) AS HTS_TST_VCT_40_44_m_pos,
COALESCE(VCT_40_44_m_neg.value,0) AS HTS_TST_VCT_40_44_m_neg,
COALESCE(VCT_45_49_f_pos.value,0) AS HTS_TST_VCT_45_49_f_pos,
COALESCE(VCT_45_49_f_neg.value,0) AS HTS_TST_VCT_45_49_f_neg,
COALESCE(VCT_45_49_m_pos.value,0) AS HTS_TST_VCT_45_49_m_pos,
COALESCE(VCT_45_49_m_neg.value,0) AS HTS_TST_VCT_45_49_m_neg,
COALESCE(VCT_50_f_pos.value,0) AS HTS_TST_VCT_50_f_pos,
COALESCE(VCT_50_f_neg.value,0) AS HTS_TST_VCT_50_f_neg,
COALESCE(VCT_50_m_pos.value,0) AS HTS_TST_VCT_50_m_pos,
COALESCE(VCT_50_m_neg.value,0) AS HTS_TST_VCT_50_m_neg,
/*Index Testing*/
/*OpenMRS*/
/*Ofered*/
'' AS placeholder75,
COALESCE(HTS_I_ofered_men1_f.value,0) AS HTS_I_ofered_men1_f,
COALESCE(HTS_I_ofered_1_4_f.value,0) AS HTS_I_ofered_1_4_f,
COALESCE(HTS_I_ofered_5_9_f.value,0) AS HTS_I_ofered_5_9_f,
COALESCE(HTS_I_ofered_10_14_f.value,0) AS HTS_I_ofered_10_14_f,
COALESCE(HTS_I_ofered_15_19_f.value,0) AS HTS_I_ofered_15_19_f,
COALESCE(HTS_I_ofered_20_24_f.value,0) AS HTS_I_ofered_20_24_f,
COALESCE(HTS_I_ofered_25_29_f.value,0) AS HTS_I_ofered_25_29_f,
COALESCE(HTS_I_ofered_30_34_f.value,0) AS HTS_I_ofered_30_34_f,
COALESCE(HTS_I_ofered_35_39_f.value,0) AS HTS_I_ofered_35_39_f,
COALESCE(HTS_I_ofered_40_44_f.value,0) AS HTS_I_ofered_40_44_f,
COALESCE(HTS_I_ofered_45_49_f.value,0) AS HTS_I_ofered_45_49_f,
COALESCE(HTS_I_ofered_50_f.value,0) AS HTS_I_ofered_50_f,
'' AS placeholder76,
COALESCE(HTS_I_ofered_men1_m.value,0) AS HTS_I_ofered_men1_m,
COALESCE(HTS_I_ofered_1_4_m.value,0) AS HTS_I_ofered_1_4_m,
COALESCE(HTS_I_ofered_5_9_m.value,0) AS HTS_I_ofered_5_9_m,
COALESCE(HTS_I_ofered_10_14_m.value,0) AS HTS_I_ofered_10_14_m,
COALESCE(HTS_I_ofered_15_19_m.value,0) AS HTS_I_ofered_15_19_m,
COALESCE(HTS_I_ofered_20_24_m.value,0) AS HTS_I_ofered_20_24_m,
COALESCE(HTS_I_ofered_25_29_m.value,0) AS HTS_I_ofered_25_29_m,
COALESCE(HTS_I_ofered_30_34_m.value,0) AS HTS_I_ofered_30_34_m,
COALESCE(HTS_I_ofered_35_39_m.value,0) AS HTS_I_ofered_35_39_m,
COALESCE(HTS_I_ofered_40_44_m.value,0) AS HTS_I_ofered_40_44_m,
COALESCE(HTS_I_ofered_45_49_m.value,0) AS HTS_I_ofered_45_49_m,
COALESCE(HTS_I_ofered_50_m.value,0) AS HTS_I_ofered_50_m,
/*Acepted*/
'' AS placeholder75,
COALESCE(HTS_I_acepted_men1_f.value,0) AS HTS_I_acepted_men1_f,
COALESCE(HTS_I_acepted_1_4_f.value,0) AS HTS_I_acepted_1_4_f,
COALESCE(HTS_I_acepted_5_9_f.value,0) AS HTS_I_acepted_5_9_f,
COALESCE(HTS_I_acepted_10_14_f.value,0) AS HTS_I_acepted_10_14_f,
COALESCE(HTS_I_acepted_15_19_f.value,0) AS HTS_I_acepted_15_19_f,
COALESCE(HTS_I_acepted_20_24_f.value,0) AS HTS_I_acepted_20_24_f,
COALESCE(HTS_I_acepted_25_29_f.value,0) AS HTS_I_acepted_25_29_f,
COALESCE(HTS_I_acepted_30_34_f.value,0) AS HTS_I_acepted_30_34_f,
COALESCE(HTS_I_acepted_35_39_f.value,0) AS HTS_I_acepted_35_39_f,
COALESCE(HTS_I_acepted_40_44_f.value,0) AS HTS_I_acepted_40_44_f,
COALESCE(HTS_I_acepted_45_49_f.value,0) AS HTS_I_acepted_45_49_f,
COALESCE(HTS_I_acepted_50_f.value,0) AS HTS_I_acepted_50_f,
'' AS placeholder76,
COALESCE(HTS_I_acepted_men1_m.value,0) AS HTS_I_acepted_men1_m,
COALESCE(HTS_I_acepted_1_4_m.value,0) AS HTS_I_acepted_1_4_m,
COALESCE(HTS_I_acepted_5_9_m.value,0) AS HTS_I_acepted_5_9_m,
COALESCE(HTS_I_acepted_10_14_m.value,0) AS HTS_I_acepted_10_14_m,
COALESCE(HTS_I_acepted_15_19_m.value,0) AS HTS_I_acepted_15_19_m,
COALESCE(HTS_I_acepted_20_24_m.value,0) AS HTS_I_acepted_20_24_m,
COALESCE(HTS_I_acepted_25_29_m.value,0) AS HTS_I_acepted_25_29_m,
COALESCE(HTS_I_acepted_30_34_m.value,0) AS HTS_I_acepted_30_34_m,
COALESCE(HTS_I_acepted_35_39_m.value,0) AS HTS_I_acepted_35_39_m,
COALESCE(HTS_I_acepted_40_44_m.value,0) AS HTS_I_acepted_40_44_m,
COALESCE(HTS_I_acepted_45_49_m.value,0) AS HTS_I_acepted_45_49_m,
COALESCE(HTS_I_acepted_50_m.value,0) AS HTS_I_acepted_50_m,
/*Elicited*/
'' AS placeholder77,
(COALESCE(cpn_index_contact_pos.value,0)+COALESCE(cpn_index_contact_neg.value,0)) AS CPN_index_contact_m,

(
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_f_pos.value,0)+COALESCE(VCT_index_0_8_f_pos.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_pos.value,0)+COALESCE(VCT_index_9_18_f_pos.value,0)+COALESCE(VCT_index_19_4_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_f_pos.value,0)+COALESCE(VCT_index_5_9_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_f_pos.value,0)+COALESCE(VCT_index_10_14_f_pos.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_f_neg.value,0)+COALESCE(VCT_index_0_8_f_neg.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_f_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_neg.value,0)+COALESCE(VCT_index_9_18_f_neg.value,0)+COALESCE(VCT_index_19_4_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_5_9_f_neg.value,0)+COALESCE(VCT_index_5_9_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_10_14_f_neg.value,0)+COALESCE(VCT_index_10_14_f_neg.value,0)
) AS Index_contact_men15_f,
(
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_m_pos.value,0)+COALESCE(VCT_index_0_8_m_pos.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_pos.value,0)+COALESCE(VCT_index_9_18_m_pos.value,0)+COALESCE(VCT_index_19_4_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_5_9_m_pos.value,0)+COALESCE(VCT_index_5_9_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_10_14_m_pos.value,0)+COALESCE(VCT_index_10_14_m_pos.value,0)+
/*REMOVING CHILD <1y
COALESCE(HTS_TST_Other_index_0_8_m_neg.value,0)+COALESCE(VCT_index_0_8_m_neg.value,0)+
*/
COALESCE(HTS_TST_Other_index_9_18_m_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_neg.value,0)+COALESCE(VCT_index_9_18_m_neg.value,0)+COALESCE(VCT_index_19_4_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_5_9_m_neg.value,0)+COALESCE(VCT_index_5_9_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_10_14_m_neg.value,0)+COALESCE(VCT_index_10_14_m_neg.value,0)
) AS Index_contact_men15_m,
(COALESCE(HTS_TST_Other_index_15_19_f_pos.value,0)+COALESCE(VCT_index_15_19_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_f_pos.value,0)+COALESCE(VCT_index_20_24_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_f_pos.value,0)+COALESCE(VCT_index_25_29_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_f_pos.value,0)+COALESCE(VCT_index_30_49_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_50_f_pos.value,0)+COALESCE(VCT_index_50_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_f_neg.value,0)+COALESCE(VCT_index_15_19_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_20_24_f_neg.value,0)+COALESCE(VCT_index_20_24_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_25_29_f_neg.value,0)+COALESCE(VCT_index_25_29_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_30_49_f_neg.value,0)+COALESCE(VCT_index_30_49_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_35_39_f_neg.value,0)+COALESCE(VCT_index_35_39_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_40_44_f_neg.value,0)+COALESCE(VCT_index_40_44_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_45_49_f_neg.value,0)+COALESCE(VCT_index_45_49_f_neg.value,0)+
COALESCE(HTS_TST_Other_index_35_39_f_pos.value,0)+COALESCE(VCT_index_35_39_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_40_44_f_pos.value,0)+COALESCE(VCT_index_40_44_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_45_49_f_pos.value,0)+COALESCE(VCT_index_45_49_f_pos.value,0)+
COALESCE(HTS_TST_Other_index_50_f_neg.value,0)+COALESCE(VCT_index_50_f_neg.value,0)
) AS Index_contact_mai15_f,
(COALESCE(HTS_TST_Other_index_15_19_m_pos.value,0)+COALESCE(VCT_index_15_19_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_20_24_m_pos.value,0)+COALESCE(VCT_index_20_24_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_25_29_m_pos.value,0)+COALESCE(VCT_index_25_29_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_30_49_m_pos.value,0)+COALESCE(VCT_index_30_49_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_50_m_pos.value,0)+COALESCE(VCT_index_50_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_15_19_m_neg.value,0)+COALESCE(VCT_index_15_19_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_20_24_m_neg.value,0)+COALESCE(VCT_index_20_24_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_25_29_m_neg.value,0)+COALESCE(VCT_index_25_29_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_30_49_m_neg.value,0)+COALESCE(VCT_index_30_49_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_35_39_m_neg.value,0)+COALESCE(VCT_index_35_39_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_40_44_m_neg.value,0)+COALESCE(VCT_index_40_44_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_45_49_m_neg.value,0)+COALESCE(VCT_index_45_49_m_neg.value,0)+
COALESCE(HTS_TST_Other_index_35_39_m_pos.value,0)+COALESCE(VCT_index_35_39_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_40_44_m_pos.value,0)+COALESCE(VCT_index_40_44_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_45_49_m_pos.value,0)+COALESCE(VCT_index_45_49_m_pos.value,0)+
COALESCE(HTS_TST_Other_index_50_m_neg.value,0)+COALESCE(VCT_index_50_m_neg.value,0)
) AS Index_contact_mai15_m,
/*Contacts*/
COALESCE(cpn_index_contact_pos.value,0) AS CPN_index_contact_m_pos_unk,
/*REMOVING CHILD <1y
(COALESCE(HTS_TST_Other_index_0_8_f_pos.value,0)+COALESCE(VCT_index_0_8_f_pos.value,0)) AS HTS_TST_Index_men1_f_pos,
(COALESCE(HTS_TST_Other_index_0_8_m_pos.value,0)+COALESCE(VCT_index_0_8_m_pos.value,0)) AS HTS_TST_Index_men1_m_pos,
*/
0 AS HTS_TST_Index_men1_f_pos,
0 AS HTS_TST_Index_men1_m_pos,
(COALESCE(HTS_TST_Other_index_9_18_f_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_pos.value,0)+COALESCE(VCT_index_9_18_f_pos.value,0)+COALESCE(VCT_index_19_4_f_pos.value,0)) AS HTS_TST_Index_1_4_f_pos,
(COALESCE(HTS_TST_Other_index_9_18_m_pos.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_pos.value,0)+COALESCE(VCT_index_9_18_m_pos.value,0)+COALESCE(VCT_index_19_4_m_pos.value,0)) AS HTS_TST_Index_1_4_m_pos,
(COALESCE(HTS_TST_Other_index_5_9_f_pos.value,0)+COALESCE(VCT_index_5_9_f_pos.value,0)) AS HTS_TST_Index_5_9_f_pos,
(COALESCE(HTS_TST_Other_index_5_9_m_pos.value,0)+COALESCE(VCT_index_5_9_m_pos.value,0)) AS HTS_TST_Index_5_9_m_pos,
(COALESCE(HTS_TST_Other_index_10_14_f_pos.value,0)+COALESCE(VCT_index_10_14_f_pos.value,0)) AS HTS_TST_Index_10_14_f_pos,
(COALESCE(HTS_TST_Other_index_10_14_m_pos.value,0)+COALESCE(VCT_index_10_14_m_pos.value,0)) AS HTS_TST_Index_10_14_m_pos,
(COALESCE(HTS_TST_Other_index_15_19_f_pos.value,0)+COALESCE(VCT_index_15_19_f_pos.value,0)) AS HTS_TST_Index_15_19_f_pos,
(COALESCE(HTS_TST_Other_index_15_19_m_pos.value,0)+COALESCE(VCT_index_15_19_m_pos.value,0)) AS HTS_TST_Index_15_19_m_pos,
(COALESCE(HTS_TST_Other_index_20_24_f_pos.value,0)+COALESCE(VCT_index_20_24_f_pos.value,0)) AS HTS_TST_Index_20_24_f_pos,
(COALESCE(HTS_TST_Other_index_20_24_m_pos.value,0)+COALESCE(VCT_index_20_24_m_pos.value,0)) AS HTS_TST_Index_20_24_m_pos,
(COALESCE(HTS_TST_Other_index_25_29_f_pos.value,0)+COALESCE(VCT_index_25_29_f_pos.value,0)) AS HTS_TST_Index_25_29_f_pos,
(COALESCE(HTS_TST_Other_index_25_29_m_pos.value,0)+COALESCE(VCT_index_25_29_m_pos.value,0)) AS HTS_TST_Index_25_29_m_pos,
(COALESCE(HTS_TST_Other_index_30_49_f_pos.value,0)+COALESCE(VCT_index_30_49_f_pos.value,0)) AS HTS_TST_Index_30_34_f_pos,
(COALESCE(HTS_TST_Other_index_30_49_m_pos.value,0)+COALESCE(VCT_index_30_49_m_pos.value,0)) AS HTS_TST_Index_30_34_m_pos,
(COALESCE(HTS_TST_Other_index_35_39_f_pos.value,0)+COALESCE(VCT_index_35_39_f_pos.value,0)) AS HTS_TST_Index_35_39_f_pos,
(COALESCE(HTS_TST_Other_index_35_39_m_pos.value,0)+COALESCE(VCT_index_35_39_m_pos.value,0)) AS HTS_TST_Index_35_39_m_pos,
(COALESCE(HTS_TST_Other_index_40_44_f_pos.value,0)+COALESCE(VCT_index_40_44_f_pos.value,0)) AS HTS_TST_Index_40_44_f_pos,
(COALESCE(HTS_TST_Other_index_40_44_m_pos.value,0)+COALESCE(VCT_index_40_44_m_pos.value,0)) AS HTS_TST_Index_40_44_m_pos,
(COALESCE(HTS_TST_Other_index_45_49_f_pos.value,0)+COALESCE(VCT_index_45_49_f_pos.value,0)) AS HTS_TST_Index_45_49_f_pos,
(COALESCE(HTS_TST_Other_index_45_49_m_pos.value,0)+COALESCE(VCT_index_45_49_m_pos.value,0)) AS HTS_TST_Index_45_49_m_pos,
(COALESCE(HTS_TST_Other_index_50_f_pos.value,0)+COALESCE(VCT_index_50_f_pos.value,0)) AS HTS_TST_Index_50_f_pos,
(COALESCE(HTS_TST_Other_index_50_m_pos.value,0)+COALESCE(VCT_index_50_m_pos.value,0)) AS HTS_TST_Index_50_m_pos,
COALESCE(cpn_index_contact_neg.value,0) AS CPN_index_contact_m_neg_unk,
/*REMOVING CHILD <1y
(COALESCE(HTS_TST_Other_index_0_8_f_neg.value,0)+COALESCE(VCT_index_0_8_f_neg.value,0)) AS HTS_TST_Index_men1_f_neg,
(COALESCE(HTS_TST_Other_index_0_8_m_neg.value,0)+COALESCE(VCT_index_0_8_m_neg.value,0)) AS HTS_TST_Index_men1_m_neg,
*/
0 AS HTS_TST_Index_men1_f_neg,
0 AS HTS_TST_Index_men1_m_neg,

(COALESCE(HTS_TST_Other_index_9_18_f_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_f_neg.value,0)+COALESCE(VCT_index_9_18_f_neg.value,0)+COALESCE(VCT_index_19_4_f_neg.value,0)) AS HTS_TST_Index_1_4_f_neg,
(COALESCE(HTS_TST_Other_index_9_18_m_neg.value,0)+COALESCE(HTS_TST_Other_index_19_4_m_neg.value,0)+COALESCE(VCT_index_9_18_m_neg.value,0)+COALESCE(VCT_index_19_4_m_neg.value,0)) AS HTS_TST_Index_1_4_m_neg,
(COALESCE(HTS_TST_Other_index_5_9_f_neg.value,0)+COALESCE(VCT_index_5_9_f_neg.value,0)) AS HTS_TST_Index_5_9_f_neg,
(COALESCE(HTS_TST_Other_index_5_9_m_neg.value,0)+COALESCE(VCT_index_5_9_m_neg.value,0)) AS HTS_TST_Index_5_9_m_neg,
(COALESCE(HTS_TST_Other_index_10_14_f_neg.value,0)+COALESCE(VCT_index_10_14_f_neg.value,0)) AS HTS_TST_Index_10_14_f_neg,
(COALESCE(HTS_TST_Other_index_10_14_m_neg.value,0)+COALESCE(VCT_index_10_14_m_neg.value,0)) AS HTS_TST_Index_10_14_m_neg,
(COALESCE(HTS_TST_Other_index_15_19_f_neg.value,0)+COALESCE(VCT_index_15_19_f_neg.value,0)) AS HTS_TST_Index_15_19_f_neg,
(COALESCE(HTS_TST_Other_index_15_19_m_neg.value,0)+COALESCE(VCT_index_15_19_m_neg.value,0)) AS HTS_TST_Index_15_19_m_neg,
(COALESCE(HTS_TST_Other_index_20_24_f_neg.value,0)+COALESCE(VCT_index_20_24_f_neg.value,0)) AS HTS_TST_Index_20_24_f_neg,
(COALESCE(HTS_TST_Other_index_20_24_m_neg.value,0)+COALESCE(VCT_index_20_24_m_neg.value,0)) AS HTS_TST_Index_20_24_m_neg,
(COALESCE(HTS_TST_Other_index_25_29_f_neg.value,0)+COALESCE(VCT_index_25_29_f_neg.value,0)) AS HTS_TST_Index_25_29_f_neg,
(COALESCE(HTS_TST_Other_index_25_29_m_neg.value,0)+COALESCE(VCT_index_25_29_m_neg.value,0)) AS HTS_TST_Index_25_29_m_neg,
(COALESCE(HTS_TST_Other_index_30_49_f_neg.value,0)+COALESCE(VCT_index_30_49_f_neg.value,0)) AS HTS_TST_Index_30_34_f_neg,
(COALESCE(HTS_TST_Other_index_30_49_m_neg.value,0)+COALESCE(VCT_index_30_49_m_neg.value,0)) AS HTS_TST_Index_30_34_m_neg,
(COALESCE(HTS_TST_Other_index_35_39_f_neg.value,0)+COALESCE(VCT_index_35_39_f_neg.value,0)) AS HTS_TST_Index_35_39_f_neg,
(COALESCE(HTS_TST_Other_index_35_39_m_neg.value,0)+COALESCE(VCT_index_35_39_m_neg.value,0)) AS HTS_TST_Index_35_39_m_neg,
(COALESCE(HTS_TST_Other_index_40_44_f_neg.value,0)+COALESCE(VCT_index_40_44_f_neg.value,0)) AS HTS_TST_Index_40_44_f_neg,
(COALESCE(HTS_TST_Other_index_40_44_m_neg.value,0)+COALESCE(VCT_index_40_44_m_neg.value,0)) AS HTS_TST_Index_40_44_m_neg,
(COALESCE(HTS_TST_Other_index_45_49_f_neg.value,0)+COALESCE(VCT_index_45_49_f_neg.value,0)) AS HTS_TST_Index_45_49_f_neg,
(COALESCE(HTS_TST_Other_index_45_49_m_neg.value,0)+COALESCE(VCT_index_45_49_m_neg.value,0)) AS HTS_TST_Index_45_49_m_neg,
(COALESCE(HTS_TST_Other_index_50_f_neg.value,0)+COALESCE(VCT_index_50_f_neg.value,0)) AS HTS_TST_Index_50_f_neg,
(COALESCE(HTS_TST_Other_index_50_m_neg.value,0)+COALESCE(VCT_index_50_m_neg.value,0)) AS HTS_TST_Index_50_m_neg,
/*Auto-Calculate*/
/*HTS_SELF*/
(
COALESCE(HTS_SELF_assisted_10_14_f.value,0)+
COALESCE(HTS_SELF_assisted_15_19_f.value,0)+
COALESCE(HTS_SELF_assisted_20_24_f.value,0)+
COALESCE(HTS_SELF_assisted_25_29_f.value,0)+
COALESCE(HTS_SELF_assisted_30_34_f.value,0)+
COALESCE(HTS_SELF_assisted_35_39_f.value,0)+
COALESCE(HTS_SELF_assisted_40_44_f.value,0)+
COALESCE(HTS_SELF_assisted_45_49_f.value,0)+
COALESCE(HTS_SELF_assisted_50_f.value,0)+
COALESCE(HTS_SELF_assisted_10_14_m.value,0)+
COALESCE(HTS_SELF_assisted_15_19_m.value,0)+
COALESCE(HTS_SELF_assisted_20_24_m.value,0)+
COALESCE(HTS_SELF_assisted_25_29_m.value,0)+
COALESCE(HTS_SELF_assisted_30_34_m.value,0)+
COALESCE(HTS_SELF_assisted_35_39_m.value,0)+
COALESCE(HTS_SELF_assisted_40_44_m.value,0)+
COALESCE(HTS_SELF_assisted_45_49_m.value,0)+
COALESCE(HTS_SELF_assisted_50_m.value,0)+
COALESCE(HTS_SELF_unassisted_10_14_f.value,0)+
COALESCE(HTS_SELF_unassisted_15_19_f.value,0)+
COALESCE(HTS_SELF_unassisted_20_24_f.value,0)+
COALESCE(HTS_SELF_unassisted_25_29_f.value,0)+
COALESCE(HTS_SELF_unassisted_30_34_f.value,0)+
COALESCE(HTS_SELF_unassisted_35_39_f.value,0)+
COALESCE(HTS_SELF_unassisted_40_44_f.value,0)+
COALESCE(HTS_SELF_unassisted_45_49_f.value,0)+
COALESCE(HTS_SELF_unassisted_50_f.value,0)+
COALESCE(HTS_SELF_unassisted_10_14_m.value,0)+
COALESCE(HTS_SELF_unassisted_15_19_m.value,0)+
COALESCE(HTS_SELF_unassisted_20_24_m.value,0)+
COALESCE(HTS_SELF_unassisted_25_29_m.value,0)+
COALESCE(HTS_SELF_unassisted_30_34_m.value,0)+
COALESCE(HTS_SELF_unassisted_35_39_m.value,0)+
COALESCE(HTS_SELF_unassisted_40_44_m.value,0)+
COALESCE(HTS_SELF_unassisted_45_49_m.value,0)+
COALESCE(HTS_SELF_unassisted_50_m.value,0) 
) AS HTS_SELF_total,
COALESCE(HTS_SELF_assisted_10_14_f.value,0) AS HTS_SELF_assisted_10_14_f,
COALESCE(HTS_SELF_assisted_15_19_f.value,0) AS HTS_SELF_assisted_15_19_f,
COALESCE(HTS_SELF_assisted_20_24_f.value,0) AS HTS_SELF_assisted_20_24_f,
COALESCE(HTS_SELF_assisted_25_29_f.value,0) AS HTS_SELF_assisted_25_29_f,
COALESCE(HTS_SELF_assisted_30_34_f.value,0) AS HTS_SELF_assisted_30_34_f,
COALESCE(HTS_SELF_assisted_35_39_f.value,0) AS HTS_SELF_assisted_35_39_f,
COALESCE(HTS_SELF_assisted_40_44_f.value,0) AS HTS_SELF_assisted_40_44_f,
COALESCE(HTS_SELF_assisted_45_49_f.value,0) AS HTS_SELF_assisted_45_49_f,
COALESCE(HTS_SELF_assisted_50_f.value,0) AS HTS_SELF_assisted_50_f,
COALESCE(HTS_SELF_assisted_10_14_m.value,0) AS HTS_SELF_assisted_10_14_m,
COALESCE(HTS_SELF_assisted_15_19_m.value,0) AS HTS_SELF_assisted_15_19_m,
COALESCE(HTS_SELF_assisted_20_24_m.value,0) AS HTS_SELF_assisted_20_24_m,
COALESCE(HTS_SELF_assisted_25_29_m.value,0) AS HTS_SELF_assisted_25_29_m,
COALESCE(HTS_SELF_assisted_30_34_m.value,0) AS HTS_SELF_assisted_30_34_m,
COALESCE(HTS_SELF_assisted_35_39_m.value,0) AS HTS_SELF_assisted_35_39_m,
COALESCE(HTS_SELF_assisted_40_44_m.value,0) AS HTS_SELF_assisted_40_44_m,
COALESCE(HTS_SELF_assisted_45_49_m.value,0) AS HTS_SELF_assisted_45_49_m,
COALESCE(HTS_SELF_assisted_50_m.value,0) AS HTS_SELF_assisted_50_m,
COALESCE(HTS_SELF_unassisted_10_14_f.value,0) AS HTS_SELF_unassisted_10_14_f,
COALESCE(HTS_SELF_unassisted_15_19_f.value,0) AS HTS_SELF_unassisted_15_19_f,
COALESCE(HTS_SELF_unassisted_20_24_f.value,0) AS HTS_SELF_unassisted_20_24_f,
COALESCE(HTS_SELF_unassisted_25_29_f.value,0) AS HTS_SELF_unassisted_25_29_f,
COALESCE(HTS_SELF_unassisted_30_34_f.value,0) AS HTS_SELF_unassisted_30_34_f,
COALESCE(HTS_SELF_unassisted_35_39_f.value,0) AS HTS_SELF_unassisted_35_39_f,
COALESCE(HTS_SELF_unassisted_40_44_f.value,0) AS HTS_SELF_unassisted_40_44_f,
COALESCE(HTS_SELF_unassisted_45_49_f.value,0) AS HTS_SELF_unassisted_45_49_f,
COALESCE(HTS_SELF_unassisted_50_f.value,0) AS HTS_SELF_unassisted_50_f,
COALESCE(HTS_SELF_unassisted_10_14_m.value,0) AS HTS_SELF_unassisted_10_14_m,
COALESCE(HTS_SELF_unassisted_15_19_m.value,0) AS HTS_SELF_unassisted_15_19_m,
COALESCE(HTS_SELF_unassisted_20_24_m.value,0) AS HTS_SELF_unassisted_20_24_m,
COALESCE(HTS_SELF_unassisted_25_29_m.value,0) AS HTS_SELF_unassisted_25_29_m,
COALESCE(HTS_SELF_unassisted_30_34_m.value,0) AS HTS_SELF_unassisted_30_34_m,
COALESCE(HTS_SELF_unassisted_35_39_m.value,0) AS HTS_SELF_unassisted_35_39_m,
COALESCE(HTS_SELF_unassisted_40_44_m.value,0) AS HTS_SELF_unassisted_40_44_m,
COALESCE(HTS_SELF_unassisted_45_49_m.value,0) AS HTS_SELF_unassisted_45_49_m,
COALESCE(HTS_SELF_unassisted_50_m.value,0) AS HTS_SELF_unassisted_50_m,
COALESCE(HTS_SELF_assisted_pwid.value,0) AS HTS_SELF_assisted_pwid,
COALESCE(HTS_SELF_assisted_msm.value,0) AS HTS_SELF_assisted_msm,
COALESCE(HTS_SELF_assisted_tg.value,0) AS HTS_SELF_assisted_tg,
COALESCE(HTS_SELF_assisted_fsw.value,0) AS HTS_SELF_assisted_fsw,
COALESCE(HTS_SELF_assisted_closed.value,0) AS HTS_SELF_assisted_closed,
COALESCE(HTS_SELF_unassisted_pwid.value,0) AS HTS_SELF_unassisted_pwid,
COALESCE(HTS_SELF_unassisted_msm.value,0) AS HTS_SELF_unassisted_msm,
COALESCE(HTS_SELF_unassisted_tg.value,0) AS HTS_SELF_unassisted_tg,
COALESCE(HTS_SELF_unassisted_fsw.value,0) AS HTS_SELF_unassisted_fsw,
COALESCE(HTS_SELF_unassisted_closed.value,0) AS HTS_SELF_unassisted_closed,
'' AS placeholder,
COALESCE(HTS_SELF_unassisted_partner.value,0) AS HTS_SELF_unassisted_partner,
COALESCE(HTS_SELF_unassisted_other.value,0) AS HTS_SELF_unassisted_other,

/*Auto-Calculate*/
/*PMTCT_STAT (Numerator)*/
(
COALESCE(PMTCT_STAT_17q2_10_14_known_pos.value,0)+
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0)+
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0)+
COALESCE(PMTCT_STAT_17q2_15_19_known_pos.value,0)+
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0)+
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0)+
COALESCE(PMTCT_STAT_17q2_20_24_known_pos.value,0)+
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0)+
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0)+
(COALESCE(PMTCT_STAT_17q2_25_49_known_pos.value,0)+COALESCE(PMTCT_STAT_17q2_25_known_pos.value,0))+
COALESCE(HTS_TST_PMTCT_25_pos.value,0)+
COALESCE(HTS_TST_PMTCT_25_neg.value,0)+
/*Recent negatives*/
COALESCE(PMTCT_STAT_10_14_recent_neg.value,0)+
COALESCE(PMTCT_STAT_15_19_recent_neg.value,0)+
COALESCE(PMTCT_STAT_20_24_recent_neg.value,0)+
COALESCE(PMTCT_STAT_25_recent_neg.value,0) 
) AS PMTCT_STAT_num,
COALESCE(PMTCT_STAT_17q2_10_14_known_pos.value,0) AS PMTCT_STAT_10_14_known_pos,
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0) AS HTS_TST_PMTCT_10_14_pos2,
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0) AS HTS_TST_PMTCT_10_14_neg2,
COALESCE(PMTCT_STAT_17q2_15_19_known_pos.value,0) AS PMTCT_STAT_15_19_known_pos,
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0) AS HTS_TST_PMTCT_15_19_pos2,
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0) AS HTS_TST_PMTCT_15_19_neg2,
COALESCE(PMTCT_STAT_17q2_20_24_known_pos.value,0) AS PMTCT_STAT_20_24_known_pos,
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0) AS HTS_TST_PMTCT_20_24_pos2,
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0) AS HTS_TST_PMTCT_20_24_neg2,
(COALESCE(PMTCT_STAT_17q2_25_49_known_pos.value,0)+COALESCE(PMTCT_STAT_17q2_25_known_pos.value,0)) AS PMTCT_STAT_25_49_known_pos,
COALESCE(HTS_TST_PMTCT_25_pos.value,0) AS HTS_TST_PMTCT_25_49_pos2,
COALESCE(HTS_TST_PMTCT_25_neg.value,0) AS HTS_TST_PMTCT_25_49_neg2,
/*Auto-Calculate*/
/*PMTCT_STAT (Denominator)*/
(
COALESCE(PMTCT_STAT_17q2_10_14_den.value,0)+
COALESCE(PMTCT_STAT_17q2_15_19_den.value,0)+
COALESCE(PMTCT_STAT_17q2_20_24_den.value,0)+
(COALESCE(PMTCT_STAT_17q2_25_49_den.value,0)+COALESCE(PMTCT_STAT_17q2_25_den.value,0)) 
) AS PMTCT_STAT_den,
COALESCE(PMTCT_STAT_17q2_10_14_den.value,0) AS PMTCT_STAT_10_14_den,
COALESCE(PMTCT_STAT_17q2_15_19_den.value,0) AS PMTCT_STAT_15_19_den,
COALESCE(PMTCT_STAT_17q2_20_24_den.value,0) AS PMTCT_STAT_20_24_den,
(COALESCE(PMTCT_STAT_17q2_25_49_den.value,0)+COALESCE(PMTCT_STAT_17q2_25_den.value,0)) AS PMTCT_STAT_25_49_den,
/*Auto-Calculate*/
/*PMTCT_EID*/
(
COALESCE(PMTCT_EID_0_2_total.value,0)+
COALESCE(PMTCT_EID_2_12_total.value,0)
) AS PMTCT_EID,
COALESCE(PMTCT_EID_0_2_total.value,0) AS PMTCT_EID_0_2_test,
COALESCE(PMTCT_EID_2_12_total.value,0) AS PMTCT_EID_2_12_test,
/*Auto-Calculate*/
/*PMTCT_HEI_POS*/
(
COALESCE(PMTCT_EID_0_2_pos.value,0)+
COALESCE(PMTCT_EID_2_12_pos_sum_prev.value,0) 
) AS PMTCT_HEI_POS,
COALESCE(PMTCT_EID_0_2_pos.value,0) AS PMTCT_EID_0_2_pos,
COALESCE(PMTCT_EID_2_12_pos_sum_prev.value,0) AS PMTCT_EID_2_12_pos,
COALESCE(PMTCT_EID_0_2_art.value,0) AS PMTCT_EID_0_2_art,
COALESCE(PMTCT_EID_2_12_art.value,0) AS PMTCT_EID_2_12_art,
/*Auto-Calculate*/
/*TB_STAT Numerator*/
(
COALESCE(TB_STAT_kp_men1_f.value,0)+
COALESCE(TB_STAT_kp_men1_m.value,0)+
COALESCE(TB_STAT_kp_1_4_f.value,0)+
COALESCE(TB_STAT_kp_1_4_m.value,0)+
COALESCE(TB_STAT_kp_5_9_f.value,0)+
COALESCE(TB_STAT_kp_5_9_m.value,0)+
COALESCE(TB_STAT_kp_10_14_f.value,0)+
COALESCE(TB_STAT_kp_10_14_m.value,0)+
COALESCE(TB_STAT_kp_15_19_f.value,0)+
COALESCE(TB_STAT_kp_15_19_m.value,0)+
COALESCE(TB_STAT_kp_20_24_f.value,0)+
COALESCE(TB_STAT_kp_20_24_m.value,0)+
COALESCE(TB_STAT_kp_25_29_f.value,0)+
COALESCE(TB_STAT_kp_25_29_m.value,0)+
COALESCE(TB_STAT_kp_30_34_f.value,0)+
COALESCE(TB_STAT_kp_30_34_m.value,0)+
COALESCE(TB_STAT_kp_35_39_f.value,0)+
COALESCE(TB_STAT_kp_35_39_m.value,0)+
COALESCE(TB_STAT_kp_40_44_f.value,0)+
COALESCE(TB_STAT_kp_40_44_m.value,0)+
COALESCE(TB_STAT_kp_45_49_f.value,0)+
COALESCE(TB_STAT_kp_45_49_m.value,0)+
COALESCE(TB_STAT_kp_50_f.value,0)+
COALESCE(TB_STAT_kp_50_m.value,0)+
COALESCE(TB_STAT_kn_men1_f.value,0)+
COALESCE(TB_STAT_kn_men1_m.value,0)+
COALESCE(TB_STAT_kn_1_4_f.value,0)+
COALESCE(TB_STAT_kn_1_4_m.value,0)+
COALESCE(TB_STAT_kn_5_9_f.value,0)+
COALESCE(TB_STAT_kn_5_9_m.value,0)+
COALESCE(TB_STAT_kn_10_14_f.value,0)+
COALESCE(TB_STAT_kn_10_14_m.value,0)+
COALESCE(TB_STAT_kn_15_19_f.value,0)+
COALESCE(TB_STAT_kn_15_19_m.value,0)+
COALESCE(TB_STAT_kn_20_24_f.value,0)+
COALESCE(TB_STAT_kn_20_24_m.value,0)+
COALESCE(TB_STAT_kn_25_29_f.value,0)+
COALESCE(TB_STAT_kn_25_29_m.value,0)+
COALESCE(TB_STAT_kn_30_34_f.value,0)+
COALESCE(TB_STAT_kn_30_34_m.value,0)+
COALESCE(TB_STAT_kn_35_39_f.value,0)+
COALESCE(TB_STAT_kn_35_39_m.value,0)+
COALESCE(TB_STAT_kn_40_44_f.value,0)+
COALESCE(TB_STAT_kn_40_44_m.value,0)+
COALESCE(TB_STAT_kn_45_49_f.value,0)+
COALESCE(TB_STAT_kn_45_49_m.value,0)+
COALESCE(TB_STAT_kn_50_f.value,0)+
COALESCE(TB_STAT_kn_50_m.value,0)+
COALESCE(HTS_TST_TB_men1_f_pos.value,0)+
COALESCE(HTS_TST_TB_men1_m_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_f_pos.value,0)+
COALESCE(HTS_TST_TB_1_4_m_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_f_pos.value,0)+
COALESCE(HTS_TST_TB_5_9_m_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_f_pos.value,0)+
COALESCE(HTS_TST_TB_10_14_m_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_f_pos.value,0)+
COALESCE(HTS_TST_TB_15_19_m_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_f_pos.value,0)+
COALESCE(HTS_TST_TB_20_24_m_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_f_pos.value,0)+
COALESCE(HTS_TST_TB_25_29_m_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_f_pos.value,0)+
COALESCE(HTS_TST_TB_30_34_m_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_f_pos.value,0)+
COALESCE(HTS_TST_TB_35_39_m_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_f_pos.value,0)+
COALESCE(HTS_TST_TB_40_44_m_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_f_pos.value,0)+
COALESCE(HTS_TST_TB_45_49_m_pos.value,0)+
COALESCE(HTS_TST_TB_50_f_pos.value,0)+
COALESCE(HTS_TST_TB_50_m_pos.value,0)+
COALESCE(HTS_TST_TB_men1_f_neg.value,0)+
COALESCE(HTS_TST_TB_men1_m_neg.value,0)+
COALESCE(HTS_TST_TB_1_4_f_neg.value,0)+
COALESCE(HTS_TST_TB_1_4_m_neg.value,0)+
COALESCE(HTS_TST_TB_5_9_f_neg.value,0)+
COALESCE(HTS_TST_TB_5_9_m_neg.value,0)+
COALESCE(HTS_TST_TB_10_14_f_neg.value,0)+
COALESCE(HTS_TST_TB_10_14_m_neg.value,0)+
COALESCE(HTS_TST_TB_15_19_f_neg.value,0)+
COALESCE(HTS_TST_TB_15_19_m_neg.value,0)+
COALESCE(HTS_TST_TB_20_24_f_neg.value,0)+
COALESCE(HTS_TST_TB_20_24_m_neg.value,0)+
COALESCE(HTS_TST_TB_25_29_f_neg.value,0)+
COALESCE(HTS_TST_TB_25_29_m_neg.value,0)+
COALESCE(HTS_TST_TB_30_34_f_neg.value,0)+
COALESCE(HTS_TST_TB_30_34_m_neg.value,0)+
COALESCE(HTS_TST_TB_35_39_f_neg.value,0)+
COALESCE(HTS_TST_TB_35_39_m_neg.value,0)+
COALESCE(HTS_TST_TB_40_44_f_neg.value,0)+
COALESCE(HTS_TST_TB_40_44_m_neg.value,0)+
COALESCE(HTS_TST_TB_45_49_f_neg.value,0)+
COALESCE(HTS_TST_TB_45_49_m_neg.value,0)+
COALESCE(HTS_TST_TB_50_f_neg.value,0)+
COALESCE(HTS_TST_TB_50_m_neg.value,0) 
) AS TB_STAT_num,
/*Known Positives*/
COALESCE(TB_STAT_kp_men1_f.value,0) AS TB_STAT_kp_men1_f,
COALESCE(TB_STAT_kp_men1_m.value,0) AS TB_STAT_kp_men1_m,
COALESCE(TB_STAT_kp_1_4_f.value,0) AS TB_STAT_kp_1_4_f,
COALESCE(TB_STAT_kp_1_4_m.value,0) AS TB_STAT_kp_1_4_m,
COALESCE(TB_STAT_kp_5_9_f.value,0) AS TB_STAT_kp_5_9_f,
COALESCE(TB_STAT_kp_5_9_m.value,0) AS TB_STAT_kp_5_9_m,
COALESCE(TB_STAT_kp_10_14_f.value,0) AS TB_STAT_kp_10_14_f,
COALESCE(TB_STAT_kp_10_14_m.value,0) AS TB_STAT_kp_10_14_m,
COALESCE(TB_STAT_kp_15_19_f.value,0) AS TB_STAT_kp_15_19_f,
COALESCE(TB_STAT_kp_15_19_m.value,0) AS TB_STAT_kp_15_19_m,
COALESCE(TB_STAT_kp_20_24_f.value,0) AS TB_STAT_kp_20_24_f,
COALESCE(TB_STAT_kp_20_24_m.value,0) AS TB_STAT_kp_20_24_m,
COALESCE(TB_STAT_kp_25_29_f.value,0) AS TB_STAT_kp_25_29_f,
COALESCE(TB_STAT_kp_25_29_m.value,0) AS TB_STAT_kp_25_29_m,
COALESCE(TB_STAT_kp_30_34_f.value,0) AS TB_STAT_kp_30_34_f,
COALESCE(TB_STAT_kp_30_34_m.value,0) AS TB_STAT_kp_30_34_m,
COALESCE(TB_STAT_kp_35_39_f.value,0) AS TB_STAT_kp_35_39_f,
COALESCE(TB_STAT_kp_35_39_m.value,0) AS TB_STAT_kp_35_39_m,
COALESCE(TB_STAT_kp_40_44_f.value,0) AS TB_STAT_kp_40_44_f,
COALESCE(TB_STAT_kp_40_44_m.value,0) AS TB_STAT_kp_40_44_m,
COALESCE(TB_STAT_kp_45_49_f.value,0) AS TB_STAT_kp_45_49_f,
COALESCE(TB_STAT_kp_45_49_m.value,0) AS TB_STAT_kp_45_49_m,
COALESCE(TB_STAT_kp_50_f.value,0) AS TB_STAT_kp_50_f,
COALESCE(TB_STAT_kp_50_m.value,0) AS TB_STAT_kp_50_m,
/*Newly Tested Positives*/
COALESCE(HTS_TST_TB_men1_f_pos.value,0) AS HTS_TST_TB_men1_f_pos2,
COALESCE(HTS_TST_TB_men1_m_pos.value,0) AS HTS_TST_TB_men1_m_pos2,
COALESCE(HTS_TST_TB_1_4_f_pos.value,0) AS HTS_TST_TB_1_4_f_pos2,
COALESCE(HTS_TST_TB_1_4_m_pos.value,0) AS HTS_TST_TB_1_4_m_pos2,
COALESCE(HTS_TST_TB_5_9_f_pos.value,0) AS HTS_TST_TB_5_9_f_pos2,
COALESCE(HTS_TST_TB_5_9_m_pos.value,0) AS HTS_TST_TB_5_9_m_pos2,
COALESCE(HTS_TST_TB_10_14_f_pos.value,0) AS HTS_TST_TB_10_14_f_pos2,
COALESCE(HTS_TST_TB_10_14_m_pos.value,0) AS HTS_TST_TB_10_14_m_pos2,
COALESCE(HTS_TST_TB_15_19_f_pos.value,0) AS HTS_TST_TB_15_19_f_pos2,
COALESCE(HTS_TST_TB_15_19_m_pos.value,0) AS HTS_TST_TB_15_19_m_pos2,
COALESCE(HTS_TST_TB_20_24_f_pos.value,0) AS HTS_TST_TB_20_24_f_pos2,
COALESCE(HTS_TST_TB_20_24_m_pos.value,0) AS HTS_TST_TB_20_24_m_pos2,
COALESCE(HTS_TST_TB_25_29_f_pos.value,0) AS HTS_TST_TB_25_29_f_pos2,
COALESCE(HTS_TST_TB_25_29_m_pos.value,0) AS HTS_TST_TB_25_29_m_pos2,
COALESCE(HTS_TST_TB_30_34_f_pos.value,0) AS HTS_TST_TB_30_34_f_pos2,
COALESCE(HTS_TST_TB_30_34_m_pos.value,0) AS HTS_TST_TB_30_34_m_pos2,
COALESCE(HTS_TST_TB_35_39_f_pos.value,0) AS HTS_TST_TB_35_39_f_pos2,
COALESCE(HTS_TST_TB_35_39_m_pos.value,0) AS HTS_TST_TB_35_39_m_pos2,
COALESCE(HTS_TST_TB_40_44_f_pos.value,0) AS HTS_TST_TB_40_44_f_pos2,
COALESCE(HTS_TST_TB_40_44_m_pos.value,0) AS HTS_TST_TB_40_44_m_pos2,
COALESCE(HTS_TST_TB_45_49_f_pos.value,0) AS HTS_TST_TB_45_49_f_pos2,
COALESCE(HTS_TST_TB_45_49_m_pos.value,0) AS HTS_TST_TB_45_49_m_pos2,
COALESCE(HTS_TST_TB_50_f_pos.value,0) AS HTS_TST_TB_50_f_pos2,
COALESCE(HTS_TST_TB_50_m_pos.value,0) AS HTS_TST_TB_50_m_pos2,
/*New Negatives + Known Negatives*/
(COALESCE(HTS_TST_TB_men1_f_neg.value,0)+COALESCE(TB_STAT_kn_men1_f.value,0)) AS HTS_TST_TB_men1_f_neg2,
(COALESCE(HTS_TST_TB_men1_m_neg.value,0)+COALESCE(TB_STAT_kn_men1_m.value,0)) AS HTS_TST_TB_men1_m_neg2,
(COALESCE(HTS_TST_TB_1_4_f_neg.value,0)+COALESCE(TB_STAT_kn_1_4_f.value,0)) AS HTS_TST_TB_1_4_f_neg2,
(COALESCE(HTS_TST_TB_1_4_m_neg.value,0)+COALESCE(TB_STAT_kn_1_4_m.value,0)) AS HTS_TST_TB_1_4_m_neg2,
(COALESCE(HTS_TST_TB_5_9_f_neg.value,0)+COALESCE(TB_STAT_kn_5_9_f.value,0)) AS HTS_TST_TB_5_9_f_neg2,
(COALESCE(HTS_TST_TB_5_9_m_neg.value,0)+COALESCE(TB_STAT_kn_5_9_m.value,0)) AS HTS_TST_TB_5_9_m_neg2,
(COALESCE(HTS_TST_TB_10_14_f_neg.value,0)+COALESCE(TB_STAT_kn_10_14_f.value,0)) AS HTS_TST_TB_10_14_f_neg2,
(COALESCE(HTS_TST_TB_10_14_m_neg.value,0)+COALESCE(TB_STAT_kn_10_14_m.value,0)) AS HTS_TST_TB_10_14_m_neg2,
(COALESCE(HTS_TST_TB_15_19_f_neg.value,0)+COALESCE(TB_STAT_kn_15_19_f.value,0)) AS HTS_TST_TB_15_19_f_neg2,
(COALESCE(HTS_TST_TB_15_19_m_neg.value,0)+COALESCE(TB_STAT_kn_15_19_m.value,0)) AS HTS_TST_TB_15_19_m_neg2,
(COALESCE(HTS_TST_TB_20_24_f_neg.value,0)+COALESCE(TB_STAT_kn_20_24_f.value,0)) AS HTS_TST_TB_20_24_f_neg2,
(COALESCE(HTS_TST_TB_20_24_m_neg.value,0)+COALESCE(TB_STAT_kn_20_24_m.value,0)) AS HTS_TST_TB_20_24_m_neg2,
(COALESCE(HTS_TST_TB_25_29_f_neg.value,0)+COALESCE(TB_STAT_kn_25_29_f.value,0)) AS HTS_TST_TB_25_29_f_neg2,
(COALESCE(HTS_TST_TB_25_29_m_neg.value,0)+COALESCE(TB_STAT_kn_25_29_m.value,0)) AS HTS_TST_TB_25_29_m_neg2,
(COALESCE(HTS_TST_TB_30_34_f_neg.value,0)+COALESCE(TB_STAT_kn_30_34_f.value,0)) AS HTS_TST_TB_30_34_f_neg2,
(COALESCE(HTS_TST_TB_30_34_m_neg.value,0)+COALESCE(TB_STAT_kn_30_34_m.value,0)) AS HTS_TST_TB_30_34_m_neg2,
(COALESCE(HTS_TST_TB_35_39_f_neg.value,0)+COALESCE(TB_STAT_kn_35_39_f.value,0)) AS HTS_TST_TB_35_39_f_neg2,
(COALESCE(HTS_TST_TB_35_39_m_neg.value,0)+COALESCE(TB_STAT_kn_35_39_m.value,0)) AS HTS_TST_TB_35_39_m_neg2,
(COALESCE(HTS_TST_TB_40_44_f_neg.value,0)+COALESCE(TB_STAT_kn_40_44_f.value,0)) AS HTS_TST_TB_40_44_f_neg2,
(COALESCE(HTS_TST_TB_40_44_m_neg.value,0)+COALESCE(TB_STAT_kn_40_44_m.value,0)) AS HTS_TST_TB_40_44_m_neg2,
(COALESCE(HTS_TST_TB_45_49_f_neg.value,0)+COALESCE(TB_STAT_kn_45_49_f.value,0)) AS HTS_TST_TB_45_49_f_neg2,
(COALESCE(HTS_TST_TB_45_49_m_neg.value,0)+COALESCE(TB_STAT_kn_45_49_m.value,0)) AS HTS_TST_TB_45_49_m_neg2,
(COALESCE(HTS_TST_TB_50_f_neg.value,0) +COALESCE(TB_STAT_kn_50_f.value,0)) AS HTS_TST_TB_50_f_neg2,
(COALESCE(HTS_TST_TB_50_m_neg.value,0) +COALESCE(TB_STAT_kn_50_m.value,0)) AS HTS_TST_TB_50_m_neg2,
/*Auto-Calculate*/
/*TB_STAT Denominator*/
(
COALESCE(TB_STAT_den_men1_f.value,0)+
COALESCE(TB_STAT_den_men1_m.value,0)+
COALESCE(TB_STAT_den_1_4_f.value,0)+
COALESCE(TB_STAT_den_1_4_m.value,0)+
COALESCE(TB_STAT_den_5_9_f.value,0)+
COALESCE(TB_STAT_den_5_9_m.value,0)+
COALESCE(TB_STAT_den_10_14_f.value,0)+
COALESCE(TB_STAT_den_10_14_m.value,0)+
COALESCE(TB_STAT_den_15_19_f.value,0)+
COALESCE(TB_STAT_den_15_19_m.value,0)+
COALESCE(TB_STAT_den_20_24_f.value,0)+
COALESCE(TB_STAT_den_20_24_m.value,0)+
COALESCE(TB_STAT_den_25_29_f.value,0)+
COALESCE(TB_STAT_den_25_29_m.value,0)+
COALESCE(TB_STAT_den_30_34_f.value,0)+
COALESCE(TB_STAT_den_30_34_m.value,0)+
COALESCE(TB_STAT_den_35_39_f.value,0)+
COALESCE(TB_STAT_den_35_39_m.value,0)+
COALESCE(TB_STAT_den_40_44_f.value,0)+
COALESCE(TB_STAT_den_40_44_m.value,0)+
COALESCE(TB_STAT_den_45_49_f.value,0)+
COALESCE(TB_STAT_den_45_49_m.value,0)+
COALESCE(TB_STAT_den_50_f.value,0)+
COALESCE(TB_STAT_den_50_m.value,0) 
)AS TB_STAT_den,
COALESCE(TB_STAT_den_men1_f.value,0) AS TB_STAT_den_men1_f,
COALESCE(TB_STAT_den_men1_m.value,0) AS TB_STAT_den_men1_m,
COALESCE(TB_STAT_den_1_4_f.value,0) AS TB_STAT_den_1_4_f,
COALESCE(TB_STAT_den_1_4_m.value,0) AS TB_STAT_den_1_4_m,
COALESCE(TB_STAT_den_5_9_f.value,0) AS TB_STAT_den_5_9_f,
COALESCE(TB_STAT_den_5_9_m.value,0) AS TB_STAT_den_5_9_m,
COALESCE(TB_STAT_den_10_14_f.value,0) AS TB_STAT_den_10_14_f,
COALESCE(TB_STAT_den_10_14_m.value,0) AS TB_STAT_den_10_14_m,
COALESCE(TB_STAT_den_15_19_f.value,0) AS TB_STAT_den_15_19_f,
COALESCE(TB_STAT_den_15_19_m.value,0) AS TB_STAT_den_15_19_m,
COALESCE(TB_STAT_den_20_24_f.value,0) AS TB_STAT_den_20_24_f,
COALESCE(TB_STAT_den_20_24_m.value,0) AS TB_STAT_den_20_24_m,
COALESCE(TB_STAT_den_25_29_f.value,0) AS TB_STAT_den_25_29_f,
COALESCE(TB_STAT_den_25_29_m.value,0) AS TB_STAT_den_25_29_m,
COALESCE(TB_STAT_den_30_34_f.value,0) AS TB_STAT_den_30_34_f,
COALESCE(TB_STAT_den_30_34_m.value,0) AS TB_STAT_den_30_34_m,
COALESCE(TB_STAT_den_35_39_f.value,0) AS TB_STAT_den_35_39_f,
COALESCE(TB_STAT_den_35_39_m.value,0) AS TB_STAT_den_35_39_m,
COALESCE(TB_STAT_den_40_44_f.value,0) AS TB_STAT_den_40_44_f,
COALESCE(TB_STAT_den_40_44_m.value,0) AS TB_STAT_den_40_44_m,
COALESCE(TB_STAT_den_45_49_f.value,0) AS TB_STAT_den_45_49_f,
COALESCE(TB_STAT_den_45_49_m.value,0) AS TB_STAT_den_45_49_m,
COALESCE(TB_STAT_den_50_f.value,0) AS TB_STAT_den_50_f,
COALESCE(TB_STAT_den_50_m.value,0) AS TB_STAT_den_50_m,
/*On ART*/
/*TX_NEW*/
COALESCE(TX_NEW_num.value,0) AS TX_NEW_num,
COALESCE(TX_NEW_breast.value,0) AS TX_NEW_breast,
COALESCE(TX_NEW_men1_f.value,0) AS TX_NEW_men1_f,
COALESCE(TX_NEW_1_4_f.value,0) AS TX_NEW_1_4_f,
COALESCE(TX_NEW_5_9_f.value,0) AS TX_NEW_5_9_f,
COALESCE(TX_NEW_10_14_f.value,0) AS TX_NEW_10_14_f,
COALESCE(TX_NEW_15_19_f.value,0) AS TX_NEW_15_19_f,
COALESCE(TX_NEW_20_24_f.value,0) AS TX_NEW_20_24_f,
COALESCE(TX_NEW_25_29_f.value,0) AS TX_NEW_25_29_f,
COALESCE(TX_NEW_30_34_f.value,0) AS TX_NEW_30_34_f,
COALESCE(TX_NEW_35_39_f.value,0) AS TX_NEW_35_39_f,
COALESCE(TX_NEW_40_44_f.value,0) AS TX_NEW_40_44_f,
COALESCE(TX_NEW_45_49_f.value,0) AS TX_NEW_45_49_f,
COALESCE(TX_NEW_50_f.value,0) AS TX_NEW_50_f,
COALESCE(TX_NEW_men1_m.value,0) AS TX_NEW_men1_m,
COALESCE(TX_NEW_1_4_m.value,0) AS TX_NEW_1_4_m,
COALESCE(TX_NEW_5_9_m.value,0) AS TX_NEW_5_9_m,
COALESCE(TX_NEW_10_14_m.value,0) AS TX_NEW_10_14_m,
COALESCE(TX_NEW_15_19_m.value,0) AS TX_NEW_15_19_m,
COALESCE(TX_NEW_20_24_m.value,0) AS TX_NEW_20_24_m,
COALESCE(TX_NEW_25_29_m.value,0) AS TX_NEW_25_29_m,
COALESCE(TX_NEW_30_34_m.value,0) AS TX_NEW_30_34_m,
COALESCE(TX_NEW_35_39_m.value,0) AS TX_NEW_35_39_m,
COALESCE(TX_NEW_40_44_m.value,0) AS TX_NEW_40_44_m,
COALESCE(TX_NEW_45_49_m.value,0) AS TX_NEW_45_49_m,
COALESCE(TX_NEW_50_m.value,0) AS TX_NEW_50_m,
COALESCE(TX_NEW_coarse_f_men15.value,0) AS TX_NEW_coarse_f_men15,
COALESCE(TX_NEW_coarse_f_mai15.value,0) AS TX_NEW_coarse_f_mai15,
COALESCE(TX_NEW_coarse_m_men15.value,0) AS TX_NEW_coarse_m_men15,
COALESCE(TX_NEW_coarse_m_mai15.value,0) AS TX_NEW_coarse_m_mai15,
COALESCE(TX_NEW_keypop_pwid.value,0) AS TX_NEW_keypop_pwid,
COALESCE(TX_NEW_keypop_msm.value,0) AS TX_NEW_keypop_msm,
COALESCE(TX_NEW_keypop_tg.value,0) AS TX_NEW_keypop_tg,
COALESCE(TX_NEW_keypop_fsw.value,0) AS TX_NEW_keypop_fsw,
COALESCE(TX_NEW_keypop_prison.value,0) AS TX_NEW_keypop_prison,
/*TX_CURR*/
COALESCE(TX_CURR_num.value,0) AS TX_CURR_num,
COALESCE(TX_CURR_men1_f.value,0) AS TX_CURR_men1_f,
COALESCE(TX_CURR_1_4_f.value,0) AS TX_CURR_1_4_f,
COALESCE(TX_CURR_5_9_f.value,0) AS TX_CURR_5_9_f,
COALESCE(TX_CURR_10_14_f.value,0) AS TX_CURR_10_14_f,
COALESCE(TX_CURR_15_19_f.value,0) AS TX_CURR_15_19_f,
COALESCE(TX_CURR_20_24_f.value,0) AS TX_CURR_20_24_f,
COALESCE(TX_CURR_25_29_f.value,0) AS TX_CURR_25_29_f,
COALESCE(TX_CURR_30_34_f.value,0) AS TX_CURR_30_34_f,
COALESCE(TX_CURR_35_39_f.value,0) AS TX_CURR_35_39_f,
COALESCE(TX_CURR_40_44_f.value,0) AS TX_CURR_40_44_f,
COALESCE(TX_CURR_45_49_f.value,0) AS TX_CURR_45_49_f,
COALESCE(TX_CURR_50_f.value,0) AS TX_CURR_50_f,
COALESCE(TX_CURR_men1_m.value,0) AS TX_CURR_men1_m,
COALESCE(TX_CURR_1_4_m.value,0) AS TX_CURR_1_4_m,
COALESCE(TX_CURR_5_9_m.value,0) AS TX_CURR_5_9_m,
COALESCE(TX_CURR_10_14_m.value,0) AS TX_CURR_10_14_m,
COALESCE(TX_CURR_15_19_m.value,0) AS TX_CURR_15_19_m,
COALESCE(TX_CURR_20_24_m.value,0) AS TX_CURR_20_24_m,
COALESCE(TX_CURR_25_29_m.value,0) AS TX_CURR_25_29_m,
COALESCE(TX_CURR_30_34_m.value,0) AS TX_CURR_30_34_m,
COALESCE(TX_CURR_35_39_m.value,0) AS TX_CURR_35_39_m,
COALESCE(TX_CURR_40_44_m.value,0) AS TX_CURR_40_44_m,
COALESCE(TX_CURR_45_49_m.value,0) AS TX_CURR_45_49_m,
COALESCE(TX_CURR_50_m.value,0) AS TX_CURR_50_m,
COALESCE(TX_CURR_coarse_f_men15.value,0) AS TX_CURR_coarse_f_men15,
COALESCE(TX_CURR_coarse_f_mai15.value,0) AS TX_CURR_coarse_f_mai15,
COALESCE(TX_CURR_coarse_m_men15.value,0) AS TX_CURR_coarse_m_men15,
COALESCE(TX_CURR_coarse_m_mai15.value,0) AS TX_CURR_coarse_m_mai15,
COALESCE(TX_CURR_keypop_pwid.value,0) AS TX_CURR_keypop_pwid,
COALESCE(TX_CURR_keypop_msm.value,0) AS TX_CURR_keypop_msm,
COALESCE(TX_CURR_keypop_tg.value,0) AS TX_CURR_keypop_tg,
COALESCE(TX_CURR_keypop_fsw.value,0) AS TX_CURR_keypop_fsw,
COALESCE(TX_CURR_keypop_prison.value,0) AS TX_CURR_keypop_prison,
COALESCE(TX_CURR_men3_f_men15.value,0) AS TX_CURR_men3_f_men15,
COALESCE(TX_CURR_men3_f_mai15.value,0) AS TX_CURR_men3_f_mai15,
COALESCE(TX_CURR_men3_m_men15.value,0) AS TX_CURR_men3_m_men15,
COALESCE(TX_CURR_men3_m_mai15.value,0) AS TX_CURR_men3_m_mai15,
COALESCE(TX_CURR_3_5_f_men15.value,0) AS TX_CURR_3_5_f_men15,
COALESCE(TX_CURR_3_5_f_mai15.value,0) AS TX_CURR_3_5_f_mai15,
COALESCE(TX_CURR_3_5_m_men15.value,0) AS TX_CURR_3_5_m_men15,
COALESCE(TX_CURR_3_5_m_mai15.value,0) AS TX_CURR_3_5_m_mai15,
COALESCE(TX_CURR_mai6_f_men15.value,0) AS TX_CURR_mai6_f_men15,
COALESCE(TX_CURR_mai6_f_mai15.value,0) AS TX_CURR_mai6_f_mai15,
COALESCE(TX_CURR_mai6_m_men15.value,0) AS TX_CURR_mai6_m_men15,
COALESCE(TX_CURR_mai6_m_mai15.value,0) AS TX_CURR_mai6_m_mai15,
/*TX_RTT*/
COALESCE(TX_RTT_num.value,0) AS TX_RTT_num,
COALESCE(TX_RTT_men1_f.value,0) AS TX_RTT_men1_f,
COALESCE(TX_RTT_1_4_f.value,0) AS TX_RTT_1_4_f,
COALESCE(TX_RTT_5_9_f.value,0) AS TX_RTT_5_9_f,
COALESCE(TX_RTT_10_14_f.value,0) AS TX_RTT_10_14_f,
COALESCE(TX_RTT_15_19_f.value,0) AS TX_RTT_15_19_f,
COALESCE(TX_RTT_20_24_f.value,0) AS TX_RTT_20_24_f,
COALESCE(TX_RTT_25_29_f.value,0) AS TX_RTT_25_29_f,
COALESCE(TX_RTT_30_34_f.value,0) AS TX_RTT_30_34_f,
COALESCE(TX_RTT_35_39_f.value,0) AS TX_RTT_35_39_f,
COALESCE(TX_RTT_40_44_f.value,0) AS TX_RTT_40_44_f,
COALESCE(TX_RTT_45_49_f.value,0) AS TX_RTT_45_49_f,
COALESCE(TX_RTT_50_f.value,0) AS TX_RTT_50_f,
COALESCE(TX_RTT_men1_m.value,0) AS TX_RTT_men1_m,
COALESCE(TX_RTT_1_4_m.value,0) AS TX_RTT_1_4_m,
COALESCE(TX_RTT_5_9_m.value,0) AS TX_RTT_5_9_m,
COALESCE(TX_RTT_10_14_m.value,0) AS TX_RTT_10_14_m,
COALESCE(TX_RTT_15_19_m.value,0) AS TX_RTT_15_19_m,
COALESCE(TX_RTT_20_24_m.value,0) AS TX_RTT_20_24_m,
COALESCE(TX_RTT_25_29_m.value,0) AS TX_RTT_25_29_m,
COALESCE(TX_RTT_30_34_m.value,0) AS TX_RTT_30_34_m,
COALESCE(TX_RTT_35_39_m.value,0) AS TX_RTT_35_39_m,
COALESCE(TX_RTT_40_44_m.value,0) AS TX_RTT_40_44_m,
COALESCE(TX_RTT_45_49_m.value,0) AS TX_RTT_45_49_m,
COALESCE(TX_RTT_50_m.value,0) AS TX_RTT_50_m,
COALESCE(TX_RTT_keypop_pwid.value,0) AS TX_RTT_keypop_pwid,
COALESCE(TX_RTT_keypop_msm.value,0) AS TX_RTT_keypop_msm,
COALESCE(TX_RTT_keypop_tg.value,0) AS TX_RTT_keypop_tg,
COALESCE(TX_RTT_keypop_fsw.value,0) AS TX_RTT_keypop_fsw,
COALESCE(TX_RTT_keypop_prison.value,0) AS TX_RTT_keypop_prison,
/*TX_ML*/
COALESCE(TX_ML_num.value,0) AS TX_ML_num,
COALESCE(TX_ML_ded_men1_f.value,0) AS TX_ML_ded_men1_f,
COALESCE(TX_ML_ded_1_4_f.value,0) AS TX_ML_ded_1_4_f,
COALESCE(TX_ML_ded_5_9_f.value,0) AS TX_ML_ded_5_9_f,
COALESCE(TX_ML_ded_10_14_f.value,0) AS TX_ML_ded_10_14_f,
COALESCE(TX_ML_ded_15_19_f.value,0) AS TX_ML_ded_15_19_f,
COALESCE(TX_ML_ded_20_24_f.value,0) AS TX_ML_ded_20_24_f,
COALESCE(TX_ML_ded_25_29_f.value,0) AS TX_ML_ded_25_29_f,
COALESCE(TX_ML_ded_30_34_f.value,0) AS TX_ML_ded_30_34_f,
COALESCE(TX_ML_ded_35_39_f.value,0) AS TX_ML_ded_35_39_f,
COALESCE(TX_ML_ded_40_44_f.value,0) AS TX_ML_ded_40_44_f,
COALESCE(TX_ML_ded_45_49_f.value,0) AS TX_ML_ded_45_49_f,
COALESCE(TX_ML_ded_50_f.value,0) AS TX_ML_ded_50_f,
COALESCE(TX_ML_ded_men1_m.value,0) AS TX_ML_ded_men1_m,
COALESCE(TX_ML_ded_1_4_m.value,0) AS TX_ML_ded_1_4_m,
COALESCE(TX_ML_ded_5_9_m.value,0) AS TX_ML_ded_5_9_m,
COALESCE(TX_ML_ded_10_14_m.value,0) AS TX_ML_ded_10_14_m,
COALESCE(TX_ML_ded_15_19_m.value,0) AS TX_ML_ded_15_19_m,
COALESCE(TX_ML_ded_20_24_m.value,0) AS TX_ML_ded_20_24_m,
COALESCE(TX_ML_ded_25_29_m.value,0) AS TX_ML_ded_25_29_m,
COALESCE(TX_ML_ded_30_34_m.value,0) AS TX_ML_ded_30_34_m,
COALESCE(TX_ML_ded_35_39_m.value,0) AS TX_ML_ded_35_39_m,
COALESCE(TX_ML_ded_40_44_m.value,0) AS TX_ML_ded_40_44_m,
COALESCE(TX_ML_ded_45_49_m.value,0) AS TX_ML_ded_45_49_m,
COALESCE(TX_ML_ded_50_m.value,0) AS TX_ML_ded_50_m,
COALESCE(TX_ML_men3_men1_f.value,0) AS TX_ML_men3_men1_f,
COALESCE(TX_ML_men3_1_4_f.value,0) AS TX_ML_men3_1_4_f,
COALESCE(TX_ML_men3_5_9_f.value,0) AS TX_ML_men3_5_9_f,
COALESCE(TX_ML_men3_10_14_f.value,0) AS TX_ML_men3_10_14_f,
COALESCE(TX_ML_men3_15_19_f.value,0) AS TX_ML_men3_15_19_f,
COALESCE(TX_ML_men3_20_24_f.value,0) AS TX_ML_men3_20_24_f,
COALESCE(TX_ML_men3_25_29_f.value,0) AS TX_ML_men3_25_29_f,
COALESCE(TX_ML_men3_30_34_f.value,0) AS TX_ML_men3_30_34_f,
COALESCE(TX_ML_men3_35_39_f.value,0) AS TX_ML_men3_35_39_f,
COALESCE(TX_ML_men3_40_44_f.value,0) AS TX_ML_men3_40_44_f,
COALESCE(TX_ML_men3_45_49_f.value,0) AS TX_ML_men3_45_49_f,
COALESCE(TX_ML_men3_50_f.value,0) AS TX_ML_men3_50_f,
COALESCE(TX_ML_men3_men1_m.value,0) AS TX_ML_men3_men1_m,
COALESCE(TX_ML_men3_1_4_m.value,0) AS TX_ML_men3_1_4_m,
COALESCE(TX_ML_men3_5_9_m.value,0) AS TX_ML_men3_5_9_m,
COALESCE(TX_ML_men3_10_14_m.value,0) AS TX_ML_men3_10_14_m,
COALESCE(TX_ML_men3_15_19_m.value,0) AS TX_ML_men3_15_19_m,
COALESCE(TX_ML_men3_20_24_m.value,0) AS TX_ML_men3_20_24_m,
COALESCE(TX_ML_men3_25_29_m.value,0) AS TX_ML_men3_25_29_m,
COALESCE(TX_ML_men3_30_34_m.value,0) AS TX_ML_men3_30_34_m,
COALESCE(TX_ML_men3_35_39_m.value,0) AS TX_ML_men3_35_39_m,
COALESCE(TX_ML_men3_40_44_m.value,0) AS TX_ML_men3_40_44_m,
COALESCE(TX_ML_men3_45_49_m.value,0) AS TX_ML_men3_45_49_m,
COALESCE(TX_ML_men3_50_m.value,0) AS TX_ML_men3_50_m,
COALESCE(TX_ML_mai3_men1_f.value,0) AS TX_ML_mai3_men1_f,
COALESCE(TX_ML_mai3_1_4_f.value,0) AS TX_ML_mai3_1_4_f,
COALESCE(TX_ML_mai3_5_9_f.value,0) AS TX_ML_mai3_5_9_f,
COALESCE(TX_ML_mai3_10_14_f.value,0) AS TX_ML_mai3_10_14_f,
COALESCE(TX_ML_mai3_15_19_f.value,0) AS TX_ML_mai3_15_19_f,
COALESCE(TX_ML_mai3_20_24_f.value,0) AS TX_ML_mai3_20_24_f,
COALESCE(TX_ML_mai3_25_29_f.value,0) AS TX_ML_mai3_25_29_f,
COALESCE(TX_ML_mai3_30_34_f.value,0) AS TX_ML_mai3_30_34_f,
COALESCE(TX_ML_mai3_35_39_f.value,0) AS TX_ML_mai3_35_39_f,
COALESCE(TX_ML_mai3_40_44_f.value,0) AS TX_ML_mai3_40_44_f,
COALESCE(TX_ML_mai3_45_49_f.value,0) AS TX_ML_mai3_45_49_f,
COALESCE(TX_ML_mai3_50_f.value,0) AS TX_ML_mai3_50_f,
COALESCE(TX_ML_mai3_men1_m.value,0) AS TX_ML_mai3_men1_m,
COALESCE(TX_ML_mai3_1_4_m.value,0) AS TX_ML_mai3_1_4_m,
COALESCE(TX_ML_mai3_5_9_m.value,0) AS TX_ML_mai3_5_9_m,
COALESCE(TX_ML_mai3_10_14_m.value,0) AS TX_ML_mai3_10_14_m,
COALESCE(TX_ML_mai3_15_19_m.value,0) AS TX_ML_mai3_15_19_m,
COALESCE(TX_ML_mai3_20_24_m.value,0) AS TX_ML_mai3_20_24_m,
COALESCE(TX_ML_mai3_25_29_m.value,0) AS TX_ML_mai3_25_29_m,
COALESCE(TX_ML_mai3_30_34_m.value,0) AS TX_ML_mai3_30_34_m,
COALESCE(TX_ML_mai3_35_39_m.value,0) AS TX_ML_mai3_35_39_m,
COALESCE(TX_ML_mai3_40_44_m.value,0) AS TX_ML_mai3_40_44_m,
COALESCE(TX_ML_mai3_45_49_m.value,0) AS TX_ML_mai3_45_49_m,
COALESCE(TX_ML_mai3_50_m.value,0) AS TX_ML_mai3_50_m,
COALESCE(TX_ML_trans_men1_f.value,0) AS TX_ML_trans_men1_f,
COALESCE(TX_ML_trans_1_4_f.value,0) AS TX_ML_trans_1_4_f,
COALESCE(TX_ML_trans_5_9_f.value,0) AS TX_ML_trans_5_9_f,
COALESCE(TX_ML_trans_10_14_f.value,0) AS TX_ML_trans_10_14_f,
COALESCE(TX_ML_trans_15_19_f.value,0) AS TX_ML_trans_15_19_f,
COALESCE(TX_ML_trans_20_24_f.value,0) AS TX_ML_trans_20_24_f,
COALESCE(TX_ML_trans_25_29_f.value,0) AS TX_ML_trans_25_29_f,
COALESCE(TX_ML_trans_30_34_f.value,0) AS TX_ML_trans_30_34_f,
COALESCE(TX_ML_trans_35_39_f.value,0) AS TX_ML_trans_35_39_f,
COALESCE(TX_ML_trans_40_44_f.value,0) AS TX_ML_trans_40_44_f,
COALESCE(TX_ML_trans_45_49_f.value,0) AS TX_ML_trans_45_49_f,
COALESCE(TX_ML_trans_50_f.value,0) AS TX_ML_trans_50_f,
COALESCE(TX_ML_trans_men1_m.value,0) AS TX_ML_trans_men1_m,
COALESCE(TX_ML_trans_1_4_m.value,0) AS TX_ML_trans_1_4_m,
COALESCE(TX_ML_trans_5_9_m.value,0) AS TX_ML_trans_5_9_m,
COALESCE(TX_ML_trans_10_14_m.value,0) AS TX_ML_trans_10_14_m,
COALESCE(TX_ML_trans_15_19_m.value,0) AS TX_ML_trans_15_19_m,
COALESCE(TX_ML_trans_20_24_m.value,0) AS TX_ML_trans_20_24_m,
COALESCE(TX_ML_trans_25_29_m.value,0) AS TX_ML_trans_25_29_m,
COALESCE(TX_ML_trans_30_34_m.value,0) AS TX_ML_trans_30_34_m,
COALESCE(TX_ML_trans_35_39_m.value,0) AS TX_ML_trans_35_39_m,
COALESCE(TX_ML_trans_40_44_m.value,0) AS TX_ML_trans_40_44_m,
COALESCE(TX_ML_trans_45_49_m.value,0) AS TX_ML_trans_45_49_m,
COALESCE(TX_ML_trans_50_m.value,0) AS TX_ML_trans_50_m,
COALESCE(TX_ML_ref_men1_f.value,0) AS TX_ML_ref_men1_f,
COALESCE(TX_ML_ref_1_4_f.value,0) AS TX_ML_ref_1_4_f,
COALESCE(TX_ML_ref_5_9_f.value,0) AS TX_ML_ref_5_9_f,
COALESCE(TX_ML_ref_10_14_f.value,0) AS TX_ML_ref_10_14_f,
COALESCE(TX_ML_ref_15_19_f.value,0) AS TX_ML_ref_15_19_f,
COALESCE(TX_ML_ref_20_24_f.value,0) AS TX_ML_ref_20_24_f,
COALESCE(TX_ML_ref_25_29_f.value,0) AS TX_ML_ref_25_29_f,
COALESCE(TX_ML_ref_30_34_f.value,0) AS TX_ML_ref_30_34_f,
COALESCE(TX_ML_ref_35_39_f.value,0) AS TX_ML_ref_35_39_f,
COALESCE(TX_ML_ref_40_44_f.value,0) AS TX_ML_ref_40_44_f,
COALESCE(TX_ML_ref_45_49_f.value,0) AS TX_ML_ref_45_49_f,
COALESCE(TX_ML_ref_50_f.value,0) AS TX_ML_ref_50_f,
COALESCE(TX_ML_ref_men1_m.value,0) AS TX_ML_ref_men1_m,
COALESCE(TX_ML_ref_1_4_m.value,0) AS TX_ML_ref_1_4_m,
COALESCE(TX_ML_ref_5_9_m.value,0) AS TX_ML_ref_5_9_m,
COALESCE(TX_ML_ref_10_14_m.value,0) AS TX_ML_ref_10_14_m,
COALESCE(TX_ML_ref_15_19_m.value,0) AS TX_ML_ref_15_19_m,
COALESCE(TX_ML_ref_20_24_m.value,0) AS TX_ML_ref_20_24_m,
COALESCE(TX_ML_ref_25_29_m.value,0) AS TX_ML_ref_25_29_m,
COALESCE(TX_ML_ref_30_34_m.value,0) AS TX_ML_ref_30_34_m,
COALESCE(TX_ML_ref_35_39_m.value,0) AS TX_ML_ref_35_39_m,
COALESCE(TX_ML_ref_40_44_m.value,0) AS TX_ML_ref_40_44_m,
COALESCE(TX_ML_ref_45_49_m.value,0) AS TX_ML_ref_45_49_m,
COALESCE(TX_ML_ref_50_m.value,0) AS TX_ML_ref_50_m,
/*Auto-Calculate*/
/*PMTCT_ART*/
(
COALESCE(PMTCT_ART_New_10_14.value,0)+
COALESCE(PMTCT_ART_New_15_19.value,0)+
COALESCE(PMTCT_ART_New_20_24.value,0)+
COALESCE(PMTCT_ART_New_25.value,0)+
COALESCE(PMTCT_ART_Already_10_14.value,0)+
COALESCE(PMTCT_ART_Already_15_19.value,0)+
COALESCE(PMTCT_ART_Already_20_24.value,0)+
COALESCE(PMTCT_ART_Already_25.value,0) 
) AS PMTCT_ART_num,
COALESCE(PMTCT_ART_New_10_14.value,0) AS PMTCT_ART_New_10_14,
COALESCE(PMTCT_ART_New_15_19.value,0) AS PMTCT_ART_New_15_19,
COALESCE(PMTCT_ART_New_20_24.value,0) AS PMTCT_ART_New_20_24,
COALESCE(PMTCT_ART_New_25.value,0) AS PMTCT_ART_New_25,
COALESCE(PMTCT_ART_Already_10_14.value,0) AS PMTCT_ART_Already_10_14,
COALESCE(PMTCT_ART_Already_15_19.value,0) AS PMTCT_ART_Already_15_19,
COALESCE(PMTCT_ART_Already_20_24.value,0) AS PMTCT_ART_Already_20_24,
COALESCE(PMTCT_ART_Already_25.value,0) AS PMTCT_ART_Already_25,
/*TB_ART*/
COALESCE(TB_ART_num.value,0) AS TB_ART_num,
/*Already*/
COALESCE(TB_ART_prev_men1_f.value,0) AS TB_ART_prev_men1_f,
COALESCE(TB_ART_prev_men1_m.value,0) AS TB_ART_prev_men1_m,
COALESCE(TB_ART_prev_1_4_f.value,0) AS TB_ART_prev_1_4_f,
COALESCE(TB_ART_prev_1_4_m.value,0) AS TB_ART_prev_1_4_m,
COALESCE(TB_ART_prev_5_9_f.value,0) AS TB_ART_prev_5_9_f,
COALESCE(TB_ART_prev_5_9_m.value,0) AS TB_ART_prev_5_9_m,
COALESCE(TB_ART_prev_10_14_f.value,0) AS TB_ART_prev_10_14_f,
COALESCE(TB_ART_prev_10_14_m.value,0) AS TB_ART_prev_10_14_m,
COALESCE(TB_ART_prev_15_19_f.value,0) AS TB_ART_prev_15_19_f,
COALESCE(TB_ART_prev_15_19_m.value,0) AS TB_ART_prev_15_19_m,
COALESCE(TB_ART_prev_20_24_f.value,0) AS TB_ART_prev_20_24_f,
COALESCE(TB_ART_prev_20_24_m.value,0) AS TB_ART_prev_20_24_m,
COALESCE(TB_ART_prev_25_29_f.value,0) AS TB_ART_prev_25_29_f,
COALESCE(TB_ART_prev_25_29_m.value,0) AS TB_ART_prev_25_29_m,
COALESCE(TB_ART_prev_30_34_f.value,0) AS TB_ART_prev_30_34_f,
COALESCE(TB_ART_prev_30_34_m.value,0) AS TB_ART_prev_30_34_m,
COALESCE(TB_ART_prev_35_39_f.value,0) AS TB_ART_prev_35_39_f,
COALESCE(TB_ART_prev_35_39_m.value,0) AS TB_ART_prev_35_39_m,
COALESCE(TB_ART_prev_40_44_f.value,0) AS TB_ART_prev_40_44_f,
COALESCE(TB_ART_prev_40_44_m.value,0) AS TB_ART_prev_40_44_m,
COALESCE(TB_ART_prev_45_49_f.value,0) AS TB_ART_prev_45_49_f,
COALESCE(TB_ART_prev_45_49_m.value,0) AS TB_ART_prev_45_49_m,
COALESCE(TB_ART_prev_50_f.value,0) AS TB_ART_prev_50_f,
COALESCE(TB_ART_prev_50_m.value,0) AS TB_ART_prev_50_m,
/*New*/
(COALESCE(TB_ART_num_men1_f.value,0)-COALESCE(TB_ART_prev_men1_f.value,0)) AS TB_ART_num_men1_f,
(COALESCE(TB_ART_num_men1_m.value,0)-COALESCE(TB_ART_prev_men1_m.value,0)) AS TB_ART_num_men1_m,
(COALESCE(TB_ART_num_1_4_f.value,0)-COALESCE(TB_ART_prev_1_4_f.value,0)) AS TB_ART_num_1_4_f,
(COALESCE(TB_ART_num_1_4_m.value,0)-COALESCE(TB_ART_prev_1_4_m.value,0)) AS TB_ART_num_1_4_m,
(COALESCE(TB_ART_num_5_9_f.value,0)-COALESCE(TB_ART_prev_5_9_f.value,0)) AS TB_ART_num_5_9_f,
(COALESCE(TB_ART_num_5_9_m.value,0)-COALESCE(TB_ART_prev_5_9_m.value,0)) AS TB_ART_num_5_9_m,
(COALESCE(TB_ART_num_10_14_f.value,0)-COALESCE(TB_ART_prev_10_14_f.value,0)) AS TB_ART_num_10_14_f,
(COALESCE(TB_ART_num_10_14_m.value,0)-COALESCE(TB_ART_prev_10_14_m.value,0)) AS TB_ART_num_10_14_m,
(COALESCE(TB_ART_num_15_19_f.value,0)-COALESCE(TB_ART_prev_15_19_f.value,0)) AS TB_ART_num_15_19_f,
(COALESCE(TB_ART_num_15_19_m.value,0)-COALESCE(TB_ART_prev_15_19_m.value,0)) AS TB_ART_num_15_19_m,
(COALESCE(TB_ART_num_20_24_f.value,0)-COALESCE(TB_ART_prev_20_24_f.value,0)) AS TB_ART_num_20_24_f,
(COALESCE(TB_ART_num_20_24_m.value,0)-COALESCE(TB_ART_prev_20_24_m.value,0)) AS TB_ART_num_20_24_m,
(COALESCE(TB_ART_num_25_29_f.value,0)-COALESCE(TB_ART_prev_25_29_f.value,0)) AS TB_ART_num_25_29_f,
(COALESCE(TB_ART_num_25_29_m.value,0)-COALESCE(TB_ART_prev_25_29_m.value,0)) AS TB_ART_num_25_29_m,
(COALESCE(TB_ART_num_30_34_f.value,0)-COALESCE(TB_ART_prev_30_34_f.value,0)) AS TB_ART_num_30_34_f,
(COALESCE(TB_ART_num_30_34_m.value,0)-COALESCE(TB_ART_prev_30_34_m.value,0)) AS TB_ART_num_30_34_m,
(COALESCE(TB_ART_num_35_39_f.value,0)-COALESCE(TB_ART_prev_35_39_f.value,0)) AS TB_ART_num_35_39_f,
(COALESCE(TB_ART_num_35_39_m.value,0)-COALESCE(TB_ART_prev_35_39_m.value,0)) AS TB_ART_num_35_39_m,
(COALESCE(TB_ART_num_40_44_f.value,0)-COALESCE(TB_ART_prev_40_44_f.value,0)) AS TB_ART_num_40_44_f,
(COALESCE(TB_ART_num_40_44_m.value,0)-COALESCE(TB_ART_prev_40_44_m.value,0)) AS TB_ART_num_40_44_m,
(COALESCE(TB_ART_num_45_49_f.value,0)-COALESCE(TB_ART_prev_45_49_f.value,0)) AS TB_ART_num_45_49_f,
(COALESCE(TB_ART_num_45_49_m.value,0)-COALESCE(TB_ART_prev_45_49_m.value,0)) AS TB_ART_num_45_49_m,
(COALESCE(TB_ART_num_50_f.value,0)-COALESCE(TB_ART_prev_50_f.value,0)) AS TB_ART_num_50_f,
(COALESCE(TB_ART_num_50_m.value,0)-COALESCE(TB_ART_prev_50_m.value,0)) AS TB_ART_num_50_m,
/*Auto-Calculate*/
/*TX_PVLS*/
/*Numerator*/
(
COALESCE(TX_PVLS_num_rou_f_men1.value,0)+
COALESCE(TX_PVLS_num_rou_f_1_4.value,0)+
COALESCE(TX_PVLS_num_rou_f_5_9.value,0)+
COALESCE(TX_PVLS_num_rou_f_10_14.value,0)+
COALESCE(TX_PVLS_num_rou_f_15_19.value,0)+
COALESCE(TX_PVLS_num_rou_f_20_24.value,0)+
COALESCE(TX_PVLS_num_rou_f_25_29.value,0)+
COALESCE(TX_PVLS_num_rou_f_30_34.value,0)+
COALESCE(TX_PVLS_num_rou_f_35_39.value,0)+
COALESCE(TX_PVLS_num_rou_f_40_44.value,0)+
COALESCE(TX_PVLS_num_rou_f_45_49.value,0)+
COALESCE(TX_PVLS_num_rou_f_50.value,0)+
COALESCE(TX_PVLS_num_rou_m_men1.value,0)+
COALESCE(TX_PVLS_num_rou_m_1_4.value,0)+
COALESCE(TX_PVLS_num_rou_m_5_9.value,0)+
COALESCE(TX_PVLS_num_rou_m_10_14.value,0)+
COALESCE(TX_PVLS_num_rou_m_15_19.value,0)+
COALESCE(TX_PVLS_num_rou_m_20_24.value,0)+
COALESCE(TX_PVLS_num_rou_m_25_29.value,0)+
COALESCE(TX_PVLS_num_rou_m_30_34.value,0)+
COALESCE(TX_PVLS_num_rou_m_35_39.value,0)+
COALESCE(TX_PVLS_num_rou_m_40_44.value,0)+
COALESCE(TX_PVLS_num_rou_m_45_49.value,0)+
COALESCE(TX_PVLS_num_rou_m_50.value,0)+
/*Not Documented*/ 
COALESCE(TX_PVLS_num_und_f_men1.value,0)+
COALESCE(TX_PVLS_num_und_f_1_4.value,0)+
COALESCE(TX_PVLS_num_und_f_5_9.value,0)+
COALESCE(TX_PVLS_num_und_f_10_14.value,0)+
COALESCE(TX_PVLS_num_und_f_15_19.value,0)+
COALESCE(TX_PVLS_num_und_f_20_24.value,0)+
COALESCE(TX_PVLS_num_und_f_25_29.value,0)+
COALESCE(TX_PVLS_num_und_f_30_34.value,0)+
COALESCE(TX_PVLS_num_und_f_35_39.value,0)+
COALESCE(TX_PVLS_num_und_f_40_44.value,0)+
COALESCE(TX_PVLS_num_und_f_45_49.value,0)+
COALESCE(TX_PVLS_num_und_f_50.value,0)+
COALESCE(TX_PVLS_num_und_m_men1.value,0)+
COALESCE(TX_PVLS_num_und_m_1_4.value,0)+
COALESCE(TX_PVLS_num_und_m_5_9.value,0)+
COALESCE(TX_PVLS_num_und_m_10_14.value,0)+
COALESCE(TX_PVLS_num_und_m_15_19.value,0)+
COALESCE(TX_PVLS_num_und_m_20_24.value,0)+
COALESCE(TX_PVLS_num_und_m_25_29.value,0)+
COALESCE(TX_PVLS_num_und_m_30_34.value,0)+
COALESCE(TX_PVLS_num_und_m_35_39.value,0)+
COALESCE(TX_PVLS_num_und_m_40_44.value,0)+
COALESCE(TX_PVLS_num_und_m_45_49.value,0)+
COALESCE(TX_PVLS_num_und_m_50.value,0) 
) 
AS TX_PVLS_num,
COALESCE(TX_PVLS_num_rou_preg.value,0) AS TX_PVLS_num_rou_preg,
COALESCE(TX_PVLS_num_rou_breast.value,0) AS TX_PVLS_num_rou_breast,
COALESCE(TX_PVLS_num_und_preg.value,0) AS TX_PVLS_num_und_preg,
COALESCE(TX_PVLS_num_und_breast.value,0) AS TX_PVLS_num_und_breast,
/*Routine*/
COALESCE(TX_PVLS_num_rou_f_men1.value,0) AS TX_PVLS_num_rou_f_men1,
COALESCE(TX_PVLS_num_rou_f_1_4.value,0) AS TX_PVLS_num_rou_f_1_4,
COALESCE(TX_PVLS_num_rou_f_5_9.value,0) AS TX_PVLS_num_rou_f_5_9,
COALESCE(TX_PVLS_num_rou_f_10_14.value,0) AS TX_PVLS_num_rou_f_10_14,
COALESCE(TX_PVLS_num_rou_f_15_19.value,0) AS TX_PVLS_num_rou_f_15_19,
COALESCE(TX_PVLS_num_rou_f_20_24.value,0) AS TX_PVLS_num_rou_f_20_24,
COALESCE(TX_PVLS_num_rou_f_25_29.value,0) AS TX_PVLS_num_rou_f_25_29,
COALESCE(TX_PVLS_num_rou_f_30_34.value,0) AS TX_PVLS_num_rou_f_30_34,
COALESCE(TX_PVLS_num_rou_f_35_39.value,0) AS TX_PVLS_num_rou_f_35_39,
COALESCE(TX_PVLS_num_rou_f_40_44.value,0) AS TX_PVLS_num_rou_f_40_44,
COALESCE(TX_PVLS_num_rou_f_45_49.value,0) AS TX_PVLS_num_rou_f_45_49,
COALESCE(TX_PVLS_num_rou_f_50.value,0) AS TX_PVLS_num_rou_f_50,
COALESCE(TX_PVLS_num_rou_m_men1.value,0) AS TX_PVLS_num_rou_m_men1,
COALESCE(TX_PVLS_num_rou_m_1_4.value,0) AS TX_PVLS_num_rou_m_1_4,
COALESCE(TX_PVLS_num_rou_m_5_9.value,0) AS TX_PVLS_num_rou_m_5_9,
COALESCE(TX_PVLS_num_rou_m_10_14.value,0) AS TX_PVLS_num_rou_m_10_14,
COALESCE(TX_PVLS_num_rou_m_15_19.value,0) AS TX_PVLS_num_rou_m_15_19,
COALESCE(TX_PVLS_num_rou_m_20_24.value,0) AS TX_PVLS_num_rou_m_20_24,
COALESCE(TX_PVLS_num_rou_m_25_29.value,0) AS TX_PVLS_num_rou_m_25_29,
COALESCE(TX_PVLS_num_rou_m_30_34.value,0) AS TX_PVLS_num_rou_m_30_34,
COALESCE(TX_PVLS_num_rou_m_35_39.value,0) AS TX_PVLS_num_rou_m_35_39,
COALESCE(TX_PVLS_num_rou_m_40_44.value,0) AS TX_PVLS_num_rou_m_40_44,
COALESCE(TX_PVLS_num_rou_m_45_49.value,0) AS TX_PVLS_num_rou_m_45_49,
COALESCE(TX_PVLS_num_rou_m_50.value,0) AS TX_PVLS_num_rou_m_50,
/*Not Documented*/
COALESCE(TX_PVLS_num_und_f_men1.value,0) AS TX_PVLS_num_und_f_men1,
COALESCE(TX_PVLS_num_und_f_1_4.value,0) AS TX_PVLS_num_und_f_1_4,
COALESCE(TX_PVLS_num_und_f_5_9.value,0) AS TX_PVLS_num_und_f_5_9,
COALESCE(TX_PVLS_num_und_f_10_14.value,0) AS TX_PVLS_num_und_f_10_14,
COALESCE(TX_PVLS_num_und_f_15_19.value,0) AS TX_PVLS_num_und_f_15_19,
COALESCE(TX_PVLS_num_und_f_20_24.value,0) AS TX_PVLS_num_und_f_20_24,
COALESCE(TX_PVLS_num_und_f_25_29.value,0) AS TX_PVLS_num_und_f_25_29,
COALESCE(TX_PVLS_num_und_f_30_34.value,0) AS TX_PVLS_num_und_f_30_34,
COALESCE(TX_PVLS_num_und_f_35_39.value,0) AS TX_PVLS_num_und_f_35_39,
COALESCE(TX_PVLS_num_und_f_40_44.value,0) AS TX_PVLS_num_und_f_40_44,
COALESCE(TX_PVLS_num_und_f_45_49.value,0) AS TX_PVLS_num_und_f_45_49,
COALESCE(TX_PVLS_num_und_f_50.value,0) AS TX_PVLS_num_und_f_50,
COALESCE(TX_PVLS_num_und_m_men1.value,0) AS TX_PVLS_num_und_m_men1,
COALESCE(TX_PVLS_num_und_m_1_4.value,0) AS TX_PVLS_num_und_m_1_4,
COALESCE(TX_PVLS_num_und_m_5_9.value,0) AS TX_PVLS_num_und_m_5_9,
COALESCE(TX_PVLS_num_und_m_10_14.value,0) AS TX_PVLS_num_und_m_10_14,
COALESCE(TX_PVLS_num_und_m_15_19.value,0) AS TX_PVLS_num_und_m_15_19,
COALESCE(TX_PVLS_num_und_m_20_24.value,0) AS TX_PVLS_num_und_m_20_24,
COALESCE(TX_PVLS_num_und_m_25_29.value,0) AS TX_PVLS_num_und_m_25_29,
COALESCE(TX_PVLS_num_und_m_30_34.value,0) AS TX_PVLS_num_und_m_30_34,
COALESCE(TX_PVLS_num_und_m_35_39.value,0) AS TX_PVLS_num_und_m_35_39,
COALESCE(TX_PVLS_num_und_m_40_44.value,0) AS TX_PVLS_num_und_m_40_44,
COALESCE(TX_PVLS_num_und_m_45_49.value,0) AS TX_PVLS_num_und_m_45_49,
COALESCE(TX_PVLS_num_und_m_50.value,0) AS TX_PVLS_num_und_m_50,
COALESCE(TX_PVLS_N_R_keypop_pwid.value,0) AS TX_PVLS_N_R_keypop_pwid,
COALESCE(TX_PVLS_N_R_keypop_msm.value,0) AS TX_PVLS_N_R_keypop_msm,
COALESCE(TX_PVLS_N_R_keypop_tg.value,0) AS TX_PVLS_N_R_keypop_tg,
COALESCE(TX_PVLS_N_R_keypop_fsw.value,0) AS TX_PVLS_N_R_keypop_fsw,
COALESCE(TX_PVLS_N_R_keypop_prison.value,0) AS TX_PVLS_N_R_keypop_prison,
COALESCE(TX_PVLS_N_T_keypop_pwid.value,0) AS TX_PVLS_N_T_keypop_pwid,
COALESCE(TX_PVLS_N_T_keypop_msm.value,0) AS TX_PVLS_N_T_keypop_msm,
COALESCE(TX_PVLS_N_T_keypop_tg.value,0) AS TX_PVLS_N_T_keypop_tg,
COALESCE(TX_PVLS_N_T_keypop_fsw.value,0) AS TX_PVLS_N_T_keypop_fsw,
COALESCE(TX_PVLS_N_T_keypop_prison.value,0) AS TX_PVLS_N_T_keypop_prison,
/*Denominator*/
(
COALESCE(TX_PVLS_den_rou_f_men1.value,0)+
COALESCE(TX_PVLS_den_rou_f_1_4.value,0)+
COALESCE(TX_PVLS_den_rou_f_5_9.value,0)+
COALESCE(TX_PVLS_den_rou_f_10_14.value,0)+
COALESCE(TX_PVLS_den_rou_f_15_19.value,0)+
COALESCE(TX_PVLS_den_rou_f_20_24.value,0)+
COALESCE(TX_PVLS_den_rou_f_25_29.value,0)+
COALESCE(TX_PVLS_den_rou_f_30_34.value,0)+
COALESCE(TX_PVLS_den_rou_f_35_39.value,0)+
COALESCE(TX_PVLS_den_rou_f_40_44.value,0)+
COALESCE(TX_PVLS_den_rou_f_45_49.value,0)+
COALESCE(TX_PVLS_den_rou_f_50.value,0)+
COALESCE(TX_PVLS_den_rou_m_men1.value,0)+
COALESCE(TX_PVLS_den_rou_m_1_4.value,0)+
COALESCE(TX_PVLS_den_rou_m_5_9.value,0)+
COALESCE(TX_PVLS_den_rou_m_10_14.value,0)+
COALESCE(TX_PVLS_den_rou_m_15_19.value,0)+
COALESCE(TX_PVLS_den_rou_m_20_24.value,0)+
COALESCE(TX_PVLS_den_rou_m_25_29.value,0)+
COALESCE(TX_PVLS_den_rou_m_30_34.value,0)+
COALESCE(TX_PVLS_den_rou_m_35_39.value,0)+
COALESCE(TX_PVLS_den_rou_m_40_44.value,0)+
COALESCE(TX_PVLS_den_rou_m_45_49.value,0)+
COALESCE(TX_PVLS_den_rou_m_50.value,0)+
/*Not Documented*/ 
COALESCE(TX_PVLS_den_und_f_men1.value,0)+
COALESCE(TX_PVLS_den_und_f_1_4.value,0)+
COALESCE(TX_PVLS_den_und_f_5_9.value,0)+
COALESCE(TX_PVLS_den_und_f_10_14.value,0)+
COALESCE(TX_PVLS_den_und_f_15_19.value,0)+
COALESCE(TX_PVLS_den_und_f_20_24.value,0)+
COALESCE(TX_PVLS_den_und_f_25_29.value,0)+
COALESCE(TX_PVLS_den_und_f_30_34.value,0)+
COALESCE(TX_PVLS_den_und_f_35_39.value,0)+
COALESCE(TX_PVLS_den_und_f_40_44.value,0)+
COALESCE(TX_PVLS_den_und_f_45_49.value,0)+
COALESCE(TX_PVLS_den_und_f_50.value,0)+
COALESCE(TX_PVLS_den_und_m_men1.value,0)+
COALESCE(TX_PVLS_den_und_m_1_4.value,0)+
COALESCE(TX_PVLS_den_und_m_5_9.value,0)+
COALESCE(TX_PVLS_den_und_m_10_14.value,0)+
COALESCE(TX_PVLS_den_und_m_15_19.value,0)+
COALESCE(TX_PVLS_den_und_m_20_24.value,0)+
COALESCE(TX_PVLS_den_und_m_25_29.value,0)+
COALESCE(TX_PVLS_den_und_m_30_34.value,0)+
COALESCE(TX_PVLS_den_und_m_35_39.value,0)+
COALESCE(TX_PVLS_den_und_m_40_44.value,0)+
COALESCE(TX_PVLS_den_und_m_45_49.value,0)+
COALESCE(TX_PVLS_den_und_m_50.value,0) 
) 
AS TX_PVLS_den,
COALESCE(TX_PVLS_den_rou_preg.value,0) AS TX_PVLS_den_rou_preg,
COALESCE(TX_PVLS_den_rou_breast.value,0) AS TX_PVLS_den_rou_breast,
COALESCE(TX_PVLS_den_und_preg.value,0) AS TX_PVLS_den_und_preg,
COALESCE(TX_PVLS_den_und_breast.value,0) AS TX_PVLS_den_und_breast,
/*Routine*/
COALESCE(TX_PVLS_den_rou_f_men1.value,0) AS TX_PVLS_den_rou_f_men1,
COALESCE(TX_PVLS_den_rou_f_1_4.value,0) AS TX_PVLS_den_rou_f_1_4,
COALESCE(TX_PVLS_den_rou_f_5_9.value,0) AS TX_PVLS_den_rou_f_5_9,
COALESCE(TX_PVLS_den_rou_f_10_14.value,0) AS TX_PVLS_den_rou_f_10_14,
COALESCE(TX_PVLS_den_rou_f_15_19.value,0) AS TX_PVLS_den_rou_f_15_19,
COALESCE(TX_PVLS_den_rou_f_20_24.value,0) AS TX_PVLS_den_rou_f_20_24,
COALESCE(TX_PVLS_den_rou_f_25_29.value,0) AS TX_PVLS_den_rou_f_25_29,
COALESCE(TX_PVLS_den_rou_f_30_34.value,0) AS TX_PVLS_den_rou_f_30_34,
COALESCE(TX_PVLS_den_rou_f_35_39.value,0) AS TX_PVLS_den_rou_f_35_39,
COALESCE(TX_PVLS_den_rou_f_40_44.value,0) AS TX_PVLS_den_rou_f_40_44,
COALESCE(TX_PVLS_den_rou_f_45_49.value,0) AS TX_PVLS_den_rou_f_45_49,
COALESCE(TX_PVLS_den_rou_f_50.value,0) AS TX_PVLS_den_rou_f_50,
COALESCE(TX_PVLS_den_rou_m_men1.value,0) AS TX_PVLS_den_rou_m_men1,
COALESCE(TX_PVLS_den_rou_m_1_4.value,0) AS TX_PVLS_den_rou_m_1_4,
COALESCE(TX_PVLS_den_rou_m_5_9.value,0) AS TX_PVLS_den_rou_m_5_9,
COALESCE(TX_PVLS_den_rou_m_10_14.value,0) AS TX_PVLS_den_rou_m_10_14,
COALESCE(TX_PVLS_den_rou_m_15_19.value,0) AS TX_PVLS_den_rou_m_15_19,
COALESCE(TX_PVLS_den_rou_m_20_24.value,0) AS TX_PVLS_den_rou_m_20_24,
COALESCE(TX_PVLS_den_rou_m_25_29.value,0) AS TX_PVLS_den_rou_m_25_29,
COALESCE(TX_PVLS_den_rou_m_30_34.value,0) AS TX_PVLS_den_rou_m_30_34,
COALESCE(TX_PVLS_den_rou_m_35_39.value,0) AS TX_PVLS_den_rou_m_35_39,
COALESCE(TX_PVLS_den_rou_m_40_44.value,0) AS TX_PVLS_den_rou_m_40_44,
COALESCE(TX_PVLS_den_rou_m_45_49.value,0) AS TX_PVLS_den_rou_m_45_49,
COALESCE(TX_PVLS_den_rou_m_50.value,0) AS TX_PVLS_den_rou_m_50,
/*Not Documented*/
COALESCE(TX_PVLS_den_und_f_men1.value,0) AS TX_PVLS_den_und_f_men1,
COALESCE(TX_PVLS_den_und_f_1_4.value,0) AS TX_PVLS_den_und_f_1_4,
COALESCE(TX_PVLS_den_und_f_5_9.value,0) AS TX_PVLS_den_und_f_5_9,
COALESCE(TX_PVLS_den_und_f_10_14.value,0) AS TX_PVLS_den_und_f_10_14,
COALESCE(TX_PVLS_den_und_f_15_19.value,0) AS TX_PVLS_den_und_f_15_19,
COALESCE(TX_PVLS_den_und_f_20_24.value,0) AS TX_PVLS_den_und_f_20_24,
COALESCE(TX_PVLS_den_und_f_25_29.value,0) AS TX_PVLS_den_und_f_25_29,
COALESCE(TX_PVLS_den_und_f_30_34.value,0) AS TX_PVLS_den_und_f_30_34,
COALESCE(TX_PVLS_den_und_f_35_39.value,0) AS TX_PVLS_den_und_f_35_39,
COALESCE(TX_PVLS_den_und_f_40_44.value,0) AS TX_PVLS_den_und_f_40_44,
COALESCE(TX_PVLS_den_und_f_45_49.value,0) AS TX_PVLS_den_und_f_45_49,
COALESCE(TX_PVLS_den_und_f_50.value,0) AS TX_PVLS_den_und_f_50,
COALESCE(TX_PVLS_den_und_m_men1.value,0) AS TX_PVLS_den_und_m_men1,
COALESCE(TX_PVLS_den_und_m_1_4.value,0) AS TX_PVLS_den_und_m_1_4,
COALESCE(TX_PVLS_den_und_m_5_9.value,0) AS TX_PVLS_den_und_m_5_9,
COALESCE(TX_PVLS_den_und_m_10_14.value,0) AS TX_PVLS_den_und_m_10_14,
COALESCE(TX_PVLS_den_und_m_15_19.value,0) AS TX_PVLS_den_und_m_15_19,
COALESCE(TX_PVLS_den_und_m_20_24.value,0) AS TX_PVLS_den_und_m_20_24,
COALESCE(TX_PVLS_den_und_m_25_29.value,0) AS TX_PVLS_den_und_m_25_29,
COALESCE(TX_PVLS_den_und_m_30_34.value,0) AS TX_PVLS_den_und_m_30_34,
COALESCE(TX_PVLS_den_und_m_35_39.value,0) AS TX_PVLS_den_und_m_35_39,
COALESCE(TX_PVLS_den_und_m_40_44.value,0) AS TX_PVLS_den_und_m_40_44,
COALESCE(TX_PVLS_den_und_m_45_49.value,0) AS TX_PVLS_den_und_m_45_49,
COALESCE(TX_PVLS_den_und_m_50.value,0) AS TX_PVLS_den_und_m_50,
COALESCE(TX_PVLS_D_R_keypop_pwid.value,0) AS TX_PVLS_D_R_keypop_pwid,
COALESCE(TX_PVLS_D_R_keypop_msm.value,0) AS TX_PVLS_D_R_keypop_msm,
COALESCE(TX_PVLS_D_R_keypop_tg.value,0) AS TX_PVLS_D_R_keypop_tg,
COALESCE(TX_PVLS_D_R_keypop_fsw.value,0) AS TX_PVLS_D_R_keypop_fsw,
COALESCE(TX_PVLS_D_R_keypop_prison.value,0) AS TX_PVLS_D_R_keypop_prison,
COALESCE(TX_PVLS_D_T_keypop_pwid.value,0) AS TX_PVLS_D_T_keypop_pwid,
COALESCE(TX_PVLS_D_T_keypop_msm.value,0) AS TX_PVLS_D_T_keypop_msm,
COALESCE(TX_PVLS_D_T_keypop_tg.value,0) AS TX_PVLS_D_T_keypop_tg,
COALESCE(TX_PVLS_D_T_keypop_fsw.value,0) AS TX_PVLS_D_T_keypop_fsw,
COALESCE(TX_PVLS_D_T_keypop_prison.value,0) AS TX_PVLS_D_T_keypop_prison,

/*PrEP_NEW*/
COALESCE(PrEP_NEW_num.value,0) AS PrEP_NEW_num,
COALESCE(PrEP_NEW_15_19_f.value,0) AS PrEP_NEW_15_19_f,
COALESCE(PrEP_NEW_20_24_f.value,0) AS PrEP_NEW_20_24_f,
COALESCE(PrEP_NEW_25_29_f.value,0) AS PrEP_NEW_25_29_f,
COALESCE(PrEP_NEW_30_34_f.value,0) AS PrEP_NEW_30_34_f,
COALESCE(PrEP_NEW_35_39_f.value,0) AS PrEP_NEW_35_39_f,
COALESCE(PrEP_NEW_40_44_f.value,0) AS PrEP_NEW_40_44_f,
COALESCE(PrEP_NEW_45_49_f.value,0) AS PrEP_NEW_45_49_f,
COALESCE(PrEP_NEW_50_f.value,0) AS PrEP_NEW_50_f,
COALESCE(PrEP_NEW_15_19_m.value,0) AS PrEP_NEW_15_19_m,
COALESCE(PrEP_NEW_20_24_m.value,0) AS PrEP_NEW_20_24_m,
COALESCE(PrEP_NEW_25_29_m.value,0) AS PrEP_NEW_25_29_m,
COALESCE(PrEP_NEW_30_34_m.value,0) AS PrEP_NEW_30_34_m,
COALESCE(PrEP_NEW_35_39_m.value,0) AS PrEP_NEW_35_39_m,
COALESCE(PrEP_NEW_40_44_m.value,0) AS PrEP_NEW_40_44_m,
COALESCE(PrEP_NEW_45_49_m.value,0) AS PrEP_NEW_45_49_m,
COALESCE(PrEP_NEW_50_m.value,0) AS PrEP_NEW_50_m,
COALESCE(PrEP_NEW_keypop_pwid.value,0) AS PrEP_NEW_keypop_pwid,
COALESCE(PrEP_NEW_keypop_msm.value,0) AS PrEP_NEW_keypop_msm,
COALESCE(PrEP_NEW_keypop_tg.value,0) AS PrEP_NEW_keypop_tg,
COALESCE(PrEP_NEW_keypop_fsw.value,0) AS PrEP_NEW_keypop_fsw,
'' AS placeholder,
/*PrEP_CURR*/
COALESCE(PrEP_CURR_num.value,0) AS PrEP_CURR_num,
COALESCE(PrEP_CURR_15_19_f.value,0) AS PrEP_CURR_15_19_f,
COALESCE(PrEP_CURR_20_24_f.value,0) AS PrEP_CURR_20_24_f,
COALESCE(PrEP_CURR_25_29_f.value,0) AS PrEP_CURR_25_29_f,
COALESCE(PrEP_CURR_30_34_f.value,0) AS PrEP_CURR_30_34_f,
COALESCE(PrEP_CURR_35_39_f.value,0) AS PrEP_CURR_35_39_f,
COALESCE(PrEP_CURR_40_44_f.value,0) AS PrEP_CURR_40_44_f,
COALESCE(PrEP_CURR_45_49_f.value,0) AS PrEP_CURR_45_49_f,
COALESCE(PrEP_CURR_50_f.value,0) AS PrEP_CURR_50_f,
COALESCE(PrEP_CURR_15_19_m.value,0) AS PrEP_CURR_15_19_m,
COALESCE(PrEP_CURR_20_24_m.value,0) AS PrEP_CURR_20_24_m,
COALESCE(PrEP_CURR_25_29_m.value,0) AS PrEP_CURR_25_29_m,
COALESCE(PrEP_CURR_30_34_m.value,0) AS PrEP_CURR_30_34_m,
COALESCE(PrEP_CURR_35_39_m.value,0) AS PrEP_CURR_35_39_m,
COALESCE(PrEP_CURR_40_44_m.value,0) AS PrEP_CURR_40_44_m,
COALESCE(PrEP_CURR_45_49_m.value,0) AS PrEP_CURR_45_49_m,
COALESCE(PrEP_CURR_50_m.value,0) AS PrEP_CURR_50_m,
COALESCE(PrEP_3_pos.value,0) AS PrEP_3_pos,
COALESCE(PrEP_3_neg.value,0) AS PrEP_3_neg,
COALESCE(PrEP_3_less.value,0) AS PrEP_3_less,
COALESCE(PrEP_CURR_keypop_pwid.value,0) AS PrEP_CURR_keypop_pwid,
COALESCE(PrEP_CURR_keypop_msm.value,0) AS PrEP_CURR_keypop_msm,
COALESCE(PrEP_CURR_keypop_tg.value,0) AS PrEP_CURR_keypop_tg,
COALESCE(PrEP_CURR_keypop_fsw.value,0) AS PrEP_CURR_keypop_fsw,
'' AS placeholder,
----------------------------------------------------------------------------------------
--SEMIANNUALY
----------------------------------------------------------------------------------------
/*TB_PREV_num*/
COALESCE(TB_PREV_num.value,0) AS TB_PREV_num,
COALESCE(TB_PREV_num_ipt_new_f_men15.value,0) AS TB_PREV_num_ipt_new_f_men15,
COALESCE(TB_PREV_num_ipt_new_f_mai15.value,0) AS TB_PREV_num_ipt_new_f_mai15,
COALESCE(TB_PREV_num_ipt_new_m_men15.value,0) AS TB_PREV_num_ipt_new_m_men15,
COALESCE(TB_PREV_num_ipt_new_m_mai15.value,0) AS TB_PREV_num_ipt_new_m_mai15,
COALESCE(TB_PREV_num_ipt_already_f_men15.value,0) AS TB_PREV_num_ipt_already_f_men15,
COALESCE(TB_PREV_num_ipt_already_f_mai15.value,0) AS TB_PREV_num_ipt_already_f_mai15,
COALESCE(TB_PREV_num_ipt_already_m_men15.value,0) AS TB_PREV_num_ipt_already_m_men15,
COALESCE(TB_PREV_num_ipt_already_m_mai15.value,0) AS TB_PREV_num_ipt_already_m_mai15,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
/*TB_PREV_den*/
COALESCE(TB_PREV_den.value,0) AS TB_PREV_den,
COALESCE(TB_PREV_den_ipt_new_f_men15.value,0) AS TB_PREV_den_ipt_new_f_men15,
COALESCE(TB_PREV_den_ipt_new_f_mai15.value,0) AS TB_PREV_den_ipt_new_f_mai15,
COALESCE(TB_PREV_den_ipt_new_m_men15.value,0) AS TB_PREV_den_ipt_new_m_men15,
COALESCE(TB_PREV_den_ipt_new_m_mai15.value,0) AS TB_PREV_den_ipt_new_m_mai15,
COALESCE(TB_PREV_den_ipt_already_f_men15.value,0) AS TB_PREV_den_ipt_already_f_men15,
COALESCE(TB_PREV_den_ipt_already_f_mai15.value,0) AS TB_PREV_den_ipt_already_f_mai15,
COALESCE(TB_PREV_den_ipt_already_m_men15.value,0) AS TB_PREV_den_ipt_already_m_men15,
COALESCE(TB_PREV_den_ipt_already_m_mai15.value,0) AS TB_PREV_den_ipt_already_m_mai15,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
'' AS placeholder,
/*CXCA_SCRN*/
/*Auto Calculate*/
(
COALESCE(CXCA_SCRN_neg_15_19.value,0) +
COALESCE(CXCA_SCRN_neg_20_24.value,0) +
COALESCE(CXCA_SCRN_neg_25_29.value,0) +
COALESCE(CXCA_SCRN_neg_30_34.value,0) +
COALESCE(CXCA_SCRN_neg_35_39.value,0) +
COALESCE(CXCA_SCRN_neg_40_44.value,0) +
COALESCE(CXCA_SCRN_neg_45_49.value,0) +
COALESCE(CXCA_SCRN_neg_50.value,0) +
COALESCE(CXCA_SCRN_pos_15_19.value,0) +
COALESCE(CXCA_SCRN_pos_20_24.value,0) +
COALESCE(CXCA_SCRN_pos_25_29.value,0) +
COALESCE(CXCA_SCRN_pos_30_34.value,0) +
COALESCE(CXCA_SCRN_pos_35_39.value,0) +
COALESCE(CXCA_SCRN_pos_40_44.value,0) +
COALESCE(CXCA_SCRN_pos_45_49.value,0) +
COALESCE(CXCA_SCRN_pos_50.value,0) +
COALESCE(CXCA_SCRN_sus_15_19.value,0) +
COALESCE(CXCA_SCRN_sus_20_24.value,0) +
COALESCE(CXCA_SCRN_sus_25_29.value,0) +
COALESCE(CXCA_SCRN_sus_30_34.value,0) +
COALESCE(CXCA_SCRN_sus_35_39.value,0) +
COALESCE(CXCA_SCRN_sus_40_44.value,0) +
COALESCE(CXCA_SCRN_sus_45_49.value,0) +
COALESCE(CXCA_SCRN_sus_50.value,0) 
) AS CXCA_SCRN_num,
COALESCE(CXCA_SCRN_neg_15_19.value,0) as CXCA_SCRN_neg_15_19,
COALESCE(CXCA_SCRN_neg_20_24.value,0) as CXCA_SCRN_neg_20_24,
COALESCE(CXCA_SCRN_neg_25_29.value,0) as CXCA_SCRN_neg_25_29,
COALESCE(CXCA_SCRN_neg_30_34.value,0) as CXCA_SCRN_neg_30_34,
COALESCE(CXCA_SCRN_neg_35_39.value,0) as CXCA_SCRN_neg_35_39,
COALESCE(CXCA_SCRN_neg_40_44.value,0) as CXCA_SCRN_neg_40_44,
COALESCE(CXCA_SCRN_neg_45_49.value,0) as CXCA_SCRN_neg_45_49,
COALESCE(CXCA_SCRN_neg_50.value,0) as CXCA_SCRN_neg_50,
COALESCE(CXCA_SCRN_pos_15_19.value,0) as CXCA_SCRN_pos_15_19,
COALESCE(CXCA_SCRN_pos_20_24.value,0) as CXCA_SCRN_pos_20_24,
COALESCE(CXCA_SCRN_pos_25_29.value,0) as CXCA_SCRN_pos_25_29,
COALESCE(CXCA_SCRN_pos_30_34.value,0) as CXCA_SCRN_pos_30_34,
COALESCE(CXCA_SCRN_pos_35_39.value,0) as CXCA_SCRN_pos_35_39,
COALESCE(CXCA_SCRN_pos_40_44.value,0) as CXCA_SCRN_pos_40_44,
COALESCE(CXCA_SCRN_pos_45_49.value,0) as CXCA_SCRN_pos_45_49,
COALESCE(CXCA_SCRN_pos_50.value,0) as CXCA_SCRN_pos_50,
COALESCE(CXCA_SCRN_sus_15_19.value,0) as CXCA_SCRN_sus_15_19,
COALESCE(CXCA_SCRN_sus_20_24.value,0) as CXCA_SCRN_sus_20_24,
COALESCE(CXCA_SCRN_sus_25_29.value,0) as CXCA_SCRN_sus_25_29,
COALESCE(CXCA_SCRN_sus_30_34.value,0) as CXCA_SCRN_sus_30_34,
COALESCE(CXCA_SCRN_sus_35_39.value,0) as CXCA_SCRN_sus_35_39,
COALESCE(CXCA_SCRN_sus_40_44.value,0) as CXCA_SCRN_sus_40_44,
COALESCE(CXCA_SCRN_sus_45_49.value,0) as CXCA_SCRN_sus_45_49,
COALESCE(CXCA_SCRN_sus_50.value,0) as CXCA_SCRN_sus_50,
/*TX_ML*/

/*TX_TB (Numerator)*/
COALESCE(TX_TB_num.value,0) AS TX_TB_num,
COALESCE(TX_TB_num_new_men15_f.value,0) AS TX_TB_num_new_men15_f,
COALESCE(TX_TB_num_new_mai15_f.value,0) AS TX_TB_num_new_mai15_f,
COALESCE(TX_TB_num_new_men15_m.value,0) AS TX_TB_num_new_men15_m,
COALESCE(TX_TB_num_new_mai15_m.value,0) AS TX_TB_num_new_mai15_m,
COALESCE(TX_TB_num_already_men15_f.value,0) AS TX_TB_num_already_men15_f,
COALESCE(TX_TB_num_already_mai15_f.value,0) AS TX_TB_num_already_mai15_f,
COALESCE(TX_TB_num_already_men15_m.value,0) AS TX_TB_num_already_men15_m,
COALESCE(TX_TB_num_already_mai15_m.value,0) AS TX_TB_num_already_mai15_m,
/*TX_TB (Denominator)*/
COALESCE(TX_TB_den.value,0) AS TX_TB_den,
COALESCE(TX_TB_den_pos_new_f_men15.value,0) AS TX_TB_den_pos_new_f_men15,
COALESCE(TX_TB_den_pos_new_f_mai15.value,0) AS TX_TB_den_pos_new_f_mai15,
COALESCE(TX_TB_den_pos_new_m_men15.value,0) AS TX_TB_den_pos_new_m_men15,
COALESCE(TX_TB_den_pos_new_m_mai15.value,0) AS TX_TB_den_pos_new_m_mai15,
COALESCE(TX_TB_den_pos_already_f_men15.value,0) AS TX_TB_den_pos_already_f_men15,
COALESCE(TX_TB_den_pos_already_f_mai15.value,0) AS TX_TB_den_pos_already_f_mai15,
COALESCE(TX_TB_den_pos_already_m_men15.value,0) AS TX_TB_den_pos_already_m_men15,
COALESCE(TX_TB_den_pos_already_m_mai15.value,0) AS TX_TB_den_pos_already_m_mai15,
COALESCE(TX_TB_den_neg_new_f_men15.value,0) AS TX_TB_den_neg_new_f_men15,
COALESCE(TX_TB_den_neg_new_f_mai15.value,0) AS TX_TB_den_neg_new_f_mai15,
COALESCE(TX_TB_den_neg_new_m_men15.value,0) AS TX_TB_den_neg_new_m_men15,
COALESCE(TX_TB_den_neg_new_m_mai15.value,0) AS TX_TB_den_neg_new_m_mai15,
COALESCE(TX_TB_den_neg_already_f_men15.value,0) AS TX_TB_den_neg_already_f_men15,
COALESCE(TX_TB_den_neg_already_f_mai15.value,0) AS TX_TB_den_neg_already_f_mai15,
COALESCE(TX_TB_den_neg_already_m_men15.value,0) AS TX_TB_den_neg_already_m_men15,
COALESCE(TX_TB_den_neg_already_m_mai15.value,0) AS TX_TB_den_neg_already_m_mai15,
COALESCE(TX_TB_specimem.value,0) AS TX_TB_specimem,
COALESCE(TX_TB_smear.value,0) AS TX_TB_smear,
COALESCE(TX_TB_xpert.value,0) AS TX_TB_xpert,
COALESCE(TX_TB_other.value,0) AS TX_TB_other,
COALESCE(TX_TB_pos_returned.value,0) AS TX_TB_pos_returned,
/*CXCA_TX*/
/*Auto Calculate*/
(
COALESCE(CXCA_TX_cryo_15_19.value,0) +
COALESCE(CXCA_TX_cryo_20_24.value,0) +
COALESCE(CXCA_TX_cryo_25_29.value,0) +
COALESCE(CXCA_TX_cryo_30_34.value,0) +
COALESCE(CXCA_TX_cryo_35_39.value,0) +
COALESCE(CXCA_TX_cryo_40_44.value,0) +
COALESCE(CXCA_TX_cryo_45_49.value,0) +
COALESCE(CXCA_TX_cryo_50.value,0) 
) AS CXCA_TX_num,
COALESCE(CXCA_TX_cryo_15_19.value,0) as CXCA_TX_cryo_15_19,
COALESCE(CXCA_TX_cryo_20_24.value,0) as CXCA_TX_cryo_20_24,
COALESCE(CXCA_TX_cryo_25_29.value,0) as CXCA_TX_cryo_25_29,
COALESCE(CXCA_TX_cryo_30_34.value,0) as CXCA_TX_cryo_30_34,
COALESCE(CXCA_TX_cryo_35_39.value,0) as CXCA_TX_cryo_35_39,
COALESCE(CXCA_TX_cryo_40_44.value,0) as CXCA_TX_cryo_40_44,
COALESCE(CXCA_TX_cryo_45_49.value,0) as CXCA_TX_cryo_45_49,
COALESCE(CXCA_TX_cryo_50.value,0) as CXCA_TX_cryo_50,
/*SC_ARVDISP*/
COALESCE(SCARVDISP_TLD_30.value,0) as SCARVDISP_TLD_30,
COALESCE(SCARVDISP_TLD_90.value,0) as SCARVDISP_TLD_90,
COALESCE(SCARVDISP_TLD_180.value,0) as SCARVDISP_TLD_180,
COALESCE(SCARVDISP_TLE_30.value,0) as SCARVDISP_TLE_30,
COALESCE(SCARVDISP_TLE_90.value,0) as SCARVDISP_TLE_90,
COALESCE(SCARVDISP_TLE_180.value,0) as SCARVDISP_TLE_180,
COALESCE(SCARVDISP_LPV_Ped.value,0) as SCARVDISP_LPV_Ped,
COALESCE(SCARVDISP_NVP_Adult.value,0) as SCARVDISP_NVP_Adult,
COALESCE(SCARVDISP_NVP_Ped.value,0) as SCARVDISP_NVP_Ped,
COALESCE(SCARVDISP_Other_Adult.value,0) as SCARVDISP_Other_Adult,
COALESCE(SCARVDISP_Other_Ped.value,0) as SCARVDISP_Other_Ped,
/*SC_CURR*/
COALESCE(SCCURR_TLD_30.value,0) as SCCURR_TLD_30,
COALESCE(SCCURR_TLD_90.value,0) as SCCURR_TLD_90,
COALESCE(SCCURR_TLD_180.value,0) as SCCURR_TLD_180,
COALESCE(SCCURR_TLE_30.value,0) as SCCURR_TLE_30,
COALESCE(SCCURR_TLE_90.value,0) as SCCURR_TLE_90,
COALESCE(SCCURR_TLE_180.value,0) as SCCURR_TLE_180,
COALESCE(SCCURR_LPV_Ped.value,0) as SCCURR_LPV_Ped,
COALESCE(SCCURR_NVP_Adult.value,0) as SCCURR_NVP_Adult,
COALESCE(SCCURR_NVP_Ped.value,0) as SCCURR_NVP_Ped,
COALESCE(SCCURR_Other_Adult.value,0) as SCCURR_Other_Adult,
COALESCE(SCCURR_Other_Ped.value,0) as SCCURR_Other_Ped,
/*SC_CURR*/
/*GEND_GBV*/
(
COALESCE(GEND_GBV_sexual_f_men10.value,0)+
COALESCE(GEND_GBV_sexual_f_10_14.value,0)+
COALESCE(GEND_GBV_sexual_f_15_19.value,0)+
COALESCE(GEND_GBV_sexual_f_20_24.value,0)+
COALESCE(GEND_GBV_sexual_f_25_29.value,0)+
COALESCE(GEND_GBV_sexual_f_30_34.value,0)+
COALESCE(GEND_GBV_sexual_f_35_39.value,0)+
COALESCE(GEND_GBV_sexual_f_40_44.value,0)+
COALESCE(GEND_GBV_sexual_f_45_49.value,0)+
COALESCE(GEND_GBV_sexual_f_50.value,0)   +
COALESCE(GEND_GBV_sexual_m_men10.value,0)+
COALESCE(GEND_GBV_sexual_m_10_14.value,0)+
COALESCE(GEND_GBV_sexual_m_15_19.value,0)+
COALESCE(GEND_GBV_sexual_m_20_24.value,0)+
COALESCE(GEND_GBV_sexual_m_25_29.value,0)+
COALESCE(GEND_GBV_sexual_m_30_34.value,0)+
COALESCE(GEND_GBV_sexual_m_35_39.value,0)+
COALESCE(GEND_GBV_sexual_m_40_44.value,0)+
COALESCE(GEND_GBV_sexual_m_45_49.value,0)+
COALESCE(GEND_GBV_sexual_m_50.value,0)   +
COALESCE(GEND_GBV_physical_f_men10.value,0)+
COALESCE(GEND_GBV_physical_f_10_14.value,0)+
COALESCE(GEND_GBV_physical_f_15_19.value,0)+
COALESCE(GEND_GBV_physical_f_20_24.value,0)+
COALESCE(GEND_GBV_physical_f_25_29.value,0)+
COALESCE(GEND_GBV_physical_f_30_34.value,0)+
COALESCE(GEND_GBV_physical_f_35_39.value,0)+
COALESCE(GEND_GBV_physical_f_40_44.value,0)+
COALESCE(GEND_GBV_physical_f_45_49.value,0)+
COALESCE(GEND_GBV_physical_f_50.value,0) +
COALESCE(GEND_GBV_physical_m_men10.value,0)+
COALESCE(GEND_GBV_physical_m_10_14.value,0)+
COALESCE(GEND_GBV_physical_m_15_19.value,0)+
COALESCE(GEND_GBV_physical_m_20_24.value,0)+
COALESCE(GEND_GBV_physical_m_25_29.value,0)+
COALESCE(GEND_GBV_physical_m_30_34.value,0)+
COALESCE(GEND_GBV_physical_m_35_39.value,0)+
COALESCE(GEND_GBV_physical_m_40_44.value,0)+
COALESCE(GEND_GBV_physical_m_45_49.value,0)+
COALESCE(GEND_GBV_physical_m_50.value,0)+
COALESCE(GEND_GBV_old_num.value,0)  
) as GEND_GBV_num,
(COALESCE(GEND_GBV_sexual_f_men10.value,0)+COALESCE(GEND_GBV_old_sexual_f_men10.value,0)) AS GEND_GBV_sexual_f_men10,
(COALESCE(GEND_GBV_sexual_f_10_14.value,0)+COALESCE(GEND_GBV_old_sexual_f_10_14.value,0)) AS GEND_GBV_sexual_f_10_14,
(COALESCE(GEND_GBV_sexual_f_15_19.value,0)+COALESCE(GEND_GBV_old_sexual_f_15_19.value,0)) AS GEND_GBV_sexual_f_15_19,
(COALESCE(GEND_GBV_sexual_f_20_24.value,0)+COALESCE(GEND_GBV_old_sexual_f_20_24.value,0)) AS GEND_GBV_sexual_f_20_24,
(COALESCE(GEND_GBV_sexual_f_25_29.value,0)+COALESCE(GEND_GBV_old_sexual_f_25_29.value,0)) AS GEND_GBV_sexual_f_25_29,
(COALESCE(GEND_GBV_sexual_f_30_34.value,0)+COALESCE(GEND_GBV_old_sexual_f_30_34.value,0)) AS GEND_GBV_sexual_f_30_34,
(COALESCE(GEND_GBV_sexual_f_35_39.value,0)+COALESCE(GEND_GBV_old_sexual_f_35_39.value,0)) AS GEND_GBV_sexual_f_35_39,
(COALESCE(GEND_GBV_sexual_f_40_44.value,0)+COALESCE(GEND_GBV_old_sexual_f_40_44.value,0)) AS GEND_GBV_sexual_f_40_44,
(COALESCE(GEND_GBV_sexual_f_45_49.value,0)+COALESCE(GEND_GBV_old_sexual_f_45_49.value,0)) AS GEND_GBV_sexual_f_45_49,
(COALESCE(GEND_GBV_sexual_f_50.value,0)+COALESCE(GEND_GBV_old_sexual_f_50.value,0)) AS GEND_GBV_sexual_f_50,
(COALESCE(GEND_GBV_sexual_m_men10.value,0)+COALESCE(GEND_GBV_old_sexual_m_men10.value,0)) AS GEND_GBV_sexual_m_men10,
(COALESCE(GEND_GBV_sexual_m_10_14.value,0)+COALESCE(GEND_GBV_old_sexual_m_10_14.value,0)) AS GEND_GBV_sexual_m_10_14,
(COALESCE(GEND_GBV_sexual_m_15_19.value,0)+COALESCE(GEND_GBV_old_sexual_m_15_19.value,0)) AS GEND_GBV_sexual_m_15_19,
(COALESCE(GEND_GBV_sexual_m_20_24.value,0)+COALESCE(GEND_GBV_old_sexual_m_20_24.value,0)) AS GEND_GBV_sexual_m_20_24,
(COALESCE(GEND_GBV_sexual_m_25_29.value,0)+COALESCE(GEND_GBV_old_sexual_m_25_29.value,0)) AS GEND_GBV_sexual_m_25_29,
(COALESCE(GEND_GBV_sexual_m_30_34.value,0)+COALESCE(GEND_GBV_old_sexual_m_30_34.value,0)) AS GEND_GBV_sexual_m_30_34,
(COALESCE(GEND_GBV_sexual_m_35_39.value,0)+COALESCE(GEND_GBV_old_sexual_m_35_39.value,0)) AS GEND_GBV_sexual_m_35_39,
(COALESCE(GEND_GBV_sexual_m_40_44.value,0)+COALESCE(GEND_GBV_old_sexual_m_40_44.value,0)) AS GEND_GBV_sexual_m_40_44,
(COALESCE(GEND_GBV_sexual_m_45_49.value,0)+COALESCE(GEND_GBV_old_sexual_m_45_49.value,0)) AS GEND_GBV_sexual_m_45_49,
(COALESCE(GEND_GBV_sexual_m_50.value,0)+COALESCE(GEND_GBV_old_sexual_m_50.value,0)) AS GEND_GBV_sexual_m_50,
(COALESCE(GEND_GBV_physical_f_men10.value,0)+COALESCE(GEND_GBV_old_physical_f_men10.value,0)) AS GEND_GBV_physical_f_men10,
(COALESCE(GEND_GBV_physical_f_10_14.value,0)+COALESCE(GEND_GBV_old_physical_f_10_14.value,0)) AS GEND_GBV_physical_f_10_14,
(COALESCE(GEND_GBV_physical_f_15_19.value,0)+COALESCE(GEND_GBV_old_physical_f_15_19.value,0)) AS GEND_GBV_physical_f_15_19,
(COALESCE(GEND_GBV_physical_f_20_24.value,0)+COALESCE(GEND_GBV_old_physical_f_20_24.value,0)) AS GEND_GBV_physical_f_20_24,
(COALESCE(GEND_GBV_physical_f_25_29.value,0)+COALESCE(GEND_GBV_old_physical_f_25_29.value,0)) AS GEND_GBV_physical_f_25_29,
(COALESCE(GEND_GBV_physical_f_30_34.value,0)+COALESCE(GEND_GBV_old_physical_f_30_34.value,0)) AS GEND_GBV_physical_f_30_34,
(COALESCE(GEND_GBV_physical_f_35_39.value,0)+COALESCE(GEND_GBV_old_physical_f_35_39.value,0)) AS GEND_GBV_physical_f_35_39,
(COALESCE(GEND_GBV_physical_f_40_44.value,0)+COALESCE(GEND_GBV_old_physical_f_40_44.value,0)) AS GEND_GBV_physical_f_40_44,
(COALESCE(GEND_GBV_physical_f_45_49.value,0)+COALESCE(GEND_GBV_old_physical_f_45_49.value,0)) AS GEND_GBV_physical_f_45_49,
(COALESCE(GEND_GBV_physical_f_50.value,0)+COALESCE(GEND_GBV_old_physical_f_50.value,0)) AS GEND_GBV_physical_f_50,
(COALESCE(GEND_GBV_physical_m_men10.value,0)+COALESCE(GEND_GBV_old_physical_m_men10.value,0)) AS GEND_GBV_physical_m_men10,
(COALESCE(GEND_GBV_physical_m_10_14.value,0)+COALESCE(GEND_GBV_old_physical_m_10_14.value,0)) AS GEND_GBV_physical_m_10_14,
(COALESCE(GEND_GBV_physical_m_15_19.value,0)+COALESCE(GEND_GBV_old_physical_m_15_19.value,0)) AS GEND_GBV_physical_m_15_19,
(COALESCE(GEND_GBV_physical_m_20_24.value,0)+COALESCE(GEND_GBV_old_physical_m_20_24.value,0)) AS GEND_GBV_physical_m_20_24,
(COALESCE(GEND_GBV_physical_m_25_29.value,0)+COALESCE(GEND_GBV_old_physical_m_25_29.value,0)) AS GEND_GBV_physical_m_25_29,
(COALESCE(GEND_GBV_physical_m_30_34.value,0)+COALESCE(GEND_GBV_old_physical_m_30_34.value,0)) AS GEND_GBV_physical_m_30_34,
(COALESCE(GEND_GBV_physical_m_35_39.value,0)+COALESCE(GEND_GBV_old_physical_m_35_39.value,0)) AS GEND_GBV_physical_m_35_39,
(COALESCE(GEND_GBV_physical_m_40_44.value,0)+COALESCE(GEND_GBV_old_physical_m_40_44.value,0)) AS GEND_GBV_physical_m_40_44,
(COALESCE(GEND_GBV_physical_m_45_49.value,0)+COALESCE(GEND_GBV_old_physical_m_45_49.value,0)) AS GEND_GBV_physical_m_45_49,
(COALESCE(GEND_GBV_physical_m_50.value,0)+COALESCE(GEND_GBV_old_physical_m_50.value,0)) AS GEND_GBV_physical_m_50,
(COALESCE(GEND_GBV_pep_f_men10.value,0)+COALESCE(GEND_GBV_old_pep_f_men10.value,0)) AS GEND_GBV_pep_f_men10,
(COALESCE(GEND_GBV_pep_f_10_14.value,0)+COALESCE(GEND_GBV_old_pep_f_10_14.value,0)) AS GEND_GBV_pep_f_10_14,
(COALESCE(GEND_GBV_pep_f_15_19.value,0)+COALESCE(GEND_GBV_old_pep_f_15_19.value,0)) AS GEND_GBV_pep_f_15_19,
(COALESCE(GEND_GBV_pep_f_20_24.value,0)+COALESCE(GEND_GBV_old_pep_f_20_24.value,0)) AS GEND_GBV_pep_f_20_24,
(COALESCE(GEND_GBV_pep_f_25_29.value,0)+COALESCE(GEND_GBV_old_pep_f_25_29.value,0)) AS GEND_GBV_pep_f_25_29,
(COALESCE(GEND_GBV_pep_f_30_34.value,0)+COALESCE(GEND_GBV_old_pep_f_30_34.value,0)) AS GEND_GBV_pep_f_30_34,
(COALESCE(GEND_GBV_pep_f_35_39.value,0)+COALESCE(GEND_GBV_old_pep_f_35_39.value,0)) AS GEND_GBV_pep_f_35_39,
(COALESCE(GEND_GBV_pep_f_40_44.value,0)+COALESCE(GEND_GBV_old_pep_f_40_44.value,0)) AS GEND_GBV_pep_f_40_44,
(COALESCE(GEND_GBV_pep_f_45_49.value,0)+COALESCE(GEND_GBV_old_pep_f_45_49.value,0)) AS GEND_GBV_pep_f_45_49,
(COALESCE(GEND_GBV_pep_f_50.value,0)+COALESCE(GEND_GBV_old_pep_f_50.value,0)) AS GEND_GBV_pep_f_50,
COALESCE(GEND_GBV_pep_m_men10.value,0) AS GEND_GBV_pep_m_men10,
COALESCE(GEND_GBV_pep_m_10_14.value,0) AS GEND_GBV_pep_m_10_14,
COALESCE(GEND_GBV_pep_m_15_19.value,0) AS GEND_GBV_pep_m_15_19,
COALESCE(GEND_GBV_pep_m_20_24.value,0) AS GEND_GBV_pep_m_20_24,
COALESCE(GEND_GBV_pep_m_25_29.value,0) AS GEND_GBV_pep_m_25_29,
COALESCE(GEND_GBV_pep_m_30_34.value,0) AS GEND_GBV_pep_m_30_34,
COALESCE(GEND_GBV_pep_m_35_39.value,0) AS GEND_GBV_pep_m_35_39,
COALESCE(GEND_GBV_pep_m_40_44.value,0) AS GEND_GBV_pep_m_40_44,
COALESCE(GEND_GBV_pep_m_45_49.value,0) AS GEND_GBV_pep_m_45_49,
COALESCE(GEND_GBV_pep_m_50.value,0)    AS GEND_GBV_pep_m_50,
----------------------------------------------------------------------------------------
--ANNUALY
----------------------------------------------------------------------------------------
/*FPINT_SITE*/
COALESCE(FPINT_SITE_hiv_testing.value,0) AS FPINT_SITE_hiv_testing,
COALESCE(FPINT_SITE_ct.value,0) AS FPINT_SITE_ct,
COALESCE(FPINT_SITE_anc.value,0) AS FPINT_SITE_anc,
COALESCE(FPINT_SITE_priority.value,0) AS FPINT_SITE_priority,
COALESCE(FPINT_SITE_key.value,0) AS FPINT_SITE_key,
/*PMTCT_FO*/
COALESCE(PMTCT_FO_den.value,0) AS PMTCT_FO_den,
/*Auto-Calculate*/
(
COALESCE(PMTCT_FO_hivinfected.value,0)+
COALESCE(PMTCT_FO_hivuninfected.value,0)+
COALESCE(PMTCT_FO_hivfsu.value,0)+
COALESCE(PMTCT_FO_died.value,0)
) AS PMTCT_FO_num,
COALESCE(PMTCT_FO_hivinfected.value,0) AS PMTCT_FO_hivinfected,
COALESCE(PMTCT_FO_hivuninfected.value,0) AS PMTCT_FO_hivuninfected,
COALESCE(PMTCT_FO_hivfsu.value,0) AS PMTCT_FO_hivfsu,
COALESCE(PMTCT_FO_died.value,0) AS PMTCT_FO_died,
/*HRH_CURR_Cadre*/
(
COALESCE(HRH_CURR_Cadre_clinical.value,0)+ 
COALESCE(HRH_CURR_Cadre_pharmacy.value,0)+ 
COALESCE(HRH_CURR_Cadre_laboratory.value,0)+
COALESCE(HRH_CURR_Cadre_management.value,0)+
COALESCE(HRH_CURR_Cadre_socialservices.value,0)+
COALESCE(HRH_CURR_Cadre_lay.value,0)+
COALESCE(HRH_CURR_Cadre_other.value,0)
) AS HRH_CURR_Cadre_num,
COALESCE(HRH_CURR_Cadre_clinical.value,0) AS HRH_CURR_Cadre_clinical,
COALESCE(HRH_CURR_Cadre_pharmacy.value,0) AS HRH_CURR_Cadre_pharmacy,
COALESCE(HRH_CURR_Cadre_laboratory.value,0) AS HRH_CURR_Cadre_laboratory,
COALESCE(HRH_CURR_Cadre_management.value,0) AS HRH_CURR_Cadre_management,
COALESCE(HRH_CURR_Cadre_socialservices.value,0) AS HRH_CURR_Cadre_socialservices,
COALESCE(HRH_CURR_Cadre_lay.value,0) AS HRH_CURR_Cadre_lay,
COALESCE(HRH_CURR_Cadre_other.value,0) AS HRH_CURR_Cadre_other,
/*HRH_CURR*/
COALESCE(HRH_CURR_clinical_ss.value,0) AS HRH_CURR_clinical_ss,
COALESCE(HRH_CURR_spent_clinical_ss.value,0) AS HRH_CURR_spent_clinical_ss,
COALESCE(HRH_CURR_clinical_srs.value,0) AS HRH_CURR_clinical_srs,
COALESCE(HRH_CURR_spent_clinical_srs.value,0) AS HRH_CURR_spent_clinical_srs,
COALESCE(HRH_CURR_clinical_srnms.value,0) AS HRH_CURR_clinical_srnms,
COALESCE(HRH_CURR_spent_clinical_srnms.value,0) AS HRH_CURR_spent_clinical_srnms,
COALESCE(HRH_CURR_pharmacy_ss.value,0) AS HRH_CURR_pharmacy_ss,
COALESCE(HRH_CURR_spent_pharmacy_ss.value,0) AS HRH_CURR_spent_pharmacy_ss,
COALESCE(HRH_CURR_pharmacy_srs.value,0) AS HRH_CURR_pharmacy_srs,
COALESCE(HRH_CURR_spent_pharmacy_srs.value,0) AS HRH_CURR_spent_pharmacy_srs,
COALESCE(HRH_CURR_pharmacy_srnms.value,0) AS HRH_CURR_pharmacy_srnms,
COALESCE(HRH_CURR_spent_pharmacy_srnms.value,0) AS HRH_CURR_spent_pharmacy_srnms,
COALESCE(HRH_CURR_laboratory_ss.value,0) AS HRH_CURR_laboratory_ss,
COALESCE(HRH_CURR_spent_laboratory_ss.value,0) AS HRH_CURR_spent_laboratory_ss,
COALESCE(HRH_CURR_laboratory_srs.value,0) AS HRH_CURR_laboratory_srs,
COALESCE(HRH_CURR_spent_laboratory_srs.value,0) AS HRH_CURR_spent_laboratory_srs,
COALESCE(HRH_CURR_laboratory_srnms.value,0) AS HRH_CURR_laboratory_srnms,
COALESCE(HRH_CURR_spent_laboratory_srnms.value,0) AS HRH_CURR_spent_laboratory_srnms,
COALESCE(HRH_CURR_management_ss.value,0) AS HRH_CURR_management_ss,
COALESCE(HRH_CURR_spent_management_ss.value,0) AS HRH_CURR_spent_management_ss,
COALESCE(HRH_CURR_management_srs.value,0) AS HRH_CURR_management_srs,
COALESCE(HRH_CURR_spent_management_srs.value,0) AS HRH_CURR_spent_management_srs,
COALESCE(HRH_CURR_management_srnms.value,0) AS HRH_CURR_management_srnms,
COALESCE(HRH_CURR_spent_management_srnms.value,0) AS HRH_CURR_spent_management_srnms,
COALESCE(HRH_CURR_socialservices_ss.value,0) AS HRH_CURR_socialservices_ss,
COALESCE(HRH_CURR_spent_socialservices_ss.value,0) AS HRH_CURR_spent_socialservices_ss,
COALESCE(HRH_CURR_socialservices_srs.value,0) AS HRH_CURR_socialservices_srs,
COALESCE(HRH_CURR_spent_socialservices_srs.value,0) AS HRH_CURR_spent_socialservices_srs,
COALESCE(HRH_CURR_socialservices_srnms.value,0) AS HRH_CURR_socialservices_srnms,
COALESCE(HRH_CURR_spent_socialservices_srnms.value,0) AS HRH_CURR_spent_socialservices_srnms,
COALESCE(HRH_CURR_lay_ss.value,0) AS HRH_CURR_lay_ss,
COALESCE(HRH_CURR_spent_lay_ss.value,0) AS HRH_CURR_spent_lay_ss,
COALESCE(HRH_CURR_lay_srs.value,0) AS HRH_CURR_lay_srs,
COALESCE(HRH_CURR_spent_lay_srs.value,0) AS HRH_CURR_spent_lay_srs,
COALESCE(HRH_CURR_lay_srnms.value,0) AS HRH_CURR_lay_srnms,
COALESCE(HRH_CURR_spent_lay_srnms.value,0) AS HRH_CURR_spent_lay_srnms,
COALESCE(HRH_CURR_other_ss.value,0) AS HRH_CURR_other_ss,
COALESCE(HRH_CURR_spent_other_ss.value,0) AS HRH_CURR_spent_other_ss,
COALESCE(HRH_CURR_other_srs.value,0) AS HRH_CURR_other_srs,
COALESCE(HRH_CURR_spent_other_srs.value,0) AS HRH_CURR_spent_other_srs,
COALESCE(HRH_CURR_other_srnms.value,0) AS HRH_CURR_other_srnms,
COALESCE(HRH_CURR_spent_other_srnms.value,0) AS HRH_CURR_spent_other_srnms,
/*EMR_SITE*/
EMR_SITE_hiv_testing.value AS EMR_SITE_hiv_testing,
EMR_SITE_ct.value AS EMR_SITE_ct,
EMR_SITE_anc.value AS EMR_SITE_anc,
EMR_SITE_infant.value AS EMR_SITE_infant,
EMR_SITE_hivtb.value AS EMR_SITE_hivtb,
/*LAB_PTCQI (Lab-based)*/
/*CQI*/
COALESCE(LAB_PTCQI_lab_cqi_hivtest_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_hivtest_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_hivtest_audited.value,0) AS LAB_PTCQI_lab_cqi_hivtest_audited,
COALESCE(LAB_PTCQI_lab_cqi_hivtest_accredited.value,0) AS LAB_PTCQI_lab_cqi_hivtest_accredited,
COALESCE(LAB_PTCQI_lab_cqi_hivtest_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_hivtest_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_hivivt_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_audited.value,0) AS LAB_PTCQI_lab_cqi_hivivt_audited,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_accredited.value,0) AS LAB_PTCQI_lab_cqi_hivivt_accredited,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_hivivt_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_load_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_load_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_load_audited.value,0) AS LAB_PTCQI_lab_cqi_load_audited,
COALESCE(LAB_PTCQI_lab_cqi_load_accredited.value,0) AS LAB_PTCQI_lab_cqi_load_accredited,
COALESCE(LAB_PTCQI_lab_cqi_load_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_load_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_audited.value,0) AS LAB_PTCQI_lab_cqi_tbxpert_audited,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_accredited.value,0) AS LAB_PTCQI_lab_cqi_tbxpert_accredited,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_tbafb_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_audited.value,0) AS LAB_PTCQI_lab_cqi_tbafb_audited,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_accredited.value,0) AS LAB_PTCQI_lab_cqi_tbafb_accredited,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_tbafb_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_tbculture_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_audited.value,0) AS LAB_PTCQI_lab_cqi_tbculture_audited,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_accredited.value,0) AS LAB_PTCQI_lab_cqi_tbculture_accredited,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_tbculture_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_cd4_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_cd4_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_cd4_audited.value,0) AS LAB_PTCQI_lab_cqi_cd4_audited,
COALESCE(LAB_PTCQI_lab_cqi_cd4_accredited.value,0) AS LAB_PTCQI_lab_cqi_cd4_accredited,
COALESCE(LAB_PTCQI_lab_cqi_cd4_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_cd4_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_other_noparticipation.value,0) AS LAB_PTCQI_lab_cqi_other_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_other_audited.value,0) AS LAB_PTCQI_lab_cqi_other_audited,
COALESCE(LAB_PTCQI_lab_cqi_other_accredited.value,0) AS LAB_PTCQI_lab_cqi_other_accredited,
COALESCE(LAB_PTCQI_lab_cqi_other_fullyaccredited.value,0) AS LAB_PTCQI_lab_cqi_other_fullyaccredited,
/*PT*/
COALESCE(LAB_PTCQI_lab_pt_hivtest_noparticipation.value,0) AS LAB_PTCQI_lab_pt_hivtest_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_hivtest_notpassed.value,0) AS LAB_PTCQI_lab_pt_hivtest_notpassed,
COALESCE(LAB_PTCQI_lab_pt_hivtest_passed.value,0) AS LAB_PTCQI_lab_pt_hivtest_passed,
COALESCE(LAB_PTCQI_lab_pt_hivivt_noparticipation.value,0) AS LAB_PTCQI_lab_pt_hivivt_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_hivivt_notpassed.value,0) AS LAB_PTCQI_lab_pt_hivivt_notpassed,
COALESCE(LAB_PTCQI_lab_pt_hivivt_passed.value,0) AS LAB_PTCQI_lab_pt_hivivt_passed,
COALESCE(LAB_PTCQI_lab_pt_load_noparticipation.value,0) AS LAB_PTCQI_lab_pt_load_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_load_notpassed.value,0) AS LAB_PTCQI_lab_pt_load_notpassed,
COALESCE(LAB_PTCQI_lab_pt_load_passed.value,0) AS LAB_PTCQI_lab_pt_load_passed,
COALESCE(LAB_PTCQI_lab_pt_tbxpert_noparticipation.value,0) AS LAB_PTCQI_lab_pt_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_tbxpert_notpassed.value,0) AS LAB_PTCQI_lab_pt_tbxpert_notpassed,
COALESCE(LAB_PTCQI_lab_pt_tbxpert_passed.value,0) AS LAB_PTCQI_lab_pt_tbxpert_passed,
COALESCE(LAB_PTCQI_lab_pt_tbafb_noparticipation.value,0) AS LAB_PTCQI_lab_pt_tbafb_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_tbafb_notpassed.value,0) AS LAB_PTCQI_lab_pt_tbafb_notpassed,
COALESCE(LAB_PTCQI_lab_pt_tbafb_passed.value,0) AS LAB_PTCQI_lab_pt_tbafb_passed,
COALESCE(LAB_PTCQI_lab_pt_tbculture_noparticipation.value,0) AS LAB_PTCQI_lab_pt_tbculture_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_tbculture_notpassed.value,0) AS LAB_PTCQI_lab_pt_tbculture_notpassed,
COALESCE(LAB_PTCQI_lab_pt_tbculture_passed.value,0) AS LAB_PTCQI_lab_pt_tbculture_passed,
COALESCE(LAB_PTCQI_lab_pt_cd4_noparticipation.value,0) AS LAB_PTCQI_lab_pt_cd4_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_cd4_notpassed.value,0) AS LAB_PTCQI_lab_pt_cd4_notpassed,
COALESCE(LAB_PTCQI_lab_pt_cd4_passed.value,0) AS LAB_PTCQI_lab_pt_cd4_passed,
COALESCE(LAB_PTCQI_lab_pt_other_noparticipation.value,0) AS LAB_PTCQI_lab_pt_other_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_other_notpassed.value,0) AS LAB_PTCQI_lab_pt_other_notpassed,
COALESCE(LAB_PTCQI_lab_pt_other_passed.value,0) AS LAB_PTCQI_lab_pt_other_passed,
/*Volume*/
COALESCE(LAB_PTCQI_lab_hivtest.value,0) AS LAB_PTCQI_lab_hivtest,
COALESCE(LAB_PTCQI_lab_hivivt.value,0) AS LAB_PTCQI_lab_hivivt,
COALESCE(LAB_PTCQI_lab_load.value,0) AS LAB_PTCQI_lab_load,
COALESCE(LAB_PTCQI_lab_tbxpert.value,0) AS LAB_PTCQI_lab_tbxpert,
COALESCE(LAB_PTCQI_lab_tbafb.value,0) AS LAB_PTCQI_lab_tbafb,
COALESCE(LAB_PTCQI_lab_tbculture.value,0) AS LAB_PTCQI_lab_tbculture,
COALESCE(LAB_PTCQI_lab_cd4.value,0) AS LAB_PTCQI_lab_cd4,
COALESCE(LAB_PTCQI_lab_other.value,0) AS LAB_PTCQI_lab_other,
/*LAB_PTCQI (POCT-based)*/
/*CQI*/
COALESCE(LAB_PTCQI_poct_cqi_hivtest_noparticipation.value,0) AS LAB_PTCQI_poct_cqi_hivtest_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_notaudited.value,0) AS LAB_PTCQI_poct_cqi_hivtest_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_01.value,0) AS LAB_PTCQI_poct_cqi_hivtest_01,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_23.value,0) AS LAB_PTCQI_poct_cqi_hivtest_23,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_45.value,0) AS LAB_PTCQI_poct_cqi_hivtest_45,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_noparticipation.value,0) AS LAB_PTCQI_poct_cqi_hivivt_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_notaudited.value,0) AS LAB_PTCQI_poct_cqi_hivivt_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_01.value,0) AS LAB_PTCQI_poct_cqi_hivivt_01,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_23.value,0) AS LAB_PTCQI_poct_cqi_hivivt_23,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_45.value,0) AS LAB_PTCQI_poct_cqi_hivivt_45,
COALESCE(LAB_PTCQI_poct_cqi_load_noparticipation.value,0) AS LAB_PTCQI_poct_cqi_load_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_load_notaudited.value,0) AS LAB_PTCQI_poct_cqi_load_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_load_01.value,0) AS LAB_PTCQI_poct_cqi_load_01,
COALESCE(LAB_PTCQI_poct_cqi_load_23.value,0) AS LAB_PTCQI_poct_cqi_load_23,
COALESCE(LAB_PTCQI_poct_cqi_load_45.value,0) AS LAB_PTCQI_poct_cqi_load_45,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_noparticipation.value,0) AS LAB_PTCQI_poct_cqi_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_notaudited.value,0) AS LAB_PTCQI_poct_cqi_tbxpert_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_01.value,0) AS LAB_PTCQI_poct_cqi_tbxpert_01,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_23.value,0) AS LAB_PTCQI_poct_cqi_tbxpert_23,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_45.value,0) AS LAB_PTCQI_poct_cqi_tbxpert_45,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_noparticipation.value,0) AS LAB_PTCQI_poct_cqi_tbafb_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_notaudited.value,0) AS LAB_PTCQI_poct_cqi_tbafb_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_01.value,0) AS LAB_PTCQI_poct_cqi_tbafb_01,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_23.value,0) AS LAB_PTCQI_poct_cqi_tbafb_23,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_45.value,0) AS LAB_PTCQI_poct_cqi_tbafb_45,
COALESCE(LAB_PTCQI_poct_cqi_cd4_noparticipation.value,0) AS LAB_PTCQI_poct_cqi_cd4_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_cd4_notaudited.value,0) AS LAB_PTCQI_poct_cqi_cd4_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_cd4_01.value,0) AS LAB_PTCQI_poct_cqi_cd4_01,
COALESCE(LAB_PTCQI_poct_cqi_cd4_23.value,0) AS LAB_PTCQI_poct_cqi_cd4_23,
COALESCE(LAB_PTCQI_poct_cqi_cd4_45.value,0) AS LAB_PTCQI_poct_cqi_cd4_45,
COALESCE(LAB_PTCQI_poct_cqi_other_noparticipation.value,0) AS LAB_PTCQI_poct_cqi_other_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_other_notaudited.value,0) AS LAB_PTCQI_poct_cqi_other_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_other_01.value,0) AS LAB_PTCQI_poct_cqi_other_01,
COALESCE(LAB_PTCQI_poct_cqi_other_23.value,0) AS LAB_PTCQI_poct_cqi_other_23,
COALESCE(LAB_PTCQI_poct_cqi_other_45.value,0) AS LAB_PTCQI_poct_cqi_other_45,
/*PT*/
COALESCE(LAB_PTCQI_poct_pt_hivtest_noparticipation.value,0) AS LAB_PTCQI_poct_pt_hivtest_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_hivtest_notpassed.value,0) AS LAB_PTCQI_poct_pt_hivtest_notpassed,
COALESCE(LAB_PTCQI_poct_pt_hivtest_passed.value,0) AS LAB_PTCQI_poct_pt_hivtest_passed,
COALESCE(LAB_PTCQI_poct_pt_hivivt_noparticipation.value,0) AS LAB_PTCQI_poct_pt_hivivt_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_hivivt_notpassed.value,0) AS LAB_PTCQI_poct_pt_hivivt_notpassed,
COALESCE(LAB_PTCQI_poct_pt_hivivt_passed.value,0) AS LAB_PTCQI_poct_pt_hivivt_passed,
COALESCE(LAB_PTCQI_poct_pt_load_noparticipation.value,0) AS LAB_PTCQI_poct_pt_load_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_load_notpassed.value,0) AS LAB_PTCQI_poct_pt_load_notpassed,
COALESCE(LAB_PTCQI_poct_pt_load_passed.value,0) AS LAB_PTCQI_poct_pt_load_passed,
COALESCE(LAB_PTCQI_poct_pt_tbxpert_noparticipation.value,0) AS LAB_PTCQI_poct_pt_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_tbxpert_notpassed.value,0) AS LAB_PTCQI_poct_pt_tbxpert_notpassed,
COALESCE(LAB_PTCQI_poct_pt_tbxpert_passed.value,0) AS LAB_PTCQI_poct_pt_tbxpert_passed,
COALESCE(LAB_PTCQI_poct_pt_tbafb_noparticipation.value,0) AS LAB_PTCQI_poct_pt_tbafb_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_tbafb_notpassed.value,0) AS LAB_PTCQI_poct_pt_tbafb_notpassed,
COALESCE(LAB_PTCQI_poct_pt_tbafb_passed.value,0) AS LAB_PTCQI_poct_pt_tbafb_passed,
COALESCE(LAB_PTCQI_poct_pt_cd4_noparticipation.value,0) AS LAB_PTCQI_poct_pt_cd4_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_cd4_notpassed.value,0) AS LAB_PTCQI_poct_pt_cd4_notpassed,
COALESCE(LAB_PTCQI_poct_pt_cd4_passed.value,0) AS LAB_PTCQI_poct_pt_cd4_passed,
COALESCE(LAB_PTCQI_poct_pt_other_noparticipation.value,0) AS LAB_PTCQI_poct_pt_other_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_other_notpassed.value,0) AS LAB_PTCQI_poct_pt_other_notpassed,
COALESCE(LAB_PTCQI_poct_pt_other_passed.value,0) AS LAB_PTCQI_poct_pt_other_passed,
/*Volume*/
COALESCE(LAB_PTCQI_poct_hivtest.value,0) AS LAB_PTCQI_poct_hivtest,
COALESCE(LAB_PTCQI_poct_hivivt.value,0) AS LAB_PTCQI_poct_hivivt,
COALESCE(LAB_PTCQI_poct_load.value,0) AS LAB_PTCQI_poct_load,
COALESCE(LAB_PTCQI_poct_tbxpert.value,0) AS LAB_PTCQI_poct_tbxpert,
COALESCE(LAB_PTCQI_poct_tbafb.value,0) AS LAB_PTCQI_poct_tbafb,
COALESCE(LAB_PTCQI_poct_cd4.value,0) AS LAB_PTCQI_poct_cd4,
COALESCE(LAB_PTCQI_poct_other.value,0) AS LAB_PTCQI_poct_other,
----------------------------------------------------------------------------------------
--ADITIONAL INFO
----------------------------------------------------------------------------------------
'' AS placeholder,
(ST_X(ou.geometry)||','||ST_Y(ou.geometry)) AS coordinates,
----------------------------------------------------------------------------------------
--NEW INDICATORS
----------------------------------------------------------------------------------------
COALESCE(PMTCT_STAT_10_14_recent_neg.value,0) AS PMTCT_STAT_10_14_recent_neg,
COALESCE(PMTCT_STAT_15_19_recent_neg.value,0) AS PMTCT_STAT_15_19_recent_neg,
COALESCE(PMTCT_STAT_20_24_recent_neg.value,0) AS PMTCT_STAT_20_24_recent_neg,
COALESCE(PMTCT_STAT_25_recent_neg.value,0) AS PMTCT_STAT_25_recent_neg,

/*NOT TO UPLOAD TO DATIM*/
/*TX_RTT PL_HIV*/
COALESCE(TX_RTT_PLHIV_total.value,0) AS TX_RTT_PLHIV_total,
COALESCE(TX_RTT_PLHIV_men12.value,0) AS TX_RTT_PLHIV_men12,
COALESCE(TX_RTT_PLHIV_mai12.value,0) AS TX_RTT_PLHIV_mai12,
COALESCE(TX_RTT_PLHIV_unk.value,0) AS TX_RTT_PLHIV_unk,
/*TRF_IN*/
COALESCE(TRF_IN_num.value,0) AS TRF_IN_num,
COALESCE(TRF_IN_men1_m.value,0) AS TRF_IN_men1_m,
COALESCE(TRF_IN_1_4_m.value,0) AS TRF_IN_1_4_m,
COALESCE(TRF_IN_5_9_m.value,0) AS TRF_IN_5_9_m,
COALESCE(TRF_IN_10_14_m.value,0) AS TRF_IN_10_14_m,
COALESCE(TRF_IN_15_19_m.value,0) AS TRF_IN_15_19_m,
COALESCE(TRF_IN_20_24_m.value,0) AS TRF_IN_20_24_m,
COALESCE(TRF_IN_25_29_m.value,0) AS TRF_IN_25_29_m,
COALESCE(TRF_IN_30_34_m.value,0) AS TRF_IN_30_34_m,
COALESCE(TRF_IN_35_39_m.value,0) AS TRF_IN_35_39_m,
COALESCE(TRF_IN_40_44_m.value,0) AS TRF_IN_40_44_m,
COALESCE(TRF_IN_45_49_m.value,0) AS TRF_IN_45_49_m,
COALESCE(TRF_IN_50_m.value,0) AS TRF_IN_50_m,
COALESCE(TRF_IN_men1_f.value,0) AS TRF_IN_men1_f,
COALESCE(TRF_IN_1_4_f.value,0) AS TRF_IN_1_4_f,
COALESCE(TRF_IN_5_9_f.value,0) AS TRF_IN_5_9_f,
COALESCE(TRF_IN_10_14_f.value,0) AS TRF_IN_10_14_f,
COALESCE(TRF_IN_15_19_f.value,0) AS TRF_IN_15_19_f,
COALESCE(TRF_IN_20_24_f.value,0) AS TRF_IN_20_24_f,
COALESCE(TRF_IN_25_29_f.value,0) AS TRF_IN_25_29_f,
COALESCE(TRF_IN_30_34_f.value,0) AS TRF_IN_30_34_f,
COALESCE(TRF_IN_35_39_f.value,0) AS TRF_IN_35_39_f,
COALESCE(TRF_IN_40_44_f.value,0) AS TRF_IN_40_44_f,
COALESCE(TRF_IN_45_49_f.value,0) AS TRF_IN_45_49_f,
COALESCE(TRF_IN_50_f.value,0) AS TRF_IN_50_f

FROM organisationunit ou
LEFT OUTER JOIN _orgunitstructure ous
 ON (ou.organisationunitid=ous.organisationunitid)
LEFT OUTER JOIN organisationunit province
 ON (ous.idlevel2=province.organisationunitid)
LEFT OUTER JOIN organisationunit district
 ON (ous.idlevel3=district.organisationunitid)
 
 /* 
 * Optional: HTS_TST Key Population
 * Source: 
 * ATS - População Chave
 */
 /*PWID*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967189
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PWID_pos ON HTS_TST_PWID_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967195
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PWID_neg ON HTS_TST_PWID_neg.sourceid=ou.organisationunitid
 
 /*MSM*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967185
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_MSM_pos ON HTS_TST_MSM_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967191
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_MSM_neg ON HTS_TST_MSM_neg.sourceid=ou.organisationunitid
 
 /*TG*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967187
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TG_pos ON HTS_TST_TG_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967193
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TG_neg ON HTS_TST_TG_neg.sourceid=ou.organisationunitid

 /*FSW*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967188
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_FSW_pos ON HTS_TST_FSW_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967194
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_FSW_neg ON HTS_TST_FSW_neg.sourceid=ou.organisationunitid
 
 /*Closed*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967186
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Closed_pos ON HTS_TST_Closed_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1968637
 AND categoryoptioncomboid=1967192
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Closed_neg ON HTS_TST_Closed_neg.sourceid=ou.organisationunitid
 
 /* 
 * HTS_TST (Facility)-PITC Inpatient Services*
 * Source: 
 * ATIP-Normal: Enfermarias (Aduto,Pediatria e Cirurgia)
 */
 /*0-8m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565920,565921,1471228,22524,1471144,22395)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_0_8_m_pos ON HTS_TST_Inpatient_0_8_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566109,566110,1471330,22593,1471246,22209)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_0_8_f_pos ON HTS_TST_Inpatient_0_8_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565941,565942,1471230,22194,1471146,22230)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_0_8_m_neg ON HTS_TST_Inpatient_0_8_m_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566130,566131,1471332,22197,1471248,22401)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_0_8_f_neg ON HTS_TST_Inpatient_0_8_f_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565983,565984,1471234)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_9_18_m_pos ON HTS_TST_Inpatient_9_18_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566172,566173,1471336)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_9_18_f_pos ON HTS_TST_Inpatient_9_18_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566004,566005,1471236)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_9_18_m_neg ON HTS_TST_Inpatient_9_18_m_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566193,566194,1471338)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_9_18_f_neg ON HTS_TST_Inpatient_9_18_f_neg.sourceid=ou.organisationunitid
 
 /*19m-4a*/
 /*1-4*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566046,566047,1471240,22375,1471150,22203)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_19_4_m_pos ON HTS_TST_Inpatient_19_4_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566235,566236,1471342,22503,1471252,22364)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_19_4_f_pos ON HTS_TST_Inpatient_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566067,566068,1471242,22655,1471152,22527)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_19_4_m_neg ON HTS_TST_Inpatient_19_4_m_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566256,566257,1471344,22169,1471254,22680)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_19_4_f_neg ON HTS_TST_Inpatient_19_4_f_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22400,22542,1471258)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_5_9_f_pos ON HTS_TST_Inpatient_5_9_f_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22299,22587,1471260)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_5_9_f_neg ON HTS_TST_Inpatient_5_9_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22425,22456,1471156)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_5_9_m_pos ON HTS_TST_Inpatient_5_9_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22199,22516,1471158)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_5_9_m_neg ON HTS_TST_Inpatient_5_9_m_neg.sourceid=ou.organisationunitid
 
/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22508,22615,1471264)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_10_14_f_pos ON HTS_TST_Inpatient_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22213,22306,1471266)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_10_14_f_neg ON HTS_TST_Inpatient_10_14_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22358,22689,1471162)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_10_14_m_pos ON HTS_TST_Inpatient_10_14_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22355,22513,1471164)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_10_14_m_neg ON HTS_TST_Inpatient_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22475,22491,1471270)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_15_19_f_pos ON HTS_TST_Inpatient_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22292,22311,1471272)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_15_19_f_neg ON HTS_TST_Inpatient_15_19_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22391,22406,1471168)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_15_19_m_pos ON HTS_TST_Inpatient_15_19_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22242,22440,1471170)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_15_19_m_neg ON HTS_TST_Inpatient_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22175,22300,1471276)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_20_24_f_pos ON HTS_TST_Inpatient_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22294,22336,1471278)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_20_24_f_neg ON HTS_TST_Inpatient_20_24_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22185,22247,1471174)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_20_24_m_pos ON HTS_TST_Inpatient_20_24_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22392,22499,1471176)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_20_24_m_neg ON HTS_TST_Inpatient_20_24_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562056,562057,1471294)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_25_29_f_pos ON HTS_TST_Inpatient_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562077,562078,1471296)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_25_29_f_neg ON HTS_TST_Inpatient_25_29_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561804,561805,1471192)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_25_29_m_pos ON HTS_TST_Inpatient_25_29_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561825,561826,1471194)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_25_29_m_neg ON HTS_TST_Inpatient_25_29_m_neg.sourceid=ou.organisationunitid

 /*30-49*/
 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565760,565761,1471324,562119,1471300,562120)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_30_49_f_pos ON HTS_TST_Inpatient_30_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565781,565782,1471326,562140,1471302,562141)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_30_49_f_neg ON HTS_TST_Inpatient_30_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565697,565698,1471222,561867,1471198,561868)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_30_49_m_pos ON HTS_TST_Inpatient_30_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565718,565719,1471224,561888,1471200,561889)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_30_49_m_neg ON HTS_TST_Inpatient_30_49_m_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562182,1471306,562183)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_35_39_f_pos ON HTS_TST_Inpatient_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562203,1471308,562204)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_35_39_f_neg ON HTS_TST_Inpatient_35_39_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561930,1471204,561931)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_35_39_m_pos ON HTS_TST_Inpatient_35_39_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561951,1471206,561952)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_35_39_m_neg ON HTS_TST_Inpatient_35_39_m_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480356,1480377,1480357)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_40_44_f_pos ON HTS_TST_Inpatient_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480379,1480400,1480380)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_40_44_f_neg ON HTS_TST_Inpatient_40_44_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480218,1480239,1480219)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_40_44_m_pos ON HTS_TST_Inpatient_40_44_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480241,1480262,1480242)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_40_44_m_neg ON HTS_TST_Inpatient_40_44_m_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480425,1480446,1480426)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_45_49_f_pos ON HTS_TST_Inpatient_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480448,1480469,1480449)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_45_49_f_neg ON HTS_TST_Inpatient_45_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480287,1480308,1480288)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_45_49_m_pos ON HTS_TST_Inpatient_45_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480310,1480331,1480311)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_45_49_m_neg ON HTS_TST_Inpatient_45_49_m_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22266,22673,1471288)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_50_f_pos ON HTS_TST_Inpatient_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22276,22438,1471290)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_50_f_neg ON HTS_TST_Inpatient_50_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22486,22639,1471186)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_50_m_pos ON HTS_TST_Inpatient_50_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22521,22525,1471188)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Inpatient_50_m_neg ON HTS_TST_Inpatient_50_m_neg.sourceid=ou.organisationunitid
 
/* 
 * HTS_TST (Facility)-PITC Pediatric Services
 * Source: 
 * ATIP-Normal: Triagem Pediatria e PAV ambas na faixa (1-4 anos)
 */
 /*19m-4a*/
 /*1-4*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566065,566055,22612,427184)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Pediatric_19_4_m_pos ON HTS_TST_Pediatric_19_4_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566254,566244,22464,427232)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Pediatric_19_4_f_pos ON HTS_TST_Pediatric_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566086,566076,22191,427186)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Pediatric_19_4_m_neg ON HTS_TST_Pediatric_19_4_m_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566275,566265,22317,427234)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Pediatric_19_4_f_neg ON HTS_TST_Pediatric_19_4_f_neg.sourceid=ou.organisationunitid

 /*
 * HTS_TST (Facility)-POST ANC
 * Source: 
 * ATIP-Normal: CPP (Feminino)
 * PTV-Maternidade: Primeira Testagem
 * 10-14 a 50+ anos
 */
 /*<1*/
 /*0-8m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566129,437605)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_0_8_f_pos ON HTS_TST_PMTCT_POST_0_8_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566150,437606)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_0_8_f_neg ON HTS_TST_PMTCT_POST_0_8_f_neg.sourceid=ou.organisationunitid


 /*9-18m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=566192
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_9_18_f_pos ON HTS_TST_PMTCT_POST_9_18_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=566213
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_9_18_f_neg ON HTS_TST_PMTCT_POST_9_18_f_neg.sourceid=ou.organisationunitid

 /*19-4a*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566255,437608)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_19_4_f_pos ON HTS_TST_PMTCT_POST_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566276,437609)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_19_4_f_neg ON HTS_TST_PMTCT_POST_19_4_f_neg.sourceid=ou.organisationunitid

 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437611
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_5_9_f_pos ON HTS_TST_PMTCT_POST_5_9_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437612
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_5_9_f_neg ON HTS_TST_PMTCT_POST_5_9_f_neg.sourceid=ou.organisationunitid

/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437615
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_10_14_f_pos ON HTS_TST_PMTCT_POST_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437616
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_10_14_f_neg ON HTS_TST_PMTCT_POST_10_14_f_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437618
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_15_19_f_pos ON HTS_TST_PMTCT_POST_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437619
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_15_19_f_neg ON HTS_TST_PMTCT_POST_15_19_f_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437621
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_20_24_f_pos ON HTS_TST_PMTCT_POST_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437622
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_20_24_f_neg ON HTS_TST_PMTCT_POST_20_24_f_neg.sourceid=ou.organisationunitid

 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=562076
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_25_29_f_pos ON HTS_TST_PMTCT_POST_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=562097
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_25_29_f_neg ON HTS_TST_PMTCT_POST_25_29_f_neg.sourceid=ou.organisationunitid

 /*30-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565780,562139)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_30_49_f_pos ON HTS_TST_PMTCT_POST_30_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(565801,562160)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_30_49_f_neg ON HTS_TST_PMTCT_POST_30_49_f_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=562202
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_35_39_f_pos ON HTS_TST_PMTCT_POST_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=562223
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_35_39_f_neg ON HTS_TST_PMTCT_POST_35_39_f_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=1480376
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_40_44_f_pos ON HTS_TST_PMTCT_POST_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=1480399
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_40_44_f_neg ON HTS_TST_PMTCT_POST_40_44_f_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=1480445
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_45_49_f_pos ON HTS_TST_PMTCT_POST_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=1480468
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_45_49_f_neg ON HTS_TST_PMTCT_POST_45_49_f_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437627
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_50_f_pos ON HTS_TST_PMTCT_POST_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=437628
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_POST_50_f_neg ON HTS_TST_PMTCT_POST_50_f_neg.sourceid=ou.organisationunitid

 /*Post ANC - PTV-CPN Repeat Test*/
/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62027
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_10_14_repeat_pos ON PMTCT_STAT_10_14_repeat_pos.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62038
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_15_19_repeat_pos ON PMTCT_STAT_15_19_repeat_pos.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62034
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_20_24_repeat_pos ON PMTCT_STAT_20_24_repeat_pos.sourceid=ou.organisationunitid
 
 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=563007
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_25_repeat_pos ON PMTCT_STAT_25_repeat_pos.sourceid=ou.organisationunitid
 
 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62003
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_10_14_repeat_neg ON PMTCT_STAT_10_14_repeat_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62014
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_15_19_repeat_neg ON PMTCT_STAT_15_19_repeat_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62015
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_20_24_repeat_neg ON PMTCT_STAT_20_24_repeat_neg.sourceid=ou.organisationunitid
 
 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=563008
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_25_repeat_neg ON PMTCT_STAT_25_repeat_neg.sourceid=ou.organisationunitid 
 
 /*Maternidade*/
 /*<1*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (61998,61994)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_men1_pos ON mat_men1_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (62017,62000)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_men1_neg ON mat_men1_neg.sourceid=ou.organisationunitid

 /*1-4*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=62039
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_1_4_pos ON mat_1_4_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=62030
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_1_4_neg ON mat_1_4_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=62031
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_5_9_pos ON mat_5_9_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=62026
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_5_9_neg ON mat_5_9_neg.sourceid=ou.organisationunitid

 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (61995,62027)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_10_14_pos ON mat_10_14_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (61999,62003)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_10_14_neg ON mat_10_14_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (62023,62038)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_15_19_pos ON mat_15_19_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (62010,62014)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_15_19_neg ON mat_15_19_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (62036,62034)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_20_24_pos ON mat_20_24_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (62004,62015)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_20_24_neg ON mat_20_24_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (561724,561736)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_25_29_pos ON mat_25_29_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (561728,561740)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_25_29_neg ON mat_25_29_neg.sourceid=ou.organisationunitid
 
 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (561725,561737)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_30_34_pos ON mat_30_34_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (561729,561741)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_30_34_neg ON mat_30_34_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (561726,561738)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_35_39_pos ON mat_35_39_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (561730,561742)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_35_39_neg ON mat_35_39_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=1480204
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_40_44_pos ON mat_40_44_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=1480206
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_40_44_neg ON mat_40_44_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=1480205
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_45_49_pos ON mat_45_49_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid=1480207
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_45_49_neg ON mat_45_49_neg.sourceid=ou.organisationunitid

 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (62013,62011)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_50_pos ON mat_50_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62041
 AND categoryoptioncomboid IN (62009,62006)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS mat_50_neg ON mat_50_neg.sourceid=ou.organisationunitid
 
/*
 * HTS_TST (Facility)-PITC Emergency Ward
 * Source: 
 * ATIP-Normal: Banco de Socorro
 * ATIP-Normal: Triagem / Banco de Socorro
 * ATIP-Normal: Triagem Adulto
 * ATIP-Normal: Triagem Pediatria excluindo de 1-4 anos Mapeado em HTS_TST PICT Pediatric
 */
 /*0-8m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(565937,565922,565938,565939,427177,427178,22454,338836,3019519)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_0_8_m_pos ON HTS_TST_Emergency_0_8_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566126,566111,566127,566128,427225,427226,22304,338884,3019576)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_0_8_f_pos ON HTS_TST_Emergency_0_8_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(565958,565943,565959,565960,427179,427180,22635,338838,3019520)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_0_8_m_neg ON HTS_TST_Emergency_0_8_m_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566147,566132,566148,566149,427227,427228,22584,338886,3019577)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_0_8_f_neg ON HTS_TST_Emergency_0_8_f_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566000,565985,566001,566002)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_9_18_m_pos ON HTS_TST_Emergency_9_18_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566189,566174,566190,566191)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_9_18_f_pos ON HTS_TST_Emergency_9_18_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566021,566006,566022,566023)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_9_18_m_neg ON HTS_TST_Emergency_9_18_m_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566210,566195,566211,566212)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_9_18_f_neg ON HTS_TST_Emergency_9_18_f_neg.sourceid=ou.organisationunitid
 
 /*19m-4a*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566063,566048,566064,338842,427183,22372,3019522)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_19_4_m_pos ON HTS_TST_Emergency_19_4_m_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566252,566237,566253,338890,427231,22246,3019579)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_19_4_f_pos ON HTS_TST_Emergency_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566084,566069,566085,338844,427185,22671,3019523)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_19_4_m_neg ON HTS_TST_Emergency_19_4_m_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(566273,566258,566274,338892,427233,22463,3019580)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_19_4_f_neg ON HTS_TST_Emergency_19_4_f_neg.sourceid=ou.organisationunitid

 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(22235,427237,427238,338896,3019582)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_5_9_f_pos ON HTS_TST_Emergency_5_9_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338898,22295,427239,427240,3019583)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_5_9_f_neg ON HTS_TST_Emergency_5_9_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(22512,338848,427189,427190,3019525)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_5_9_m_pos ON HTS_TST_Emergency_5_9_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338850,22333,427191,427192,3019526)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_5_9_m_neg ON HTS_TST_Emergency_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338902,22664,427243,427244,3019585)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_10_14_f_pos ON HTS_TST_Emergency_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338904,22202,427245,427246,3019586)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_10_14_f_neg ON HTS_TST_Emergency_10_14_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338854,22384,427195,427196,3019528)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_10_14_m_pos ON HTS_TST_Emergency_10_14_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338856,22337,427197,427198,3019529)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_10_14_m_neg ON HTS_TST_Emergency_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338908,22402,427249,427250,3019588)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_15_19_f_pos ON HTS_TST_Emergency_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338910,22495,427251,427252,3019589)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_15_19_f_neg ON HTS_TST_Emergency_15_19_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338860,22549,427201,427202,3019531)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_15_19_m_pos ON HTS_TST_Emergency_15_19_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338862,22648,427203,427204,3019532)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_15_19_m_neg ON HTS_TST_Emergency_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338914,22631,427255,427256,3019591)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_20_24_f_pos ON HTS_TST_Emergency_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338916,22537,427257,427258,3019592)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_20_24_f_neg ON HTS_TST_Emergency_20_24_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338866,22211,427207,427208,3019534)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_20_24_m_pos ON HTS_TST_Emergency_20_24_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN(338868,22231,427209,427210,3019535)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_20_24_m_neg ON HTS_TST_Emergency_20_24_m_neg.sourceid=ou.organisationunitid

 /*25-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=338920
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_49_f_pos ON HTS_TST_Emergency_25_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=338922
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_49_f_neg ON HTS_TST_Emergency_25_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=338872
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_49_m_pos ON HTS_TST_Emergency_25_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid=338874
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_49_m_neg ON HTS_TST_Emergency_25_49_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562073,562058,562074,562075,3019600)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_29_f_pos ON HTS_TST_Emergency_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562094,562079,562095,562096,3019601)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_29_f_neg ON HTS_TST_Emergency_25_29_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561821,561806,561822,561823,3019543)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_29_m_pos ON HTS_TST_Emergency_25_29_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561842,561827,561843,561844,3019544)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_25_29_m_neg ON HTS_TST_Emergency_25_29_m_neg.sourceid=ou.organisationunitid

 /*30-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565777,565762,565778,565779,562138,562136,562137,562121,3019603)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_30_49_f_pos ON HTS_TST_Emergency_30_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565798,565783,565799,565800,562157,562158,562142,562159,3019604)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_30_49_f_neg ON HTS_TST_Emergency_30_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565714,565699,565715,565716,561884,561886,561885,561869,3019546)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_30_49_m_pos ON HTS_TST_Emergency_30_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565735,565720,565736,565737,561905,561906,561890,561907,3019547)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_30_49_m_neg ON HTS_TST_Emergency_30_49_m_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562199,562200,562201,562184,3019606)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_35_39_f_pos ON HTS_TST_Emergency_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562220,562221,562222,562205,3019607)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_35_39_f_neg ON HTS_TST_Emergency_35_39_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561947,561948,561949,561932,3019549)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_35_39_m_pos ON HTS_TST_Emergency_35_39_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561968,561969,561970,561953,3019550)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_35_39_m_neg ON HTS_TST_Emergency_35_39_m_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480373,1480374,1480375,1480358,3019627)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_40_44_f_pos ON HTS_TST_Emergency_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480396,1480397,1480398,1480381,3019628)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_40_44_f_neg ON HTS_TST_Emergency_40_44_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480235,1480236,1480237,1480220,3019570)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_40_44_m_pos ON HTS_TST_Emergency_40_44_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480258,1480259,1480260,1480243,3019571)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_40_44_m_neg ON HTS_TST_Emergency_40_44_m_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480442,1480443,1480444,1480427,3019630)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_45_49_f_pos ON HTS_TST_Emergency_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480465,1480466,1480467,1480450,3019631)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_45_49_f_neg ON HTS_TST_Emergency_45_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480304,1480305,1480306,1480289,3019573)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_45_49_m_pos ON HTS_TST_Emergency_45_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480327,1480328,1480329,1480312,3019574)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_45_49_m_neg ON HTS_TST_Emergency_45_49_m_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (338926,22596,427267,427268,3019597)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_50_f_pos ON HTS_TST_Emergency_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (338928,22322,427269,427270,3019598)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_50_f_neg ON HTS_TST_Emergency_50_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (338878,22647,427219,427220,3019540)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_50_m_pos ON HTS_TST_Emergency_50_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (338880,22665,427221,427222,3019541)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Emergency_50_m_neg ON HTS_TST_Emergency_50_m_neg.sourceid=ou.organisationunitid 
 
/*
 * HTS_TST (Facility)- Other PICT
 * Source: 
 * Outros pontos de ATIP nao usado noutras modalidades,alguns casos especiais a nao esquecer:
 * CPP: Masculino e Feminino HTS_TST_PMTCT_POST somente de <1 a 5-9 anos 
 * PAV: excluir 1-4 anos
 */
 /*<1*/
 /*0-8m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22243,566113,230321,566124,230317,566120,230318,566121,1471247,1471331,22205,566112,230319,566122,22632,566117,22228,566114,230320,566123,22458,566119,22453,566118,22598,566115)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_0_8_f_pos ON HTS_TST_Other_0_8_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22690,566134,230328,566145,230324,566141,230325,566142,1471249,1471333,22558,566133,230326,566143,22548,566138,22623,566135,230327,566144,22502,566140,22669,566139,22426,566136)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_0_8_f_neg ON HTS_TST_Other_0_8_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22567,565924,230153,565935,230149,565931,230150,565932,1471145,1471229,22319,565923,230151,565933,437581,565940,22528,565928,22606,565925,230152,565934,22505,565930,22381,565929,22377,565926)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_0_8_m_pos ON HTS_TST_Other_0_8_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22180,565945,230160,565956,230156,565952,230157,565953,1471147,1471231,22268,565944,230158,565954,437582,565961,22552,565949,22204,565946,230159,565955,22492,565951,22273,565950,22663,565947)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_0_8_m_neg ON HTS_TST_Other_0_8_m_neg.sourceid=ou.organisationunitid

 /*9-18m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,1471337)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_9_18_f_pos ON HTS_TST_Other_9_18_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,1471339)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_9_18_f_neg ON HTS_TST_Other_9_18_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566003,1471235)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_9_18_m_pos ON HTS_TST_Other_9_18_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566024,1471237)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_9_18_m_neg ON HTS_TST_Other_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22562,230342,230338,230339,1471253,22483,230340,22675,22447,230341,22469,22350,566238,566239,566240,566241,566243,566245,566246,566247,566248,566249,566250,1471343)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_19_4_f_pos ON HTS_TST_Other_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22629,230349,230345,230346,1471255,22580,230347,22659,22271,230348,22334,22649,566259,566260,566261,566262,566264,566266,566267,566268,566269,566270,566271,1471345)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_19_4_f_neg ON HTS_TST_Other_19_4_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22260,230174,230170,230171,1471151,22565,230172,437584,22365,22595,230173,22510,22335,566049,566050,566051,566052,566054,566056,566057,566058,566059,566060,566061,566066,1471241)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_19_4_m_pos ON HTS_TST_Other_19_4_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22653,230181,230177,230178,1471153,22614,230179,437585,22473,22472,230180,22434,22685,566070,566071,566072,566073,566075,566077,566078,566079,566080,566081,566082,566087,1471243)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_19_4_m_neg ON HTS_TST_Other_19_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22256,22349,22405,22498,22509,22560,22597,230359,230360,230361,230362,230363,1471259)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_5_9_f_pos ON HTS_TST_Other_5_9_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22305,22331,22339,22515,22603,22622,22646,230366,230367,230368,230369,230370,1471261)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_5_9_f_neg ON HTS_TST_Other_5_9_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22207,22327,22404,22457,22517,22683,22692,230191,230192,230193,230194,230195,437587,1471157)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_5_9_m_pos ON HTS_TST_Other_5_9_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22170,22189,22346,22430,22478,22561,22576,230198,230199,230200,230201,230202,437588,1471159)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_5_9_m_neg ON HTS_TST_Other_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22187,22352,22466,22506,22582,22602,22641,230380,230381,230382,230383,230384,1471265)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_10_14_f_pos ON HTS_TST_Other_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22215,22241,22279,22420,22443,22488,22667,230387,230388,230389,230390,230391,1471267)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_10_14_f_neg ON HTS_TST_Other_10_14_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22206,22261,22263,22347,22414,22480,22518,230212,230213,230214,230215,230216,437590,1471163)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_10_14_m_pos ON HTS_TST_Other_10_14_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22240,22307,22416,22477,22496,22619,22668,230219,230220,230221,230222,230223,437591,1471165)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_10_14_m_neg ON HTS_TST_Other_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22173,22233,22254,22282,22301,22534,22620,230401,230402,230403,230404,230405,1471271)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_15_19_f_pos ON HTS_TST_Other_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22190,22277,22342,22397,22522,22572,22613,230408,230409,230410,230411,230412,1471273)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_15_19_f_neg ON HTS_TST_Other_15_19_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22320,22321,22460,22511,22577,22590,22660,230233,230234,230235,230236,230237,437593,1471169)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_15_19_m_pos ON HTS_TST_Other_15_19_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22177,22361,22385,22386,22413,22465,22686,230240,230241,230242,230243,230244,437594,1471171)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_15_19_m_neg ON HTS_TST_Other_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22208,22222,22314,22351,22367,22586,22588,230422,230423,230424,230425,230426,1471277)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_20_24_f_pos ON HTS_TST_Other_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22323,22393,22476,22541,22578,22592,22621,230429,230430,230431,230432,230433,1471279)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_20_24_f_neg ON HTS_TST_Other_20_24_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22250,22258,22275,22312,22338,22538,22691,230254,230255,230256,230257,230258,437596,1471175)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_20_24_m_pos ON HTS_TST_Other_20_24_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22265,22278,22309,22357,22394,22403,22415,230261,230262,230263,230264,230265,437597,1471177)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_20_24_m_neg ON HTS_TST_Other_20_24_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,1471295)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_25_29_f_pos ON HTS_TST_Other_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,1471297)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_25_29_f_neg ON HTS_TST_Other_25_29_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561824,1471193)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_25_29_m_pos ON HTS_TST_Other_25_29_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561845,1471195)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_25_29_m_neg ON HTS_TST_Other_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562123,562134,562130,562131,1471301,562122,562132,562127,562124,562133,562129,562128,562125,565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,1471325)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_30_49_f_pos ON HTS_TST_Other_30_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562144,562155,562151,562152,1471303,562143,562153,562148,562145,562154,562150,562149,562146,565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,1471327)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_30_49_f_neg ON HTS_TST_Other_30_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561871,561882,561878,561879,1471199,561870,561880,561887,561875,561872,561881,561877,561876,561873,565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565717,1471223)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_30_49_m_pos ON HTS_TST_Other_30_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561892,561903,561899,561900,1471201,561891,561901,561908,561896,561893,561902,561898,561897,561894,565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565738,1471225)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_30_49_m_neg ON HTS_TST_Other_30_49_m_neg.sourceid=ou.organisationunitid

 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562186,562197,562193,562194,1471307,562185,562195,562190,562187,562196,562192,562191,562188)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_35_39_f_pos ON HTS_TST_Other_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562207,562218,562214,562215,1471309,562206,562216,562211,562208,562217,562213,562212,562209)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_35_39_f_neg ON HTS_TST_Other_35_39_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561934,561945,561941,561942,1471205,561933,561943,561950,561938,561935,561944,561940,561939,561936)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_35_39_m_pos ON HTS_TST_Other_35_39_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561955,561966,561962,561963,1471207,561954,561964,561971,561959,561956,561965,561961,561960,561957)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_35_39_m_neg ON HTS_TST_Other_35_39_m_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480360,1480371,1480367,1480368,1480378,1480359,1480369,1480364,1480361,1480370,1480366,1480365,1480362)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_40_44_f_pos ON HTS_TST_Other_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480383,1480394,1480390,1480391,1480401,1480382,1480392,1480387,1480384,1480393,1480389,1480388,1480385)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_40_44_f_neg ON HTS_TST_Other_40_44_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480222,1480233,1480229,1480230,1480240,1480221,1480231,1480238,1480226,1480223,1480232,1480228,1480227,1480224)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_40_44_m_pos ON HTS_TST_Other_40_44_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480245,1480256,1480252,1480253,1480263,1480244,1480254,1480261,1480249,1480246,1480255,1480251,1480250,1480247)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_40_44_m_neg ON HTS_TST_Other_40_44_m_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480429,1480440,1480436,1480437,1480447,1480428,1480438,1480433,1480430,1480439,1480435,1480434,1480431)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_45_49_f_pos ON HTS_TST_Other_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480452,1480463,1480459,1480460,1480470,1480451,1480461,1480456,1480453,1480462,1480458,1480457,1480454)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_45_49_f_neg ON HTS_TST_Other_45_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480291,1480302,1480298,1480299,1480309,1480290,1480300,1480307,1480295,1480292,1480301,1480297,1480296,1480293)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_45_49_m_pos ON HTS_TST_Other_45_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480314,1480325,1480321,1480322,1480332,1480313,1480323,1480330,1480318,1480315,1480324,1480320,1480319,1480316)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_45_49_m_neg ON HTS_TST_Other_45_49_m_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22264,22313,22412,22482,22485,22514,22643,230464,230465,230466,230467,230468,1471289)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_50_f_pos ON HTS_TST_Other_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22244,22325,22343,22467,22500,22540,22543,230471,230472,230473,230474,230475,1471291)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_50_f_neg ON HTS_TST_Other_50_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22168,22238,22550,22570,22642,22656,22670,230296,230297,230298,230299,230300,437602,1471187)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_50_m_pos ON HTS_TST_Other_50_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22200,22212,22444,22481,22569,22600,22607,230303,230304,230305,230306,230307,437603,1471189)
 AND attributeoptioncomboid=230146
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_50_m_neg ON HTS_TST_Other_50_m_neg.sourceid=ou.organisationunitid
 
 /*
 * HTS_TST (Facility)-VCT
 * Source: 
 * ATS
 */
 /*0-8m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565851,21861)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_0_8_f_pos ON VCT_0_8_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565852,21862)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_0_8_f_neg ON VCT_0_8_f_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565842,21837)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_0_8_m_pos ON VCT_0_8_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565843,21838)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_0_8_m_neg ON VCT_0_8_m_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=565854
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_9_18_f_pos ON VCT_9_18_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=565855
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_9_18_f_neg ON VCT_9_18_f_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=565845
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_9_18_m_pos ON VCT_9_18_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=565846
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_9_18_m_neg ON VCT_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565857,21864)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_19_4_f_pos ON VCT_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565858,21865)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_19_4_f_neg ON VCT_19_4_f_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565848,21840)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_19_4_m_pos ON VCT_19_4_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565849,21841)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_19_4_m_neg ON VCT_19_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21867
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_5_9_f_pos ON VCT_5_9_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21868
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_5_9_f_neg ON VCT_5_9_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21843
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_5_9_m_pos ON VCT_5_9_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21844
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_5_9_m_neg ON VCT_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21870
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_10_14_f_pos ON VCT_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21871
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_10_14_f_neg ON VCT_10_14_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21846
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_10_14_m_pos ON VCT_10_14_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21847
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_10_14_m_neg ON VCT_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21873
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_15_19_f_pos ON VCT_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21874
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_15_19_f_neg ON VCT_15_19_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21849
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_15_19_m_pos ON VCT_15_19_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21850
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_15_19_m_neg ON VCT_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21876
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_20_24_f_pos ON VCT_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21877
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_20_24_f_neg ON VCT_20_24_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21852
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_20_24_m_pos ON VCT_20_24_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21853
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_20_24_m_neg ON VCT_20_24_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561792
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_25_29_f_pos ON VCT_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561793
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_25_29_f_neg ON VCT_25_29_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561780
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_25_29_m_pos ON VCT_25_29_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561781
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_25_29_m_neg ON VCT_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565693,561795)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_30_49_f_pos ON VCT_30_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565694,561796)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_30_49_f_neg ON VCT_30_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565690,561783)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_30_49_m_pos ON VCT_30_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid IN (565691,561784)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_30_49_m_neg ON VCT_30_49_m_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561798
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_35_39_f_pos ON VCT_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561799
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_35_39_f_neg ON VCT_35_39_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_35_39_m_pos ON VCT_35_39_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=561787
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_35_39_m_neg ON VCT_35_39_m_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480522
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_40_44_f_pos ON VCT_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480523
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_40_44_f_neg ON VCT_40_44_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480516
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_40_44_m_pos ON VCT_40_44_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480517
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_40_44_m_neg ON VCT_40_44_m_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480525
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_45_49_f_pos ON VCT_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480526
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_45_49_f_neg ON VCT_45_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480519
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_45_49_m_pos ON VCT_45_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=1480520
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_45_49_m_neg ON VCT_45_49_m_neg.sourceid=ou.organisationunitid

 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21882
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_50_f_pos ON VCT_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21883
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_50_f_neg ON VCT_50_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21858
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_50_m_pos ON VCT_50_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=21815
 AND categoryoptioncomboid=21859
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_50_m_neg ON VCT_50_m_neg.sourceid=ou.organisationunitid
 
/*
 * HTS_TST (Facility)-PITC-TB Clinics
 * Source: 
 * TB/HIV: Novos Testados
 */
/*<1*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62242
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_men1_f_pos ON HTS_TST_TB_men1_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62258
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_men1_f_neg ON HTS_TST_TB_men1_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62234
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_men1_m_pos ON HTS_TST_TB_men1_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62250
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_men1_m_neg ON HTS_TST_TB_men1_m_neg.sourceid=ou.organisationunitid
 
 /*1-4*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62243
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_1_4_f_pos ON HTS_TST_TB_1_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62259
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_1_4_f_neg ON HTS_TST_TB_1_4_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62235
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_1_4_m_pos ON HTS_TST_TB_1_4_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62251
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_1_4_m_neg ON HTS_TST_TB_1_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62244
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_5_9_f_pos ON HTS_TST_TB_5_9_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62260
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_5_9_f_neg ON HTS_TST_TB_5_9_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62236
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_5_9_m_pos ON HTS_TST_TB_5_9_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62252
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_5_9_m_neg ON HTS_TST_TB_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62245
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_10_14_f_pos ON HTS_TST_TB_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62261
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_10_14_f_neg ON HTS_TST_TB_10_14_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62237
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_10_14_m_pos ON HTS_TST_TB_10_14_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62253
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_10_14_m_neg ON HTS_TST_TB_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62246
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_15_19_f_pos ON HTS_TST_TB_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62262
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_15_19_f_neg ON HTS_TST_TB_15_19_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62238
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_15_19_m_pos ON HTS_TST_TB_15_19_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62254
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_15_19_m_neg ON HTS_TST_TB_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62247
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_20_24_f_pos ON HTS_TST_TB_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62263
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_20_24_f_neg ON HTS_TST_TB_20_24_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62239
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_20_24_m_pos ON HTS_TST_TB_20_24_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62255
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_20_24_m_neg ON HTS_TST_TB_20_24_m_neg.sourceid=ou.organisationunitid

 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561752
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_25_29_f_pos ON HTS_TST_TB_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561760
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_25_29_f_neg ON HTS_TST_TB_25_29_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561748
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_25_29_m_pos ON HTS_TST_TB_25_29_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561756
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_25_29_m_neg ON HTS_TST_TB_25_29_m_neg.sourceid=ou.organisationunitid

 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561753
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_30_34_f_pos ON HTS_TST_TB_30_34_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561761
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_30_34_f_neg ON HTS_TST_TB_30_34_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561749
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_30_34_m_pos ON HTS_TST_TB_30_34_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561757
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_30_34_m_neg ON HTS_TST_TB_30_34_m_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561754
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_35_39_f_pos ON HTS_TST_TB_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561762
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_35_39_f_neg ON HTS_TST_TB_35_39_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561750
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_35_39_m_pos ON HTS_TST_TB_35_39_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561758
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_35_39_m_neg ON HTS_TST_TB_35_39_m_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480502
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_40_44_f_pos ON HTS_TST_TB_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480506
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_40_44_f_neg ON HTS_TST_TB_40_44_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480500
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_40_44_m_pos ON HTS_TST_TB_40_44_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480504
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_40_44_m_neg ON HTS_TST_TB_40_44_m_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480503
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_45_49_f_pos ON HTS_TST_TB_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480507
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_45_49_f_neg ON HTS_TST_TB_45_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480501
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_45_49_m_pos ON HTS_TST_TB_45_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480505
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_45_49_m_neg ON HTS_TST_TB_45_49_m_neg.sourceid=ou.organisationunitid

 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62249
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_50_f_pos ON HTS_TST_TB_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62265
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_50_f_neg ON HTS_TST_TB_50_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62241
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_50_m_pos ON HTS_TST_TB_50_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62257
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_TB_50_m_neg ON HTS_TST_TB_50_m_neg.sourceid=ou.organisationunitid

 /*HTS_TST (Facility)-PITC PMTCT (ANC Only) Clinics*/
 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=61995
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_10_14_pos ON HTS_TST_PMTCT_10_14_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=61999
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_10_14_neg ON HTS_TST_PMTCT_10_14_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62023
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_15_19_pos ON HTS_TST_PMTCT_15_19_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62010
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_15_19_neg ON HTS_TST_PMTCT_15_19_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62036
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_20_24_pos ON HTS_TST_PMTCT_20_24_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=62004
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_20_24_neg ON HTS_TST_PMTCT_20_24_neg.sourceid=ou.organisationunitid

 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=563004
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_25_pos ON HTS_TST_PMTCT_25_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62040
 AND categoryoptioncomboid=563005
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_PMTCT_25_neg ON HTS_TST_PMTCT_25_neg.sourceid=ou.organisationunitid

 /*CPN Parceiros*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=6946
 AND categoryoptioncomboid=6924
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS cpn_m_pos ON cpn_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=6946
 AND categoryoptioncomboid=6925
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS cpn_m_neg ON cpn_m_neg.sourceid=ou.organisationunitid

 /*Index Testing*/
 /*Offered UATS/ATIP*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (255151,43326)
 AND attributeoptioncomboid IN (229786,184430)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS index_offered_unk ON index_offered_unk.sourceid=ou.organisationunitid
 
/*Contacts*/
/*CPN*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (1535896,1555061)
 AND categoryoptioncomboid=6924
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS cpn_index_contact_pos ON cpn_index_contact_pos.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (1535896,1555061)
 AND categoryoptioncomboid=6925
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS cpn_index_contact_neg ON cpn_index_contact_neg.sourceid=ou.organisationunitid
 
 /*
 * HTS_TST (Facility)- HTS_INDEX
 * Source: 
 * OpenMRS Quarterly HTS_INDEX
 * ATIP/UATS Caso Indice da US
 */
 
 /*HTS Index Offered*/
/*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538076
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_men1_f ON HTS_I_ofered_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538078
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_1_4_f ON HTS_I_ofered_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538080
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_5_9_f ON HTS_I_ofered_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444114
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_10_14_f ON HTS_I_ofered_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444116
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_15_19_f ON HTS_I_ofered_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444118
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_20_24_f ON HTS_I_ofered_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=603097
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_25_29_f ON HTS_I_ofered_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=603099
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_30_34_f ON HTS_I_ofered_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=603101
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_35_39_f ON HTS_I_ofered_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538082
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_40_44_f ON HTS_I_ofered_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538084
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_45_49_f ON HTS_I_ofered_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444117
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_50_f ON HTS_I_ofered_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538075
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_men1_m ON HTS_I_ofered_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538077
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_1_4_m ON HTS_I_ofered_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538079
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_5_9_m ON HTS_I_ofered_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444123
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_10_14_m ON HTS_I_ofered_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444119
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_15_19_m ON HTS_I_ofered_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444120
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_20_24_m ON HTS_I_ofered_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=603096
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_25_29_m ON HTS_I_ofered_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=603098
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_30_34_m ON HTS_I_ofered_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=603100
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_35_39_m ON HTS_I_ofered_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538081
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_40_44_m ON HTS_I_ofered_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=1538083
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_45_49_m ON HTS_I_ofered_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668025
 AND categoryoptioncomboid=444121
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_ofered_50_m ON HTS_I_ofered_50_m.sourceid=ou.organisationunitid
 
 /*HTS Index Accepted*/
/*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538076
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_men1_f ON HTS_I_acepted_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538078
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_1_4_f ON HTS_I_acepted_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538080
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_5_9_f ON HTS_I_acepted_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444114
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_10_14_f ON HTS_I_acepted_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444116
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_15_19_f ON HTS_I_acepted_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444118
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_20_24_f ON HTS_I_acepted_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=603097
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_25_29_f ON HTS_I_acepted_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=603099
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_30_34_f ON HTS_I_acepted_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=603101
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_35_39_f ON HTS_I_acepted_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538082
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_40_44_f ON HTS_I_acepted_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538084
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_45_49_f ON HTS_I_acepted_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444117
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_50_f ON HTS_I_acepted_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538075
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_men1_m ON HTS_I_acepted_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538077
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_1_4_m ON HTS_I_acepted_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538079
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_5_9_m ON HTS_I_acepted_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444123
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_10_14_m ON HTS_I_acepted_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444119
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_15_19_m ON HTS_I_acepted_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444120
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_20_24_m ON HTS_I_acepted_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=603096
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_25_29_m ON HTS_I_acepted_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=603098
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_30_34_m ON HTS_I_acepted_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=603100
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_35_39_m ON HTS_I_acepted_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538081
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_40_44_m ON HTS_I_acepted_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=1538083
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_45_49_m ON HTS_I_acepted_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1668026
 AND categoryoptioncomboid=444121
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HTS_I_acepted_50_m ON HTS_I_acepted_50_m.sourceid=ou.organisationunitid 
 
 /*Contacts*/
 /*0-8m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (338836,22567,230153,22524,1471144,22395,230149,230150,1471145,22319,230151,437581,22528,22606,230152,22505,22381,22377,427177,427178,22454,566129,566109,566110,566111,566112,566113,566114,566115,566117,566118,566119,566120,566121,566122,566123,566124,566126,566127,566128,1471330,1471331,3019576)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_0_8_f_pos ON HTS_TST_Other_index_0_8_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (427179,427180,22635,22180,230160,338838,230156,230157,1471147,22268,230158,437582,22552,22204,230159,22492,22273,22663,22194,1471146,22230,566130,566131,566132,566133,566134,566135,566136,566138,566139,566140,566141,566142,566143,566144,566145,566147,566148,566149,566150,1471332,1471333,3019577)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_0_8_f_neg ON HTS_TST_Other_index_0_8_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (338884,22243,230321,22593,1471246,22209,230317,230318,1471247,22205,230319,437605,22632,22228,230320,22458,22453,22598,427225,427226,22304,565920,565921,565922,565923,565924,565925,565926,565928,565929,565930,565931,565932,565933,565934,565935,565937,565938,565939,565940,1471228,1471229,3019519)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_0_8_m_pos ON HTS_TST_Other_index_0_8_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22690,230328,338886,230324,230325,1471249,22558,230326,437606,22548,22623,230327,22502,22669,22426,22197,1471248,22401,427227,427228,22584,565941,565942,565943,565944,565945,565946,565947,565949,565950,565951,565952,565953,565954,565955,565956,565958,565959,565960,565961,1471230,1471231,3019520)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_0_8_m_neg ON HTS_TST_Other_index_0_8_m_neg.sourceid=ou.organisationunitid

 /*9-18m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566172,566173,566174,566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,566189,566190,566191,566192,1471336,1471337)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_9_18_f_pos ON HTS_TST_Other_index_9_18_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566193,566194,566195,566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,566210,566211,566212,566213,1471338,1471339)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_9_18_f_neg ON HTS_TST_Other_index_9_18_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (565983,565984,565985,565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566000,566001,566002,566003,1471234,1471235)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_9_18_m_pos ON HTS_TST_Other_index_9_18_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (566004,566005,566006,566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566021,566022,566023,566024,1471236,1471237)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_9_18_m_neg ON HTS_TST_Other_index_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22260,230174,22375,1471150,22203,230170,230171,1471151,22565,230172,437584,22365,22595,230173,22510,22335,338842,22612,427184,427183,22372,566235,566236,566237,566238,566239,566240,566241,566243,566244,566245,566246,566247,566248,566249,566250,566252,566253,566254,566255,1471342,1471343,3019579)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_19_4_f_pos ON HTS_TST_Other_index_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (338844,427186,427185,22671,22191,22653,230181,230177,230178,1471153,22614,230179,437585,22473,22472,230180,22434,22685,22655,1471152,22527,566256,566257,566258,566259,566260,566261,566262,566264,566265,566266,566267,566268,566269,566270,566271,566273,566274,566275,566276,1471344,1471345,3019580)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_19_4_f_neg ON HTS_TST_Other_index_19_4_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22562,230342,230338,230339,1471253,22483,230340,437608,22675,22447,230341,22469,22350,22464,22503,1471252,22364,338890,427231,427232,22246,566046,566047,566048,566049,566050,566051,566052,566054,566055,566056,566057,566058,566059,566060,566061,566063,566064,566065,566066,1471240,1471241,3019522)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_19_4_m_pos ON HTS_TST_Other_index_19_4_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22629,230349,338892,427233,230345,230346,1471255,22580,230347,437609,22659,22271,230348,22334,22317,22649,22169,1471254,22680,427234,22463,566067,566068,566069,566070,566071,566072,566073,566075,566076,566077,566078,566079,566080,566081,566082,566084,566085,566086,566087,1471242,1471243,3019523)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_19_4_m_neg ON HTS_TST_Other_index_19_4_m_neg.sourceid=ou.organisationunitid

 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22235,22256,22349,22405,22498,22509,22560,427237,22597,427238,22400,230359,230360,230361,230362,230363,22542,437611,338896,1471258,1471259,3019582)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_5_9_f_pos ON HTS_TST_Other_index_5_9_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22299,22587,338898,22295,427239,427240,22305,22331,22339,22515,22603,22622,22646,230366,230367,230368,230369,230370,437612,1471260,1471261,3019583)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_5_9_f_neg ON HTS_TST_Other_index_5_9_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22207,22327,22404,22457,22425,22517,22456,22683,22692,230191,230192,230193,230194,230195,22512,437587,338848,427189,427190,1471156,1471157,3019525)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_5_9_m_pos ON HTS_TST_Other_index_5_9_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22199,22516,338850,22333,22170,22189,22346,22430,22478,22561,22576,230198,230199,230200,230201,230202,437588,427191,427192,1471158,1471159,3019526)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_5_9_m_neg ON HTS_TST_Other_index_5_9_m_neg.sourceid=ou.organisationunitid
 
/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22582,230384,22553,230380,230381,22187,230382,22615,22508,22466,22352,230383,22506,22602,22641,22664,338902,427243,427244,437615,1471264,1471265,3019585)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_10_14_f_pos ON HTS_TST_Other_index_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22279,230391,22658,230387,230388,22488,230389,22213,22306,22667,22215,230390,22443,22241,22420,22202,338904,427245,427246,437616,1471266,1471267,3019586)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_10_14_f_neg ON HTS_TST_Other_index_10_14_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22261,230216,22484,230212,230213,22263,230214,22358,22689,22480,22347,230215,22414,22206,22518,22384,338854,427195,427196,437590,1471162,1471163,3019528)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_10_14_m_pos ON HTS_TST_Other_index_10_14_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22307,230223,22672,230219,230220,22416,230221,22355,22513,22496,22477,230222,22619,22668,22240,22337,338856,427197,427198,437591,1471164,1471165,3019529)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_10_14_m_neg ON HTS_TST_Other_index_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22282,230405,22546,230401,230402,22534,230403,22491,22475,22233,22620,230404,22301,22254,22173,22402,338908,427249,427250,437618,1471270,1471271,3019588)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_15_19_f_pos ON HTS_TST_Other_index_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22397,230412,22328,230408,230409,22190,230410,22292,22311,22277,22342,230411,22522,22613,22572,22495,338910,427251,427252,437619,1471272,1471273,3019589)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_15_19_f_neg ON HTS_TST_Other_index_15_19_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22320,230237,22547,230233,230234,22660,230235,22406,22391,22460,22590,230236,22577,22511,22321,22549,338860,427201,427202,437593,1471168,1471169,3019531)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_15_19_m_pos ON HTS_TST_Other_index_15_19_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22413,230244,22526,230240,230241,22686,230242,22440,22242,22361,22386,230243,22465,22385,22177,22648,338862,427203,427204,437594,1471170,1471171,3019532)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_15_19_m_neg ON HTS_TST_Other_index_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22586,230426,22536,230422,230423,22222,230424,22175,22300,22208,22314,230425,22588,22367,22351,22631,338914,427255,427256,437621,1471276,1471277,3019591)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_20_24_f_pos ON HTS_TST_Other_index_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22393,230433,22218,230429,230430,22621,230431,22336,22294,22592,22578,230432,22541,22476,22323,22537,338916,427257,427258,437622,1471278,1471279,3019592)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_20_24_f_neg ON HTS_TST_Other_index_20_24_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22312,230258,22624,230254,230255,22258,230256,22247,22185,22691,22275,230257,22338,22250,22538,22211,338866,427207,427208,437596,1471174,1471175,3019534)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_20_24_m_pos ON HTS_TST_Other_index_20_24_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22357,230265,22345,230261,230262,22394,230263,22392,22499,22403,22415,230264,22265,22309,22278,22231,338868,427209,427210,437597,1471176,1471177,3019535)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_20_24_m_neg ON HTS_TST_Other_index_20_24_m_neg.sourceid=ou.organisationunitid

 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562056,562057,562058,562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,562073,562074,562075,562076,1471294,1471295,3019600)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_25_29_f_pos ON HTS_TST_Other_index_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562077,562078,562079,562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,562094,562095,562096,562097,1471296,1471297,3019601)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_25_29_f_neg ON HTS_TST_Other_index_25_29_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561804,561805,561806,561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561821,561822,561823,561824,1471192,1471193,3019543)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_25_29_m_pos ON HTS_TST_Other_index_25_29_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561825,561826,561827,561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561842,561843,561844,561845,1471194,1471195,3019544)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_25_29_m_neg ON HTS_TST_Other_index_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561871,561882,561867,1471198,561868,561878,561879,1471199,561870,561880,561887,561875,561872,561881,561877,561876,561873,561884,561886,561885,561869,565760,565761,565699,565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565714,565715,565716,565717,1471222,1471223,3019546)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_30_49_m_pos ON HTS_TST_Other_index_30_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561892,561903,561905,561906,561899,561900,1471201,561891,561901,561908,561896,561893,561902,561898,561897,561894,561888,1471200,561889,561890,561907,565781,565782,565720,565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565735,565736,565737,565738,1471224,1471225,3019547)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_30_49_m_neg ON HTS_TST_Other_index_30_49_m_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562123,562134,562119,1471300,562120,562130,562131,1471301,562122,562132,562139,562127,562124,562133,562129,562128,562125,562138,562136,562137,562121,565697,565698,565762,565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,565777,565778,565779,565780,1471324,1471325,3019603)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_30_49_f_pos ON HTS_TST_Other_index_30_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562144,562155,562157,562158,562151,562152,1471303,562143,562153,562160,562148,562145,562154,562150,562149,562146,562140,1471302,562141,562142,562159,565718,565719,565783,565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,565798,565799,565800,565801,1471326,1471327,3019604)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_30_49_f_neg ON HTS_TST_Other_index_30_49_f_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562186,562197,562182,1471306,562183,562193,562194,1471307,562185,562195,562202,562190,562187,562196,562192,562191,562188,562199,562200,562201,562184,3019606)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_35_39_f_pos ON HTS_TST_Other_index_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (562207,562218,562220,562221,562214,562215,1471309,562206,562216,562223,562211,562208,562217,562213,562212,562209,562203,1471308,562204,562222,562205,3019607)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_35_39_f_neg ON HTS_TST_Other_index_35_39_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561934,561945,561930,1471204,561931,561941,561942,1471205,561933,561943,561950,561938,561935,561944,561940,561939,561936,561947,561948,561949,561932,3019549)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_35_39_m_pos ON HTS_TST_Other_index_35_39_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (561955,561966,561968,561969,561962,561963,1471207,561954,561964,561971,561959,561956,561965,561961,561960,561957,561951,1471206,561952,561970,561953,3019550)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_35_39_m_neg ON HTS_TST_Other_index_35_39_m_neg.sourceid=ou.organisationunitid

 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480360,1480371,1480356,1480377,1480367,1480368,1480378,1480359,1480369,1480376,1480364,1480361,1480370,1480366,1480365,1480362,1480357,1480373,1480374,1480375,1480358,3019627)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_40_44_f_pos ON HTS_TST_Other_index_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480383,1480394,1480396,1480397,1480390,1480391,1480401,1480382,1480392,1480399,1480387,1480384,1480393,1480389,1480388,1480385,1480379,1480400,1480380,1480398,1480381,3019628)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_40_44_f_neg ON HTS_TST_Other_index_40_44_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480222,1480233,1480218,1480239,1480219,1480229,1480230,1480240,1480221,1480231,1480238,1480226,1480223,1480232,1480228,1480227,1480224,1480235,1480236,1480237,1480220,3019570)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_40_44_m_pos ON HTS_TST_Other_index_40_44_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480245,1480256,1480258,1480259,1480252,1480253,1480263,1480244,1480254,1480261,1480249,1480246,1480255,1480251,1480250,1480247,1480241,1480262,1480242,1480260,1480243,3019571)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_40_44_m_neg ON HTS_TST_Other_index_40_44_m_neg.sourceid=ou.organisationunitid

 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480429,1480440,1480425,1480446,1480436,1480437,1480447,1480428,1480438,1480445,1480433,1480430,1480439,1480435,1480434,1480431,1480442,1480443,1480426,1480444,1480427,3019630)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_45_49_f_pos ON HTS_TST_Other_index_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480452,1480463,1480465,1480466,1480459,1480460,1480470,1480451,1480461,1480468,1480456,1480453,1480462,1480458,1480457,1480454,1480448,1480469,1480449,1480467,1480450,3019631)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_45_49_f_neg ON HTS_TST_Other_index_45_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480291,1480302,1480287,1480308,1480288,1480298,1480299,1480309,1480290,1480300,1480307,1480295,1480292,1480301,1480297,1480296,1480293,1480304,1480305,1480306,1480289,3019573)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_45_49_m_pos ON HTS_TST_Other_index_45_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (1480314,1480327,1480328,1480325,1480321,1480322,1480332,1480313,1480323,1480330,1480318,1480315,1480324,1480320,1480319,1480316,1480310,1480331,1480311,1480329,1480312,3019574)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_45_49_m_neg ON HTS_TST_Other_index_45_49_m_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22313,230468,22201,230464,230465,22482,230466,22266,22673,22412,22485,230467,22264,22514,22643,22596,338926,427267,427268,437627,1471288,1471289,3019597)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_50_f_pos ON HTS_TST_Other_index_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22325,230475,22461,230471,230472,22540,230473,22276,22438,22543,22244,230474,22500,22343,22467,22322,338928,427269,427270,437628,1471290,1471291,3019598)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_50_f_neg ON HTS_TST_Other_index_50_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22168,230300,22370,230296,230297,22238,230298,22639,22486,22656,22570,230299,22642,22670,22550,22647,338878,427219,427220,437602,1471186,1471187,3019540)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_50_m_pos ON HTS_TST_Other_index_50_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=22693
 AND categoryoptioncomboid IN (22481,230307,22389,230303,230304,22444,230305,22525,22521,22200,22600,230306,22212,22607,22569,22665,338880,427221,427222,437603,1471188,1471189,3019541)
 AND attributeoptioncomboid=229786
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_TST_Other_index_50_m_neg ON HTS_TST_Other_index_50_m_neg.sourceid=ou.organisationunitid

 /*ATS Index*/
 /*0-8m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565851,21861)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_0_8_f_pos ON VCT_index_0_8_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565852,21862)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_0_8_f_neg ON VCT_index_0_8_f_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565842,21837)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_0_8_m_pos ON VCT_index_0_8_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565843,21838)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_0_8_m_neg ON VCT_index_0_8_m_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=565854
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_9_18_f_pos ON VCT_index_9_18_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=565855
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_9_18_f_neg ON VCT_index_9_18_f_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=565845
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_9_18_m_pos ON VCT_index_9_18_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=565846
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_9_18_m_neg ON VCT_index_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565857,21864)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_19_4_f_pos ON VCT_index_19_4_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565858,21865)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_19_4_f_neg ON VCT_index_19_4_f_neg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565848,21840)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_19_4_m_pos ON VCT_index_19_4_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565849,21841)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_19_4_m_neg ON VCT_index_19_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21867
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_5_9_f_pos ON VCT_index_5_9_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21868
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_5_9_f_neg ON VCT_index_5_9_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21843
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_5_9_m_pos ON VCT_index_5_9_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21844
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_5_9_m_neg ON VCT_index_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21870
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_10_14_f_pos ON VCT_index_10_14_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21871
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_10_14_f_neg ON VCT_index_10_14_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21846
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_10_14_m_pos ON VCT_index_10_14_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21847
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_10_14_m_neg ON VCT_index_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21873
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_15_19_f_pos ON VCT_index_15_19_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21874
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_15_19_f_neg ON VCT_index_15_19_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21849
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_15_19_m_pos ON VCT_index_15_19_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21850
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_15_19_m_neg ON VCT_index_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21876
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_20_24_f_pos ON VCT_index_20_24_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21877
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_20_24_f_neg ON VCT_index_20_24_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21852
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_20_24_m_pos ON VCT_index_20_24_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21853
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_20_24_m_neg ON VCT_index_20_24_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561792
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_25_29_f_pos ON VCT_index_25_29_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561793
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_25_29_f_neg ON VCT_index_25_29_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561780
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_25_29_m_pos ON VCT_index_25_29_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561781
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_25_29_m_neg ON VCT_index_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565693,561795)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_30_49_f_pos ON VCT_index_30_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565694,561796)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_30_49_f_neg ON VCT_index_30_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565690,561783)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_30_49_m_pos ON VCT_index_30_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid IN (565691,561784)
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_30_49_m_neg ON VCT_index_30_49_m_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561798
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_35_39_f_pos ON VCT_index_35_39_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561799
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_35_39_f_neg ON VCT_index_35_39_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561786
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_35_39_m_pos ON VCT_index_35_39_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=561787
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_35_39_m_neg ON VCT_index_35_39_m_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480522
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_40_44_f_pos ON VCT_index_40_44_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480523
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_40_44_f_neg ON VCT_index_40_44_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480516
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_40_44_m_pos ON VCT_index_40_44_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480517
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_40_44_m_neg ON VCT_index_40_44_m_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480525
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_45_49_f_pos ON VCT_index_45_49_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480526
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_45_49_f_neg ON VCT_index_45_49_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480519
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_45_49_m_pos ON VCT_index_45_49_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=1480520
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_45_49_m_neg ON VCT_index_45_49_m_neg.sourceid=ou.organisationunitid

 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21882
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_50_f_pos ON VCT_index_50_f_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21883
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_50_f_neg ON VCT_index_50_f_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21858
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_50_m_pos ON VCT_index_50_m_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=43327
 AND categoryoptioncomboid=21859
 AND attributeoptioncomboid=184430 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS VCT_index_50_m_neg ON VCT_index_50_m_neg.sourceid=ou.organisationunitid
 
 /*
 * PMTCT_STAT (Numerator)
 * Source: 
 * PTV-CPN
 */
 /*Age*/
 /*<10*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (199720,199729)
 AND categoryoptioncomboid IN (199706,199708)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_men10_num ON PMTCT_STAT_17q2_men10_num.sourceid=ou.organisationunitid

 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (199720,199729)
 AND categoryoptioncomboid=199705
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_10_14_num ON PMTCT_STAT_17q2_10_14_num.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (199720,199729)
 AND categoryoptioncomboid=199709
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_15_19_num ON PMTCT_STAT_17q2_15_19_num.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (199720,199729)
 AND categoryoptioncomboid=199703
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_20_24_num ON PMTCT_STAT_17q2_20_24_num.sourceid=ou.organisationunitid

 /*25-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (199720,199729)
 AND categoryoptioncomboid IN (199702,199707)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_25_49_num ON PMTCT_STAT_17q2_25_49_num.sourceid=ou.organisationunitid

 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (199720,199729)
 AND categoryoptioncomboid=562864
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_25_num ON PMTCT_STAT_17q2_25_num.sourceid=ou.organisationunitid
 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (199720,199729)
 AND categoryoptioncomboid=199704
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_50_num ON PMTCT_STAT_17q2_50_num.sourceid=ou.organisationunitid

 /*Known Positive*/
 /*<10*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199720
 AND categoryoptioncomboid IN (199706,199708)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_men10_known_pos ON PMTCT_STAT_17q2_men10_known_pos.sourceid=ou.organisationunitid

 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199720
 AND categoryoptioncomboid=199705
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_10_14_known_pos ON PMTCT_STAT_17q2_10_14_known_pos.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199720
 AND categoryoptioncomboid=199709
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_15_19_known_pos ON PMTCT_STAT_17q2_15_19_known_pos.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199720
 AND categoryoptioncomboid=199703
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_20_24_known_pos ON PMTCT_STAT_17q2_20_24_known_pos.sourceid=ou.organisationunitid

 /*25-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199720
 AND categoryoptioncomboid IN (199702,199707)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_25_49_known_pos ON PMTCT_STAT_17q2_25_49_known_pos.sourceid=ou.organisationunitid
 
 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199720
 AND categoryoptioncomboid=562864
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_25_known_pos ON PMTCT_STAT_17q2_25_known_pos.sourceid=ou.organisationunitid
 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199720
 AND categoryoptioncomboid=199704
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_50_known_pos ON PMTCT_STAT_17q2_50_known_pos.sourceid=ou.organisationunitid

 /*Unknown*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (6920)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q1_unk_known_pos ON PMTCT_STAT_17q1_unk_known_pos.sourceid=ou.organisationunitid
 
 /*RECENT NEGATIVES*/
 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=424037
 AND categoryoptioncomboid=199705
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_10_14_recent_neg ON PMTCT_STAT_10_14_recent_neg.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=424037
 AND categoryoptioncomboid=199709
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_15_19_recent_neg ON PMTCT_STAT_15_19_recent_neg.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=424037
 AND categoryoptioncomboid=199703
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_20_24_recent_neg ON PMTCT_STAT_20_24_recent_neg.sourceid=ou.organisationunitid
 
 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=424037
 AND categoryoptioncomboid=562864
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_25_recent_neg ON PMTCT_STAT_25_recent_neg.sourceid=ou.organisationunitid
 
 /*
 * PMTCT_STAT (Denominator)
 * Source: 
 * PTV-CPN
 */
 /*Age Unknown*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=6913
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q1_den ON PMTCT_STAT_17q1_den.sourceid=ou.organisationunitid

 /*Age*/
 /*<10*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199711
 AND categoryoptioncomboid IN (199706,199708)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_men10_den ON PMTCT_STAT_17q2_men10_den.sourceid=ou.organisationunitid

 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199711
 AND categoryoptioncomboid=199705
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_10_14_den ON PMTCT_STAT_17q2_10_14_den.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199711
 AND categoryoptioncomboid=199709
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_15_19_den ON PMTCT_STAT_17q2_15_19_den.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199711
 AND categoryoptioncomboid=199703
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_20_24_den ON PMTCT_STAT_17q2_20_24_den.sourceid=ou.organisationunitid

 /*25-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199711
 AND categoryoptioncomboid IN (199702,199707)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_25_49_den ON PMTCT_STAT_17q2_25_49_den.sourceid=ou.organisationunitid

 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199711
 AND categoryoptioncomboid=562864
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_25_den ON PMTCT_STAT_17q2_25_den.sourceid=ou.organisationunitid

 
 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199711
 AND categoryoptioncomboid=199704
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_STAT_17q2_50_den ON PMTCT_STAT_17q2_50_den.sourceid=ou.organisationunitid


 /*
 * PMTCT_EID
 * Source: 
 * PTV-CCR
 */
 /*Positive*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (7020,472971)
 AND categoryoptioncomboid=7011
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_0_2_pos ON PMTCT_EID_0_2_pos.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (23816,472972,648454)
 AND categoryoptioncomboid IN (23813,7011)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_2_12_pos_sum_prev ON PMTCT_EID_2_12_pos_sum_prev.sourceid=ou.organisationunitid

 /*Negative*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (7020,472971)
 AND categoryoptioncomboid=7014
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_0_2_neg ON PMTCT_EID_0_2_neg.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (23816,472972)
 AND categoryoptioncomboid=23812
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_2_12_neg ON PMTCT_EID_2_12_neg.sourceid=ou.organisationunitid

 /*Collected*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=7020
 AND categoryoptioncomboid=455205
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_0_2_col ON PMTCT_EID_0_2_col.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=23816
 AND categoryoptioncomboid=455204
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_2_12_col ON PMTCT_EID_2_12_col.sourceid=ou.organisationunitid
 
 /*ART*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=642133
 AND categoryoptioncomboid=6989
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_0_2_art ON PMTCT_EID_0_2_art.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=642133
 AND categoryoptioncomboid IN (6988,648456)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_2_12_art ON PMTCT_EID_2_12_art.sourceid=ou.organisationunitid
 
 
 /*PMTCT_EID_total*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (6990,1692808)
 AND categoryoptioncomboid IN (6989,155125,155126)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_0_2_total ON PMTCT_EID_0_2_total.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN(6990,1692809,1692810)
 AND categoryoptioncomboid IN(6988,1516819,155125,155126)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_EID_2_12_total ON PMTCT_EID_2_12_total.sourceid=ou.organisationunitid
 
 /*
 * TB_STAT (Numerator)
 * Source: 
 * TB/HIV
 */
/*Known Positive*/
/*<1*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62274
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_men1_f ON TB_STAT_kp_men1_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62266
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_men1_m ON TB_STAT_kp_men1_m.sourceid=ou.organisationunitid
 
 /*1-4*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62275
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_1_4_f ON TB_STAT_kp_1_4_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62267
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_1_4_m ON TB_STAT_kp_1_4_m.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62276
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_5_9_f ON TB_STAT_kp_5_9_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62268
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_5_9_m ON TB_STAT_kp_5_9_m.sourceid=ou.organisationunitid

 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62277
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_10_14_f ON TB_STAT_kp_10_14_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62269
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_10_14_m ON TB_STAT_kp_10_14_m.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62278
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_15_19_f ON TB_STAT_kp_15_19_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62270
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_15_19_m ON TB_STAT_kp_15_19_m.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62279
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_20_24_f ON TB_STAT_kp_20_24_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62271
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_20_24_m ON TB_STAT_kp_20_24_m.sourceid=ou.organisationunitid

 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561768
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_25_29_f ON TB_STAT_kp_25_29_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561764
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_25_29_m ON TB_STAT_kp_25_29_m.sourceid=ou.organisationunitid

 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561769
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_30_34_f ON TB_STAT_kp_30_34_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561765
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_30_34_m ON TB_STAT_kp_30_34_m.sourceid=ou.organisationunitid

 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561770
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_35_39_f ON TB_STAT_kp_35_39_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561766
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_35_39_m ON TB_STAT_kp_35_39_m.sourceid=ou.organisationunitid

 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480510
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_40_44_f ON TB_STAT_kp_40_44_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480508
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_40_44_m ON TB_STAT_kp_40_44_m.sourceid=ou.organisationunitid

 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480511
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_45_49_f ON TB_STAT_kp_45_49_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480509
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_45_49_m ON TB_STAT_kp_45_49_m.sourceid=ou.organisationunitid

 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62281
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_50_f ON TB_STAT_kp_50_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62273
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kp_50_m ON TB_STAT_kp_50_m.sourceid=ou.organisationunitid
 
 /*Known Negative*/
/*<1*/

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62290
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_men1_f ON TB_STAT_kn_men1_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62282
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_men1_m ON TB_STAT_kn_men1_m.sourceid=ou.organisationunitid
 
 
 /*1-4*/

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62291
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_1_4_f ON TB_STAT_kn_1_4_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62283
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_1_4_m ON TB_STAT_kn_1_4_m.sourceid=ou.organisationunitid

 /*5-9*/

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62292
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_5_9_f ON TB_STAT_kn_5_9_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62284
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_5_9_m ON TB_STAT_kn_5_9_m.sourceid=ou.organisationunitid

 /*10-14*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62293
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_10_14_f ON TB_STAT_kn_10_14_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62285
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_10_14_m ON TB_STAT_kn_10_14_m.sourceid=ou.organisationunitid

 /*15-19*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62294
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_15_19_f ON TB_STAT_kn_15_19_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62286
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_15_19_m ON TB_STAT_kn_15_19_m.sourceid=ou.organisationunitid

 /*20-24*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62295
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_20_24_f ON TB_STAT_kn_20_24_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62287
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_20_24_m ON TB_STAT_kn_20_24_m.sourceid=ou.organisationunitid

 /*25-29*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561776
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_25_29_f ON TB_STAT_kn_25_29_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561772
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_25_29_m ON TB_STAT_kn_25_29_m.sourceid=ou.organisationunitid

 /*30-34*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561777
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_30_34_f ON TB_STAT_kn_30_34_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561773
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_30_34_m ON TB_STAT_kn_30_34_m.sourceid=ou.organisationunitid

 /*35-39*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561778
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_35_39_f ON TB_STAT_kn_35_39_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=561774
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_35_39_m ON TB_STAT_kn_35_39_m.sourceid=ou.organisationunitid

 /*40-44*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480514
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_40_44_f ON TB_STAT_kn_40_44_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480512
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_40_44_m ON TB_STAT_kn_40_44_m.sourceid=ou.organisationunitid

 /*45-49*/
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480515
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_45_49_f ON TB_STAT_kn_45_49_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=1480513
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_45_49_m ON TB_STAT_kn_45_49_m.sourceid=ou.organisationunitid

 /*50+*/

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62297
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_50_f ON TB_STAT_kn_50_f.sourceid=ou.organisationunitid
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=62230
 AND categoryoptioncomboid=62289
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps, period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_kn_50_m ON TB_STAT_kn_50_m.sourceid=ou.organisationunitid
 

/*
 * TB_STAT (Denominator)
 * Source: 
 * TB/HIV
 */
 /*Denominator*/
/*<1*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562476
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_men1_f ON TB_STAT_den_men1_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562465
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_men1_m ON TB_STAT_den_men1_m.sourceid=ou.organisationunitid
 
 /*1-4*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562477
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_1_4_f ON TB_STAT_den_1_4_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562466
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_1_4_m ON TB_STAT_den_1_4_m.sourceid=ou.organisationunitid
 
 /*5-9*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562478
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_5_9_f ON TB_STAT_den_5_9_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562467
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_5_9_m ON TB_STAT_den_5_9_m.sourceid=ou.organisationunitid

 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562479
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_10_14_f ON TB_STAT_den_10_14_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562468
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_10_14_m ON TB_STAT_den_10_14_m.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562480
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_15_19_f ON TB_STAT_den_15_19_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562469
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_15_19_m ON TB_STAT_den_15_19_m.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562481
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_20_24_f ON TB_STAT_den_20_24_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562470
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_20_24_m ON TB_STAT_den_20_24_m.sourceid=ou.organisationunitid

 /*25-29*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562482
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_25_29_f ON TB_STAT_den_25_29_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562471
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_25_29_m ON TB_STAT_den_25_29_m.sourceid=ou.organisationunitid

 /*30-34*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562483
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_30_34_f ON TB_STAT_den_30_34_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562472
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_30_34_m ON TB_STAT_den_30_34_m.sourceid=ou.organisationunitid

 /*35-39*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562484
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_35_39_f ON TB_STAT_den_35_39_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562473
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_35_39_m ON TB_STAT_den_35_39_m.sourceid=ou.organisationunitid

 /*40-44*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=1480498
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_40_44_f ON TB_STAT_den_40_44_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=1480496
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_40_44_m ON TB_STAT_den_40_44_m.sourceid=ou.organisationunitid

 /*45-49*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=1480499
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_45_49_f ON TB_STAT_den_45_49_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=1480497
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_45_49_m ON TB_STAT_den_45_49_m.sourceid=ou.organisationunitid

 /*50+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562486
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_50_f ON TB_STAT_den_50_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=199614
 AND categoryoptioncomboid=562475
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_STAT_den_50_m ON TB_STAT_den_50_m.sourceid=ou.organisationunitid
 
/*
 * TX_NEW
 * Source: 
 * OpenMRS Quarterly
 */
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=443867
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_num ON TX_NEW_num.sourceid=ou.organisationunitid
 
 /*Preg_Breast*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=443945
 AND categoryoptioncomboid=443938
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_preg ON TX_NEW_preg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=443945
 AND categoryoptioncomboid=443937
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_breast ON TX_NEW_breast.sourceid=ou.organisationunitid
 
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538076
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_men1_f ON TX_NEW_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538078
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_1_4_f ON TX_NEW_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538080
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_5_9_f ON TX_NEW_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444114
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_10_14_f ON TX_NEW_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444116
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_15_19_f ON TX_NEW_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444118
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_20_24_f ON TX_NEW_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=603097
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_25_29_f ON TX_NEW_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=603099
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_30_34_f ON TX_NEW_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=603101
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_35_39_f ON TX_NEW_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538082
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_40_44_f ON TX_NEW_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538084
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_45_49_f ON TX_NEW_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444117
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_50_f ON TX_NEW_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538075
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_men1_m ON TX_NEW_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538077
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_1_4_m ON TX_NEW_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538079
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_5_9_m ON TX_NEW_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444123
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_10_14_m ON TX_NEW_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444119
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_15_19_m ON TX_NEW_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444120
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_20_24_m ON TX_NEW_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=603096
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_25_29_m ON TX_NEW_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=603098
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_30_34_m ON TX_NEW_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=603100
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_35_39_m ON TX_NEW_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538081
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_40_44_m ON TX_NEW_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=1538083
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_45_49_m ON TX_NEW_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444127
 AND categoryoptioncomboid=444121
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_50_m ON TX_NEW_50_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444416
 AND categoryoptioncomboid=444404
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_keypop_pwid ON TX_NEW_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444416
 AND categoryoptioncomboid=444403
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_keypop_msm ON TX_NEW_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444416
 AND categoryoptioncomboid=444405
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_keypop_tg ON TX_NEW_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444416
 AND categoryoptioncomboid=444402
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_keypop_fsw ON TX_NEW_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444416
 AND categoryoptioncomboid=444401
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_keypop_prison ON TX_NEW_keypop_prison.sourceid=ou.organisationunitid
 
 /*
 * TX_CURR
 * Source: 
 * OpenMRS Quarterly
 */
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444204
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_num ON TX_CURR_num.sourceid=ou.organisationunitid
 
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538076
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_men1_f ON TX_CURR_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538078
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_1_4_f ON TX_CURR_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538080
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_5_9_f ON TX_CURR_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444114
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_10_14_f ON TX_CURR_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444116
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_15_19_f ON TX_CURR_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444118
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_20_24_f ON TX_CURR_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=603097
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_25_29_f ON TX_CURR_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=603099
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_30_34_f ON TX_CURR_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=603101
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_35_39_f ON TX_CURR_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538082
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_40_44_f ON TX_CURR_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538084
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_45_49_f ON TX_CURR_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444117
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_50_f ON TX_CURR_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538075
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_men1_m ON TX_CURR_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538077
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_1_4_m ON TX_CURR_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538079
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_5_9_m ON TX_CURR_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444123
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_10_14_m ON TX_CURR_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444119
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_15_19_m ON TX_CURR_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444120
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_20_24_m ON TX_CURR_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=603096
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_25_29_m ON TX_CURR_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=603098
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_30_34_m ON TX_CURR_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=603100
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_35_39_m ON TX_CURR_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538081
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_40_44_m ON TX_CURR_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=1538083
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_45_49_m ON TX_CURR_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=444211
 AND categoryoptioncomboid=444121
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_50_m ON TX_CURR_50_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619446
 AND categoryoptioncomboid=444404
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_keypop_pwid ON TX_CURR_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619446
 AND categoryoptioncomboid=444403
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_keypop_msm ON TX_CURR_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619446
 AND categoryoptioncomboid=444405
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_keypop_tg ON TX_CURR_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619446
 AND categoryoptioncomboid=444402
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_keypop_fsw ON TX_CURR_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619446
 AND categoryoptioncomboid=444401
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_keypop_prison ON TX_CURR_keypop_prison.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619815
 AND categoryoptioncomboid=481511
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_men3_f_men15 ON TX_CURR_men3_f_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619815
 AND categoryoptioncomboid=481512
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_men3_f_mai15 ON TX_CURR_men3_f_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619815
 AND categoryoptioncomboid=481513
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_men3_m_men15 ON TX_CURR_men3_m_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619815
 AND categoryoptioncomboid=481510
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_men3_m_mai15 ON TX_CURR_men3_m_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619796
 AND categoryoptioncomboid=481511
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_3_5_f_men15 ON TX_CURR_3_5_f_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619796
 AND categoryoptioncomboid=481512
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_3_5_f_mai15 ON TX_CURR_3_5_f_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619796
 AND categoryoptioncomboid=481513
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_3_5_m_men15 ON TX_CURR_3_5_m_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619796
 AND categoryoptioncomboid=481510
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_3_5_m_mai15 ON TX_CURR_3_5_m_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619801
 AND categoryoptioncomboid=481511
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_mai6_f_men15 ON TX_CURR_mai6_f_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619801
 AND categoryoptioncomboid=481512
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_mai6_f_mai15 ON TX_CURR_mai6_f_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619801
 AND categoryoptioncomboid=481513
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_mai6_m_men15 ON TX_CURR_mai6_m_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2619801
 AND categoryoptioncomboid=481510
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_mai6_m_mai15 ON TX_CURR_mai6_m_mai15.sourceid=ou.organisationunitid
 
 /*TX_NEW TX_CURR Coarse*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515648
 AND categoryoptioncomboid=481511
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_coarse_f_men15 ON TX_NEW_coarse_f_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515648
 AND categoryoptioncomboid=481512
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_coarse_f_mai15 ON TX_NEW_coarse_f_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515648
 AND categoryoptioncomboid=481513
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_coarse_m_men15 ON TX_NEW_coarse_m_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515648
 AND categoryoptioncomboid=481510
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_NEW_coarse_m_mai15 ON TX_NEW_coarse_m_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515649
 AND categoryoptioncomboid=481511
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_coarse_f_men15 ON TX_CURR_coarse_f_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515649
 AND categoryoptioncomboid=481512
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_coarse_f_mai15 ON TX_CURR_coarse_f_mai15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515649
 AND categoryoptioncomboid=481513
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_coarse_m_men15 ON TX_CURR_coarse_m_men15.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=515649
 AND categoryoptioncomboid=481510
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_CURR_coarse_m_mai15 ON TX_CURR_coarse_m_mai15.sourceid=ou.organisationunitid
 
 /*
 * TX_RTT
 * Source: 
 * OpenMRS Quarterly
 */
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2627322
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_num ON TX_RTT_num.sourceid=ou.organisationunitid

 
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622399
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_men1_f ON TX_RTT_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622400
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_1_4_f ON TX_RTT_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622401
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_5_9_f ON TX_RTT_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622390
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_10_14_f ON TX_RTT_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622391
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_15_19_f ON TX_RTT_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622392
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_20_24_f ON TX_RTT_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622395
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_25_29_f ON TX_RTT_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622396
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_30_34_f ON TX_RTT_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622397
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_35_39_f ON TX_RTT_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622402
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_40_44_f ON TX_RTT_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622403
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_45_49_f ON TX_RTT_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622394
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_50_f ON TX_RTT_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622385
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_men1_m ON TX_RTT_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622386
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_1_4_m ON TX_RTT_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622387
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_5_9_m ON TX_RTT_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622376
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_10_14_m ON TX_RTT_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622377
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_15_19_m ON TX_RTT_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622378
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_20_24_m ON TX_RTT_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622381
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_25_29_m ON TX_RTT_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622382
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_30_34_m ON TX_RTT_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622383
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_35_39_m ON TX_RTT_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622388
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_40_44_m ON TX_RTT_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622389
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_45_49_m ON TX_RTT_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2622951
 AND categoryoptioncomboid=2622380
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_50_m ON TX_RTT_50_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2625144
 AND categoryoptioncomboid=2623042
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_keypop_pwid ON TX_RTT_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2625144
 AND categoryoptioncomboid=2623038
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_keypop_msm ON TX_RTT_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2625144
 AND categoryoptioncomboid=2623040
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_keypop_tg ON TX_RTT_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2625144
 AND categoryoptioncomboid=2623041
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_keypop_fsw ON TX_RTT_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2625144
 AND categoryoptioncomboid=2623039
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_keypop_prison ON TX_RTT_keypop_prison.sourceid=ou.organisationunitid
 
 /*
 * PMTCT_ART New
 * Source: 
 * PTV-CPN
 */
 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535785
 AND categoryoptioncomboid=199705
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_New_10_14 ON PMTCT_ART_New_10_14.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535785
 AND categoryoptioncomboid=199709
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_New_15_19 ON PMTCT_ART_New_15_19.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535785
 AND categoryoptioncomboid=199703
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_New_20_24 ON PMTCT_ART_New_20_24.sourceid=ou.organisationunitid

 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535785
 AND categoryoptioncomboid=562864
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_New_25 ON PMTCT_ART_New_25.sourceid=ou.organisationunitid

 /*
 * PMTCT_ART Already
 * Source: 
 * PTV-CPN
 */
 /*10-14*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535786
 AND categoryoptioncomboid=199705
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_Already_10_14 ON PMTCT_ART_Already_10_14.sourceid=ou.organisationunitid

 /*15-19*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535786
 AND categoryoptioncomboid=199709
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_Already_15_19 ON PMTCT_ART_Already_15_19.sourceid=ou.organisationunitid

 /*20-24*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535786
 AND categoryoptioncomboid=199703
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_Already_20_24 ON PMTCT_ART_Already_20_24.sourceid=ou.organisationunitid

 /*25+*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535786
 AND categoryoptioncomboid=562864
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_ART_Already_25 ON PMTCT_ART_Already_25.sourceid=ou.organisationunitid

/*
 * TB_ART (Numerator)
 * Source: 
 * TB/HIV
 */
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num ON TB_ART_num.sourceid=ou.organisationunitid

/*Female*/
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562476
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_men1_f ON TB_ART_num_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562477
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_1_4_f ON TB_ART_num_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562478
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_5_9_f ON TB_ART_num_5_9_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562479
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_10_14_f ON TB_ART_num_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562480
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_15_19_f ON TB_ART_num_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562481
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_20_24_f ON TB_ART_num_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562482
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_25_29_f ON TB_ART_num_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562483
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_30_34_f ON TB_ART_num_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562484
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_35_39_f ON TB_ART_num_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=1480498
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_40_44_f ON TB_ART_num_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=1480499
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_45_49_f ON TB_ART_num_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562486
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_50_f ON TB_ART_num_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562465
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_men1_m ON TB_ART_num_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562466
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_1_4_m ON TB_ART_num_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562467
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_5_9_m ON TB_ART_num_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562468
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_10_14_m ON TB_ART_num_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562469
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_15_19_m ON TB_ART_num_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562470
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_20_24_m ON TB_ART_num_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562471
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_25_29_m ON TB_ART_num_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562472
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_30_34_m ON TB_ART_num_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562473
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_35_39_m ON TB_ART_num_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=1480496
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_40_44_m ON TB_ART_num_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=1480497
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_45_49_m ON TB_ART_num_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=298004
 AND categoryoptioncomboid=562475
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_num_50_m ON TB_ART_num_50_m.sourceid=ou.organisationunitid
 
 /*Female*/
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562476
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_men1_f ON TB_ART_prev_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562477
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_1_4_f ON TB_ART_prev_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562478
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_5_9_f ON TB_ART_prev_5_9_f.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562479
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_10_14_f ON TB_ART_prev_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562480
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_15_19_f ON TB_ART_prev_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562481
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_20_24_f ON TB_ART_prev_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562482
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_25_29_f ON TB_ART_prev_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562483
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_30_34_f ON TB_ART_prev_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562484
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_35_39_f ON TB_ART_prev_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=1480498
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_40_44_f ON TB_ART_prev_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=1480499
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_45_49_f ON TB_ART_prev_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562486
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_50_f ON TB_ART_prev_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562465
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_men1_m ON TB_ART_prev_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562466
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_1_4_m ON TB_ART_prev_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562467
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_5_9_m ON TB_ART_prev_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562468
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_10_14_m ON TB_ART_prev_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562469
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_15_19_m ON TB_ART_prev_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562470
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_20_24_m ON TB_ART_prev_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562471
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_25_29_m ON TB_ART_prev_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562472
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_30_34_m ON TB_ART_prev_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562473
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_35_39_m ON TB_ART_prev_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=1480496
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_40_44_m ON TB_ART_prev_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=1480497
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_45_49_m ON TB_ART_prev_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1535163
 AND categoryoptioncomboid=562475
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS TB_ART_prev_50_m ON TB_ART_prev_50_m.sourceid=ou.organisationunitid
 
 /*
 * TX_PVLS
 * Source: 
 * OpenMRS Quarterly
 */
 /*Routine*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484186
 AND categoryoptioncomboid=484024
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_preg ON TX_PVLS_num_rou_preg.sourceid=ou.organisationunitid
 
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484186
 AND categoryoptioncomboid=484023
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_breast ON TX_PVLS_num_rou_breast.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538088
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_men1 ON TX_PVLS_num_rou_f_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538094
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_1_4 ON TX_PVLS_num_rou_f_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538100
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_5_9 ON TX_PVLS_num_rou_f_5_9.sourceid=ou.organisationunitid
 
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484042
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_10_14 ON TX_PVLS_num_rou_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484039
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_15_19 ON TX_PVLS_num_rou_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484038
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_20_24 ON TX_PVLS_num_rou_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603107
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_25_29 ON TX_PVLS_num_rou_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603113
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_30_34 ON TX_PVLS_num_rou_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603119
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_35_39 ON TX_PVLS_num_rou_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538106
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_40_44 ON TX_PVLS_num_rou_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538112
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_45_49 ON TX_PVLS_num_rou_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484057
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_f_50 ON TX_PVLS_num_rou_f_50.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538085
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_men1 ON TX_PVLS_num_rou_m_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538091
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_1_4 ON TX_PVLS_num_rou_m_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538097
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_5_9 ON TX_PVLS_num_rou_m_5_9.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484055
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_10_14 ON TX_PVLS_num_rou_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484041
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_15_19 ON TX_PVLS_num_rou_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484061
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_20_24 ON TX_PVLS_num_rou_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603104
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_25_29 ON TX_PVLS_num_rou_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603110
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_30_34 ON TX_PVLS_num_rou_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603116
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_35_39 ON TX_PVLS_num_rou_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538103
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_40_44 ON TX_PVLS_num_rou_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538109
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_45_49 ON TX_PVLS_num_rou_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484065
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_rou_m_50 ON TX_PVLS_num_rou_m_50.sourceid=ou.organisationunitid
 
 /*Undocumented*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484186
 AND categoryoptioncomboid=484027
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_preg ON TX_PVLS_num_und_preg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484186
 AND categoryoptioncomboid=484025
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_breast ON TX_PVLS_num_und_breast.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538090
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_men1 ON TX_PVLS_num_und_f_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538096
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_1_4 ON TX_PVLS_num_und_f_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538102
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_5_9 ON TX_PVLS_num_und_f_5_9.sourceid=ou.organisationunitid
 
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484054
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_10_14 ON TX_PVLS_num_und_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484040
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_15_19 ON TX_PVLS_num_und_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484036
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_20_24 ON TX_PVLS_num_und_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603109
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_25_29 ON TX_PVLS_num_und_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603115
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_30_34 ON TX_PVLS_num_und_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603121
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_35_39 ON TX_PVLS_num_und_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538108
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_40_44 ON TX_PVLS_num_und_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538114
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_45_49 ON TX_PVLS_num_und_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484064
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_f_50 ON TX_PVLS_num_und_f_50.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538087
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_men1 ON TX_PVLS_num_und_m_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538093
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_1_4 ON TX_PVLS_num_und_m_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538099
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_5_9 ON TX_PVLS_num_und_m_5_9.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484052
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_10_14 ON TX_PVLS_num_und_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484047
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_15_19 ON TX_PVLS_num_und_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484037
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_20_24 ON TX_PVLS_num_und_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603106
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_25_29 ON TX_PVLS_num_und_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603112
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_30_34 ON TX_PVLS_num_und_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=603118
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_35_39 ON TX_PVLS_num_und_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538105
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_40_44 ON TX_PVLS_num_und_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=1538111
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_45_49 ON TX_PVLS_num_und_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484188
 AND categoryoptioncomboid=484046
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_num_und_m_50 ON TX_PVLS_num_und_m_50.sourceid=ou.organisationunitid
 
 /*Denominator*/
 /*Routine*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484191
 AND categoryoptioncomboid=484024
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_preg ON TX_PVLS_den_rou_preg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484191
 AND categoryoptioncomboid=484023
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_breast ON TX_PVLS_den_rou_breast.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538088
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_men1 ON TX_PVLS_den_rou_f_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538094
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_1_4 ON TX_PVLS_den_rou_f_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538100
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_5_9 ON TX_PVLS_den_rou_f_5_9.sourceid=ou.organisationunitid
 
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484042
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_10_14 ON TX_PVLS_den_rou_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484039
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_15_19 ON TX_PVLS_den_rou_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484038
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_20_24 ON TX_PVLS_den_rou_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603107
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_25_29 ON TX_PVLS_den_rou_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603113
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_30_34 ON TX_PVLS_den_rou_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603119
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_35_39 ON TX_PVLS_den_rou_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538106
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_40_44 ON TX_PVLS_den_rou_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538112
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_45_49 ON TX_PVLS_den_rou_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484057
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_f_50 ON TX_PVLS_den_rou_f_50.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538085
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_men1 ON TX_PVLS_den_rou_m_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538091
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_1_4 ON TX_PVLS_den_rou_m_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538097
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_5_9 ON TX_PVLS_den_rou_m_5_9.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484055
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_10_14 ON TX_PVLS_den_rou_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484041
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_15_19 ON TX_PVLS_den_rou_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484061
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_20_24 ON TX_PVLS_den_rou_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603104
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_25_29 ON TX_PVLS_den_rou_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603110
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_30_34 ON TX_PVLS_den_rou_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603116
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_35_39 ON TX_PVLS_den_rou_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538103
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_40_44 ON TX_PVLS_den_rou_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538109
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_45_49 ON TX_PVLS_den_rou_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484065
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_rou_m_50 ON TX_PVLS_den_rou_m_50.sourceid=ou.organisationunitid
 
 /*Undocumented*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484191
 AND categoryoptioncomboid=484027
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_preg ON TX_PVLS_den_und_preg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484191
 AND categoryoptioncomboid=484025
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_breast ON TX_PVLS_den_und_breast.sourceid=ou.organisationunitid 
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538090
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_men1 ON TX_PVLS_den_und_f_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538096
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_1_4 ON TX_PVLS_den_und_f_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538102
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_5_9 ON TX_PVLS_den_und_f_5_9.sourceid=ou.organisationunitid
 
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484054
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_10_14 ON TX_PVLS_den_und_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484040
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_15_19 ON TX_PVLS_den_und_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484036
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_20_24 ON TX_PVLS_den_und_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603109
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_25_29 ON TX_PVLS_den_und_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603115
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_30_34 ON TX_PVLS_den_und_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603121
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_35_39 ON TX_PVLS_den_und_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538108
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_40_44 ON TX_PVLS_den_und_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538114
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_45_49 ON TX_PVLS_den_und_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484064
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_f_50 ON TX_PVLS_den_und_f_50.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538087
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_men1 ON TX_PVLS_den_und_m_men1.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538093
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_1_4 ON TX_PVLS_den_und_m_1_4.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538099
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_5_9 ON TX_PVLS_den_und_m_5_9.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484052
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_10_14 ON TX_PVLS_den_und_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484047
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_15_19 ON TX_PVLS_den_und_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484037
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_20_24 ON TX_PVLS_den_und_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603106
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_25_29 ON TX_PVLS_den_und_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603112
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_30_34 ON TX_PVLS_den_und_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=603118
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_35_39 ON TX_PVLS_den_und_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538105
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_40_44 ON TX_PVLS_den_und_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=1538111
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_45_49 ON TX_PVLS_den_und_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=484189
 AND categoryoptioncomboid=484046
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_den_und_m_50 ON TX_PVLS_den_und_m_50.sourceid=ou.organisationunitid
 
 /*
 * HTS_SELF
 * ATS - Confirmacao de Autoteste
 */
 /*Assisted*/
 /*Female*/ 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969089
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_10_14_f ON HTS_SELF_assisted_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969091
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_15_19_f ON HTS_SELF_assisted_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969093
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_20_24_f ON HTS_SELF_assisted_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969095
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_25_29_f ON HTS_SELF_assisted_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969107
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_30_34_f ON HTS_SELF_assisted_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969109
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_35_39_f ON HTS_SELF_assisted_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969113
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_40_44_f ON HTS_SELF_assisted_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969115
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_45_49_f ON HTS_SELF_assisted_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969099
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_50_f ON HTS_SELF_assisted_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969053
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_10_14_m ON HTS_SELF_assisted_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969055
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_15_19_m ON HTS_SELF_assisted_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969057
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_20_24_m ON HTS_SELF_assisted_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969059
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_25_29_m ON HTS_SELF_assisted_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969071
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_30_34_m ON HTS_SELF_assisted_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969073
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_35_39_m ON HTS_SELF_assisted_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969077
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_40_44_m ON HTS_SELF_assisted_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969079
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_45_49_m ON HTS_SELF_assisted_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969063
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_50_m ON HTS_SELF_assisted_50_m.sourceid=ou.organisationunitid
 
 /*Unassisted*/
 /*Female*/ 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969090
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_10_14_f ON HTS_SELF_unassisted_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969092
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_15_19_f ON HTS_SELF_unassisted_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969094
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_20_24_f ON HTS_SELF_unassisted_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969096
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_25_29_f ON HTS_SELF_unassisted_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969108
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_30_34_f ON HTS_SELF_unassisted_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969110
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_35_39_f ON HTS_SELF_unassisted_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969114
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_40_44_f ON HTS_SELF_unassisted_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969116
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_45_49_f ON HTS_SELF_unassisted_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969100
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_50_f ON HTS_SELF_unassisted_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969054
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_10_14_m ON HTS_SELF_unassisted_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969056
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_15_19_m ON HTS_SELF_unassisted_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969058
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_20_24_m ON HTS_SELF_unassisted_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969060
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_25_29_m ON HTS_SELF_unassisted_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969072
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_30_34_m ON HTS_SELF_unassisted_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969074
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_35_39_m ON HTS_SELF_unassisted_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969078
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_40_44_m ON HTS_SELF_unassisted_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969080
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_45_49_m ON HTS_SELF_unassisted_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid=1969064
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_50_m ON HTS_SELF_unassisted_50_m.sourceid=ou.organisationunitid
 
 /*KeyPop*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid IN (1968836,1968848,1968854,1968860,1968866,1968878,1968902,1968908,1968920,1968926,1968932,1968938,1968944,1968956,1968962,1968968,1968974,1968986,1969010,1969016,1969028,1969034,1969040,1969046)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_pwid ON HTS_SELF_assisted_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid IN (1968832,1968844,1968850,1968856,1968862,1968874,1968898,1968904,1968916,1968922,1968928,1968934,1968940,1968952,1968958,1968964,1968970,1968982,1969006,1969012,1969024,1969030,1969036,1969042)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_msm ON HTS_SELF_assisted_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid IN (1968834,1968846,1968852,1968858,1968864,1968876,1968900,1968906,1968918,1968924,1968930,1968936,1968942,1968954,1968960,1968966,1968972,1968984,1969008,1969014,1969026,1969032,1969038,1969044)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_tg ON HTS_SELF_assisted_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid IN (1968835,1968847,1968853,1968859,1968865,1968877,1968901,1968907,1968919,1968925,1968931,1968937,1968943,1968955,1968961,1968967,1968973,1968985,1969009,1969015,1969027,1969033,1969039,1969045)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_fsw ON HTS_SELF_assisted_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1969455
 AND categoryoptioncomboid IN (1968833,1968845,1968851,1968857,1968863,1968875,1968899,1968905,1968917,1968923,1968929,1968935,1968941,1968953,1968959,1968965,1968971,1968983,1969007,1969013,1969025,1969031,1969037,1969043)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_assisted_closed ON HTS_SELF_assisted_closed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2004815
 AND categoryoptioncomboid IN (1968836,1968848,1968854,1968860,1968866,1968878,1968902,1968908,1968920,1968926,1968932,1968938,1968944,1968956,1968962,1968968,1968974,1968986,1969010,1969016,1969028,1969034,1969040,1969046)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_pwid ON HTS_SELF_unassisted_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2004815
 AND categoryoptioncomboid IN (1968832,1968844,1968850,1968856,1968862,1968874,1968898,1968904,1968916,1968922,1968928,1968934,1968940,1968952,1968958,1968964,1968970,1968982,1969006,1969012,1969024,1969030,1969036,1969042)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_msm ON HTS_SELF_unassisted_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2004815
 AND categoryoptioncomboid IN (1968834,1968846,1968852,1968858,1968864,1968876,1968900,1968906,1968918,1968924,1968930,1968936,1968942,1968954,1968960,1968966,1968972,1968984,1969008,1969014,1969026,1969032,1969038,1969044)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_tg ON HTS_SELF_unassisted_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2004815
 AND categoryoptioncomboid IN (1968835,1968847,1968853,1968859,1968865,1968877,1968901,1968907,1968919,1968925,1968931,1968937,1968943,1968955,1968961,1968967,1968973,1968985,1969009,1969015,1969027,1969033,1969039,1969045)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_fsw ON HTS_SELF_unassisted_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2004815
 AND categoryoptioncomboid IN (1968833,1968845,1968851,1968857,1968863,1968875,1968899,1968905,1968917,1968923,1968929,1968935,1968941,1968953,1968959,1968965,1968971,1968983,1969007,1969013,1969025,1969031,1969037,1969043)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_closed ON HTS_SELF_unassisted_closed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2004815
 AND categoryoptioncomboid IN (3504234,3504237,3504240,3504243,3504249,3504261,3504264,3504270,3504273,3504282,3504291,3504294,3504297,3504300,3504306,3504318,3504321,3504327,3504330,3504339)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_partner ON HTS_SELF_unassisted_partner.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2004815
 AND categoryoptioncomboid IN (3504235,3504238,3504241,3504244,3504250,3504262,3504265,3504271,3504274,3504283,3504292,3504295,3504298,3504301,3504307,3504319,3504322,3504328,3504331,3504340)
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS HTS_SELF_unassisted_other ON HTS_SELF_unassisted_other.sourceid=ou.organisationunitid

/* TX_ML
 * Source:
 * DATIM MER Results MER Quarterly
 */
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772865
AND categoryoptioncomboid=16
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_ML_num ON TX_ML_num.sourceid=ou.organisationunitid

/*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772824
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_men1_f ON TX_ML_ded_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772832
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_1_4_f ON TX_ML_ded_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772840
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_5_9_f ON TX_ML_ded_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772752
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_10_14_f ON TX_ML_ded_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772760
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_15_19_f ON TX_ML_ded_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772768
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_20_24_f ON TX_ML_ded_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772792
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_25_29_f ON TX_ML_ded_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772800
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_30_34_f ON TX_ML_ded_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772808
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_35_39_f ON TX_ML_ded_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772848
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_40_44_f ON TX_ML_ded_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772856
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_45_49_f ON TX_ML_ded_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772784
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_50_f ON TX_ML_ded_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772820
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_men1_m ON TX_ML_ded_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772828
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_1_4_m ON TX_ML_ded_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772836
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_5_9_m ON TX_ML_ded_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772748
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_10_14_m ON TX_ML_ded_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772756
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_15_19_m ON TX_ML_ded_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772764
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_20_24_m ON TX_ML_ded_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772788
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_25_29_m ON TX_ML_ded_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772796
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_30_34_m ON TX_ML_ded_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772804
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_35_39_m ON TX_ML_ded_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772844
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_40_44_m ON TX_ML_ded_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772852
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_45_49_m ON TX_ML_ded_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772780
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ded_50_m ON TX_ML_ded_50_m.sourceid=ou.organisationunitid
 
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772825
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_men1_f ON TX_ML_men3_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772833
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_1_4_f ON TX_ML_men3_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772841
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_5_9_f ON TX_ML_men3_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772753
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_10_14_f ON TX_ML_men3_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772761
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_15_19_f ON TX_ML_men3_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772769
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_20_24_f ON TX_ML_men3_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772793
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_25_29_f ON TX_ML_men3_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772801
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_30_34_f ON TX_ML_men3_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772809
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_35_39_f ON TX_ML_men3_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772849
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_40_44_f ON TX_ML_men3_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772857
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_45_49_f ON TX_ML_men3_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772785
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_50_f ON TX_ML_men3_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772821
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_men1_m ON TX_ML_men3_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772829
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_1_4_m ON TX_ML_men3_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772837
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_5_9_m ON TX_ML_men3_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772749
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_10_14_m ON TX_ML_men3_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772757
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_15_19_m ON TX_ML_men3_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772765
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_20_24_m ON TX_ML_men3_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772789
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_25_29_m ON TX_ML_men3_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772797
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_30_34_m ON TX_ML_men3_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772805
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_35_39_m ON TX_ML_men3_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772845
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_40_44_m ON TX_ML_men3_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772853
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_45_49_m ON TX_ML_men3_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772781
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_men3_50_m ON TX_ML_men3_50_m.sourceid=ou.organisationunitid
 
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772826
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_men1_f ON TX_ML_mai3_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772834
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_1_4_f ON TX_ML_mai3_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772842
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_5_9_f ON TX_ML_mai3_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772754
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_10_14_f ON TX_ML_mai3_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772762
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_15_19_f ON TX_ML_mai3_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772770
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_20_24_f ON TX_ML_mai3_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772794
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_25_29_f ON TX_ML_mai3_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772802
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_30_34_f ON TX_ML_mai3_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772810
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_35_39_f ON TX_ML_mai3_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772850
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_40_44_f ON TX_ML_mai3_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772858
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_45_49_f ON TX_ML_mai3_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772786
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_50_f ON TX_ML_mai3_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772822
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_men1_m ON TX_ML_mai3_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772830
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_1_4_m ON TX_ML_mai3_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772838
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_5_9_m ON TX_ML_mai3_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772750
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_10_14_m ON TX_ML_mai3_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772758
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_15_19_m ON TX_ML_mai3_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772766
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_20_24_m ON TX_ML_mai3_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772790
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_25_29_m ON TX_ML_mai3_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772798
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_30_34_m ON TX_ML_mai3_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772806
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_35_39_m ON TX_ML_mai3_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772846
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_40_44_m ON TX_ML_mai3_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772854
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_45_49_m ON TX_ML_mai3_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772782
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_mai3_50_m ON TX_ML_mai3_50_m.sourceid=ou.organisationunitid
 
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772827
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_men1_f ON TX_ML_trans_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772835
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_1_4_f ON TX_ML_trans_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772843
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_5_9_f ON TX_ML_trans_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772755
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_10_14_f ON TX_ML_trans_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772763
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_15_19_f ON TX_ML_trans_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772771
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_20_24_f ON TX_ML_trans_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772795
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_25_29_f ON TX_ML_trans_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772803
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_30_34_f ON TX_ML_trans_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772811
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_35_39_f ON TX_ML_trans_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772851
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_40_44_f ON TX_ML_trans_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772859
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_45_49_f ON TX_ML_trans_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772787
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_50_f ON TX_ML_trans_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772823
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_men1_m ON TX_ML_trans_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772831
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_1_4_m ON TX_ML_trans_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772839
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_5_9_m ON TX_ML_trans_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772751
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_10_14_m ON TX_ML_trans_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772759
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_15_19_m ON TX_ML_trans_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772767
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_20_24_m ON TX_ML_trans_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772791
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_25_29_m ON TX_ML_trans_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772799
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_30_34_m ON TX_ML_trans_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772807
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_35_39_m ON TX_ML_trans_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772847
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_40_44_m ON TX_ML_trans_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772855
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_45_49_m ON TX_ML_trans_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=1772783
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_trans_50_m ON TX_ML_trans_50_m.sourceid=ou.organisationunitid
 
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623371
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_men1_f ON TX_ML_ref_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623373
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_1_4_f ON TX_ML_ref_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623375
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_5_9_f ON TX_ML_ref_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623353
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_10_14_f ON TX_ML_ref_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623355
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_15_19_f ON TX_ML_ref_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623357
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_20_24_f ON TX_ML_ref_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623363
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_25_29_f ON TX_ML_ref_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623365
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_30_34_f ON TX_ML_ref_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623367
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_35_39_f ON TX_ML_ref_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623377
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_40_44_f ON TX_ML_ref_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623379
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_45_49_f ON TX_ML_ref_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623361
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_50_f ON TX_ML_ref_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623370
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_men1_m ON TX_ML_ref_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623372
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_1_4_m ON TX_ML_ref_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623374
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_5_9_m ON TX_ML_ref_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623352
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_10_14_m ON TX_ML_ref_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623354
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_15_19_m ON TX_ML_ref_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623356
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_20_24_m ON TX_ML_ref_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623362
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_25_29_m ON TX_ML_ref_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623364
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_30_34_m ON TX_ML_ref_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623366
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_35_39_m ON TX_ML_ref_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623376
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_40_44_m ON TX_ML_ref_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623378
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_45_49_m ON TX_ML_ref_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1772864
 AND categoryoptioncomboid=2623360
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_ML_ref_50_m ON TX_ML_ref_50_m.sourceid=ou.organisationunitid
 
 /*TX_PVLS KeyPop*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621615
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_R_keypop_pwid ON TX_PVLS_N_R_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621611
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_R_keypop_msm ON TX_PVLS_N_R_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621613
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_R_keypop_tg ON TX_PVLS_N_R_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621614
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_R_keypop_fsw ON TX_PVLS_N_R_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621612
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_R_keypop_prison ON TX_PVLS_N_R_keypop_prison.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621621
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_T_keypop_pwid ON TX_PVLS_N_T_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621617
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_T_keypop_msm ON TX_PVLS_N_T_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621619
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_T_keypop_tg ON TX_PVLS_N_T_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621620
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_T_keypop_fsw ON TX_PVLS_N_T_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621597
 AND categoryoptioncomboid=2621618
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_N_T_keypop_prison ON TX_PVLS_N_T_keypop_prison.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621615
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_R_keypop_pwid ON TX_PVLS_D_R_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621611
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_R_keypop_msm ON TX_PVLS_D_R_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621613
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_R_keypop_tg ON TX_PVLS_D_R_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621614
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_R_keypop_fsw ON TX_PVLS_D_R_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621612
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_R_keypop_prison ON TX_PVLS_D_R_keypop_prison.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621621
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_T_keypop_pwid ON TX_PVLS_D_T_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621617
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_T_keypop_msm ON TX_PVLS_D_T_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621619
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_T_keypop_tg ON TX_PVLS_D_T_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621620
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_T_keypop_fsw ON TX_PVLS_D_T_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2621736
 AND categoryoptioncomboid=2621618
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_PVLS_D_T_keypop_prison ON TX_PVLS_D_T_keypop_prison.sourceid=ou.organisationunitid

/*PrEP_NEW
 * Source:
 * Clinico-PrEP
 */
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) as value
from datavalue
WHERE dataelementid=735659
AND categoryoptioncomboid=16
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_num ON PrEP_NEW_num.sourceid=ou.organisationunitid

/*Female*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735831
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_15_19_f ON PrEP_NEW_15_19_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735833
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_20_24_f ON PrEP_NEW_20_24_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735835
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_25_29_f ON PrEP_NEW_25_29_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735837
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_30_34_f ON PrEP_NEW_30_34_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735839
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_35_39_f ON PrEP_NEW_35_39_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=1484545
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_40_44_f ON PrEP_NEW_40_44_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=1484546
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_45_49_f ON PrEP_NEW_45_49_f.sourceid=ou.organisationunitid


LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735843
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_50_f ON PrEP_NEW_50_f.sourceid=ou.organisationunitid

/*Male*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735830
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_15_19_m ON PrEP_NEW_15_19_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735832
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_20_24_m ON PrEP_NEW_20_24_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735834
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_25_29_m ON PrEP_NEW_25_29_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735836
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_30_34_m ON PrEP_NEW_30_34_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735838
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_35_39_m ON PrEP_NEW_35_39_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=1484543
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_40_44_m ON PrEP_NEW_40_44_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=1484544
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_45_49_m ON PrEP_NEW_45_49_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=735857
AND categoryoptioncomboid=735842
AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS PrEP_NEW_50_m ON PrEP_NEW_50_m.sourceid=ou.organisationunitid

/*PrEP_NEW KEY POP*/
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=735873
 AND categoryoptioncomboid=444404
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PrEP_NEW_keypop_pwid ON PrEP_NEW_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=735873
 AND categoryoptioncomboid=444403
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PrEP_NEW_keypop_msm ON PrEP_NEW_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=735873
 AND categoryoptioncomboid=444405
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PrEP_NEW_keypop_tg ON PrEP_NEW_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=735873
 AND categoryoptioncomboid=444402
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PrEP_NEW_keypop_fsw ON PrEP_NEW_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=735873
 AND categoryoptioncomboid=444401
 AND periodid IN (SELECT DISTINCT(ps.periodid) FROM _periodstructure ps,period p WHERE quarterly=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PrEP_NEW_keypop_prison ON PrEP_NEW_keypop_prison.sourceid=ou.organisationunitid

/*PrEP_CURR
 * Source:
 * Clinico-PrEP
 */
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750033
AND categoryoptioncomboid=16
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_num ON PrEP_CURR_num.sourceid=ou.organisationunitid

/*Female*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735831
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_15_19_f ON PrEP_CURR_15_19_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735833
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_20_24_f ON PrEP_CURR_20_24_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735835
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_25_29_f ON PrEP_CURR_25_29_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735837
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_30_34_f ON PrEP_CURR_30_34_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735839
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_35_39_f ON PrEP_CURR_35_39_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=1484545
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_40_44_f ON PrEP_CURR_40_44_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=1484546
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_45_49_f ON PrEP_CURR_45_49_f.sourceid=ou.organisationunitid


LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735843
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_50_f ON PrEP_CURR_50_f.sourceid=ou.organisationunitid

/*Male*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735830
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_15_19_m ON PrEP_CURR_15_19_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735832
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_20_24_m ON PrEP_CURR_20_24_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735834
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_25_29_m ON PrEP_CURR_25_29_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735836
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_30_34_m ON PrEP_CURR_30_34_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735838
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_35_39_m ON PrEP_CURR_35_39_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=1484543
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_40_44_m ON PrEP_CURR_40_44_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=1484544
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_45_49_m ON PrEP_CURR_45_49_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750035
AND categoryoptioncomboid=735842
AND periodid=3459701
GROUP BY sourceid) AS PrEP_CURR_50_m ON PrEP_CURR_50_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750063
AND categoryoptioncomboid=1750053
AND periodid=3459701
GROUP BY sourceid) AS PrEP_3_pos ON PrEP_3_pos.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750063
AND categoryoptioncomboid=1750054
AND periodid=3459701
GROUP BY sourceid) AS PrEP_3_neg ON PrEP_3_neg.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1750063
AND categoryoptioncomboid IN (1750055,1807513)
AND periodid=3459701
GROUP BY sourceid) AS PrEP_3_less ON PrEP_3_less.sourceid=ou.organisationunitid

/*PrEP_CURR KEY POP*/
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1750037
 AND categoryoptioncomboid=444404
 AND periodid=3459701
 GROUP BY sourceid) AS PrEP_CURR_keypop_pwid ON PrEP_CURR_keypop_pwid.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1750037
 AND categoryoptioncomboid=444403
 AND periodid=3459701
 GROUP BY sourceid) AS PrEP_CURR_keypop_msm ON PrEP_CURR_keypop_msm.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1750037
 AND categoryoptioncomboid=444405
 AND periodid=3459701
 GROUP BY sourceid) AS PrEP_CURR_keypop_tg ON PrEP_CURR_keypop_tg.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1750037
 AND categoryoptioncomboid=444402
 AND periodid=3459701
 GROUP BY sourceid) AS PrEP_CURR_keypop_fsw ON PrEP_CURR_keypop_fsw.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1750037
 AND categoryoptioncomboid=444401
 AND periodid=3459701
 GROUP BY sourceid) AS PrEP_CURR_keypop_prison ON PrEP_CURR_keypop_prison.sourceid=ou.organisationunitid

----------------------------------------------------------------------------------------
--SEMIANNUALY
-----------------------------------------------------------------------------------------
 
/*TB_PREV (Numerator)
 * Source:
 * DATIM MER Results MER Semiannually
 */
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=500018
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num ON TB_PREV_num.sourceid=ou.organisationunitid

/*IPT*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772488
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_new_f_men15 ON TB_PREV_num_ipt_new_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772489
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_new_f_mai15 ON TB_PREV_num_ipt_new_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772484
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_new_m_men15 ON TB_PREV_num_ipt_new_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772485
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_new_m_mai15 ON TB_PREV_num_ipt_new_m_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772503
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_already_f_men15 ON TB_PREV_num_ipt_already_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772504
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_already_f_mai15 ON TB_PREV_num_ipt_already_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772499
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_already_m_men15 ON TB_PREV_num_ipt_already_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772500
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_ipt_already_m_mai15 ON TB_PREV_num_ipt_already_m_mai15.sourceid=ou.organisationunitid

/*Alternative*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772518
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_new_f_men15 ON TB_PREV_num_alter_new_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772519
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_new_f_mai15 ON TB_PREV_num_alter_new_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772514
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_new_m_men15 ON TB_PREV_num_alter_new_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772515
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_new_m_mai15 ON TB_PREV_num_alter_new_m_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772533
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_already_f_men15 ON TB_PREV_num_alter_already_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772534
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_already_f_mai15 ON TB_PREV_num_alter_already_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772529
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_already_m_men15 ON TB_PREV_num_alter_already_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772575
AND categoryoptioncomboid=1772530
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_num_alter_already_m_mai15 ON TB_PREV_num_alter_already_m_mai15.sourceid=ou.organisationunitid

/*TB_PREV (Denominator)
 * Source:
 * DATIM MER Results MER Semiannually
 */
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=500066
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den ON TB_PREV_den.sourceid=ou.organisationunitid

/*IPT*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772488
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_new_f_men15 ON TB_PREV_den_ipt_new_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772489
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_new_f_mai15 ON TB_PREV_den_ipt_new_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772484
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_new_m_men15 ON TB_PREV_den_ipt_new_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772485
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_new_m_mai15 ON TB_PREV_den_ipt_new_m_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772503
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_already_f_men15 ON TB_PREV_den_ipt_already_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772504
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_already_f_mai15 ON TB_PREV_den_ipt_already_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772499
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_already_m_men15 ON TB_PREV_den_ipt_already_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772500
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_ipt_already_m_mai15 ON TB_PREV_den_ipt_already_m_mai15.sourceid=ou.organisationunitid

/*Alternative*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772518
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_new_f_men15 ON TB_PREV_den_alter_new_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772519
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_new_f_mai15 ON TB_PREV_den_alter_new_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772514
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_new_m_men15 ON TB_PREV_den_alter_new_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772515
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_new_m_mai15 ON TB_PREV_den_alter_new_m_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772533
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_already_f_men15 ON TB_PREV_den_alter_already_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772534
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_already_f_mai15 ON TB_PREV_den_alter_already_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772529
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_already_m_men15 ON TB_PREV_den_alter_already_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772591
AND categoryoptioncomboid=1772530
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TB_PREV_den_alter_already_m_mai15 ON TB_PREV_den_alter_already_m_mai15.sourceid=ou.organisationunitid

/* TX_TB (Numerator)
 * Source:
 * DATIM MER Results MER Semiannually
 */
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=480786
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num ON TX_TB_num.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772618
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_new_men15_f ON TX_TB_num_new_men15_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772620
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_new_mai15_f ON TX_TB_num_new_mai15_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772608
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_new_men15_m ON TX_TB_num_new_men15_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772610
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_new_mai15_m ON TX_TB_num_new_mai15_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772619
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_already_men15_f ON TX_TB_num_already_men15_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772621
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_already_mai15_f ON TX_TB_num_already_mai15_f.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772609
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_already_men15_m ON TX_TB_num_already_men15_m.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772631
AND categoryoptioncomboid=1772611
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_num_already_mai15_m ON TX_TB_num_already_mai15_m.sourceid=ou.organisationunitid

/* TX_TB (Denominator)
 * Source:
 * DATIM MER Results MER Semiannually
 */
 
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=480889
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den ON TX_TB_den.sourceid=ou.organisationunitid

/*Positive*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772659
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_new_f_men15 ON TX_TB_den_pos_new_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772660
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_new_f_mai15 ON TX_TB_den_pos_new_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772654
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_new_m_men15 ON TX_TB_den_pos_new_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772655
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_new_m_mai15 ON TX_TB_den_pos_new_m_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772669
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_already_f_men15 ON TX_TB_den_pos_already_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772670
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_already_f_mai15 ON TX_TB_den_pos_already_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772664
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_already_m_men15 ON TX_TB_den_pos_already_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772665
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_pos_already_m_mai15 ON TX_TB_den_pos_already_m_mai15.sourceid=ou.organisationunitid

/*Negative*/
LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772679
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_new_f_men15 ON TX_TB_den_neg_new_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772680
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_new_f_mai15 ON TX_TB_den_neg_new_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772674
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_new_m_men15 ON TX_TB_den_neg_new_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772675
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_new_m_mai15 ON TX_TB_den_neg_new_m_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772689
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_already_f_men15 ON TX_TB_den_neg_already_f_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772690
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_already_f_mai15 ON TX_TB_den_neg_already_f_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772684
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_already_m_men15 ON TX_TB_den_neg_already_m_men15.sourceid=ou.organisationunitid

 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772714
AND categoryoptioncomboid=1772685
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_den_neg_already_m_mai15 ON TX_TB_den_neg_already_m_mai15.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=481701
AND categoryoptioncomboid=16
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_specimem ON TX_TB_specimem.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=481106
AND categoryoptioncomboid=481017
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_smear ON TX_TB_smear.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=481106
AND categoryoptioncomboid=481015
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_xpert ON TX_TB_xpert.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=481106
AND categoryoptioncomboid=481016
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_other ON TX_TB_other.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1772729
AND categoryoptioncomboid=16
AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701))
GROUP BY sourceid) AS TX_TB_pos_returned ON TX_TB_pos_returned.sourceid=ou.organisationunitid


/*CXCA_SCRN
 * Source:
 * CACUM
 */
/*Negative*/
/*15-19*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1244133
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_15_19 ON CXCA_SCRN_neg_15_19.sourceid=ou.organisationunitid

/*20-24*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1244134
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_20_24 ON CXCA_SCRN_neg_20_24.sourceid=ou.organisationunitid

/*25-29*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1204803
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_25_29 ON CXCA_SCRN_neg_25_29.sourceid=ou.organisationunitid

/*30-34*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1204804
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_30_34 ON CXCA_SCRN_neg_30_34.sourceid=ou.organisationunitid

/*35-39*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1204805
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_35_39 ON CXCA_SCRN_neg_35_39.sourceid=ou.organisationunitid

/*40-44*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1244136
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_40_44 ON CXCA_SCRN_neg_40_44.sourceid=ou.organisationunitid

/*45-49*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1244138
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_45_49 ON CXCA_SCRN_neg_45_49.sourceid=ou.organisationunitid

/*50+*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204823
AND categoryoptioncomboid=1204807
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_neg_50 ON CXCA_SCRN_neg_50.sourceid=ou.organisationunitid

/*Positive*/
/*15-19*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1244133
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_15_19 ON CXCA_SCRN_pos_15_19.sourceid=ou.organisationunitid

/*20-24*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1244134
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_20_24 ON CXCA_SCRN_pos_20_24.sourceid=ou.organisationunitid

/*25-29*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1204803
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_25_29 ON CXCA_SCRN_pos_25_29.sourceid=ou.organisationunitid

/*30-34*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1204804
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_30_34 ON CXCA_SCRN_pos_30_34.sourceid=ou.organisationunitid

/*35-39*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1204805
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_35_39 ON CXCA_SCRN_pos_35_39.sourceid=ou.organisationunitid

/*40-44*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1244136
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_40_44 ON CXCA_SCRN_pos_40_44.sourceid=ou.organisationunitid

/*45-49*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1244138
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_45_49 ON CXCA_SCRN_pos_45_49.sourceid=ou.organisationunitid

/*50+*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204824
AND categoryoptioncomboid=1204807
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_pos_50 ON CXCA_SCRN_pos_50.sourceid=ou.organisationunitid

/*Suspected*/
/*15-19*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1244133
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_15_19 ON CXCA_SCRN_sus_15_19.sourceid=ou.organisationunitid

/*20-24*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1244134
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_20_24 ON CXCA_SCRN_sus_20_24.sourceid=ou.organisationunitid

/*25-29*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1204803
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_25_29 ON CXCA_SCRN_sus_25_29.sourceid=ou.organisationunitid

/*30-34*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1204804
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_30_34 ON CXCA_SCRN_sus_30_34.sourceid=ou.organisationunitid

/*35-39*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1204805
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_35_39 ON CXCA_SCRN_sus_35_39.sourceid=ou.organisationunitid

/*40-44*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1244136
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_40_44 ON CXCA_SCRN_sus_40_44.sourceid=ou.organisationunitid

/*45-49*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1244138
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_45_49 ON CXCA_SCRN_sus_45_49.sourceid=ou.organisationunitid

/*50+*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204829
AND categoryoptioncomboid=1204807
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_SCRN_sus_50 ON CXCA_SCRN_sus_50.sourceid=ou.organisationunitid

/* CXCA_TX
 * Source:
 * CACUM
 */
/*Cryotherapy*/
/*15-19*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1244133
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_15_19 ON CXCA_TX_cryo_15_19.sourceid=ou.organisationunitid

/*20-24*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1244134
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_20_24 ON CXCA_TX_cryo_20_24.sourceid=ou.organisationunitid

/*25-29*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1204803
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_25_29 ON CXCA_TX_cryo_25_29.sourceid=ou.organisationunitid

/*30-34*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1204804
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_30_34 ON CXCA_TX_cryo_30_34.sourceid=ou.organisationunitid

/*35-39*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1204805
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_35_39 ON CXCA_TX_cryo_35_39.sourceid=ou.organisationunitid

/*40-44*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1244136
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_40_44 ON CXCA_TX_cryo_40_44.sourceid=ou.organisationunitid

/*45-49*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1244138
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_45_49 ON CXCA_TX_cryo_45_49.sourceid=ou.organisationunitid

/*50+*/
 LEFT OUTER JOIN (
SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
FROM datavalue
WHERE dataelementid=1204825
AND categoryoptioncomboid=1204807
AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
GROUP BY sourceid) AS CXCA_TX_cryo_50 ON CXCA_TX_cryo_50.sourceid=ou.organisationunitid

/*SC_ARVDISP*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2684317
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_TLD_30 ON SCARVDISP_TLD_30.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2684323
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_TLD_90 ON SCARVDISP_TLD_90.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2684324
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_TLD_180 ON SCARVDISP_TLD_180.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2684315
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_TLE_30 ON SCARVDISP_TLE_30.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2684316
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_TLE_90 ON SCARVDISP_TLE_90.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2684302
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_TLE_180 ON SCARVDISP_TLE_180.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2684425
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_LPV_Ped ON SCARVDISP_LPV_Ped.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2684415,2684326)
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_NVP_Adult ON SCARVDISP_NVP_Adult.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2684439,2684435)
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_NVP_Ped ON SCARVDISP_NVP_Ped.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2684423,2684336,2684342,2684343,2684329,2684346,2684404,2684406)
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_Other_Adult ON SCARVDISP_Other_Adult.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2684440,2684424,2684426,2684427,2684428,2684429,2684433,2684437)
 AND categoryoptioncomboid=16
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS SCARVDISP_Other_Ped ON SCARVDISP_Other_Ped.sourceid=ou.organisationunitid
 
 /*SC_CURR*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2685612
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_TLD_30 ON SCCURR_TLD_30.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2685611
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_TLD_90 ON SCCURR_TLD_90.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2685613
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_TLD_180 ON SCCURR_TLD_180.sourceid=ou.organisationunitid

LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2685610
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_TLE_30 ON SCCURR_TLE_30.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2685609
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_TLE_90 ON SCCURR_TLE_90.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2685608
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_TLE_180 ON SCCURR_TLE_180.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2685595
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_LPV_Ped ON SCCURR_LPV_Ped.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2685603,2684451)
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_NVP_Adult ON SCCURR_NVP_Adult.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2685622,2684453)
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_NVP_Ped ON SCCURR_NVP_Ped.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2685618,2685574,2685573,2685594,2685584,2685578,2685575,2685616)
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_Other_Adult ON SCCURR_Other_Adult.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid IN (2685619,2685586,2685598,2685577,2685572,2685571,2685585,2685617)
 AND categoryoptioncomboid=16
 AND periodid=3459701
 GROUP BY sourceid) AS SCCURR_Other_Ped ON SCCURR_Other_Ped.sourceid=ou.organisationunitid
 
/*GEND_GBV*/
 /*Sexual*/
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489212
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_men10 ON GEND_GBV_sexual_f_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489213
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_10_14 ON GEND_GBV_sexual_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489214
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_15_19 ON GEND_GBV_sexual_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489215
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_20_24 ON GEND_GBV_sexual_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489216
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_25_29 ON GEND_GBV_sexual_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489217
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_30_34 ON GEND_GBV_sexual_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489218
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_35_39 ON GEND_GBV_sexual_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489213
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_40_49 ON GEND_GBV_sexual_f_40_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489219
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_40_44 ON GEND_GBV_sexual_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489220
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_45_49 ON GEND_GBV_sexual_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489221
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_f_50 ON GEND_GBV_sexual_f_50.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489202
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_men10 ON GEND_GBV_sexual_m_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489203
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_10_14 ON GEND_GBV_sexual_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489204
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_15_19 ON GEND_GBV_sexual_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489205
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_20_24 ON GEND_GBV_sexual_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489206
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_25_29 ON GEND_GBV_sexual_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489207
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_30_34 ON GEND_GBV_sexual_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489208
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_35_39 ON GEND_GBV_sexual_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=562375
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_40_49 ON GEND_GBV_sexual_m_40_49.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489209
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_40_44 ON GEND_GBV_sexual_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489210
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_45_49 ON GEND_GBV_sexual_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489226
 AND categoryoptioncomboid=3489211
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_sexual_m_50 ON GEND_GBV_sexual_m_50.sourceid=ou.organisationunitid
 
 /*Physical*/
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489212
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_men10 ON GEND_GBV_physical_f_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489213
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_10_14 ON GEND_GBV_physical_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489214
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_15_19 ON GEND_GBV_physical_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489215
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_20_24 ON GEND_GBV_physical_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489216
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_25_29 ON GEND_GBV_physical_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489217
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_30_34 ON GEND_GBV_physical_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489218
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_35_39 ON GEND_GBV_physical_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489213
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_40_49 ON GEND_GBV_physical_f_40_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489219
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_40_44 ON GEND_GBV_physical_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489220
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_45_49 ON GEND_GBV_physical_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489221
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_f_50 ON GEND_GBV_physical_f_50.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489202
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_men10 ON GEND_GBV_physical_m_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489203
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_10_14 ON GEND_GBV_physical_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489204
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_15_19 ON GEND_GBV_physical_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489205
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_20_24 ON GEND_GBV_physical_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489206
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_25_29 ON GEND_GBV_physical_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489207
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_30_34 ON GEND_GBV_physical_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489208
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_35_39 ON GEND_GBV_physical_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=562375
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_40_49 ON GEND_GBV_physical_m_40_49.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489209
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_40_44 ON GEND_GBV_physical_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489210
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_45_49 ON GEND_GBV_physical_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489245
 AND categoryoptioncomboid=3489211
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_physical_m_50 ON GEND_GBV_physical_m_50.sourceid=ou.organisationunitid
 
 /*PEP*/
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489212
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_men10 ON GEND_GBV_pep_f_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489213
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_10_14 ON GEND_GBV_pep_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489214
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_15_19 ON GEND_GBV_pep_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489215
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_20_24 ON GEND_GBV_pep_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489216
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_25_29 ON GEND_GBV_pep_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489217
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_30_34 ON GEND_GBV_pep_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489218
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_35_39 ON GEND_GBV_pep_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489213
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_40_49 ON GEND_GBV_pep_f_40_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489219
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_40_44 ON GEND_GBV_pep_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489220
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_45_49 ON GEND_GBV_pep_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489221
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_f_50 ON GEND_GBV_pep_f_50.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489202
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_men10 ON GEND_GBV_pep_m_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489203
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_10_14 ON GEND_GBV_pep_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489204
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_15_19 ON GEND_GBV_pep_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489205
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_20_24 ON GEND_GBV_pep_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489206
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_25_29 ON GEND_GBV_pep_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489207
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_30_34 ON GEND_GBV_pep_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489208
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_35_39 ON GEND_GBV_pep_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=562375
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_40_49 ON GEND_GBV_pep_m_40_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489209
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_40_44 ON GEND_GBV_pep_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489210
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_45_49 ON GEND_GBV_pep_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3489237
 AND categoryoptioncomboid=3489211
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_pep_m_50 ON GEND_GBV_pep_m_50.sourceid=ou.organisationunitid
 
 
 /*GEND_GBV_old*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=13043
 AND categoryoptioncomboid IN (13041,13042)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_num ON GEND_GBV_old_num.sourceid=ou.organisationunitid
 
 /*Sexual*/
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid IN (562364,562368,562384)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_men10 ON GEND_GBV_old_sexual_f_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562371
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_10_14 ON GEND_GBV_old_sexual_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562370
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_15_19 ON GEND_GBV_old_sexual_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562363
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_20_24 ON GEND_GBV_old_sexual_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562372
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_25_29 ON GEND_GBV_old_sexual_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562376
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_30_34 ON GEND_GBV_old_sexual_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562367
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_35_39 ON GEND_GBV_old_sexual_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562369
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_40_49 ON GEND_GBV_old_sexual_f_40_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=1480202
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_40_44 ON GEND_GBV_old_sexual_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=1480203
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_45_49 ON GEND_GBV_old_sexual_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562385
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_f_50 ON GEND_GBV_old_sexual_f_50.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid IN (562366,562374,562378)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_men10 ON GEND_GBV_old_sexual_m_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562373
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_10_14 ON GEND_GBV_old_sexual_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562377
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_15_19 ON GEND_GBV_old_sexual_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562382
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_20_24 ON GEND_GBV_old_sexual_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562383
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_25_29 ON GEND_GBV_old_sexual_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562362
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_30_34 ON GEND_GBV_old_sexual_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562365
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_35_39 ON GEND_GBV_old_sexual_m_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562375
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_40_49 ON GEND_GBV_old_sexual_m_40_49.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=1480200
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_40_44 ON GEND_GBV_old_sexual_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=1480201
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_45_49 ON GEND_GBV_old_sexual_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562387
 AND categoryoptioncomboid=562380
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_sexual_m_50 ON GEND_GBV_old_sexual_m_50.sourceid=ou.organisationunitid
 
 /*Physical*/
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid IN (562364,562368,562384)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_men10 ON GEND_GBV_old_physical_f_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562371
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_10_14 ON GEND_GBV_old_physical_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562370
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_15_19 ON GEND_GBV_old_physical_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562363
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_20_24 ON GEND_GBV_old_physical_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562372
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_25_29 ON GEND_GBV_old_physical_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562376
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_30_34 ON GEND_GBV_old_physical_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562367
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_35_39 ON GEND_GBV_old_physical_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562369
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_40_49 ON GEND_GBV_old_physical_f_40_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=1480202
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_40_44 ON GEND_GBV_old_physical_f_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=1480203
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_45_49 ON GEND_GBV_old_physical_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562385
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_f_50 ON GEND_GBV_old_physical_f_50.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid IN (562366,562374,562378)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_men10 ON GEND_GBV_old_physical_m_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562373
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_10_14 ON GEND_GBV_old_physical_m_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562377
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_15_19 ON GEND_GBV_old_physical_m_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562382
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_20_24 ON GEND_GBV_old_physical_m_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562383
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_25_29 ON GEND_GBV_old_physical_m_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562362
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_30_34 ON GEND_GBV_old_physical_m_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562365
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_35_39 ON GEND_GBV_old_physical_m_35_39.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=1480200
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_40_44 ON GEND_GBV_old_physical_m_40_44.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=1480201
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_45_49 ON GEND_GBV_old_physical_m_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562375
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_40_49 ON GEND_GBV_old_physical_m_40_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562386
 AND categoryoptioncomboid=562380
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_physical_m_50 ON GEND_GBV_old_physical_m_50.sourceid=ou.organisationunitid

 
 /*PEP*/
 /*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid IN (562390,562391,562396)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_men10 ON GEND_GBV_old_pep_f_men10.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562392
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_10_14 ON GEND_GBV_old_pep_f_10_14.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562395
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_15_19 ON GEND_GBV_old_pep_f_15_19.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562397
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_20_24 ON GEND_GBV_old_pep_f_20_24.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562398
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_25_29 ON GEND_GBV_old_pep_f_25_29.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562394
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_30_34 ON GEND_GBV_old_pep_f_30_34.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562400
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_35_39 ON GEND_GBV_old_pep_f_35_39.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562399
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_40_49 ON GEND_GBV_old_pep_f_40_49.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=1480216
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_40_44 ON GEND_GBV_old_pep_f_40_44.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=1480217
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_45_49 ON GEND_GBV_old_pep_f_45_49.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=562401
 AND categoryoptioncomboid=562389
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE sixmonthlyapril=(SELECT sixmonthlyapril FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS GEND_GBV_old_pep_f_50 ON GEND_GBV_old_pep_f_50.sourceid=ou.organisationunitid
 
 ----------------------------------------------------------------------------------------
--ANNUALY
----------------------------------------------------------------------------------------
 
 /*FPINT_SITE*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=516969
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS FPINT_SITE_hiv_testing ON FPINT_SITE_hiv_testing.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=516968
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS FPINT_SITE_ct ON FPINT_SITE_ct.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=516967
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS FPINT_SITE_anc ON FPINT_SITE_anc.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=516971
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS FPINT_SITE_priority ON FPINT_SITE_priority.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=516970
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS FPINT_SITE_key ON FPINT_SITE_key.sourceid=ou.organisationunitid
 
 /*PMTCT_FO*/
 /*Denominator*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1203573
 AND categoryoptioncomboid IN (1203650,1203651,1203652)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE financialoct=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_FO_den ON PMTCT_FO_den.sourceid=ou.organisationunitid
 
 /*HIV-Infected*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1203594
 AND categoryoptioncomboid IN (1203656,1203657,1203658)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE financialoct=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_FO_hivinfected ON PMTCT_FO_hivinfected.sourceid=ou.organisationunitid
 
 /*HIV-uninfected*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1203594
 AND categoryoptioncomboid IN (1203653,1203654,1203655)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE financialoct=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_FO_hivuninfected ON PMTCT_FO_hivuninfected.sourceid=ou.organisationunitid
 
 /*HIV-final status unknown*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1203594
 AND categoryoptioncomboid IN (1203659,1203660,1203661,1203662,1203663,1203664)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE financialoct=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_FO_hivfsu ON PMTCT_FO_hivfsu.sourceid=ou.organisationunitid 
 
 /*Died without status known*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1203594
 AND categoryoptioncomboid IN (1203665,1203666,1203667)
 AND periodid IN (SELECT distinct(ps.periodid) FROM _periodstructure ps, period p WHERE financialoct=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701) AND ps.periodid=p.periodid AND p.periodtypeid=3)
 GROUP BY sourceid) AS PMTCT_FO_died ON PMTCT_FO_died.sourceid=ou.organisationunitid
 
 /*HRH_CURR_Cadre*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472674
 AND categoryoptioncomboid=472933
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_Cadre_clinical ON HRH_CURR_Cadre_clinical.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472674
 AND categoryoptioncomboid=2213134
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_Cadre_pharmacy ON HRH_CURR_Cadre_pharmacy.sourceid=ou.organisationunitid
 
  LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472674
 AND categoryoptioncomboid=2213133
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_Cadre_laboratory ON HRH_CURR_Cadre_laboratory.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472674
 AND categoryoptioncomboid=472935
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_Cadre_management ON HRH_CURR_Cadre_management.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472674
 AND categoryoptioncomboid=472936
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_Cadre_socialservices ON HRH_CURR_Cadre_socialservices.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472674
 AND categoryoptioncomboid=472937
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_Cadre_lay ON HRH_CURR_Cadre_lay.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472674
 AND categoryoptioncomboid=472938
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_Cadre_other ON HRH_CURR_Cadre_other.sourceid=ou.organisationunitid
 
 /*HRH_CURR_Clinical*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472662
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_clinical_ss ON HRH_CURR_clinical_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472659
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_clinical_srs ON HRH_CURR_clinical_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472661
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_clinical_srnms ON HRH_CURR_clinical_srnms.sourceid=ou.organisationunitid
 
  /*HRH_CURR_Pharmacy*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=2213130
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_pharmacy_ss ON HRH_CURR_pharmacy_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=2213131
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_pharmacy_srs ON HRH_CURR_pharmacy_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=2213132
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_pharmacy_srnms ON HRH_CURR_pharmacy_srnms.sourceid=ou.organisationunitid
 
  /*HRH_CURR_Laboratory*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=2213127
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_laboratory_ss ON HRH_CURR_laboratory_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=2213128
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_laboratory_srs ON HRH_CURR_laboratory_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=2213129
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_laboratory_srnms ON HRH_CURR_laboratory_srnms.sourceid=ou.organisationunitid
 
 /*HRH_CURR_Management*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472664
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_management_ss ON HRH_CURR_management_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472666
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_management_srs ON HRH_CURR_management_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472654
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_management_srnms ON HRH_CURR_management_srnms.sourceid=ou.organisationunitid
 
 /*HRH_CURR_socialservices*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472668
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=3459701))
  group by sourceid) as HRH_CURR_socialservices_ss on HRH_CURR_socialservices_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472657
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=3459701))
  group by sourceid) as HRH_CURR_socialservices_srs on HRH_CURR_socialservices_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472667
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=3459701))
  group by sourceid) as HRH_CURR_socialservices_srnms on HRH_CURR_socialservices_srnms.sourceid=ou.organisationunitid
 
 /*HRH_CURR_lay*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472665
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_lay_ss ON HRH_CURR_lay_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472656
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_lay_srs ON HRH_CURR_lay_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472651
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_lay_srnms ON HRH_CURR_lay_srnms.sourceid=ou.organisationunitid
 
/*HRH_CURR_other*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472655
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_other_ss ON HRH_CURR_other_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472660
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_other_srs ON HRH_CURR_other_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=472673
 AND categoryoptioncomboid=472658
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_other_srnms ON HRH_CURR_other_srnms.sourceid=ou.organisationunitid
 
 
  /*HRH_CURR_spent_Clinical*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472662
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_clinical_ss ON HRH_CURR_spent_clinical_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472659
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_clinical_srs ON HRH_CURR_spent_clinical_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472661
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_clinical_srnms ON HRH_CURR_spent_clinical_srnms.sourceid=ou.organisationunitid
 
  /*HRH_CURR_spent_Pharmacy*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=2213130
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_pharmacy_ss ON HRH_CURR_spent_pharmacy_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=2213131
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_pharmacy_srs ON HRH_CURR_spent_pharmacy_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=2213132
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_pharmacy_srnms ON HRH_CURR_spent_pharmacy_srnms.sourceid=ou.organisationunitid
 
  /*HRH_CURR_spent_Laboratory*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=2213127
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_laboratory_ss ON HRH_CURR_spent_laboratory_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=2213128
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_laboratory_srs ON HRH_CURR_spent_laboratory_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=2213129
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_laboratory_srnms ON HRH_CURR_spent_laboratory_srnms.sourceid=ou.organisationunitid
 
 /*HRH_CURR_spent_Management*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472664
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_management_ss ON HRH_CURR_spent_management_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472666
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_management_srs ON HRH_CURR_spent_management_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472654
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_management_srnms ON HRH_CURR_spent_management_srnms.sourceid=ou.organisationunitid
 
 /*HRH_CURR_spent_socialservices*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=2213032
  and categoryoptioncomboid=472668
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=3459701))
  group by sourceid) as HRH_CURR_spent_socialservices_ss on HRH_CURR_spent_socialservices_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=2213032
  and categoryoptioncomboid=472657
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=3459701))
  group by sourceid) as HRH_CURR_spent_socialservices_srs on HRH_CURR_spent_socialservices_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=2213032
  and categoryoptioncomboid=472667
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=3459701))
  group by sourceid) as HRH_CURR_spent_socialservices_srnms on HRH_CURR_spent_socialservices_srnms.sourceid=ou.organisationunitid
 
 /*HRH_CURR_spent_lay*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472665
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_lay_ss ON HRH_CURR_spent_lay_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472656
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_lay_srs ON HRH_CURR_spent_lay_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472651
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_lay_srnms ON HRH_CURR_spent_lay_srnms.sourceid=ou.organisationunitid
 
/*HRH_CURR_spent_other*/
LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472655
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_other_ss ON HRH_CURR_spent_other_ss.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472660
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_other_srs ON HRH_CURR_spent_other_srs.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=2213032
 AND categoryoptioncomboid=472658
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS HRH_CURR_spent_other_srnms ON HRH_CURR_spent_other_srnms.sourceid=ou.organisationunitid
 
 /*EMR_SITE*/
 LEFT OUTER JOIN (
 SELECT sourceid, value AS value
 FROM datavalue
 WHERE dataelementid=523786
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 ) AS EMR_SITE_hiv_testing ON EMR_SITE_hiv_testing.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, value AS value
 FROM datavalue
 WHERE dataelementid=523784
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 ) AS EMR_SITE_ct ON EMR_SITE_ct.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, value AS value
 FROM datavalue
 WHERE dataelementid=523779
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 ) AS EMR_SITE_anc ON EMR_SITE_anc.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, value AS value
 FROM datavalue
 WHERE dataelementid=523785
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 ) AS EMR_SITE_infant ON EMR_SITE_infant.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, value AS value
 FROM datavalue
 WHERE dataelementid=523791
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 ) AS EMR_SITE_hivtb ON EMR_SITE_hivtb.sourceid=ou.organisationunitid
 
 /*LAB_PTCQI (Lab-based)*/
 /*CQI*/
 /*HIV Testing*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168747
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivtest_noparticipatiON ON LAB_PTCQI_lab_cqi_hivtest_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168746
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivtest_audited ON LAB_PTCQI_lab_cqi_hivtest_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168745
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivtest_accredited ON LAB_PTCQI_lab_cqi_hivtest_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168744
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivtest_fullyaccredited ON LAB_PTCQI_lab_cqi_hivtest_fullyaccredited.sourceid=ou.organisationunitid
 
 /*HIV IVT*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168751
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivivt_noparticipatiON ON LAB_PTCQI_lab_cqi_hivivt_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168750
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivivt_audited ON LAB_PTCQI_lab_cqi_hivivt_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168749
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivivt_accredited ON LAB_PTCQI_lab_cqi_hivivt_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168748
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_hivivt_fullyaccredited ON LAB_PTCQI_lab_cqi_hivivt_fullyaccredited.sourceid=ou.organisationunitid
 
 /*HIV Viral Load*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168755
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_load_noparticipatiON ON LAB_PTCQI_lab_cqi_load_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168754
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_load_audited ON LAB_PTCQI_lab_cqi_load_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168753
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_load_accredited ON LAB_PTCQI_lab_cqi_load_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168752
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_load_fullyaccredited ON LAB_PTCQI_lab_cqi_load_fullyaccredited.sourceid=ou.organisationunitid
 
 /*TB Xpert*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168759
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbxpert_noparticipatiON ON LAB_PTCQI_lab_cqi_tbxpert_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168758
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbxpert_audited ON LAB_PTCQI_lab_cqi_tbxpert_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168757
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbxpert_accredited ON LAB_PTCQI_lab_cqi_tbxpert_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168756
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited ON LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited.sourceid=ou.organisationunitid
 
 /*TB AFB*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168763
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbafb_noparticipatiON ON LAB_PTCQI_lab_cqi_tbafb_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168762
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbafb_audited ON LAB_PTCQI_lab_cqi_tbafb_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168761
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbafb_accredited ON LAB_PTCQI_lab_cqi_tbafb_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168760
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbafb_fullyaccredited ON LAB_PTCQI_lab_cqi_tbafb_fullyaccredited.sourceid=ou.organisationunitid
 
 /*TB Culture*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168767
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbculture_noparticipatiON ON LAB_PTCQI_lab_cqi_tbculture_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168766
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbculture_audited ON LAB_PTCQI_lab_cqi_tbculture_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168765
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbculture_accredited ON LAB_PTCQI_lab_cqi_tbculture_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168764
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_tbculture_fullyaccredited ON LAB_PTCQI_lab_cqi_tbculture_fullyaccredited.sourceid=ou.organisationunitid
 
 /*TB Culture*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168771
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_cd4_noparticipatiON ON LAB_PTCQI_lab_cqi_cd4_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168770
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_cd4_audited ON LAB_PTCQI_lab_cqi_cd4_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168769
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_cd4_accredited ON LAB_PTCQI_lab_cqi_cd4_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168768
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_cd4_fullyaccredited ON LAB_PTCQI_lab_cqi_cd4_fullyaccredited.sourceid=ou.organisationunitid
 
 /*Other*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168775
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_other_noparticipatiON ON LAB_PTCQI_lab_cqi_other_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168774
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_other_audited ON LAB_PTCQI_lab_cqi_other_audited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168773
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_other_accredited ON LAB_PTCQI_lab_cqi_other_accredited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168777
 AND categoryoptioncomboid=1168772
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cqi_other_fullyaccredited ON LAB_PTCQI_lab_cqi_other_fullyaccredited.sourceid=ou.organisationunitid
 
 /*PT*/
/*HIV Testing*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169326
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_hivtest_noparticipatiON ON LAB_PTCQI_lab_pt_hivtest_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169325
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_hivtest_notpassed ON LAB_PTCQI_lab_pt_hivtest_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169324
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_hivtest_passed ON LAB_PTCQI_lab_pt_hivtest_passed.sourceid=ou.organisationunitid
 
 /*HIV IVT*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169329
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_hivivt_noparticipatiON ON LAB_PTCQI_lab_pt_hivivt_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169328
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_hivivt_notpassed ON LAB_PTCQI_lab_pt_hivivt_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169327
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_hivivt_passed ON LAB_PTCQI_lab_pt_hivivt_passed.sourceid=ou.organisationunitid
 
 /*HIV Viral Load*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169332
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_load_noparticipatiON ON LAB_PTCQI_lab_pt_load_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169331
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_load_notpassed ON LAB_PTCQI_lab_pt_load_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169330
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_load_passed ON LAB_PTCQI_lab_pt_load_passed.sourceid=ou.organisationunitid
 
 /*TB Xpert*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169335
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbxpert_noparticipatiON ON LAB_PTCQI_lab_pt_tbxpert_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169334
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbxpert_notpassed ON LAB_PTCQI_lab_pt_tbxpert_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169333
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbxpert_passed ON LAB_PTCQI_lab_pt_tbxpert_passed.sourceid=ou.organisationunitid
 
 /*TB AFB*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169338
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbafb_noparticipatiON ON LAB_PTCQI_lab_pt_tbafb_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169337
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbafb_notpassed ON LAB_PTCQI_lab_pt_tbafb_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169336
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbafb_passed ON LAB_PTCQI_lab_pt_tbafb_passed.sourceid=ou.organisationunitid

 
 /*TB Culture*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169341
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbculture_noparticipatiON ON LAB_PTCQI_lab_pt_tbculture_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169340
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbculture_notpassed ON LAB_PTCQI_lab_pt_tbculture_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169339
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_tbculture_passed ON LAB_PTCQI_lab_pt_tbculture_passed.sourceid=ou.organisationunitid
 
 /*CD4*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169344
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_cd4_noparticipatiON ON LAB_PTCQI_lab_pt_cd4_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169343
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_cd4_notpassed ON LAB_PTCQI_lab_pt_cd4_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169342
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_cd4_passed ON LAB_PTCQI_lab_pt_cd4_passed.sourceid=ou.organisationunitid
 
 /*Other*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169347
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_other_noparticipatiON ON LAB_PTCQI_lab_pt_other_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169346
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_other_notpassed ON LAB_PTCQI_lab_pt_other_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168810
 AND categoryoptioncomboid=1169345
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_pt_other_passed ON LAB_PTCQI_lab_pt_other_passed.sourceid=ou.organisationunitid

 /*Volume*/
/*HIV Testing*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168813
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_hivtest ON LAB_PTCQI_lab_hivtest.sourceid=ou.organisationunitid

/*HIV IVT*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168814
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_hivivt ON LAB_PTCQI_lab_hivivt.sourceid=ou.organisationunitid

/*HIV Viral Load*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168815
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_load ON LAB_PTCQI_lab_load.sourceid=ou.organisationunitid

/*TB Xpert*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168816
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_tbxpert ON LAB_PTCQI_lab_tbxpert.sourceid=ou.organisationunitid

/*TB AFB*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168817
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_tbafb ON LAB_PTCQI_lab_tbafb.sourceid=ou.organisationunitid

/*TB Culture*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168818
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_tbculture ON LAB_PTCQI_lab_tbculture.sourceid=ou.organisationunitid

/*CD4*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168819
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_cd4 ON LAB_PTCQI_lab_cd4.sourceid=ou.organisationunitid

 /*Other*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168823
 AND categoryoptioncomboid=1168820
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_lab_other ON LAB_PTCQI_lab_other.sourceid=ou.organisationunitid
 
 /*LAB_PTCQI (POCT-based)*/
 /*CQI*/
 /*HIV Testing*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169353
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivtest_noparticipatiON ON LAB_PTCQI_poct_cqi_hivtest_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169352
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivtest_notaudited ON LAB_PTCQI_poct_cqi_hivtest_notaudited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169349
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivtest_01 ON LAB_PTCQI_poct_cqi_hivtest_01.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169350
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivtest_23 ON LAB_PTCQI_poct_cqi_hivtest_23.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169351
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivtest_45 ON LAB_PTCQI_poct_cqi_hivtest_45.sourceid=ou.organisationunitid
 
 /*HIV IVT*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169358
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivivt_noparticipatiON ON LAB_PTCQI_poct_cqi_hivivt_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169357
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivivt_notaudited ON LAB_PTCQI_poct_cqi_hivivt_notaudited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169354
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivivt_01 ON LAB_PTCQI_poct_cqi_hivivt_01.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169355
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivivt_23 ON LAB_PTCQI_poct_cqi_hivivt_23.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169356
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_hivivt_45 ON LAB_PTCQI_poct_cqi_hivivt_45.sourceid=ou.organisationunitid
 
 /*Viral Load*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169363
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_load_noparticipatiON ON LAB_PTCQI_poct_cqi_load_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169362
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_load_notaudited ON LAB_PTCQI_poct_cqi_load_notaudited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169359
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_load_01 ON LAB_PTCQI_poct_cqi_load_01.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169360
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_load_23 ON LAB_PTCQI_poct_cqi_load_23.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169361
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_load_45 ON LAB_PTCQI_poct_cqi_load_45.sourceid=ou.organisationunitid
 
 /*TB Xpert*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169368
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbxpert_noparticipatiON ON LAB_PTCQI_poct_cqi_tbxpert_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169367
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbxpert_notaudited ON LAB_PTCQI_poct_cqi_tbxpert_notaudited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169364
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbxpert_01 ON LAB_PTCQI_poct_cqi_tbxpert_01.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169365
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbxpert_23 ON LAB_PTCQI_poct_cqi_tbxpert_23.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169366
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbxpert_45 ON LAB_PTCQI_poct_cqi_tbxpert_45.sourceid=ou.organisationunitid
 
 /*TB AFB*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169373
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbafb_noparticipatiON ON LAB_PTCQI_poct_cqi_tbafb_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169372
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbafb_notaudited ON LAB_PTCQI_poct_cqi_tbafb_notaudited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169369
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbafb_01 ON LAB_PTCQI_poct_cqi_tbafb_01.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169370
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbafb_23 ON LAB_PTCQI_poct_cqi_tbafb_23.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169371
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_tbafb_45 ON LAB_PTCQI_poct_cqi_tbafb_45.sourceid=ou.organisationunitid
 
 /*CD4*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169383
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_cd4_noparticipatiON ON LAB_PTCQI_poct_cqi_cd4_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169382
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_cd4_notaudited ON LAB_PTCQI_poct_cqi_cd4_notaudited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169379
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_cd4_01 ON LAB_PTCQI_poct_cqi_cd4_01.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169380
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_cd4_23 ON LAB_PTCQI_poct_cqi_cd4_23.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169381
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_cd4_45 ON LAB_PTCQI_poct_cqi_cd4_45.sourceid=ou.organisationunitid
 
 /*Other*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169388
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_other_noparticipatiON ON LAB_PTCQI_poct_cqi_other_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169387
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_other_notaudited ON LAB_PTCQI_poct_cqi_other_notaudited.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169384
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_other_01 ON LAB_PTCQI_poct_cqi_other_01.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169385
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_other_23 ON LAB_PTCQI_poct_cqi_other_23.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168873
 AND categoryoptioncomboid=1169386
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cqi_other_45 ON LAB_PTCQI_poct_cqi_other_45.sourceid=ou.organisationunitid
 
 /*PT*/
 /*HIV Testing*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169326
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_hivtest_noparticipatiON ON LAB_PTCQI_poct_pt_hivtest_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169325
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_hivtest_notpassed ON LAB_PTCQI_poct_pt_hivtest_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169324
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_hivtest_passed ON LAB_PTCQI_poct_pt_hivtest_passed.sourceid=ou.organisationunitid
 
 /*HIV IVT*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169329
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_hivivt_noparticipatiON ON LAB_PTCQI_poct_pt_hivivt_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169328
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_hivivt_notpassed ON LAB_PTCQI_poct_pt_hivivt_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169327
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_hivivt_passed ON LAB_PTCQI_poct_pt_hivivt_passed.sourceid=ou.organisationunitid
 
 /*HIV Viral Load*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169332
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_load_noparticipatiON ON LAB_PTCQI_poct_pt_load_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169331
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_load_notpassed ON LAB_PTCQI_poct_pt_load_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169330
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_load_passed ON LAB_PTCQI_poct_pt_load_passed.sourceid=ou.organisationunitid
 
 /*TB Xpert*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169335
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_tbxpert_noparticipatiON ON LAB_PTCQI_poct_pt_tbxpert_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169334
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_tbxpert_notpassed ON LAB_PTCQI_poct_pt_tbxpert_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169333
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_tbxpert_passed ON LAB_PTCQI_poct_pt_tbxpert_passed.sourceid=ou.organisationunitid
 
 /*TB AFB*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169338
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_tbafb_noparticipatiON ON LAB_PTCQI_poct_pt_tbafb_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169337
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_tbafb_notpassed ON LAB_PTCQI_poct_pt_tbafb_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169336
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_tbafb_passed ON LAB_PTCQI_poct_pt_tbafb_passed.sourceid=ou.organisationunitid

 /*CD4*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169344
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_cd4_noparticipatiON ON LAB_PTCQI_poct_pt_cd4_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169343
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_cd4_notpassed ON LAB_PTCQI_poct_pt_cd4_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169342
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_cd4_passed ON LAB_PTCQI_poct_pt_cd4_passed.sourceid=ou.organisationunitid
 
 /*Other*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169347
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_other_noparticipatiON ON LAB_PTCQI_poct_pt_other_noparticipation.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169346
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_other_notpassed ON LAB_PTCQI_poct_pt_other_notpassed.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168890
 AND categoryoptioncomboid=1169345
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_pt_other_passed ON LAB_PTCQI_poct_pt_other_passed.sourceid=ou.organisationunitid
 
 /*Volume*/
/*HIV Testing*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168905
 AND categoryoptioncomboid=1168813
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_hivtest ON LAB_PTCQI_poct_hivtest.sourceid=ou.organisationunitid

/*HIV IVT*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168905
 AND categoryoptioncomboid=1168814
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_hivivt ON LAB_PTCQI_poct_hivivt.sourceid=ou.organisationunitid

/*HIV Viral Load*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168905
 AND categoryoptioncomboid=1168815
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_load ON LAB_PTCQI_poct_load.sourceid=ou.organisationunitid

/*TB Xpert*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168905
 AND categoryoptioncomboid=1168816
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_tbxpert ON LAB_PTCQI_poct_tbxpert.sourceid=ou.organisationunitid

/*TB AFB*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168905
 AND categoryoptioncomboid=1168817
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_tbafb ON LAB_PTCQI_poct_tbafb.sourceid=ou.organisationunitid

/*CD4*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168905
 AND categoryoptioncomboid=1168819
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_cd4 ON LAB_PTCQI_poct_cd4.sourceid=ou.organisationunitid

 /*Other*/
 LEFT OUTER JOIN (
 SELECT sourceid, SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=1168905
 AND categoryoptioncomboid=1168820
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT financialoct FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS LAB_PTCQI_poct_other ON LAB_PTCQI_poct_other.sourceid=ou.organisationunitid
 
 
/*TX_RTT PL_HIV*/
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497207
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_PLHIV_total ON TX_RTT_PLHIV_total.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497208
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_PLHIV_men12 ON TX_RTT_PLHIV_men12.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497209
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_PLHIV_mai12 ON TX_RTT_PLHIV_mai12.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497210
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TX_RTT_PLHIV_unk ON TX_RTT_PLHIV_unk.sourceid=ou.organisationunitid
 
 /*TRF_IN*/
LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497206
 AND categoryoptioncomboid=16
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_num ON TRF_IN_num.sourceid=ou.organisationunitid

/*Female*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538076
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_men1_f ON TRF_IN_men1_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538078
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_1_4_f ON TRF_IN_1_4_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538080
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_5_9_f ON TRF_IN_5_9_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444114
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_10_14_f ON TRF_IN_10_14_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444116
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_15_19_f ON TRF_IN_15_19_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444118
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_20_24_f ON TRF_IN_20_24_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=603097
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_25_29_f ON TRF_IN_25_29_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=603099
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_30_34_f ON TRF_IN_30_34_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=603101
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_35_39_f ON TRF_IN_35_39_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538082
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_40_44_f ON TRF_IN_40_44_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538084
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_45_49_f ON TRF_IN_45_49_f.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444117
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_50_f ON TRF_IN_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538075
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_men1_m ON TRF_IN_men1_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538077
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_1_4_m ON TRF_IN_1_4_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538079
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_5_9_m ON TRF_IN_5_9_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444123
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_10_14_m ON TRF_IN_10_14_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444119
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_15_19_m ON TRF_IN_15_19_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444120
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_20_24_m ON TRF_IN_20_24_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=603096
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_25_29_m ON TRF_IN_25_29_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=603098
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_30_34_m ON TRF_IN_30_34_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=603100
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_35_39_m ON TRF_IN_35_39_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538081
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_40_44_m ON TRF_IN_40_44_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=1538083
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_45_49_m ON TRF_IN_45_49_m.sourceid=ou.organisationunitid
 
 LEFT OUTER JOIN (
 SELECT sourceid,SUM(CAST(value AS DOUBLE PRECISION)) AS value
 FROM datavalue
 WHERE dataelementid=3497205
 AND categoryoptioncomboid=444121
 AND periodid=(SELECT ps.periodid FROM _periodstructure ps WHERE iso=(SELECT quarterly FROM _periodstructure WHERE periodid=3459701))
 GROUP BY sourceid) AS TRF_IN_50_m ON TRF_IN_50_m.sourceid=ou.organisationunitid
 
 
 
 
WHERE ous.level=4 AND ous.idlevel2=110 AND ou.closeddate IS NULL AND ou.code IS NOT NULL ORDER BY district.name || ' / ' || ou.name ASC;