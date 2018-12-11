select district.name || ' / ' || ou.name as facility,
'' AS placeholder1,
/*Quarterly*/
/*HTS_TST_num*/
(
/*HTS_TST (Facility) - PITC Inpatient Services*/
COALESCE(atip_enf_0_8_f_pos.value,0)+
COALESCE(atip_enf_0_8_f_neg.value,0)+
COALESCE(atip_enf_0_8_m_pos.value,0)+
COALESCE(atip_enf_0_8_m_neg.value,0)+
(COALESCE(atip_enf_9_18_f_pos.value,0)+COALESCE(atip_enf_19_4_f_pos.value,0))+
(COALESCE(atip_enf_9_18_f_neg.value,0)+COALESCE(atip_enf_19_4_f_neg.value,0))+
(COALESCE(atip_enf_9_18_m_pos.value,0)+COALESCE(atip_enf_19_4_m_pos.value,0))+
(COALESCE(atip_enf_9_18_m_neg.value,0)+COALESCE(atip_enf_19_4_m_neg.value,0))+
COALESCE(atip_enf_5_9_f_pos.value,0)+
COALESCE(atip_enf_5_9_f_neg.value,0)+
COALESCE(atip_enf_5_9_m_pos.value,0)+
COALESCE(atip_enf_5_9_m_neg.value,0)+
COALESCE(atip_enf_10_14_f_pos.value,0)+
COALESCE(atip_enf_10_14_f_neg.value,0)+
COALESCE(atip_enf_10_14_m_pos.value,0)+
COALESCE(atip_enf_10_14_m_neg.value,0)+
COALESCE(atip_enf_15_19_f_pos.value,0)+
COALESCE(atip_enf_15_19_f_neg.value,0)+
COALESCE(atip_enf_15_19_m_pos.value,0)+
COALESCE(atip_enf_15_19_m_neg.value,0)+
COALESCE(atip_enf_20_24_f_pos.value,0)+
COALESCE(atip_enf_20_24_f_neg.value,0)+
COALESCE(atip_enf_20_24_m_pos.value,0)+
COALESCE(atip_enf_20_24_m_neg.value,0)+
(COALESCE(atip_enf_25_29_f_pos.value,0)+COALESCE(atip_enf_30_49_f_pos.value,0))+
(COALESCE(atip_enf_25_29_f_neg.value,0)+COALESCE(atip_enf_30_49_f_neg.value,0))+
(COALESCE(atip_enf_25_29_m_pos.value,0)+COALESCE(atip_enf_30_49_m_pos.value,0))+
(COALESCE(atip_enf_25_29_m_neg.value,0)+COALESCE(atip_enf_30_49_m_neg.value,0))+
COALESCE(atip_enf_50_f_pos.value,0)+
COALESCE(atip_enf_50_f_neg.value,0)+
COALESCE(atip_enf_50_m_pos.value,0)+
COALESCE(atip_enf_50_m_neg.value,0)+
/*HTS_TST (Facility)-PITC Pediatric Services*/
COALESCE(HTS_TST_Pediatric_pos.value,0)+
COALESCE(HTS_TST_Pediatric_neg.value,0)+
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
(COALESCE(mat_men1_pos.value,0)+COALESCE(atip_cpp_0_8_f_pos.value,0))+
(COALESCE(mat_men1_neg.value,0)+COALESCE(atip_cpp_0_8_f_neg.value,0))+
(COALESCE(mat_1_4_pos.value,0)+COALESCE(atip_cpp_9_18_f_pos.value,0)+COALESCE(atip_cpp_19_4_f_pos.value,0))+
(COALESCE(mat_1_4_neg.value,0)+COALESCE(atip_cpp_9_18_f_neg.value,0)+COALESCE(atip_cpp_19_4_f_neg.value,0))+
(COALESCE(mat_5_9_pos.value,0)+COALESCE(atip_cpp_5_9_f_pos.value,0))+
(COALESCE(mat_5_9_neg.value,0)+COALESCE(atip_cpp_5_9_f_neg.value,0))+
(COALESCE(mat_10_14_pos.value,0)+COALESCE(atip_cpp_10_14_f_pos.value,0))+
(COALESCE(mat_10_14_neg.value,0)+COALESCE(atip_cpp_10_14_f_neg.value,0))+
(COALESCE(mat_15_19_pos.value,0)+COALESCE(atip_cpp_15_19_f_pos.value,0))+
(COALESCE(mat_15_19_neg.value,0)+COALESCE(atip_cpp_15_19_f_neg.value,0))+
(COALESCE(mat_20_24_pos.value,0)+COALESCE(atip_cpp_20_24_f_pos.value,0))+
(COALESCE(mat_20_24_neg.value,0)+COALESCE(atip_cpp_20_24_f_neg.value,0))+
(COALESCE(mat_25_29_pos.value,0)+COALESCE(mat_30_34_pos.value,0)+COALESCE(mat_35_39_pos.value,0)+COALESCE(mat_40_44_pos.value,0)+COALESCE(mat_45_49_pos.value,0)+COALESCE(atip_cpp_25_29_f_pos.value,0)+COALESCE(atip_cpp_30_49_f_pos.value,0))+
(COALESCE(mat_25_29_neg.value,0)+COALESCE(mat_30_34_neg.value,0)+COALESCE(mat_35_39_neg.value,0)+COALESCE(mat_40_44_neg.value,0)+COALESCE(mat_45_49_neg.value,0)+COALESCE(atip_cpp_25_29_f_neg.value,0)+COALESCE(atip_cpp_30_49_f_neg.value,0))+
(COALESCE(mat_50_pos.value,0)+COALESCE(atip_cpp_50_f_pos.value,0))+
(COALESCE(mat_50_neg.value,0)+COALESCE(atip_cpp_50_f_neg.value,0))+
/*HTS_TST (Facility)-PITC Emergency Ward*/
COALESCE(atip_bso_0_8_f_pos.value,0)+
COALESCE(atip_bso_0_8_f_neg.value,0)+
COALESCE(atip_bso_0_8_m_pos.value,0)+
COALESCE(atip_bso_0_8_m_neg.value,0)+
(COALESCE(atip_bso_9_18_f_pos.value,0)+COALESCE(atip_bso_19_4_f_pos.value,0))+
(COALESCE(atip_bso_9_18_f_neg.value,0)+COALESCE(atip_bso_19_4_f_neg.value,0))+
(COALESCE(atip_bso_9_18_m_pos.value,0)+COALESCE(atip_bso_19_4_m_pos.value,0))+
(COALESCE(atip_bso_9_18_m_neg.value,0)+COALESCE(atip_bso_19_4_m_neg.value,0))+
COALESCE(atip_bso_5_9_f_pos.value,0)+
COALESCE(atip_bso_5_9_f_neg.value,0)+
COALESCE(atip_bso_5_9_m_pos.value,0)+
COALESCE(atip_bso_5_9_m_neg.value,0)+
COALESCE(atip_bso_10_14_f_pos.value,0)+
COALESCE(atip_bso_10_14_f_neg.value,0)+
COALESCE(atip_bso_10_14_m_pos.value,0)+
COALESCE(atip_bso_10_14_m_neg.value,0)+
COALESCE(atip_bso_15_19_f_pos.value,0)+
COALESCE(atip_bso_15_19_f_neg.value,0)+
COALESCE(atip_bso_15_19_m_pos.value,0)+
COALESCE(atip_bso_15_19_m_neg.value,0)+
COALESCE(atip_bso_20_24_f_pos.value,0)+
COALESCE(atip_bso_20_24_f_neg.value,0)+
COALESCE(atip_bso_20_24_m_pos.value,0)+
COALESCE(atip_bso_20_24_m_neg.value,0)+
(COALESCE(atip_bso_25_29_f_pos.value,0)+COALESCE(atip_bso_30_49_f_pos.value,0))+
(COALESCE(atip_bso_25_29_f_neg.value,0)+COALESCE(atip_bso_30_49_f_neg.value,0))+
(COALESCE(atip_bso_25_29_m_pos.value,0)+COALESCE(atip_bso_30_49_m_pos.value,0))+
(COALESCE(atip_bso_25_29_m_neg.value,0)+COALESCE(atip_bso_30_49_m_neg.value,0))+
COALESCE(atip_bso_50_f_pos.value,0)+
COALESCE(atip_bso_50_f_neg.value,0)+
COALESCE(atip_bso_50_m_pos.value,0)+
COALESCE(atip_bso_50_m_neg.value,0)+
/*HTS_TST (Facility)-Other PITC*/
COALESCE(cpn_m_pos.value,0)+
COALESCE(cpn_m_neg.value,0)+
COALESCE(atip_0_8_f_pos.value,0)+
COALESCE(atip_0_8_f_neg.value,0)+
COALESCE(atip_0_8_m_pos.value,0)+
COALESCE(atip_0_8_m_neg.value,0)+
(COALESCE(atip_9_18_f_pos.value,0)+COALESCE(atip_19_4_f_pos.value,0))+
(COALESCE(atip_9_18_f_neg.value,0)+COALESCE(atip_19_4_f_neg.value,0))+
(COALESCE(atip_9_18_m_pos.value,0)+COALESCE(atip_19_4_m_pos.value,0))+
(COALESCE(atip_9_18_m_neg.value,0)+COALESCE(atip_19_4_m_neg.value,0))+
COALESCE(atip_5_9_f_pos.value,0)+
COALESCE(atip_5_9_f_neg.value,0)+
COALESCE(atip_5_9_m_pos.value,0)+
COALESCE(atip_5_9_m_neg.value,0)+
COALESCE(atip_10_14_f_pos.value,0)+
COALESCE(atip_10_14_f_neg.value,0)+
COALESCE(atip_10_14_m_pos.value,0)+
COALESCE(atip_10_14_m_neg.value,0)+
COALESCE(atip_15_19_f_pos.value,0)+
COALESCE(atip_15_19_f_neg.value,0)+
COALESCE(atip_15_19_m_pos.value,0)+
COALESCE(atip_15_19_m_neg.value,0)+
COALESCE(atip_20_24_f_pos.value,0)+
COALESCE(atip_20_24_f_neg.value,0)+
COALESCE(atip_20_24_m_pos.value,0)+
COALESCE(atip_20_24_m_neg.value,0)+
(COALESCE(atip_25_29_f_pos.value,0)+COALESCE(atip_30_49_f_pos.value,0))+
(COALESCE(atip_25_29_f_neg.value,0)+COALESCE(atip_30_49_f_neg.value,0))+
(COALESCE(atip_25_29_m_pos.value,0)+COALESCE(atip_30_49_m_pos.value,0))+
(COALESCE(atip_25_29_m_neg.value,0)+COALESCE(atip_30_49_m_neg.value,0))+
(COALESCE(atip_50_f_pos.value,0))+
(COALESCE(atip_50_f_neg.value,0))+
COALESCE(atip_50_m_pos.value,0)+
COALESCE(atip_50_m_neg.value,0)+
/*HTS_TST (Facility)-VCT*/
COALESCE(ats_0_8_f_pos.value,0)+
COALESCE(ats_0_8_f_neg.value,0)+
COALESCE(ats_0_8_m_pos.value,0)+
COALESCE(ats_0_8_m_neg.value,0)+
(COALESCE(ats_9_18_f_pos.value,0)+COALESCE(ats_19_4_f_pos.value,0))+
(COALESCE(ats_9_18_f_neg.value,0)+COALESCE(ats_19_4_f_neg.value,0))+
(COALESCE(ats_9_18_m_pos.value,0)+COALESCE(ats_19_4_m_pos.value,0))+
(COALESCE(ats_9_18_m_neg.value,0)+COALESCE(ats_19_4_m_neg.value,0))+
COALESCE(ats_5_9_f_pos.value,0)+
COALESCE(ats_5_9_f_neg.value,0)+
COALESCE(ats_5_9_m_pos.value,0)+
COALESCE(ats_5_9_m_neg.value,0)+
COALESCE(ats_10_14_f_pos.value,0)+
COALESCE(ats_10_14_f_neg.value,0)+
COALESCE(ats_10_14_m_pos.value,0)+
COALESCE(ats_10_14_m_neg.value,0)+
COALESCE(ats_15_19_f_pos.value,0)+
COALESCE(ats_15_19_f_neg.value,0)+
COALESCE(ats_15_19_m_pos.value,0)+
COALESCE(ats_15_19_m_neg.value,0)+
COALESCE(ats_20_24_f_pos.value,0)+
COALESCE(ats_20_24_f_neg.value,0)+
COALESCE(ats_20_24_m_pos.value,0)+
COALESCE(ats_20_24_m_neg.value,0)+
(COALESCE(ats_25_29_f_pos.value,0)+COALESCE(ats_30_49_f_pos.value,0))+
(COALESCE(ats_25_29_f_neg.value,0)+COALESCE(ats_30_49_f_neg.value,0))+
(COALESCE(ats_25_29_m_pos.value,0)+COALESCE(ats_30_49_m_pos.value,0))+
(COALESCE(ats_25_29_m_neg.value,0)+COALESCE(ats_30_49_m_neg.value,0))+
COALESCE(ats_50_f_pos.value,0)+
COALESCE(ats_50_f_neg.value,0)+
COALESCE(ats_50_m_pos.value,0)+
COALESCE(ats_50_m_neg.value,0)+
/*Index Testing*/
(COALESCE(atip_index_0_8_f_pos.value,0)+COALESCE(ats_index_0_8_f_pos.value,0))+
(COALESCE(atip_index_0_8_f_neg.value,0)+COALESCE(ats_index_0_8_f_neg.value,0))+
(COALESCE(atip_index_0_8_m_pos.value,0)+COALESCE(ats_index_0_8_m_pos.value,0))+
(COALESCE(atip_index_0_8_m_neg.value,0)+COALESCE(ats_index_0_8_m_neg.value,0))+
(COALESCE(atip_index_9_18_f_pos.value,0)+COALESCE(atip_index_19_4_f_pos.value,0)+COALESCE(ats_index_9_18_f_pos.value,0)+COALESCE(ats_index_19_4_f_pos.value,0))+
(COALESCE(atip_index_9_18_f_neg.value,0)+COALESCE(atip_index_19_4_f_neg.value,0)+COALESCE(ats_index_9_18_f_neg.value,0)+COALESCE(ats_index_19_4_f_neg.value,0))+
(COALESCE(atip_index_9_18_m_pos.value,0)+COALESCE(atip_index_19_4_m_pos.value,0)+COALESCE(ats_index_9_18_m_pos.value,0)+COALESCE(ats_index_19_4_m_pos.value,0))+
(COALESCE(atip_index_9_18_m_neg.value,0)+COALESCE(atip_index_19_4_m_neg.value,0)+COALESCE(ats_index_9_18_m_neg.value,0)+COALESCE(ats_index_19_4_m_neg.value,0))+
(COALESCE(atip_index_5_9_f_pos.value,0)+COALESCE(ats_index_5_9_f_pos.value,0))+
(COALESCE(atip_index_5_9_f_neg.value,0)+COALESCE(ats_index_5_9_f_neg.value,0))+
(COALESCE(atip_index_5_9_m_pos.value,0)+COALESCE(ats_index_5_9_m_pos.value,0))+
(COALESCE(atip_index_5_9_m_neg.value,0)+COALESCE(ats_index_5_9_m_neg.value,0))+
(COALESCE(atip_index_10_14_f_pos.value,0)+COALESCE(ats_index_10_14_f_pos.value,0))+
(COALESCE(atip_index_10_14_f_neg.value,0)+COALESCE(ats_index_10_14_f_neg.value,0))+
(COALESCE(atip_index_10_14_m_pos.value,0)+COALESCE(ats_index_10_14_m_pos.value,0))+
(COALESCE(atip_index_10_14_m_neg.value,0)+COALESCE(ats_index_10_14_m_neg.value,0))+
(COALESCE(atip_index_15_19_f_pos.value,0)+COALESCE(ats_index_15_19_f_pos.value,0))+
(COALESCE(atip_index_15_19_f_neg.value,0)+COALESCE(ats_index_15_19_f_neg.value,0))+
(COALESCE(atip_index_15_19_m_pos.value,0)+COALESCE(ats_index_15_19_m_pos.value,0))+
(COALESCE(atip_index_15_19_m_neg.value,0)+COALESCE(ats_index_15_19_m_neg.value,0))+
(COALESCE(atip_index_20_24_f_pos.value,0)+COALESCE(ats_index_20_24_f_pos.value,0))+
(COALESCE(atip_index_20_24_f_neg.value,0)+COALESCE(ats_index_20_24_f_neg.value,0))+
(COALESCE(atip_index_20_24_m_pos.value,0)+COALESCE(ats_index_20_24_m_pos.value,0))+
(COALESCE(atip_index_20_24_m_neg.value,0)+COALESCE(ats_index_20_24_m_neg.value,0))+
(COALESCE(atip_index_25_29_f_pos.value,0)+COALESCE(atip_index_30_49_f_pos.value,0)+COALESCE(ats_index_25_29_f_pos.value,0)+COALESCE(ats_index_30_49_f_pos.value,0))+
(COALESCE(atip_index_25_29_f_neg.value,0)+COALESCE(atip_index_30_49_f_neg.value,0)+COALESCE(ats_index_25_29_f_neg.value,0)+COALESCE(ats_index_30_49_f_neg.value,0))+
(COALESCE(atip_index_25_29_m_pos.value,0)+COALESCE(atip_index_30_49_m_pos.value,0)+COALESCE(ats_index_25_29_m_pos.value,0)+COALESCE(ats_index_30_49_m_pos.value,0))+
(COALESCE(atip_index_25_29_m_neg.value,0)+COALESCE(atip_index_30_49_m_neg.value,0)+COALESCE(ats_index_25_29_m_neg.value,0)+COALESCE(ats_index_30_49_m_neg.value,0))+
(COALESCE(atip_index_50_f_pos.value,0)+COALESCE(ats_index_50_f_pos.value,0))+
(COALESCE(atip_index_50_f_neg.value,0)+COALESCE(ats_index_50_f_neg.value,0))+
(COALESCE(atip_index_50_m_pos.value,0)+COALESCE(ats_index_50_m_pos.value,0))+
(COALESCE(atip_index_50_m_neg.value,0)+COALESCE(ats_index_50_m_neg.value,0))
) AS HTS_TST_num,
/*HTS_TST (Facility)-PITC Inpatient Services*/
COALESCE(atip_enf_0_8_f_pos.value,0) AS HTS_TST_Inpatient_men1_f_pos,
COALESCE(atip_enf_0_8_f_neg.value,0) AS HTS_TST_Inpatient_men1_f_neg,
COALESCE(atip_enf_0_8_m_pos.value,0) AS HTS_TST_Inpatient_men1_m_pos,
COALESCE(atip_enf_0_8_m_neg.value,0) AS HTS_TST_Inpatient_men1_m_neg,
(COALESCE(atip_enf_9_18_f_pos.value,0)+COALESCE(atip_enf_19_4_f_pos.value,0)) AS HTS_TST_Inpatient_1_4_f_pos,
(COALESCE(atip_enf_9_18_f_neg.value,0)+COALESCE(atip_enf_19_4_f_neg.value,0)) AS HTS_TST_Inpatient_1_4_f_neg,
(COALESCE(atip_enf_9_18_m_pos.value,0)+COALESCE(atip_enf_19_4_m_pos.value,0)) AS HTS_TST_Inpatient_1_4_m_pos,
(COALESCE(atip_enf_9_18_m_neg.value,0)+COALESCE(atip_enf_19_4_m_neg.value,0)) AS HTS_TST_Inpatient_1_4_m_neg,
COALESCE(atip_enf_5_9_f_pos.value,0) AS HTS_TST_Inpatient_5_9_f_pos,
COALESCE(atip_enf_5_9_f_neg.value,0) AS HTS_TST_Inpatient_5_9_f_neg,
COALESCE(atip_enf_5_9_m_pos.value,0) AS HTS_TST_Inpatient_5_9_m_pos,
COALESCE(atip_enf_5_9_m_neg.value,0) AS HTS_TST_Inpatient_5_9_m_neg,
COALESCE(atip_enf_10_14_f_pos.value,0) AS HTS_TST_Inpatient_10_14_f_pos,
COALESCE(atip_enf_10_14_f_neg.value,0) AS HTS_TST_Inpatient_10_14_f_neg,
COALESCE(atip_enf_10_14_m_pos.value,0) AS HTS_TST_Inpatient_10_14_m_pos,
COALESCE(atip_enf_10_14_m_neg.value,0) AS HTS_TST_Inpatient_10_14_m_neg,
COALESCE(atip_enf_15_19_f_pos.value,0) AS HTS_TST_Inpatient_15_19_f_pos,
COALESCE(atip_enf_15_19_f_neg.value,0) AS HTS_TST_Inpatient_15_19_f_neg,
COALESCE(atip_enf_15_19_m_pos.value,0) AS HTS_TST_Inpatient_15_19_m_pos,
COALESCE(atip_enf_15_19_m_neg.value,0) AS HTS_TST_Inpatient_15_19_m_neg,
COALESCE(atip_enf_20_24_f_pos.value,0) AS HTS_TST_Inpatient_20_24_f_pos,
COALESCE(atip_enf_20_24_f_neg.value,0) AS HTS_TST_Inpatient_20_24_f_neg,
COALESCE(atip_enf_20_24_m_pos.value,0) AS HTS_TST_Inpatient_20_24_m_pos,
COALESCE(atip_enf_20_24_m_neg.value,0) AS HTS_TST_Inpatient_20_24_m_neg,
(COALESCE(atip_enf_25_29_f_pos.value,0)+COALESCE(atip_enf_30_49_f_pos.value,0)) AS HTS_TST_Inpatient_25_49_f_pos,
(COALESCE(atip_enf_25_29_f_neg.value,0)+COALESCE(atip_enf_30_49_f_neg.value,0)) AS HTS_TST_Inpatient_25_49_f_neg,
(COALESCE(atip_enf_25_29_m_pos.value,0)+COALESCE(atip_enf_30_49_m_pos.value,0)) AS HTS_TST_Inpatient_25_49_m_pos,
(COALESCE(atip_enf_25_29_m_neg.value,0)+COALESCE(atip_enf_30_49_m_neg.value,0)) AS HTS_TST_Inpatient_25_49_m_neg,
COALESCE(atip_enf_50_f_pos.value,0) AS HTS_TST_Inpatient_50_f_pos,
COALESCE(atip_enf_50_f_neg.value,0) AS HTS_TST_Inpatient_50_f_neg,
COALESCE(atip_enf_50_m_pos.value,0) AS HTS_TST_Inpatient_50_m_pos,
COALESCE(atip_enf_50_m_neg.value,0) AS HTS_TST_Inpatient_50_m_neg,
/*HTS_TST (Facility)-PITC Pediatric Services*/
COALESCE(HTS_TST_Pediatric_pos.value,0) AS HTS_TST_Pediatric_pos,
COALESCE(HTS_TST_Pediatric_neg.value,0) AS HTS_TST_Pediatric_neg,
/*HTS_TST (Facility)-PITC-TB Clinics*/
COALESCE(HTS_TST_TB_men1_f_pos.value,0) AS HTS_TST_TB_men1_f_pos,
COALESCE(HTS_TST_TB_men1_f_neg.value,0) AS HTS_TST_TB_men1_f_neg,
COALESCE(HTS_TST_TB_men1_m_pos.value,0) AS HTS_TST_TB_men1_m_pos,
COALESCE(HTS_TST_TB_men1_m_neg.value,0) AS HTS_TST_TB_men1_m_neg,
COALESCE(HTS_TST_TB_1_4_f_pos.value,0) AS HTS_TST_TB_1_4_f_pos,
COALESCE(HTS_TST_TB_1_4_f_neg.value,0) AS HTS_TST_TB_1_4_f_neg,
COALESCE(HTS_TST_TB_1_4_m_pos.value,0) AS HTS_TST_TB_1_4_m_pos,
COALESCE(HTS_TST_TB_1_4_m_neg.value,0) AS HTS_TST_TB_1_4_m_neg,
COALESCE(HTS_TST_TB_5_9_f_pos.value,0) AS HTS_TST_TB_5_9_f_pos,
COALESCE(HTS_TST_TB_5_9_f_neg.value,0) AS HTS_TST_TB_5_9_f_neg,
COALESCE(HTS_TST_TB_5_9_m_pos.value,0) AS HTS_TST_TB_5_9_m_pos,
COALESCE(HTS_TST_TB_5_9_m_neg.value,0) AS HTS_TST_TB_5_9_m_neg,
COALESCE(HTS_TST_TB_10_14_f_pos.value,0) AS HTS_TST_TB_10_14_f_pos,
COALESCE(HTS_TST_TB_10_14_f_neg.value,0) AS HTS_TST_TB_10_14_f_neg,
COALESCE(HTS_TST_TB_10_14_m_pos.value,0) AS HTS_TST_TB_10_14_m_pos,
COALESCE(HTS_TST_TB_10_14_m_neg.value,0) AS HTS_TST_TB_10_14_m_neg,
COALESCE(HTS_TST_TB_15_19_f_pos.value,0) AS HTS_TST_TB_15_19_f_pos,
COALESCE(HTS_TST_TB_15_19_f_neg.value,0) AS HTS_TST_TB_15_19_f_neg,
COALESCE(HTS_TST_TB_15_19_m_pos.value,0) AS HTS_TST_TB_15_19_m_pos,
COALESCE(HTS_TST_TB_15_19_m_neg.value,0) AS HTS_TST_TB_15_19_m_neg,
COALESCE(HTS_TST_TB_20_24_f_pos.value,0) AS HTS_TST_TB_20_24_f_pos,
COALESCE(HTS_TST_TB_20_24_f_neg.value,0) AS HTS_TST_TB_20_24_f_neg,
COALESCE(HTS_TST_TB_20_24_m_pos.value,0) AS HTS_TST_TB_20_24_m_pos,
COALESCE(HTS_TST_TB_20_24_m_neg.value,0) AS HTS_TST_TB_20_24_m_neg,
COALESCE(HTS_TST_TB_25_29_f_pos.value,0) AS HTS_TST_TB_25_29_f_pos,
COALESCE(HTS_TST_TB_25_29_f_neg.value,0) AS HTS_TST_TB_25_29_f_neg,
COALESCE(HTS_TST_TB_25_29_m_pos.value,0) AS HTS_TST_TB_25_29_m_pos,
COALESCE(HTS_TST_TB_25_29_m_neg.value,0) AS HTS_TST_TB_25_29_m_neg,
COALESCE(HTS_TST_TB_30_34_f_pos.value,0) AS HTS_TST_TB_30_34_f_pos,
COALESCE(HTS_TST_TB_30_34_f_neg.value,0) AS HTS_TST_TB_30_34_f_neg,
COALESCE(HTS_TST_TB_30_34_m_pos.value,0) AS HTS_TST_TB_30_34_m_pos,
COALESCE(HTS_TST_TB_30_34_m_neg.value,0) AS HTS_TST_TB_30_34_m_neg,
COALESCE(HTS_TST_TB_35_39_f_pos.value,0) AS HTS_TST_TB_35_39_f_pos,
COALESCE(HTS_TST_TB_35_39_f_neg.value,0) AS HTS_TST_TB_35_39_f_neg,
COALESCE(HTS_TST_TB_35_39_m_pos.value,0) AS HTS_TST_TB_35_39_m_pos,
COALESCE(HTS_TST_TB_35_39_m_neg.value,0) AS HTS_TST_TB_35_39_m_neg,
COALESCE(HTS_TST_TB_40_44_f_pos.value,0) AS HTS_TST_TB_40_44_f_pos,
COALESCE(HTS_TST_TB_40_44_f_neg.value,0) AS HTS_TST_TB_40_44_f_neg,
COALESCE(HTS_TST_TB_40_44_m_pos.value,0) AS HTS_TST_TB_40_44_m_pos,
COALESCE(HTS_TST_TB_40_44_m_neg.value,0) AS HTS_TST_TB_40_44_m_neg,
COALESCE(HTS_TST_TB_45_49_f_pos.value,0) AS HTS_TST_TB_45_49_f_pos,
COALESCE(HTS_TST_TB_45_49_f_neg.value,0) AS HTS_TST_TB_45_49_f_neg,
COALESCE(HTS_TST_TB_45_49_m_pos.value,0) AS HTS_TST_TB_45_49_m_pos,
COALESCE(HTS_TST_TB_45_49_m_neg.value,0) AS HTS_TST_TB_45_49_m_neg,
COALESCE(HTS_TST_TB_50_f_pos.value,0) AS HTS_TST_TB_50_f_pos,
COALESCE(HTS_TST_TB_50_f_neg.value,0) AS HTS_TST_TB_50_f_neg,
COALESCE(HTS_TST_TB_50_m_pos.value,0) AS HTS_TST_TB_50_m_pos,
COALESCE(HTS_TST_TB_50_m_neg.value,0) AS HTS_TST_TB_50_m_neg,
/*HTS_TST (Facility)-PITC PMTCT (ANC Only) Clinics*/
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0) AS HTS_TST_PMTCT_10_14_pos,
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0) AS HTS_TST_PMTCT_10_14_neg,
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0) AS HTS_TST_PMTCT_15_19_pos,
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0) AS HTS_TST_PMTCT_15_19_neg,
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0) AS HTS_TST_PMTCT_20_24_pos,
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0) AS HTS_TST_PMTCT_20_24_neg,
COALESCE(HTS_TST_PMTCT_25_pos.value,0) AS HTS_TST_PMTCT_25_49_pos,
COALESCE(HTS_TST_PMTCT_25_neg.value,0) AS HTS_TST_PMTCT_25_49_neg,
/*HTS_TST (Facility)-PITC PMTCT Post ANC*/
(COALESCE(mat_men1_pos.value,0)+COALESCE(atip_cpp_0_8_f_pos.value,0)) AS HTS_TST_PMTCT_POST_men1_pos,
(COALESCE(mat_men1_neg.value,0)+COALESCE(atip_cpp_0_8_f_neg.value,0)) AS HTS_TST_PMTCT_POST_men1_neg,
(COALESCE(mat_1_4_pos.value,0)+COALESCE(atip_cpp_9_18_f_pos.value,0)+COALESCE(atip_cpp_19_4_f_pos.value,0)) AS HTS_TST_PMTCT_POST_1_4_pos,
(COALESCE(mat_1_4_neg.value,0)+COALESCE(atip_cpp_9_18_f_neg.value,0)+COALESCE(atip_cpp_19_4_f_neg.value,0)) AS HTS_TST_PMTCT_POST_1_4_neg,
(COALESCE(mat_5_9_pos.value,0)+COALESCE(atip_cpp_5_9_f_pos.value,0)) AS HTS_TST_PMTCT_POST_5_9_pos,
(COALESCE(mat_5_9_neg.value,0)+COALESCE(atip_cpp_5_9_f_neg.value,0)) AS HTS_TST_PMTCT_POST_5_9_neg,
(COALESCE(mat_10_14_pos.value,0)+COALESCE(atip_cpp_10_14_f_pos.value,0)) AS HTS_TST_PMTCT_POST_10_14_pos,
(COALESCE(mat_10_14_neg.value,0)+COALESCE(atip_cpp_10_14_f_neg.value,0)) AS HTS_TST_PMTCT_POST_10_14_neg,
(COALESCE(mat_15_19_pos.value,0)+COALESCE(atip_cpp_15_19_f_pos.value,0)) AS HTS_TST_PMTCT_POST_15_19_pos,
(COALESCE(mat_15_19_neg.value,0)+COALESCE(atip_cpp_15_19_f_neg.value,0)) AS HTS_TST_PMTCT_POST_15_19_neg,
(COALESCE(mat_20_24_pos.value,0)+COALESCE(atip_cpp_20_24_f_pos.value,0)) AS HTS_TST_PMTCT_POST_20_24_pos,
(COALESCE(mat_20_24_neg.value,0)+COALESCE(atip_cpp_20_24_f_neg.value,0)) AS HTS_TST_PMTCT_POST_20_24_neg,
(COALESCE(mat_25_29_pos.value,0)+COALESCE(mat_30_34_pos.value,0)+COALESCE(mat_35_39_pos.value,0)+COALESCE(mat_40_44_pos.value,0)+COALESCE(mat_45_49_pos.value,0)+COALESCE(atip_cpp_25_29_f_pos.value,0)+COALESCE(atip_cpp_30_49_f_pos.value,0)) AS HTS_TST_PMTCT_POST_25_49_pos,
(COALESCE(mat_25_29_neg.value,0)+COALESCE(mat_30_34_neg.value,0)+COALESCE(mat_35_39_neg.value,0)+COALESCE(mat_40_44_neg.value,0)+COALESCE(mat_45_49_neg.value,0)+COALESCE(atip_cpp_25_29_f_neg.value,0)+COALESCE(atip_cpp_30_49_f_neg.value,0)) AS HTS_TST_PMTCT_POST_25_49_neg,
(COALESCE(mat_50_pos.value,0)+COALESCE(atip_cpp_50_f_pos.value,0)) AS HTS_TST_PMTCT_POST_50_pos,
(COALESCE(mat_50_neg.value,0)+COALESCE(atip_cpp_50_f_neg.value,0)) AS HTS_TST_PMTCT_POST_50_neg,
/*HTS_TST (Facility)-PITC Emergency Ward*/
COALESCE(atip_bso_0_8_f_pos.value,0) AS HTS_TST_Emergency_men1_f_pos,
COALESCE(atip_bso_0_8_f_neg.value,0) AS HTS_TST_Emergency_men1_f_neg,
COALESCE(atip_bso_0_8_m_pos.value,0) AS HTS_TST_Emergency_men1_m_pos,
COALESCE(atip_bso_0_8_m_neg.value,0) AS HTS_TST_Emergency_men1_m_neg,
(COALESCE(atip_bso_9_18_f_pos.value,0)+COALESCE(atip_bso_19_4_f_pos.value,0)) AS HTS_TST_Emergency_1_4_f_pos,
(COALESCE(atip_bso_9_18_f_neg.value,0)+COALESCE(atip_bso_19_4_f_neg.value,0)) AS HTS_TST_Emergency_1_4_f_neg,
(COALESCE(atip_bso_9_18_m_pos.value,0)+COALESCE(atip_bso_19_4_m_pos.value,0)) AS HTS_TST_Emergency_1_4_m_pos,
(COALESCE(atip_bso_9_18_m_neg.value,0)+COALESCE(atip_bso_19_4_m_neg.value,0)) AS HTS_TST_Emergency_1_4_m_neg,
COALESCE(atip_bso_5_9_f_pos.value,0) AS HTS_TST_Emergency_5_9_f_pos,
COALESCE(atip_bso_5_9_f_neg.value,0) AS HTS_TST_Emergency_5_9_f_neg,
COALESCE(atip_bso_5_9_m_pos.value,0) AS HTS_TST_Emergency_5_9_m_pos,
COALESCE(atip_bso_5_9_m_neg.value,0) AS HTS_TST_Emergency_5_9_m_neg,
COALESCE(atip_bso_10_14_f_pos.value,0) AS HTS_TST_Emergency_10_14_f_pos,
COALESCE(atip_bso_10_14_f_neg.value,0) AS HTS_TST_Emergency_10_14_f_neg,
COALESCE(atip_bso_10_14_m_pos.value,0) AS HTS_TST_Emergency_10_14_m_pos,
COALESCE(atip_bso_10_14_m_neg.value,0) AS HTS_TST_Emergency_10_14_m_neg,
COALESCE(atip_bso_15_19_f_pos.value,0) AS HTS_TST_Emergency_15_19_f_pos,
COALESCE(atip_bso_15_19_f_neg.value,0) AS HTS_TST_Emergency_15_19_f_neg,
COALESCE(atip_bso_15_19_m_pos.value,0) AS HTS_TST_Emergency_15_19_m_pos,
COALESCE(atip_bso_15_19_m_neg.value,0) AS HTS_TST_Emergency_15_19_m_neg,
COALESCE(atip_bso_20_24_f_pos.value,0) AS HTS_TST_Emergency_20_24_f_pos,
COALESCE(atip_bso_20_24_f_neg.value,0) AS HTS_TST_Emergency_20_24_f_neg,
COALESCE(atip_bso_20_24_m_pos.value,0) AS HTS_TST_Emergency_20_24_m_pos,
COALESCE(atip_bso_20_24_m_neg.value,0) AS HTS_TST_Emergency_20_24_m_neg,
(COALESCE(atip_bso_25_29_f_pos.value,0)+COALESCE(atip_bso_30_49_f_pos.value,0)) AS HTS_TST_Emergency_25_49_f_pos,
(COALESCE(atip_bso_25_29_f_neg.value,0)+COALESCE(atip_bso_30_49_f_neg.value,0)) AS HTS_TST_Emergency_25_49_f_neg,
(COALESCE(atip_bso_25_29_m_pos.value,0)+COALESCE(atip_bso_30_49_m_pos.value,0)) AS HTS_TST_Emergency_25_49_m_pos,
(COALESCE(atip_bso_25_29_m_neg.value,0)+COALESCE(atip_bso_30_49_m_neg.value,0)) AS HTS_TST_Emergency_25_49_m_neg,
COALESCE(atip_bso_50_f_pos.value,0) AS HTS_TST_Emergency_50_f_pos,
COALESCE(atip_bso_50_f_neg.value,0) AS HTS_TST_Emergency_50_f_neg,
COALESCE(atip_bso_50_m_pos.value,0) AS HTS_TST_Emergency_50_m_pos,
COALESCE(atip_bso_50_m_neg.value,0) AS HTS_TST_Emergency_50_m_neg,
/*HTS_TST (Facility)-Other PITC*/
COALESCE(cpn_m_pos.value,0) AS HTS_TST_Other_u_m_pos,
COALESCE(cpn_m_neg.value,0) AS HTS_TST_Other_u_m_neg,
COALESCE(atip_0_8_f_pos.value,0) AS HTS_TST_Other_men1_f_pos,
COALESCE(atip_0_8_f_neg.value,0) AS HTS_TST_Other_men1_f_neg,
COALESCE(atip_0_8_m_pos.value,0) AS HTS_TST_Other_men1_m_pos,
COALESCE(atip_0_8_m_neg.value,0) AS HTS_TST_Other_men1_m_neg,
(COALESCE(atip_9_18_f_pos.value,0)+COALESCE(atip_19_4_f_pos.value,0)) AS HTS_TST_Other_1_4_f_pos,
(COALESCE(atip_9_18_f_neg.value,0)+COALESCE(atip_19_4_f_neg.value,0)) AS HTS_TST_Other_1_4_f_neg,
(COALESCE(atip_9_18_m_pos.value,0)+COALESCE(atip_19_4_m_pos.value,0)) AS HTS_TST_Other_1_4_m_pos,
(COALESCE(atip_9_18_m_neg.value,0)+COALESCE(atip_19_4_m_neg.value,0)) AS HTS_TST_Other_1_4_m_neg,
COALESCE(atip_5_9_f_pos.value,0) AS HTS_TST_Other_5_9_f_pos,
COALESCE(atip_5_9_f_neg.value,0) AS HTS_TST_Other_5_9_f_neg,
COALESCE(atip_5_9_m_pos.value,0) AS HTS_TST_Other_5_9_m_pos,
COALESCE(atip_5_9_m_neg.value,0) AS HTS_TST_Other_5_9_m_neg,
COALESCE(atip_10_14_f_pos.value,0) AS HTS_TST_Other_10_14_f_pos,
COALESCE(atip_10_14_f_neg.value,0) AS HTS_TST_Other_10_14_f_neg,
COALESCE(atip_10_14_m_pos.value,0) AS HTS_TST_Other_10_14_m_pos,
COALESCE(atip_10_14_m_neg.value,0) AS HTS_TST_Other_10_14_m_neg,
COALESCE(atip_15_19_f_pos.value,0) AS HTS_TST_Other_15_19_f_pos,
COALESCE(atip_15_19_f_neg.value,0) AS HTS_TST_Other_15_19_f_neg,
COALESCE(atip_15_19_m_pos.value,0) AS HTS_TST_Other_15_19_m_pos,
COALESCE(atip_15_19_m_neg.value,0) AS HTS_TST_Other_15_19_m_neg,
COALESCE(atip_20_24_f_pos.value,0) AS HTS_TST_Other_20_24_f_pos,
COALESCE(atip_20_24_f_neg.value,0) AS HTS_TST_Other_20_24_f_neg,
COALESCE(atip_20_24_m_pos.value,0) AS HTS_TST_Other_20_24_m_pos,
COALESCE(atip_20_24_m_neg.value,0) AS HTS_TST_Other_20_24_m_neg,
(COALESCE(atip_25_29_f_pos.value,0)+COALESCE(atip_30_49_f_pos.value,0)) AS HTS_TST_Other_25_49_f_pos,
(COALESCE(atip_25_29_f_neg.value,0)+COALESCE(atip_30_49_f_neg.value,0)) AS HTS_TST_Other_25_49_f_neg,
(COALESCE(atip_25_29_m_pos.value,0)+COALESCE(atip_30_49_m_pos.value,0)) AS HTS_TST_Other_25_49_m_pos,
(COALESCE(atip_25_29_m_neg.value,0)+COALESCE(atip_30_49_m_neg.value,0)) AS HTS_TST_Other_25_49_m_neg,
(COALESCE(atip_50_f_pos.value,0)) AS HTS_TST_Other_50_f_pos,
(COALESCE(atip_50_f_neg.value,0)) AS HTS_TST_Other_50_f_neg,
COALESCE(atip_50_m_pos.value,0) AS HTS_TST_Other_50_m_pos,
COALESCE(atip_50_m_neg.value,0) AS HTS_TST_Other_50_m_neg,
/*HTS_TST (Facility)-VCT*/
COALESCE(ats_0_8_f_pos.value,0) AS HTS_TST_VCT_men1_f_pos,
COALESCE(ats_0_8_f_neg.value,0) AS HTS_TST_VCT_men1_f_neg,
COALESCE(ats_0_8_m_pos.value,0) AS HTS_TST_VCT_men1_m_pos,
COALESCE(ats_0_8_m_neg.value,0) AS HTS_TST_VCT_men1_m_neg,
(COALESCE(ats_9_18_f_pos.value,0)+COALESCE(ats_19_4_f_pos.value,0)) AS HTS_TST_VCT_1_4_f_pos,
(COALESCE(ats_9_18_f_neg.value,0)+COALESCE(ats_19_4_f_neg.value,0)) AS HTS_TST_VCT_1_4_f_neg,
(COALESCE(ats_9_18_m_pos.value,0)+COALESCE(ats_19_4_m_pos.value,0)) AS HTS_TST_VCT_1_4_m_pos,
(COALESCE(ats_9_18_m_neg.value,0)+COALESCE(ats_19_4_m_neg.value,0)) AS HTS_TST_VCT_1_4_m_neg,
COALESCE(ats_5_9_f_pos.value,0) AS HTS_TST_VCT_5_9_f_pos,
COALESCE(ats_5_9_f_neg.value,0) AS HTS_TST_VCT_5_9_f_neg,
COALESCE(ats_5_9_m_pos.value,0) AS HTS_TST_VCT_5_9_m_pos,
COALESCE(ats_5_9_m_neg.value,0) AS HTS_TST_VCT_5_9_m_neg,
COALESCE(ats_10_14_f_pos.value,0) AS HTS_TST_VCT_10_14_f_pos,
COALESCE(ats_10_14_f_neg.value,0) AS HTS_TST_VCT_10_14_f_neg,
COALESCE(ats_10_14_m_pos.value,0) AS HTS_TST_VCT_10_14_m_pos,
COALESCE(ats_10_14_m_neg.value,0) AS HTS_TST_VCT_10_14_m_neg,
COALESCE(ats_15_19_f_pos.value,0) AS HTS_TST_VCT_15_19_f_pos,
COALESCE(ats_15_19_f_neg.value,0) AS HTS_TST_VCT_15_19_f_neg,
COALESCE(ats_15_19_m_pos.value,0) AS HTS_TST_VCT_15_19_m_pos,
COALESCE(ats_15_19_m_neg.value,0) AS HTS_TST_VCT_15_19_m_neg,
COALESCE(ats_20_24_f_pos.value,0) AS HTS_TST_VCT_20_24_f_pos,
COALESCE(ats_20_24_f_neg.value,0) AS HTS_TST_VCT_20_24_f_neg,
COALESCE(ats_20_24_m_pos.value,0) AS HTS_TST_VCT_20_24_m_pos,
COALESCE(ats_20_24_m_neg.value,0) AS HTS_TST_VCT_20_24_m_neg,
(COALESCE(ats_25_29_f_pos.value,0)+COALESCE(ats_30_49_f_pos.value,0)) AS HTS_TST_VCT_25_49_f_pos,
(COALESCE(ats_25_29_f_neg.value,0)+COALESCE(ats_30_49_f_neg.value,0)) AS HTS_TST_VCT_25_49_f_neg,
(COALESCE(ats_25_29_m_pos.value,0)+COALESCE(ats_30_49_m_pos.value,0)) AS HTS_TST_VCT_25_49_m_pos,
(COALESCE(ats_25_29_m_neg.value,0)+COALESCE(ats_30_49_m_neg.value,0)) AS HTS_TST_VCT_25_49_m_neg,
COALESCE(ats_50_f_pos.value,0) AS HTS_TST_VCT_50_f_pos,
COALESCE(ats_50_f_neg.value,0) AS HTS_TST_VCT_50_f_neg,
COALESCE(ats_50_m_pos.value,0) AS HTS_TST_VCT_50_m_pos,
COALESCE(ats_50_m_neg.value,0) AS HTS_TST_VCT_50_m_neg,
/*Index Testing*/
(COALESCE(atip_index_0_8_f_pos.value,0)+COALESCE(ats_index_0_8_f_pos.value,0)) AS HTS_TST_Index_men1_f_pos,
(COALESCE(atip_index_0_8_f_neg.value,0)+COALESCE(ats_index_0_8_f_neg.value,0)) AS HTS_TST_Index_men1_f_neg,
(COALESCE(atip_index_0_8_m_pos.value,0)+COALESCE(ats_index_0_8_m_pos.value,0)) AS HTS_TST_Index_men1_m_pos,
(COALESCE(atip_index_0_8_m_neg.value,0)+COALESCE(ats_index_0_8_m_neg.value,0)) AS HTS_TST_Index_men1_m_neg,
(COALESCE(atip_index_9_18_f_pos.value,0)+COALESCE(atip_index_19_4_f_pos.value,0)+COALESCE(ats_index_9_18_f_pos.value,0)+COALESCE(ats_index_19_4_f_pos.value,0)) AS HTS_TST_Index_1_4_f_pos,
(COALESCE(atip_index_9_18_f_neg.value,0)+COALESCE(atip_index_19_4_f_neg.value,0)+COALESCE(ats_index_9_18_f_neg.value,0)+COALESCE(ats_index_19_4_f_neg.value,0)) AS HTS_TST_Index_1_4_f_neg,
(COALESCE(atip_index_9_18_m_pos.value,0)+COALESCE(atip_index_19_4_m_pos.value,0)+COALESCE(ats_index_9_18_m_pos.value,0)+COALESCE(ats_index_19_4_m_pos.value,0)) AS HTS_TST_Index_1_4_m_pos,
(COALESCE(atip_index_9_18_m_neg.value,0)+COALESCE(atip_index_19_4_m_neg.value,0)+COALESCE(ats_index_9_18_m_neg.value,0)+COALESCE(ats_index_19_4_m_neg.value,0)) AS HTS_TST_Index_1_4_m_neg,
(COALESCE(atip_index_5_9_f_pos.value,0)+COALESCE(ats_index_5_9_f_pos.value,0)) AS HTS_TST_Index_5_9_f_pos,
(COALESCE(atip_index_5_9_f_neg.value,0)+COALESCE(ats_index_5_9_f_neg.value,0)) AS HTS_TST_Index_5_9_f_neg,
(COALESCE(atip_index_5_9_m_pos.value,0)+COALESCE(ats_index_5_9_m_pos.value,0)) AS HTS_TST_Index_5_9_m_pos,
(COALESCE(atip_index_5_9_m_neg.value,0)+COALESCE(ats_index_5_9_m_neg.value,0)) AS HTS_TST_Index_5_9_m_neg,
(COALESCE(atip_index_10_14_f_pos.value,0)+COALESCE(ats_index_10_14_f_pos.value,0)) AS HTS_TST_Index_10_14_f_pos,
(COALESCE(atip_index_10_14_f_neg.value,0)+COALESCE(ats_index_10_14_f_neg.value,0)) AS HTS_TST_Index_10_14_f_neg,
(COALESCE(atip_index_10_14_m_pos.value,0)+COALESCE(ats_index_10_14_m_pos.value,0)) AS HTS_TST_Index_10_14_m_pos,
(COALESCE(atip_index_10_14_m_neg.value,0)+COALESCE(ats_index_10_14_m_neg.value,0)) AS HTS_TST_Index_10_14_m_neg,
(COALESCE(atip_index_15_19_f_pos.value,0)+COALESCE(ats_index_15_19_f_pos.value,0)) AS HTS_TST_Index_15_19_f_pos,
(COALESCE(atip_index_15_19_f_neg.value,0)+COALESCE(ats_index_15_19_f_neg.value,0)) AS HTS_TST_Index_15_19_f_neg,
(COALESCE(atip_index_15_19_m_pos.value,0)+COALESCE(ats_index_15_19_m_pos.value,0)) AS HTS_TST_Index_15_19_m_pos,
(COALESCE(atip_index_15_19_m_neg.value,0)+COALESCE(ats_index_15_19_m_neg.value,0)) AS HTS_TST_Index_15_19_m_neg,
(COALESCE(atip_index_20_24_f_pos.value,0)+COALESCE(ats_index_20_24_f_pos.value,0)) AS HTS_TST_Index_20_24_f_pos,
(COALESCE(atip_index_20_24_f_neg.value,0)+COALESCE(ats_index_20_24_f_neg.value,0)) AS HTS_TST_Index_20_24_f_neg,
(COALESCE(atip_index_20_24_m_pos.value,0)+COALESCE(ats_index_20_24_m_pos.value,0)) AS HTS_TST_Index_20_24_m_pos,
(COALESCE(atip_index_20_24_m_neg.value,0)+COALESCE(ats_index_20_24_m_neg.value,0)) AS HTS_TST_Index_20_24_m_neg,
(COALESCE(atip_index_25_29_f_pos.value,0)+COALESCE(atip_index_30_49_f_pos.value,0)+COALESCE(ats_index_25_29_f_pos.value,0)+COALESCE(ats_index_30_49_f_pos.value,0)) AS HTS_TST_Index_25_49_f_pos,
(COALESCE(atip_index_25_29_f_neg.value,0)+COALESCE(atip_index_30_49_f_neg.value,0)+COALESCE(ats_index_25_29_f_neg.value,0)+COALESCE(ats_index_30_49_f_neg.value,0)) AS HTS_TST_Index_25_49_f_neg,
(COALESCE(atip_index_25_29_m_pos.value,0)+COALESCE(atip_index_30_49_m_pos.value,0)+COALESCE(ats_index_25_29_m_pos.value,0)+COALESCE(ats_index_30_49_m_pos.value,0)) AS HTS_TST_Index_25_49_m_pos,
(COALESCE(atip_index_25_29_m_neg.value,0)+COALESCE(atip_index_30_49_m_neg.value,0)+COALESCE(ats_index_25_29_m_neg.value,0)+COALESCE(ats_index_30_49_m_neg.value,0)) AS HTS_TST_Index_25_49_m_neg,
(COALESCE(atip_index_50_f_pos.value,0)+COALESCE(ats_index_50_f_pos.value,0)) AS HTS_TST_Index_50_f_pos,
(COALESCE(atip_index_50_f_neg.value,0)+COALESCE(ats_index_50_f_neg.value,0)) AS HTS_TST_Index_50_f_neg,
(COALESCE(atip_index_50_m_pos.value,0)+COALESCE(ats_index_50_m_pos.value,0)) AS HTS_TST_Index_50_m_pos,
(COALESCE(atip_index_50_m_neg.value,0)+COALESCE(ats_index_50_m_neg.value,0)) AS HTS_TST_Index_50_m_neg,
/*PMTCT_STAT (Numerator)*/
(COALESCE(PMTCT_STAT_17q2_num.value,0)+COALESCE(PMTCT_STAT_17q1_num.value,0)) AS PMTCT_STAT_num,
(COALESCE(HTS_TST_PMTCT_10_14_pos.value,0)+COALESCE(HTS_TST_PMTCT_10_14_neg.value,0)+COALESCE(PMTCT_STAT_17q2_10_14_known_pos.value,0)) AS PMTCT_STAT_10_14_num,
(COALESCE(HTS_TST_PMTCT_15_19_pos.value,0)+COALESCE(HTS_TST_PMTCT_15_19_neg.value,0)+COALESCE(PMTCT_STAT_17q2_15_19_known_pos.value,0)) AS PMTCT_STAT_15_19_num,
(COALESCE(HTS_TST_PMTCT_20_24_pos.value,0)+COALESCE(HTS_TST_PMTCT_20_24_neg.value,0)+COALESCE(PMTCT_STAT_17q2_20_24_known_pos.value,0)) AS PMTCT_STAT_20_24_num,
(COALESCE(PMTCT_STAT_17q2_25_49_known_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_neg.value,0)+COALESCE(PMTCT_STAT_17q2_25_known_pos.value,0)) AS PMTCT_STAT_25_49_num,
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
/*PMTCT_STAT (Denominator)*/
COALESCE(PMTCT_STAT_17q2_10_14_den.value,0) AS PMTCT_STAT_10_14_den,
COALESCE(PMTCT_STAT_17q2_15_19_den.value,0) AS PMTCT_STAT_15_19_den,
COALESCE(PMTCT_STAT_17q2_20_24_den.value,0) AS PMTCT_STAT_20_24_den,
(COALESCE(PMTCT_STAT_17q2_25_49_den.value,0)+COALESCE(PMTCT_STAT_17q2_25_den.value,0)) AS PMTCT_STAT_25_49_den,
/*PMTCT_EID*/
COALESCE(PMTCT_EID_0_2_total.value,0) AS PMTCT_EID_0_2_test,
COALESCE(PMTCT_EID_2_12_total.value,0) AS PMTCT_EID_2_12_test,
COALESCE(PMTCT_EID_0_2_pos.value,0) AS PMTCT_EID_0_2_pos,
COALESCE(PMTCT_EID_0_2_art.value,0) AS PMTCT_EID_0_2_art,
COALESCE(PMTCT_EID_2_12_pos_sum_prev.value,0) AS PMTCT_EID_2_12_pos,
COALESCE(PMTCT_EID_2_12_art.value,0) AS PMTCT_EID_2_12_art,
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
/*New Negatives*/
COALESCE(HTS_TST_TB_men1_f_neg.value,0) AS HTS_TST_TB_men1_f_neg2,
COALESCE(HTS_TST_TB_men1_m_neg.value,0) AS HTS_TST_TB_men1_m_neg2,
COALESCE(HTS_TST_TB_1_4_f_neg.value,0) AS HTS_TST_TB_1_4_f_neg2,
COALESCE(HTS_TST_TB_1_4_m_neg.value,0) AS HTS_TST_TB_1_4_m_neg2,
COALESCE(HTS_TST_TB_5_9_f_neg.value,0) AS HTS_TST_TB_5_9_f_neg2,
COALESCE(HTS_TST_TB_5_9_m_neg.value,0) AS HTS_TST_TB_5_9_m_neg2,
COALESCE(HTS_TST_TB_10_14_f_neg.value,0) AS HTS_TST_TB_10_14_f_neg2,
COALESCE(HTS_TST_TB_10_14_m_neg.value,0) AS HTS_TST_TB_10_14_m_neg2,
COALESCE(HTS_TST_TB_15_19_f_neg.value,0) AS HTS_TST_TB_15_19_f_neg2,
COALESCE(HTS_TST_TB_15_19_m_neg.value,0) AS HTS_TST_TB_15_19_m_neg2,
COALESCE(HTS_TST_TB_20_24_f_neg.value,0) AS HTS_TST_TB_20_24_f_neg2,
COALESCE(HTS_TST_TB_20_24_m_neg.value,0) AS HTS_TST_TB_20_24_m_neg2,
COALESCE(HTS_TST_TB_25_29_f_neg.value,0) AS HTS_TST_TB_25_29_f_neg2,
COALESCE(HTS_TST_TB_25_29_m_neg.value,0) AS HTS_TST_TB_25_29_m_neg2,
COALESCE(HTS_TST_TB_30_34_f_neg.value,0) AS HTS_TST_TB_30_34_f_neg2,
COALESCE(HTS_TST_TB_30_34_m_neg.value,0) AS HTS_TST_TB_30_34_m_neg2,
COALESCE(HTS_TST_TB_35_39_f_neg.value,0) AS HTS_TST_TB_35_39_f_neg2,
COALESCE(HTS_TST_TB_35_39_m_neg.value,0) AS HTS_TST_TB_35_39_m_neg2,
COALESCE(HTS_TST_TB_40_44_f_neg.value,0) AS HTS_TST_TB_40_44_f_neg2,
COALESCE(HTS_TST_TB_40_44_m_neg.value,0) AS HTS_TST_TB_40_44_m_neg2,
COALESCE(HTS_TST_TB_45_49_f_neg.value,0) AS HTS_TST_TB_45_49_f_neg2,
COALESCE(HTS_TST_TB_45_49_m_neg.value,0) AS HTS_TST_TB_45_49_m_neg2,
COALESCE(HTS_TST_TB_50_f_neg.value,0) AS HTS_TST_TB_50_f_neg2,
COALESCE(HTS_TST_TB_50_m_neg.value,0) AS HTS_TST_TB_50_m_neg2,
/* TB_STAT Denominator*/
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
COALESCE(TX_NEW_preg.value,0) AS TX_NEW_preg,
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
/*TX_PVLS*/
COALESCE(TX_PVLS_num_und.value,0) as TX_PVLS_num,
COALESCE(TX_PVLS_num_und.value,0) as TX_PVLS_num_und,
COALESCE(TX_PVLS_num_und_preg.value,0) as TX_PVLS_num_und_preg,
COALESCE(TX_PVLS_num_und_breast.value,0) as TX_PVLS_num_und_breast,
COALESCE(TX_PVLS_num_und_f_men1.value,0) as TX_PVLS_num_und_f_men1,
COALESCE(TX_PVLS_num_und_f_1_4.value,0) as TX_PVLS_num_und_f_1_4,
COALESCE(TX_PVLS_num_und_f_5_9.value,0) as TX_PVLS_num_und_f_5_9,
COALESCE(TX_PVLS_num_und_f_10_14.value,0) as TX_PVLS_num_und_f_10_14,
COALESCE(TX_PVLS_num_und_f_15_19.value,0) as TX_PVLS_num_und_f_15_19,
COALESCE(TX_PVLS_num_und_f_20_24.value,0) as TX_PVLS_num_und_f_20_24,
COALESCE(TX_PVLS_num_und_f_25_29.value,0) as TX_PVLS_num_und_f_25_29,
COALESCE(TX_PVLS_num_und_f_30_34.value,0) as TX_PVLS_num_und_f_30_34,
COALESCE(TX_PVLS_num_und_f_35_39.value,0) as TX_PVLS_num_und_f_35_39,
COALESCE(TX_PVLS_num_und_f_40_44.value,0) as TX_PVLS_num_und_f_40_44,
COALESCE(TX_PVLS_num_und_f_45_49.value,0) as TX_PVLS_num_und_f_45_49,
COALESCE(TX_PVLS_num_und_f_50.value,0) as TX_PVLS_num_und_f_50,
COALESCE(TX_PVLS_num_und_m_men1.value,0) as TX_PVLS_num_und_m_men1,
COALESCE(TX_PVLS_num_und_m_1_4.value,0) as TX_PVLS_num_und_m_1_4,
COALESCE(TX_PVLS_num_und_m_5_9.value,0) as TX_PVLS_num_und_m_5_9,
COALESCE(TX_PVLS_num_und_m_10_14.value,0) as TX_PVLS_num_und_m_10_14,
COALESCE(TX_PVLS_num_und_m_15_19.value,0) as TX_PVLS_num_und_m_15_19,
COALESCE(TX_PVLS_num_und_m_20_24.value,0) as TX_PVLS_num_und_m_20_24,
COALESCE(TX_PVLS_num_und_m_25_29.value,0) as TX_PVLS_num_und_m_25_29,
COALESCE(TX_PVLS_num_und_m_30_34.value,0) as TX_PVLS_num_und_m_30_34,
COALESCE(TX_PVLS_num_und_m_35_39.value,0) as TX_PVLS_num_und_m_35_39,
COALESCE(TX_PVLS_num_und_m_40_44.value,0) as TX_PVLS_num_und_m_40_44,
COALESCE(TX_PVLS_num_und_m_45_49.value,0) as TX_PVLS_num_und_m_45_49,
COALESCE(TX_PVLS_num_und_m_50.value,0) as TX_PVLS_num_und_m_50,
COALESCE(TX_PVLS_den_und.value,0) as TX_PVLS_den,
COALESCE(TX_PVLS_den_und.value,0) as TX_PVLS_den_und,
COALESCE(TX_PVLS_den_und_preg.value,0) as TX_PVLS_den_und_preg,
COALESCE(TX_PVLS_den_und_breast.value,0) as TX_PVLS_den_und_breast,
COALESCE(TX_PVLS_den_und_f_men1.value,0) as TX_PVLS_den_und_f_men1,
COALESCE(TX_PVLS_den_und_f_1_4.value,0) as TX_PVLS_den_und_f_1_4,
COALESCE(TX_PVLS_den_und_f_5_9.value,0) as TX_PVLS_den_und_f_5_9,
COALESCE(TX_PVLS_den_und_f_10_14.value,0) as TX_PVLS_den_und_f_10_14,
COALESCE(TX_PVLS_den_und_f_15_19.value,0) as TX_PVLS_den_und_f_15_19,
COALESCE(TX_PVLS_den_und_f_20_24.value,0) as TX_PVLS_den_und_f_20_24,
COALESCE(TX_PVLS_den_und_f_25_29.value,0) as TX_PVLS_den_und_f_25_29,
COALESCE(TX_PVLS_den_und_f_30_34.value,0) as TX_PVLS_den_und_f_30_34,
COALESCE(TX_PVLS_den_und_f_35_39.value,0) as TX_PVLS_den_und_f_35_39,
COALESCE(TX_PVLS_den_und_f_40_44.value,0) as TX_PVLS_den_und_f_40_44,
COALESCE(TX_PVLS_den_und_f_45_49.value,0) as TX_PVLS_den_und_f_45_49,
COALESCE(TX_PVLS_den_und_f_50.value,0) as TX_PVLS_den_und_f_50,
COALESCE(TX_PVLS_den_und_m_men1.value,0) as TX_PVLS_den_und_m_men1,
COALESCE(TX_PVLS_den_und_m_1_4.value,0) as TX_PVLS_den_und_m_1_4,
COALESCE(TX_PVLS_den_und_m_5_9.value,0) as TX_PVLS_den_und_m_5_9,
COALESCE(TX_PVLS_den_und_m_10_14.value,0) as TX_PVLS_den_und_m_10_14,
COALESCE(TX_PVLS_den_und_m_15_19.value,0) as TX_PVLS_den_und_m_15_19,
COALESCE(TX_PVLS_den_und_m_20_24.value,0) as TX_PVLS_den_und_m_20_24,
COALESCE(TX_PVLS_den_und_m_25_29.value,0) as TX_PVLS_den_und_m_25_29,
COALESCE(TX_PVLS_den_und_m_30_34.value,0) as TX_PVLS_den_und_m_30_34,
COALESCE(TX_PVLS_den_und_m_35_39.value,0) as TX_PVLS_den_und_m_35_39,
COALESCE(TX_PVLS_den_und_m_40_44.value,0) as TX_PVLS_den_und_m_40_44,
COALESCE(TX_PVLS_den_und_m_45_49.value,0) as TX_PVLS_den_und_m_45_49,
COALESCE(TX_PVLS_den_und_m_50.value,0) as TX_PVLS_den_und_m_50

