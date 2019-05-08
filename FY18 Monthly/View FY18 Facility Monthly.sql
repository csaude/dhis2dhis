select district.name || ' / ' || ou.name as facility,
'' AS placeholder1,
/*Quarterly*/
/*HTS_TST_num*/
(
/*HTS_TST (Facility) - PITC Inpatient Services*/
(COALESCE(atip_enf_men1_pos.value,0)+COALESCE(atip_enf_0_8_f_pos.value,0)+COALESCE(atip_enf_0_8_m_pos.value,0)) +
(COALESCE(atip_enf_men1_neg.value,0)+COALESCE(atip_enf_0_8_f_neg.value,0)+COALESCE(atip_enf_0_8_m_neg.value,0)) +
(COALESCE(atip_enf_1_9_pos.value,0)+COALESCE(atip_enf_19_4_f_pos.value,0)+COALESCE(atip_enf_19_4_m_pos.value,0)+COALESCE(atip_enf_9_18_f_pos.value,0)+COALESCE(atip_enf_9_18_m_pos.value,0)) +
(COALESCE(atip_enf_1_9_neg.value,0)+COALESCE(atip_enf_19_4_f_neg.value,0)+COALESCE(atip_enf_19_4_m_neg.value,0)+COALESCE(atip_enf_9_18_f_neg.value,0)+COALESCE(atip_enf_9_18_m_neg.value,0)) +
COALESCE(atip_enf_10_14_f_pos.value,0) +
COALESCE(atip_enf_10_14_f_neg.value,0) +
COALESCE(atip_enf_10_14_m_pos.value,0) +
COALESCE(atip_enf_10_14_m_neg.value,0) +
COALESCE(atip_enf_15_19_f_pos.value,0) +
COALESCE(atip_enf_15_19_f_neg.value,0) +
COALESCE(atip_enf_15_19_m_pos.value,0) +
COALESCE(atip_enf_15_19_m_neg.value,0) +
COALESCE(atip_enf_20_24_f_pos.value,0) +
COALESCE(atip_enf_20_24_f_neg.value,0) +
COALESCE(atip_enf_20_24_m_pos.value,0) +
COALESCE(atip_enf_20_24_m_neg.value,0) +
(COALESCE(atip_enf_25_49_f_pos.value,0)+COALESCE(atip_enf_25_29_f_pos.value,0)+COALESCE(atip_enf_30_49_f_pos.value,0)) +
(COALESCE(atip_enf_25_49_f_neg.value,0)+COALESCE(atip_enf_25_29_f_neg.value,0)+COALESCE(atip_enf_30_49_f_neg.value,0)) +
(COALESCE(atip_enf_25_49_m_pos.value,0)+COALESCE(atip_enf_25_29_m_pos.value,0)+COALESCE(atip_enf_30_49_m_pos.value,0)) +
(COALESCE(atip_enf_25_49_m_neg.value,0)+COALESCE(atip_enf_25_29_m_neg.value,0)+COALESCE(atip_enf_30_49_m_neg.value,0)) +
COALESCE(atip_enf_50_f_pos.value,0) +
COALESCE(atip_enf_50_f_neg.value,0) +
COALESCE(atip_enf_50_m_pos.value,0) +
COALESCE(atip_enf_50_m_neg.value,0) +
/*HTS_TST (Facility) - PITC Pediatric Services*/
COALESCE(HTS_TST_Pediatric_pos.value,0) +
COALESCE(HTS_TST_Pediatric_neg.value,0) +
/*HTS_TST (Facility) - PITC - TB Clinics*/
COALESCE(HTS_TST_TB_men1_pos.value,0)+
COALESCE(HTS_TST_TB_men1_neg.value,0)+
COALESCE(HTS_TST_TB_1_9_pos.value,0) +
COALESCE(HTS_TST_TB_1_9_neg.value,0) +
COALESCE(HTS_TST_TB_10_14_f_pos.value,0) +
COALESCE(HTS_TST_TB_10_14_f_neg.value,0) +
COALESCE(HTS_TST_TB_10_14_m_pos.value,0) +
COALESCE(HTS_TST_TB_10_14_m_neg.value,0) +
COALESCE(HTS_TST_TB_15_19_f_pos.value,0) +
COALESCE(HTS_TST_TB_15_19_f_neg.value,0) +
COALESCE(HTS_TST_TB_15_19_m_pos.value,0) +
COALESCE(HTS_TST_TB_15_19_m_neg.value,0) +
COALESCE(HTS_TST_TB_20_24_f_pos.value,0) +
COALESCE(HTS_TST_TB_20_24_f_neg.value,0) +
COALESCE(HTS_TST_TB_20_24_m_pos.value,0) +
COALESCE(HTS_TST_TB_20_24_m_neg.value,0) +
(COALESCE(HTS_TST_TB_25_49_f_pos.value,0)+COALESCE(HTS_TST_TB_25_29_f_pos.value,0)+COALESCE(HTS_TST_TB_30_34_f_pos.value,0)+COALESCE(HTS_TST_TB_35_39_f_pos.value,0)+COALESCE(HTS_TST_TB_40_49_f_pos.value,0)) +
(COALESCE(HTS_TST_TB_25_49_f_neg.value,0)+COALESCE(HTS_TST_TB_25_29_f_neg.value,0)+COALESCE(HTS_TST_TB_30_34_f_neg.value,0)+COALESCE(HTS_TST_TB_35_39_f_neg.value,0)+COALESCE(HTS_TST_TB_40_49_f_neg.value,0)) +
(COALESCE(HTS_TST_TB_25_49_m_pos.value,0)+COALESCE(HTS_TST_TB_25_29_m_pos.value,0)+COALESCE(HTS_TST_TB_30_34_m_pos.value,0)+COALESCE(HTS_TST_TB_35_39_m_pos.value,0)+COALESCE(HTS_TST_TB_40_49_m_pos.value,0)) +
(COALESCE(HTS_TST_TB_25_49_m_neg.value,0)+COALESCE(HTS_TST_TB_25_29_m_neg.value,0)+COALESCE(HTS_TST_TB_30_34_m_neg.value,0)+COALESCE(HTS_TST_TB_35_39_m_neg.value,0)+COALESCE(HTS_TST_TB_40_49_m_neg.value,0)) +
COALESCE(HTS_TST_TB_50_f_pos.value,0) +
COALESCE(HTS_TST_TB_50_f_neg.value,0) +
COALESCE(HTS_TST_TB_50_m_pos.value,0) +
COALESCE(HTS_TST_TB_50_m_neg.value,0) +
/*HTS_TST (Facility) - PITC PMTCT (ANC Only) Clinics*/
COALESCE(HTS_TST_PMTCT_men1_pos.value,0)+
COALESCE(HTS_TST_PMTCT_men1_neg.value,0)+
COALESCE(HTS_TST_PMTCT_1_9_pos.value,0) +
COALESCE(HTS_TST_PMTCT_1_9_neg.value,0) +
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0) +
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0) +
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0) +
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0) +
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0) +
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0) +
(COALESCE(HTS_TST_PMTCT_25_49_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_pos.value,0)) +
(COALESCE(HTS_TST_PMTCT_25_49_neg.value,0)+COALESCE(HTS_TST_PMTCT_25_neg.value,0)) +
COALESCE(HTS_TST_PMTCT_50_pos.value,0) +
COALESCE(HTS_TST_PMTCT_50_neg.value,0) +
(COALESCE(HTS_TST_PMTCT_men1_pos.value,0)+COALESCE(HTS_TST_PMTCT_1_9_pos.value,0)) +
(COALESCE(HTS_TST_PMTCT_men1_neg.value,0)+COALESCE(HTS_TST_PMTCT_1_9_neg.value,0)) +
/*HTS_TST (Facility) - PITC Emergency Ward*/
(COALESCE(atip_bso_0_8_f_pos.value,0)+COALESCE(atip_bso_0_8_m_pos.value,0)) +
(COALESCE(atip_bso_0_8_f_neg.value,0)+COALESCE(atip_bso_0_8_m_neg.value,0)) +
(COALESCE(atip_bso_1_9_pos.value,0)+COALESCE(atip_bso_19_4_f_pos.value,0)+COALESCE(atip_bso_19_4_m_pos.value,0)+COALESCE(atip_bso_9_18_f_pos.value,0)+COALESCE(atip_bso_9_18_m_pos.value,0)) +
(COALESCE(atip_bso_1_9_neg.value,0)+COALESCE(atip_bso_19_4_f_neg.value,0)+COALESCE(atip_bso_19_4_m_neg.value,0)+COALESCE(atip_bso_9_18_f_neg.value,0)+COALESCE(atip_bso_9_18_m_neg.value,0)) +
COALESCE(atip_bso_10_14_f_pos.value,0) +
COALESCE(atip_bso_10_14_f_neg.value,0) +
COALESCE(atip_bso_10_14_m_pos.value,0) +
COALESCE(atip_bso_10_14_m_neg.value,0) +
COALESCE(atip_bso_15_19_f_pos.value,0) +
COALESCE(atip_bso_15_19_f_neg.value,0) +
COALESCE(atip_bso_15_19_m_pos.value,0) +
COALESCE(atip_bso_15_19_m_neg.value,0) +
COALESCE(atip_bso_20_24_f_pos.value,0) +
COALESCE(atip_bso_20_24_f_neg.value,0) +
COALESCE(atip_bso_20_24_m_pos.value,0) +
COALESCE(atip_bso_20_24_m_neg.value,0) +
(COALESCE(atip_bso_25_49_f_pos.value,0)+COALESCE(atip_bso_25_29_f_pos.value,0)+COALESCE(atip_bso_30_49_f_pos.value,0)) +
(COALESCE(atip_bso_25_49_f_neg.value,0)+COALESCE(atip_bso_25_29_f_neg.value,0)+COALESCE(atip_bso_30_49_f_neg.value,0)) +
(COALESCE(atip_bso_25_49_m_pos.value,0)+COALESCE(atip_bso_25_29_m_pos.value,0)+COALESCE(atip_bso_30_49_m_pos.value,0)) +
(COALESCE(atip_bso_25_49_m_neg.value,0)+COALESCE(atip_bso_25_29_m_neg.value,0)+COALESCE(atip_bso_30_49_m_neg.value,0)) +
COALESCE(atip_bso_50_f_pos.value,0) +
COALESCE(atip_bso_50_f_neg.value,0) +
COALESCE(atip_bso_50_m_pos.value,0) +
COALESCE(atip_bso_50_m_neg.value,0) +
/*HTS_TST (Facility) - Other PITC*/
COALESCE(cpn_m_pos.value,0) +
COALESCE(cpn_m_neg.value,0) +
(COALESCE(atip_men1_pos.value,0)+COALESCE(mat_men1_pos.value,0)+COALESCE(atip_0_8_f_pos.value,0)+COALESCE(atip_0_8_m_pos.value,0)) +
(COALESCE(atip_men1_neg.value,0)+COALESCE(mat_men1_neg.value,0)+COALESCE(atip_0_8_f_neg.value,0)+COALESCE(atip_0_8_m_neg.value,0)) +
(COALESCE(atip_1_9_pos.value,0)+COALESCE(mat_1_9_pos.value,0)+COALESCE(atip_19_4_f_pos.value,0)+COALESCE(atip_19_4_m_pos.value,0)+COALESCE(atip_9_18_f_pos.value,0)+COALESCE(atip_9_18_m_pos.value,0)) +
(COALESCE(atip_1_9_neg.value,0)+COALESCE(mat_1_9_neg.value,0)+COALESCE(atip_19_4_f_neg.value,0)+COALESCE(atip_19_4_m_neg.value,0)+COALESCE(atip_9_18_f_neg.value,0)+COALESCE(atip_9_18_m_neg.value,0)) +
(COALESCE(atip_10_14_f_pos.value,0)+COALESCE(mat_10_14_pos.value,0)) +
(COALESCE(atip_10_14_f_neg.value,0)+COALESCE(mat_10_14_neg.value,0)) +
COALESCE(atip_10_14_m_pos.value,0) +
COALESCE(atip_10_14_m_neg.value,0) +
(COALESCE(atip_15_19_f_pos.value,0)+COALESCE(mat_15_19_pos.value,0)) +
(COALESCE(atip_15_19_f_neg.value,0)+COALESCE(mat_15_19_neg.value,0)) +
COALESCE(atip_15_19_m_pos.value,0) +
COALESCE(atip_15_19_m_neg.value,0) +
(COALESCE(atip_20_24_f_pos.value,0)+COALESCE(mat_20_24_pos.value,0)) +
(COALESCE(atip_20_24_f_neg.value,0)+COALESCE(mat_20_24_neg.value,0)) +
COALESCE(atip_20_24_m_pos.value,0) +
COALESCE(atip_20_24_m_neg.value,0) +
(COALESCE(atip_25_49_f_pos.value,0)+COALESCE(mat_25_49_pos.value,0)+COALESCE(atip_25_29_f_pos.value,0)+COALESCE(atip_30_49_f_pos.value,0)+COALESCE(mat_25_29_pos.value,0)+COALESCE(mat_30_34_pos.value,0)+COALESCE(mat_35_39_pos.value,0)+COALESCE(mat_40_49_pos.value,0)) +
(COALESCE(atip_25_49_f_neg.value,0)+COALESCE(mat_25_49_neg.value,0)+COALESCE(atip_25_29_f_neg.value,0)+COALESCE(atip_30_49_f_neg.value,0)+COALESCE(mat_25_29_neg.value,0)+COALESCE(mat_30_34_neg.value,0)+COALESCE(mat_35_39_neg.value,0)+COALESCE(mat_40_49_neg.value,0)) +
(COALESCE(atip_25_49_m_pos.value,0)+COALESCE(atip_25_29_m_pos.value,0)+COALESCE(atip_30_49_m_pos.value,0)) +
(COALESCE(atip_25_49_m_neg.value,0)+COALESCE(atip_25_29_m_neg.value,0)+COALESCE(atip_30_49_m_neg.value,0)) +
(COALESCE(atip_50_f_pos.value,0)+COALESCE(mat_50_pos.value,0)) +
(COALESCE(atip_50_f_neg.value,0)+COALESCE(mat_50_neg.value,0)) +
COALESCE(atip_50_m_pos.value,0) +
COALESCE(atip_50_m_neg.value,0) +
/*HTS_TST (Facility) - VCT*/
(COALESCE(ats_men1_pos.value,0)+COALESCE(ats_0_8_f_pos.value,0)+COALESCE(ats_0_8_m_pos.value,0)) +
(COALESCE(ats_men1_neg.value,0)+COALESCE(ats_0_8_f_neg.value,0)+COALESCE(ats_0_8_m_neg.value,0)) +
(COALESCE(ats_1_9_pos.value,0)+COALESCE(ats_19_4_f_pos.value,0)+COALESCE(ats_19_4_m_pos.value,0)+COALESCE(ats_9_18_f_pos.value,0)+COALESCE(ats_9_18_m_pos.value,0)) +
(COALESCE(ats_1_9_neg.value,0)+COALESCE(ats_19_4_f_neg.value,0)+COALESCE(ats_19_4_m_neg.value,0)+COALESCE(ats_9_18_f_neg.value,0)+COALESCE(ats_9_18_m_neg.value,0)) +
COALESCE(ats_10_14_f_pos.value,0) +
COALESCE(ats_10_14_f_neg.value,0) +
COALESCE(ats_10_14_m_pos.value,0) +
COALESCE(ats_10_14_m_neg.value,0) +
COALESCE(ats_15_19_f_pos.value,0) +
COALESCE(ats_15_19_f_neg.value,0) +
COALESCE(ats_15_19_m_pos.value,0) +
COALESCE(ats_15_19_m_neg.value,0) +
COALESCE(ats_20_24_f_pos.value,0) +
COALESCE(ats_20_24_f_neg.value,0) +
COALESCE(ats_20_24_m_pos.value,0) +
COALESCE(ats_20_24_m_neg.value,0) +
(COALESCE(ats_25_49_f_pos.value,0)+COALESCE(ats_25_29_f_pos.value,0)+COALESCE(ats_30_49_f_pos.value,0)) +
(COALESCE(ats_25_49_f_neg.value,0)+COALESCE(ats_25_29_f_neg.value,0)+COALESCE(ats_30_49_f_neg.value,0)) +
(COALESCE(ats_25_49_m_pos.value,0)+COALESCE(ats_25_29_m_pos.value,0)+COALESCE(ats_30_49_m_pos.value,0)) +
(COALESCE(ats_25_49_m_neg.value,0)+COALESCE(ats_25_29_m_neg.value,0)+COALESCE(ats_30_49_m_neg.value,0)) +
COALESCE(ats_50_f_pos.value,0) +
COALESCE(ats_50_f_neg.value,0) +
COALESCE(ats_50_m_pos.value,0) +
COALESCE(ats_50_m_neg.value,0) +
/*Index Testing*/
(COALESCE(atip_index_men1_pos.value,0)+COALESCE(ats_index_men1_pos.value,0)+COALESCE(atip_index_0_8_f_pos.value,0)+COALESCE(atip_index_0_8_m_pos.value,0)+COALESCE(ats_index_0_8_f_pos.value,0)+COALESCE(ats_index_0_8_m_pos.value,0)) +
(COALESCE(atip_index_men1_neg.value,0)+COALESCE(ats_index_men1_neg.value,0)+COALESCE(atip_index_0_8_f_neg.value,0)+COALESCE(atip_index_0_8_m_neg.value,0)+COALESCE(ats_index_0_8_f_neg.value,0)+COALESCE(ats_index_0_8_m_neg.value,0)) +
(COALESCE(atip_index_1_9_pos.value,0)+COALESCE(ats_index_1_9_pos.value,0)+COALESCE(atip_index_19_4_f_pos.value,0)+COALESCE(atip_index_19_4_m_pos.value,0)+COALESCE(ats_index_19_4_f_pos.value,0)+COALESCE(ats_index_19_4_m_pos.value,0)+COALESCE(ats_index_9_18_f_pos.value,0)+COALESCE(ats_index_9_18_m_pos.value,0)+COALESCE(atip_index_9_18_f_pos.value,0)+COALESCE(atip_index_9_18_m_pos.value,0)) +
(COALESCE(atip_index_1_9_neg.value,0)+COALESCE(ats_index_1_9_neg.value,0)+COALESCE(atip_index_19_4_f_neg.value,0)+COALESCE(atip_index_19_4_m_neg.value,0)+COALESCE(ats_index_19_4_f_neg.value,0)+COALESCE(ats_index_19_4_m_neg.value,0)+COALESCE(ats_index_9_18_f_neg.value,0)+COALESCE(ats_index_9_18_m_neg.value,0)+COALESCE(atip_index_9_18_f_neg.value,0)+COALESCE(atip_index_9_18_m_neg.value,0)) +
(COALESCE(atip_index_10_14_f_pos.value,0)+COALESCE(ats_index_10_14_f_pos.value,0)) +
(COALESCE(atip_index_10_14_f_neg.value,0)+COALESCE(ats_index_10_14_f_neg.value,0)) +
(COALESCE(atip_index_10_14_m_pos.value,0)+COALESCE(ats_index_10_14_m_pos.value,0)) +
(COALESCE(atip_index_10_14_m_neg.value,0)+COALESCE(ats_index_10_14_m_neg.value,0)) +
(COALESCE(atip_index_15_19_f_pos.value,0)+COALESCE(ats_index_15_19_f_pos.value,0)) +
(COALESCE(atip_index_15_19_f_neg.value,0)+COALESCE(ats_index_15_19_f_neg.value,0)) +
(COALESCE(atip_index_15_19_m_pos.value,0)+COALESCE(ats_index_15_19_m_pos.value,0)) +
(COALESCE(atip_index_15_19_m_neg.value,0)+COALESCE(ats_index_15_19_m_neg.value,0)) +
(COALESCE(atip_index_20_24_f_pos.value,0)+COALESCE(ats_index_20_24_f_pos.value,0)) +
(COALESCE(atip_index_20_24_f_neg.value,0)+COALESCE(ats_index_20_24_f_neg.value,0)) +
(COALESCE(atip_index_20_24_m_pos.value,0)+COALESCE(ats_index_20_24_m_pos.value,0)) +
(COALESCE(atip_index_20_24_m_neg.value,0)+COALESCE(ats_index_20_24_m_neg.value,0)) +
(COALESCE(atip_index_25_49_f_pos.value,0)+COALESCE(ats_index_25_49_f_pos.value,0)+COALESCE(atip_index_25_29_f_pos.value,0)+COALESCE(atip_index_30_49_f_pos.value,0)+COALESCE(ats_index_25_29_f_pos.value,0)+COALESCE(ats_index_30_49_f_pos.value,0)) +
(COALESCE(atip_index_25_49_f_neg.value,0)+COALESCE(ats_index_25_49_f_neg.value,0)+COALESCE(atip_index_25_29_f_neg.value,0)+COALESCE(atip_index_30_49_f_neg.value,0)+COALESCE(ats_index_25_29_f_neg.value,0)+COALESCE(ats_index_30_49_f_neg.value,0)) +
(COALESCE(atip_index_25_49_m_pos.value,0)+COALESCE(ats_index_25_49_m_pos.value,0)+COALESCE(atip_index_25_29_m_pos.value,0)+COALESCE(atip_index_30_49_m_pos.value,0)+COALESCE(ats_index_25_29_m_pos.value,0)+COALESCE(ats_index_30_49_m_pos.value,0)) +
(COALESCE(atip_index_25_49_m_neg.value,0)+COALESCE(ats_index_25_49_m_neg.value,0)+COALESCE(atip_index_25_29_m_neg.value,0)+COALESCE(atip_index_30_49_m_neg.value,0)+COALESCE(ats_index_25_29_m_neg.value,0)+COALESCE(ats_index_30_49_m_neg.value,0)) +
(COALESCE(atip_index_50_f_pos.value,0)+COALESCE(ats_index_50_f_pos.value,0)) +
(COALESCE(atip_index_50_f_neg.value,0)+COALESCE(ats_index_50_f_neg.value,0)) +
(COALESCE(atip_index_50_m_pos.value,0)+COALESCE(ats_index_50_m_pos.value,0)) +
(COALESCE(atip_index_50_m_neg.value,0)+COALESCE(ats_index_50_m_neg.value,0)) 
) AS HTS_TST_num,
'' AS placeholder2,
'' AS placeholder3,
'' AS placeholder4,
'' AS placeholder5,
/*Knowing HIV Status*/
/*HTS_TST (Facility) - PITC Inpatient Services*/
(COALESCE(atip_enf_men1_pos.value,0)+COALESCE(atip_enf_0_8_f_pos.value,0)+COALESCE(atip_enf_0_8_m_pos.value,0)) AS HTS_TST_Inpatient_men1_pos,
(COALESCE(atip_enf_men1_neg.value,0)+COALESCE(atip_enf_0_8_f_neg.value,0)+COALESCE(atip_enf_0_8_m_neg.value,0)) AS HTS_TST_Inpatient_men1_neg,
(COALESCE(atip_enf_1_9_pos.value,0)+COALESCE(atip_enf_19_4_f_pos.value,0)+COALESCE(atip_enf_19_4_m_pos.value,0)+COALESCE(atip_enf_9_18_f_pos.value,0)+COALESCE(atip_enf_9_18_m_pos.value,0)) AS HTS_TST_Inpatient_1_9_pos,
(COALESCE(atip_enf_1_9_neg.value,0)+COALESCE(atip_enf_19_4_f_neg.value,0)+COALESCE(atip_enf_19_4_m_neg.value,0)+COALESCE(atip_enf_9_18_f_neg.value,0)+COALESCE(atip_enf_9_18_m_neg.value,0)) AS HTS_TST_Inpatient_1_9_neg,
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
(COALESCE(atip_enf_25_49_f_pos.value,0)+COALESCE(atip_enf_25_29_f_pos.value,0)+COALESCE(atip_enf_30_49_f_pos.value,0)) AS HTS_TST_Inpatient_25_49_f_pos,
(COALESCE(atip_enf_25_49_f_neg.value,0)+COALESCE(atip_enf_25_29_f_neg.value,0)+COALESCE(atip_enf_30_49_f_neg.value,0)) AS HTS_TST_Inpatient_25_49_f_neg,
(COALESCE(atip_enf_25_49_m_pos.value,0)+COALESCE(atip_enf_25_29_m_pos.value,0)+COALESCE(atip_enf_30_49_m_pos.value,0)) AS HTS_TST_Inpatient_25_49_m_pos,
(COALESCE(atip_enf_25_49_m_neg.value,0)+COALESCE(atip_enf_25_29_m_neg.value,0)+COALESCE(atip_enf_30_49_m_neg.value,0)) AS HTS_TST_Inpatient_25_49_m_neg,
COALESCE(atip_enf_50_f_pos.value,0) AS HTS_TST_Inpatient_50_f_pos,
COALESCE(atip_enf_50_f_neg.value,0) AS HTS_TST_Inpatient_50_f_neg,
COALESCE(atip_enf_50_m_pos.value,0) AS HTS_TST_Inpatient_50_m_pos,
COALESCE(atip_enf_50_m_neg.value,0) AS HTS_TST_Inpatient_50_m_neg,
/*HTS_TST (Facility) - PITC Pediatric Services*/
COALESCE(HTS_TST_Pediatric_pos.value,0) AS HTS_TST_Pediatric_pos,
COALESCE(HTS_TST_Pediatric_neg.value,0) AS HTS_TST_Pediatric_neg,
'' AS placeholder6,
'' AS placeholder7,
'' AS placeholder8,
'' AS placeholder9,
/*HTS_TST (Facility) - PITC - TB Clinics*/
COALESCE(HTS_TST_TB_men1_pos.value,0) AS HTS_TST_TB_men1_pos,
COALESCE(HTS_TST_TB_men1_neg.value,0) AS HTS_TST_TB_men1_neg,
COALESCE(HTS_TST_TB_1_9_pos.value,0) AS HTS_TST_TB_1_9_pos,
COALESCE(HTS_TST_TB_1_9_neg.value,0) AS HTS_TST_TB_1_9_neg,
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
(COALESCE(HTS_TST_TB_25_49_f_pos.value,0)+COALESCE(HTS_TST_TB_25_29_f_pos.value,0)+COALESCE(HTS_TST_TB_30_34_f_pos.value,0)+COALESCE(HTS_TST_TB_35_39_f_pos.value,0)+COALESCE(HTS_TST_TB_40_49_f_pos.value,0)) AS HTS_TST_TB_25_49_f_pos,
(COALESCE(HTS_TST_TB_25_49_f_neg.value,0)+COALESCE(HTS_TST_TB_25_29_f_neg.value,0)+COALESCE(HTS_TST_TB_30_34_f_neg.value,0)+COALESCE(HTS_TST_TB_35_39_f_neg.value,0)+COALESCE(HTS_TST_TB_40_49_f_neg.value,0)) AS HTS_TST_TB_25_49_f_neg,
(COALESCE(HTS_TST_TB_25_49_m_pos.value,0)+COALESCE(HTS_TST_TB_25_29_m_pos.value,0)+COALESCE(HTS_TST_TB_30_34_m_pos.value,0)+COALESCE(HTS_TST_TB_35_39_m_pos.value,0)+COALESCE(HTS_TST_TB_40_49_m_pos.value,0)) AS HTS_TST_TB_25_49_m_pos,
(COALESCE(HTS_TST_TB_25_49_m_neg.value,0)+COALESCE(HTS_TST_TB_25_29_m_neg.value,0)+COALESCE(HTS_TST_TB_30_34_m_neg.value,0)+COALESCE(HTS_TST_TB_35_39_m_neg.value,0)+COALESCE(HTS_TST_TB_40_49_m_neg.value,0)) AS HTS_TST_TB_25_49_m_neg,
COALESCE(HTS_TST_TB_50_f_pos.value,0) AS HTS_TST_TB_50_f_pos,
COALESCE(HTS_TST_TB_50_f_neg.value,0) AS HTS_TST_TB_50_f_neg,
COALESCE(HTS_TST_TB_50_m_pos.value,0) AS HTS_TST_TB_50_m_pos,
COALESCE(HTS_TST_TB_50_m_neg.value,0) AS HTS_TST_TB_50_m_neg,
'' AS placeholder10,
'' AS placeholder11,
'' AS placeholder12,
'' AS placeholder13,
'' AS placeholder14,
'' AS placeholder15,
/*HTS_TST (Facility) - PITC PMTCT (ANC Only) Clinics*/
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0) AS HTS_TST_PMTCT_10_14_pos,
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0) AS HTS_TST_PMTCT_10_14_neg,
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0) AS HTS_TST_PMTCT_15_19_pos,
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0) AS HTS_TST_PMTCT_15_19_neg,
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0) AS HTS_TST_PMTCT_20_24_pos,
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0) AS HTS_TST_PMTCT_20_24_neg,
(COALESCE(HTS_TST_PMTCT_25_49_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_pos.value,0)) AS HTS_TST_PMTCT_25_49_pos,
(COALESCE(HTS_TST_PMTCT_25_49_neg.value,0)+COALESCE(HTS_TST_PMTCT_25_neg.value,0)) AS HTS_TST_PMTCT_25_49_neg,
'' AS placeholder16,
'' AS placeholder17,
'' AS placeholder18,
'' AS placeholder19,
'' AS placeholder20,
'' AS placeholder21,
/*HTS_TST (Facility) - PITC Emergency Ward*/
(COALESCE(atip_bso_0_8_f_pos.value,0)+COALESCE(atip_bso_0_8_m_pos.value,0)) AS HTS_TST_Emergency_men1_pos,
(COALESCE(atip_bso_0_8_f_neg.value,0)+COALESCE(atip_bso_0_8_m_neg.value,0)) AS HTS_TST_Emergency_men1_neg,
(COALESCE(atip_bso_1_9_pos.value,0)+COALESCE(atip_bso_19_4_f_pos.value,0)+COALESCE(atip_bso_19_4_m_pos.value,0)+COALESCE(atip_bso_9_18_f_pos.value,0)+COALESCE(atip_bso_9_18_m_pos.value,0)) AS HTS_TST_Emergency_1_9_pos,
(COALESCE(atip_bso_1_9_neg.value,0)+COALESCE(atip_bso_19_4_f_neg.value,0)+COALESCE(atip_bso_19_4_m_neg.value,0)+COALESCE(atip_bso_9_18_f_neg.value,0)+COALESCE(atip_bso_9_18_m_neg.value,0)) AS HTS_TST_Emergency_1_9_neg,
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
(COALESCE(atip_bso_25_49_f_pos.value,0)+COALESCE(atip_bso_25_29_f_pos.value,0)+COALESCE(atip_bso_30_49_f_pos.value,0)) AS HTS_TST_Emergency_25_49_f_pos,
(COALESCE(atip_bso_25_49_f_neg.value,0)+COALESCE(atip_bso_25_29_f_neg.value,0)+COALESCE(atip_bso_30_49_f_neg.value,0)) AS HTS_TST_Emergency_25_49_f_neg,
(COALESCE(atip_bso_25_49_m_pos.value,0)+COALESCE(atip_bso_25_29_m_pos.value,0)+COALESCE(atip_bso_30_49_m_pos.value,0)) AS HTS_TST_Emergency_25_49_m_pos,
(COALESCE(atip_bso_25_49_m_neg.value,0)+COALESCE(atip_bso_25_29_m_neg.value,0)+COALESCE(atip_bso_30_49_m_neg.value,0)) AS HTS_TST_Emergency_25_49_m_neg,
COALESCE(atip_bso_50_f_pos.value,0) AS HTS_TST_Emergency_50_f_pos,
COALESCE(atip_bso_50_f_neg.value,0) AS HTS_TST_Emergency_50_f_neg,
COALESCE(atip_bso_50_m_pos.value,0) AS HTS_TST_Emergency_50_m_pos,
COALESCE(atip_bso_50_m_neg.value,0) AS HTS_TST_Emergency_50_m_neg,
'' AS placeholder22,
'' AS placeholder23,
/*HTS_TST (Facility) - Other PITC*/
COALESCE(cpn_m_pos.value,0) AS HTS_TST_Other_u_m_pos,
COALESCE(cpn_m_neg.value,0) AS HTS_TST_Other_u_m_neg,
(COALESCE(atip_men1_pos.value,0)+COALESCE(mat_men1_pos.value,0)+COALESCE(atip_0_8_f_pos.value,0)+COALESCE(atip_0_8_m_pos.value,0)) AS HTS_TST_Other_men1_pos,
(COALESCE(atip_men1_neg.value,0)+COALESCE(mat_men1_neg.value,0)+COALESCE(atip_0_8_f_neg.value,0)+COALESCE(atip_0_8_m_neg.value,0)) AS HTS_TST_Other_men1_neg,
(COALESCE(atip_1_9_pos.value,0)+COALESCE(mat_1_9_pos.value,0)+COALESCE(atip_19_4_f_pos.value,0)+COALESCE(atip_19_4_m_pos.value,0)+COALESCE(atip_9_18_f_pos.value,0)+COALESCE(atip_9_18_m_pos.value,0)) AS HTS_TST_Other_1_9_pos,
(COALESCE(atip_1_9_neg.value,0)+COALESCE(mat_1_9_neg.value,0)+COALESCE(atip_19_4_f_neg.value,0)+COALESCE(atip_19_4_m_neg.value,0)+COALESCE(atip_9_18_f_neg.value,0)+COALESCE(atip_9_18_m_neg.value,0)) AS HTS_TST_Other_1_9_neg,
(COALESCE(atip_10_14_f_pos.value,0)+COALESCE(mat_10_14_pos.value,0)) AS HTS_TST_Other_10_14_f_pos,
(COALESCE(atip_10_14_f_neg.value,0)+COALESCE(mat_10_14_neg.value,0)) AS HTS_TST_Other_10_14_f_neg,
COALESCE(atip_10_14_m_pos.value,0) AS HTS_TST_Other_10_14_m_pos,
COALESCE(atip_10_14_m_neg.value,0) AS HTS_TST_Other_10_14_m_neg,
(COALESCE(atip_15_19_f_pos.value,0)+COALESCE(mat_15_19_pos.value,0)) AS HTS_TST_Other_15_19_f_pos,
(COALESCE(atip_15_19_f_neg.value,0)+COALESCE(mat_15_19_neg.value,0)) AS HTS_TST_Other_15_19_f_neg,
COALESCE(atip_15_19_m_pos.value,0) AS HTS_TST_Other_15_19_m_pos,
COALESCE(atip_15_19_m_neg.value,0) AS HTS_TST_Other_15_19_m_neg,
(COALESCE(atip_20_24_f_pos.value,0)+COALESCE(mat_20_24_pos.value,0)) AS HTS_TST_Other_20_24_f_pos,
(COALESCE(atip_20_24_f_neg.value,0)+COALESCE(mat_20_24_neg.value,0)) AS HTS_TST_Other_20_24_f_neg,
COALESCE(atip_20_24_m_pos.value,0) AS HTS_TST_Other_20_24_m_pos,
COALESCE(atip_20_24_m_neg.value,0) AS HTS_TST_Other_20_24_m_neg,
(COALESCE(atip_25_49_f_pos.value,0)+COALESCE(mat_25_49_pos.value,0)+COALESCE(atip_25_29_f_pos.value,0)+COALESCE(atip_30_49_f_pos.value,0)+COALESCE(mat_25_29_pos.value,0)+COALESCE(mat_30_34_pos.value,0)+COALESCE(mat_35_39_pos.value,0)+COALESCE(mat_40_49_pos.value,0)) AS HTS_TST_Other_25_49_f_pos,
(COALESCE(atip_25_49_f_neg.value,0)+COALESCE(mat_25_49_neg.value,0)+COALESCE(atip_25_29_f_neg.value,0)+COALESCE(atip_30_49_f_neg.value,0)+COALESCE(mat_25_29_neg.value,0)+COALESCE(mat_30_34_neg.value,0)+COALESCE(mat_35_39_neg.value,0)+COALESCE(mat_40_49_neg.value,0)) AS HTS_TST_Other_25_49_f_neg,
(COALESCE(atip_25_49_m_pos.value,0)+COALESCE(atip_25_29_m_pos.value,0)+COALESCE(atip_30_49_m_pos.value,0)) AS HTS_TST_Other_25_49_m_pos,
(COALESCE(atip_25_49_m_neg.value,0)+COALESCE(atip_25_29_m_neg.value,0)+COALESCE(atip_30_49_m_neg.value,0)) AS HTS_TST_Other_25_49_m_neg,
(COALESCE(atip_50_f_pos.value,0)+COALESCE(mat_50_pos.value,0)) AS HTS_TST_Other_50_f_pos,
(COALESCE(atip_50_f_neg.value,0)+COALESCE(mat_50_neg.value,0)) AS HTS_TST_Other_50_f_neg,
COALESCE(atip_50_m_pos.value,0) AS HTS_TST_Other_50_m_pos,
COALESCE(atip_50_m_neg.value,0) AS HTS_TST_Other_50_m_neg,
'' AS placeholder24,
'' AS placeholder25,
'' AS placeholder26,
'' AS placeholder27,
/*HTS_TST (Facility) - VCT*/
(COALESCE(ats_men1_pos.value,0)+COALESCE(ats_0_8_f_pos.value,0)+COALESCE(ats_0_8_m_pos.value,0)) AS HTS_TST_VCT_men1_pos,
(COALESCE(ats_men1_neg.value,0)+COALESCE(ats_0_8_f_neg.value,0)+COALESCE(ats_0_8_m_neg.value,0)) AS HTS_TST_VCT_men1_neg,
(COALESCE(ats_1_9_pos.value,0)+COALESCE(ats_19_4_f_pos.value,0)+COALESCE(ats_19_4_m_pos.value,0)+COALESCE(ats_9_18_f_pos.value,0)+COALESCE(ats_9_18_m_pos.value,0)) AS HTS_TST_VCT_1_9_pos,
(COALESCE(ats_1_9_neg.value,0)+COALESCE(ats_19_4_f_neg.value,0)+COALESCE(ats_19_4_m_neg.value,0)+COALESCE(ats_9_18_f_neg.value,0)+COALESCE(ats_9_18_m_neg.value,0)) AS HTS_TST_VCT_1_9_neg,
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
(COALESCE(ats_25_49_f_pos.value,0)+COALESCE(ats_25_29_f_pos.value,0)+COALESCE(ats_30_49_f_pos.value,0)) AS HTS_TST_VCT_25_49_f_pos,
(COALESCE(ats_25_49_f_neg.value,0)+COALESCE(ats_25_29_f_neg.value,0)+COALESCE(ats_30_49_f_neg.value,0)) AS HTS_TST_VCT_25_49_f_neg,
(COALESCE(ats_25_49_m_pos.value,0)+COALESCE(ats_25_29_m_pos.value,0)+COALESCE(ats_30_49_m_pos.value,0)) AS HTS_TST_VCT_25_49_m_pos,
(COALESCE(ats_25_49_m_neg.value,0)+COALESCE(ats_25_29_m_neg.value,0)+COALESCE(ats_30_49_m_neg.value,0)) AS HTS_TST_VCT_25_49_m_neg,
COALESCE(ats_50_f_pos.value,0) AS HTS_TST_VCT_50_f_pos,
COALESCE(ats_50_f_neg.value,0) AS HTS_TST_VCT_50_f_neg,
COALESCE(ats_50_m_pos.value,0) AS HTS_TST_VCT_50_m_pos,
COALESCE(ats_50_m_neg.value,0) AS HTS_TST_VCT_50_m_neg,
'' AS placeholder28,
'' AS placeholder29,
'' AS placeholder30,
'' AS placeholder31,
/*Index Testing*/
(COALESCE(atip_index_men1_pos.value,0)+COALESCE(ats_index_men1_pos.value,0)+COALESCE(atip_index_0_8_f_pos.value,0)+COALESCE(atip_index_0_8_m_pos.value,0)+COALESCE(ats_index_0_8_f_pos.value,0)+COALESCE(ats_index_0_8_m_pos.value,0)) AS HTS_TST_Index_men1_pos,
(COALESCE(atip_index_men1_neg.value,0)+COALESCE(ats_index_men1_neg.value,0)+COALESCE(atip_index_0_8_f_neg.value,0)+COALESCE(atip_index_0_8_m_neg.value,0)+COALESCE(ats_index_0_8_f_neg.value,0)+COALESCE(ats_index_0_8_m_neg.value,0)) AS HTS_TST_Index_men1_neg,
(COALESCE(atip_index_1_9_pos.value,0)+COALESCE(ats_index_1_9_pos.value,0)+COALESCE(atip_index_19_4_f_pos.value,0)+COALESCE(atip_index_19_4_m_pos.value,0)+COALESCE(ats_index_19_4_f_pos.value,0)+COALESCE(ats_index_19_4_m_pos.value,0)+COALESCE(ats_index_9_18_f_pos.value,0)+COALESCE(ats_index_9_18_m_pos.value,0)+COALESCE(atip_index_9_18_f_pos.value,0)+COALESCE(atip_index_9_18_m_pos.value,0)) AS HTS_TST_Index_1_9_pos,
(COALESCE(atip_index_1_9_neg.value,0)+COALESCE(ats_index_1_9_neg.value,0)+COALESCE(atip_index_19_4_f_neg.value,0)+COALESCE(atip_index_19_4_m_neg.value,0)+COALESCE(ats_index_19_4_f_neg.value,0)+COALESCE(ats_index_19_4_m_neg.value,0)+COALESCE(ats_index_9_18_f_neg.value,0)+COALESCE(ats_index_9_18_m_neg.value,0)+COALESCE(atip_index_9_18_f_neg.value,0)+COALESCE(atip_index_9_18_m_neg.value,0)) AS HTS_TST_Index_1_9_neg,
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
(COALESCE(atip_index_25_49_f_pos.value,0)+COALESCE(ats_index_25_49_f_pos.value,0)+COALESCE(atip_index_25_29_f_pos.value,0)+COALESCE(atip_index_30_49_f_pos.value,0)+COALESCE(ats_index_25_29_f_pos.value,0)+COALESCE(ats_index_30_49_f_pos.value,0)) AS HTS_TST_Index_25_49_f_pos,
(COALESCE(atip_index_25_49_f_neg.value,0)+COALESCE(ats_index_25_49_f_neg.value,0)+COALESCE(atip_index_25_29_f_neg.value,0)+COALESCE(atip_index_30_49_f_neg.value,0)+COALESCE(ats_index_25_29_f_neg.value,0)+COALESCE(ats_index_30_49_f_neg.value,0)) AS HTS_TST_Index_25_49_f_neg,
(COALESCE(atip_index_25_49_m_pos.value,0)+COALESCE(ats_index_25_49_m_pos.value,0)+COALESCE(atip_index_25_29_m_pos.value,0)+COALESCE(atip_index_30_49_m_pos.value,0)+COALESCE(ats_index_25_29_m_pos.value,0)+COALESCE(ats_index_30_49_m_pos.value,0)) AS HTS_TST_Index_25_49_m_pos,
(COALESCE(atip_index_25_49_m_neg.value,0)+COALESCE(ats_index_25_49_m_neg.value,0)+COALESCE(atip_index_25_29_m_neg.value,0)+COALESCE(atip_index_30_49_m_neg.value,0)+COALESCE(ats_index_25_29_m_neg.value,0)+COALESCE(ats_index_30_49_m_neg.value,0)) AS HTS_TST_Index_25_49_m_neg,
(COALESCE(atip_index_50_f_pos.value,0)+COALESCE(ats_index_50_f_pos.value,0)) AS HTS_TST_Index_50_f_pos,
(COALESCE(atip_index_50_f_neg.value,0)+COALESCE(ats_index_50_f_neg.value,0)) AS HTS_TST_Index_50_f_neg,
(COALESCE(atip_index_50_m_pos.value,0)+COALESCE(ats_index_50_m_pos.value,0)) AS HTS_TST_Index_50_m_pos,
(COALESCE(atip_index_50_m_neg.value,0)+COALESCE(ats_index_50_m_neg.value,0)) AS HTS_TST_Index_50_m_neg,
/*PMTCT_STAT (Numerator)*/
(COALESCE(PMTCT_STAT_17q2_num.value,0)+COALESCE(PMTCT_STAT_17q1_num.value,0)) AS PMTCT_STAT_num,
'' AS placeholder32,
'' AS placeholder33,
(COALESCE(HTS_TST_PMTCT_10_14_pos.value,0)+COALESCE(HTS_TST_PMTCT_10_14_neg.value,0)+COALESCE(PMTCT_STAT_17q2_10_14_known_pos.value,0)) AS PMTCT_STAT_10_14_num,
(COALESCE(HTS_TST_PMTCT_15_19_pos.value,0)+COALESCE(HTS_TST_PMTCT_15_19_neg.value,0)+COALESCE(PMTCT_STAT_17q2_15_19_known_pos.value,0)) AS PMTCT_STAT_15_19_num,
(COALESCE(HTS_TST_PMTCT_20_24_pos.value,0)+COALESCE(HTS_TST_PMTCT_20_24_neg.value,0)+COALESCE(PMTCT_STAT_17q2_20_24_known_pos.value,0)) AS PMTCT_STAT_20_24_num,
(COALESCE(HTS_TST_PMTCT_25_49_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_49_neg.value,0)+COALESCE(PMTCT_STAT_17q2_25_49_known_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_neg.value,0)+COALESCE(PMTCT_STAT_17q2_25_known_pos.value,0)) AS PMTCT_STAT_25_49_num,
'' AS placeholder34,
'' AS placeholder35,
'' AS placeholder36,
'' AS placeholder37,
'' AS placeholder38,
'' AS placeholder39,
'' AS placeholder40,
COALESCE(PMTCT_STAT_17q2_10_14_known_pos.value,0) AS PMTCT_STAT_10_14_known_pos,
COALESCE(HTS_TST_PMTCT_10_14_pos.value,0) AS HTS_TST_PMTCT_10_14_pos2,
COALESCE(HTS_TST_PMTCT_10_14_neg.value,0) AS HTS_TST_PMTCT_10_14_neg2,
COALESCE(PMTCT_STAT_17q2_15_19_known_pos.value,0) AS PMTCT_STAT_15_19_known_pos,
COALESCE(HTS_TST_PMTCT_15_19_pos.value,0) AS HTS_TST_PMTCT_15_19_pos2,
COALESCE(HTS_TST_PMTCT_15_19_neg.value,0) AS HTS_TST_PMTCT_15_19_neg2,
COALESCE(PMTCT_STAT_17q2_20_24_known_pos.value,0) AS PMTCT_STAT_20_24_known_pos,
COALESCE(HTS_TST_PMTCT_20_24_pos.value,0) AS HTS_TST_PMTCT_20_24_pos2,
COALESCE(HTS_TST_PMTCT_20_24_neg.value,0) AS HTS_TST_PMTCT_20_24_neg2,
(COALESCE(PMTCT_STAT_17q2_25_49_known_pos.value,0)++COALESCE(PMTCT_STAT_17q2_25_known_pos.value,0)) AS PMTCT_STAT_25_49_known_pos,
(COALESCE(HTS_TST_PMTCT_25_49_pos.value,0)+COALESCE(HTS_TST_PMTCT_25_pos.value,0)) AS HTS_TST_PMTCT_25_49_pos2,
(COALESCE(HTS_TST_PMTCT_25_49_neg.value,0)+COALESCE(HTS_TST_PMTCT_25_neg.value,0)) AS HTS_TST_PMTCT_25_49_neg2,
'' AS placeholder41,
'' AS placeholder42,
'' AS placeholder43,
'' AS placeholder44,
/*PMTCT_STAT (Denominator)*/

