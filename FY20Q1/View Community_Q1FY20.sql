select district.name as district,
'DSD' AS placeholder1,
/*Quarterly*/
/*HTS_TST_num*/
SUM(
/*Index Testing*/
(COALESCE(ats_index_men1_pos.value,0)+COALESCE(ats_index_0_8_f_pos.value,0)+COALESCE(ats_index_0_8_m_pos.value,0)) +
(COALESCE(ats_index_men1_neg.value,0)+COALESCE(ats_index_0_8_f_neg.value,0)+COALESCE(ats_index_0_8_m_neg.value,0)) +
(COALESCE(ats_index_1_9_pos.value,0)+COALESCE(ats_index_19_4_f_pos.value,0)+COALESCE(ats_index_19_4_m_pos.value,0)+COALESCE(ats_index_9_18_f_pos.value,0)+COALESCE(ats_index_9_18_m_pos.value,0))+
(COALESCE(ats_index_1_9_neg.value,0)+COALESCE(ats_index_19_4_f_neg.value,0)+COALESCE(ats_index_19_4_m_neg.value,0)+COALESCE(ats_index_9_18_f_neg.value,0)+COALESCE(ats_index_9_18_m_neg.value,0))+
COALESCE(ats_index_10_14_f_pos.value,0) +
COALESCE(ats_index_10_14_f_neg.value,0) +
COALESCE(ats_index_10_14_m_pos.value,0) +
COALESCE(ats_index_10_14_m_neg.value,0) +
COALESCE(ats_index_15_19_f_pos.value,0) +
COALESCE(ats_index_15_19_f_neg.value,0) +
COALESCE(ats_index_15_19_m_pos.value,0) +
COALESCE(ats_index_15_19_m_neg.value,0) +
COALESCE(ats_index_20_24_f_pos.value,0) +
COALESCE(ats_index_20_24_f_neg.value,0) +
COALESCE(ats_index_20_24_m_pos.value,0) +
COALESCE(ats_index_20_24_m_neg.value,0) +
(COALESCE(ats_index_25_49_f_pos.value,0)+COALESCE(ats_index_25_29_f_pos.value,0)+COALESCE(ats_index_30_49_f_pos.value,0)) +
(COALESCE(ats_index_25_49_f_neg.value,0)+COALESCE(ats_index_25_29_f_neg.value,0)+COALESCE(ats_index_30_49_f_neg.value,0)) +
(COALESCE(ats_index_25_49_m_pos.value,0)+COALESCE(ats_index_25_29_m_pos.value,0)+COALESCE(ats_index_30_49_m_pos.value,0)) +
(COALESCE(ats_index_25_49_m_neg.value,0)+COALESCE(ats_index_25_29_m_neg.value,0)+COALESCE(ats_index_30_49_m_neg.value,0)) +
COALESCE(ats_index_50_f_pos.value,0) +
COALESCE(ats_index_50_f_neg.value,0) +
COALESCE(ats_index_50_m_pos.value,0) +
COALESCE(ats_index_50_m_neg.value,0) +
/*Mobile Clinic*/
(COALESCE(ats_mobile_men1_pos.value,0)+COALESCE(ats_mobile_0_8_f_pos.value,0)+COALESCE(ats_mobile_0_8_m_pos.value,0)) +
(COALESCE(ats_mobile_men1_neg.value,0)+COALESCE(ats_mobile_0_8_f_neg.value,0)+COALESCE(ats_mobile_0_8_m_neg.value,0)) +
(COALESCE(ats_mobile_1_9_pos.value,0)+COALESCE(ats_mobile_19_4_f_pos.value,0)+COALESCE(ats_mobile_19_4_m_pos.value,0)+COALESCE(ats_mobile_9_18_f_pos.value,0)+COALESCE(ats_mobile_9_18_m_pos.value,0))+
(COALESCE(ats_mobile_1_9_neg.value,0)+COALESCE(ats_mobile_19_4_f_neg.value,0)+COALESCE(ats_mobile_19_4_m_neg.value,0)+COALESCE(ats_mobile_9_18_f_neg.value,0)+COALESCE(ats_mobile_9_18_m_neg.value,0))+
COALESCE(ats_mobile_10_14_f_pos.value,0) +
COALESCE(ats_mobile_10_14_f_neg.value,0) +
COALESCE(ats_mobile_10_14_m_pos.value,0) +
COALESCE(ats_mobile_10_14_m_neg.value,0) +
COALESCE(ats_mobile_15_19_f_pos.value,0) +
COALESCE(ats_mobile_15_19_f_neg.value,0) +
COALESCE(ats_mobile_15_19_m_pos.value,0) +
COALESCE(ats_mobile_15_19_m_neg.value,0) +
COALESCE(ats_mobile_20_24_f_pos.value,0) +
COALESCE(ats_mobile_20_24_f_neg.value,0) +
COALESCE(ats_mobile_20_24_m_pos.value,0) +
COALESCE(ats_mobile_20_24_m_neg.value,0) +
(COALESCE(ats_mobile_25_49_f_pos.value,0)+COALESCE(ats_mobile_25_29_f_pos.value,0)+COALESCE(ats_mobile_30_49_f_pos.value,0)) +
(COALESCE(ats_mobile_25_49_f_neg.value,0)+COALESCE(ats_mobile_25_29_f_neg.value,0)+COALESCE(ats_mobile_30_49_f_neg.value,0)) +
(COALESCE(ats_mobile_25_49_m_pos.value,0)+COALESCE(ats_mobile_25_29_m_pos.value,0)+COALESCE(ats_mobile_30_49_m_pos.value,0)) +
(COALESCE(ats_mobile_25_49_m_neg.value,0)+COALESCE(ats_mobile_25_29_m_neg.value,0)+COALESCE(ats_mobile_30_49_m_neg.value,0)) +
COALESCE(ats_mobile_50_f_pos.value,0) +
COALESCE(ats_mobile_50_f_neg.value,0) +
COALESCE(ats_mobile_50_m_pos.value,0) +
COALESCE(ats_mobile_50_m_neg.value,0) ) AS HTS_TST_num,
'' AS placeholder2,
'' AS placeholder3,
'' AS placeholder4,
'' AS placeholder5,
/*Index Testing*/
SUM(COALESCE(ats_index_men1_pos.value,0)+COALESCE(ats_index_0_8_f_pos.value,0)+COALESCE(ats_index_0_8_m_pos.value,0))  AS HTS_TST_Index_men1_pos,
SUM(COALESCE(ats_index_men1_neg.value,0)+COALESCE(ats_index_0_8_f_neg.value,0)+COALESCE(ats_index_0_8_m_neg.value,0))  AS HTS_TST_Index_men1_neg,
SUM(COALESCE(ats_index_1_9_pos.value,0)+COALESCE(ats_index_19_4_f_pos.value,0)+COALESCE(ats_index_19_4_m_pos.value,0)+COALESCE(ats_index_9_18_f_pos.value,0)+COALESCE(ats_index_9_18_m_pos.value,0))AS HTS_TST_Index_1_9_pos,
SUM(COALESCE(ats_index_1_9_neg.value,0)+COALESCE(ats_index_19_4_f_neg.value,0)+COALESCE(ats_index_19_4_m_neg.value,0)+COALESCE(ats_index_9_18_f_neg.value,0)+COALESCE(ats_index_9_18_m_neg.value,0))AS HTS_TST_Index_1_9_neg,
SUM(COALESCE(ats_index_10_14_f_pos.value,0)) AS HTS_TST_Index_10_14_f_pos,
SUM(COALESCE(ats_index_10_14_f_neg.value,0)) AS HTS_TST_Index_10_14_f_neg,
SUM(COALESCE(ats_index_10_14_m_pos.value,0)) AS HTS_TST_Index_10_14_m_pos,
SUM(COALESCE(ats_index_10_14_m_neg.value,0)) AS HTS_TST_Index_10_14_m_neg,
SUM(COALESCE(ats_index_15_19_f_pos.value,0)) AS HTS_TST_Index_15_19_f_pos,
SUM(COALESCE(ats_index_15_19_f_neg.value,0)) AS HTS_TST_Index_15_19_f_neg,
SUM(COALESCE(ats_index_15_19_m_pos.value,0)) AS HTS_TST_Index_15_19_m_pos,
SUM(COALESCE(ats_index_15_19_m_neg.value,0)) AS HTS_TST_Index_15_19_m_neg,
SUM(COALESCE(ats_index_20_24_f_pos.value,0)) AS HTS_TST_Index_20_24_f_pos,
SUM(COALESCE(ats_index_20_24_f_neg.value,0)) AS HTS_TST_Index_20_24_f_neg,
SUM(COALESCE(ats_index_20_24_m_pos.value,0)) AS HTS_TST_Index_20_24_m_pos,
SUM(COALESCE(ats_index_20_24_m_neg.value,0)) AS HTS_TST_Index_20_24_m_neg,
SUM(COALESCE(ats_index_25_49_f_pos.value,0)+COALESCE(ats_index_25_29_f_pos.value,0)+COALESCE(ats_index_30_49_f_pos.value,0)) AS HTS_TST_Index_25_49_f_pos,
SUM(COALESCE(ats_index_25_49_f_neg.value,0)+COALESCE(ats_index_25_29_f_neg.value,0)+COALESCE(ats_index_30_49_f_neg.value,0)) AS HTS_TST_Index_25_49_f_neg,
SUM(COALESCE(ats_index_25_49_m_pos.value,0)+COALESCE(ats_index_25_29_m_pos.value,0)+COALESCE(ats_index_30_49_m_pos.value,0)) AS HTS_TST_Index_25_49_m_pos,
SUM(COALESCE(ats_index_25_49_m_neg.value,0)+COALESCE(ats_index_25_29_m_neg.value,0)+COALESCE(ats_index_30_49_m_neg.value,0)) AS HTS_TST_Index_25_49_m_neg,
SUM(COALESCE(ats_index_50_f_pos.value,0)) AS HTS_TST_Index_50_f_pos,
SUM(COALESCE(ats_index_50_f_neg.value,0)) AS HTS_TST_Index_50_f_neg,
SUM(COALESCE(ats_index_50_m_pos.value,0)) AS HTS_TST_Index_50_m_pos,
SUM(COALESCE(ats_index_50_m_neg.value,0)) AS HTS_TST_Index_50_m_neg,
'' AS placeholder6,
'' AS placeholder7,
'' AS placeholder8,
'' AS placeholder9,
/*Mobile Clinic*/
SUM(COALESCE(ats_mobile_men1_pos.value,0)+COALESCE(ats_mobile_0_8_f_pos.value,0)+COALESCE(ats_mobile_0_8_m_pos.value,0))  AS HTS_TST_VCT_men1_pos,
SUM(COALESCE(ats_mobile_men1_neg.value,0)+COALESCE(ats_mobile_0_8_f_neg.value,0)+COALESCE(ats_mobile_0_8_m_neg.value,0))  AS HTS_TST_VCT_men1_neg,
SUM(COALESCE(ats_mobile_1_9_pos.value,0)+COALESCE(ats_mobile_19_4_f_pos.value,0)+COALESCE(ats_mobile_19_4_m_pos.value,0)+COALESCE(ats_mobile_9_18_f_pos.value,0)+COALESCE(ats_mobile_9_18_m_pos.value,0))AS HTS_TST_VCT_1_9_pos,
SUM(COALESCE(ats_mobile_1_9_neg.value,0)+COALESCE(ats_mobile_19_4_f_neg.value,0)+COALESCE(ats_mobile_19_4_m_neg.value,0)+COALESCE(ats_mobile_9_18_f_neg.value,0)+COALESCE(ats_mobile_9_18_m_neg.value,0))AS HTS_TST_VCT_1_9_neg,
SUM(COALESCE(ats_mobile_10_14_f_pos.value,0)) AS HTS_TST_VCT_10_14_f_pos,
SUM(COALESCE(ats_mobile_10_14_f_neg.value,0)) AS HTS_TST_VCT_10_14_f_neg,
SUM(COALESCE(ats_mobile_10_14_m_pos.value,0)) AS HTS_TST_VCT_10_14_m_pos,
SUM(COALESCE(ats_mobile_10_14_m_neg.value,0)) AS HTS_TST_VCT_10_14_m_neg,
SUM(COALESCE(ats_mobile_15_19_f_pos.value,0)) AS HTS_TST_VCT_15_19_f_pos,
SUM(COALESCE(ats_mobile_15_19_f_neg.value,0)) AS HTS_TST_VCT_15_19_f_neg,
SUM(COALESCE(ats_mobile_15_19_m_pos.value,0)) AS HTS_TST_VCT_15_19_m_pos,
SUM(COALESCE(ats_mobile_15_19_m_neg.value,0)) AS HTS_TST_VCT_15_19_m_neg,
SUM(COALESCE(ats_mobile_20_24_f_pos.value,0)) AS HTS_TST_VCT_20_24_f_pos,
SUM(COALESCE(ats_mobile_20_24_f_neg.value,0)) AS HTS_TST_VCT_20_24_f_neg,
SUM(COALESCE(ats_mobile_20_24_m_pos.value,0)) AS HTS_TST_VCT_20_24_m_pos,
SUM(COALESCE(ats_mobile_20_24_m_neg.value,0)) AS HTS_TST_VCT_20_24_m_neg,
SUM(COALESCE(ats_mobile_25_49_f_pos.value,0)+COALESCE(ats_mobile_25_29_f_pos.value,0)+COALESCE(ats_mobile_30_49_f_pos.value,0)) AS HTS_TST_VCT_25_49_f_pos,
SUM(COALESCE(ats_mobile_25_49_f_neg.value,0)+COALESCE(ats_mobile_25_29_f_neg.value,0)+COALESCE(ats_mobile_30_49_f_neg.value,0)) AS HTS_TST_VCT_25_49_f_neg,
SUM(COALESCE(ats_mobile_25_49_m_pos.value,0)+COALESCE(ats_mobile_25_29_m_pos.value,0)+COALESCE(ats_mobile_30_49_m_pos.value,0)) AS HTS_TST_VCT_25_49_m_pos,
SUM(COALESCE(ats_mobile_25_49_m_neg.value,0)+COALESCE(ats_mobile_25_29_m_neg.value,0)+COALESCE(ats_mobile_30_49_m_neg.value,0)) AS HTS_TST_VCT_25_49_m_neg,
SUM(COALESCE(ats_mobile_50_f_pos.value,0)) AS HTS_TST_VCT_50_f_pos,
SUM(COALESCE(ats_mobile_50_f_neg.value,0)) AS HTS_TST_VCT_50_f_neg,
SUM(COALESCE(ats_mobile_50_m_pos.value,0)) AS HTS_TST_VCT_50_m_pos,
SUM(COALESCE(ats_mobile_50_m_neg.value,0)) AS HTS_TST_VCT_50_m_neg