from organisationunit ou
left outer join _orgunitstructure ous
 on (ou.organisationunitid=ous.organisationunitid)
left outer join organisationunit province
 on (ous.idlevel2=province.organisationunitid)
left outer join organisationunit district
 on (ous.idlevel3=district.organisationunitid)

/*Quarterly*/
/*HTS_TST (Facility)-PITC Pediatric Services*/
left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=23817
 and categoryoptioncomboid=23818
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_Pediatric_pos on HTS_TST_Pediatric_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=23817
 and categoryoptioncomboid=23819
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_Pediatric_neg on HTS_TST_Pediatric_neg.sourceid=ou.organisationunitid

/*HTS_TST (Facility)-PITC-TB Clinics*/
/*<1*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62242
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_men1_f_pos on HTS_TST_TB_men1_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62258
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_men1_f_neg on HTS_TST_TB_men1_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62234
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_men1_m_pos on HTS_TST_TB_men1_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62250
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_men1_m_neg on HTS_TST_TB_men1_m_neg.sourceid=ou.organisationunitid
 
 /*1-4*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62243
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_1_4_f_pos on HTS_TST_TB_1_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62259
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_1_4_f_neg on HTS_TST_TB_1_4_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62235
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_1_4_m_pos on HTS_TST_TB_1_4_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62251
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_1_4_m_neg on HTS_TST_TB_1_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62244
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_5_9_f_pos on HTS_TST_TB_5_9_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62260
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_5_9_f_neg on HTS_TST_TB_5_9_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62236
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_5_9_m_pos on HTS_TST_TB_5_9_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62252
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_5_9_m_neg on HTS_TST_TB_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62245
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_10_14_f_pos on HTS_TST_TB_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62261
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_10_14_f_neg on HTS_TST_TB_10_14_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62237
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_10_14_m_pos on HTS_TST_TB_10_14_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62253
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_10_14_m_neg on HTS_TST_TB_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62246
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_15_19_f_pos on HTS_TST_TB_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62262
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_15_19_f_neg on HTS_TST_TB_15_19_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62238
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_15_19_m_pos on HTS_TST_TB_15_19_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62254
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_15_19_m_neg on HTS_TST_TB_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62247
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_20_24_f_pos on HTS_TST_TB_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62263
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_20_24_f_neg on HTS_TST_TB_20_24_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62239
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_20_24_m_pos on HTS_TST_TB_20_24_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62255
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_20_24_m_neg on HTS_TST_TB_20_24_m_neg.sourceid=ou.organisationunitid

 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561752
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_25_29_f_pos on HTS_TST_TB_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561760
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_25_29_f_neg on HTS_TST_TB_25_29_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561748
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_25_29_m_pos on HTS_TST_TB_25_29_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561756
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_25_29_m_neg on HTS_TST_TB_25_29_m_neg.sourceid=ou.organisationunitid

 /*30-34*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561753
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_30_34_f_pos on HTS_TST_TB_30_34_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561761
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_30_34_f_neg on HTS_TST_TB_30_34_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561749
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_30_34_m_pos on HTS_TST_TB_30_34_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561757
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_30_34_m_neg on HTS_TST_TB_30_34_m_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561754
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_35_39_f_pos on HTS_TST_TB_35_39_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561762
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_35_39_f_neg on HTS_TST_TB_35_39_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561750
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_35_39_m_pos on HTS_TST_TB_35_39_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561758
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_35_39_m_neg on HTS_TST_TB_35_39_m_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480502
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_40_44_f_pos on HTS_TST_TB_40_44_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480506
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_40_44_f_neg on HTS_TST_TB_40_44_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480500
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_40_44_m_pos on HTS_TST_TB_40_44_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480504
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_40_44_m_neg on HTS_TST_TB_40_44_m_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480503
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_45_49_f_pos on HTS_TST_TB_45_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480507
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_45_49_f_neg on HTS_TST_TB_45_49_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480501
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_45_49_m_pos on HTS_TST_TB_45_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480505
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_45_49_m_neg on HTS_TST_TB_45_49_m_neg.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62249
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_50_f_pos on HTS_TST_TB_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62265
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_50_f_neg on HTS_TST_TB_50_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62241
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_50_m_pos on HTS_TST_TB_50_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62257
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_TB_50_m_neg on HTS_TST_TB_50_m_neg.sourceid=ou.organisationunitid

 /*HTS_TST (Facility)-PITC PMTCT (ANC Only) Clinics*/

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=61995
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_10_14_pos on HTS_TST_PMTCT_10_14_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=61999
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_10_14_neg on HTS_TST_PMTCT_10_14_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=62023
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_15_19_pos on HTS_TST_PMTCT_15_19_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=62010
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_15_19_neg on HTS_TST_PMTCT_15_19_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=62036
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_20_24_pos on HTS_TST_PMTCT_20_24_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=62004
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_20_24_neg on HTS_TST_PMTCT_20_24_neg.sourceid=ou.organisationunitid

 /*25+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=563004
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_25_pos on HTS_TST_PMTCT_25_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62040
 and categoryoptioncomboid=563005
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as HTS_TST_PMTCT_25_neg on HTS_TST_PMTCT_25_neg.sourceid=ou.organisationunitid

 /*HTS_TST (Facility)-Other PITC*/
 /*ATIP*/
 /*<1*/
 /*0-8m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566112,566113,566114,566115,566117,566118,566119,566120,566121,566122,566123,566124,1471331)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_0_8_f_pos on atip_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566133,566134,566135,566136,566138,566139,566140,566141,566142,566143,566144,566145,1471333)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_0_8_f_neg on atip_0_8_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565923,565924,565925,565926,565928,565929,565930,565931,565932,565933,565934,565935,565940,1471229)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_0_8_m_pos on atip_0_8_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565944,565945,565946,565947,565949,565950,565951,565952,565953,565954,565955,565956,565961,1471231)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_0_8_m_neg on atip_0_8_m_neg.sourceid=ou.organisationunitid

 /*9-18m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,1471337)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_9_18_f_pos on atip_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,1471339)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_9_18_f_neg on atip_9_18_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566003,1471235)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_9_18_m_pos on atip_9_18_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566024,1471237)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_9_18_m_neg on atip_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566238,566239,566240,566241,566243,566244,566245,566246,566247,566248,566249,566250,1471343)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_19_4_f_pos on atip_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566259,566260,566261,566262,566264,566265,566266,566267,566268,566269,566270,566271,1471345)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_19_4_f_neg on atip_19_4_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566049,566050,566051,566052,566054,566055,566056,566057,566058,566059,566060,566061,566066,1471241)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_19_4_m_pos on atip_19_4_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566070,566071,566072,566073,566075,566076,566077,566078,566079,566080,566081,566082,566087,1471243)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_19_4_m_neg on atip_19_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22256,22349,22405,22498,22509,22560,22597,230359,230360,230361,230362,230363,1471259)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_5_9_f_pos on atip_5_9_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22305,22331,22339,22515,22603,22622,22646,230366,230367,230368,230369,230370,1471261)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_5_9_f_neg on atip_5_9_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22207,22327,22404,22457,22517,22683,22692,230191,230192,230193,230194,230195,437587,1471157)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_5_9_m_pos on atip_5_9_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22170,22189,22346,22430,22478,22561,22576,230198,230199,230200,230201,230202,437588,1471159)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_5_9_m_neg on atip_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22187,22352,22466,22506,22582,22602,22641,230380,230381,230382,230383,230384,1471265)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_10_14_f_pos on atip_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22215,22241,22279,22420,22443,22488,22667,230387,230388,230389,230390,230391,1471267)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_10_14_f_neg on atip_10_14_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22206,22261,22263,22347,22414,22480,22518,230212,230213,230214,230215,230216,437590,1471163)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_10_14_m_pos on atip_10_14_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22240,22307,22416,22477,22496,22619,22668,230219,230220,230221,230222,230223,437591,1471165)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_10_14_m_neg on atip_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22173,22233,22254,22282,22301,22534,22620,230401,230402,230403,230404,230405,1471271)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_15_19_f_pos on atip_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22190,22277,22342,22397,22522,22572,22613,230408,230409,230410,230411,230412,1471273)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_15_19_f_neg on atip_15_19_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22320,22321,22460,22511,22577,22590,22660,230233,230234,230235,230236,230237,437593,1471169)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_15_19_m_pos on atip_15_19_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22177,22361,22385,22386,22413,22465,22686,230240,230241,230242,230243,230244,437594,1471171)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_15_19_m_neg on atip_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22208,22222,22314,22351,22367,22586,22588,230422,230423,230424,230425,230426,1471277)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_20_24_f_pos on atip_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22323,22393,22476,22541,22578,22592,22621,230429,230430,230431,230432,230433,1471279)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_20_24_f_neg on atip_20_24_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22250,22258,22275,22312,22338,22538,22691,230254,230255,230256,230257,230258,437596,1471175)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_20_24_m_pos on atip_20_24_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22265,22278,22309,22357,22394,22403,22415,230261,230262,230263,230264,230265,437597,1471177)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_20_24_m_neg on atip_20_24_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,1471295)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_25_29_f_pos on atip_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,1471297)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_25_29_f_neg on atip_25_29_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561824,1471193)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_25_29_m_pos on atip_25_29_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561845,1471195)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_25_29_m_neg on atip_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,1471325)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_30_49_f_pos on atip_30_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,1471327)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_30_49_f_neg on atip_30_49_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565717,1471223)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_30_49_m_pos on atip_30_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565738,1471225)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_30_49_m_neg on atip_30_49_m_neg.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22264,22313,22412,22482,22485,22514,22643,230464,230465,230466,230467,230468,1471289)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_50_f_pos on atip_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22244,22325,22343,22467,22500,22540,22543,230471,230472,230473,230474,230475,1471291)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_50_f_neg on atip_50_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22168,22238,22550,22570,22642,22656,22670,230296,230297,230298,230299,230300,437602,1471187)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_50_m_pos on atip_50_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22200,22212,22444,22481,22569,22600,22607,230303,230304,230305,230306,230307,437603,1471189)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_50_m_neg on atip_50_m_neg.sourceid=ou.organisationunitid
 
 
 /*HTS_TST (Facility)-POST ANC*/
 /*ATIP CPP*/
 /*<1*/
 /*0-8m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=566129
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_0_8_f_pos on atip_cpp_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=566150
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_0_8_f_neg on atip_cpp_0_8_f_neg.sourceid=ou.organisationunitid


 /*9-18m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=566192
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_9_18_f_pos on atip_cpp_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=566213
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_9_18_f_neg on atip_cpp_9_18_f_neg.sourceid=ou.organisationunitid

 
 /*19-4a*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=566255
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_19_4_f_pos on atip_cpp_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=566276
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_19_4_f_neg on atip_cpp_19_4_f_neg.sourceid=ou.organisationunitid

 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437611
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_5_9_f_pos on atip_cpp_5_9_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437612
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_5_9_f_neg on atip_cpp_5_9_f_neg.sourceid=ou.organisationunitid

/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437615
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_10_14_f_pos on atip_cpp_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437616
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_10_14_f_neg on atip_cpp_10_14_f_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437618
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_15_19_f_pos on atip_cpp_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437619
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_15_19_f_neg on atip_cpp_15_19_f_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437621
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_20_24_f_pos on atip_cpp_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437622
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_20_24_f_neg on atip_cpp_20_24_f_neg.sourceid=ou.organisationunitid

 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=562076
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_25_29_f_pos on atip_cpp_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=562097
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_25_29_f_neg on atip_cpp_25_29_f_neg.sourceid=ou.organisationunitid

 /*30-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=565780
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_30_49_f_pos on atip_cpp_30_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=565801
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_30_49_f_neg on atip_cpp_30_49_f_neg.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437627
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_50_f_pos on atip_cpp_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=437628
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_cpp_50_f_neg on atip_cpp_50_f_neg.sourceid=ou.organisationunitid

 /*Maternidade*/
 /*<1*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (61998,61994)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_men1_pos on mat_men1_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (62017,62000)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_men1_neg on mat_men1_neg.sourceid=ou.organisationunitid

 /*1-4*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=62039
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_1_4_pos on mat_1_4_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=62030
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_1_4_neg on mat_1_4_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=62031
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_5_9_pos on mat_5_9_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=62026
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_5_9_neg on mat_5_9_neg.sourceid=ou.organisationunitid

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (61995,62027)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_10_14_pos on mat_10_14_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (61999,62003)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_10_14_neg on mat_10_14_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (62023,62038)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_15_19_pos on mat_15_19_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (62010,62014)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_15_19_neg on mat_15_19_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (62036,62034)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_20_24_pos on mat_20_24_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (62004,62015)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_20_24_neg on mat_20_24_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (561724,561736)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_25_29_pos on mat_25_29_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (561728,561740)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_25_29_neg on mat_25_29_neg.sourceid=ou.organisationunitid
 
 /*30-34*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (561725,561737)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_30_34_pos on mat_30_34_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (561729,561741)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_30_34_neg on mat_30_34_neg.sourceid=ou.organisationunitid
 
 /*35-39*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (561726,561738)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_35_39_pos on mat_35_39_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (561730,561742)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_35_39_neg on mat_35_39_neg.sourceid=ou.organisationunitid
 
 /*40-44*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=1480204
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_40_44_pos on mat_40_44_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=1480206
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_40_44_neg on mat_40_44_neg.sourceid=ou.organisationunitid
 
 /*45-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=1480205
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_45_49_pos on mat_45_49_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid=1480207
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_45_49_neg on mat_45_49_neg.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (62013,62011)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_50_pos on mat_50_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62041
 and categoryoptioncomboid IN (62009,62006)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as mat_50_neg on mat_50_neg.sourceid=ou.organisationunitid

 /*CPN Parceiros*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=6946
 and categoryoptioncomboid=6924
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as cpn_m_pos on cpn_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=6946
 and categoryoptioncomboid=6925
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as cpn_m_neg on cpn_m_neg.sourceid=ou.organisationunitid

 /*HTS_TST (Facility)-VCT*/
 /*0-8m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565851
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_0_8_f_pos on ats_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565852
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_0_8_f_neg on ats_0_8_f_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565842
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_0_8_m_pos on ats_0_8_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565843
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_0_8_m_neg on ats_0_8_m_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565854
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_9_18_f_pos on ats_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565855
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_9_18_f_neg on ats_9_18_f_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565845
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_9_18_m_pos on ats_9_18_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565846
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_9_18_m_neg on ats_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565857
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_19_4_f_pos on ats_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565858
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_19_4_f_neg on ats_19_4_f_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565848
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_19_4_m_pos on ats_19_4_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565849
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_19_4_m_neg on ats_19_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21867
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_5_9_f_pos on ats_5_9_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21868
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_5_9_f_neg on ats_5_9_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21843
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_5_9_m_pos on ats_5_9_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21844
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_5_9_m_neg on ats_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21870
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_10_14_f_pos on ats_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21871
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_10_14_f_neg on ats_10_14_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21846
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_10_14_m_pos on ats_10_14_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21847
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_10_14_m_neg on ats_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21873
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_15_19_f_pos on ats_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21874
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_15_19_f_neg on ats_15_19_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21849
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_15_19_m_pos on ats_15_19_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21850
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_15_19_m_neg on ats_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21876
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_20_24_f_pos on ats_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21877
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_20_24_f_neg on ats_20_24_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21852
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_20_24_m_pos on ats_20_24_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21853
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_20_24_m_neg on ats_20_24_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=561792
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_25_29_f_pos on ats_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=561793
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_25_29_f_neg on ats_25_29_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=561780
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_25_29_m_pos on ats_25_29_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=561781
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_25_29_m_neg on ats_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565693
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_30_49_f_pos on ats_30_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565694
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_30_49_f_neg on ats_30_49_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565690
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_30_49_m_pos on ats_30_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=565691
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_30_49_m_neg on ats_30_49_m_neg.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21882
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_50_f_pos on ats_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21883
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_50_f_neg on ats_50_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21858
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_50_m_pos on ats_50_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=21815
 and categoryoptioncomboid=21859
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_50_m_neg on ats_50_m_neg.sourceid=ou.organisationunitid


 /*Index Testing*/
 /*ATIP*/
 /*0-8m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566109,566110,566111,566112,566113,566114,566115,566117,566118,566119,566120,566121,566122,566123,566124,566126,566127,566128,566129,1471330,1471331)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_0_8_f_pos on atip_index_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566130,566131,566132,566133,566134,566135,566136,566138,566139,566140,566141,566142,566143,566144,566145,566147,566148,566149,566150,1471332,1471333)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_0_8_f_neg on atip_index_0_8_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565920,565921,565922,565923,565924,565925,565926,565928,565929,565930,565931,565932,565933,565934,565935,565937,565938,565939,565940,1471228,1471229)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_0_8_m_pos on atip_index_0_8_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565941,565942,565943,565944,565945,565946,565947,565949,565950,565951,565952,565953,565954,565955,565956,565958,565959,565960,565961,1471230,1471231)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_0_8_m_neg on atip_index_0_8_m_neg.sourceid=ou.organisationunitid

 /*9-18m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566172,566173,566174,566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,566189,566190,566191,566192,1471336,1471337)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_9_18_f_pos on atip_index_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566193,566194,566195,566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,566210,566211,566212,566213,1471338,1471339)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_9_18_f_neg on atip_index_9_18_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565983,565984,565985,565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566000,566001,566002,566003,1471234,1471235)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_9_18_m_pos on atip_index_9_18_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566004,566005,566006,566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566021,566022,566023,566024,1471236,1471237)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_9_18_m_neg on atip_index_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566235,566236,566237,566238,566239,566240,566241,566243,566244,566245,566246,566247,566248,566249,566250,566252,566253,566254,566255,1471342,1471343)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_19_4_f_pos on atip_index_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566256,566257,566258,566259,566260,566261,566262,566264,566265,566266,566267,566268,566269,566270,566271,566273,566274,566275,566276,1471344,1471345)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_19_4_f_neg on atip_index_19_4_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566046,566047,566048,566049,566050,566051,566052,566054,566055,566056,566057,566058,566059,566060,566061,566063,566064,566065,566066,1471240,1471241)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_19_4_m_pos on atip_index_19_4_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566067,566068,566069,566070,566071,566072,566073,566075,566076,566077,566078,566079,566080,566081,566082,566084,566085,566086,566087,1471242,1471243)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_19_4_m_neg on atip_index_19_4_m_neg.sourceid=ou.organisationunitid

 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22235,22256,22349,22405,22498,22509,22560,427237,22597,427238,22400,230359,230360,230361,230362,230363,22542,437611,338896,1471258,1471259)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_5_9_f_pos on atip_index_5_9_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22299,22587,338898,22295,427239,427240,22305,22331,22339,22515,22603,22622,22646,230366,230367,230368,230369,230370,437612,1471260,1471261)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_5_9_f_neg on atip_index_5_9_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22207,22327,22404,22457,22425,22517,22456,22683,22692,230191,230192,230193,230194,230195,22512,437587,338848,427189,427190,1471156,1471157)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_5_9_m_pos on atip_index_5_9_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22199,22516,338850,22333,22170,22189,22346,22430,22478,22561,22576,230198,230199,230200,230201,230202,437588,427191,427192,1471158,1471159)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_5_9_m_neg on atip_index_5_9_m_neg.sourceid=ou.organisationunitid
 
/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22582,230384,22553,230380,230381,22187,230382,22615,22508,22466,22352,230383,22506,22602,22641,22664,338902,427243,427244,437615,1471264,1471265)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_10_14_f_pos on atip_index_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22279,230391,22658,230387,230388,22488,230389,22213,22306,22667,22215,230390,22443,22241,22420,22202,338904,427245,427246,437616,1471266,1471267)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_10_14_f_neg on atip_index_10_14_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22261,230216,22484,230212,230213,22263,230214,22358,22689,22480,22347,230215,22414,22206,22518,22384,338854,427195,427196,437590,1471162,1471163)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_10_14_m_pos on atip_index_10_14_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22307,230223,22672,230219,230220,22416,230221,22355,22513,22496,22477,230222,22619,22668,22240,22337,338856,427197,427198,437591,1471164,1471165)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_10_14_m_neg on atip_index_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22282,230405,22546,230401,230402,22534,230403,22491,22475,22233,22620,230404,22301,22254,22173,22402,338908,427249,427250,437618,1471270,1471271)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_15_19_f_pos on atip_index_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22397,230412,22328,230408,230409,22190,230410,22292,22311,22277,22342,230411,22522,22613,22572,22495,338910,427251,427252,437619,1471272,1471273)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_15_19_f_neg on atip_index_15_19_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22320,230237,22547,230233,230234,22660,230235,22406,22391,22460,22590,230236,22577,22511,22321,22549,338860,427201,427202,437593,1471168,1471169)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_15_19_m_pos on atip_index_15_19_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22413,230244,22526,230240,230241,22686,230242,22440,22242,22361,22386,230243,22465,22385,22177,22648,338862,427203,427204,437594,1471170,1471171)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_15_19_m_neg on atip_index_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22586,230426,22536,230422,230423,22222,230424,22175,22300,22208,22314,230425,22588,22367,22351,22631,338914,427255,427256,437621,1471276,1471277)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_20_24_f_pos on atip_index_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22393,230433,22218,230429,230430,22621,230431,22336,22294,22592,22578,230432,22541,22476,22323,22537,338916,427257,427258,437622,1471278,1471279)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_20_24_f_neg on atip_index_20_24_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22312,230258,22624,230254,230255,22258,230256,22247,22185,22691,22275,230257,22338,22250,22538,22211,338866,427207,427208,437596,1471174,1471175)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_20_24_m_pos on atip_index_20_24_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22357,230265,22345,230261,230262,22394,230263,22392,22499,22403,22415,230264,22265,22309,22278,22231,338868,427209,427210,437597,1471176,1471177)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_20_24_m_neg on atip_index_20_24_m_neg.sourceid=ou.organisationunitid

 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562056,562057,562058,562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,562073,562074,562075,562076,1471294,1471295)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_25_29_f_pos on atip_index_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562077,562078,562079,562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,562094,562095,562096,562097,1471296,1471297)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_25_29_f_neg on atip_index_25_29_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561804,561805,561806,561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561821,561822,561823,561824,1471192,1471193)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_25_29_m_pos on atip_index_25_29_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561825,561826,561827,561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561842,561843,561844,561845,1471194,1471195)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_25_29_m_neg on atip_index_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565760,565761,565699,565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565714,565715,565716,565717,1471222,1471223)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_30_49_m_pos on atip_index_30_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565781,565782,565720,565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565735,565736,565737,565738,1471224,1471225)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_30_49_m_neg on atip_index_30_49_m_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565697,565698,565762,565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,565777,565778,565779,565780,1471324,1471325)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_30_49_f_pos on atip_index_30_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565718,565719,565783,565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,565798,565799,565800,565801,1471326,1471327)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_30_49_f_neg on atip_index_30_49_f_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22313,230468,22201,230464,230465,22482,230466,22266,22673,22412,22485,230467,22264,22514,22643,22596,338926,427267,427268,437627,1471288,1471289)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_50_f_pos on atip_index_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22325,230475,22461,230471,230472,22540,230473,22276,22438,22543,22244,230474,22500,22343,22467,22322,338928,427269,427270,437628,1471290,1471291)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_50_f_neg on atip_index_50_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22168,230300,22370,230296,230297,22238,230298,22639,22486,22656,22570,230299,22642,22670,22550,22647,338878,427219,427220,437602,1471186,1471187)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_50_m_pos on atip_index_50_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22481,230307,22389,230303,230304,22444,230305,22525,22521,22200,22600,230306,22212,22607,22569,22665,338880,427221,427222,437603,1471188,1471189)
 and attributeoptioncomboid=229786
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_index_50_m_neg on atip_index_50_m_neg.sourceid=ou.organisationunitid

 /*ATS Index*/
 /*0-8m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565851
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_0_8_f_pos on ats_index_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565852
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_0_8_f_neg on ats_index_0_8_f_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565842
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_0_8_m_pos on ats_index_0_8_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565843
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_0_8_m_neg on ats_index_0_8_m_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565854
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_9_18_f_pos on ats_index_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565855
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_9_18_f_neg on ats_index_9_18_f_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565845
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_9_18_m_pos on ats_index_9_18_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565846
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_9_18_m_neg on ats_index_9_18_m_neg.sourceid=ou.organisationunitid
 
 /*19-4a*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565857
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_19_4_f_pos on ats_index_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565858
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_19_4_f_neg on ats_index_19_4_f_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565848
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_19_4_m_pos on ats_index_19_4_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565849
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_19_4_m_neg on ats_index_19_4_m_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21867
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_5_9_f_pos on ats_index_5_9_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21868
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_5_9_f_neg on ats_index_5_9_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21843
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_5_9_m_pos on ats_index_5_9_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21844
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_5_9_m_neg on ats_index_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21870
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_10_14_f_pos on ats_index_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21871
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_10_14_f_neg on ats_index_10_14_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21846
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_10_14_m_pos on ats_index_10_14_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21847
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_10_14_m_neg on ats_index_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21873
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_15_19_f_pos on ats_index_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21874
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_15_19_f_neg on ats_index_15_19_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21849
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_15_19_m_pos on ats_index_15_19_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21850
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_15_19_m_neg on ats_index_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21876
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_20_24_f_pos on ats_index_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21877
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_20_24_f_neg on ats_index_20_24_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21852
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_20_24_m_pos on ats_index_20_24_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21853
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_20_24_m_neg on ats_index_20_24_m_neg.sourceid=ou.organisationunitid

 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=561792
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_25_29_f_pos on ats_index_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=561793
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_25_29_f_neg on ats_index_25_29_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=561780
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_25_29_m_pos on ats_index_25_29_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=561781
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_25_29_m_neg on ats_index_25_29_m_neg.sourceid=ou.organisationunitid
 
 /*30-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565693
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_30_49_f_pos on ats_index_30_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565694
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_30_49_f_neg on ats_index_30_49_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565690
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_30_49_m_pos on ats_index_30_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=565691
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_30_49_m_neg on ats_index_30_49_m_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21882
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_50_f_pos on ats_index_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21883
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_50_f_neg on ats_index_50_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21858
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_50_m_pos on ats_index_50_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=43327
 and categoryoptioncomboid=21859
 and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as ats_index_50_m_neg on ats_index_50_m_neg.sourceid=ou.organisationunitid

 /*PMTCT_STAT (Numerator)*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid IN (199702,199703,199704,199705,199706,199707,199708,199709,562864)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_num on PMTCT_STAT_17q2_num.sourceid=ou.organisationunitid

 /*Age Unknown*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (6920,CASE WHEN periodid IN (5786,3799,3817,18562,19934,20612,35909,35910,36804,27077,27397,32124,17085,17084,17083,104544) THEN 7407 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q1_num on PMTCT_STAT_17q1_num.sourceid=ou.organisationunitid

 /*Age*/
 /*<10*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid IN (199706,199708)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_men10_num on PMTCT_STAT_17q2_men10_num.sourceid=ou.organisationunitid

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid=199705
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_10_14_num on PMTCT_STAT_17q2_10_14_num.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid=199709
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_15_19_num on PMTCT_STAT_17q2_15_19_num.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid=199703
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_20_24_num on PMTCT_STAT_17q2_20_24_num.sourceid=ou.organisationunitid

 /*25-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid IN (199702,199707)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_25_49_num on PMTCT_STAT_17q2_25_49_num.sourceid=ou.organisationunitid

 /*25+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid=562864
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_25_num on PMTCT_STAT_17q2_25_num.sourceid=ou.organisationunitid
 
 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (199720,199729)
 and categoryoptioncomboid=199704
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_50_num on PMTCT_STAT_17q2_50_num.sourceid=ou.organisationunitid

 /*Known Positive*/
 /*<10*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199720
 and categoryoptioncomboid IN (199706,199708)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_men10_known_pos on PMTCT_STAT_17q2_men10_known_pos.sourceid=ou.organisationunitid

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199720
 and categoryoptioncomboid=199705
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_10_14_known_pos on PMTCT_STAT_17q2_10_14_known_pos.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199720
 and categoryoptioncomboid=199709
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_15_19_known_pos on PMTCT_STAT_17q2_15_19_known_pos.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199720
 and categoryoptioncomboid=199703
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_20_24_known_pos on PMTCT_STAT_17q2_20_24_known_pos.sourceid=ou.organisationunitid

 /*25-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199720
 and categoryoptioncomboid IN (199702,199707)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_25_49_known_pos on PMTCT_STAT_17q2_25_49_known_pos.sourceid=ou.organisationunitid
 
 /*25+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199720
 and categoryoptioncomboid=562864
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_25_known_pos on PMTCT_STAT_17q2_25_known_pos.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199720
 and categoryoptioncomboid=199704
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_50_known_pos on PMTCT_STAT_17q2_50_known_pos.sourceid=ou.organisationunitid

 /*Unknown*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (6920)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q1_unk_known_pos on PMTCT_STAT_17q1_unk_known_pos.sourceid=ou.organisationunitid

 /*HTS_TST (Facility)-PITC Inpatient Services*/
 /*0-8m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565920,565921,1471228)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_0_8_m_pos on atip_enf_0_8_m_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566109,566110,1471330)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_0_8_f_pos on atip_enf_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565941,565942,1471230)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_0_8_m_neg on atip_enf_0_8_m_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566130,566131,1471332)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_0_8_f_neg on atip_enf_0_8_f_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565983,565984,1471234)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_9_18_m_pos on atip_enf_9_18_m_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566172,566173,1471336)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_9_18_f_pos on atip_enf_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566004,566005,1471236)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_9_18_m_neg on atip_enf_9_18_m_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566193,566194,1471338)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_9_18_f_neg on atip_enf_9_18_f_neg.sourceid=ou.organisationunitid
 
 /*19m-4a*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566046,566047,1471240)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_19_4_m_pos on atip_enf_19_4_m_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566235,566236,1471342)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_19_4_f_pos on atip_enf_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566067,566068,1471242)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_19_4_m_neg on atip_enf_19_4_m_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (566256,566257,1471344)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_19_4_f_neg on atip_enf_19_4_f_neg.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22400,22542,1471258)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_5_9_f_pos on atip_enf_5_9_f_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22299,22587,1471260)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_5_9_f_neg on atip_enf_5_9_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22425,22456,1471156)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_5_9_m_pos on atip_enf_5_9_m_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22199,22516,1471158)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_5_9_m_neg on atip_enf_5_9_m_neg.sourceid=ou.organisationunitid
 
/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22508,22615,1471264)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_10_14_f_pos on atip_enf_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22213,22306,1471266)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_10_14_f_neg on atip_enf_10_14_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22358,22689,1471162)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_10_14_m_pos on atip_enf_10_14_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22355,22513,1471164)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_10_14_m_neg on atip_enf_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22475,22491,1471270)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_15_19_f_pos on atip_enf_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22292,22311,1471272)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_15_19_f_neg on atip_enf_15_19_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22391,22406,1471168)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_15_19_m_pos on atip_enf_15_19_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22242,22440,1471170)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_15_19_m_neg on atip_enf_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22175,22300,1471276)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_20_24_f_pos on atip_enf_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22294,22336,1471278)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_20_24_f_neg on atip_enf_20_24_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22185,22247,1471174)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_20_24_m_pos on atip_enf_20_24_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22392,22499,1471176)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_20_24_m_neg on atip_enf_20_24_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562056,562057,1471294)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_25_29_f_pos on atip_enf_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562077,562078,1471296)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_25_29_f_neg on atip_enf_25_29_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561804,561805,1471192)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_25_29_m_pos on atip_enf_25_29_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561825,561826,1471194)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_25_29_m_neg on atip_enf_25_29_m_neg.sourceid=ou.organisationunitid

 /*30-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565760,565761,1471324)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_30_49_f_pos on atip_enf_30_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565781,565782,1471326)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_30_49_f_neg on atip_enf_30_49_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565697,565698,1471222)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_30_49_m_pos on atip_enf_30_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565718,565719,1471224)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_30_49_m_neg on atip_enf_30_49_m_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22266,22673,1471288)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_50_f_pos on atip_enf_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22276,22438,1471290)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_50_f_neg on atip_enf_50_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22486,22639,1471186)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_50_m_pos on atip_enf_50_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (22521,22525,1471188)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_enf_50_m_neg on atip_enf_50_m_neg.sourceid=ou.organisationunitid

 /*HTS_TST (Facility)-PITC Emergency Ward*/