COALESCE(PMTCT_STAT_17q2_10_14_den.value,0) AS PMTCT_STAT_10_14_den,
COALESCE(PMTCT_STAT_17q2_15_19_den.value,0) AS PMTCT_STAT_15_19_den,
COALESCE(PMTCT_STAT_17q2_20_24_den.value,0) AS PMTCT_STAT_20_24_den,
(COALESCE(PMTCT_STAT_17q2_25_49_den.value,0)+COALESCE(PMTCT_STAT_17q2_25_den.value,0)) AS PMTCT_STAT_25_49_den,
'' AS placeholder45,
/*PMTCT_EID*/
COALESCE(PMTCT_EID_0_2_total.value,0) AS PMTCT_EID_0_2_test,
COALESCE(PMTCT_EID_2_12_total.value,0) AS PMTCT_EID_2_12_test,
COALESCE(PMTCT_EID_0_2_pos.value,0) AS PMTCT_EID_0_2_pos,
COALESCE(PMTCT_EID_0_2_art.value,0) AS PMTCT_EID_0_2_art,
COALESCE(PMTCT_EID_2_12_pos_sum_prev.value,0) AS PMTCT_EID_2_12_pos,
COALESCE(PMTCT_EID_2_12_art.value,0) AS PMTCT_EID_2_12_art,
/*On ART*/
/*TX_NEW*/
COALESCE(TX_NEW_num.value,0) AS TX_NEW_num,
COALESCE(TX_NEW_preg.value,0) AS TX_NEW_preg,
COALESCE(TX_NEW_breast.value,0) AS TX_NEW_breast,
COALESCE(TX_NEW_tb.value,0) AS TX_NEW_tb,
COALESCE(TX_NEW_men1.value,0) AS TX_NEW_men1,
COALESCE(TX_NEW_1_9.value,0) AS TX_NEW_1_9,
COALESCE(TX_NEW_10_14_f.value,0) AS TX_NEW_10_14_f,
COALESCE(TX_NEW_15_19_f.value,0) AS TX_NEW_15_19_f,
COALESCE(TX_NEW_20_24_f.value,0) AS TX_NEW_20_24_f,
COALESCE(TX_NEW_25_49_f.value,0) AS TX_NEW_25_49_f,
COALESCE(TX_NEW_50_f.value,0) AS TX_NEW_50_f,
COALESCE(TX_NEW_10_14_m.value,0) AS TX_NEW_10_14_m,
COALESCE(TX_NEW_15_19_m.value,0) AS TX_NEW_15_19_m,
COALESCE(TX_NEW_20_24_m.value,0) AS TX_NEW_20_24_m,
COALESCE(TX_NEW_25_49_m.value,0) AS TX_NEW_25_49_m,
COALESCE(TX_NEW_50_m.value,0) AS TX_NEW_50_m,
COALESCE(TX_NEW_coarse_f_men15.value,0) AS TX_NEW_coarse_f_men15,
COALESCE(TX_NEW_coarse_f_mai15.value,0) AS TX_NEW_coarse_f_mai15,
COALESCE(TX_NEW_coarse_m_men15.value,0) AS TX_NEW_coarse_m_men15,
COALESCE(TX_NEW_coarse_m_mai15.value,0) AS TX_NEW_coarse_m_mai15,
/*TX_CURR*/
COALESCE(TX_CURR_num.value,0) AS TX_CURR_num,
COALESCE(TX_CURR_men1.value,0) AS TX_CURR_men1,
COALESCE(TX_CURR_1_9.value,0) AS TX_CURR_1_9,
COALESCE(TX_CURR_10_14_f.value,0) AS TX_CURR_10_14_f,
COALESCE(TX_CURR_15_19_f.value,0) AS TX_CURR_15_19_f,
COALESCE(TX_CURR_20_24_f.value,0) AS TX_CURR_20_24_f,
COALESCE(TX_CURR_25_49_f.value,0) AS TX_CURR_25_49_f,
COALESCE(TX_CURR_50_f.value,0) AS TX_CURR_50_f,
COALESCE(TX_CURR_10_14_m.value,0) AS TX_CURR_10_14_m,
COALESCE(TX_CURR_15_19_m.value,0) AS TX_CURR_15_19_m,
COALESCE(TX_CURR_20_24_m.value,0) AS TX_CURR_20_24_m,
COALESCE(TX_CURR_25_49_m.value,0) AS TX_CURR_25_49_m,
COALESCE(TX_CURR_50_m.value,0) AS TX_CURR_50_m,
COALESCE(TX_CURR_coarse_f_men15.value,0) AS TX_CURR_coarse_f_men15,
COALESCE(TX_CURR_coarse_f_mai15.value,0) AS TX_CURR_coarse_f_mai15,
COALESCE(TX_CURR_coarse_m_men15.value,0) AS TX_CURR_coarse_m_men15,
COALESCE(TX_CURR_coarse_m_mai15.value,0) AS TX_CURR_coarse_m_mai15,
/*PMTCT_ART*/
COALESCE(PMTCT_ART_Newly.value,0) AS PMTCT_ART_Newly,
COALESCE(PMTCT_ART_Already.value,0) AS PMTCT_ART_Already


