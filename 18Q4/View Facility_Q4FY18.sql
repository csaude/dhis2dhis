select district.name || ' / ' || ou.name as facility,
'' AS placeholder1,
/*Quarterly*/
/*PrEP_NEW*/
COALESCE(PrEP_NEW_num.value,0) AS PrEP_NEW_num,
COALESCE(PrEP_NEW_15_19_f.value,0) AS PrEP_NEW_15_19_f,
COALESCE(PrEP_NEW_20_24_f.value,0) AS PrEP_NEW_20_24_f,
COALESCE(PrEP_NEW_25_29_f.value,0) AS PrEP_NEW_25_29_f,
COALESCE(PrEP_NEW_30_34_f.value,0) AS PrEP_NEW_30_34_f,
COALESCE(PrEP_NEW_35_39_f.value,0) AS PrEP_NEW_35_39_f,
COALESCE(PrEP_NEW_40_49_f.value,0) AS PrEP_NEW_40_49_f,
COALESCE(PrEP_NEW_50_f.value,0) AS PrEP_NEW_50_f,
COALESCE(PrEP_NEW_15_19_m.value,0) AS PrEP_NEW_15_19_m,
COALESCE(PrEP_NEW_20_24_m.value,0) AS PrEP_NEW_20_24_m,
COALESCE(PrEP_NEW_25_29_m.value,0) AS PrEP_NEW_25_29_m,
COALESCE(PrEP_NEW_30_34_m.value,0) AS PrEP_NEW_30_34_m,
COALESCE(PrEP_NEW_35_39_m.value,0) AS PrEP_NEW_35_39_m,
COALESCE(PrEP_NEW_40_49_m.value,0) AS PrEP_NEW_40_49_m,
COALESCE(PrEP_NEW_50_m.value,0) AS PrEP_NEW_50_m,
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
(COALESCE(HTS_TST_TB_25_29_f_pos.value,0)+COALESCE(HTS_TST_TB_30_34_f_pos.value,0)+COALESCE(HTS_TST_TB_35_39_f_pos.value,0)+COALESCE(HTS_TST_TB_40_49_f_pos.value,0)) +
(COALESCE(HTS_TST_TB_25_29_f_neg.value,0)+COALESCE(HTS_TST_TB_30_34_f_neg.value,0)+COALESCE(HTS_TST_TB_35_39_f_neg.value,0)+COALESCE(HTS_TST_TB_40_49_f_neg.value,0)) +
(COALESCE(HTS_TST_TB_25_29_m_pos.value,0)+COALESCE(HTS_TST_TB_30_34_m_pos.value,0)+COALESCE(HTS_TST_TB_35_39_m_pos.value,0)+COALESCE(HTS_TST_TB_40_49_m_pos.value,0)) +
(COALESCE(HTS_TST_TB_25_29_m_neg.value,0)+COALESCE(HTS_TST_TB_30_34_m_neg.value,0)+COALESCE(HTS_TST_TB_35_39_m_neg.value,0)+COALESCE(HTS_TST_TB_40_49_m_neg.value,0)) +
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
COALESCE(HTS_TST_TB_40_49_f_pos.value,0) AS HTS_TST_TB_40_49_f_pos,
COALESCE(HTS_TST_TB_40_49_f_neg.value,0) AS HTS_TST_TB_40_49_f_neg,
COALESCE(HTS_TST_TB_40_49_m_pos.value,0) AS HTS_TST_TB_40_49_m_pos,
COALESCE(HTS_TST_TB_40_49_m_neg.value,0) AS HTS_TST_TB_40_49_m_neg,
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
(COALESCE(PMTCT_EID_2_12_pos_sum_prev.value,0)+COALESCE(PMTCT_EID_9_12_pos.value,0)) AS PMTCT_EID_2_12_pos,
(COALESCE(PMTCT_EID_2_12_art.value,0)+COALESCE(PMTCT_EID_9_12_art.value,0)) AS PMTCT_EID_2_12_art,
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
COALESCE(TX_NEW_25_29_f.value,0) AS TX_NEW_25_29_f,
COALESCE(TX_NEW_30_34_f.value,0) AS TX_NEW_30_34_f,
COALESCE(TX_NEW_35_39_f.value,0) AS TX_NEW_35_39_f,
COALESCE(TX_NEW_40_49_f.value,0) AS TX_NEW_40_49_f,
COALESCE(TX_NEW_50_f.value,0) AS TX_NEW_50_f,
COALESCE(TX_NEW_10_14_m.value,0) AS TX_NEW_10_14_m,
COALESCE(TX_NEW_15_19_m.value,0) AS TX_NEW_15_19_m,
COALESCE(TX_NEW_20_24_m.value,0) AS TX_NEW_20_24_m,
COALESCE(TX_NEW_25_29_m.value,0) AS TX_NEW_25_29_m,
COALESCE(TX_NEW_30_34_m.value,0) AS TX_NEW_30_34_m,
COALESCE(TX_NEW_35_39_m.value,0) AS TX_NEW_35_39_m,
COALESCE(TX_NEW_40_49_m.value,0) AS TX_NEW_40_49_m,
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
COALESCE(TX_CURR_25_29_f.value,0) AS TX_CURR_25_29_f,
COALESCE(TX_CURR_30_34_f.value,0) AS TX_CURR_30_34_f,
COALESCE(TX_CURR_35_39_f.value,0) AS TX_CURR_35_39_f,
COALESCE(TX_CURR_40_49_f.value,0) AS TX_CURR_40_49_f,
COALESCE(TX_CURR_50_f.value,0) AS TX_CURR_50_f,
COALESCE(TX_CURR_10_14_m.value,0) AS TX_CURR_10_14_m,
COALESCE(TX_CURR_15_19_m.value,0) AS TX_CURR_15_19_m,
COALESCE(TX_CURR_20_24_m.value,0) AS TX_CURR_20_24_m,
COALESCE(TX_CURR_25_29_m.value,0) AS TX_CURR_25_29_m,
COALESCE(TX_CURR_30_34_m.value,0) AS TX_CURR_30_34_m,
COALESCE(TX_CURR_35_39_m.value,0) AS TX_CURR_35_39_m,
COALESCE(TX_CURR_40_49_m.value,0) AS TX_CURR_40_49_m,
COALESCE(TX_CURR_50_m.value,0) AS TX_CURR_50_m,
COALESCE(TX_CURR_coarse_f_men15.value,0) AS TX_CURR_coarse_f_men15,
COALESCE(TX_CURR_coarse_f_mai15.value,0) AS TX_CURR_coarse_f_mai15,
COALESCE(TX_CURR_coarse_m_men15.value,0) AS TX_CURR_coarse_m_men15,
COALESCE(TX_CURR_coarse_m_mai15.value,0) AS TX_CURR_coarse_m_mai15,
/*PMTCT_ART*/
COALESCE(PMTCT_ART_Newly.value,0) AS PMTCT_ART_Newly,
COALESCE(PMTCT_ART_Already.value,0) AS PMTCT_ART_Already,