/*0-8m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(565937,565922,565938,565939)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_0_8_m_pos on atip_bso_0_8_m_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566126,566111,566127,566128)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_0_8_f_pos on atip_bso_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(565958,565943,565959,565960)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_0_8_m_neg on atip_bso_0_8_m_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566147,566132,566148,566149)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_0_8_f_neg on atip_bso_0_8_f_neg.sourceid=ou.organisationunitid
 
 /*9-18m*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566000,565985,566001,566002)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_9_18_m_pos on atip_bso_9_18_m_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566189,566174,566190,566191)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_9_18_f_pos on atip_bso_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566021,566006,566022,566023)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_9_18_m_neg on atip_bso_9_18_m_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566210,566195,566211,566212)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_9_18_f_neg on atip_bso_9_18_f_neg.sourceid=ou.organisationunitid
 
 /*19m-4a*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566063,566048,566064,566065)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_19_4_m_pos on atip_bso_19_4_m_pos.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566252,566237,566253,566254)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_19_4_f_pos on atip_bso_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566084,566069,566085,566086)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_19_4_m_neg on atip_bso_19_4_m_neg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(566273,566258,566274,566275)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_19_4_f_neg on atip_bso_19_4_f_neg.sourceid=ou.organisationunitid

 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(22235,427237,427238,338896)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_5_9_f_pos on atip_bso_5_9_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338898,22295,427239,427240)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_5_9_f_neg on atip_bso_5_9_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(22512,338848,427189,427190)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_5_9_m_pos on atip_bso_5_9_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338850,22333,427191,427192)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_5_9_m_neg on atip_bso_5_9_m_neg.sourceid=ou.organisationunitid

/*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338902,22664,427243,427244)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_10_14_f_pos on atip_bso_10_14_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338904,22202,427245,427246)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_10_14_f_neg on atip_bso_10_14_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338854,22384,427195,427196)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_10_14_m_pos on atip_bso_10_14_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338856,22337,427197,427198)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_10_14_m_neg on atip_bso_10_14_m_neg.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338908,22402,427249,427250)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_15_19_f_pos on atip_bso_15_19_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338910,22495,427251,427252)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_15_19_f_neg on atip_bso_15_19_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338860,22549,427201,427202)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_15_19_m_pos on atip_bso_15_19_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338862,22648,427203,427204)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_15_19_m_neg on atip_bso_15_19_m_neg.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338914,22631,427255,427256)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_20_24_f_pos on atip_bso_20_24_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338916,22537,427257,427258)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_20_24_f_neg on atip_bso_20_24_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338866,22211,427207,427208)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_20_24_m_pos on atip_bso_20_24_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN(338868,22231,427209,427210)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_20_24_m_neg on atip_bso_20_24_m_neg.sourceid=ou.organisationunitid

 /*25-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=338920
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_49_f_pos on atip_bso_25_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=338922
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_49_f_neg on atip_bso_25_49_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=338872
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_49_m_pos on atip_bso_25_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid=338874
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_49_m_neg on atip_bso_25_49_m_neg.sourceid=ou.organisationunitid
 
 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562073,562058,562074,562075)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_29_f_pos on atip_bso_25_29_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (562094,562079,562095,562096)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_29_f_neg on atip_bso_25_29_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561821,561806,561822,561823)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_29_m_pos on atip_bso_25_29_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (561842,561827,561843,561844)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_25_29_m_neg on atip_bso_25_29_m_neg.sourceid=ou.organisationunitid

 /*30-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565777,565762,565778,565779)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_30_49_f_pos on atip_bso_30_49_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565798,565783,565799,565800)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_30_49_f_neg on atip_bso_30_49_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565714,565699,565715,565716)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_30_49_m_pos on atip_bso_30_49_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (565735,565720,565736,565737)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_30_49_m_neg on atip_bso_30_49_m_neg.sourceid=ou.organisationunitid
 
 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (338926,22596,427267,427268)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_50_f_pos on atip_bso_50_f_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (338928,22322,427269,427270)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_50_f_neg on atip_bso_50_f_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (338878,22647,427219,427220)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_50_m_pos on atip_bso_50_m_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=22693
 and categoryoptioncomboid IN (338880,22665,427221,427222)
 and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as atip_bso_50_m_neg on atip_bso_50_m_neg.sourceid=ou.organisationunitid
 
 /*PMTCT_STAT (Denominator)*/
 /*Age Unknown*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=6913
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q1_den on PMTCT_STAT_17q1_den.sourceid=ou.organisationunitid

 /*Age*/
 /*<10*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199711
 and categoryoptioncomboid IN (199706,199708)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_men10_den on PMTCT_STAT_17q2_men10_den.sourceid=ou.organisationunitid

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199711
 and categoryoptioncomboid=199705
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_10_14_den on PMTCT_STAT_17q2_10_14_den.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199711
 and categoryoptioncomboid=199709
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_15_19_den on PMTCT_STAT_17q2_15_19_den.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199711
 and categoryoptioncomboid=199703
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_20_24_den on PMTCT_STAT_17q2_20_24_den.sourceid=ou.organisationunitid

 /*25-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199711
 and categoryoptioncomboid IN (199702,199707)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_25_49_den on PMTCT_STAT_17q2_25_49_den.sourceid=ou.organisationunitid

 /*25+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199711
 and categoryoptioncomboid=562864
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_25_den on PMTCT_STAT_17q2_25_den.sourceid=ou.organisationunitid

 
 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199711
 and categoryoptioncomboid=199704
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_STAT_17q2_50_den on PMTCT_STAT_17q2_50_den.sourceid=ou.organisationunitid


 /*PMTCT_EID*/
 /*Positive*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (7020,472971)
 and categoryoptioncomboid=7011
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_0_2_pos on PMTCT_EID_0_2_pos.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (23816,472972,648454)
 and categoryoptioncomboid IN (23813,7011)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_2_12_pos_sum_prev on PMTCT_EID_2_12_pos_sum_prev.sourceid=ou.organisationunitid

 /*Negative*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (7020,472971)
 and categoryoptioncomboid=7014
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_0_2_neg on PMTCT_EID_0_2_neg.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid IN (23816,472972)
 and categoryoptioncomboid=23812
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_2_12_neg on PMTCT_EID_2_12_neg.sourceid=ou.organisationunitid

 /*Collected*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=7020
 and categoryoptioncomboid=455205
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_0_2_col on PMTCT_EID_0_2_col.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=23816
 and categoryoptioncomboid=455204
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_2_12_col on PMTCT_EID_2_12_col.sourceid=ou.organisationunitid
 
 /*ART*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=642133
 and categoryoptioncomboid=6989
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_0_2_art on PMTCT_EID_0_2_art.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=642133
 and categoryoptioncomboid=6988
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_2_12_art on PMTCT_EID_2_12_art.sourceid=ou.organisationunitid
 
 
 /*PMTCT_EID_total*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=6990
 and categoryoptioncomboid=6989
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_0_2_total on PMTCT_EID_0_2_total.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=6990
 and categoryoptioncomboid IN(6988,648456)
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_EID_2_12_total on PMTCT_EID_2_12_total.sourceid=ou.organisationunitid
 
/*TB_STAT*/
/*Known Positive*/
/*<1*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62274
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_men1_f on TB_STAT_kp_men1_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62266
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_men1_m on TB_STAT_kp_men1_m.sourceid=ou.organisationunitid
 
 /*1-4*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62275
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_1_4_f on TB_STAT_kp_1_4_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62267
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_1_4_m on TB_STAT_kp_1_4_m.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62276
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_5_9_f on TB_STAT_kp_5_9_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62268
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_5_9_m on TB_STAT_kp_5_9_m.sourceid=ou.organisationunitid

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62277
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_10_14_f on TB_STAT_kp_10_14_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62269
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_10_14_m on TB_STAT_kp_10_14_m.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62278
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_15_19_f on TB_STAT_kp_15_19_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62270
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_15_19_m on TB_STAT_kp_15_19_m.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62279
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_20_24_f on TB_STAT_kp_20_24_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62271
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_20_24_m on TB_STAT_kp_20_24_m.sourceid=ou.organisationunitid

 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561768
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_25_29_f on TB_STAT_kp_25_29_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561764
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_25_29_m on TB_STAT_kp_25_29_m.sourceid=ou.organisationunitid

 /*30-34*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561769
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_30_34_f on TB_STAT_kp_30_34_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561765
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_30_34_m on TB_STAT_kp_30_34_m.sourceid=ou.organisationunitid

 /*35-39*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561770
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_35_39_f on TB_STAT_kp_35_39_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561766
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_35_39_m on TB_STAT_kp_35_39_m.sourceid=ou.organisationunitid

 /*40-44*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480510
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_40_44_f on TB_STAT_kp_40_44_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480508
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_40_44_m on TB_STAT_kp_40_44_m.sourceid=ou.organisationunitid

 /*45-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480511
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_45_49_f on TB_STAT_kp_45_49_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480509
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_45_49_m on TB_STAT_kp_45_49_m.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62281
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_50_f on TB_STAT_kp_50_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62273
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kp_50_m on TB_STAT_kp_50_m.sourceid=ou.organisationunitid
 
 /*Known Negative*/