from organisationunit ou
left outer join _orgunitstructure ous
  on (ou.organisationunitid=ous.organisationunitid)
left outer join organisationunit province
  on (ous.idlevel2=province.organisationunitid)
left outer join organisationunit district
  on (ous.idlevel3=district.organisationunitid)

/*Quarterly*/
/*PMTCT_ART*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6945
  and categoryoptioncomboid=6944
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_ART_Newly on PMTCT_ART_Newly.sourceid=ou.organisationunitid

left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6945
  and categoryoptioncomboid=6941
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_ART_Already on PMTCT_ART_Already.sourceid=ou.organisationunitid

/*HTS_TST (Facility) - PITC Pediatric Services*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=23817
  and categoryoptioncomboid=23818
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_Pediatric_pos on HTS_TST_Pediatric_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=23817
  and categoryoptioncomboid=23819
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_Pediatric_neg on HTS_TST_Pediatric_neg.sourceid=ou.organisationunitid

/*HTS_TST (Facility) - PITC - TB Clinics*/
/*Under 10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62234,62242)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_men1_pos on HTS_TST_TB_men1_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62250,62258)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_men1_neg on HTS_TST_TB_men1_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62235,62236,62243,62244)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_1_9_pos on HTS_TST_TB_1_9_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62251,62252,62259,62260)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_1_9_neg on HTS_TST_TB_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62245
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_10_14_f_pos on HTS_TST_TB_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62261
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_10_14_f_neg on HTS_TST_TB_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62237
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_10_14_m_pos on HTS_TST_TB_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62253
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_10_14_m_neg on HTS_TST_TB_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62246
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_15_19_f_pos on HTS_TST_TB_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62262
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_15_19_f_neg on HTS_TST_TB_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62238
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_15_19_m_pos on HTS_TST_TB_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62254
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_15_19_m_neg on HTS_TST_TB_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62247
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_20_24_f_pos on HTS_TST_TB_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62263
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_20_24_f_neg on HTS_TST_TB_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62239
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_20_24_m_pos on HTS_TST_TB_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62255
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_20_24_m_neg on HTS_TST_TB_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62248
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_49_f_pos on HTS_TST_TB_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62264
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_49_f_neg on HTS_TST_TB_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62240
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_49_m_pos on HTS_TST_TB_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62256
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_49_m_neg on HTS_TST_TB_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561752
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_29_f_pos on HTS_TST_TB_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561760
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_29_f_neg on HTS_TST_TB_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561748
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_29_m_pos on HTS_TST_TB_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561756
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_25_29_m_neg on HTS_TST_TB_25_29_m_neg.sourceid=ou.organisationunitid

  /*30-34*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561753
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_30_34_f_pos on HTS_TST_TB_30_34_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561761
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_30_34_f_neg on HTS_TST_TB_30_34_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561749
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_30_34_m_pos on HTS_TST_TB_30_34_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561757
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_30_34_m_neg on HTS_TST_TB_30_34_m_neg.sourceid=ou.organisationunitid
  
  /*35-39*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561754
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_35_39_f_pos on HTS_TST_TB_35_39_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561762
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_35_39_f_neg on HTS_TST_TB_35_39_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561750
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_35_39_m_pos on HTS_TST_TB_35_39_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561758
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_35_39_m_neg on HTS_TST_TB_35_39_m_neg.sourceid=ou.organisationunitid

  /*40-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561755
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_40_49_f_pos on HTS_TST_TB_40_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561763
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_40_49_f_neg on HTS_TST_TB_40_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561751
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_40_49_m_pos on HTS_TST_TB_40_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561759
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_40_49_m_neg on HTS_TST_TB_40_49_m_neg.sourceid=ou.organisationunitid

  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62249
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_50_f_pos on HTS_TST_TB_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62265
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_50_f_neg on HTS_TST_TB_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62241
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_50_m_pos on HTS_TST_TB_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62257
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_TB_50_m_neg on HTS_TST_TB_50_m_neg.sourceid=ou.organisationunitid

  /*HTS_TST (Facility) - PITC PMTCT (ANC Only) Clinics*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=61998
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_men1_pos on HTS_TST_PMTCT_men1_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62017
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_men1_neg on HTS_TST_PMTCT_men1_neg.sourceid=ou.organisationunitid

  /*1-9*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid IN (62039,62031)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_1_9_pos on HTS_TST_PMTCT_1_9_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid IN (62030,62026)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_1_9_neg on HTS_TST_PMTCT_1_9_neg.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=61995
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_10_14_pos on HTS_TST_PMTCT_10_14_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=61999
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_10_14_neg on HTS_TST_PMTCT_10_14_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62023
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_15_19_pos on HTS_TST_PMTCT_15_19_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62010
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_15_19_neg on HTS_TST_PMTCT_15_19_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62036
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_20_24_pos on HTS_TST_PMTCT_20_24_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62004
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_20_24_neg on HTS_TST_PMTCT_20_24_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62012
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_25_49_pos on HTS_TST_PMTCT_25_49_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62002
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_25_49_neg on HTS_TST_PMTCT_25_49_neg.sourceid=ou.organisationunitid
  
  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=563004
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_25_pos on HTS_TST_PMTCT_25_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=563005
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_25_neg on HTS_TST_PMTCT_25_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62013
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_50_pos on HTS_TST_PMTCT_50_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62009
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as HTS_TST_PMTCT_50_neg on HTS_TST_PMTCT_50_neg.sourceid=ou.organisationunitid

  /*HTS_TST (Facility) - Other PITC*/
  /*ATIP*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22243,230321,22181,230317,230318,22205,230319,22632,22228,230320,22458,22453,22598,22304,22567,230153,22599,230149,230150,22319,230151,22528,22606,230152,22505,22381,22377,22454,427177,427178,427225,427226,437581,437605)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_men1_pos on atip_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22690,230328,22198,230324,230325,22558,230326,22548,22623,230327,22502,22669,22426,22584,22180,230160,22626,230156,230157,22268,230158,22552,22204,230159,22492,22273,22663,22635,427179,427180,427227,427228,437582,437606)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_men1_neg on atip_men1_neg.sourceid=ou.organisationunitid
  
  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566111,566112,566113,566114,566115,566117,566118,566119,566120,566121,566122,566123,566124,566127,566128,566129)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_0_8_f_pos on atip_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566132,566133,566134,566135,566136,566138,566139,566140,566141,566142,566143,566144,566145,566148,566149,566150)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_0_8_f_neg on atip_0_8_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565922,565923,565924,565925,565926,565928,565929,565930,565931,565932,565933,565934,565935,565938,565939,565940)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_0_8_m_pos on atip_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565943,565944,565945,565946,565947,565949,565950,565951,565952,565953,565954,565955,565956,565959,565960,565961)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_0_8_m_neg on atip_0_8_m_neg.sourceid=ou.organisationunitid

  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566174,566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,566190,566191,566192)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_9_18_f_pos on atip_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566195,566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,566211,566212,566213)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_9_18_f_neg on atip_9_18_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565985,565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566001,566002,566003)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_9_18_m_pos on atip_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566006,566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566022,566023,566024)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_9_18_m_neg on atip_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566237,566238,566239,566240,566241,566243,566244,566245,566246,566247,566248,566249,566250,566253,566254,566255)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_19_4_f_pos on atip_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566258,566259,566260,566261,566262,566264,566265,566266,566267,566268,566269,566270,566271,566274,566275,566276)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_19_4_f_neg on atip_19_4_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566048,566049,566050,566051,566052,566054,566055,566056,566057,566058,566059,566060,566061,566064,566065,566066)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_19_4_m_pos on atip_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566069,566070,566071,566072,566073,566075,566076,566077,566078,566079,566080,566081,566082,566085,566086,566087)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_19_4_m_neg on atip_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22171,22207,22235,22246,22256,22260,22327,22330,22335,22349,22350,22365,22372,22404,22405,22411,22447,22457,22464,22469,22483,22498,22509,22510,22512,22517,22560,22562,22565,22595,22597,22612,22628,22675,22683,22692,230170,230171,230172,230173,230174,230191,230192,230193,230194,230195,230338,230339,230340,230341,230342,230359,230360,230361,230362,230363,427183,427184,427189,427190,427231,427232,427237,427238,437584,437587,437608,437611)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_1_9_pos on atip_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22170,22182,22189,22191,22271,22295,22305,22317,22331,22333,22334,22339,22346,22430,22434,22463,22472,22473,22478,22515,22533,22561,22576,22580,22603,22614,22622,22629,22640,22646,22649,22653,22659,22671,22677,22685,230177,230178,230179,230180,230181,230198,230199,230200,230201,230202,230345,230346,230347,230348,230349,230366,230367,230368,230369,230370,427185,427186,427191,427192,427233,427234,427239,427240,437585,437588,437609,437612)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_1_9_neg on atip_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22582,230384,22553,230380,230381,22187,230382,22466,22352,230383,22506,22602,22641,22664,427243,427244,437615)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_10_14_f_pos on atip_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22279,230391,22658,230387,230388,22488,230389,22667,22215,230390,22443,22241,22420,22202,427245,427246,437616)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_10_14_f_neg on atip_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22261,230216,22484,230212,230213,22263,230214,22480,22347,230215,22414,22206,22518,22384,427195,427196,437590)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_10_14_m_pos on atip_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22307,230223,22672,230219,230220,22416,230221,22496,22477,230222,22619,22668,22240,22337,427197,427198,437591)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_10_14_m_neg on atip_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22282,230405,22546,230401,230402,22534,230403,22233,22620,230404,22301,22254,22173,22402,427249,427250,437618)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_15_19_f_pos on atip_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22397,230412,22328,230408,230409,22190,230410,22277,22342,230411,22522,22613,22572,22495,427251,427252,437619)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_15_19_f_neg on atip_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22320,230237,22547,230233,230234,22660,230235,22460,22590,230236,22577,22511,22321,22549,427201,427202,437593)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_15_19_m_pos on atip_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22413,230244,22526,230240,230241,22686,230242,22361,22386,230243,22465,22385,22177,22648,427203,427204,437594)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_15_19_m_neg on atip_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22586,230426,22536,230422,230423,22222,230424,22208,22314,230425,22588,22367,22351,22631,427255,427256,437621)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_20_24_f_pos on atip_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22393,230433,22218,230429,230430,22621,230431,22592,22578,230432,22541,22476,22323,22537,427257,427258,437622)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_20_24_f_neg on atip_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22312,230258,22624,230254,230255,22258,230256,22691,22275,230257,22338,22250,22538,22211,427207,427208,437596)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_20_24_m_pos on atip_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22357,230265,22345,230261,230262,22394,230263,22403,22415,230264,22265,22309,22278,22231,427209,427210,437597)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_20_24_m_neg on atip_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22608,230447,22490,230443,230444,22285,230445,22497,22272,230446,22471,22380,22296,22251,427261,427262,437624)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_49_f_pos on atip_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22303,230454,22354,230450,230451,22449,230452,22544,22462,230453,22459,22601,22172,22610,427263,427264,437625)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_49_f_neg on atip_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22493,230279,22329,230275,230276,22555,230277,22383,22388,230278,22409,22676,22650,22259,427213,427214,437599)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_49_m_pos on atip_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22618,230286,22318,230282,230283,22423,230284,22281,22290,230285,22591,22287,22681,22288,427215,427216,437600)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_49_m_neg on atip_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562058,562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,562074,562075,562076)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_29_f_pos on atip_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562079,562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,562095,562096,562097)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_29_f_neg on atip_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561806,561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561822,561823,561824)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_29_m_pos on atip_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561827,561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561843,561844,561845)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_25_29_m_neg on atip_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565762,565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,565778,565779,565780)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_30_49_f_pos on atip_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565783,565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,565799,565800,565801)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_30_49_f_neg on atip_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565699,565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565715,565716,565717)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_30_49_m_pos on atip_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565720,565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565736,565737,565738)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_30_49_m_neg on atip_30_49_m_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22313,230468,22201,230464,230465,22482,230466,22412,22485,230467,22264,22514,22643,22596,427267,427268,437627)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_50_f_pos on atip_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22325,230475,22461,230471,230472,22540,230473,22543,22244,230474,22500,22343,22467,22322,427269,427270,437628)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_50_f_neg on atip_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22168,230300,22370,230296,230297,22238,230298,22656,22570,230299,22642,22670,22550,22647,427219,427220,437602)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_50_m_pos on atip_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22481,230307,22389,230303,230304,22444,230305,22200,22600,230306,22212,22607,22569,22665,427221,427222,437603)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_50_m_neg on atip_50_m_neg.sourceid=ou.organisationunitid

  /*Maternidade*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (61998,61994)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_men1_pos on mat_men1_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62017,62000)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_men1_neg on mat_men1_neg.sourceid=ou.organisationunitid

  /*1-9*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62039,62031,62005,62029)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_1_9_pos on mat_1_9_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62030,62026,62019,62001)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_1_9_neg on mat_1_9_neg.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (61995,62027)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_10_14_pos on mat_10_14_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (61999,62003)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_10_14_neg on mat_10_14_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62023,62038)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_15_19_pos on mat_15_19_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62010,62014)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_15_19_neg on mat_15_19_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62036,62034)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_20_24_pos on mat_20_24_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62004,62015)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_20_24_neg on mat_20_24_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62012,62020)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_25_49_pos on mat_25_49_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62002,62022)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_25_49_neg on mat_25_49_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561724,561736)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_25_29_pos on mat_25_29_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561728,561740)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_25_29_neg on mat_25_29_neg.sourceid=ou.organisationunitid
  
  /*30-34*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561725,561737)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_30_34_pos on mat_30_34_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561729,561741)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_30_34_neg on mat_30_34_neg.sourceid=ou.organisationunitid
  
  /*35-39*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561726,561738)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_35_39_pos on mat_35_39_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561730,561742)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_35_39_neg on mat_35_39_neg.sourceid=ou.organisationunitid
  
  /*40-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561727,561739)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_40_49_pos on mat_40_49_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561731,561743)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_40_49_neg on mat_40_49_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62013,62011)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_50_pos on mat_50_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62009,62006)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as mat_50_neg on mat_50_neg.sourceid=ou.organisationunitid

  /*CPN Parceiros*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6946
  and categoryoptioncomboid=6924
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as cpn_m_pos on cpn_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6946
  and categoryoptioncomboid=6925
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as cpn_m_neg on cpn_m_neg.sourceid=ou.organisationunitid

  /*HTS_TST (Facility) - VCT*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21837,21861)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_men1_pos on ats_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21838,21862)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_men1_neg on ats_men1_neg.sourceid=ou.organisationunitid
  
  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565851
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_0_8_f_pos on ats_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565852
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_0_8_f_neg on ats_0_8_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565842
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_0_8_m_pos on ats_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565843
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_0_8_m_neg on ats_0_8_m_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565854
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_9_18_f_pos on ats_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565855
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_9_18_f_neg on ats_9_18_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565845
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_9_18_m_pos on ats_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565846
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_9_18_m_neg on ats_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565857
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_19_4_f_pos on ats_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565858
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_19_4_f_neg on ats_19_4_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565848
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_19_4_m_pos on ats_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565849
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_19_4_m_neg on ats_19_4_m_neg.sourceid=ou.organisationunitid

  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21840,21843,21864,21867)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_1_9_pos on ats_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21841,21844,21865,21868)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_1_9_neg on ats_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21870
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_10_14_f_pos on ats_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21871
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_10_14_f_neg on ats_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21846
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_10_14_m_pos on ats_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21847
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_10_14_m_neg on ats_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21873
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_15_19_f_pos on ats_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21874
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_15_19_f_neg on ats_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21849
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_15_19_m_pos on ats_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21850
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_15_19_m_neg on ats_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21876
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_20_24_f_pos on ats_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21877
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_20_24_f_neg on ats_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21852
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_20_24_m_pos on ats_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21853
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_20_24_m_neg on ats_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21879
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_49_f_pos on ats_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21880
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_49_f_neg on ats_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21855
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_49_m_pos on ats_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21856
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_49_m_neg on ats_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561792
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_29_f_pos on ats_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561793
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_29_f_neg on ats_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561780
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_29_m_pos on ats_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561781
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_25_29_m_neg on ats_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565693
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_30_49_f_pos on ats_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565694
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_30_49_f_neg on ats_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565690
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_30_49_m_pos on ats_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565691
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_30_49_m_neg on ats_30_49_m_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21882
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_50_f_pos on ats_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21883
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_50_f_neg on ats_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21858
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_50_m_pos on ats_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21859
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_50_m_neg on ats_50_m_neg.sourceid=ou.organisationunitid


  /*Index Testing*/
  /*ATIP*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22243,230321,22181,230317,230318,22205,230319,22593,22209,22632,22228,230320,22458,22453,22598,22304,22567,230153,22599,230149,230150,22319,230151,22524,22395,22528,22606,230152,22505,22381,22377,22454,338836,338884,427177,427178,427225,427226,437581,437605)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_men1_pos on atip_index_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22690,230328,22198,230324,230325,22558,230326,22197,22401,22548,22623,230327,22502,22669,22426,22584,22180,230160,22626,230156,230157,22268,230158,22194,22230,22552,22204,230159,22492,22273,22663,22635,338838,338886,427179,427180,427227,427228,437582,437606)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_men1_neg on atip_index_men1_neg.sourceid=ou.organisationunitid

  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566109,566110,566111,566112,566113,566114,566115,566117,566118,566119,566120,566121,566122,566123,566124,566126,566127,566128,566129)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_0_8_f_pos on atip_index_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566130,566131,566132,566133,566134,566135,566136,566138,566139,566140,566141,566142,566143,566144,566145,566147,566148,566149,566150)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_0_8_f_neg on atip_index_0_8_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565920,565921,565922,565923,565924,565925,565926,565928,565929,565930,565931,565932,565933,565934,565935,565937,565938,565939,565940)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_0_8_m_pos on atip_index_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565941,565942,565943,565944,565945,565946,565947,565949,565950,565951,565952,565953,565954,565955,565956,565958,565959,565960,565961)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_0_8_m_neg on atip_index_0_8_m_neg.sourceid=ou.organisationunitid

  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566172,566173,566174,566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,566189,566190,566191,566192)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_9_18_f_pos on atip_index_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566193,566194,566195,566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,566210,566211,566212,566213)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_9_18_f_neg on atip_index_9_18_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565983,565984,565985,565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566000,566001,566002,566003)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_9_18_m_pos on atip_index_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566004,566005,566006,566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566021,566022,566023,566024)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_9_18_m_neg on atip_index_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566235,566236,566237,566238,566239,566240,566241,566243,566244,566245,566246,566247,566248,566249,566250,566252,566253,566254,566255)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_19_4_f_pos on atip_index_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566256,566257,566258,566259,566260,566261,566262,566264,566265,566266,566267,566268,566269,566270,566271,566273,566274,566275,566276)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_19_4_f_neg on atip_index_19_4_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566046,566047,566048,566049,566050,566051,566052,566054,566055,566056,566057,566058,566059,566060,566061,566063,566064,566065,566066)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_19_4_m_pos on atip_index_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566067,566068,566069,566070,566071,566072,566073,566075,566076,566077,566078,566079,566080,566081,566082,566084,566085,566086,566087)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_19_4_m_neg on atip_index_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22171,22203,22207,22235,22246,22256,22260,22327,22330,22335,22349,22350,22364,22365,22372,22375,22400,22404,22405,22411,22425,22447,22456,22457,22464,22469,22483,22498,22503,22509,22510,22512,22517,22542,22560,22562,22565,22595,22597,22612,22628,22675,22683,22692,230170,230171,230172,230173,230174,230191,230192,230193,230194,230195,230338,230339,230340,230341,230342,230359,230360,230361,230362,230363,338842,338848,338890,338896,427183,427184,427189,427190,427231,427232,427237,427238,437584,437587,437608,437611)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_1_9_pos on atip_index_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22169,22170,22182,22189,22191,22199,22271,22295,22299,22305,22317,22331,22333,22334,22339,22346,22430,22434,22463,22472,22473,22478,22515,22516,22527,22533,22561,22576,22580,22587,22603,22614,22622,22629,22640,22646,22649,22653,22655,22659,22671,22677,22680,22685,230177,230178,230179,230180,230181,230198,230199,230200,230201,230202,230345,230346,230347,230348,230349,230366,230367,230368,230369,230370,338844,338850,338892,338898,427185,427186,427191,427192,427233,427234,427239,427240,437585,437588,437609,437612)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_1_9_neg on atip_index_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22582,230384,22553,230380,230381,22187,230382,22615,22508,22466,22352,230383,22506,22602,22641,22664,338902,427243,427244,437615)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_10_14_f_pos on atip_index_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22279,230391,22658,230387,230388,22488,230389,22213,22306,22667,22215,230390,22443,22241,22420,22202,338904,427245,427246,437616)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_10_14_f_neg on atip_index_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22261,230216,22484,230212,230213,22263,230214,22358,22689,22480,22347,230215,22414,22206,22518,22384,338854,427195,427196,437590)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_10_14_m_pos on atip_index_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22307,230223,22672,230219,230220,22416,230221,22355,22513,22496,22477,230222,22619,22668,22240,22337,338856,427197,427198,437591)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_10_14_m_neg on atip_index_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22282,230405,22546,230401,230402,22534,230403,22491,22475,22233,22620,230404,22301,22254,22173,22402,338908,427249,427250,437618)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_15_19_f_pos on atip_index_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22397,230412,22328,230408,230409,22190,230410,22292,22311,22277,22342,230411,22522,22613,22572,22495,338910,427251,427252,437619)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_15_19_f_neg on atip_index_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22320,230237,22547,230233,230234,22660,230235,22406,22391,22460,22590,230236,22577,22511,22321,22549,338860,427201,427202,437593)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_15_19_m_pos on atip_index_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22413,230244,22526,230240,230241,22686,230242,22440,22242,22361,22386,230243,22465,22385,22177,22648,338862,427203,427204,437594)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_15_19_m_neg on atip_index_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22586,230426,22536,230422,230423,22222,230424,22175,22300,22208,22314,230425,22588,22367,22351,22631,338914,427255,427256,437621)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_20_24_f_pos on atip_index_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22393,230433,22218,230429,230430,22621,230431,22336,22294,22592,22578,230432,22541,22476,22323,22537,338916,427257,427258,437622)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_20_24_f_neg on atip_index_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22312,230258,22624,230254,230255,22258,230256,22247,22185,22691,22275,230257,22338,22250,22538,22211,338866,427207,427208,437596)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_20_24_m_pos on atip_index_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22357,230265,22345,230261,230262,22394,230263,22392,22499,22403,22415,230264,22265,22309,22278,22231,338868,427209,427210,437597)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_20_24_m_neg on atip_index_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22608,230447,22490,230443,230444,22285,230445,22344,22363,22497,22272,230446,22471,22380,22296,22251,338920,427261,427262,437624)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_49_f_pos on atip_index_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22303,230454,22354,230450,230451,22449,230452,22446,22236,22544,22462,230453,22459,22601,22172,22610,338922,427263,427264,437625)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_49_f_neg on atip_index_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22493,230279,22329,230275,230276,22555,230277,22657,22348,22383,22388,230278,22409,22676,22650,22259,338872,427213,427214,437599)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_49_m_pos on atip_index_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22618,230286,22318,230282,230283,22423,230284,22176,22399,22281,22290,230285,22591,22287,22681,22288,338874,427215,427216,437600)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_49_m_neg on atip_index_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562056,562057,562058,562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,562073,562074,562075,562076)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_29_f_pos on atip_index_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562077,562078,562079,562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,562094,562095,562096,562097)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_29_f_neg on atip_index_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561804,561805,561806,561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561821,561822,561823,561824)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_29_m_pos on atip_index_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561825,561826,561827,561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561842,561843,561844,561845)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_25_29_m_neg on atip_index_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565760,565761,565699,565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565714,565715,565716,565717)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_30_49_m_pos on atip_index_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565781,565782,565720,565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565735,565736,565737,565738)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_30_49_m_neg on atip_index_30_49_m_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565697,565698,565762,565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,565777,565778,565779,565780)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_30_49_f_pos on atip_index_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565718,565719,565783,565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,565798,565799,565800,565801)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_30_49_f_neg on atip_index_30_49_f_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22313,230468,22201,230464,230465,22482,230466,22266,22673,22412,22485,230467,22264,22514,22643,22596,338926,427267,427268,437627)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_50_f_pos on atip_index_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22325,230475,22461,230471,230472,22540,230473,22276,22438,22543,22244,230474,22500,22343,22467,22322,338928,427269,427270,437628)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_50_f_neg on atip_index_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22168,230300,22370,230296,230297,22238,230298,22639,22486,22656,22570,230299,22642,22670,22550,22647,338878,427219,427220,437602)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_50_m_pos on atip_index_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22481,230307,22389,230303,230304,22444,230305,22525,22521,22200,22600,230306,22212,22607,22569,22665,338880,427221,427222,437603)
  and attributeoptioncomboid =229786
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_index_50_m_neg on atip_index_50_m_neg.sourceid=ou.organisationunitid

  /*VCT*/
   /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21837,21861)
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_men1_pos on ats_index_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21838,21862)
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_men1_neg on ats_index_men1_neg.sourceid=ou.organisationunitid

  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565851
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_0_8_f_pos on ats_index_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565852
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_0_8_f_neg on ats_index_0_8_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565842
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_0_8_m_pos on ats_index_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565843
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_0_8_m_neg on ats_index_0_8_m_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565854
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_9_18_f_pos on ats_index_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565855
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_9_18_f_neg on ats_index_9_18_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565845
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_9_18_m_pos on ats_index_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565846
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_9_18_m_neg on ats_index_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565857
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_19_4_f_pos on ats_index_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565858
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_19_4_f_neg on ats_index_19_4_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565848
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_19_4_m_pos on ats_index_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565849
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_19_4_m_neg on ats_index_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21840,21843,21864,21867)
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_1_9_pos on ats_index_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21841,21844,21865,21868)
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_1_9_neg on ats_index_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21870
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_10_14_f_pos on ats_index_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21871
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_10_14_f_neg on ats_index_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21846
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_10_14_m_pos on ats_index_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21847
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_10_14_m_neg on ats_index_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21873
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_15_19_f_pos on ats_index_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21874
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_15_19_f_neg on ats_index_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21849
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_15_19_m_pos on ats_index_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21850
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_15_19_m_neg on ats_index_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21876
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_20_24_f_pos on ats_index_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21877
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_20_24_f_neg on ats_index_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21852
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_20_24_m_pos on ats_index_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21853
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_20_24_m_neg on ats_index_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21879
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_49_f_pos on ats_index_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21880
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_49_f_neg on ats_index_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21855
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_49_m_pos on ats_index_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21856
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_49_m_neg on ats_index_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561792
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_29_f_pos on ats_index_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561793
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_29_f_neg on ats_index_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561780
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_29_m_pos on ats_index_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561781
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_25_29_m_neg on ats_index_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565693
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_30_49_f_pos on ats_index_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565694
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_30_49_f_neg on ats_index_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565690
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_30_49_m_pos on ats_index_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565691
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_30_49_m_neg on ats_index_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21882
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_50_f_pos on ats_index_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21883
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_50_f_neg on ats_index_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21858
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_50_m_pos on ats_index_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21859
  and attributeoptioncomboid=184430 and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as ats_index_50_m_neg on ats_index_50_m_neg.sourceid=ou.organisationunitid

  /*PMTCT_STAT (Numerator)*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid IN (199702,199703,199704,199705,199706,199707,199708,199709,562864)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_num on PMTCT_STAT_17q2_num.sourceid=ou.organisationunitid

  /*Age Unknown*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (6920,CASE WHEN periodid IN (5786,3799,3817,18562,19934,20612,35909,35910,36804,27077,27397,32124,17085,17084,17083,104544) THEN 7407 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q1_num on PMTCT_STAT_17q1_num.sourceid=ou.organisationunitid

  /*Age*/
  /*<10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid IN (199706,199708)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_men10_num on PMTCT_STAT_17q2_men10_num.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199705
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_10_14_num on PMTCT_STAT_17q2_10_14_num.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199709
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_15_19_num on PMTCT_STAT_17q2_15_19_num.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199703
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_20_24_num on PMTCT_STAT_17q2_20_24_num.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid IN (199702,199707)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_25_49_num on PMTCT_STAT_17q2_25_49_num.sourceid=ou.organisationunitid

  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =562864
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_25_num on PMTCT_STAT_17q2_25_num.sourceid=ou.organisationunitid
  
    /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199704
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_50_num on PMTCT_STAT_17q2_50_num.sourceid=ou.organisationunitid

  /*Known Positive*/
  /*<10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid IN (199706,199708)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_men10_known_pos on PMTCT_STAT_17q2_men10_known_pos.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199705
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_10_14_known_pos on PMTCT_STAT_17q2_10_14_known_pos.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199709
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_15_19_known_pos on PMTCT_STAT_17q2_15_19_known_pos.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199703
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_20_24_known_pos on PMTCT_STAT_17q2_20_24_known_pos.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid IN (199702,199707)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_25_49_known_pos on PMTCT_STAT_17q2_25_49_known_pos.sourceid=ou.organisationunitid
  
  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =562864
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_25_known_pos on PMTCT_STAT_17q2_25_known_pos.sourceid=ou.organisationunitid

    /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199704
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_50_known_pos on PMTCT_STAT_17q2_50_known_pos.sourceid=ou.organisationunitid

  /*Unknown*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (6920)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q1_unk_known_pos on PMTCT_STAT_17q1_unk_known_pos.sourceid=ou.organisationunitid

  /*HTS_TST (Facility) - PITC Inpatient Services*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22395,22524,22209,22593)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_men1_pos on atip_enf_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22194,22230,22197,22401)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_men1_neg on atip_enf_men1_neg.sourceid=ou.organisationunitid
  
  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565920,565921)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_0_8_m_pos on atip_enf_0_8_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566109,566110)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_0_8_f_pos on atip_enf_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565941,565942)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_0_8_m_neg on atip_enf_0_8_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566130,566131)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_0_8_f_neg on atip_enf_0_8_f_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565983,565984)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_9_18_m_pos on atip_enf_9_18_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566172,566173)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_9_18_f_pos on atip_enf_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566004,566005)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_9_18_m_neg on atip_enf_9_18_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566193,566194)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_9_18_f_neg on atip_enf_9_18_f_neg.sourceid=ou.organisationunitid
  
  /*19m-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566046,566047)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_19_4_m_pos on atip_enf_19_4_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566235,566236)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_19_4_f_pos on atip_enf_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566067,566068)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_19_4_m_neg on atip_enf_19_4_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566256,566257)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_19_4_f_neg on atip_enf_19_4_f_neg.sourceid=ou.organisationunitid

  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22203,22375,22425,22456,22364,22503,22400,22542)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_1_9_pos on atip_enf_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22527,22655,22199,22516,22169,22680,22299,22587)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_1_9_neg on atip_enf_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22508,22615)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_10_14_f_pos on atip_enf_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22213,22306)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_10_14_f_neg on atip_enf_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22358,22689)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_10_14_m_pos on atip_enf_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22355,22513)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_10_14_m_neg on atip_enf_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22475,22491)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_15_19_f_pos on atip_enf_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22292,22311)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_15_19_f_neg on atip_enf_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22391,22406)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_15_19_m_pos on atip_enf_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22242,22440)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_15_19_m_neg on atip_enf_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22175,22300)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_20_24_f_pos on atip_enf_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22294,22336)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_20_24_f_neg on atip_enf_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22185,22247)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_20_24_m_pos on atip_enf_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22392,22499)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_20_24_m_neg on atip_enf_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22344,22363)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_49_f_pos on atip_enf_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22236,22446)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_49_f_neg on atip_enf_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22348,22657)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_49_m_pos on atip_enf_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22176,22399)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_49_m_neg on atip_enf_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562056,562057)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_29_f_pos on atip_enf_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562077,562078)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_29_f_neg on atip_enf_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561804,561805)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_29_m_pos on atip_enf_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561825,561826)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_25_29_m_neg on atip_enf_25_29_m_neg.sourceid=ou.organisationunitid

  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565760,565761)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_30_49_f_pos on atip_enf_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565781,565782)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_30_49_f_neg on atip_enf_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565697,565698)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_30_49_m_pos on atip_enf_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565718,565719)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_30_49_m_neg on atip_enf_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22266,22673)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_50_f_pos on atip_enf_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22276,22438)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_50_f_neg on atip_enf_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22486,22639)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_50_m_pos on atip_enf_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22521,22525)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_enf_50_m_neg on atip_enf_50_m_neg.sourceid=ou.organisationunitid

 /*HTS_TST (Facility) - PITC Emergency Ward*/