/*Semi-Annual*/
/*TB_PREV (Numerator)*/
COALESCE(TB_PREV_num.value,0) AS TB_PREV_num,
COALESCE(TB_PREV_num_ipt_new.value,0) AS TB_PREV_num_ipt_new,
COALESCE(TB_PREV_num_ipt_already.value,0) AS TB_PREV_num_ipt_already,
'' AS placeholder46,
'' AS placeholder47,
COALESCE(TB_PREV_num_f_men15.value,0) AS TB_PREV_num_f_men15,
COALESCE(TB_PREV_num_f_mai15.value,0) AS TB_PREV_num_f_mai15,
COALESCE(TB_PREV_num_m_men15.value,0) AS TB_PREV_num_m_men15,
COALESCE(TB_PREV_num_m_mai15.value,0) AS TB_PREV_num_m_mai15,
/*TB_PREV (Denominator)*/
COALESCE(TB_PREV_den.value,0) AS TB_PREV_den,
COALESCE(TB_PREV_den_ipt_new.value,0) AS TB_PREV_den_ipt_new,
COALESCE(TB_PREV_den_ipt_already.value,0) AS TB_PREV_den_ipt_already,
'' AS placeholder48,
'' AS placeholder49,
COALESCE(TB_PREV_den_f_men15.value,0) AS TB_PREV_den_f_men15,
COALESCE(TB_PREV_den_f_mai15.value,0) AS TB_PREV_den_f_mai15,
COALESCE(TB_PREV_den_m_men15.value,0) AS TB_PREV_den_m_men15,
COALESCE(TB_PREV_den_m_mai15.value,0) AS TB_PREV_den_m_mai15,
/*TB_STAT_num*/
(COALESCE(TB_STAT_kp_num_m_men15_pos.value,0) +
COALESCE(TB_STAT_kp_num_m_mai15_pos.value,0) +
COALESCE(TB_STAT_kp_num_f_men15_pos.value,0) +
COALESCE(TB_STAT_kp_num_f_mai15_pos.value,0) +
COALESCE(TB_STAT_kn_num_m_men15_pos.value,0) +
COALESCE(TB_STAT_kn_num_m_mai15_pos.value,0) +
COALESCE(TB_STAT_kn_num_f_men15_pos.value,0) +
COALESCE(TB_STAT_kn_num_f_mai15_pos.value,0) +
COALESCE(TB_STAT_np_num_m_men15_pos.value,0) +
COALESCE(TB_STAT_np_num_m_mai15_pos.value,0) +
COALESCE(TB_STAT_np_num_f_men15_pos.value,0) +
COALESCE(TB_STAT_np_num_f_mai15_pos.value,0) +
COALESCE(TB_STAT_nn_num_m_men15_pos.value,0) +
COALESCE(TB_STAT_nn_num_m_mai15_pos.value,0) +
COALESCE(TB_STAT_nn_num_f_men15_pos.value,0) +
COALESCE(TB_STAT_nn_num_f_mai15_pos.value,0) ) as TB_STAT_num,
'' AS placeholder50,
'' AS placeholder51,
COALESCE(TB_STAT_kp_num_f_men15_pos.value,0) as TB_STAT_kp_num_f_men15_pos,
COALESCE(TB_STAT_kp_num_m_men15_pos.value,0) as TB_STAT_kp_num_m_men15_pos,
COALESCE(TB_STAT_kp_num_f_mai15_pos.value,0) as TB_STAT_kp_num_f_mai15_pos,
COALESCE(TB_STAT_kp_num_m_mai15_pos.value,0) as TB_STAT_kp_num_m_mai15_pos,
'' AS placeholder52,
'' AS placeholder53,
COALESCE(TB_STAT_np_num_f_men15_pos.value,0) as TB_STAT_np_num_f_men15_pos,
COALESCE(TB_STAT_np_num_m_men15_pos.value,0) as TB_STAT_np_num_m_men15_pos,
COALESCE(TB_STAT_np_num_f_mai15_pos.value,0) as TB_STAT_np_num_f_mai15_pos,
COALESCE(TB_STAT_np_num_m_mai15_pos.value,0) as TB_STAT_np_num_m_mai15_pos,
'' AS placeholder54,
'' AS placeholder55,
COALESCE(TB_STAT_nn_num_f_men15_pos.value,0) as TB_STAT_nn_num_f_men15_pos,
COALESCE(TB_STAT_nn_num_m_men15_pos.value,0) as TB_STAT_nn_num_m_men15_pos,
COALESCE(TB_STAT_nn_num_f_mai15_pos.value,0) as TB_STAT_nn_num_f_mai15_pos,
COALESCE(TB_STAT_nn_num_m_mai15_pos.value,0) as TB_STAT_nn_num_m_mai15_pos,
/*TB_STAT_den*/
(COALESCE(TB_STAT_den_f_mai15.value,0) +
COALESCE(TB_STAT_den_f_men15.value,0) +
COALESCE(TB_STAT_den_m_mai15.value,0) +
COALESCE(TB_STAT_den_m_men15.value,0) )as TB_STAT_den,
'' AS placeholder56,
'' AS placeholder57,
COALESCE(TB_STAT_den_f_men15.value,0) as TB_STAT_den_f_men15,
COALESCE(TB_STAT_den_m_men15.value,0) as TB_STAT_den_m_men15,
COALESCE(TB_STAT_den_f_mai15.value,0) as TB_STAT_den_f_mai15,
COALESCE(TB_STAT_den_m_mai15.value,0) as TB_STAT_den_m_mai15,
/*TB_ART_num*/
(COALESCE(TB_ART_num_17q3.value,0)) AS TB_ART_num,
COALESCE(TB_ART_already.value,0) AS TB_ART_already,
(COALESCE(TB_ART_num_17q3.value,0)-COALESCE(TB_ART_already.value,0)) AS TB_ART_new,
COALESCE(TB_ART_men1.value,0) AS TB_ART_men1,
COALESCE(TB_ART_1_9.value,0) AS TB_ART_1_9,
COALESCE(TB_ART_10_14_f.value,0) AS TB_ART_10_14_f,
COALESCE(TB_ART_15_19_f.value,0) AS TB_ART_15_19_f,
COALESCE(TB_ART_20_24_f.value,0) AS TB_ART_20_24_f,
COALESCE(TB_ART_25_29_f.value,0) AS TB_ART_25_29_f,
COALESCE(TB_ART_30_34_f.value,0) AS TB_ART_30_34_f,
COALESCE(TB_ART_35_39_f.value,0) AS TB_ART_35_39_f,
COALESCE(TB_ART_40_49_f.value,0) AS TB_ART_40_49_f,
COALESCE(TB_ART_50_f.value,0) AS TB_ART_50_f,
COALESCE(TB_ART_10_14_m.value,0) AS TB_ART_10_14_m,
COALESCE(TB_ART_15_19_m.value,0) AS TB_ART_15_19_m,
COALESCE(TB_ART_20_24_m.value,0) AS TB_ART_20_24_m,
COALESCE(TB_ART_25_29_m.value,0) AS TB_ART_25_29_m,
COALESCE(TB_ART_30_34_m.value,0) AS TB_ART_30_34_m,
COALESCE(TB_ART_35_39_m.value,0) AS TB_ART_35_39_m,
COALESCE(TB_ART_40_49_m.value,0) AS TB_ART_40_49_m,
COALESCE(TB_ART_50_m.value,0) AS TB_ART_50_m,
/*TX_TB (Numerator)*/
COALESCE(TX_TB_num.value,0) AS TX_TB_num,
COALESCE(TX_TB_num_new.value,0) AS TX_TB_num_new,
COALESCE(TX_TB_num_already.value,0) AS TX_TB_num_already,
COALESCE(TX_TB_num_f_men15.value,0) AS TX_TB_num_f_men15,
COALESCE(TX_TB_num_f_mai15.value,0) AS TX_TB_num_f_mai15,
COALESCE(TX_TB_num_m_men15.value,0) AS TX_TB_num_m_men15,
COALESCE(TX_TB_num_m_mai15.value,0) AS TX_TB_num_m_mai15,
/*TX_TB (Denominator)*/
COALESCE(TX_TB_den.value,0) AS TX_TB_den,
COALESCE(TX_TB_den_pos_new.value,0) AS TX_TB_den_pos_new,
COALESCE(TX_TB_den_pos_already.value,0) AS TX_TB_den_pos_already,
COALESCE(TX_TB_den_neg_new.value,0) AS TX_TB_den_neg_new,
COALESCE(TX_TB_den_neg_already.value,0) AS TX_TB_den_neg_already,
/*COALESCE(TX_TB_den_specimem.value,0) AS TX_TB_den_specimem,
COALESCE(TX_TB_den_smear.value,0) AS TX_TB_den_smear,
COALESCE(TX_TB_den_xpert.value,0) AS TX_TB_den_xpert,
COALESCE(TX_TB_den_other.value,0) AS TX_TB_den_other,*/
'' AS placeholder58,
'' AS placeholder59,
'' AS placeholder60,
'' AS placeholder61,
COALESCE(TX_TB_den_f_men15.value,0) AS TX_TB_den_f_men15,
COALESCE(TX_TB_den_f_mai15.value,0) AS TX_TB_den_f_mai15,
COALESCE(TX_TB_den_m_men15.value,0) AS TX_TB_den_m_men15,
COALESCE(TX_TB_den_m_mai15.value,0) AS TX_TB_den_m_mai15,
/*Annually*/
/*GEND_GBV*/
COALESCE(GEND_GBV_num.value,0) as GEND_GBV_num,
COALESCE(GEND_GBV_sexual_f_men10.value,0) as GEND_GBV_sexual_f_men10,
COALESCE(GEND_GBV_sexual_f_10_14.value,0) as GEND_GBV_sexual_f_10_14,
COALESCE(GEND_GBV_sexual_f_15_19.value,0) as GEND_GBV_sexual_f_15_19,
COALESCE(GEND_GBV_sexual_f_20_24.value,0) as GEND_GBV_sexual_f_20_24,
COALESCE(GEND_GBV_sexual_f_25_29.value,0) as GEND_GBV_sexual_f_25_29,
COALESCE(GEND_GBV_sexual_f_30_34.value,0) as GEND_GBV_sexual_f_30_34,
COALESCE(GEND_GBV_sexual_f_35_39.value,0) as GEND_GBV_sexual_f_35_39,
COALESCE(GEND_GBV_sexual_f_40_49.value,0) as GEND_GBV_sexual_f_40_49,
COALESCE(GEND_GBV_sexual_f_50.value,0) as GEND_GBV_sexual_f_50,
COALESCE(GEND_GBV_sexual_m_men10.value,0) as GEND_GBV_sexual_m_men10,
COALESCE(GEND_GBV_sexual_m_10_14.value,0) as GEND_GBV_sexual_m_10_14,
COALESCE(GEND_GBV_sexual_m_15_19.value,0) as GEND_GBV_sexual_m_15_19,
COALESCE(GEND_GBV_sexual_m_20_24.value,0) as GEND_GBV_sexual_m_20_24,
COALESCE(GEND_GBV_sexual_m_25_29.value,0) as GEND_GBV_sexual_m_25_29,
COALESCE(GEND_GBV_sexual_m_30_34.value,0) as GEND_GBV_sexual_m_30_34,
COALESCE(GEND_GBV_sexual_m_35_39.value,0) as GEND_GBV_sexual_m_35_39,
COALESCE(GEND_GBV_sexual_m_40_49.value,0) as GEND_GBV_sexual_m_40_49,
COALESCE(GEND_GBV_sexual_m_50.value,0) as GEND_GBV_sexual_m_50,
COALESCE(GEND_GBV_physical_f_men10.value,0) as GEND_GBV_physical_f_men10,
COALESCE(GEND_GBV_physical_f_10_14.value,0) as GEND_GBV_physical_f_10_14,
COALESCE(GEND_GBV_physical_f_15_19.value,0) as GEND_GBV_physical_f_15_19,
COALESCE(GEND_GBV_physical_f_20_24.value,0) as GEND_GBV_physical_f_20_24,
COALESCE(GEND_GBV_physical_f_25_29.value,0) as GEND_GBV_physical_f_25_29,
COALESCE(GEND_GBV_physical_f_30_34.value,0) as GEND_GBV_physical_f_30_34,
COALESCE(GEND_GBV_physical_f_35_39.value,0) as GEND_GBV_physical_f_35_39,
COALESCE(GEND_GBV_physical_f_40_49.value,0) as GEND_GBV_physical_f_40_49,
COALESCE(GEND_GBV_physical_f_50.value,0) as GEND_GBV_physical_f_50,
COALESCE(GEND_GBV_physical_m_men10.value,0) as GEND_GBV_physical_m_men10,
COALESCE(GEND_GBV_physical_m_10_14.value,0) as GEND_GBV_physical_m_10_14,
COALESCE(GEND_GBV_physical_m_15_19.value,0) as GEND_GBV_physical_m_15_19,
COALESCE(GEND_GBV_physical_m_20_24.value,0) as GEND_GBV_physical_m_20_24,
COALESCE(GEND_GBV_physical_m_25_29.value,0) as GEND_GBV_physical_m_25_29,
COALESCE(GEND_GBV_physical_m_30_34.value,0) as GEND_GBV_physical_m_30_34,
COALESCE(GEND_GBV_physical_m_35_39.value,0) as GEND_GBV_physical_m_35_39,
COALESCE(GEND_GBV_physical_m_40_49.value,0) as GEND_GBV_physical_m_40_49,
COALESCE(GEND_GBV_physical_m_50.value,0) as GEND_GBV_physical_m_50,
COALESCE(GEND_GBV_pep_f_men10.value,0) as GEND_GBV_pep_f_men10,
COALESCE(GEND_GBV_pep_f_10_14.value,0) as GEND_GBV_pep_f_10_14,
COALESCE(GEND_GBV_pep_f_15_19.value,0) as GEND_GBV_pep_f_15_19,
COALESCE(GEND_GBV_pep_f_20_24.value,0) as GEND_GBV_pep_f_20_24,
COALESCE(GEND_GBV_pep_f_25_29.value,0) as GEND_GBV_pep_f_25_29,
COALESCE(GEND_GBV_pep_f_30_34.value,0) as GEND_GBV_pep_f_30_34,
COALESCE(GEND_GBV_pep_f_35_39.value,0) as GEND_GBV_pep_f_35_39,
COALESCE(GEND_GBV_pep_f_40_49.value,0) as GEND_GBV_pep_f_40_49,
COALESCE(GEND_GBV_pep_f_50.value,0) as GEND_GBV_pep_f_50,
'' AS placeholder62,
'' AS placeholder63,
'' AS placeholder64,
'' AS placeholder65,
'' AS placeholder66,
'' AS placeholder67,
'' AS placeholder68,
'' AS placeholder69,
'' AS placeholder70,
/*FPINT_SITE*/
COALESCE(FPINT_SITE_hiv_testing.value,0) as FPINT_SITE_hiv_testing,
COALESCE(FPINT_SITE_ct.value,0) as FPINT_SITE_ct,
COALESCE(FPINT_SITE_anc.value,0) as FPINT_SITE_anc,
COALESCE(FPINT_SITE_priority.value,0) as FPINT_SITE_priority,
COALESCE(FPINT_SITE_key.value,0) as FPINT_SITE_key,
/*TX_RET*/
COALESCE(TX_RET_num_12mo.value,0) as TX_RET_num_12mo,
COALESCE(TX_RET_num_24mo.value,0) as TX_RET_num_24mo,
COALESCE(TX_RET_num_36mo.value,0) as TX_RET_num_36mo,
COALESCE(TX_RET_num_preg.value,0) as TX_RET_num_preg,
COALESCE(TX_RET_num_breast.value,0) as TX_RET_num_breast,
COALESCE(TX_RET_num_men1.value,0) as TX_RET_num_men1,
COALESCE(TX_RET_num_1_9.value,0) as TX_RET_num_1_9,
COALESCE(TX_RET_num_f_10_14.value,0) as TX_RET_num_f_10_14,
COALESCE(TX_RET_num_f_15_19.value,0) as TX_RET_num_f_15_19,
COALESCE(TX_RET_num_f_20_24.value,0) as TX_RET_num_f_20_24,
COALESCE(TX_RET_num_f_25_29.value,0) as TX_RET_num_f_25_29,
COALESCE(TX_RET_num_f_30_34.value,0) as TX_RET_num_f_30_34,
COALESCE(TX_RET_num_f_35_39.value,0) as TX_RET_num_f_35_39,
COALESCE(TX_RET_num_f_40_49.value,0) as TX_RET_num_f_40_49,
COALESCE(TX_RET_num_f_50.value,0) as TX_RET_num_f_50,
COALESCE(TX_RET_num_m_10_14.value,0) as TX_RET_num_m_10_14,
COALESCE(TX_RET_num_m_15_19.value,0) as TX_RET_num_m_15_19,
COALESCE(TX_RET_num_m_20_24.value,0) as TX_RET_num_m_20_24,
COALESCE(TX_RET_num_m_25_29.value,0) as TX_RET_num_m_25_29,
COALESCE(TX_RET_num_m_30_34.value,0) as TX_RET_num_m_30_34,
COALESCE(TX_RET_num_m_35_39.value,0) as TX_RET_num_m_35_39,
COALESCE(TX_RET_num_m_40_49.value,0) as TX_RET_num_m_40_49,
COALESCE(TX_RET_num_m_50.value,0) as TX_RET_num_m_50,
COALESCE(TX_RET_den_12mo.value,0) as TX_RET_den_12mo,
COALESCE(TX_RET_den_24mo.value,0) as TX_RET_den_24mo,
COALESCE(TX_RET_den_36mo.value,0) as TX_RET_den_36mo,
COALESCE(TX_RET_den_preg.value,0) as TX_RET_den_preg,
COALESCE(TX_RET_den_breast.value,0) as TX_RET_den_breast,
COALESCE(TX_RET_den_men1.value,0) as TX_RET_den_men1,
COALESCE(TX_RET_den_1_9.value,0) as TX_RET_den_1_9,
COALESCE(TX_RET_den_f_10_14.value,0) as TX_RET_den_f_10_14,
COALESCE(TX_RET_den_f_15_19.value,0) as TX_RET_den_f_15_19,
COALESCE(TX_RET_den_f_20_24.value,0) as TX_RET_den_f_20_24,
COALESCE(TX_RET_den_f_25_29.value,0) as TX_RET_den_f_25_29,
COALESCE(TX_RET_den_f_30_34.value,0) as TX_RET_den_f_30_34,
COALESCE(TX_RET_den_f_35_39.value,0) as TX_RET_den_f_35_39,
COALESCE(TX_RET_den_f_40_49.value,0) as TX_RET_den_f_40_49,
COALESCE(TX_RET_den_f_50.value,0) as TX_RET_den_f_50,
COALESCE(TX_RET_den_m_10_14.value,0) as TX_RET_den_m_10_14,
COALESCE(TX_RET_den_m_15_19.value,0) as TX_RET_den_m_15_19,
COALESCE(TX_RET_den_m_20_24.value,0) as TX_RET_den_m_20_24,
COALESCE(TX_RET_den_m_25_29.value,0) as TX_RET_den_m_25_29,
COALESCE(TX_RET_den_m_30_34.value,0) as TX_RET_den_m_30_34,
COALESCE(TX_RET_den_m_35_39.value,0) as TX_RET_den_m_35_39,
COALESCE(TX_RET_den_m_40_49.value,0) as TX_RET_den_m_40_49,
COALESCE(TX_RET_den_m_50.value,0) as TX_RET_den_m_50,
/*TX_PVLS*/
COALESCE(TX_PVLS_num_und.value,0) as TX_PVLS_num_und,
COALESCE(TX_PVLS_num_und_preg.value,0) as TX_PVLS_num_und_preg,
COALESCE(TX_PVLS_num_und_breast.value,0) as TX_PVLS_num_und_breast,
COALESCE(TX_PVLS_num_und_men1.value,0) as TX_PVLS_num_und_men1,
COALESCE(TX_PVLS_num_und_1_9.value,0) as TX_PVLS_num_und_1_9,
COALESCE(TX_PVLS_num_und_f_10_14.value,0) as TX_PVLS_num_und_f_10_14,
COALESCE(TX_PVLS_num_und_f_15_19.value,0) as TX_PVLS_num_und_f_15_19,
COALESCE(TX_PVLS_num_und_f_20_24.value,0) as TX_PVLS_num_und_f_20_24,
COALESCE(TX_PVLS_num_und_f_25_49.value,0) as TX_PVLS_num_und_f_25_49,
COALESCE(TX_PVLS_num_und_f_50.value,0) as TX_PVLS_num_und_f_50,
COALESCE(TX_PVLS_num_und_m_10_14.value,0) as TX_PVLS_num_und_m_10_14,
COALESCE(TX_PVLS_num_und_m_15_19.value,0) as TX_PVLS_num_und_m_15_19,
COALESCE(TX_PVLS_num_und_m_20_24.value,0) as TX_PVLS_num_und_m_20_24,
COALESCE(TX_PVLS_num_und_m_25_49.value,0) as TX_PVLS_num_und_m_25_49,
COALESCE(TX_PVLS_num_und_m_50.value,0) as TX_PVLS_num_und_m_50,
COALESCE(TX_PVLS_den.value,0) as TX_PVLS_den,
COALESCE(TX_PVLS_den_und.value,0) as TX_PVLS_den_und,
COALESCE(TX_PVLS_den_und_preg.value,0) as TX_PVLS_den_und_preg,
COALESCE(TX_PVLS_den_und_breast.value,0) as TX_PVLS_den_und_breast,
COALESCE(TX_PVLS_den_und_men1.value,0) as TX_PVLS_den_und_men1,
COALESCE(TX_PVLS_den_und_1_9.value,0) as TX_PVLS_den_und_1_9,
COALESCE(TX_PVLS_den_und_f_10_14.value,0) as TX_PVLS_den_und_f_10_14,
COALESCE(TX_PVLS_den_und_f_15_19.value,0) as TX_PVLS_den_und_f_15_19,
COALESCE(TX_PVLS_den_und_f_20_24.value,0) as TX_PVLS_den_und_f_20_24,
COALESCE(TX_PVLS_den_und_f_25_49.value,0) as TX_PVLS_den_und_f_25_49,
COALESCE(TX_PVLS_den_und_f_50.value,0) as TX_PVLS_den_und_f_50,
COALESCE(TX_PVLS_den_und_m_10_14.value,0) as TX_PVLS_den_und_m_10_14,
COALESCE(TX_PVLS_den_und_m_15_19.value,0) as TX_PVLS_den_und_m_15_19,
COALESCE(TX_PVLS_den_und_m_20_24.value,0) as TX_PVLS_den_und_m_20_24,
COALESCE(TX_PVLS_den_und_m_25_49.value,0) as TX_PVLS_den_und_m_25_49,
COALESCE(TX_PVLS_den_und_m_50.value,0) as TX_PVLS_den_und_m_50,
/*HRH_CURR*/
COALESCE(HRH_CURR_clinical_ss.value,0) as HRH_CURR_clinical_ss,
COALESCE(HRH_CURR_clinical_srs.value,0) as HRH_CURR_clinical_srs,
COALESCE(HRH_CURR_clinical_srnms.value,0) as HRH_CURR_clinical_srnms,
COALESCE(HRH_CURR_management_ss.value,0) as HRH_CURR_management_ss,
COALESCE(HRH_CURR_management_srs.value,0) as HRH_CURR_management_srs,
COALESCE(HRH_CURR_management_srnms.value,0) as HRH_CURR_management_srnms,
COALESCE(HRH_CURR_clinicalsupport_ss.value,0) as HRH_CURR_clinicalsupport_ss,
COALESCE(HRH_CURR_clinicalsupport_srs.value,0) as HRH_CURR_clinicalsupport_srs,
COALESCE(HRH_CURR_clinicalsupport_srnms.value,0) as HRH_CURR_clinicalsupport_srnms,
COALESCE(HRH_CURR_socialservices_ss.value,0) as HRH_CURR_socialservices_ss,
COALESCE(HRH_CURR_socialservices_srs.value,0) as HRH_CURR_socialservices_srs,
COALESCE(HRH_CURR_socialservices_srnms.value,0) as HRH_CURR_socialservices_srnms,
COALESCE(HRH_CURR_lay_ss.value,0) as HRH_CURR_lay_ss,
COALESCE(HRH_CURR_lay_srs.value,0) as HRH_CURR_lay_srs,
COALESCE(HRH_CURR_lay_srnms.value,0) as HRH_CURR_lay_srnms,
COALESCE(HRH_CURR_other_ss.value,0) as HRH_CURR_other_ss,
COALESCE(HRH_CURR_other_srs.value,0) as HRH_CURR_other_srs,
COALESCE(HRH_CURR_other_srnms.value,0) as HRH_CURR_other_srnms,
/*HRH_STAFF*/
COALESCE(HRH_STAFF_clinical.value,0) as HRH_STAFF_clinical,
COALESCE(HRH_STAFF_management.value,0) as HRH_STAFF_management,
COALESCE(HRH_STAFF_clinicalsupport.value,0) as HRH_STAFF_clinicalsupport,
COALESCE(HRH_STAFF_socialservices.value,0) as HRH_STAFF_socialservices,
COALESCE(HRH_STAFF_lay.value,0) as HRH_STAFF_lay,
COALESCE(HRH_STAFF_other.value,0) as HRH_STAFF_other,
/*EMR_SITE*/
EMR_SITE_hiv_testing.value as EMR_SITE_hiv_testing,
EMR_SITE_ct.value as EMR_SITE_ct,
EMR_SITE_anc.value as EMR_SITE_anc,
EMR_SITE_infant.value as EMR_SITE_infant,
EMR_SITE_hivtb.value as EMR_SITE_hivtb,
/*LAB_PTCQI (Lab-based)*/
/*CQI*/
COALESCE(LAB_PTCQI_lab_cqi_hivtest_noparticipation.value,0) as LAB_PTCQI_lab_cqi_hivtest_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_hivtest_audited.value,0) as LAB_PTCQI_lab_cqi_hivtest_audited,
COALESCE(LAB_PTCQI_lab_cqi_hivtest_accredited.value,0) as LAB_PTCQI_lab_cqi_hivtest_accredited,
COALESCE(LAB_PTCQI_lab_cqi_hivtest_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_hivtest_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_noparticipation.value,0) as LAB_PTCQI_lab_cqi_hivivt_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_audited.value,0) as LAB_PTCQI_lab_cqi_hivivt_audited,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_accredited.value,0) as LAB_PTCQI_lab_cqi_hivivt_accredited,
COALESCE(LAB_PTCQI_lab_cqi_hivivt_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_hivivt_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_load_noparticipation.value,0) as LAB_PTCQI_lab_cqi_load_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_load_audited.value,0) as LAB_PTCQI_lab_cqi_load_audited,
COALESCE(LAB_PTCQI_lab_cqi_load_accredited.value,0) as LAB_PTCQI_lab_cqi_load_accredited,
COALESCE(LAB_PTCQI_lab_cqi_load_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_load_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_noparticipation.value,0) as LAB_PTCQI_lab_cqi_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_audited.value,0) as LAB_PTCQI_lab_cqi_tbxpert_audited,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_accredited.value,0) as LAB_PTCQI_lab_cqi_tbxpert_accredited,
COALESCE(LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_noparticipation.value,0) as LAB_PTCQI_lab_cqi_tbafb_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_audited.value,0) as LAB_PTCQI_lab_cqi_tbafb_audited,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_accredited.value,0) as LAB_PTCQI_lab_cqi_tbafb_accredited,
COALESCE(LAB_PTCQI_lab_cqi_tbafb_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_tbafb_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_noparticipation.value,0) as LAB_PTCQI_lab_cqi_tbculture_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_audited.value,0) as LAB_PTCQI_lab_cqi_tbculture_audited,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_accredited.value,0) as LAB_PTCQI_lab_cqi_tbculture_accredited,
COALESCE(LAB_PTCQI_lab_cqi_tbculture_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_tbculture_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_cd4_noparticipation.value,0) as LAB_PTCQI_lab_cqi_cd4_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_cd4_audited.value,0) as LAB_PTCQI_lab_cqi_cd4_audited,
COALESCE(LAB_PTCQI_lab_cqi_cd4_accredited.value,0) as LAB_PTCQI_lab_cqi_cd4_accredited,
COALESCE(LAB_PTCQI_lab_cqi_cd4_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_cd4_fullyaccredited,
COALESCE(LAB_PTCQI_lab_cqi_other_noparticipation.value,0) as LAB_PTCQI_lab_cqi_other_noparticipation,
COALESCE(LAB_PTCQI_lab_cqi_other_audited.value,0) as LAB_PTCQI_lab_cqi_other_audited,
COALESCE(LAB_PTCQI_lab_cqi_other_accredited.value,0) as LAB_PTCQI_lab_cqi_other_accredited,
COALESCE(LAB_PTCQI_lab_cqi_other_fullyaccredited.value,0) as LAB_PTCQI_lab_cqi_other_fullyaccredited,
/*PT*/
COALESCE(LAB_PTCQI_lab_pt_hivtest_noparticipation.value,0) as LAB_PTCQI_lab_pt_hivtest_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_hivtest_notpassed.value,0) as LAB_PTCQI_lab_pt_hivtest_notpassed,
COALESCE(LAB_PTCQI_lab_pt_hivtest_passed.value,0) as LAB_PTCQI_lab_pt_hivtest_passed,
COALESCE(LAB_PTCQI_lab_pt_hivivt_noparticipation.value,0) as LAB_PTCQI_lab_pt_hivivt_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_hivivt_notpassed.value,0) as LAB_PTCQI_lab_pt_hivivt_notpassed,
COALESCE(LAB_PTCQI_lab_pt_hivivt_passed.value,0) as LAB_PTCQI_lab_pt_hivivt_passed,
COALESCE(LAB_PTCQI_lab_pt_load_noparticipation.value,0) as LAB_PTCQI_lab_pt_load_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_load_notpassed.value,0) as LAB_PTCQI_lab_pt_load_notpassed,
COALESCE(LAB_PTCQI_lab_pt_load_passed.value,0) as LAB_PTCQI_lab_pt_load_passed,
COALESCE(LAB_PTCQI_lab_pt_tbxpert_noparticipation.value,0) as LAB_PTCQI_lab_pt_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_tbxpert_notpassed.value,0) as LAB_PTCQI_lab_pt_tbxpert_notpassed,
COALESCE(LAB_PTCQI_lab_pt_tbxpert_passed.value,0) as LAB_PTCQI_lab_pt_tbxpert_passed,
COALESCE(LAB_PTCQI_lab_pt_tbafb_noparticipation.value,0) as LAB_PTCQI_lab_pt_tbafb_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_tbafb_notpassed.value,0) as LAB_PTCQI_lab_pt_tbafb_notpassed,
COALESCE(LAB_PTCQI_lab_pt_tbafb_passed.value,0) as LAB_PTCQI_lab_pt_tbafb_passed,
COALESCE(LAB_PTCQI_lab_pt_tbculture_noparticipation.value,0) as LAB_PTCQI_lab_pt_tbculture_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_tbculture_notpassed.value,0) as LAB_PTCQI_lab_pt_tbculture_notpassed,
COALESCE(LAB_PTCQI_lab_pt_tbculture_passed.value,0) as LAB_PTCQI_lab_pt_tbculture_passed,
COALESCE(LAB_PTCQI_lab_pt_cd4_noparticipation.value,0) as LAB_PTCQI_lab_pt_cd4_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_cd4_notpassed.value,0) as LAB_PTCQI_lab_pt_cd4_notpassed,
COALESCE(LAB_PTCQI_lab_pt_cd4_passed.value,0) as LAB_PTCQI_lab_pt_cd4_passed,
COALESCE(LAB_PTCQI_lab_pt_other_noparticipation.value,0) as LAB_PTCQI_lab_pt_other_noparticipation,
COALESCE(LAB_PTCQI_lab_pt_other_notpassed.value,0) as LAB_PTCQI_lab_pt_other_notpassed,
COALESCE(LAB_PTCQI_lab_pt_other_passed.value,0) as LAB_PTCQI_lab_pt_other_passed,
/*Volume*/
COALESCE(LAB_PTCQI_lab_hivtest.value,0) as LAB_PTCQI_lab_hivtest,
COALESCE(LAB_PTCQI_lab_hivivt.value,0) as LAB_PTCQI_lab_hivivt,
COALESCE(LAB_PTCQI_lab_load.value,0) as LAB_PTCQI_lab_load,
COALESCE(LAB_PTCQI_lab_tbxpert.value,0) as LAB_PTCQI_lab_tbxpert,
COALESCE(LAB_PTCQI_lab_tbafb.value,0) as LAB_PTCQI_lab_tbafb,
COALESCE(LAB_PTCQI_lab_tbculture.value,0) as LAB_PTCQI_lab_tbculture,
COALESCE(LAB_PTCQI_lab_cd4.value,0) as LAB_PTCQI_lab_cd4,
COALESCE(LAB_PTCQI_lab_other.value,0) as LAB_PTCQI_lab_other,
/*LAB_PTCQI (POCT-based)*/
/*CQI*/
COALESCE(LAB_PTCQI_poct_cqi_hivtest_noparticipation.value,0) as LAB_PTCQI_poct_cqi_hivtest_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_notaudited.value,0) as LAB_PTCQI_poct_cqi_hivtest_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_01.value,0) as LAB_PTCQI_poct_cqi_hivtest_01,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_23.value,0) as LAB_PTCQI_poct_cqi_hivtest_23,
COALESCE(LAB_PTCQI_poct_cqi_hivtest_45.value,0) as LAB_PTCQI_poct_cqi_hivtest_45,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_noparticipation.value,0) as LAB_PTCQI_poct_cqi_hivivt_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_notaudited.value,0) as LAB_PTCQI_poct_cqi_hivivt_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_01.value,0) as LAB_PTCQI_poct_cqi_hivivt_01,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_23.value,0) as LAB_PTCQI_poct_cqi_hivivt_23,
COALESCE(LAB_PTCQI_poct_cqi_hivivt_45.value,0) as LAB_PTCQI_poct_cqi_hivivt_45,
COALESCE(LAB_PTCQI_poct_cqi_load_noparticipation.value,0) as LAB_PTCQI_poct_cqi_load_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_load_notaudited.value,0) as LAB_PTCQI_poct_cqi_load_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_load_01.value,0) as LAB_PTCQI_poct_cqi_load_01,
COALESCE(LAB_PTCQI_poct_cqi_load_23.value,0) as LAB_PTCQI_poct_cqi_load_23,
COALESCE(LAB_PTCQI_poct_cqi_load_45.value,0) as LAB_PTCQI_poct_cqi_load_45,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_noparticipation.value,0) as LAB_PTCQI_poct_cqi_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_notaudited.value,0) as LAB_PTCQI_poct_cqi_tbxpert_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_01.value,0) as LAB_PTCQI_poct_cqi_tbxpert_01,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_23.value,0) as LAB_PTCQI_poct_cqi_tbxpert_23,
COALESCE(LAB_PTCQI_poct_cqi_tbxpert_45.value,0) as LAB_PTCQI_poct_cqi_tbxpert_45,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_noparticipation.value,0) as LAB_PTCQI_poct_cqi_tbafb_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_notaudited.value,0) as LAB_PTCQI_poct_cqi_tbafb_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_01.value,0) as LAB_PTCQI_poct_cqi_tbafb_01,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_23.value,0) as LAB_PTCQI_poct_cqi_tbafb_23,
COALESCE(LAB_PTCQI_poct_cqi_tbafb_45.value,0) as LAB_PTCQI_poct_cqi_tbafb_45,
COALESCE(LAB_PTCQI_poct_cqi_cd4_noparticipation.value,0) as LAB_PTCQI_poct_cqi_cd4_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_cd4_notaudited.value,0) as LAB_PTCQI_poct_cqi_cd4_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_cd4_01.value,0) as LAB_PTCQI_poct_cqi_cd4_01,
COALESCE(LAB_PTCQI_poct_cqi_cd4_23.value,0) as LAB_PTCQI_poct_cqi_cd4_23,
COALESCE(LAB_PTCQI_poct_cqi_cd4_45.value,0) as LAB_PTCQI_poct_cqi_cd4_45,
COALESCE(LAB_PTCQI_poct_cqi_other_noparticipation.value,0) as LAB_PTCQI_poct_cqi_other_noparticipation,
COALESCE(LAB_PTCQI_poct_cqi_other_notaudited.value,0) as LAB_PTCQI_poct_cqi_other_notaudited,
COALESCE(LAB_PTCQI_poct_cqi_other_01.value,0) as LAB_PTCQI_poct_cqi_other_01,
COALESCE(LAB_PTCQI_poct_cqi_other_23.value,0) as LAB_PTCQI_poct_cqi_other_23,
COALESCE(LAB_PTCQI_poct_cqi_other_45.value,0) as LAB_PTCQI_poct_cqi_other_45,
/*PT*/
COALESCE(LAB_PTCQI_poct_pt_hivtest_noparticipation.value,0) as LAB_PTCQI_poct_pt_hivtest_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_hivtest_notpassed.value,0) as LAB_PTCQI_poct_pt_hivtest_notpassed,
COALESCE(LAB_PTCQI_poct_pt_hivtest_passed.value,0) as LAB_PTCQI_poct_pt_hivtest_passed,
COALESCE(LAB_PTCQI_poct_pt_hivivt_noparticipation.value,0) as LAB_PTCQI_poct_pt_hivivt_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_hivivt_notpassed.value,0) as LAB_PTCQI_poct_pt_hivivt_notpassed,
COALESCE(LAB_PTCQI_poct_pt_hivivt_passed.value,0) as LAB_PTCQI_poct_pt_hivivt_passed,
COALESCE(LAB_PTCQI_poct_pt_load_noparticipation.value,0) as LAB_PTCQI_poct_pt_load_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_load_notpassed.value,0) as LAB_PTCQI_poct_pt_load_notpassed,
COALESCE(LAB_PTCQI_poct_pt_load_passed.value,0) as LAB_PTCQI_poct_pt_load_passed,
COALESCE(LAB_PTCQI_poct_pt_tbxpert_noparticipation.value,0) as LAB_PTCQI_poct_pt_tbxpert_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_tbxpert_notpassed.value,0) as LAB_PTCQI_poct_pt_tbxpert_notpassed,
COALESCE(LAB_PTCQI_poct_pt_tbxpert_passed.value,0) as LAB_PTCQI_poct_pt_tbxpert_passed,
COALESCE(LAB_PTCQI_poct_pt_tbafb_noparticipation.value,0) as LAB_PTCQI_poct_pt_tbafb_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_tbafb_notpassed.value,0) as LAB_PTCQI_poct_pt_tbafb_notpassed,
COALESCE(LAB_PTCQI_poct_pt_tbafb_passed.value,0) as LAB_PTCQI_poct_pt_tbafb_passed,
COALESCE(LAB_PTCQI_poct_pt_cd4_noparticipation.value,0) as LAB_PTCQI_poct_pt_cd4_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_cd4_notpassed.value,0) as LAB_PTCQI_poct_pt_cd4_notpassed,
COALESCE(LAB_PTCQI_poct_pt_cd4_passed.value,0) as LAB_PTCQI_poct_pt_cd4_passed,
COALESCE(LAB_PTCQI_poct_pt_other_noparticipation.value,0) as LAB_PTCQI_poct_pt_other_noparticipation,
COALESCE(LAB_PTCQI_poct_pt_other_notpassed.value,0) as LAB_PTCQI_poct_pt_other_notpassed,
COALESCE(LAB_PTCQI_poct_pt_other_passed.value,0) as LAB_PTCQI_poct_pt_other_passed,
/*Volume*/
COALESCE(LAB_PTCQI_poct_hivtest.value,0) as LAB_PTCQI_poct_hivtest,
COALESCE(LAB_PTCQI_poct_hivivt.value,0) as LAB_PTCQI_poct_hivivt,
COALESCE(LAB_PTCQI_poct_load.value,0) as LAB_PTCQI_poct_load,
COALESCE(LAB_PTCQI_poct_tbxpert.value,0) as LAB_PTCQI_poct_tbxpert,
COALESCE(LAB_PTCQI_poct_tbafb.value,0) as LAB_PTCQI_poct_tbafb,
COALESCE(LAB_PTCQI_poct_cd4.value,0) as LAB_PTCQI_poct_cd4,
COALESCE(LAB_PTCQI_poct_other.value,0) as LAB_PTCQI_poct_other,
/*PMTCT_FO*/
COALESCE(PMTCT_FO_den.value,0) as PMTCT_FO_den,
COALESCE(PMTCT_FO_hivinfected.value,0) as PMTCT_FO_hivinfected,
COALESCE(PMTCT_FO_hivuninfected.value,0) as PMTCT_FO_hivuninfected,
COALESCE(PMTCT_FO_hivfsu.value,0) as PMTCT_FO_hivfsu,
COALESCE(PMTCT_FO_died.value,0) as PMTCT_FO_died