from organisationunit ou
left outer join _orgunitstructure ous
  on (ou.organisationunitid=ous.organisationunitid)
left outer join organisationunit province
  on (ous.idlevel2=province.organisationunitid)
left outer join organisationunit district
  on (ous.idlevel3=district.organisationunitid)

  /*Quarterly*/
  
  /*Index Testing*/
  /*VCT*/
   /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21837,21861)
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_men1_pos on ats_index_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21838,21862)
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_men1_neg on ats_index_men1_neg.sourceid=ou.organisationunitid

  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565851
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_f_pos on ats_index_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565852
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_f_neg on ats_index_0_8_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565842
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_m_pos on ats_index_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565843
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_0_8_m_neg on ats_index_0_8_m_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565854
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_f_pos on ats_index_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565855
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_f_neg on ats_index_9_18_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565845
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_m_pos on ats_index_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565846
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_9_18_m_neg on ats_index_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565857
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_f_pos on ats_index_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565858
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_f_neg on ats_index_19_4_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565848
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_m_pos on ats_index_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565849
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_19_4_m_neg on ats_index_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21840,21843,21864,21867)
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_1_9_pos on ats_index_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21841,21844,21865,21868)
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_1_9_neg on ats_index_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21870
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_f_pos on ats_index_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21871
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_f_neg on ats_index_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21846
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_m_pos on ats_index_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21847
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_10_14_m_neg on ats_index_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21873
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_f_pos on ats_index_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21874
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_f_neg on ats_index_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21849
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_m_pos on ats_index_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21850
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_15_19_m_neg on ats_index_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21876
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_f_pos on ats_index_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21877
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_f_neg on ats_index_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21852
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_m_pos on ats_index_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21853
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_20_24_m_neg on ats_index_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21879
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_f_pos on ats_index_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21880
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_f_neg on ats_index_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21855
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_m_pos on ats_index_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21856
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_49_m_neg on ats_index_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561792
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_f_pos on ats_index_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561793
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_f_neg on ats_index_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561780
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_m_pos on ats_index_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561781
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_25_29_m_neg on ats_index_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565693
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_f_pos on ats_index_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565694
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_f_neg on ats_index_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565690
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_m_pos on ats_index_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565691
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_30_49_m_neg on ats_index_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21882
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_f_pos on ats_index_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21883
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_f_neg on ats_index_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21858
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_m_pos on ats_index_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21859
  and attributeoptioncomboid=132044 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_index_50_m_neg on ats_index_50_m_neg.sourceid=ou.organisationunitid
   
  /*Mobile Clinic*/
   /*<1*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21837,21861)
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_men1_pos on ats_mobile_men1_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21838,21862)
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_men1_neg on ats_mobile_men1_neg.sourceid=ou.organisationunitid

  /*0-8m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565851
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_0_8_f_pos on ats_mobile_0_8_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565852
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_0_8_f_neg on ats_mobile_0_8_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565842
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_0_8_m_pos on ats_mobile_0_8_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565843
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_0_8_m_neg on ats_mobile_0_8_m_neg.sourceid=ou.organisationunitid
  
  /*9-18m*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565854
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_9_18_f_pos on ats_mobile_9_18_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565855
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_9_18_f_neg on ats_mobile_9_18_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565845
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_9_18_m_pos on ats_mobile_9_18_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565846
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_9_18_m_neg on ats_mobile_9_18_m_neg.sourceid=ou.organisationunitid
  
  /*19-4a*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565857
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_19_4_f_pos on ats_mobile_19_4_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565858
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_19_4_f_neg on ats_mobile_19_4_f_neg.sourceid=ou.organisationunitid
  
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565848
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_19_4_m_pos on ats_mobile_19_4_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565849
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_19_4_m_neg on ats_mobile_19_4_m_neg.sourceid=ou.organisationunitid
  
  /*1-9*/
 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21840,21843,21864,21867)
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_1_9_pos on ats_mobile_1_9_pos.sourceid=ou.organisationunitid

 left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid IN (21841,21844,21865,21868)
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_1_9_neg on ats_mobile_1_9_neg.sourceid=ou.organisationunitid