/*<1*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62290
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_men1_f on TB_STAT_kn_men1_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62282
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_men1_m on TB_STAT_kn_men1_m.sourceid=ou.organisationunitid
 
 /*1-4*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62291
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_1_4_f on TB_STAT_kn_1_4_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62283
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_1_4_m on TB_STAT_kn_1_4_m.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62292
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_5_9_f on TB_STAT_kn_5_9_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62284
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_5_9_m on TB_STAT_kn_5_9_m.sourceid=ou.organisationunitid

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62293
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_10_14_f on TB_STAT_kn_10_14_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62285
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_10_14_m on TB_STAT_kn_10_14_m.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62294
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_15_19_f on TB_STAT_kn_15_19_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62286
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_15_19_m on TB_STAT_kn_15_19_m.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62295
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_20_24_f on TB_STAT_kn_20_24_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62287
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_20_24_m on TB_STAT_kn_20_24_m.sourceid=ou.organisationunitid

 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561776
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_25_29_f on TB_STAT_kn_25_29_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561772
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_25_29_m on TB_STAT_kn_25_29_m.sourceid=ou.organisationunitid

 /*30-34*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561777
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_30_34_f on TB_STAT_kn_30_34_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561773
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_30_34_m on TB_STAT_kn_30_34_m.sourceid=ou.organisationunitid

 /*35-39*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561778
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_35_39_f on TB_STAT_kn_35_39_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=561774
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_35_39_m on TB_STAT_kn_35_39_m.sourceid=ou.organisationunitid

 /*40-44*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480514
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_40_44_f on TB_STAT_kn_40_44_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480512
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_40_44_m on TB_STAT_kn_40_44_m.sourceid=ou.organisationunitid

 /*45-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480515
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_45_49_f on TB_STAT_kn_45_49_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=1480513
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_45_49_m on TB_STAT_kn_45_49_m.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62297
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_50_f on TB_STAT_kn_50_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=62230
 and categoryoptioncomboid=62289
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_kn_50_m on TB_STAT_kn_50_m.sourceid=ou.organisationunitid
 
 /*TB_STAT*/
 /*Denominator*/