from organisationunit ou
left outer join _orgunitstructure ous
  on (ou.organisationunitid=ous.organisationunitid)
left outer join organisationunit province
  on (ous.idlevel2=province.organisationunitid)
left outer join organisationunit district
  on (ous.idlevel3=district.organisationunitid)

/*Quarterly*/
/*PrEP_NEW*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735659
  and categoryoptioncomboid=16
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_num on PrEP_NEW_num.sourceid=ou.organisationunitid
  
/*Female*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735831
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_15_19_f on PrEP_NEW_15_19_f.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735833
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_20_24_f on PrEP_NEW_20_24_f.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735835
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_25_29_f on PrEP_NEW_25_29_f.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735837
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_30_34_f on PrEP_NEW_30_34_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735839
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_35_39_f on PrEP_NEW_35_39_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735841
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_40_49_f on PrEP_NEW_40_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735843
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_50_f on PrEP_NEW_50_f.sourceid=ou.organisationunitid

  /*Male*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735830
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_15_19_m on PrEP_NEW_15_19_m.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735832
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_20_24_m on PrEP_NEW_20_24_m.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735834
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_25_29_m on PrEP_NEW_25_29_m.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735836
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_30_34_m on PrEP_NEW_30_34_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735838
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_35_39_m on PrEP_NEW_35_39_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735840
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_40_49_m on PrEP_NEW_40_49_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=735857
  and categoryoptioncomboid=735842
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PrEP_NEW_50_m on PrEP_NEW_50_m.sourceid=ou.organisationunitid
  
/*PMTCT_ART*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6945
  and categoryoptioncomboid=6944
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_ART_Newly on PMTCT_ART_Newly.sourceid=ou.organisationunitid

left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6945
  and categoryoptioncomboid=6941
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_ART_Already on PMTCT_ART_Already.sourceid=ou.organisationunitid

/*HTS_TST (Facility) - PITC Pediatric Services*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=23817
  and categoryoptioncomboid=23818
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_Pediatric_pos on HTS_TST_Pediatric_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=23817
  and categoryoptioncomboid=23819
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_Pediatric_neg on HTS_TST_Pediatric_neg.sourceid=ou.organisationunitid

/*HTS_TST (Facility) - PITC - TB Clinics*/
/*Under 10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62234,62242)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_men1_pos on HTS_TST_TB_men1_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62250,62258)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_men1_neg on HTS_TST_TB_men1_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62235,62236,62243,62244)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_1_9_pos on HTS_TST_TB_1_9_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62251,62252,62259,62260)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_1_9_neg on HTS_TST_TB_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62245
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_10_14_f_pos on HTS_TST_TB_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62261
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_10_14_f_neg on HTS_TST_TB_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62237
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_10_14_m_pos on HTS_TST_TB_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62253
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_10_14_m_neg on HTS_TST_TB_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62246
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_15_19_f_pos on HTS_TST_TB_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62262
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_15_19_f_neg on HTS_TST_TB_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62238
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_15_19_m_pos on HTS_TST_TB_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62254
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_15_19_m_neg on HTS_TST_TB_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62247
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_20_24_f_pos on HTS_TST_TB_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62263
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_20_24_f_neg on HTS_TST_TB_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62239
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_20_24_m_pos on HTS_TST_TB_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62255
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_20_24_m_neg on HTS_TST_TB_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62248
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_49_f_pos on HTS_TST_TB_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62264
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_49_f_neg on HTS_TST_TB_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62240
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_49_m_pos on HTS_TST_TB_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62256
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_49_m_neg on HTS_TST_TB_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561752
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_29_f_pos on HTS_TST_TB_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561760
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_29_f_neg on HTS_TST_TB_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561748
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_29_m_pos on HTS_TST_TB_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561756
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_25_29_m_neg on HTS_TST_TB_25_29_m_neg.sourceid=ou.organisationunitid

  /*30-34*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561753
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_30_34_f_pos on HTS_TST_TB_30_34_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561761
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_30_34_f_neg on HTS_TST_TB_30_34_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561749
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_30_34_m_pos on HTS_TST_TB_30_34_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561757
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_30_34_m_neg on HTS_TST_TB_30_34_m_neg.sourceid=ou.organisationunitid
  
  /*35-39*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561754
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_35_39_f_pos on HTS_TST_TB_35_39_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561762
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_35_39_f_neg on HTS_TST_TB_35_39_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561750
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_35_39_m_pos on HTS_TST_TB_35_39_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561758
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_35_39_m_neg on HTS_TST_TB_35_39_m_neg.sourceid=ou.organisationunitid

  /*40-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561755
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_40_49_f_pos on HTS_TST_TB_40_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561763
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_40_49_f_neg on HTS_TST_TB_40_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561751
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_40_49_m_pos on HTS_TST_TB_40_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=561759
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_40_49_m_neg on HTS_TST_TB_40_49_m_neg.sourceid=ou.organisationunitid

  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62249
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_50_f_pos on HTS_TST_TB_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62265
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_50_f_neg on HTS_TST_TB_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62241
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_50_m_pos on HTS_TST_TB_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid=62257
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_TB_50_m_neg on HTS_TST_TB_50_m_neg.sourceid=ou.organisationunitid

  /*HTS_TST (Facility) - PITC PMTCT (ANC Only) Clinics*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=61998
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_men1_pos on HTS_TST_PMTCT_men1_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62017
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_men1_neg on HTS_TST_PMTCT_men1_neg.sourceid=ou.organisationunitid

  /*1-9*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid IN (62039,62031)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_1_9_pos on HTS_TST_PMTCT_1_9_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid IN (62030,62026)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_1_9_neg on HTS_TST_PMTCT_1_9_neg.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=61995
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_10_14_pos on HTS_TST_PMTCT_10_14_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=61999
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_10_14_neg on HTS_TST_PMTCT_10_14_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62023
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_15_19_pos on HTS_TST_PMTCT_15_19_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62010
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_15_19_neg on HTS_TST_PMTCT_15_19_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62036
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_20_24_pos on HTS_TST_PMTCT_20_24_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62004
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_20_24_neg on HTS_TST_PMTCT_20_24_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62012
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_25_49_pos on HTS_TST_PMTCT_25_49_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62002
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_25_49_neg on HTS_TST_PMTCT_25_49_neg.sourceid=ou.organisationunitid
  
  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=563004
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_25_pos on HTS_TST_PMTCT_25_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=563005
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_25_neg on HTS_TST_PMTCT_25_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62013
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as HTS_TST_PMTCT_50_pos on HTS_TST_PMTCT_50_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62040
  and categoryoptioncomboid=62009
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
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
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_men1_pos on atip_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22690,230328,22198,230324,230325,22558,230326,22548,22623,230327,22502,22669,22426,22584,22180,230160,22626,230156,230157,22268,230158,22552,22204,230159,22492,22273,22663,22635,427179,427180,427227,427228,437582,437606)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_men1_neg on atip_men1_neg.sourceid=ou.organisationunitid
  
  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566111,566112,566113,566114,566115,566117,566118,566119,566120,566121,566122,566123,566124,566127,566128,566129)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_0_8_f_pos on atip_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566132,566133,566134,566135,566136,566138,566139,566140,566141,566142,566143,566144,566145,566148,566149,566150)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_0_8_f_neg on atip_0_8_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565922,565923,565924,565925,565926,565928,565929,565930,565931,565932,565933,565934,565935,565938,565939,565940)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_0_8_m_pos on atip_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565943,565944,565945,565946,565947,565949,565950,565951,565952,565953,565954,565955,565956,565959,565960,565961)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_0_8_m_neg on atip_0_8_m_neg.sourceid=ou.organisationunitid

  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566174,566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,566190,566191,566192)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_9_18_f_pos on atip_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566195,566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,566211,566212,566213)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_9_18_f_neg on atip_9_18_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565985,565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566001,566002,566003)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_9_18_m_pos on atip_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566006,566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566022,566023,566024)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_9_18_m_neg on atip_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566237,566238,566239,566240,566241,566243,566244,566245,566246,566247,566248,566249,566250,566253,566254,566255)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_19_4_f_pos on atip_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566258,566259,566260,566261,566262,566264,566265,566266,566267,566268,566269,566270,566271,566274,566275,566276)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_19_4_f_neg on atip_19_4_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566048,566049,566050,566051,566052,566054,566055,566056,566057,566058,566059,566060,566061,566064,566065,566066)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_19_4_m_pos on atip_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566069,566070,566071,566072,566073,566075,566076,566077,566078,566079,566080,566081,566082,566085,566086,566087)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_19_4_m_neg on atip_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22171,22207,22235,22246,22256,22260,22327,22330,22335,22349,22350,22365,22372,22404,22405,22411,22447,22457,22464,22469,22483,22498,22509,22510,22512,22517,22560,22562,22565,22595,22597,22612,22628,22675,22683,22692,230170,230171,230172,230173,230174,230191,230192,230193,230194,230195,230338,230339,230340,230341,230342,230359,230360,230361,230362,230363,427183,427184,427189,427190,427231,427232,427237,427238,437584,437587,437608,437611)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_1_9_pos on atip_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22170,22182,22189,22191,22271,22295,22305,22317,22331,22333,22334,22339,22346,22430,22434,22463,22472,22473,22478,22515,22533,22561,22576,22580,22603,22614,22622,22629,22640,22646,22649,22653,22659,22671,22677,22685,230177,230178,230179,230180,230181,230198,230199,230200,230201,230202,230345,230346,230347,230348,230349,230366,230367,230368,230369,230370,427185,427186,427191,427192,427233,427234,427239,427240,437585,437588,437609,437612)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_1_9_neg on atip_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22582,230384,22553,230380,230381,22187,230382,22466,22352,230383,22506,22602,22641,22664,427243,427244,437615)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_10_14_f_pos on atip_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22279,230391,22658,230387,230388,22488,230389,22667,22215,230390,22443,22241,22420,22202,427245,427246,437616)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_10_14_f_neg on atip_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22261,230216,22484,230212,230213,22263,230214,22480,22347,230215,22414,22206,22518,22384,427195,427196,437590)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_10_14_m_pos on atip_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22307,230223,22672,230219,230220,22416,230221,22496,22477,230222,22619,22668,22240,22337,427197,427198,437591)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_10_14_m_neg on atip_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22282,230405,22546,230401,230402,22534,230403,22233,22620,230404,22301,22254,22173,22402,427249,427250,437618)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_15_19_f_pos on atip_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22397,230412,22328,230408,230409,22190,230410,22277,22342,230411,22522,22613,22572,22495,427251,427252,437619)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_15_19_f_neg on atip_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22320,230237,22547,230233,230234,22660,230235,22460,22590,230236,22577,22511,22321,22549,427201,427202,437593)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_15_19_m_pos on atip_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22413,230244,22526,230240,230241,22686,230242,22361,22386,230243,22465,22385,22177,22648,427203,427204,437594)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_15_19_m_neg on atip_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22586,230426,22536,230422,230423,22222,230424,22208,22314,230425,22588,22367,22351,22631,427255,427256,437621)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_20_24_f_pos on atip_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22393,230433,22218,230429,230430,22621,230431,22592,22578,230432,22541,22476,22323,22537,427257,427258,437622)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_20_24_f_neg on atip_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22312,230258,22624,230254,230255,22258,230256,22691,22275,230257,22338,22250,22538,22211,427207,427208,437596)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_20_24_m_pos on atip_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22357,230265,22345,230261,230262,22394,230263,22403,22415,230264,22265,22309,22278,22231,427209,427210,437597)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_20_24_m_neg on atip_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22608,230447,22490,230443,230444,22285,230445,22497,22272,230446,22471,22380,22296,22251,427261,427262,437624)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_49_f_pos on atip_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22303,230454,22354,230450,230451,22449,230452,22544,22462,230453,22459,22601,22172,22610,427263,427264,437625)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_49_f_neg on atip_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22493,230279,22329,230275,230276,22555,230277,22383,22388,230278,22409,22676,22650,22259,427213,427214,437599)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_49_m_pos on atip_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22618,230286,22318,230282,230283,22423,230284,22281,22290,230285,22591,22287,22681,22288,427215,427216,437600)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_49_m_neg on atip_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562058,562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,562074,562075,562076)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_29_f_pos on atip_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562079,562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,562095,562096,562097)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_29_f_neg on atip_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561806,561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561822,561823,561824)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_29_m_pos on atip_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561827,561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561843,561844,561845)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_25_29_m_neg on atip_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565762,565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,565778,565779,565780)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_30_49_f_pos on atip_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565783,565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,565799,565800,565801)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_30_49_f_neg on atip_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565699,565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565715,565716,565717)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_30_49_m_pos on atip_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565720,565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565736,565737,565738)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_30_49_m_neg on atip_30_49_m_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22313,230468,22201,230464,230465,22482,230466,22412,22485,230467,22264,22514,22643,22596,427267,427268,437627)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_50_f_pos on atip_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22325,230475,22461,230471,230472,22540,230473,22543,22244,230474,22500,22343,22467,22322,427269,427270,437628)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_50_f_neg on atip_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22168,230300,22370,230296,230297,22238,230298,22656,22570,230299,22642,22670,22550,22647,427219,427220,437602)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_50_m_pos on atip_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22481,230307,22389,230303,230304,22444,230305,22200,22600,230306,22212,22607,22569,22665,427221,427222,437603)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_50_m_neg on atip_50_m_neg.sourceid=ou.organisationunitid

  /*Maternidade*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (61998,61994)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_men1_pos on mat_men1_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62017,62000)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_men1_neg on mat_men1_neg.sourceid=ou.organisationunitid

  /*1-9*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62039,62031,62005,62029)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_1_9_pos on mat_1_9_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62030,62026,62019,62001)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_1_9_neg on mat_1_9_neg.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (61995,62027)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_10_14_pos on mat_10_14_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (61999,62003)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_10_14_neg on mat_10_14_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62023,62038)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_15_19_pos on mat_15_19_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62010,62014)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_15_19_neg on mat_15_19_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62036,62034)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_20_24_pos on mat_20_24_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62004,62015)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_20_24_neg on mat_20_24_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62012,62020)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_25_49_pos on mat_25_49_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62002,62022)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_25_49_neg on mat_25_49_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561724,561736)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_25_29_pos on mat_25_29_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561728,561740)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_25_29_neg on mat_25_29_neg.sourceid=ou.organisationunitid
  
  /*30-34*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561725,561737)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_30_34_pos on mat_30_34_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561729,561741)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_30_34_neg on mat_30_34_neg.sourceid=ou.organisationunitid
  
  /*35-39*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561726,561738)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_35_39_pos on mat_35_39_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561730,561742)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_35_39_neg on mat_35_39_neg.sourceid=ou.organisationunitid
  
  /*40-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561727,561739)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_40_49_pos on mat_40_49_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (561731,561743)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_40_49_neg on mat_40_49_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62013,62011)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_50_pos on mat_50_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62041
  and categoryoptioncomboid IN (62009,62006)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as mat_50_neg on mat_50_neg.sourceid=ou.organisationunitid

  /*CPN Parceiros*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6946
  and categoryoptioncomboid=6924
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as cpn_m_pos on cpn_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6946
  and categoryoptioncomboid=6925
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as cpn_m_neg on cpn_m_neg.sourceid=ou.organisationunitid

  /*HTS_TST (Facility) - VCT*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21837,21861)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_men1_pos on ats_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21838,21862)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_men1_neg on ats_men1_neg.sourceid=ou.organisationunitid
  
  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565851
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_0_8_f_pos on ats_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565852
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_0_8_f_neg on ats_0_8_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565842
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_0_8_m_pos on ats_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565843
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_0_8_m_neg on ats_0_8_m_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565854
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_9_18_f_pos on ats_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565855
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_9_18_f_neg on ats_9_18_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565845
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_9_18_m_pos on ats_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565846
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_9_18_m_neg on ats_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565857
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_19_4_f_pos on ats_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565858
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_19_4_f_neg on ats_19_4_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565848
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_19_4_m_pos on ats_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565849
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_19_4_m_neg on ats_19_4_m_neg.sourceid=ou.organisationunitid

  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21840,21843,21864,21867)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_1_9_pos on ats_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid IN (21841,21844,21865,21868)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_1_9_neg on ats_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21870
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_10_14_f_pos on ats_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21871
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_10_14_f_neg on ats_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21846
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_10_14_m_pos on ats_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21847
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_10_14_m_neg on ats_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21873
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_15_19_f_pos on ats_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21874
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_15_19_f_neg on ats_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21849
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_15_19_m_pos on ats_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21850
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_15_19_m_neg on ats_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21876
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_20_24_f_pos on ats_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21877
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_20_24_f_neg on ats_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21852
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_20_24_m_pos on ats_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21853
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_20_24_m_neg on ats_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21879
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_49_f_pos on ats_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21880
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_49_f_neg on ats_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21855
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_49_m_pos on ats_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21856
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_49_m_neg on ats_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561792
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_29_f_pos on ats_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561793
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_29_f_neg on ats_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561780
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_29_m_pos on ats_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=561781
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_25_29_m_neg on ats_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565693
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_30_49_f_pos on ats_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565694
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_30_49_f_neg on ats_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565690
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_30_49_m_pos on ats_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=565691
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_30_49_m_neg on ats_30_49_m_neg.sourceid=ou.organisationunitid

  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21882
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_50_f_pos on ats_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21883
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_50_f_neg on ats_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21858
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_50_m_pos on ats_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=21815
  and categoryoptioncomboid=21859
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
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
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_men1_pos on atip_index_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22690,230328,22198,230324,230325,22558,230326,22197,22401,22548,22623,230327,22502,22669,22426,22584,22180,230160,22626,230156,230157,22268,230158,22194,22230,22552,22204,230159,22492,22273,22663,22635,338838,338886,427179,427180,427227,427228,437582,437606)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_men1_neg on atip_index_men1_neg.sourceid=ou.organisationunitid

  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566109,566110,566111,566112,566113,566114,566115,566117,566118,566119,566120,566121,566122,566123,566124,566126,566127,566128,566129)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_0_8_f_pos on atip_index_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566130,566131,566132,566133,566134,566135,566136,566138,566139,566140,566141,566142,566143,566144,566145,566147,566148,566149,566150)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_0_8_f_neg on atip_index_0_8_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565920,565921,565922,565923,565924,565925,565926,565928,565929,565930,565931,565932,565933,565934,565935,565937,565938,565939,565940)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_0_8_m_pos on atip_index_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565941,565942,565943,565944,565945,565946,565947,565949,565950,565951,565952,565953,565954,565955,565956,565958,565959,565960,565961)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_0_8_m_neg on atip_index_0_8_m_neg.sourceid=ou.organisationunitid

  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566172,566173,566174,566175,566176,566177,566178,566180,566181,566182,566183,566184,566185,566186,566187,566189,566190,566191,566192)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_9_18_f_pos on atip_index_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566193,566194,566195,566196,566197,566198,566199,566201,566202,566203,566204,566205,566206,566207,566208,566210,566211,566212,566213)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_9_18_f_neg on atip_index_9_18_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565983,565984,565985,565986,565987,565988,565989,565991,565992,565993,565994,565995,565996,565997,565998,566000,566001,566002,566003)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_9_18_m_pos on atip_index_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566004,566005,566006,566007,566008,566009,566010,566012,566013,566014,566015,566016,566017,566018,566019,566021,566022,566023,566024)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_9_18_m_neg on atip_index_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566235,566236,566237,566238,566239,566240,566241,566243,566244,566245,566246,566247,566248,566249,566250,566252,566253,566254,566255)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_19_4_f_pos on atip_index_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566256,566257,566258,566259,566260,566261,566262,566264,566265,566266,566267,566268,566269,566270,566271,566273,566274,566275,566276)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_19_4_f_neg on atip_index_19_4_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566046,566047,566048,566049,566050,566051,566052,566054,566055,566056,566057,566058,566059,566060,566061,566063,566064,566065,566066)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_19_4_m_pos on atip_index_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566067,566068,566069,566070,566071,566072,566073,566075,566076,566077,566078,566079,566080,566081,566082,566084,566085,566086,566087)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_19_4_m_neg on atip_index_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22171,22203,22207,22235,22246,22256,22260,22327,22330,22335,22349,22350,22364,22365,22372,22375,22400,22404,22405,22411,22425,22447,22456,22457,22464,22469,22483,22498,22503,22509,22510,22512,22517,22542,22560,22562,22565,22595,22597,22612,22628,22675,22683,22692,230170,230171,230172,230173,230174,230191,230192,230193,230194,230195,230338,230339,230340,230341,230342,230359,230360,230361,230362,230363,338842,338848,338890,338896,427183,427184,427189,427190,427231,427232,427237,427238,437584,437587,437608,437611)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_1_9_pos on atip_index_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22169,22170,22182,22189,22191,22199,22271,22295,22299,22305,22317,22331,22333,22334,22339,22346,22430,22434,22463,22472,22473,22478,22515,22516,22527,22533,22561,22576,22580,22587,22603,22614,22622,22629,22640,22646,22649,22653,22655,22659,22671,22677,22680,22685,230177,230178,230179,230180,230181,230198,230199,230200,230201,230202,230345,230346,230347,230348,230349,230366,230367,230368,230369,230370,338844,338850,338892,338898,427185,427186,427191,427192,427233,427234,427239,427240,437585,437588,437609,437612)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_1_9_neg on atip_index_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22582,230384,22553,230380,230381,22187,230382,22615,22508,22466,22352,230383,22506,22602,22641,22664,338902,427243,427244,437615)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_10_14_f_pos on atip_index_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22279,230391,22658,230387,230388,22488,230389,22213,22306,22667,22215,230390,22443,22241,22420,22202,338904,427245,427246,437616)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_10_14_f_neg on atip_index_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22261,230216,22484,230212,230213,22263,230214,22358,22689,22480,22347,230215,22414,22206,22518,22384,338854,427195,427196,437590)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_10_14_m_pos on atip_index_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22307,230223,22672,230219,230220,22416,230221,22355,22513,22496,22477,230222,22619,22668,22240,22337,338856,427197,427198,437591)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_10_14_m_neg on atip_index_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22282,230405,22546,230401,230402,22534,230403,22491,22475,22233,22620,230404,22301,22254,22173,22402,338908,427249,427250,437618)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_15_19_f_pos on atip_index_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22397,230412,22328,230408,230409,22190,230410,22292,22311,22277,22342,230411,22522,22613,22572,22495,338910,427251,427252,437619)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_15_19_f_neg on atip_index_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22320,230237,22547,230233,230234,22660,230235,22406,22391,22460,22590,230236,22577,22511,22321,22549,338860,427201,427202,437593)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_15_19_m_pos on atip_index_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22413,230244,22526,230240,230241,22686,230242,22440,22242,22361,22386,230243,22465,22385,22177,22648,338862,427203,427204,437594)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_15_19_m_neg on atip_index_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22586,230426,22536,230422,230423,22222,230424,22175,22300,22208,22314,230425,22588,22367,22351,22631,338914,427255,427256,437621)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_20_24_f_pos on atip_index_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22393,230433,22218,230429,230430,22621,230431,22336,22294,22592,22578,230432,22541,22476,22323,22537,338916,427257,427258,437622)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_20_24_f_neg on atip_index_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22312,230258,22624,230254,230255,22258,230256,22247,22185,22691,22275,230257,22338,22250,22538,22211,338866,427207,427208,437596)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_20_24_m_pos on atip_index_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22357,230265,22345,230261,230262,22394,230263,22392,22499,22403,22415,230264,22265,22309,22278,22231,338868,427209,427210,437597)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_20_24_m_neg on atip_index_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22608,230447,22490,230443,230444,22285,230445,22344,22363,22497,22272,230446,22471,22380,22296,22251,338920,427261,427262,437624)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_49_f_pos on atip_index_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22303,230454,22354,230450,230451,22449,230452,22446,22236,22544,22462,230453,22459,22601,22172,22610,338922,427263,427264,437625)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_49_f_neg on atip_index_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22493,230279,22329,230275,230276,22555,230277,22657,22348,22383,22388,230278,22409,22676,22650,22259,338872,427213,427214,437599)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_49_m_pos on atip_index_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22618,230286,22318,230282,230283,22423,230284,22176,22399,22281,22290,230285,22591,22287,22681,22288,338874,427215,427216,437600)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_49_m_neg on atip_index_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562056,562057,562058,562059,562060,562061,562062,562064,562065,562066,562067,562068,562069,562070,562071,562073,562074,562075,562076)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_29_f_pos on atip_index_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562077,562078,562079,562080,562081,562082,562083,562085,562086,562087,562088,562089,562090,562091,562092,562094,562095,562096,562097)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_29_f_neg on atip_index_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561804,561805,561806,561807,561808,561809,561810,561812,561813,561814,561815,561816,561817,561818,561819,561821,561822,561823,561824)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_29_m_pos on atip_index_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561825,561826,561827,561828,561829,561830,561831,561833,561834,561835,561836,561837,561838,561839,561840,561842,561843,561844,561845)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_25_29_m_neg on atip_index_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565760,565761,565699,565700,565701,565702,565703,565705,565706,565707,565708,565709,565710,565711,565712,565714,565715,565716,565717)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_30_49_m_pos on atip_index_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565781,565782,565720,565721,565722,565723,565724,565726,565727,565728,565729,565730,565731,565732,565733,565735,565736,565737,565738)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_30_49_m_neg on atip_index_30_49_m_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565697,565698,565762,565763,565764,565765,565766,565768,565769,565770,565771,565772,565773,565774,565775,565777,565778,565779,565780)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_30_49_f_pos on atip_index_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565718,565719,565783,565784,565785,565786,565787,565789,565790,565791,565792,565793,565794,565795,565796,565798,565799,565800,565801)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_30_49_f_neg on atip_index_30_49_f_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22313,230468,22201,230464,230465,22482,230466,22266,22673,22412,22485,230467,22264,22514,22643,22596,338926,427267,427268,437627)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_50_f_pos on atip_index_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22325,230475,22461,230471,230472,22540,230473,22276,22438,22543,22244,230474,22500,22343,22467,22322,338928,427269,427270,437628)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_50_f_neg on atip_index_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22168,230300,22370,230296,230297,22238,230298,22639,22486,22656,22570,230299,22642,22670,22550,22647,338878,427219,427220,437602)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_50_m_pos on atip_index_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22481,230307,22389,230303,230304,22444,230305,22525,22521,22200,22600,230306,22212,22607,22569,22665,338880,427221,427222,437603)
  and attributeoptioncomboid =229786
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_index_50_m_neg on atip_index_50_m_neg.sourceid=ou.organisationunitid

  /*VCT*/
   /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21837,21861)
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_men1_pos on ats_index_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21838,21862)
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_men1_neg on ats_index_men1_neg.sourceid=ou.organisationunitid

  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565851
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_f_pos on ats_index_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565852
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_f_neg on ats_index_0_8_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565842
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_m_pos on ats_index_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565843
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_m_neg on ats_index_0_8_m_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565854
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_f_pos on ats_index_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565855
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_f_neg on ats_index_9_18_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565845
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_m_pos on ats_index_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565846
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_m_neg on ats_index_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565857
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_f_pos on ats_index_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565858
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_f_neg on ats_index_19_4_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565848
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_m_pos on ats_index_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565849
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_m_neg on ats_index_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21840,21843,21864,21867)
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_1_9_pos on ats_index_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21841,21844,21865,21868)
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_1_9_neg on ats_index_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21870
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_f_pos on ats_index_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21871
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_f_neg on ats_index_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21846
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_m_pos on ats_index_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21847
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_m_neg on ats_index_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21873
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_f_pos on ats_index_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21874
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_f_neg on ats_index_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21849
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_m_pos on ats_index_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21850
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_m_neg on ats_index_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21876
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_f_pos on ats_index_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21877
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_f_neg on ats_index_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21852
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_m_pos on ats_index_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21853
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_m_neg on ats_index_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21879
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_f_pos on ats_index_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21880
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_f_neg on ats_index_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21855
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_m_pos on ats_index_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21856
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_m_neg on ats_index_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561792
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_f_pos on ats_index_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561793
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_f_neg on ats_index_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561780
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_m_pos on ats_index_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561781
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_m_neg on ats_index_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565693
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_f_pos on ats_index_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565694
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_f_neg on ats_index_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565690
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_m_pos on ats_index_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565691
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_m_neg on ats_index_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21882
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_f_pos on ats_index_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21883
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_f_neg on ats_index_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21858
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_m_pos on ats_index_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21859
  and attributeoptioncomboid=184430 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_m_neg on ats_index_50_m_neg.sourceid=ou.organisationunitid

  /*PMTCT_STAT (Numerator)*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid IN (199702,199703,199704,199705,199706,199707,199708,199709,562864)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_num on PMTCT_STAT_17q2_num.sourceid=ou.organisationunitid

  /*Age Unknown*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (6920,CASE WHEN periodid IN (5786,3799,3817,18562,19934,20612,35909,35910,36804,27077,27397,32124,17085,17084,17083,104544) THEN 7407 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q1_num on PMTCT_STAT_17q1_num.sourceid=ou.organisationunitid

  /*Age*/
  /*<10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid IN (199706,199708)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_men10_num on PMTCT_STAT_17q2_men10_num.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199705
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_10_14_num on PMTCT_STAT_17q2_10_14_num.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199709
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_15_19_num on PMTCT_STAT_17q2_15_19_num.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199703
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_20_24_num on PMTCT_STAT_17q2_20_24_num.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid IN (199702,199707)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_25_49_num on PMTCT_STAT_17q2_25_49_num.sourceid=ou.organisationunitid

  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =562864
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_25_num on PMTCT_STAT_17q2_25_num.sourceid=ou.organisationunitid
  
    /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (199720,199729)
  and categoryoptioncomboid =199704
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_50_num on PMTCT_STAT_17q2_50_num.sourceid=ou.organisationunitid

  /*Known Positive*/
  /*<10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid IN (199706,199708)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_men10_known_pos on PMTCT_STAT_17q2_men10_known_pos.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199705
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_10_14_known_pos on PMTCT_STAT_17q2_10_14_known_pos.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199709
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_15_19_known_pos on PMTCT_STAT_17q2_15_19_known_pos.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199703
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_20_24_known_pos on PMTCT_STAT_17q2_20_24_known_pos.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid IN (199702,199707)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_25_49_known_pos on PMTCT_STAT_17q2_25_49_known_pos.sourceid=ou.organisationunitid
  
  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =562864
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_25_known_pos on PMTCT_STAT_17q2_25_known_pos.sourceid=ou.organisationunitid

    /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid =199720
  and categoryoptioncomboid =199704
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_50_known_pos on PMTCT_STAT_17q2_50_known_pos.sourceid=ou.organisationunitid

  /*Unknown*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid IN (6920)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q1_unk_known_pos on PMTCT_STAT_17q1_unk_known_pos.sourceid=ou.organisationunitid

  /*HTS_TST (Facility) - PITC Inpatient Services*/
  /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22395,22524,22209,22593)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_men1_pos on atip_enf_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22194,22230,22197,22401)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_men1_neg on atip_enf_men1_neg.sourceid=ou.organisationunitid
  
  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565920,565921)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_0_8_m_pos on atip_enf_0_8_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566109,566110)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_0_8_f_pos on atip_enf_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565941,565942)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_0_8_m_neg on atip_enf_0_8_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566130,566131)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_0_8_f_neg on atip_enf_0_8_f_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565983,565984)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_9_18_m_pos on atip_enf_9_18_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566172,566173)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_9_18_f_pos on atip_enf_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566004,566005)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_9_18_m_neg on atip_enf_9_18_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566193,566194)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_9_18_f_neg on atip_enf_9_18_f_neg.sourceid=ou.organisationunitid
  
  /*19m-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566046,566047)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_19_4_m_pos on atip_enf_19_4_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566235,566236)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_19_4_f_pos on atip_enf_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566067,566068)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_19_4_m_neg on atip_enf_19_4_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (566256,566257)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_19_4_f_neg on atip_enf_19_4_f_neg.sourceid=ou.organisationunitid

  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22203,22375,22425,22456,22364,22503,22400,22542)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_1_9_pos on atip_enf_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22527,22655,22199,22516,22169,22680,22299,22587)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_1_9_neg on atip_enf_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22508,22615)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_10_14_f_pos on atip_enf_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22213,22306)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_10_14_f_neg on atip_enf_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22358,22689)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_10_14_m_pos on atip_enf_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22355,22513)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_10_14_m_neg on atip_enf_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22475,22491)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_15_19_f_pos on atip_enf_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22292,22311)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_15_19_f_neg on atip_enf_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22391,22406)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_15_19_m_pos on atip_enf_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22242,22440)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_15_19_m_neg on atip_enf_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22175,22300)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_20_24_f_pos on atip_enf_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22294,22336)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_20_24_f_neg on atip_enf_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22185,22247)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_20_24_m_pos on atip_enf_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22392,22499)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_20_24_m_neg on atip_enf_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22344,22363)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_49_f_pos on atip_enf_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22236,22446)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_49_f_neg on atip_enf_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22348,22657)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_49_m_pos on atip_enf_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22176,22399)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_49_m_neg on atip_enf_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562056,562057)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_29_f_pos on atip_enf_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (562077,562078)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_29_f_neg on atip_enf_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561804,561805)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_29_m_pos on atip_enf_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (561825,561826)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_25_29_m_neg on atip_enf_25_29_m_neg.sourceid=ou.organisationunitid

  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565760,565761)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_30_49_f_pos on atip_enf_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565781,565782)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_30_49_f_neg on atip_enf_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565697,565698)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_30_49_m_pos on atip_enf_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (565718,565719)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_30_49_m_neg on atip_enf_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22266,22673)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_50_f_pos on atip_enf_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22276,22438)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_50_f_neg on atip_enf_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22486,22639)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_50_m_pos on atip_enf_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (22521,22525)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_enf_50_m_neg on atip_enf_50_m_neg.sourceid=ou.organisationunitid

 /*HTS_TST (Facility) - PITC Emergency Ward*/