/*10-14*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21870
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_10_14_f_pos on ats_mobile_10_14_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21871
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_10_14_f_neg on ats_mobile_10_14_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21846
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_10_14_m_pos on ats_mobile_10_14_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21847
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_10_14_m_neg on ats_mobile_10_14_m_neg.sourceid=ou.organisationunitid

  /*15-19*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21873
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_15_19_f_pos on ats_mobile_15_19_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21874
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_15_19_f_neg on ats_mobile_15_19_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21849
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_15_19_m_pos on ats_mobile_15_19_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21850
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_15_19_m_neg on ats_mobile_15_19_m_neg.sourceid=ou.organisationunitid

  /*20-24*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21876
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_20_24_f_pos on ats_mobile_20_24_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21877
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_20_24_f_neg on ats_mobile_20_24_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21852
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_20_24_m_pos on ats_mobile_20_24_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21853
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_20_24_m_neg on ats_mobile_20_24_m_neg.sourceid=ou.organisationunitid

  /*25-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21879
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_49_f_pos on ats_mobile_25_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21880
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_49_f_neg on ats_mobile_25_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21855
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_49_m_pos on ats_mobile_25_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21856
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_49_m_neg on ats_mobile_25_49_m_neg.sourceid=ou.organisationunitid

  /*25-29*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561792
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_29_f_pos on ats_mobile_25_29_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561793
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_29_f_neg on ats_mobile_25_29_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561780
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_29_m_pos on ats_mobile_25_29_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=561781
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_25_29_m_neg on ats_mobile_25_29_m_neg.sourceid=ou.organisationunitid
  
  /*30-49*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565693
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_30_49_f_pos on ats_mobile_30_49_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565694
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_30_49_f_neg on ats_mobile_30_49_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565690
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_30_49_m_pos on ats_mobile_30_49_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=565691
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_30_49_m_neg on ats_mobile_30_49_m_neg.sourceid=ou.organisationunitid
  
  /*50+*/
  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21882
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_50_f_pos on ats_mobile_50_f_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21883
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_50_f_neg on ats_mobile_50_f_neg.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21858
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_50_m_pos on ats_mobile_50_m_pos.sourceid=ou.organisationunitid

  left outer join (
  select sourceid, sum(cast(value as double precision)) as value
  from datavalue
  where dataelementid=43327
  and categoryoptioncomboid=21859
  and attributeoptioncomboid=132045 and periodid IN (select distinct(ps.periodid) from _periodstructure ps, period p where quarterly=(SELECT quarterly from _periodstructure where periodid=1582247) and ps.periodid=p.periodid and p.periodtypeid=3)
  group by sourceid) as ats_mobile_50_m_neg on ats_mobile_50_m_neg.sourceid=ou.organisationunitid
  
  
 
where ous.level=4 and case 2 when 4 then ous.idlevel3=(select distinct(ous_p.idlevel3) from _orgunitstructure ous_p where ous_p.idlevel4=110) else ous.idlevel2=110 end group by district.name order by district.name ASC;