/*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565937
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_0_8_m_pos on atip_bso_0_8_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566126
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_0_8_f_pos on atip_bso_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565958
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_0_8_m_neg on atip_bso_0_8_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566147
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_0_8_f_neg on atip_bso_0_8_f_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566000
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_9_18_m_pos on atip_bso_9_18_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566189
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_9_18_f_pos on atip_bso_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566021
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_9_18_m_neg on atip_bso_9_18_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566210
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_9_18_f_neg on atip_bso_9_18_f_neg.sourceid=ou.organisationunitid
  
  /*19m-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566063
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_19_4_m_pos on atip_bso_19_4_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566252
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_19_4_f_pos on atip_bso_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566084
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_19_4_m_neg on atip_bso_19_4_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566273
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_19_4_f_neg on atip_bso_19_4_f_neg.sourceid=ou.organisationunitid

  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (338848,338896)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_1_9_pos on atip_bso_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (338850,338898)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_1_9_neg on atip_bso_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338902
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_10_14_f_pos on atip_bso_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338904
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_10_14_f_neg on atip_bso_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338854
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_10_14_m_pos on atip_bso_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338856
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_10_14_m_neg on atip_bso_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338908
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_15_19_f_pos on atip_bso_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338910
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_15_19_f_neg on atip_bso_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338860
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_15_19_m_pos on atip_bso_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338862
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_15_19_m_neg on atip_bso_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338914
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_20_24_f_pos on atip_bso_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338916
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_20_24_f_neg on atip_bso_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338866
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_20_24_m_pos on atip_bso_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338868
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_20_24_m_neg on atip_bso_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338920
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_49_f_pos on atip_bso_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338922
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_49_f_neg on atip_bso_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338872
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_49_m_pos on atip_bso_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338874
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_49_m_neg on atip_bso_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =562073
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_29_f_pos on atip_bso_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =562094
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_29_f_neg on atip_bso_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =561821
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_29_m_pos on atip_bso_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =561842
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_25_29_m_neg on atip_bso_25_29_m_neg.sourceid=ou.organisationunitid

  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565777
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_30_49_f_pos on atip_bso_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565798
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_30_49_f_neg on atip_bso_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565714
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_30_49_m_pos on atip_bso_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565735
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_30_49_m_neg on atip_bso_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338926
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_50_f_pos on atip_bso_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid  =338928
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_50_f_neg on atip_bso_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid  =338878
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_50_m_pos on atip_bso_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338880
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as atip_bso_50_m_neg on atip_bso_50_m_neg.sourceid=ou.organisationunitid
  
  /*PMTCT_STAT (Denominator)*/
  /*Age Unknown*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6913
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q1_den on PMTCT_STAT_17q1_den.sourceid=ou.organisationunitid

  /*Age*/
  /*<10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid IN (199706,199708)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_men10_den on PMTCT_STAT_17q2_men10_den.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid =199705
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_10_14_den on PMTCT_STAT_17q2_10_14_den.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid =199709
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_15_19_den on PMTCT_STAT_17q2_15_19_den.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid =199703
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_20_24_den on PMTCT_STAT_17q2_20_24_den.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid IN (199702,199707)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_25_49_den on PMTCT_STAT_17q2_25_49_den.sourceid=ou.organisationunitid

  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid=562864
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_25_den on PMTCT_STAT_17q2_25_den.sourceid=ou.organisationunitid

  
    /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 199711
  and categoryoptioncomboid =199704
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_STAT_17q2_50_den on PMTCT_STAT_17q2_50_den.sourceid=ou.organisationunitid


  /*PMTCT_EID*/
  /*Positive*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (7020,472971)
  and categoryoptioncomboid = 7011
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_0_2_pos on PMTCT_EID_0_2_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (23816,472972,648454)
  and categoryoptioncomboid IN (23813,7011)
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_2_12_pos_sum_prev on PMTCT_EID_2_12_pos_sum_prev.sourceid=ou.organisationunitid

  /*Negative*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (7020,472971)
  and categoryoptioncomboid =7014
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_0_2_neg on PMTCT_EID_0_2_neg.sourceid=ou.organisationunitid

    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (23816,472972)
  and categoryoptioncomboid =23812
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_2_12_neg on PMTCT_EID_2_12_neg.sourceid=ou.organisationunitid

  /*Collected*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 7020
  and categoryoptioncomboid =455205
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_0_2_col on PMTCT_EID_0_2_col.sourceid=ou.organisationunitid

    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 23816
  and categoryoptioncomboid =455204
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_2_12_col on PMTCT_EID_2_12_col.sourceid=ou.organisationunitid
  
  /*ART*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 642133
  and categoryoptioncomboid = 6989
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_0_2_art on PMTCT_EID_0_2_art.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  =642133
  and categoryoptioncomboid =6988
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_2_12_art on PMTCT_EID_2_12_art.sourceid=ou.organisationunitid
  
    /*TX_NEW*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805150
  and categoryoptioncomboid =16
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_num on TX_NEW_num.sourceid=ou.organisationunitid
  
  /*Preg_Breast*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805151
  and categoryoptioncomboid =443938
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_preg on TX_NEW_preg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805151
  and categoryoptioncomboid =443937
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_breast on TX_NEW_breast.sourceid=ou.organisationunitid
  
  /*TB*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805155
  and categoryoptioncomboid =16
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_tb on TX_NEW_tb.sourceid=ou.organisationunitid
  
  /*Under 10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805154
  and categoryoptioncomboid =444071
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_men1 on TX_NEW_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805154
  and categoryoptioncomboid =444072
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_1_9 on TX_NEW_1_9.sourceid=ou.organisationunitid
  
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444114
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_10_14_f on TX_NEW_10_14_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444116
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_15_19_f on TX_NEW_15_19_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444118
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_20_24_f on TX_NEW_20_24_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444122
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_25_49_f on TX_NEW_25_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603097
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_25_29_f on TX_NEW_25_29_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603099
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_30_34_f on TX_NEW_30_34_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603101
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_35_39_f on TX_NEW_35_39_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603103
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_40_49_f on TX_NEW_40_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444117
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_50_f on TX_NEW_50_f.sourceid=ou.organisationunitid
  
  /*Male*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444123
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_10_14_m on TX_NEW_10_14_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444119
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_15_19_m on TX_NEW_15_19_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444120
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_20_24_m on TX_NEW_20_24_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444115
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_25_49_m on TX_NEW_25_49_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603096
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_25_29_m on TX_NEW_25_29_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603098
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_30_34_m on TX_NEW_30_34_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603100
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_35_39_m on TX_NEW_35_39_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =603102
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_40_49_m on TX_NEW_40_49_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805153
  and categoryoptioncomboid =444121
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_50_m on TX_NEW_50_m.sourceid=ou.organisationunitid
  
  /*TX_CURR*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805159
  and categoryoptioncomboid =16
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_num on TX_CURR_num.sourceid=ou.organisationunitid
  
  /*Under 10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805162
  and categoryoptioncomboid =444071
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_men1 on TX_CURR_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805162
  and categoryoptioncomboid =444072
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_1_9 on TX_CURR_1_9.sourceid=ou.organisationunitid
  
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444114
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_10_14_f on TX_CURR_10_14_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444116
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_15_19_f on TX_CURR_15_19_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444118
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_20_24_f on TX_CURR_20_24_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444122
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_25_49_f on TX_CURR_25_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603097
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_25_29_f on TX_CURR_25_29_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603099
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_30_34_f on TX_CURR_30_34_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603101
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_35_39_f on TX_CURR_35_39_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603103
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_40_49_f on TX_CURR_40_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444117
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_50_f on TX_CURR_50_f.sourceid=ou.organisationunitid
  
  /*Male*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444123
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_10_14_m on TX_CURR_10_14_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444119
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_15_19_m on TX_CURR_15_19_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444120
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_20_24_m on TX_CURR_20_24_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444115
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_25_49_m on TX_CURR_25_49_m.sourceid=ou.organisationunitid
  
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603096
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_25_29_m on TX_CURR_25_29_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603098
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_30_34_m on TX_CURR_30_34_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603100
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_35_39_m on TX_CURR_35_39_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =603102
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_40_49_m on TX_CURR_40_49_m.sourceid=ou.organisationunitid
  
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805160
  and categoryoptioncomboid =444121
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_50_m on TX_CURR_50_m.sourceid=ou.organisationunitid
  
  /*TX_NEW TX_CURR Coarse*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805157
  and categoryoptioncomboid =481511
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_coarse_f_men15 on TX_NEW_coarse_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805157
  and categoryoptioncomboid =481512
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_coarse_f_mai15 on TX_NEW_coarse_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805157
  and categoryoptioncomboid =481513
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_coarse_m_men15 on TX_NEW_coarse_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805157
  and categoryoptioncomboid =481510
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_NEW_coarse_m_mai15 on TX_NEW_coarse_m_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805158
  and categoryoptioncomboid =481511
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_coarse_f_men15 on TX_CURR_coarse_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805158
  and categoryoptioncomboid =481512
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_coarse_f_mai15 on TX_CURR_coarse_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805158
  and categoryoptioncomboid =481513
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_coarse_m_men15 on TX_CURR_coarse_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 805158
  and categoryoptioncomboid =481510
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as TX_CURR_coarse_m_mai15 on TX_CURR_coarse_m_mai15.sourceid=ou.organisationunitid
  
  /*PMTCT_EID_total*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 6990
  and categoryoptioncomboid =6989
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_0_2_total on PMTCT_EID_0_2_total.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 6990
  and categoryoptioncomboid =6988
  and periodid= (select periodid from _periodstructure where iso=CAST(${monthly} AS text))
  group by sourceid) as PMTCT_EID_2_12_total on PMTCT_EID_2_12_total.sourceid=ou.organisationunitid
  

where ous.level=4 and ous.idlevel2=110 order by district.name || ' / ' || ou.name ASC;