/*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565937
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_0_8_m_pos on atip_bso_0_8_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566126
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_0_8_f_pos on atip_bso_0_8_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565958
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_0_8_m_neg on atip_bso_0_8_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566147
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_0_8_f_neg on atip_bso_0_8_f_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566000
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_9_18_m_pos on atip_bso_9_18_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566189
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_9_18_f_pos on atip_bso_9_18_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566021
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_9_18_m_neg on atip_bso_9_18_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566210
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_9_18_f_neg on atip_bso_9_18_f_neg.sourceid=ou.organisationunitid
  
  /*19m-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566063
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_19_4_m_pos on atip_bso_19_4_m_pos.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566252
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_19_4_f_pos on atip_bso_19_4_f_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566084
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_19_4_m_neg on atip_bso_19_4_m_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =566273
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_19_4_f_neg on atip_bso_19_4_f_neg.sourceid=ou.organisationunitid

  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (338848,338896)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_1_9_pos on atip_bso_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid IN (338850,338898)
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_1_9_neg on atip_bso_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338902
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_10_14_f_pos on atip_bso_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338904
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_10_14_f_neg on atip_bso_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338854
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_10_14_m_pos on atip_bso_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338856
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_10_14_m_neg on atip_bso_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338908
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_15_19_f_pos on atip_bso_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338910
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_15_19_f_neg on atip_bso_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338860
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_15_19_m_pos on atip_bso_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338862
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_15_19_m_neg on atip_bso_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338914
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_20_24_f_pos on atip_bso_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338916
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_20_24_f_neg on atip_bso_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338866
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_20_24_m_pos on atip_bso_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338868
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_20_24_m_neg on atip_bso_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338920
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_49_f_pos on atip_bso_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338922
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_49_f_neg on atip_bso_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338872
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_49_m_pos on atip_bso_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338874
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_49_m_neg on atip_bso_25_49_m_neg.sourceid=ou.organisationunitid
  
  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =562073
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_29_f_pos on atip_bso_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =562094
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_29_f_neg on atip_bso_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =561821
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_29_m_pos on atip_bso_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =561842
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_25_29_m_neg on atip_bso_25_29_m_neg.sourceid=ou.organisationunitid

  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565777
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_30_49_f_pos on atip_bso_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565798
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_30_49_f_neg on atip_bso_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565714
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_30_49_m_pos on atip_bso_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =565735
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_30_49_m_neg on atip_bso_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338926
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_50_f_pos on atip_bso_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid  =338928
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_50_f_neg on atip_bso_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid  =338878
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_50_m_pos on atip_bso_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=22693
  and categoryoptioncomboid =338880
  and attributeoptioncomboid IN (16,230146,CASE WHEN periodid=51202 THEN 229786 ELSE 0 END)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as atip_bso_50_m_neg on atip_bso_50_m_neg.sourceid=ou.organisationunitid
  
  /*PMTCT_STAT (Denominator)*/
  /*Age Unknown*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=6913
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q1_den on PMTCT_STAT_17q1_den.sourceid=ou.organisationunitid

  /*Age*/
  /*<10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid IN (199706,199708)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_men10_den on PMTCT_STAT_17q2_men10_den.sourceid=ou.organisationunitid

  /*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid =199705
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_10_14_den on PMTCT_STAT_17q2_10_14_den.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid =199709
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_15_19_den on PMTCT_STAT_17q2_15_19_den.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid =199703
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_20_24_den on PMTCT_STAT_17q2_20_24_den.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid IN (199702,199707)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_25_49_den on PMTCT_STAT_17q2_25_49_den.sourceid=ou.organisationunitid

  /*25+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 199711
  and categoryoptioncomboid=562864
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_25_den on PMTCT_STAT_17q2_25_den.sourceid=ou.organisationunitid

  
    /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 199711
  and categoryoptioncomboid =199704
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_STAT_17q2_50_den on PMTCT_STAT_17q2_50_den.sourceid=ou.organisationunitid


  /*PMTCT_EID*/
  /*Positive*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (7020,472971)
  and categoryoptioncomboid = 7011
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_0_2_pos on PMTCT_EID_0_2_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (23816,472972)
  and categoryoptioncomboid =23813
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_2_12_pos_sum_prev on PMTCT_EID_2_12_pos_sum_prev.sourceid=ou.organisationunitid
  
  /*>9 a 12 months*/
  /*Positive*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=648454
  and categoryoptioncomboid=7011
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_9_12_pos on PMTCT_EID_9_12_pos.sourceid=ou.organisationunitid
  
   /*ART*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=642133
  and categoryoptioncomboid=648456
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_9_12_art on PMTCT_EID_9_12_art.sourceid=ou.organisationunitid

  /*Negative*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (7020,472971)
  and categoryoptioncomboid =7014
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_0_2_neg on PMTCT_EID_0_2_neg.sourceid=ou.organisationunitid

    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  IN (23816,472972)
  and categoryoptioncomboid =23812
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_2_12_neg on PMTCT_EID_2_12_neg.sourceid=ou.organisationunitid

  /*Collected*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 7020
  and categoryoptioncomboid =455205
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_0_2_col on PMTCT_EID_0_2_col.sourceid=ou.organisationunitid

    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 23816
  and categoryoptioncomboid =455204
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_2_12_col on PMTCT_EID_2_12_col.sourceid=ou.organisationunitid
  
  /*ART*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 642133
  and categoryoptioncomboid = 6989
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_0_2_art on PMTCT_EID_0_2_art.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  =642133
  and categoryoptioncomboid =6988
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_2_12_art on PMTCT_EID_2_12_art.sourceid=ou.organisationunitid
  
    /*TX_NEW*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 443867
  and categoryoptioncomboid =16
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_num on TX_NEW_num.sourceid=ou.organisationunitid
  
  /*Preg_Breast*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 443945
  and categoryoptioncomboid =443938
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_preg on TX_NEW_preg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 443945
  and categoryoptioncomboid =443937
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_breast on TX_NEW_breast.sourceid=ou.organisationunitid
  
  /*TB*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 443970
  and categoryoptioncomboid =16
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_tb on TX_NEW_tb.sourceid=ou.organisationunitid
  
  /*Under 10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444074
  and categoryoptioncomboid =444071
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_men1 on TX_NEW_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444074
  and categoryoptioncomboid =444072
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_1_9 on TX_NEW_1_9.sourceid=ou.organisationunitid
  
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444114
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_10_14_f on TX_NEW_10_14_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444116
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_15_19_f on TX_NEW_15_19_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444118
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_20_24_f on TX_NEW_20_24_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444122
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_25_49_f on TX_NEW_25_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603097
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_25_29_f on TX_NEW_25_29_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603099
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_30_34_f on TX_NEW_30_34_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603101
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_35_39_f on TX_NEW_35_39_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603103
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_40_49_f on TX_NEW_40_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444117
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_50_f on TX_NEW_50_f.sourceid=ou.organisationunitid
  
  /*Male*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444123
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_10_14_m on TX_NEW_10_14_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444119
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_15_19_m on TX_NEW_15_19_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444120
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_20_24_m on TX_NEW_20_24_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444115
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_25_49_m on TX_NEW_25_49_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603096
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_25_29_m on TX_NEW_25_29_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603098
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_30_34_m on TX_NEW_30_34_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603100
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_35_39_m on TX_NEW_35_39_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =603102
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_40_49_m on TX_NEW_40_49_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444127
  and categoryoptioncomboid =444121
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_50_m on TX_NEW_50_m.sourceid=ou.organisationunitid
  
  /*TX_CURR*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444204
  and categoryoptioncomboid =16
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_num on TX_CURR_num.sourceid=ou.organisationunitid
  
  /*Under 10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444205
  and categoryoptioncomboid =444071
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_men1 on TX_CURR_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444205
  and categoryoptioncomboid =444072
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_1_9 on TX_CURR_1_9.sourceid=ou.organisationunitid
  
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444114
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_10_14_f on TX_CURR_10_14_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444116
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_15_19_f on TX_CURR_15_19_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444118
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_20_24_f on TX_CURR_20_24_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444122
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_25_49_f on TX_CURR_25_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603097
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_25_29_f on TX_CURR_25_29_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603099
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_30_34_f on TX_CURR_30_34_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603101
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_35_39_f on TX_CURR_35_39_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603103
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_40_49_f on TX_CURR_40_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444117
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_50_f on TX_CURR_50_f.sourceid=ou.organisationunitid
  
  /*Male*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444123
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_10_14_m on TX_CURR_10_14_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444119
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_15_19_m on TX_CURR_15_19_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444120
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_20_24_m on TX_CURR_20_24_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444115
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_25_49_m on TX_CURR_25_49_m.sourceid=ou.organisationunitid
  
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603096
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_25_29_m on TX_CURR_25_29_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603098
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_30_34_m on TX_CURR_30_34_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603100
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_35_39_m on TX_CURR_35_39_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =603102
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_40_49_m on TX_CURR_40_49_m.sourceid=ou.organisationunitid
  
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 444211
  and categoryoptioncomboid =444121
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_50_m on TX_CURR_50_m.sourceid=ou.organisationunitid
  
  /*TX_NEW TX_CURR Coarse*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515648
  and categoryoptioncomboid =481511
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_coarse_f_men15 on TX_NEW_coarse_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515648
  and categoryoptioncomboid =481512
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_coarse_f_mai15 on TX_NEW_coarse_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515648
  and categoryoptioncomboid =481513
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_coarse_m_men15 on TX_NEW_coarse_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515648
  and categoryoptioncomboid =481510
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_NEW_coarse_m_mai15 on TX_NEW_coarse_m_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515649
  and categoryoptioncomboid =481511
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_coarse_f_men15 on TX_CURR_coarse_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515649
  and categoryoptioncomboid =481512
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_coarse_f_mai15 on TX_CURR_coarse_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515649
  and categoryoptioncomboid =481513
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_coarse_m_men15 on TX_CURR_coarse_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 515649
  and categoryoptioncomboid =481510
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT quarterly from _periodstructure where periodid=599888))
  group by sourceid) as TX_CURR_coarse_m_mai15 on TX_CURR_coarse_m_mai15.sourceid=ou.organisationunitid
  
  /*PMTCT_EID_total*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 6990
  and categoryoptioncomboid =6989
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_0_2_total on PMTCT_EID_0_2_total.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 6990
  and categoryoptioncomboid =6988
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as PMTCT_EID_2_12_total on PMTCT_EID_2_12_total.sourceid=ou.organisationunitid
  
  /*Semi-Annual*/
  /*TB_PREV (Numerator)*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500018
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_num on TB_PREV_num.sourceid=ou.organisationunitid
  
  /*IPT*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 738384
  and categoryoptioncomboid =480776
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_num_ipt_new on TB_PREV_num_ipt_new.sourceid=ou.organisationunitid
  
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 738384
  and categoryoptioncomboid =480775
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_num_ipt_already on TB_PREV_num_ipt_already.sourceid=ou.organisationunitid
  
  /*Coarse*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500049
  and categoryoptioncomboid =481511
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_num_f_men15 on TB_PREV_num_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500049
  and categoryoptioncomboid =481512
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_num_f_mai15 on TB_PREV_num_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500049
  and categoryoptioncomboid =481513
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_num_m_men15 on TB_PREV_num_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500049
  and categoryoptioncomboid =481510
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_num_m_mai15 on TB_PREV_num_m_mai15.sourceid=ou.organisationunitid
  
  /*TB_PREV (Denominator)*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500066
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_den on TB_PREV_den.sourceid=ou.organisationunitid
  
  /*IPT*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 738411
  and categoryoptioncomboid =480776
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_den_ipt_new on TB_PREV_den_ipt_new.sourceid=ou.organisationunitid
  
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 738411
  and categoryoptioncomboid =480775
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_den_ipt_already on TB_PREV_den_ipt_already.sourceid=ou.organisationunitid
  
  /*Coarse*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500163
  and categoryoptioncomboid =481511
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_den_f_men15 on TB_PREV_den_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500163
  and categoryoptioncomboid =481512
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_den_f_mai15 on TB_PREV_den_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500163
  and categoryoptioncomboid =481513
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_den_m_men15 on TB_PREV_den_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 500163
  and categoryoptioncomboid =481510
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TB_PREV_den_m_mai15 on TB_PREV_den_m_mai15.sourceid=ou.organisationunitid
  
  /*TB_STAT (Numerator)*/
  /*Known Positive*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62266,62267,62268,62269)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kp_num_m_men15_pos on TB_STAT_kp_num_m_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62270,62271,62273,561764,561765,561766,561767)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kp_num_m_mai15_pos on TB_STAT_kp_num_m_mai15_pos.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62274,62275,62276,62277)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kp_num_f_men15_pos on TB_STAT_kp_num_f_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62278,62279,62281,561768,561769,561770,561771)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kp_num_f_mai15_pos on TB_STAT_kp_num_f_mai15_pos.sourceid=ou.organisationunitid
  
  /*Known Negative*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62282,62283,62284,62285)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kn_num_m_men15_pos on TB_STAT_kn_num_m_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62286,62287,62289,561772,561773,561774,561775)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kn_num_m_mai15_pos on TB_STAT_kn_num_m_mai15_pos.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62290,62291,62292,62293)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kn_num_f_men15_pos on TB_STAT_kn_num_f_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62294,62295,62297,561776,561777,561778,561779)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_kn_num_f_mai15_pos on TB_STAT_kn_num_f_mai15_pos.sourceid=ou.organisationunitid
  
  /*Newly Tested Positives*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62234,62235,62236,62237)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_np_num_m_men15_pos on TB_STAT_np_num_m_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62238,62239,62241,561748,561749,561750,561751)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_np_num_m_mai15_pos on TB_STAT_np_num_m_mai15_pos.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62242,62243,62244,62245)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_np_num_f_men15_pos on TB_STAT_np_num_f_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62246,62247,62249,561752,561753,561754,561755)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_np_num_f_mai15_pos on TB_STAT_np_num_f_mai15_pos.sourceid=ou.organisationunitid
  
   /*Newly Negatives*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62250,62251,62252,62253)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_nn_num_m_men15_pos on TB_STAT_nn_num_m_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62254,62255,62257,561756,561757,561758,561759)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_nn_num_m_mai15_pos on TB_STAT_nn_num_m_mai15_pos.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62258,62259,62260,62261)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_nn_num_f_men15_pos on TB_STAT_nn_num_f_men15_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=62230
  and categoryoptioncomboid IN (62262,62263,62265,561760,561761,561762,561763)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_nn_num_f_mai15_pos on TB_STAT_nn_num_f_mai15_pos.sourceid=ou.organisationunitid
  
  /*TB_STAT (Denominator)*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=199614
  and categoryoptioncomboid IN (562476,562477,562478,562479)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_den_f_men15 on TB_STAT_den_f_men15.sourceid=ou.organisationunitid

  left outer join (
    select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=199614
  and categoryoptioncomboid IN (562480,562481,562482,562483,562484,562485,562486)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_den_f_mai15 on TB_STAT_den_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=199614
  and categoryoptioncomboid IN (562465,562466,562467,562468)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_den_m_men15 on TB_STAT_den_m_men15.sourceid=ou.organisationunitid

  left outer join (
    select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=199614
  and categoryoptioncomboid IN (562469,562470,562471,562472,562473,562474,562475)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_STAT_den_m_mai15 on TB_STAT_den_m_mai15.sourceid=ou.organisationunitid
  
  /*TB_ART (Numerator)*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=298004
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_num_17q3 on TB_ART_num_17q3.sourceid=ou.organisationunitid
  
   /*TB_ART_Already on ART*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=3744
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_already on TB_ART_already.sourceid=ou.organisationunitid
  
  /*Under 10*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid IN (562465,562476)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_men1 on TB_ART_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid IN (562466,562467,562477,562478)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_1_9 on TB_ART_1_9.sourceid=ou.organisationunitid
  
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562479
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_10_14_f on TB_ART_10_14_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562480
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_15_19_f on TB_ART_15_19_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562481
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_20_24_f on TB_ART_20_24_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562482
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_25_29_f on TB_ART_25_29_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562483
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_30_34_f on TB_ART_30_34_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562484
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_35_39_f on TB_ART_35_39_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562485
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_40_49_f on TB_ART_40_49_f.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562486
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_50_f on TB_ART_50_f.sourceid=ou.organisationunitid
  
  /*Male*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562468
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_10_14_m on TB_ART_10_14_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562469
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_15_19_m on TB_ART_15_19_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562470
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_20_24_m on TB_ART_20_24_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562471
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_25_29_m on TB_ART_25_29_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562472
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_30_34_m on TB_ART_30_34_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562473
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_35_39_m on TB_ART_35_39_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562474
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_40_49_m on TB_ART_40_49_m.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 298004
  and categoryoptioncomboid =562475
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where sixmonthlyapril=(SELECT sixmonthlyapril from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as TB_ART_50_m on TB_ART_50_m.sourceid=ou.organisationunitid
  
  /*TX_TB (Numerator)*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480786
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_num on TX_TB_num.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480902
  and categoryoptioncomboid =480776
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_num_new on TX_TB_num_new.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480902
  and categoryoptioncomboid =480775
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_num_already on TX_TB_num_already.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480876
  and categoryoptioncomboid =481511
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_num_f_men15 on TX_TB_num_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480876
  and categoryoptioncomboid =481512
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_num_f_mai15 on TX_TB_num_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480876
  and categoryoptioncomboid =481513
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_num_m_men15 on TX_TB_num_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480876
  and categoryoptioncomboid =481510
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_num_m_mai15 on TX_TB_num_m_mai15.sourceid=ou.organisationunitid
  
  /*TX_TB (Denominator)*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480889
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den on TX_TB_den.sourceid=ou.organisationunitid
  
  /*Screening*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 750812
  and categoryoptioncomboid =750806
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_pos_new on TX_TB_den_pos_new.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 750812
  and categoryoptioncomboid =750807
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_pos_already on TX_TB_den_pos_already.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 750812
  and categoryoptioncomboid =750808
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_neg_new on TX_TB_den_neg_new.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 750812
  and categoryoptioncomboid =750809
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_neg_already on TX_TB_den_neg_already.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 481701
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_specimem on TX_TB_den_specimem.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 481106
  and categoryoptioncomboid =481017
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_smear on TX_TB_den_smear.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 481106
  and categoryoptioncomboid =481015
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_xpert on TX_TB_den_xpert.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 481106
  and categoryoptioncomboid =481016
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_other on TX_TB_den_other.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480890
  and categoryoptioncomboid =481511
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_f_men15 on TX_TB_den_f_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480890
  and categoryoptioncomboid =481512
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_f_mai15 on TX_TB_den_f_mai15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480890
  and categoryoptioncomboid =481513
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_m_men15 on TX_TB_den_m_men15.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid  = 480890
  and categoryoptioncomboid =481510
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT sixmonthlyapril from _periodstructure where periodid=599888))
  group by sourceid) as TX_TB_den_m_mai15 on TX_TB_den_m_mai15.sourceid=ou.organisationunitid
  
  /*Annually*/
  /*GEND_GBV*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=13043
  and categoryoptioncomboid IN (13041,13042)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_num on GEND_GBV_num.sourceid=ou.organisationunitid
 
 /*Sexual*/
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid IN (562364,562368,562384)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_men10  on GEND_GBV_sexual_f_men10.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562371
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_10_14  on GEND_GBV_sexual_f_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562370
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_15_19  on GEND_GBV_sexual_f_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562363
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_20_24  on GEND_GBV_sexual_f_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562372
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_25_29  on GEND_GBV_sexual_f_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562376
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_30_34  on GEND_GBV_sexual_f_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562367
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_35_39  on GEND_GBV_sexual_f_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562369
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_40_49  on GEND_GBV_sexual_f_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562385
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_f_50  on GEND_GBV_sexual_f_50.sourceid=ou.organisationunitid
  
  /*Male*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid IN (562366,562374,562378)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_men10  on GEND_GBV_sexual_m_men10.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562373
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_10_14  on GEND_GBV_sexual_m_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562377
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_15_19  on GEND_GBV_sexual_m_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562382
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_20_24  on GEND_GBV_sexual_m_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562383
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_25_29  on GEND_GBV_sexual_m_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562362
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_30_34  on GEND_GBV_sexual_m_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562365
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_35_39  on GEND_GBV_sexual_m_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562375
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_40_49  on GEND_GBV_sexual_m_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562387
  and categoryoptioncomboid = 562380
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_sexual_m_50  on GEND_GBV_sexual_m_50.sourceid=ou.organisationunitid
  
  /*Physical*/
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid IN (562364,562368,562384)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_men10  on GEND_GBV_physical_f_men10.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562371
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_10_14  on GEND_GBV_physical_f_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562370
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_15_19  on GEND_GBV_physical_f_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562363
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_20_24  on GEND_GBV_physical_f_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562372
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_25_29  on GEND_GBV_physical_f_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562376
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_30_34  on GEND_GBV_physical_f_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562367
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_35_39  on GEND_GBV_physical_f_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562369
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_40_49  on GEND_GBV_physical_f_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562385
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_f_50  on GEND_GBV_physical_f_50.sourceid=ou.organisationunitid
  
  /*Male*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid IN (562366,562374,562378)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_men10  on GEND_GBV_physical_m_men10.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562373
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_10_14  on GEND_GBV_physical_m_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562377
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_15_19  on GEND_GBV_physical_m_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562382
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_20_24  on GEND_GBV_physical_m_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562383
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_25_29  on GEND_GBV_physical_m_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562362
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_30_34  on GEND_GBV_physical_m_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562365
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_35_39  on GEND_GBV_physical_m_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562375
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_40_49  on GEND_GBV_physical_m_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562386
  and categoryoptioncomboid = 562380
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_physical_m_50  on GEND_GBV_physical_m_50.sourceid=ou.organisationunitid
  
  /*PEP*/
  /*Female*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid IN (562390,562391,562396)
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_men10  on GEND_GBV_pep_f_men10.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562392
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_10_14  on GEND_GBV_pep_f_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562395
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_15_19  on GEND_GBV_pep_f_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562397
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_20_24  on GEND_GBV_pep_f_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562398
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_25_29  on GEND_GBV_pep_f_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562394
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_30_34  on GEND_GBV_pep_f_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562400
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_35_39  on GEND_GBV_pep_f_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562399
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_40_49  on GEND_GBV_pep_f_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 562401
  and categoryoptioncomboid = 562389
  and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where financialoct=(SELECT financialoct from _periodstructure where periodid=599888) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as GEND_GBV_pep_f_50  on GEND_GBV_pep_f_50.sourceid=ou.organisationunitid
  
  /*FPINT_SITE*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 516969
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as FPINT_SITE_hiv_testing  on FPINT_SITE_hiv_testing.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 516968
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as FPINT_SITE_ct  on FPINT_SITE_ct.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 516967
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as FPINT_SITE_anc  on FPINT_SITE_anc.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 516971
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as FPINT_SITE_priority  on FPINT_SITE_priority.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid = 516970
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as FPINT_SITE_key  on FPINT_SITE_key.sourceid=ou.organisationunitid
  
  /*TX_RET (Numerator)*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483274
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_12mo on TX_RET_num_12mo.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483308
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_24mo on TX_RET_num_24mo.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483313
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_36mo on TX_RET_num_36mo.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483400
  and categoryoptioncomboid=443938
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_preg on TX_RET_num_preg.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483400
  and categoryoptioncomboid=443937
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_breast on TX_RET_num_breast.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483986
  and categoryoptioncomboid=444071
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_men1 on TX_RET_num_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483986
  and categoryoptioncomboid=444072
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_1_9 on TX_RET_num_1_9.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444114
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_10_14 on TX_RET_num_f_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444116
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_15_19 on TX_RET_num_f_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444118
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_20_24 on TX_RET_num_f_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444122
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_25_49 on TX_RET_num_f_25_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603097
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_25_29 on TX_RET_num_f_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603099
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_30_34 on TX_RET_num_f_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603101
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_35_39 on TX_RET_num_f_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603103
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_40_49 on TX_RET_num_f_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444117
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_f_50 on TX_RET_num_f_50.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444123
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_10_14 on TX_RET_num_m_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444119
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_15_19 on TX_RET_num_m_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444120
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_20_24 on TX_RET_num_m_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444115
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_25_49 on TX_RET_num_m_25_49.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603096
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_25_29 on TX_RET_num_m_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603098
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_30_34 on TX_RET_num_m_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603100
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_35_39 on TX_RET_num_m_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=603102
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_40_49 on TX_RET_num_m_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483996
  and categoryoptioncomboid=444121
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_num_m_50 on TX_RET_num_m_50.sourceid=ou.organisationunitid
  
  /*TX_RET (Denominator)*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=483998
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_12mo on TX_RET_den_12mo.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484007
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_24mo on TX_RET_den_24mo.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484008
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_36mo on TX_RET_den_36mo.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484011
  and categoryoptioncomboid=443938
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_preg on TX_RET_den_preg.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484011
  and categoryoptioncomboid=443937
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_breast on TX_RET_den_breast.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484010
  and categoryoptioncomboid=444071
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_men1 on TX_RET_den_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484010
  and categoryoptioncomboid=444072
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_1_9 on TX_RET_den_1_9.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444114
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_10_14 on TX_RET_den_f_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444116
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_15_19 on TX_RET_den_f_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444118
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_20_24 on TX_RET_den_f_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444122
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_25_49 on TX_RET_den_f_25_49.sourceid=ou.organisationunitid
  
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603097
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_25_29 on TX_RET_den_f_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603099
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_30_34 on TX_RET_den_f_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603101
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_35_39 on TX_RET_den_f_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603103
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_40_49 on TX_RET_den_f_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444117
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_f_50 on TX_RET_den_f_50.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444123
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_10_14 on TX_RET_den_m_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444119
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_15_19 on TX_RET_den_m_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444120
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_20_24 on TX_RET_den_m_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444115
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_25_49 on TX_RET_den_m_25_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603096
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_25_29 on TX_RET_den_m_25_29.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603098
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_30_34 on TX_RET_den_m_30_34.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603100
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_35_39 on TX_RET_den_m_35_39.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=603102
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_40_49 on TX_RET_den_m_40_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484009
  and categoryoptioncomboid=444121
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_RET_den_m_50 on TX_RET_den_m_50.sourceid=ou.organisationunitid
  
  /*TX_PVLS (Numerator)*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484185
  and categoryoptioncomboid=484019
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und on TX_PVLS_num_und.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484186
  and categoryoptioncomboid=484027
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_preg on TX_PVLS_num_und_preg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484186
  and categoryoptioncomboid=484025
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_breast on TX_PVLS_num_und_breast.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484187
  and categoryoptioncomboid=484030
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_men1 on TX_PVLS_num_und_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484187
  and categoryoptioncomboid=484034
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_1_9 on TX_PVLS_num_und_1_9.sourceid=ou.organisationunitid
  
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484054
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_f_10_14 on TX_PVLS_num_und_f_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484040
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_f_15_19 on TX_PVLS_num_und_f_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484036
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_f_20_24 on TX_PVLS_num_und_f_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484058
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_f_25_49 on TX_PVLS_num_und_f_25_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484064
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_f_50 on TX_PVLS_num_und_f_50.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484052
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_m_10_14 on TX_PVLS_num_und_m_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484047
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_m_15_19 on TX_PVLS_num_und_m_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484037
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_m_20_24 on TX_PVLS_num_und_m_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484060
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_m_25_49 on TX_PVLS_num_und_m_25_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484188
  and categoryoptioncomboid=484046
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_num_und_m_50 on TX_PVLS_num_und_m_50.sourceid=ou.organisationunitid
  
   /*TX_PVLS (Denominator)*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484192
  and categoryoptioncomboid=484019
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und on TX_PVLS_den_und.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484191
  and categoryoptioncomboid=484027
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_preg on TX_PVLS_den_und_preg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484191
  and categoryoptioncomboid=484025
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_breast on TX_PVLS_den_und_breast.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484190
  and categoryoptioncomboid=484030
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_men1 on TX_PVLS_den_und_men1.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484190
  and categoryoptioncomboid=484034
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_1_9 on TX_PVLS_den_und_1_9.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484054
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_f_10_14 on TX_PVLS_den_und_f_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484040
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_f_15_19 on TX_PVLS_den_und_f_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484036
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_f_20_24 on TX_PVLS_den_und_f_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484058
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_f_25_49 on TX_PVLS_den_und_f_25_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484064
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_f_50 on TX_PVLS_den_und_f_50.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484052
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_m_10_14 on TX_PVLS_den_und_m_10_14.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484047
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_m_15_19 on TX_PVLS_den_und_m_15_19.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484037
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_m_20_24 on TX_PVLS_den_und_m_20_24.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484060
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_m_25_49 on TX_PVLS_den_und_m_25_49.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=484189
  and categoryoptioncomboid=484046
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den_und_m_50 on TX_PVLS_den_und_m_50.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=493157
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as TX_PVLS_den on TX_PVLS_den.sourceid=ou.organisationunitid
  
  /*HRH_CURR_Clinical*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472662
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_clinical_ss on HRH_CURR_clinical_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472659
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_clinical_srs on HRH_CURR_clinical_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472661
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_clinical_srnms on HRH_CURR_clinical_srnms.sourceid=ou.organisationunitid
  
  /*HRH_CURR_Management*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472664
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_management_ss on HRH_CURR_management_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472666
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_management_srs on HRH_CURR_management_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472654
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_management_srnms on HRH_CURR_management_srnms.sourceid=ou.organisationunitid
  
  /*HRH_CURR_clinicalsupport*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472653
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_clinicalsupport_ss on HRH_CURR_clinicalsupport_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472663
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_clinicalsupport_srs on HRH_CURR_clinicalsupport_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472652
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_clinicalsupport_srnms on HRH_CURR_clinicalsupport_srnms.sourceid=ou.organisationunitid
  
  /*HRH_CURR_socialservices*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472668
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_socialservices_ss on HRH_CURR_socialservices_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472657
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_socialservices_srs on HRH_CURR_socialservices_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472667
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_socialservices_srnms on HRH_CURR_socialservices_srnms.sourceid=ou.organisationunitid
  
  /*HRH_CURR_lay*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472665
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_lay_ss on HRH_CURR_lay_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472656
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_lay_srs on HRH_CURR_lay_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472651
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_lay_srnms on HRH_CURR_lay_srnms.sourceid=ou.organisationunitid
  
/*HRH_CURR_other*/
left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472655
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_other_ss on HRH_CURR_other_ss.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472660
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_other_srs on HRH_CURR_other_srs.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472673
  and categoryoptioncomboid=472658
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_CURR_other_srnms on HRH_CURR_other_srnms.sourceid=ou.organisationunitid
  