/*<1*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562476
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_men1_f on TB_STAT_den_men1_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562465
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_men1_m on TB_STAT_den_men1_m.sourceid=ou.organisationunitid
 
 /*1-4*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562477
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_1_4_f on TB_STAT_den_1_4_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562466
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_1_4_m on TB_STAT_den_1_4_m.sourceid=ou.organisationunitid
 
 /*5-9*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562478
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_5_9_f on TB_STAT_den_5_9_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562467
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_5_9_m on TB_STAT_den_5_9_m.sourceid=ou.organisationunitid

 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562479
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_10_14_f on TB_STAT_den_10_14_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562468
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_10_14_m on TB_STAT_den_10_14_m.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562480
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_15_19_f on TB_STAT_den_15_19_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562469
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_15_19_m on TB_STAT_den_15_19_m.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562481
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_20_24_f on TB_STAT_den_20_24_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562470
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_20_24_m on TB_STAT_den_20_24_m.sourceid=ou.organisationunitid

 /*25-29*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562482
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_25_29_f on TB_STAT_den_25_29_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562471
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_25_29_m on TB_STAT_den_25_29_m.sourceid=ou.organisationunitid

 /*30-34*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562483
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_30_34_f on TB_STAT_den_30_34_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562472
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_30_34_m on TB_STAT_den_30_34_m.sourceid=ou.organisationunitid

 /*35-39*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562484
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_35_39_f on TB_STAT_den_35_39_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562473
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_35_39_m on TB_STAT_den_35_39_m.sourceid=ou.organisationunitid

 /*40-44*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=1480498
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_40_44_f on TB_STAT_den_40_44_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=1480496
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_40_44_m on TB_STAT_den_40_44_m.sourceid=ou.organisationunitid

 /*45-49*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=1480499
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_45_49_f on TB_STAT_den_45_49_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=1480497
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_45_49_m on TB_STAT_den_45_49_m.sourceid=ou.organisationunitid

 /*50+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562486
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_50_f on TB_STAT_den_50_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=199614
 and categoryoptioncomboid=562475
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_STAT_den_50_m on TB_STAT_den_50_m.sourceid=ou.organisationunitid
 
 /*TX_NEW*/