/*HRH_STAFF*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472674
  and categoryoptioncomboid=472933
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_STAFF_clinical on HRH_STAFF_clinical.sourceid=ou.organisationunitid
  
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472674
  and categoryoptioncomboid=472935
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_STAFF_management on HRH_STAFF_management.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472674
  and categoryoptioncomboid=472934
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_STAFF_clinicalsupport on HRH_STAFF_clinicalsupport.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472674
  and categoryoptioncomboid=472936
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_STAFF_socialservices on HRH_STAFF_socialservices.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472674
  and categoryoptioncomboid=472937
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_STAFF_lay on HRH_STAFF_lay.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=472674
  and categoryoptioncomboid=472938
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as HRH_STAFF_other on HRH_STAFF_other.sourceid=ou.organisationunitid
  
 /*EMR_SITE*/
  left outer join (
  select sourceid, value as value
  from datavalue
  where dataelementid = 523786
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  ) as EMR_SITE_hiv_testing  on EMR_SITE_hiv_testing.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, value as value
  from datavalue
  where dataelementid = 523784
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  ) as EMR_SITE_ct  on EMR_SITE_ct.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, value as value
  from datavalue
  where dataelementid = 523779
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  ) as EMR_SITE_anc  on EMR_SITE_anc.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, value as value
  from datavalue
  where dataelementid = 523785
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  ) as EMR_SITE_infant  on EMR_SITE_infant.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, value as value
  from datavalue
  where dataelementid = 523791
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  ) as EMR_SITE_hivtb  on EMR_SITE_hivtb.sourceid=ou.organisationunitid
  
  /*LAB_PTCQI (Lab-based)*/
  /*CQI*/
  /*HIV Testing*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168747
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivtest_noparticipation on LAB_PTCQI_lab_cqi_hivtest_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168746
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivtest_audited on LAB_PTCQI_lab_cqi_hivtest_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168745
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivtest_accredited on LAB_PTCQI_lab_cqi_hivtest_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168744
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivtest_fullyaccredited on LAB_PTCQI_lab_cqi_hivtest_fullyaccredited.sourceid=ou.organisationunitid
  
  /*HIV IVT*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168751
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivivt_noparticipation on LAB_PTCQI_lab_cqi_hivivt_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168750
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivivt_audited on LAB_PTCQI_lab_cqi_hivivt_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168749
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivivt_accredited on LAB_PTCQI_lab_cqi_hivivt_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168748
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_hivivt_fullyaccredited on LAB_PTCQI_lab_cqi_hivivt_fullyaccredited.sourceid=ou.organisationunitid
  
  /*HIV Viral Load*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168755
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_load_noparticipation on LAB_PTCQI_lab_cqi_load_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168754
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_load_audited on LAB_PTCQI_lab_cqi_load_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168753
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_load_accredited on LAB_PTCQI_lab_cqi_load_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168752
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_load_fullyaccredited on LAB_PTCQI_lab_cqi_load_fullyaccredited.sourceid=ou.organisationunitid
  
    /*TB Xpert*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168759
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbxpert_noparticipation on LAB_PTCQI_lab_cqi_tbxpert_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168758
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbxpert_audited on LAB_PTCQI_lab_cqi_tbxpert_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168757
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbxpert_accredited on LAB_PTCQI_lab_cqi_tbxpert_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168756
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited on LAB_PTCQI_lab_cqi_tbxpert_fullyaccredited.sourceid=ou.organisationunitid
  
  /*TB AFB*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168763
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbafb_noparticipation on LAB_PTCQI_lab_cqi_tbafb_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168762
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbafb_audited on LAB_PTCQI_lab_cqi_tbafb_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168761
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbafb_accredited on LAB_PTCQI_lab_cqi_tbafb_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168760
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbafb_fullyaccredited on LAB_PTCQI_lab_cqi_tbafb_fullyaccredited.sourceid=ou.organisationunitid
  
    /*TB Culture*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168767
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbculture_noparticipation on LAB_PTCQI_lab_cqi_tbculture_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168766
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbculture_audited on LAB_PTCQI_lab_cqi_tbculture_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168765
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbculture_accredited on LAB_PTCQI_lab_cqi_tbculture_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168764
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_tbculture_fullyaccredited on LAB_PTCQI_lab_cqi_tbculture_fullyaccredited.sourceid=ou.organisationunitid
  
      /*TB Culture*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168771
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_cd4_noparticipation on LAB_PTCQI_lab_cqi_cd4_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168770
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_cd4_audited on LAB_PTCQI_lab_cqi_cd4_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168769
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_cd4_accredited on LAB_PTCQI_lab_cqi_cd4_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168768
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_cd4_fullyaccredited on LAB_PTCQI_lab_cqi_cd4_fullyaccredited.sourceid=ou.organisationunitid
  
     /*Other*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168775
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_other_noparticipation on LAB_PTCQI_lab_cqi_other_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168774
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_other_audited on LAB_PTCQI_lab_cqi_other_audited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168773
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_other_accredited on LAB_PTCQI_lab_cqi_other_accredited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168777
  and categoryoptioncomboid=1168772
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cqi_other_fullyaccredited on LAB_PTCQI_lab_cqi_other_fullyaccredited.sourceid=ou.organisationunitid
  
  /*PT*/
/*HIV Testing*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169326
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_hivtest_noparticipation on LAB_PTCQI_lab_pt_hivtest_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169325
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_hivtest_notpassed on LAB_PTCQI_lab_pt_hivtest_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169324
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_hivtest_passed on LAB_PTCQI_lab_pt_hivtest_passed.sourceid=ou.organisationunitid
  
  /*HIV IVT*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169329
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_hivivt_noparticipation on LAB_PTCQI_lab_pt_hivivt_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169328
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_hivivt_notpassed on LAB_PTCQI_lab_pt_hivivt_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169327
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_hivivt_passed on LAB_PTCQI_lab_pt_hivivt_passed.sourceid=ou.organisationunitid
  
  /*HIV Viral Load*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169332
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_load_noparticipation on LAB_PTCQI_lab_pt_load_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169331
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_load_notpassed on LAB_PTCQI_lab_pt_load_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169330
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_load_passed on LAB_PTCQI_lab_pt_load_passed.sourceid=ou.organisationunitid
  
    /*TB Xpert*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169335
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbxpert_noparticipation on LAB_PTCQI_lab_pt_tbxpert_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169334
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbxpert_notpassed on LAB_PTCQI_lab_pt_tbxpert_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169333
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbxpert_passed on LAB_PTCQI_lab_pt_tbxpert_passed.sourceid=ou.organisationunitid
  
  /*TB AFB*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169338
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbafb_noparticipation on LAB_PTCQI_lab_pt_tbafb_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169337
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbafb_notpassed on LAB_PTCQI_lab_pt_tbafb_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169336
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbafb_passed on LAB_PTCQI_lab_pt_tbafb_passed.sourceid=ou.organisationunitid

  
    /*TB Culture*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169341
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbculture_noparticipation on LAB_PTCQI_lab_pt_tbculture_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169340
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbculture_notpassed on LAB_PTCQI_lab_pt_tbculture_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169339
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_tbculture_passed on LAB_PTCQI_lab_pt_tbculture_passed.sourceid=ou.organisationunitid
  
      /*CD4*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169344
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_cd4_noparticipation on LAB_PTCQI_lab_pt_cd4_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169343
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_cd4_notpassed on LAB_PTCQI_lab_pt_cd4_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169342
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_cd4_passed on LAB_PTCQI_lab_pt_cd4_passed.sourceid=ou.organisationunitid
  
     /*Other*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169347
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_other_noparticipation on LAB_PTCQI_lab_pt_other_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169346
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_other_notpassed on LAB_PTCQI_lab_pt_other_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168810
  and categoryoptioncomboid=1169345
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_pt_other_passed on LAB_PTCQI_lab_pt_other_passed.sourceid=ou.organisationunitid

  /*Volume*/