left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=443867
 and categoryoptioncomboid=16
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_num on TX_NEW_num.sourceid=ou.organisationunitid
 
 /*Preg_Breast*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=443945
 and categoryoptioncomboid=443938
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_preg on TX_NEW_preg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=443945
 and categoryoptioncomboid=443937
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_breast on TX_NEW_breast.sourceid=ou.organisationunitid
 
 /*Female*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538076
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_men1_f on TX_NEW_men1_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538078
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_1_4_f on TX_NEW_1_4_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538080
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_5_9_f on TX_NEW_5_9_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444114
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_10_14_f on TX_NEW_10_14_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444116
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_15_19_f on TX_NEW_15_19_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444118
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_20_24_f on TX_NEW_20_24_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=603097
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_25_29_f on TX_NEW_25_29_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=603099
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_30_34_f on TX_NEW_30_34_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=603101
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_35_39_f on TX_NEW_35_39_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538082
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_40_44_f on TX_NEW_40_44_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538084
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_45_49_f on TX_NEW_45_49_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444117
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_50_f on TX_NEW_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538075
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_men1_m on TX_NEW_men1_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538077
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_1_4_m on TX_NEW_1_4_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538079
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_5_9_m on TX_NEW_5_9_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444123
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_10_14_m on TX_NEW_10_14_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444119
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_15_19_m on TX_NEW_15_19_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444120
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_20_24_m on TX_NEW_20_24_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=603096
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_25_29_m on TX_NEW_25_29_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=603098
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_30_34_m on TX_NEW_30_34_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=603100
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_35_39_m on TX_NEW_35_39_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538081
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_40_44_m on TX_NEW_40_44_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=1538083
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_45_49_m on TX_NEW_45_49_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444127
 and categoryoptioncomboid=444121
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_50_m on TX_NEW_50_m.sourceid=ou.organisationunitid
 
 /*TX_CURR*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444204
 and categoryoptioncomboid=16
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_num on TX_CURR_num.sourceid=ou.organisationunitid
 
 /*Female*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538076
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_men1_f on TX_CURR_men1_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538078
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_1_4_f on TX_CURR_1_4_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538080
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_5_9_f on TX_CURR_5_9_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444114
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_10_14_f on TX_CURR_10_14_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444116
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_15_19_f on TX_CURR_15_19_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444118
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_20_24_f on TX_CURR_20_24_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=603097
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_25_29_f on TX_CURR_25_29_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=603099
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_30_34_f on TX_CURR_30_34_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=603101
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_35_39_f on TX_CURR_35_39_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538082
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_40_44_f on TX_CURR_40_44_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538084
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_45_49_f on TX_CURR_45_49_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444117
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_50_f on TX_CURR_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538075
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_men1_m on TX_CURR_men1_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538077
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_1_4_m on TX_CURR_1_4_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538079
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_5_9_m on TX_CURR_5_9_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444123
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_10_14_m on TX_CURR_10_14_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444119
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_15_19_m on TX_CURR_15_19_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444120
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_20_24_m on TX_CURR_20_24_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=603096
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_25_29_m on TX_CURR_25_29_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=603098
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_30_34_m on TX_CURR_30_34_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=603100
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_35_39_m on TX_CURR_35_39_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538081
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_40_44_m on TX_CURR_40_44_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=1538083
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_45_49_m on TX_CURR_45_49_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=444211
 and categoryoptioncomboid=444121
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_50_m on TX_CURR_50_m.sourceid=ou.organisationunitid
 
 /*TX_NEW TX_CURR Coarse*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515648
 and categoryoptioncomboid=481511
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_coarse_f_men15 on TX_NEW_coarse_f_men15.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515648
 and categoryoptioncomboid=481512
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_coarse_f_mai15 on TX_NEW_coarse_f_mai15.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515648
 and categoryoptioncomboid=481513
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_coarse_m_men15 on TX_NEW_coarse_m_men15.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515648
 and categoryoptioncomboid=481510
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_NEW_coarse_m_mai15 on TX_NEW_coarse_m_mai15.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515649
 and categoryoptioncomboid=481511
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_coarse_f_men15 on TX_CURR_coarse_f_men15.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515649
 and categoryoptioncomboid=481512
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_coarse_f_mai15 on TX_CURR_coarse_f_mai15.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515649
 and categoryoptioncomboid=481513
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_coarse_m_men15 on TX_CURR_coarse_m_men15.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=515649
 and categoryoptioncomboid=481510
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_CURR_coarse_m_mai15 on TX_CURR_coarse_m_mai15.sourceid=ou.organisationunitid
 
 /*PMTCT_ART New*/
 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535785
 and categoryoptioncomboid=199705
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_New_10_14 on PMTCT_ART_New_10_14.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535785
 and categoryoptioncomboid=199709
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_New_15_19 on PMTCT_ART_New_15_19.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535785
 and categoryoptioncomboid=199703
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_New_20_24 on PMTCT_ART_New_20_24.sourceid=ou.organisationunitid

 /*25+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535785
 and categoryoptioncomboid=562864
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_New_25 on PMTCT_ART_New_25.sourceid=ou.organisationunitid

 /*PMTCT_ART Already*/
 /*10-14*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535786
 and categoryoptioncomboid=199705
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_Already_10_14 on PMTCT_ART_Already_10_14.sourceid=ou.organisationunitid

 /*15-19*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535786
 and categoryoptioncomboid=199709
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_Already_15_19 on PMTCT_ART_Already_15_19.sourceid=ou.organisationunitid

 /*20-24*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535786
 and categoryoptioncomboid=199703
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_Already_20_24 on PMTCT_ART_Already_20_24.sourceid=ou.organisationunitid

 /*25+*/
 left outer join (
 select sourceid,sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535786
 and categoryoptioncomboid=562864
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as PMTCT_ART_Already_25 on PMTCT_ART_Already_25.sourceid=ou.organisationunitid

/*TB_ART (Numerator)*/
left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num on TB_ART_num.sourceid=ou.organisationunitid

/*Female*/
left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562476
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_men1_f on TB_ART_num_men1_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562477
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_1_4_f on TB_ART_num_1_4_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562478
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_5_9_f on TB_ART_num_5_9_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562479
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_10_14_f on TB_ART_num_10_14_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562480
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_15_19_f on TB_ART_num_15_19_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562481
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_20_24_f on TB_ART_num_20_24_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562482
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_25_29_f on TB_ART_num_25_29_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562483
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_30_34_f on TB_ART_num_30_34_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562484
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_35_39_f on TB_ART_num_35_39_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=1480498
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_40_44_f on TB_ART_num_40_44_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=1480499
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_45_49_f on TB_ART_num_45_49_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562486
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_50_f on TB_ART_num_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562465
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_men1_m on TB_ART_num_men1_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562466
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_1_4_m on TB_ART_num_1_4_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562467
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_5_9_m on TB_ART_num_5_9_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562468
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_10_14_m on TB_ART_num_10_14_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562469
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_15_19_m on TB_ART_num_15_19_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562470
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_20_24_m on TB_ART_num_20_24_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562471
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_25_29_m on TB_ART_num_25_29_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562472
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_30_34_m on TB_ART_num_30_34_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562473
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_35_39_m on TB_ART_num_35_39_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=1480496
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_40_44_m on TB_ART_num_40_44_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=1480497
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_45_49_m on TB_ART_num_45_49_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=298004
 and categoryoptioncomboid=562475
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_num_50_m on TB_ART_num_50_m.sourceid=ou.organisationunitid
 
 /*Female*/
left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562476
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_men1_f on TB_ART_prev_men1_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562477
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_1_4_f on TB_ART_prev_1_4_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562478
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_5_9_f on TB_ART_prev_5_9_f.sourceid=ou.organisationunitid

 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562479
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_10_14_f on TB_ART_prev_10_14_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562480
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_15_19_f on TB_ART_prev_15_19_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562481
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_20_24_f on TB_ART_prev_20_24_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562482
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_25_29_f on TB_ART_prev_25_29_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562483
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_30_34_f on TB_ART_prev_30_34_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562484
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_35_39_f on TB_ART_prev_35_39_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=1480498
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_40_44_f on TB_ART_prev_40_44_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=1480499
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_45_49_f on TB_ART_prev_45_49_f.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562486
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_50_f on TB_ART_prev_50_f.sourceid=ou.organisationunitid
 
 /*Male*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562465
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_men1_m on TB_ART_prev_men1_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562466
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_1_4_m on TB_ART_prev_1_4_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562467
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_5_9_m on TB_ART_prev_5_9_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562468
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_10_14_m on TB_ART_prev_10_14_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562469
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_15_19_m on TB_ART_prev_15_19_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562470
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_20_24_m on TB_ART_prev_20_24_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562471
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_25_29_m on TB_ART_prev_25_29_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562472
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_30_34_m on TB_ART_prev_30_34_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562473
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_35_39_m on TB_ART_prev_35_39_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=1480496
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_40_44_m on TB_ART_prev_40_44_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=1480497
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_45_49_m on TB_ART_prev_45_49_m.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=1535163
 and categoryoptioncomboid=562475
 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=630920) and ps.periodid=p.periodid and p.periodtypeid=3)
 group by sourceid) as TB_ART_prev_50_m on TB_ART_prev_50_m.sourceid=ou.organisationunitid
 
 /*TX_PVLS*/
 /*TX_PVLS (Numerator)*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484185
 and categoryoptioncomboid=484019
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und on TX_PVLS_num_und.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484186
 and categoryoptioncomboid=484027
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_preg on TX_PVLS_num_und_preg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484186
 and categoryoptioncomboid=484025
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_breast on TX_PVLS_num_und_breast.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538090
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_men1 on TX_PVLS_num_und_f_men1.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538096
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_1_4 on TX_PVLS_num_und_f_1_4.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538102
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_5_9 on TX_PVLS_num_und_f_5_9.sourceid=ou.organisationunitid
 
left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484054
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_10_14 on TX_PVLS_num_und_f_10_14.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484040
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_15_19 on TX_PVLS_num_und_f_15_19.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484036
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_20_24 on TX_PVLS_num_und_f_20_24.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=603109
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_25_29 on TX_PVLS_num_und_f_25_29.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=603115
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_30_34 on TX_PVLS_num_und_f_30_34.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=603121
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_35_39 on TX_PVLS_num_und_f_35_39.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538108
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_40_44 on TX_PVLS_num_und_f_40_44.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538114
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_45_49 on TX_PVLS_num_und_f_45_49.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484064
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_f_50 on TX_PVLS_num_und_f_50.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538087
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_men1 on TX_PVLS_num_und_m_men1.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538093
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_1_4 on TX_PVLS_num_und_m_1_4.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538099
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_5_9 on TX_PVLS_num_und_m_5_9.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484052
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_10_14 on TX_PVLS_num_und_m_10_14.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484047
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_15_19 on TX_PVLS_num_und_m_15_19.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484037
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_20_24 on TX_PVLS_num_und_m_20_24.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=603106
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_25_29 on TX_PVLS_num_und_m_25_29.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=603112
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_30_34 on TX_PVLS_num_und_m_30_34.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=603118
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_35_39 on TX_PVLS_num_und_m_35_39.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538105
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_40_44 on TX_PVLS_num_und_m_40_44.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=1538111
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_45_49 on TX_PVLS_num_und_m_45_49.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484188
 and categoryoptioncomboid=484046
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_num_und_m_50 on TX_PVLS_num_und_m_50.sourceid=ou.organisationunitid
 
 /*TX_PVLS (Denominator)*/
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484192
 and categoryoptioncomboid=484019
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und on TX_PVLS_den_und.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484191
 and categoryoptioncomboid=484027
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_preg on TX_PVLS_den_und_preg.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484191
 and categoryoptioncomboid=484025
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_breast on TX_PVLS_den_und_breast.sourceid=ou.organisationunitid 
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538090
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_men1 on TX_PVLS_den_und_f_men1.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538096
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_1_4 on TX_PVLS_den_und_f_1_4.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538102
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_5_9 on TX_PVLS_den_und_f_5_9.sourceid=ou.organisationunitid
 
left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484054
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_10_14 on TX_PVLS_den_und_f_10_14.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484040
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_15_19 on TX_PVLS_den_und_f_15_19.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484036
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_20_24 on TX_PVLS_den_und_f_20_24.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=603109
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_25_29 on TX_PVLS_den_und_f_25_29.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=603115
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_30_34 on TX_PVLS_den_und_f_30_34.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=603121
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_35_39 on TX_PVLS_den_und_f_35_39.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538108
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_40_44 on TX_PVLS_den_und_f_40_44.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538114
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_45_49 on TX_PVLS_den_und_f_45_49.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484064
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_f_50 on TX_PVLS_den_und_f_50.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538087
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_men1 on TX_PVLS_den_und_m_men1.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538093
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_1_4 on TX_PVLS_den_und_m_1_4.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538099
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_5_9 on TX_PVLS_den_und_m_5_9.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484052
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_10_14 on TX_PVLS_den_und_m_10_14.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484047
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_15_19 on TX_PVLS_den_und_m_15_19.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484037
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_20_24 on TX_PVLS_den_und_m_20_24.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=603106
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_25_29 on TX_PVLS_den_und_m_25_29.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=603112
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_30_34 on TX_PVLS_den_und_m_30_34.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=603118
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_35_39 on TX_PVLS_den_und_m_35_39.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538105
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_40_44 on TX_PVLS_den_und_m_40_44.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=1538111
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_45_49 on TX_PVLS_den_und_m_45_49.sourceid=ou.organisationunitid
 
 left outer join (
 select sourceid, sum(cast(value as double precision)) as value
 from datavalue
 where dataelementid=484189
 and categoryoptioncomboid=484046
 and periodid=(select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=630920))
 group by sourceid) as TX_PVLS_den_und_m_50 on TX_PVLS_den_und_m_50.sourceid=ou.organisationunitid
 
 
where ous.level=4 and ous.idlevel2=110 order by district.name || ' / ' || ou.name ASC;