/*HIV Testing*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168813
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_hivtest on LAB_PTCQI_lab_hivtest.sourceid=ou.organisationunitid

/*HIV IVT*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168814
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_hivivt on LAB_PTCQI_lab_hivivt.sourceid=ou.organisationunitid

/*HIV Viral Load*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168815
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_load on LAB_PTCQI_lab_load.sourceid=ou.organisationunitid

/*TB Xpert*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168816
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_tbxpert on LAB_PTCQI_lab_tbxpert.sourceid=ou.organisationunitid

/*TB AFB*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168817
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_tbafb on LAB_PTCQI_lab_tbafb.sourceid=ou.organisationunitid

/*TB Culture*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168818
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_tbculture on LAB_PTCQI_lab_tbculture.sourceid=ou.organisationunitid

/*CD4*/
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168819
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_cd4 on LAB_PTCQI_lab_cd4.sourceid=ou.organisationunitid

  /*Other*/
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168823
  and categoryoptioncomboid=1168820
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_lab_other on LAB_PTCQI_lab_other.sourceid=ou.organisationunitid
  
  /*LAB_PTCQI (POCT-based)*/
  /*CQI*/
 /*HIV Testing*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169353
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivtest_noparticipation on LAB_PTCQI_poct_cqi_hivtest_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169352
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivtest_notaudited on LAB_PTCQI_poct_cqi_hivtest_notaudited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169349
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivtest_01 on LAB_PTCQI_poct_cqi_hivtest_01.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169350
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivtest_23 on LAB_PTCQI_poct_cqi_hivtest_23.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169351
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivtest_45 on LAB_PTCQI_poct_cqi_hivtest_45.sourceid=ou.organisationunitid
  
   /*HIV IVT*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169358
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivivt_noparticipation on LAB_PTCQI_poct_cqi_hivivt_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169357
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivivt_notaudited on LAB_PTCQI_poct_cqi_hivivt_notaudited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169354
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivivt_01 on LAB_PTCQI_poct_cqi_hivivt_01.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169355
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivivt_23 on LAB_PTCQI_poct_cqi_hivivt_23.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169356
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_hivivt_45 on LAB_PTCQI_poct_cqi_hivivt_45.sourceid=ou.organisationunitid
  
  /*Viral Load*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169363
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_load_noparticipation on LAB_PTCQI_poct_cqi_load_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169362
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_load_notaudited on LAB_PTCQI_poct_cqi_load_notaudited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169359
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_load_01 on LAB_PTCQI_poct_cqi_load_01.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169360
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_load_23 on LAB_PTCQI_poct_cqi_load_23.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169361
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_load_45 on LAB_PTCQI_poct_cqi_load_45.sourceid=ou.organisationunitid
  
  /*TB Xpert*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169368
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbxpert_noparticipation on LAB_PTCQI_poct_cqi_tbxpert_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169367
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbxpert_notaudited on LAB_PTCQI_poct_cqi_tbxpert_notaudited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169364
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbxpert_01 on LAB_PTCQI_poct_cqi_tbxpert_01.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169365
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbxpert_23 on LAB_PTCQI_poct_cqi_tbxpert_23.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169366
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbxpert_45 on LAB_PTCQI_poct_cqi_tbxpert_45.sourceid=ou.organisationunitid
  
  /*TB AFB*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169373
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbafb_noparticipation on LAB_PTCQI_poct_cqi_tbafb_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169372
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbafb_notaudited on LAB_PTCQI_poct_cqi_tbafb_notaudited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169369
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbafb_01 on LAB_PTCQI_poct_cqi_tbafb_01.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169370
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbafb_23 on LAB_PTCQI_poct_cqi_tbafb_23.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169371
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_tbafb_45 on LAB_PTCQI_poct_cqi_tbafb_45.sourceid=ou.organisationunitid
  
  /*CD4*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169383
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_cd4_noparticipation on LAB_PTCQI_poct_cqi_cd4_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169382
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_cd4_notaudited on LAB_PTCQI_poct_cqi_cd4_notaudited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169379
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_cd4_01 on LAB_PTCQI_poct_cqi_cd4_01.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169380
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_cd4_23 on LAB_PTCQI_poct_cqi_cd4_23.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169381
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_cd4_45 on LAB_PTCQI_poct_cqi_cd4_45.sourceid=ou.organisationunitid
  
  /*Other*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169388
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_other_noparticipation on LAB_PTCQI_poct_cqi_other_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169387
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_other_notaudited on LAB_PTCQI_poct_cqi_other_notaudited.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169384
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_other_01 on LAB_PTCQI_poct_cqi_other_01.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169385
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_other_23 on LAB_PTCQI_poct_cqi_other_23.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168873
  and categoryoptioncomboid=1169386
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cqi_other_45 on LAB_PTCQI_poct_cqi_other_45.sourceid=ou.organisationunitid
  
  /*PT*/
 /*HIV Testing*/
    left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169326
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_hivtest_noparticipation on LAB_PTCQI_poct_pt_hivtest_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169325
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_hivtest_notpassed on LAB_PTCQI_poct_pt_hivtest_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169324
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_hivtest_passed on LAB_PTCQI_poct_pt_hivtest_passed.sourceid=ou.organisationunitid
  
  /*HIV IVT*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169329
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_hivivt_noparticipation on LAB_PTCQI_poct_pt_hivivt_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169328
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_hivivt_notpassed on LAB_PTCQI_poct_pt_hivivt_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169327
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_hivivt_passed on LAB_PTCQI_poct_pt_hivivt_passed.sourceid=ou.organisationunitid
  
  /*HIV Viral Load*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169332
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_load_noparticipation on LAB_PTCQI_poct_pt_load_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169331
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_load_notpassed on LAB_PTCQI_poct_pt_load_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169330
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_load_passed on LAB_PTCQI_poct_pt_load_passed.sourceid=ou.organisationunitid
  
    /*TB Xpert*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169335
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_tbxpert_noparticipation on LAB_PTCQI_poct_pt_tbxpert_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169334
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_tbxpert_notpassed on LAB_PTCQI_poct_pt_tbxpert_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169333
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_tbxpert_passed on LAB_PTCQI_poct_pt_tbxpert_passed.sourceid=ou.organisationunitid
  
  /*TB AFB*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169338
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_tbafb_noparticipation on LAB_PTCQI_poct_pt_tbafb_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169337
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_tbafb_notpassed on LAB_PTCQI_poct_pt_tbafb_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169336
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_tbafb_passed on LAB_PTCQI_poct_pt_tbafb_passed.sourceid=ou.organisationunitid

   /*CD4*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169344
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_cd4_noparticipation on LAB_PTCQI_poct_pt_cd4_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169343
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_cd4_notpassed on LAB_PTCQI_poct_pt_cd4_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169342
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_cd4_passed on LAB_PTCQI_poct_pt_cd4_passed.sourceid=ou.organisationunitid
  
     /*Other*/
      left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169347
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_other_noparticipation on LAB_PTCQI_poct_pt_other_noparticipation.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169346
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_other_notpassed on LAB_PTCQI_poct_pt_other_notpassed.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168890
  and categoryoptioncomboid=1169345
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_pt_other_passed on LAB_PTCQI_poct_pt_other_passed.sourceid=ou.organisationunitid
  
  /*Volume*/
/*HIV Testing*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168905
  and categoryoptioncomboid=1168813
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_hivtest on LAB_PTCQI_poct_hivtest.sourceid=ou.organisationunitid

/*HIV IVT*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168905
  and categoryoptioncomboid=1168814
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_hivivt on LAB_PTCQI_poct_hivivt.sourceid=ou.organisationunitid

/*HIV Viral Load*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168905
  and categoryoptioncomboid=1168815
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_load on LAB_PTCQI_poct_load.sourceid=ou.organisationunitid

/*TB Xpert*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168905
  and categoryoptioncomboid=1168816
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_tbxpert on LAB_PTCQI_poct_tbxpert.sourceid=ou.organisationunitid

/*TB AFB*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168905
  and categoryoptioncomboid=1168817
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_tbafb on LAB_PTCQI_poct_tbafb.sourceid=ou.organisationunitid

/*CD4*/
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168905
  and categoryoptioncomboid=1168819
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_cd4 on LAB_PTCQI_poct_cd4.sourceid=ou.organisationunitid

  /*Other*/
   left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1168905
  and categoryoptioncomboid=1168820
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as LAB_PTCQI_poct_other on LAB_PTCQI_poct_other.sourceid=ou.organisationunitid
  
  /*PMTCT_FO*/
  /*Denominator*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1203573
  and categoryoptioncomboid IN (1203650,1203651,1203652)
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as PMTCT_FO_den on PMTCT_FO_den.sourceid=ou.organisationunitid
  
  /*HIV-Infected*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1203594
  and categoryoptioncomboid IN (1203656,1203657,1203658)
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as PMTCT_FO_hivinfected on PMTCT_FO_hivinfected.sourceid=ou.organisationunitid
  
  /*HIV-uninfected*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1203594
  and categoryoptioncomboid IN (1203653,1203654,1203655)
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as PMTCT_FO_hivuninfected on PMTCT_FO_hivuninfected.sourceid=ou.organisationunitid
  
    /*HIV-final status unknown*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1203594
  and categoryoptioncomboid IN (1203659,1203660,1203661,1203662,1203663,1203664)
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as PMTCT_FO_hivfsu on PMTCT_FO_hivfsu.sourceid=ou.organisationunitid  
  
    /*Died without status known*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=1203594
  and categoryoptioncomboid IN (1203665,1203666,1203667)
  and periodid = (select ps.periodid from _periodstructure ps where iso=(SELECT financialoct from _periodstructure where periodid=599888))
  group by sourceid) as PMTCT_FO_died on PMTCT_FO_died.sourceid=ou.organisationunitid  
  
  
where ous.level=4 and ous.idlevel2=110 order by district.name || ' / ' || ou.name ASC;