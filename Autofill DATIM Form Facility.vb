' Copyright (C) 2017-2018, Friends in Global Health, LLC
' All rights reserved.

' This code allows a DATIM end user to automatically fill out the
' MER Results: Facility Based form for a specific quarterly period and
' Organizational Units. This code works in a specific MS Excel file

'--------------------------------------------------------------------
'                             INSTRUCTIONS
'--------------------------------------------------------------------

' Before run this Macro make sure to login in DATIM with Data Entry
' previleges, this approach only works with the Internet Explorer browser

Public IE As Object
Public ouList As String

'Main function that should be called by the button on Excel file
Sub MainMacro()

'Protection of macros execution
    Dim Ans As Boolean
    Const Pword As Variant = "fghdatim"
    Ans = False
        If Not InputBox("Por favor, introduza o password, e certifique que ja fez Login na plataforma DATIM utilizando o internet explorer, deve ser um utilizador com previlegio de Entrada de Dados.", "Entrar Password") = Pword Then
            Ans = True
        If MsgBox("Sem a password não pode efectuar esta operação. Por favor! Para mais informações contacte o Departamento de Informação Estratégica da FGH.", vbOKOnly, "Informação") = vbOK Then Exit Sub
        End If
'End of Protection for macros execution

'------------------------------------------
'       PROGRESS BAR INITIALIZATION
'------------------------------------------
Dim lastRow As Long
Dim toComplete As Single
Dim startTime As Date
Dim endTime As Date
Dim fillDuration As Date
'FormProgressBar is Mandatory to use this code
FormProgressBar.LabelProgress.Width = 0
FormProgressBar.CheckBox1.Caption = "Hora inicial: " & Now
startTime = Now
FormProgressBar.LabelCaption = "Preparando para digitar dados..."
FormProgressBar.LabelUserInfo = "Utilizador do Sistema Operacional: " & Environ("Username")
FormProgressBar.LabelUserAgentInfo = "Agente do Utilizador: " & Environ("COMPUTERNAME") & ", " & Environ("OS") & ", " & Environ("PROCESSOR_ARCHITECTURE") & ", " & Environ("NUMBER_OF_PROCESSORS") & " CPU"
FormProgressBar.Show
'COUNT total OUs
Set myRange = Worksheets("sheet1").Range("A10:A300")
lastRow = Application.WorksheetFunction.CountA(myRange)

Set IE = CreateObject("InternetExplorer.Application")

'DATIM Data Entry URL
IE.Navigate "https://www.datim.org/dhis-web-dataentry/index.action"
IE.Visible = True

While IE.busy
DoEvents 'wait until IE is done loading page
Wend

'15 seconds to ensure that the page loads all HTML/CSS/JS components
Application.Wait Now + TimeValue("00:00:15")

'Element that allows Org Unit selection
IE.Document.all.Item

Dim i As Integer
i = 1

'Possible to run over 1000 Health Facilities, change if overflow
Do While i < 1000

If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("A10")) Then
'End process if find line with blank Org Unit
i = i + 1000

Else

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("ZK10")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ZK10")) Then
'Delete row 10 if there is no identification of DATIM Org Unit
ThisWorkbook.Sheets("sheet1").Rows(10).EntireRow.Delete

Else

    'ProgressBar lifetime update
    ouList = ouList & ThisWorkbook.Sheets("sheet1").Range("A10") & " (" & ThisWorkbook.Sheets("sheet1").Range("B10") & ")" & "<br>"
    toComplete = i / lastRow
    With FormProgressBar
        .LabelCaption.Caption = "Digitando Unidade Organizacional nº " & i & " de " & lastRow
        .LabelOUInfo.Caption = "A digitar: " & ThisWorkbook.Sheets("sheet1").Range("A10") & " (" & ThisWorkbook.Sheets("sheet1").Range("B10") & ")"
        .LabelProgress.Width = toComplete * (.FrameProgress.Width)
    End With

    'Call DHIS2 javascript function to select Org Unit on tree
    Call IE.Document.parentWindow.execScript("javascript:void selection.select( '" & ThisWorkbook.Sheets("sheet1").Range("ZK10") & "' )", "JavaScript")
    Application.Wait Now + TimeValue("00:00:05")
    
    'Select the Dataset and Period only at 1st time
    If i = 1 Then
    Set evt = IE.Document.createEvent("HTMLEvents")
    evt.initEvent "change", True, False
    'Select Dataset
    IE.Document.GetElementByID("selectedDataSetId").Value = "tz1bQ3ZwUKJ"
    IE.Document.GetElementByID("selectedDataSetId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:07")
    'Select the Period
    IE.Document.GetElementByID("selectedPeriodId").Value = "2018Q3"
    IE.Document.GetElementByID("selectedPeriodId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:10")
    End If

    'Show TAB to End User DSD or TA-SDI
    Call TAB_selection
    Application.Wait Now + TimeValue("00:00:02")

    '--------------------------------------------------------------------
    '                        CALL WRITE FUNCTIONS
    '--------------------------------------------------------------------
    'Control here the Data that have to writed on DATIM Form
    'Quarterly
    Call PrEP_write
    Call HTS_TST_Numerator_write
    Call PICT_Inpatient_write
    Call PICT_Pediatric_write
    Call PICT_TB_Clinic_write
    Call PICT_PMTCT_ANC_write
    Call PICT_Emergency_write
    Call PICT_Other_write
    Call VCT_write
    Call Index_Testing_write
    Call PMTCT_STAT_write
    Call PMTCT_EID_HEI_POS_write
    Call TX_NEW_TX_CURR_write
    Call PMTCT_ART_write
    
    'Semiannually
    Call TB_PREV_write
    Call TB_STAT_write
    Call TB_ART_write
    Call TX_TB_write
    
    'Annually
    Call GEND_GBV_write
    Call FPINT_SITE_write
    Call TX_RET_write
    Call TX_PVLS_write
    Call HRH_write
    Call LAB_PTCQI_write

    '--------------------------------------------------------------------
    '                       CALL PERSIST FUNCTIONS
    '--------------------------------------------------------------------
    'Control here the Data that have to persisted on DATIM Form
    Application.Wait Now + TimeValue("00:00:05") 
    'Quarterly
    Call PrEP_persist
    Call HTS_TST_Numerator_persist
    Call PICT_Inpatient_persist
    Call PICT_Pediatric_persist
    Call PICT_TB_Clinic_persist
    Call PICT_PMTCT_ANC_persist
    Call PICT_Emergency_persist
    Call PICT_Other_persist
    Call VCT_persist
    Call Index_Testing_persist
    Call PMTCT_STAT_persist
    Call PMTCT_EID_HEI_POS_persist
    Call TX_NEW_TX_CURR_persist
    Call PMTCT_ART_persist
    
    'Semiannually
    Call TB_PREV_persist
    Call TB_STAT_persist
    Call TB_ART_persist
    Call TX_TB_persist
    
    'Annually
    Call GEND_GBV_persist
    Call FPINT_SITE_persist
    Call TX_RET_persist
    Call TX_PVLS_persist
    Call HRH_persist
    Call LAB_PTCQI_persist

    Application.Wait Now + TimeValue("00:00:15")  
    ThisWorkbook.Sheets("sheet1").Rows(10).EntireRow.Delete
    Application.Wait Now + TimeValue("00:00:05") 

End If
    
i = i + 1

End If
Loop

'Calculate the total duration time
endTime = Now
fillDuration = endTime - startTime
FormProgressBar.CheckBox2.Value = True
FormProgressBar.CheckBox2.Caption = "Hora final: " & Now & ", Duração: " & Format(fillDuration, "hh") & ":" & Format(fillDuration, "nn:ss")

'Send E-mail notification
Call SendEmailNotification

End Sub

'Function to show the TAB selection DSD or TA-SDI
Sub TAB_selection
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-7").Click
Else
IE.Document.GetElementByID("ui-id-8").Click
End If
End Sub

'--------------------------------------------------------------------
'                        WRITE FUNCTIONS
'--------------------------------------------------------------------
'PrEP_NEW
Sub PrEP_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("C10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WQqBCWI0gND-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("C10")
Else
IE.Document.GetElementByID("bz61aPNTomM-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("C10")
End If
'Female, 15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-rsDhJVueMlj-val").Value = ThisWorkbook.Sheets("sheet1").Range("D10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-rsDhJVueMlj-val").Value = ThisWorkbook.Sheets("sheet1").Range("D10")
End If
'Female, 20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-Eb1wUeyQfm1-val").Value = ThisWorkbook.Sheets("sheet1").Range("E10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-Eb1wUeyQfm1-val").Value = ThisWorkbook.Sheets("sheet1").Range("E10")
End If
'Female, 25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-SOyl1KfM62E-val").Value = ThisWorkbook.Sheets("sheet1").Range("F10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-SOyl1KfM62E-val").Value = ThisWorkbook.Sheets("sheet1").Range("F10")
End If
'Female, 30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-WJs7WStaKb7-val").Value = ThisWorkbook.Sheets("sheet1").Range("G10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-WJs7WStaKb7-val").Value = ThisWorkbook.Sheets("sheet1").Range("G10")
End If
'Female, 35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-D6I9GaYrrcy-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-D6I9GaYrrcy-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
End If
'Female, 40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-ngxcu4ikzmm-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-ngxcu4ikzmm-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
End If
'Female, 50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-kWUjVlYNfMC-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-kWUjVlYNfMC-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
End If
'Male, 15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-ijirRiCapCK-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-ijirRiCapCK-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
End If
'Male, 20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-twp0pnjjBhU-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-twp0pnjjBhU-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
End If
'Male, 25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-w3Ke7t08Ca6-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-w3Ke7t08Ca6-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
End If
'Male, 30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-dPRznpKPI5f-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-dPRznpKPI5f-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
End If
'Male, 35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-UlVb0KF88sP-val").Value = ThisWorkbook.Sheets("sheet1").Range("O10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-UlVb0KF88sP-val").Value = ThisWorkbook.Sheets("sheet1").Range("O10")
End If
'Male, 40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-lwaRLYm2Yc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("P10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-lwaRLYm2Yc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("P10")
End If
'Male, 50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-mpyFgAd2eTH-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
Else
IE.Document.GetElementByID("b6OI9qB0Who-mpyFgAd2eTH-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
End If
End If
End Sub

'HTS_TST (Facility)
Sub HTS_TST_Numerator_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("R10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K6f6jR0NOcZ-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
Else
IE.Document.GetElementByID("FJSew4Ks0j3-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
End If
End If
End Sub

'PITC Modality: Inpatient Services
Sub PICT_Inpatient_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("W10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AF10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AF10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AG10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AG10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AH10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AH10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AI10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AI10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
End If
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
End If
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
End If
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
End If
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
Else
IE.Document.GetElementByID("qZAq6ABJe2I-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
End If
End If
End Sub

'PITC Modality: Pediatric Services
Sub PICT_Pediatric_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AU10")) Then
'Positive,<5
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("SpjvCpxnc20-tfxXAPNxtUc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
Else
IE.Document.GetElementByID("TUJPxclPx31-tfxXAPNxtUc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
End If
'Negative,<5
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("SpjvCpxnc20-QV7inC4TQdR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
Else
IE.Document.GetElementByID("TUJPxclPx31-QV7inC4TQdR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
End If
End If
End Sub

'PITC Modality: TB Clinics
Sub PICT_TB_Clinic_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("BA10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("BH10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("BH10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BI10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BI10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("BJ10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("BJ10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("BK10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("BK10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("BL10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("BL10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("BM10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("BM10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("BN10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("BN10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("BO10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("BO10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BP10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BP10")
End If
'25-29,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-qF9q6ImcE4Q-val").Value = ThisWorkbook.Sheets("sheet1").Range("BQ10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-qF9q6ImcE4Q-val").Value = ThisWorkbook.Sheets("sheet1").Range("BQ10")
End If
'25-29,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-LIuHxfndMvN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BR10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-LIuHxfndMvN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BR10")
End If
'25-29,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-zJAFlhIuWgH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BS10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-zJAFlhIuWgH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BS10")
End If
'25-29,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-DX5hOcGmzO4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BT10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-DX5hOcGmzO4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BT10")
End If
'30-34,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-nm4ngD1r1hU-val").Value = ThisWorkbook.Sheets("sheet1").Range("BU10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-nm4ngD1r1hU-val").Value = ThisWorkbook.Sheets("sheet1").Range("BU10")
End If
'30-34,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-g4X5YaSBkbt-val").Value = ThisWorkbook.Sheets("sheet1").Range("BV10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-g4X5YaSBkbt-val").Value = ThisWorkbook.Sheets("sheet1").Range("BV10")
End If
'30-34,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-SYFxsQKDZB6-val").Value = ThisWorkbook.Sheets("sheet1").Range("BW10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-SYFxsQKDZB6-val").Value = ThisWorkbook.Sheets("sheet1").Range("BW10")
End If
'30-34,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-X6qWVyu9XoN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BX10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-X6qWVyu9XoN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BX10")
End If
'35-39,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-XpcFo6dVPT4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BY10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-XpcFo6dVPT4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BY10")
End If
'35-39,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-xrbKLtiVPLr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BZ10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-xrbKLtiVPLr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BZ10")
End If
'35-39,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-K5N6EXwJKhq-val").Value = ThisWorkbook.Sheets("sheet1").Range("CA10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-K5N6EXwJKhq-val").Value = ThisWorkbook.Sheets("sheet1").Range("CA10")
End If
'35-39,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-V6sMmLkODqf-val").Value = ThisWorkbook.Sheets("sheet1").Range("CB10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-V6sMmLkODqf-val").Value = ThisWorkbook.Sheets("sheet1").Range("CB10")
End If
'40-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-RHmkwEYAkor-val").Value = ThisWorkbook.Sheets("sheet1").Range("CC10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-RHmkwEYAkor-val").Value = ThisWorkbook.Sheets("sheet1").Range("CC10")
End If
'40-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-SdpT6lSiyCM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CD10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-SdpT6lSiyCM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CD10")
End If
'40-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-j98NBCtzxly-val").Value = ThisWorkbook.Sheets("sheet1").Range("CE10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-j98NBCtzxly-val").Value = ThisWorkbook.Sheets("sheet1").Range("CE10")
End If
'40-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-HBu2SwE1QoF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CF10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-HBu2SwE1QoF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CF10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("CG10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("CG10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("CH10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("CH10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("CI10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("CI10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("CJ10")
Else
IE.Document.GetElementByID("KeklNQcVqTQ-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("CJ10")
End If
End If
'End PITC Modality: TB Clinics
End Sub

'PITC Modality: PMTCT (ANC Only) Clinics
Sub PICT_PMTCT_ANC_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("CQ10")) Then
'10-14,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-yLBZURYX4dM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CQ10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-yLBZURYX4dM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CQ10")
End If
'10-14,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-V3oXrjInRC5-val").Value = ThisWorkbook.Sheets("sheet1").Range("CR10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-V3oXrjInRC5-val").Value = ThisWorkbook.Sheets("sheet1").Range("CR10")
End If
'15-19,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-Nh2FihNXvdJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CS10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-Nh2FihNXvdJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CS10")
End If
'15-19,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-swdumJN00xH-val").Value = ThisWorkbook.Sheets("sheet1").Range("CT10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-swdumJN00xH-val").Value = ThisWorkbook.Sheets("sheet1").Range("CT10")
End If
'20-24,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-qSEFOXyVh36-val").Value = ThisWorkbook.Sheets("sheet1").Range("CU10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-qSEFOXyVh36-val").Value = ThisWorkbook.Sheets("sheet1").Range("CU10")
End If
'20-24,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-LUGZN0xJK8O-val").Value = ThisWorkbook.Sheets("sheet1").Range("CV10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-LUGZN0xJK8O-val").Value = ThisWorkbook.Sheets("sheet1").Range("CV10")
End If
'25-49,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-liB7pxJtaLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("CW10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-liB7pxJtaLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("CW10")
End If
'25-49,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-hxYS9p5OORs-val").Value = ThisWorkbook.Sheets("sheet1").Range("CX10")
Else
IE.Document.GetElementByID("RT8zvKCJaXC-hxYS9p5OORs-val").Value = ThisWorkbook.Sheets("sheet1").Range("CX10")
End If
End If
End Sub

'PITC Modality: Emergency Ward
Sub PICT_Emergency_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("DE10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("DE10")
Else
IE.Document.GetElementByID("viytbgNBMks-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("DE10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DF10")
Else
IE.Document.GetElementByID("viytbgNBMks-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DF10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DG10")
Else
IE.Document.GetElementByID("viytbgNBMks-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DG10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DH10")
Else
IE.Document.GetElementByID("viytbgNBMks-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DH10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("DI10")
Else
IE.Document.GetElementByID("viytbgNBMks-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("DI10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("DJ10")
Else
IE.Document.GetElementByID("viytbgNBMks-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("DJ10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("DK10")
Else
IE.Document.GetElementByID("viytbgNBMks-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("DK10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DL10")
Else
IE.Document.GetElementByID("viytbgNBMks-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DL10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DM10")
Else
IE.Document.GetElementByID("viytbgNBMks-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DM10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("DN10")
Else
IE.Document.GetElementByID("viytbgNBMks-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("DN10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("DO10")
Else
IE.Document.GetElementByID("viytbgNBMks-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("DO10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("DP10")
Else
IE.Document.GetElementByID("viytbgNBMks-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("DP10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("DQ10")
Else
IE.Document.GetElementByID("viytbgNBMks-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("DQ10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("DR10")
Else
IE.Document.GetElementByID("viytbgNBMks-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("DR10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("DS10")
Else
IE.Document.GetElementByID("viytbgNBMks-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("DS10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DT10")
Else
IE.Document.GetElementByID("viytbgNBMks-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DT10")
End If
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DU10")
Else
IE.Document.GetElementByID("viytbgNBMks-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DU10")
End If
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("DV10")
Else
IE.Document.GetElementByID("viytbgNBMks-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("DV10")
End If
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DW10")
Else
IE.Document.GetElementByID("viytbgNBMks-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DW10")
End If
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("DX10")
Else
IE.Document.GetElementByID("viytbgNBMks-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("DX10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("DY10")
Else
IE.Document.GetElementByID("viytbgNBMks-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("DY10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("DZ10")
Else
IE.Document.GetElementByID("viytbgNBMks-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("DZ10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("EA10")
Else
IE.Document.GetElementByID("viytbgNBMks-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("EA10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("EB10")
Else
IE.Document.GetElementByID("viytbgNBMks-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("EB10")
End If
End If
End Sub

'PITC Modality: Other PICT
Sub PICT_Other_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("EE10")) Then
'Unknown,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-EpuxXtY71JG-val").Value = ThisWorkbook.Sheets("sheet1").Range("EE10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-EpuxXtY71JG-val").Value = ThisWorkbook.Sheets("sheet1").Range("EE10")
End If
'Unknown,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-YcXbNpQVqTA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EF10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-YcXbNpQVqTA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EF10")
End If
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("EG10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("EG10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EH10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EH10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EI10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EI10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EJ10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EJ10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("EK10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("EK10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("EL10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("EL10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("EM10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("EM10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("EN10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("EN10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EO10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EO10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("EP10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("EP10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("EQ10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("EQ10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ER10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ER10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("ES10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("ES10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ET10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ET10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("EU10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("EU10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EV10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EV10")
End If
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EW10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EW10")
End If
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("EX10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("EX10")
End If
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EY10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EY10")
End If
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("EZ10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("EZ10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("FA10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("FA10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("FB10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("FB10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("FC10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("FC10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("FD10")
Else
IE.Document.GetElementByID("jHjC9XIJbhL-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("FD10")
End If
End If
End Sub

'VCT
Sub VCT_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("FI10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("FI10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("FI10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FJ10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FJ10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FK10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FK10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FL10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FL10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("FM10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("FM10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("FN10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("FN10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("FO10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("FO10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("FP10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("FP10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FQ10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FQ10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("FR10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("FR10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("FS10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("FS10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("FT10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("FT10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("FU10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("FU10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("FV10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("FV10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("FW10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("FW10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FX10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FX10")
End If
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("FY10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("FY10")
End If
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("FZ10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("FZ10")
End If
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("GA10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("GA10")
End If
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("GB10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("GB10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("GD10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("GD10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("GE10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("GE10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("GF10")
Else
IE.Document.GetElementByID("YBdu7j2gGjC-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("GF10")
End If
End If
End Sub

'Index Testing
Sub Index_Testing_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("GK10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("GK10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("GK10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GL10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GL10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GM10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GM10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GN10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GN10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("GO10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("GO10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("GP10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("GP10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("GQ10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("GQ10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("GR10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("GR10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GS10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GS10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("GT10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("GT10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("GU10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("GU10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("GV10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("GV10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("GW10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("GW10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("GX10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("GX10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("GY10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("GY10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GZ10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GZ10")
End If
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HA10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HA10")
End If
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("HB10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("HB10")
End If
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HC10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HC10")
End If
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("HD10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("HD10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("HE10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("HE10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("HF10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("HF10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HG10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HG10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("HH10")
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("HH10")
End If
End If
End Sub

'PMTCT_STAT
Sub PMTCT_STAT_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("HI10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("DsC5f5aN6Ef-Jwb1SWomgpk-val").Value = ThisWorkbook.Sheets("sheet1").Range("HI10")
Else
IE.Document.GetElementByID("EQiyFRSNeK2-Jwb1SWomgpk-val").Value = ThisWorkbook.Sheets("sheet1").Range("HI10")
End If
'10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("HL10")
Else
IE.Document.GetElementByID("A6sEZh4ctKy-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("HL10")
End If
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("HM10")
Else
IE.Document.GetElementByID("A6sEZh4ctKy-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("HM10")
End If
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HN10")
Else
IE.Document.GetElementByID("A6sEZh4ctKy-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HN10")
End If
'25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("HO10")
Else
IE.Document.GetElementByID("A6sEZh4ctKy-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("HO10")
End If
'Known+,Newly+,Newly-
'10-14,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-FATw338XdmD-val").Value = ThisWorkbook.Sheets("sheet1").Range("HW10")
Else
IE.Document.GetElementByID("bII4eG3osk5-FATw338XdmD-val").Value = ThisWorkbook.Sheets("sheet1").Range("HW10")
End If
'10-14,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-PpWt03yRclQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HX10")
Else
IE.Document.GetElementByID("bII4eG3osk5-PpWt03yRclQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HX10")
End If
'10-14,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-Wjm2Jejaqh2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HY10")
Else
IE.Document.GetElementByID("bII4eG3osk5-Wjm2Jejaqh2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HY10")
End If
'15-19,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-CQz1usv1yjJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HZ10")
Else
IE.Document.GetElementByID("bII4eG3osk5-CQz1usv1yjJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HZ10")
End If
'15-19,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-bGJGYyYer7f-val").Value = ThisWorkbook.Sheets("sheet1").Range("IA10")
Else
IE.Document.GetElementByID("bII4eG3osk5-bGJGYyYer7f-val").Value = ThisWorkbook.Sheets("sheet1").Range("IA10")
End If
'15-19,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-Cn4g5a16slF-val").Value = ThisWorkbook.Sheets("sheet1").Range("IB10")
Else
IE.Document.GetElementByID("bII4eG3osk5-Cn4g5a16slF-val").Value = ThisWorkbook.Sheets("sheet1").Range("IB10")
End If
'20-24,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-aluqwhKuVku-val").Value = ThisWorkbook.Sheets("sheet1").Range("IC10")
Else
IE.Document.GetElementByID("bII4eG3osk5-aluqwhKuVku-val").Value = ThisWorkbook.Sheets("sheet1").Range("IC10")
End If
'20-24,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-Dvi71PYwhYc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
Else
IE.Document.GetElementByID("bII4eG3osk5-Dvi71PYwhYc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
End If
'20-24,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-aPB9hvARz8F-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
Else
IE.Document.GetElementByID("bII4eG3osk5-aPB9hvARz8F-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
End If
'25-49,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-rkCstFZdZ63-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
Else
IE.Document.GetElementByID("bII4eG3osk5-rkCstFZdZ63-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
End If
'25-49,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-B0YaR1ETmQ5-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
Else
IE.Document.GetElementByID("bII4eG3osk5-B0YaR1ETmQ5-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
End If
'25-49,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-M5WmuzUAdzH-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
Else
IE.Document.GetElementByID("bII4eG3osk5-M5WmuzUAdzH-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
End If
End If
'PMTCT_STAT
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IM10")) Then
'Denominator
'10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("IM10")
Else
IE.Document.GetElementByID("D3dXMIpnOfu-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("IM10")
End If
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("IN10")
Else
IE.Document.GetElementByID("D3dXMIpnOfu-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("IN10")
End If
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IO10")
Else
IE.Document.GetElementByID("D3dXMIpnOfu-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IO10")
End If
'25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("IP10")
Else
IE.Document.GetElementByID("D3dXMIpnOfu-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("IP10")
End If
End If
End Sub

'PMTCT_EID
Sub PMTCT_EID_HEI_POS_write()
'PMTCT_EID
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IR10")) Then
'0-2
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Value = ThisWorkbook.Sheets("sheet1").Range("IR10")
Else
IE.Document.GetElementByID("PD4lzqx2CCu-TRTNKzpystS-val").Value = ThisWorkbook.Sheets("sheet1").Range("IR10")
End If
'2-12
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Value = ThisWorkbook.Sheets("sheet1").Range("IS10")
Else
IE.Document.GetElementByID("PD4lzqx2CCu-El4ysmXTL9r-val").Value = ThisWorkbook.Sheets("sheet1").Range("IS10")
End If
End If

'PMTCT_HEI_POS
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IT10")) Then
'0-2,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Value = ThisWorkbook.Sheets("sheet1").Range("IT10")
Else
IE.Document.GetElementByID("uMl3wp297tR-VG9llDXZfqR-val").Value = ThisWorkbook.Sheets("sheet1").Range("IT10")
End If
'0-2,art
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Value = ThisWorkbook.Sheets("sheet1").Range("IU10")
Else
IE.Document.GetElementByID("yNfuoYteftA-oYuICUnILbz-val").Value = ThisWorkbook.Sheets("sheet1").Range("IU10")
End If
'2-12,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("IV10")
Else
IE.Document.GetElementByID("uMl3wp297tR-liIscF6uc2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("IV10")
End If
'2-12,art
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Value = ThisWorkbook.Sheets("sheet1").Range("IW10")
Else
IE.Document.GetElementByID("yNfuoYteftA-bZ4b1EW7Uw7-val").Value = ThisWorkbook.Sheets("sheet1").Range("IW10")
End If
End If
End Sub

'TX_NEW_TX_CURR
Sub TX_NEW_TX_CURR_write()
'TX_NEW
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IX10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("BunPg5H6AL9-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IX10")
Else
IE.Document.GetElementByID("JqSiilvpE7v-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IX10")
End If
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("QI0LrOAmBCG-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("IY10")
Else
IE.Document.GetElementByID("JiEYm4EWwtR-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("IY10")
End If
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("IZ10")
Else
IE.Document.GetElementByID("JiEYm4EWwtR-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("IZ10")
End If
'TB
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("VGykA1pjgZz-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JA10")
Else
IE.Document.GetElementByID("eTkiWqrqxkG-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JA10")
End If
'<1
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JB10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JB10")
End If
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JC10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JC10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("JD10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("JD10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("JE10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("JE10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("JF10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("JF10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("JG10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("JG10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("JH10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("JH10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("JI10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("JI10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("JJ10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("JJ10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("JK10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("JK10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("JL10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("JL10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JM10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JM10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("JN10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("JN10")
End If
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("JO10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("JO10")
End If
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("JP10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("JP10")
End If
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JQ10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JQ10")
End If
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("JR10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("JR10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("JS10")
Else
IE.Document.GetElementByID("FjLaCnuoQWR-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("JS10")
End If
End If
'Female,<15
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("JT10")
Else
IE.Document.GetElementByID("a2BO57JIf4z-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("JT10")
End If
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("JU10")
Else
IE.Document.GetElementByID("a2BO57JIf4z-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("JU10")
End If
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("JV10")
Else
IE.Document.GetElementByID("a2BO57JIf4z-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("JV10")
End If
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("JW10")
Else
IE.Document.GetElementByID("a2BO57JIf4z-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("JW10")
End If
End If
End If

'TX_CURR
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JX10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D2KvZp54CsB-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JX10")
Else
IE.Document.GetElementByID("moJA7xJZWuJ-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JX10")
End If
'<1
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JY10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JY10")
End If
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JZ10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JZ10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("KA10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("KA10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("KB10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("KB10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("KC10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("KC10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("KD10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("KD10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KE10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KE10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("KF10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("KF10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("KG10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("KG10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("KH10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("KH10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("KI10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("KI10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KJ10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KJ10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("KK10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("KK10")
End If
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("KL10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("KL10")
End If
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("KM10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("KM10")
End If
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KN10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KN10")
End If
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("KO10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("KO10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("KP10")
Else
IE.Document.GetElementByID("ebCEt4u78PX-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("KP10")
End If
End If
'Female,<15
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KQ10")
Else
IE.Document.GetElementByID("qkjYvdfOakY-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KQ10")
End If
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KR10")
Else
IE.Document.GetElementByID("qkjYvdfOakY-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KR10")
End If
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("KS10")
Else
IE.Document.GetElementByID("qkjYvdfOakY-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("KS10")
End If
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("KT10")
Else
IE.Document.GetElementByID("qkjYvdfOakY-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("KT10")
End If
End If
End If
End Sub

'PMTCT_ART
Sub PMTCT_ART_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("KU10")) Then
'Newly
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("dfUOSQ4dypU-Q2EBeMBa8Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KU10")
Else
IE.Document.GetElementByID("AbBlLexIsnr-Q2EBeMBa8Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KU10")
End If
'Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("dfUOSQ4dypU-RTYO8ycjbCt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KV10")
Else
IE.Document.GetElementByID("AbBlLexIsnr-RTYO8ycjbCt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KV10")
End If
End If
End Sub

'TB_PREV
Sub TB_PREV_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("KW10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("wdNc4AeiH95-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KW10")
Else
IE.Document.GetElementByID("f9kduaQUMKV-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KW10")
End If
'IPT, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("FqAdKlk9CuW-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("KX10")
Else
IE.Document.GetElementByID("vdoRxRjgvFm-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("KX10")
End If
'IPT, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("FqAdKlk9CuW-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("KY10")
Else
IE.Document.GetElementByID("vdoRxRjgvFm-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("KY10")
End If
'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LB10")
Else
IE.Document.GetElementByID("h6WsUZjy18B-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LB10")
End If
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LC10")
Else
IE.Document.GetElementByID("h6WsUZjy18B-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LC10")
End If
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LD10")
Else
IE.Document.GetElementByID("h6WsUZjy18B-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LD10")
End If
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LE10")
Else
IE.Document.GetElementByID("h6WsUZjy18B-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LE10")
End If
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("DFOhwZmqmLA-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("LF10")
Else
IE.Document.GetElementByID("NZGXcA4oHYe-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("LF10")
End If
'IPT, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("v8ebDCsu6HA-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LG10")
Else
IE.Document.GetElementByID("Ge1F4eyI3lc-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LG10")
End If
'IPT, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("v8ebDCsu6HA-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("LH10")
Else
IE.Document.GetElementByID("Ge1F4eyI3lc-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("LH10")
End If
'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LK10")
Else
IE.Document.GetElementByID("NFYlz2qYNka-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LK10")
End If
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LL10")
Else
IE.Document.GetElementByID("NFYlz2qYNka-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LL10")
End If
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LM10")
Else
IE.Document.GetElementByID("NFYlz2qYNka-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LM10")
End If
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LN10")
Else
IE.Document.GetElementByID("NFYlz2qYNka-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LN10")
End If
End If
End Sub

'TB_STAT
Sub TB_STAT_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("LO10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GLx5aAKX4MD-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LO10")
Else
IE.Document.GetElementByID("rTZdUyIFsGy-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LO10")
End If
'Known Positives
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-twCITCOvoZA-val").Value = ThisWorkbook.Sheets("sheet1").Range("LR10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-twCITCOvoZA-val").Value = ThisWorkbook.Sheets("sheet1").Range("LR10")
End If
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-PVCB2tKuVGO-val").Value = ThisWorkbook.Sheets("sheet1").Range("LS10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-PVCB2tKuVGO-val").Value = ThisWorkbook.Sheets("sheet1").Range("LS10")
End If
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-bXQKnndJcUy-val").Value = ThisWorkbook.Sheets("sheet1").Range("LT10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-bXQKnndJcUy-val").Value = ThisWorkbook.Sheets("sheet1").Range("LT10")
End If
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-a9IejiMkpxr-val").Value = ThisWorkbook.Sheets("sheet1").Range("LU10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-a9IejiMkpxr-val").Value = ThisWorkbook.Sheets("sheet1").Range("LU10")
End If
'Newly Tested Positives
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-QrgQR5qqecn-val").Value = ThisWorkbook.Sheets("sheet1").Range("LX10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-QrgQR5qqecn-val").Value = ThisWorkbook.Sheets("sheet1").Range("LX10")
End If
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-qR9wVOZHs3F-val").Value = ThisWorkbook.Sheets("sheet1").Range("LY10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-qR9wVOZHs3F-val").Value = ThisWorkbook.Sheets("sheet1").Range("LY10")
End If
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-YXt74Aa7CQB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LZ10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-YXt74Aa7CQB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LZ10")
End If
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-H2d7tWiIX9V-val").Value = ThisWorkbook.Sheets("sheet1").Range("MA10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-H2d7tWiIX9V-val").Value = ThisWorkbook.Sheets("sheet1").Range("MA10")
End If
'New Negatives
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-zC0EQMShVZc-val").Value = ThisWorkbook.Sheets("sheet1").Range("MD10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-zC0EQMShVZc-val").Value = ThisWorkbook.Sheets("sheet1").Range("MD10")
End If
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-zjd6BsbodQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ME10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-zjd6BsbodQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ME10")
End If
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-cQQ1Cu0X0sU-val").Value = ThisWorkbook.Sheets("sheet1").Range("MF10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-cQQ1Cu0X0sU-val").Value = ThisWorkbook.Sheets("sheet1").Range("MF10")
End If
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-ewOK9Oo1KWm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MG10")
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-ewOK9Oo1KWm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MG10")
End If
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("LZXAdOjlBwi-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("MH10")
Else
IE.Document.GetElementByID("TcyIxVHZd8I-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("MH10")
End If
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-BGFCDhyk4M8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MK10")
Else
IE.Document.GetElementByID("AcTftDyXTzF-BGFCDhyk4M8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MK10")
End If
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-SBUMYkq3pEs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ML10")
Else
IE.Document.GetElementByID("AcTftDyXTzF-SBUMYkq3pEs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ML10")
End If
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-er95aeLbIHg-val").Value = ThisWorkbook.Sheets("sheet1").Range("MM10")
Else
IE.Document.GetElementByID("AcTftDyXTzF-er95aeLbIHg-val").Value = ThisWorkbook.Sheets("sheet1").Range("MM10")
End If
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-RFKoE51NKAq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MN10")
Else
IE.Document.GetElementByID("AcTftDyXTzF-RFKoE51NKAq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MN10")
End If
End If
'End TB_STAT
End Sub

'TB_ART
Sub TB_ART_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("MO10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pecRCQ589Ip-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("MO10")
Else
IE.Document.GetElementByID("J0EJi8BhnUC-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("MO10")
End If
'Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("TXqEC76VtrC-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("MP10")
Else
IE.Document.GetElementByID("ocBmpbqlNsi-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("MP10")
End If
'New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("TXqEC76VtrC-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("MQ10")
Else
IE.Document.GetElementByID("ocBmpbqlNsi-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("MQ10")
End If
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MR10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MR10")
End If
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("MS10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("MS10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("MT10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("MT10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("MU10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("MU10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("MV10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("MV10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("MW10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("MW10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("MX10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("MX10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("MY10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("MY10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("MZ10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("MZ10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("NA10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("NA10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("NB10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("NB10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NC10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NC10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ND10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ND10")
End If
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("NE10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("NE10")
End If
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("NF10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("NF10")
End If
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NG10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NG10")
End If
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("NH10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("NH10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("NI10")
Else
IE.Document.GetElementByID("fhBEkut3R3H-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("NI10")
End If
End If
End Sub

'TX_TB
Sub TX_TB_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("NJ10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bO90YLjSbox-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NJ10")
Else
IE.Document.GetElementByID("ZdCidLkGGV4-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NJ10")
End If
'New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CEANcO1xqgC-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("NK10")
Else
IE.Document.GetElementByID("WQowTtUTc97-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("NK10")
End If
'Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CEANcO1xqgC-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("NL10")
Else
IE.Document.GetElementByID("WQowTtUTc97-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("NL10")
End If
'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NM10")
Else
IE.Document.GetElementByID("G6EQGNhixQe-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NM10")
End If
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("NN10")
Else
IE.Document.GetElementByID("G6EQGNhixQe-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("NN10")
End If
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("NO10")
Else
IE.Document.GetElementByID("G6EQGNhixQe-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("NO10")
End If
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("NP10")
Else
IE.Document.GetElementByID("G6EQGNhixQe-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("NP10")
End If
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("lo2c9TXkj5X-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NQ10")
Else
IE.Document.GetElementByID("iBT0uRSIadN-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NQ10")
End If
'Positive, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-s5fJZmqOejY-val").Value = ThisWorkbook.Sheets("sheet1").Range("NR10")
Else
IE.Document.GetElementByID("cdacTAmnRph-s5fJZmqOejY-val").Value = ThisWorkbook.Sheets("sheet1").Range("NR10")
End If
'Positive, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-u6sRGIOBmoh-val").Value = ThisWorkbook.Sheets("sheet1").Range("NS10")
Else
IE.Document.GetElementByID("cdacTAmnRph-u6sRGIOBmoh-val").Value = ThisWorkbook.Sheets("sheet1").Range("NS10")
End If
'Negative, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-e2L487QXxft-val").Value = ThisWorkbook.Sheets("sheet1").Range("NT10")
Else
IE.Document.GetElementByID("cdacTAmnRph-e2L487QXxft-val").Value = ThisWorkbook.Sheets("sheet1").Range("NT10")
End If
'Negative, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-shTc2NWLhMt-val").Value = ThisWorkbook.Sheets("sheet1").Range("NU10")
Else
IE.Document.GetElementByID("cdacTAmnRph-shTc2NWLhMt-val").Value = ThisWorkbook.Sheets("sheet1").Range("NU10")
End If
'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NZ10")
Else
IE.Document.GetElementByID("QBCFhUL0DsI-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NZ10")
End If
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OA10")
Else
IE.Document.GetElementByID("QBCFhUL0DsI-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OA10")
End If
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("OB10")
Else
IE.Document.GetElementByID("QBCFhUL0DsI-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("OB10")
End If
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("OC10")
Else
IE.Document.GetElementByID("QBCFhUL0DsI-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("OC10")
End If
End If
End Sub

'GEND_GBV
Sub GEND_GBV_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OD10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pWTXzF2L8lG-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OD10")
Else
IE.Document.GetElementByID("sIagQEZjSyy-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OD10")
End If
'Sexual Violence
'Female,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-QdyvOZhmwfP-val").Value = ThisWorkbook.Sheets("sheet1").Range("OE10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-QdyvOZhmwfP-val").Value = ThisWorkbook.Sheets("sheet1").Range("OE10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-O8VSbT4lhbG-val").Value = ThisWorkbook.Sheets("sheet1").Range("OF10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-O8VSbT4lhbG-val").Value = ThisWorkbook.Sheets("sheet1").Range("OF10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-lQfjasPsxs3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OG10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-lQfjasPsxs3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OG10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-Oz9mfDvGh0n-val").Value = ThisWorkbook.Sheets("sheet1").Range("OH10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-Oz9mfDvGh0n-val").Value = ThisWorkbook.Sheets("sheet1").Range("OH10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-GmlEpQlBZJN-val").Value = ThisWorkbook.Sheets("sheet1").Range("OI10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-GmlEpQlBZJN-val").Value = ThisWorkbook.Sheets("sheet1").Range("OI10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-O6L8gP01Z7E-val").Value = ThisWorkbook.Sheets("sheet1").Range("OJ10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-O6L8gP01Z7E-val").Value = ThisWorkbook.Sheets("sheet1").Range("OJ10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-RRU8Xbcw6m2-val").Value = ThisWorkbook.Sheets("sheet1").Range("OK10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-RRU8Xbcw6m2-val").Value = ThisWorkbook.Sheets("sheet1").Range("OK10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-nW1xLOwJNQ3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OL10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-nW1xLOwJNQ3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OL10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-EMPdzS9xUZs-val").Value = ThisWorkbook.Sheets("sheet1").Range("OM10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-EMPdzS9xUZs-val").Value = ThisWorkbook.Sheets("sheet1").Range("OM10")
End If
'Male,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-qRPbwt7xN8N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ON10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-qRPbwt7xN8N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ON10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-dWU2Qc1DBTx-val").Value = ThisWorkbook.Sheets("sheet1").Range("OO10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-dWU2Qc1DBTx-val").Value = ThisWorkbook.Sheets("sheet1").Range("OO10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-zh1RfnjU3nw-val").Value = ThisWorkbook.Sheets("sheet1").Range("OP10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-zh1RfnjU3nw-val").Value = ThisWorkbook.Sheets("sheet1").Range("OP10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-EaFoYeVKtl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("OQ10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-EaFoYeVKtl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("OQ10")
End If
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-eph8upo4KnI-val").Value = ThisWorkbook.Sheets("sheet1").Range("OR10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-eph8upo4KnI-val").Value = ThisWorkbook.Sheets("sheet1").Range("OR10")
End If
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-kTLb3E6uG8m-val").Value = ThisWorkbook.Sheets("sheet1").Range("OS10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-kTLb3E6uG8m-val").Value = ThisWorkbook.Sheets("sheet1").Range("OS10")
End If
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-njzg2pswvAa-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-njzg2pswvAa-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
End If
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-l0fUVaWXRTe-val").Value = ThisWorkbook.Sheets("sheet1").Range("OU10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-l0fUVaWXRTe-val").Value = ThisWorkbook.Sheets("sheet1").Range("OU10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-sIES2ww1feR-val").Value = ThisWorkbook.Sheets("sheet1").Range("OV10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-sIES2ww1feR-val").Value = ThisWorkbook.Sheets("sheet1").Range("OV10")
End If
'Physical and / or Emotional Violence
'Female,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-wt4A4IVhK44-val").Value = ThisWorkbook.Sheets("sheet1").Range("OW10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-wt4A4IVhK44-val").Value = ThisWorkbook.Sheets("sheet1").Range("OW10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-GGtPtwWGpuU-val").Value = ThisWorkbook.Sheets("sheet1").Range("OX10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-GGtPtwWGpuU-val").Value = ThisWorkbook.Sheets("sheet1").Range("OX10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-Cec3GHF5VQZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OY10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-Cec3GHF5VQZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OY10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-UwV8YVOEVl3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OZ10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-UwV8YVOEVl3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OZ10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-NwrTfkWdED1-val").Value = ThisWorkbook.Sheets("sheet1").Range("PA10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-NwrTfkWdED1-val").Value = ThisWorkbook.Sheets("sheet1").Range("PA10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-AH6J0MDYMZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("PB10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-AH6J0MDYMZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("PB10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-wVVtzmD5xsT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PC10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-wVVtzmD5xsT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PC10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-HUNtR6x2i93-val").Value = ThisWorkbook.Sheets("sheet1").Range("PD10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-HUNtR6x2i93-val").Value = ThisWorkbook.Sheets("sheet1").Range("PD10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-AGV475enDdO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PE10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-AGV475enDdO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PE10")
End If
'Male,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-ClVqXFbwu7z-val").Value = ThisWorkbook.Sheets("sheet1").Range("PF10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-ClVqXFbwu7z-val").Value = ThisWorkbook.Sheets("sheet1").Range("PF10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-YsGSdOrSGvO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PG10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-YsGSdOrSGvO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PG10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-qS6AUbNJKE8-val").Value = ThisWorkbook.Sheets("sheet1").Range("PH10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-qS6AUbNJKE8-val").Value = ThisWorkbook.Sheets("sheet1").Range("PH10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-pA604NbnktK-val").Value = ThisWorkbook.Sheets("sheet1").Range("PI10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-pA604NbnktK-val").Value = ThisWorkbook.Sheets("sheet1").Range("PI10")
End If
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-EUViVSqSaSx-val").Value = ThisWorkbook.Sheets("sheet1").Range("PJ10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-EUViVSqSaSx-val").Value = ThisWorkbook.Sheets("sheet1").Range("PJ10")
End If
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-KUP9oCrnXLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("PK10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-KUP9oCrnXLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("PK10")
End If
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-VPXUnkqLbb4-val").Value = ThisWorkbook.Sheets("sheet1").Range("PL10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-VPXUnkqLbb4-val").Value = ThisWorkbook.Sheets("sheet1").Range("PL10")
End If
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-iam0H1wLzgw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PM10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-iam0H1wLzgw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PM10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-v5rsJlwfzWD-val").Value = ThisWorkbook.Sheets("sheet1").Range("PN10")
Else
IE.Document.GetElementByID("pKH3YTAShEe-v5rsJlwfzWD-val").Value = ThisWorkbook.Sheets("sheet1").Range("PN10")
End If
'PEP
'Female,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-m0cv4FpuKcT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PO10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-m0cv4FpuKcT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PO10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-WZA61w3X97V-val").Value = ThisWorkbook.Sheets("sheet1").Range("PP10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-WZA61w3X97V-val").Value = ThisWorkbook.Sheets("sheet1").Range("PP10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-n3LvtfmkEfp-val").Value = ThisWorkbook.Sheets("sheet1").Range("PQ10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-n3LvtfmkEfp-val").Value = ThisWorkbook.Sheets("sheet1").Range("PQ10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-mfOtkXnJkEw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PR10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-mfOtkXnJkEw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PR10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-Tvu2J5Nr7JF-val").Value = ThisWorkbook.Sheets("sheet1").Range("PS10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-Tvu2J5Nr7JF-val").Value = ThisWorkbook.Sheets("sheet1").Range("PS10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-WJKtglKn0DE-val").Value = ThisWorkbook.Sheets("sheet1").Range("PT10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-WJKtglKn0DE-val").Value = ThisWorkbook.Sheets("sheet1").Range("PT10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-YjCsCWpQVob-val").Value = ThisWorkbook.Sheets("sheet1").Range("PU10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-YjCsCWpQVob-val").Value = ThisWorkbook.Sheets("sheet1").Range("PU10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-MytUkuWfSju-val").Value = ThisWorkbook.Sheets("sheet1").Range("PV10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-MytUkuWfSju-val").Value = ThisWorkbook.Sheets("sheet1").Range("PV10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-hiHSrG29erB-val").Value = ThisWorkbook.Sheets("sheet1").Range("PW10")
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-hiHSrG29erB-val").Value = ThisWorkbook.Sheets("sheet1").Range("PW10")
End If
End If
End Sub

'FPINT_SITE
Sub FPINT_SITE_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("QG10")) Then
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").Value = ThisWorkbook.Sheets("sheet1").Range("QG10")
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").Value = ThisWorkbook.Sheets("sheet1").Range("QH10")
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").Value = ThisWorkbook.Sheets("sheet1").Range("QI10")
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").Value = ThisWorkbook.Sheets("sheet1").Range("QJ10")
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").Value = ThisWorkbook.Sheets("sheet1").Range("QK10")
End If
End Sub

'TX_RET
Sub TX_RET_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("QL10")) Then
'Numerator
'12 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KLHpJzK1SLy-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QL10")
Else
IE.Document.GetElementByID("ZOU9pal2R3w-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QL10")
End If
'24 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Pxf0TEEIZFl-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QM10")
Else
IE.Document.GetElementByID("KWmsoOySlvp-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QM10")
End If
'36 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("BnlDGvdjpYH-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QN10")
Else
IE.Document.GetElementByID("bOnCafw9zhe-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QN10")
End If
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9MO0VAFjar-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("QO10")
Else
IE.Document.GetElementByID("HdRYfCJUfsc-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("QO10")
End If
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9MO0VAFjar-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("QP10")
Else
IE.Document.GetElementByID("HdRYfCJUfsc-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("QP10")
End If
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("QQ10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("QQ10")
End If
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("QR10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("QR10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("QS10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("QS10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("QT10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("QT10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("QU10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("QU10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("QV10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("QV10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("QW10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("QW10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("QX10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("QX10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("QY10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("QY10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("QZ10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("QZ10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RA10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RA10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RB10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RB10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RC10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RC10")
End If
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("RD10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("RD10")
End If
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("RE10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("RE10")
End If
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RF10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RF10")
End If
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("RG10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("RG10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("RH10")
Else
IE.Document.GetElementByID("gmR0FxXhLyl-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("RH10")
End If
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("RI10")) Then
'Denominator
'12 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("VX3vV0hBeLy-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RI10")
Else
IE.Document.GetElementByID("SmaMR3maQMj-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RI10")
End If
'24 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("LRovH4RfPxL-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RJ10")
Else
IE.Document.GetElementByID("BWkdrGCoKhQ-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RJ10")
End If
'36 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pnXn5yTXLvG-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RK10")
Else
IE.Document.GetElementByID("X2m1PXxPAQe-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RK10")
End If
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("aal61UVcc5M-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("RL10")
Else
IE.Document.GetElementByID("UGj6ot4NTm7-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("RL10")
End If
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("aal61UVcc5M-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("RM10")
Else
IE.Document.GetElementByID("UGj6ot4NTm7-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("RM10")
End If
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("RN10")
Else
IE.Document.GetElementByID("ASBT43khvwp-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("RN10")
End If
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RO10")
Else
IE.Document.GetElementByID("ASBT43khvwp-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RO10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("RP10")
Else
IE.Document.GetElementByID("ASBT43khvwp-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("RP10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("RQ10")
Else
IE.Document.GetElementByID("ASBT43khvwp-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("RQ10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("RR10")
Else
IE.Document.GetElementByID("ASBT43khvwp-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("RR10")
End If
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("RS10")
Else
IE.Document.GetElementByID("ASBT43khvwp-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("RS10")
End If
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("RT10")
Else
IE.Document.GetElementByID("ASBT43khvwp-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("RT10")
End If
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("RU10")
Else
IE.Document.GetElementByID("ASBT43khvwp-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("RU10")
End If
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("RV10")
Else
IE.Document.GetElementByID("ASBT43khvwp-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("RV10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("RW10")
Else
IE.Document.GetElementByID("ASBT43khvwp-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("RW10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RX10")
Else
IE.Document.GetElementByID("ASBT43khvwp-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RX10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RY10")
Else
IE.Document.GetElementByID("ASBT43khvwp-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RY10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RZ10")
Else
IE.Document.GetElementByID("ASBT43khvwp-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RZ10")
End If
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SA10")
Else
IE.Document.GetElementByID("ASBT43khvwp-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SA10")
End If
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("SB10")
Else
IE.Document.GetElementByID("ASBT43khvwp-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("SB10")
End If
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("SC10")
Else
IE.Document.GetElementByID("ASBT43khvwp-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("SC10")
End If
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("SD10")
Else
IE.Document.GetElementByID("ASBT43khvwp-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("SD10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("SE10")
Else
IE.Document.GetElementByID("ASBT43khvwp-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("SE10")
End If
End If
End Sub

'TX_PVLS
Sub TX_PVLS_write()
'Numerator
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("SF10")) Then
'Indication
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YQEFlW4vClz-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SF10")
Else
IE.Document.GetElementByID("ptcrUFB3k5M-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SF10")
End If
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SG10")
Else
IE.Document.GetElementByID("pICN9lMKMAl-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SG10")
End If
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SH10")
Else
IE.Document.GetElementByID("pICN9lMKMAl-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SH10")
End If
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SI10")
Else
IE.Document.GetElementByID("MylJht530Cc-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SI10")
End If
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SJ10")
Else
IE.Document.GetElementByID("MylJht530Cc-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SJ10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SK10")
Else
IE.Document.GetElementByID("MylJht530Cc-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SK10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SL10")
Else
IE.Document.GetElementByID("MylJht530Cc-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SL10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("SM10")
Else
IE.Document.GetElementByID("MylJht530Cc-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("SM10")
End If
'Female,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("SN10")
Else
IE.Document.GetElementByID("MylJht530Cc-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("SN10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("SO10")
Else
IE.Document.GetElementByID("MylJht530Cc-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("SO10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SP10")
Else
IE.Document.GetElementByID("MylJht530Cc-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SP10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SQ10")
Else
IE.Document.GetElementByID("MylJht530Cc-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SQ10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("SR10")
Else
IE.Document.GetElementByID("MylJht530Cc-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("SR10")
End If
'Male,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("SS10")
Else
IE.Document.GetElementByID("MylJht530Cc-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("SS10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ST10")
Else
IE.Document.GetElementByID("MylJht530Cc-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ST10")
End If
End If

'Denominator
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("SU10")) Then
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("baOWBUVWsx0-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("SU10")
Else
IE.Document.GetElementByID("MMWrCwgC4yq-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("SU10")
End If
'Indication
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NtwSTwGUYzt-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SV10")
Else
IE.Document.GetElementByID("YCJoGPP9akp-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SV10")
End If
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SW10")
Else
IE.Document.GetElementByID("PsGw5Fibj3P-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SW10")
End If
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SX10")
Else
IE.Document.GetElementByID("PsGw5Fibj3P-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SX10")
End If
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SY10")
Else
IE.Document.GetElementByID("alP4jHSfacs-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SY10")
End If
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SZ10")
Else
IE.Document.GetElementByID("alP4jHSfacs-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SZ10")
End If
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("TA10")
Else
IE.Document.GetElementByID("alP4jHSfacs-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("TA10")
End If
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("TB10")
Else
IE.Document.GetElementByID("alP4jHSfacs-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("TB10")
End If
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("TC10")
Else
IE.Document.GetElementByID("alP4jHSfacs-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("TC10")
End If
'Female,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("TD10")
Else
IE.Document.GetElementByID("alP4jHSfacs-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("TD10")
End If
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("TE10")
Else
IE.Document.GetElementByID("alP4jHSfacs-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("TE10")
End If
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("TF10")
Else
IE.Document.GetElementByID("alP4jHSfacs-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("TF10")
End If
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("TG10")
Else
IE.Document.GetElementByID("alP4jHSfacs-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("TG10")
End If
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TH10")
Else
IE.Document.GetElementByID("alP4jHSfacs-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TH10")
End If
'Male,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("TI10")
Else
IE.Document.GetElementByID("alP4jHSfacs-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("TI10")
End If
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("TJ10")
Else
IE.Document.GetElementByID("alP4jHSfacs-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("TJ10")
End If
End If
End Sub

'HRH
Sub HRH_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("TK10")) Then
'HRH_CURR
'Clinical
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").Value = ThisWorkbook.Sheets("sheet1").Range("TK10")
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("TL10")
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("TM10")
'Clinical Support
IE.Document.GetElementByID("XL1jnbmgXje-DOwfGvVn9ck-val").Value = ThisWorkbook.Sheets("sheet1").Range("TN10")
IE.Document.GetElementByID("XL1jnbmgXje-ua5IEJcXKSZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("TO10")
IE.Document.GetElementByID("XL1jnbmgXje-gM511Ccfn0j-val").Value = ThisWorkbook.Sheets("sheet1").Range("TP10")
'Management
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").Value = ThisWorkbook.Sheets("sheet1").Range("TQ10")
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").Value = ThisWorkbook.Sheets("sheet1").Range("TR10")
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TS10")
'Social Service
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").Value = ThisWorkbook.Sheets("sheet1").Range("TT10")
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").Value = ThisWorkbook.Sheets("sheet1").Range("TU10")
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").Value = ThisWorkbook.Sheets("sheet1").Range("TV10")
'Lay
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").Value = ThisWorkbook.Sheets("sheet1").Range("TW10")
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").Value = ThisWorkbook.Sheets("sheet1").Range("TX10")
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").Value = ThisWorkbook.Sheets("sheet1").Range("TY10")
'Other
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TZ10")
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").Value = ThisWorkbook.Sheets("sheet1").Range("UA10")
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("UB10")
End If
'HRH_STAFF
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("UC10")) Then
IE.Document.GetElementByID("Kk4CdspETNQ-mkOfrTuz7tS-val").Value = ThisWorkbook.Sheets("sheet1").Range("UC10")
IE.Document.GetElementByID("Kk4CdspETNQ-j2gebSicoa8-val").Value = ThisWorkbook.Sheets("sheet1").Range("UD10")
IE.Document.GetElementByID("Kk4CdspETNQ-oaRfTQD4RLG-val").Value = ThisWorkbook.Sheets("sheet1").Range("UE10")
IE.Document.GetElementByID("Kk4CdspETNQ-itxIkeWqiE9-val").Value = ThisWorkbook.Sheets("sheet1").Range("UF10")
IE.Document.GetElementByID("Kk4CdspETNQ-a9N5X73zhET-val").Value = ThisWorkbook.Sheets("sheet1").Range("UG10")
IE.Document.GetElementByID("Kk4CdspETNQ-wKH5X6oHquw-val").Value = ThisWorkbook.Sheets("sheet1").Range("UH10")
End If
End Sub

'LAB_PTCQI
Sub LAB_PTCQI_write()
'LAB_Based
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("UN10")) Then
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").Value = ThisWorkbook.Sheets("sheet1").Range("UN10")
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").Value = ThisWorkbook.Sheets("sheet1").Range("UO10")
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").Value = ThisWorkbook.Sheets("sheet1").Range("UP10")
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").Value = ThisWorkbook.Sheets("sheet1").Range("UQ10")
'HIV IVT/EID
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").Value = ThisWorkbook.Sheets("sheet1").Range("UR10")
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").Value = ThisWorkbook.Sheets("sheet1").Range("US10")
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").Value = ThisWorkbook.Sheets("sheet1").Range("UT10")
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").Value = ThisWorkbook.Sheets("sheet1").Range("UU10")
'HIV Viral Load
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").Value = ThisWorkbook.Sheets("sheet1").Range("UV10")
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").Value = ThisWorkbook.Sheets("sheet1").Range("UW10")
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").Value = ThisWorkbook.Sheets("sheet1").Range("UX10")
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").Value = ThisWorkbook.Sheets("sheet1").Range("UY10")
'TB Xpert
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").Value = ThisWorkbook.Sheets("sheet1").Range("UZ10")
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").Value = ThisWorkbook.Sheets("sheet1").Range("VA10")
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").Value = ThisWorkbook.Sheets("sheet1").Range("VB10")
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").Value = ThisWorkbook.Sheets("sheet1").Range("VC10")
'TB AFB
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").Value = ThisWorkbook.Sheets("sheet1").Range("VD10")
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").Value = ThisWorkbook.Sheets("sheet1").Range("VE10")
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").Value = ThisWorkbook.Sheets("sheet1").Range("VF10")
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").Value = ThisWorkbook.Sheets("sheet1").Range("VG10")
'TB Culture
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").Value = ThisWorkbook.Sheets("sheet1").Range("VH10")
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").Value = ThisWorkbook.Sheets("sheet1").Range("VI10")
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").Value = ThisWorkbook.Sheets("sheet1").Range("VJ10")
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").Value = ThisWorkbook.Sheets("sheet1").Range("VK10")
'CD4
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").Value = ThisWorkbook.Sheets("sheet1").Range("VL10")
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").Value = ThisWorkbook.Sheets("sheet1").Range("VM10")
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").Value = ThisWorkbook.Sheets("sheet1").Range("VN10")
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").Value = ThisWorkbook.Sheets("sheet1").Range("VO10")
'Other
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").Value = ThisWorkbook.Sheets("sheet1").Range("VO10")
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").Value = ThisWorkbook.Sheets("sheet1").Range("VP10")
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").Value = ThisWorkbook.Sheets("sheet1").Range("VQ10")
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").Value = ThisWorkbook.Sheets("sheet1").Range("VR10")
'2
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").Value = ThisWorkbook.Sheets("sheet1").Range("VS10")
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").Value = ThisWorkbook.Sheets("sheet1").Range("VT10")
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").Value = ThisWorkbook.Sheets("sheet1").Range("VU10")
'HIV IVT/EID
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").Value = ThisWorkbook.Sheets("sheet1").Range("VV10")
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").Value = ThisWorkbook.Sheets("sheet1").Range("VW10")
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").Value = ThisWorkbook.Sheets("sheet1").Range("VX10")
'HIV Viral Load
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").Value = ThisWorkbook.Sheets("sheet1").Range("VY10")
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").Value = ThisWorkbook.Sheets("sheet1").Range("VZ10")
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").Value = ThisWorkbook.Sheets("sheet1").Range("WA10")
'TB Xpert
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").Value = ThisWorkbook.Sheets("sheet1").Range("WB10")
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("WC10")
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").Value = ThisWorkbook.Sheets("sheet1").Range("WD10")
'TB AFB
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").Value = ThisWorkbook.Sheets("sheet1").Range("WE10")
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").Value = ThisWorkbook.Sheets("sheet1").Range("WF10")
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").Value = ThisWorkbook.Sheets("sheet1").Range("WG10")
'TB Culture
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").Value = ThisWorkbook.Sheets("sheet1").Range("WH10")
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").Value = ThisWorkbook.Sheets("sheet1").Range("WI10")
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").Value = ThisWorkbook.Sheets("sheet1").Range("WJ10")
'CD4
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").Value = ThisWorkbook.Sheets("sheet1").Range("WK10")
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").Value = ThisWorkbook.Sheets("sheet1").Range("WL10")
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("WM10")
'Other
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").Value = ThisWorkbook.Sheets("sheet1").Range("WN10")
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").Value = ThisWorkbook.Sheets("sheet1").Range("WO10")
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").Value = ThisWorkbook.Sheets("sheet1").Range("WP10")
'Specimens received
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").Value = ThisWorkbook.Sheets("sheet1").Range("WQ10")
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").Value = ThisWorkbook.Sheets("sheet1").Range("WR10")
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").Value = ThisWorkbook.Sheets("sheet1").Range("WS10")
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").Value = ThisWorkbook.Sheets("sheet1").Range("WT10")
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").Value = ThisWorkbook.Sheets("sheet1").Range("WU10")
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").Value = ThisWorkbook.Sheets("sheet1").Range("WV10")
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").Value = ThisWorkbook.Sheets("sheet1").Range("WX10")
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").Value = ThisWorkbook.Sheets("sheet1").Range("WY10")
End If
'POCT_Based
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("WZ10")) Then
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").Value = ThisWorkbook.Sheets("sheet1").Range("WZ10")
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").Value = ThisWorkbook.Sheets("sheet1").Range("XA10")
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").Value = ThisWorkbook.Sheets("sheet1").Range("XB10")
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").Value = ThisWorkbook.Sheets("sheet1").Range("XC10")
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").Value = ThisWorkbook.Sheets("sheet1").Range("XD10")
'HIV IVT/EID
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").Value = ThisWorkbook.Sheets("sheet1").Range("XE10")
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").Value = ThisWorkbook.Sheets("sheet1").Range("XF10")
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").Value = ThisWorkbook.Sheets("sheet1").Range("XG10")
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").Value = ThisWorkbook.Sheets("sheet1").Range("XH10")
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").Value = ThisWorkbook.Sheets("sheet1").Range("XI10")
'HIV Viral Load
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").Value = ThisWorkbook.Sheets("sheet1").Range("XJ10")
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").Value = ThisWorkbook.Sheets("sheet1").Range("XK10")
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").Value = ThisWorkbook.Sheets("sheet1").Range("XL10")
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").Value = ThisWorkbook.Sheets("sheet1").Range("XM10")
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").Value = ThisWorkbook.Sheets("sheet1").Range("XN10")
'TB Xpert
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").Value = ThisWorkbook.Sheets("sheet1").Range("XO10")
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").Value = ThisWorkbook.Sheets("sheet1").Range("XP10")
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").Value = ThisWorkbook.Sheets("sheet1").Range("XQ10")
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").Value = ThisWorkbook.Sheets("sheet1").Range("XR10")
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("XS10")
'TB AFB
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").Value = ThisWorkbook.Sheets("sheet1").Range("XT10")
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").Value = ThisWorkbook.Sheets("sheet1").Range("XU10")
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").Value = ThisWorkbook.Sheets("sheet1").Range("XV10")
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").Value = ThisWorkbook.Sheets("sheet1").Range("XW10")
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").Value = ThisWorkbook.Sheets("sheet1").Range("XX10")
'CD4
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").Value = ThisWorkbook.Sheets("sheet1").Range("XY10")
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").Value = ThisWorkbook.Sheets("sheet1").Range("XZ10")
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").Value = ThisWorkbook.Sheets("sheet1").Range("YA10")
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").Value = ThisWorkbook.Sheets("sheet1").Range("YB10")
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").Value = ThisWorkbook.Sheets("sheet1").Range("YC10")
'Other
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("YD10")
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").Value = ThisWorkbook.Sheets("sheet1").Range("YE10")
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").Value = ThisWorkbook.Sheets("sheet1").Range("YF10")
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").Value = ThisWorkbook.Sheets("sheet1").Range("YG10")
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").Value = ThisWorkbook.Sheets("sheet1").Range("YH10")
'2
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").Value = ThisWorkbook.Sheets("sheet1").Range("YI10")
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").Value = ThisWorkbook.Sheets("sheet1").Range("YJ10")
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").Value = ThisWorkbook.Sheets("sheet1").Range("YK10")
'HIV IVT/EID
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").Value = ThisWorkbook.Sheets("sheet1").Range("YL10")
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").Value = ThisWorkbook.Sheets("sheet1").Range("YM10")
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").Value = ThisWorkbook.Sheets("sheet1").Range("YN10")
'HIV Viral Load
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").Value = ThisWorkbook.Sheets("sheet1").Range("YO10")
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").Value = ThisWorkbook.Sheets("sheet1").Range("YP10")
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").Value = ThisWorkbook.Sheets("sheet1").Range("YQ10")
'TB Xpert
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").Value = ThisWorkbook.Sheets("sheet1").Range("YR10")
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").Value = ThisWorkbook.Sheets("sheet1").Range("YS10")
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").Value = ThisWorkbook.Sheets("sheet1").Range("YT10")
'TB AFB
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").Value = ThisWorkbook.Sheets("sheet1").Range("YU10")
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").Value = ThisWorkbook.Sheets("sheet1").Range("YV10")
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").Value = ThisWorkbook.Sheets("sheet1").Range("YW10")
'CD4
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("YX10")
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").Value = ThisWorkbook.Sheets("sheet1").Range("YY10")
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").Value = ThisWorkbook.Sheets("sheet1").Range("YZ10")
'Other
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZA10")
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZB10")
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZC10")
'Specimens received
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZD10")
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZE10")
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZF10")
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZG10")
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZH10")
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZI10")
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZJ10") 
End If
End Sub

'--------------------------------------------------------------------
'                        PERSIST FUNCTIONS
'--------------------------------------------------------------------
'PrEP
Sub PrEP_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WQqBCWI0gND-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-rsDhJVueMlj-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-Eb1wUeyQfm1-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-SOyl1KfM62E-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-WJs7WStaKb7-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-D6I9GaYrrcy-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-ngxcu4ikzmm-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-kWUjVlYNfMC-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-ijirRiCapCK-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-twp0pnjjBhU-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-w3Ke7t08Ca6-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-dPRznpKPI5f-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-UlVb0KF88sP-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-lwaRLYm2Yc8-val").dispatchEvent evt
IE.Document.GetElementByID("KNO4emPfF91-mpyFgAd2eTH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bz61aPNTomM-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-rsDhJVueMlj-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-Eb1wUeyQfm1-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-SOyl1KfM62E-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-WJs7WStaKb7-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-D6I9GaYrrcy-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-ngxcu4ikzmm-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-kWUjVlYNfMC-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-ijirRiCapCK-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-twp0pnjjBhU-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-w3Ke7t08Ca6-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-dPRznpKPI5f-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-UlVb0KF88sP-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-lwaRLYm2Yc8-val").dispatchEvent evt
IE.Document.GetElementByID("b6OI9qB0Who-mpyFgAd2eTH-val").dispatchEvent evt
End If
End Sub

'HTS_TST_Numerator
Sub HTS_TST_Numerator_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K6f6jR0NOcZ-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FJSew4Ks0j3-HllvX50cXC0-val").dispatchEvent evt
End If
End Sub

'PICT_Inpatient
Sub PICT_Inpatient_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("hvtNfA73XhN-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("qZAq6ABJe2I-HSpL3hSBx6F-val").dispatchEvent evt
End If
End Sub

'PICT_Pediatric
Sub PICT_Pediatric_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("SpjvCpxnc20-tfxXAPNxtUc-val").dispatchEvent evt
IE.Document.GetElementByID("SpjvCpxnc20-QV7inC4TQdR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("TUJPxclPx31-tfxXAPNxtUc-val").dispatchEvent evt
IE.Document.GetElementByID("TUJPxclPx31-QV7inC4TQdR-val").dispatchEvent evt
End If
End Sub

'PICT_TB_Clinic
Sub PICT_TB_Clinic_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-qF9q6ImcE4Q-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-LIuHxfndMvN-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-zJAFlhIuWgH-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-DX5hOcGmzO4-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-nm4ngD1r1hU-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-g4X5YaSBkbt-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-SYFxsQKDZB6-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-X6qWVyu9XoN-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-XpcFo6dVPT4-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-xrbKLtiVPLr-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-K5N6EXwJKhq-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-V6sMmLkODqf-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-RHmkwEYAkor-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-SdpT6lSiyCM-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-j98NBCtzxly-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-HBu2SwE1QoF-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("Ogm7REBudex-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-qF9q6ImcE4Q-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-LIuHxfndMvN-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-zJAFlhIuWgH-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-DX5hOcGmzO4-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-nm4ngD1r1hU-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-g4X5YaSBkbt-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-SYFxsQKDZB6-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-X6qWVyu9XoN-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-XpcFo6dVPT4-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-xrbKLtiVPLr-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-K5N6EXwJKhq-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-V6sMmLkODqf-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-RHmkwEYAkor-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-SdpT6lSiyCM-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-j98NBCtzxly-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-HBu2SwE1QoF-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("KeklNQcVqTQ-HSpL3hSBx6F-val").dispatchEvent evt
End If
End Sub

'PICT_PMTCT_ANC
Sub PICT_PMTCT_ANC_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-yLBZURYX4dM-val").dispatchEvent evt
IE.Document.GetElementByID("tgHxA0DD5oL-V3oXrjInRC5-val").dispatchEvent evt
IE.Document.GetElementByID("tgHxA0DD5oL-Nh2FihNXvdJ-val").dispatchEvent evt
IE.Document.GetElementByID("tgHxA0DD5oL-swdumJN00xH-val").dispatchEvent evt
IE.Document.GetElementByID("tgHxA0DD5oL-qSEFOXyVh36-val").dispatchEvent evt
IE.Document.GetElementByID("tgHxA0DD5oL-LUGZN0xJK8O-val").dispatchEvent evt
IE.Document.GetElementByID("tgHxA0DD5oL-liB7pxJtaLm-val").dispatchEvent evt
IE.Document.GetElementByID("tgHxA0DD5oL-hxYS9p5OORs-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-yLBZURYX4dM-val").dispatchEvent evt
IE.Document.GetElementByID("RT8zvKCJaXC-V3oXrjInRC5-val").dispatchEvent evt
IE.Document.GetElementByID("RT8zvKCJaXC-Nh2FihNXvdJ-val").dispatchEvent evt
IE.Document.GetElementByID("RT8zvKCJaXC-swdumJN00xH-val").dispatchEvent evt
IE.Document.GetElementByID("RT8zvKCJaXC-qSEFOXyVh36-val").dispatchEvent evt
IE.Document.GetElementByID("RT8zvKCJaXC-LUGZN0xJK8O-val").dispatchEvent evt
IE.Document.GetElementByID("RT8zvKCJaXC-liB7pxJtaLm-val").dispatchEvent evt
IE.Document.GetElementByID("RT8zvKCJaXC-hxYS9p5OORs-val").dispatchEvent evt
End If
End Sub

'PICT_Emergency
Sub PICT_Emergency_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("m6oDgY6WhM4-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("viytbgNBMks-HSpL3hSBx6F-val").dispatchEvent evt
End If
End Sub

'PICT_Other
Sub PICT_Other_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-EpuxXtY71JG-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-YcXbNpQVqTA-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("H7Iu1SBCLTm-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-EpuxXtY71JG-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-YcXbNpQVqTA-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("jHjC9XIJbhL-HSpL3hSBx6F-val").dispatchEvent evt
End If
End Sub

'VCT
Sub VCT_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("K3I0l3A6fNt-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("YBdu7j2gGjC-HSpL3hSBx6F-val").dispatchEvent evt
End If
End Sub

'Index_Testing
Sub Index_Testing_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("WSzB03ZCEuR-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("JjDbcm9MfuJ-HSpL3hSBx6F-val").dispatchEvent evt
End If
End Sub

'PMTCT_STAT
Sub PMTCT_STAT_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("DsC5f5aN6Ef-Jwb1SWomgpk-val").dispatchEvent evt
IE.Document.GetElementByID("sVZKPce0Cd6-tfLs2DP45Ls-val").dispatchEvent evt
IE.Document.GetElementByID("sVZKPce0Cd6-PYDtXtMwEBg-val").dispatchEvent evt
IE.Document.GetElementByID("sVZKPce0Cd6-BNxBrkZHoIj-val").dispatchEvent evt
IE.Document.GetElementByID("sVZKPce0Cd6-ivDtJODDkOt-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-FATw338XdmD-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-PpWt03yRclQ-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-Wjm2Jejaqh2-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-CQz1usv1yjJ-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-bGJGYyYer7f-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-Cn4g5a16slF-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-aluqwhKuVku-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-Dvi71PYwhYc-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-aPB9hvARz8F-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-rkCstFZdZ63-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-B0YaR1ETmQ5-val").dispatchEvent evt
IE.Document.GetElementByID("fg53NvKg3EN-M5WmuzUAdzH-val").dispatchEvent evt
IE.Document.GetElementByID("RHN2Ui10Ivu-tfLs2DP45Ls-val").dispatchEvent evt
IE.Document.GetElementByID("RHN2Ui10Ivu-PYDtXtMwEBg-val").dispatchEvent evt
IE.Document.GetElementByID("RHN2Ui10Ivu-BNxBrkZHoIj-val").dispatchEvent evt
IE.Document.GetElementByID("RHN2Ui10Ivu-ivDtJODDkOt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("EQiyFRSNeK2-Jwb1SWomgpk-val").dispatchEvent evt
IE.Document.GetElementByID("A6sEZh4ctKy-tfLs2DP45Ls-val").dispatchEvent evt
IE.Document.GetElementByID("A6sEZh4ctKy-PYDtXtMwEBg-val").dispatchEvent evt
IE.Document.GetElementByID("A6sEZh4ctKy-BNxBrkZHoIj-val").dispatchEvent evt
IE.Document.GetElementByID("A6sEZh4ctKy-ivDtJODDkOt-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-FATw338XdmD-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-PpWt03yRclQ-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-Wjm2Jejaqh2-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-CQz1usv1yjJ-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-bGJGYyYer7f-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-Cn4g5a16slF-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-aluqwhKuVku-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-Dvi71PYwhYc-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-aPB9hvARz8F-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-rkCstFZdZ63-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-B0YaR1ETmQ5-val").dispatchEvent evt
IE.Document.GetElementByID("bII4eG3osk5-M5WmuzUAdzH-val").dispatchEvent evt
IE.Document.GetElementByID("D3dXMIpnOfu-tfLs2DP45Ls-val").dispatchEvent evt
IE.Document.GetElementByID("D3dXMIpnOfu-PYDtXtMwEBg-val").dispatchEvent evt
IE.Document.GetElementByID("D3dXMIpnOfu-BNxBrkZHoIj-val").dispatchEvent evt
IE.Document.GetElementByID("D3dXMIpnOfu-ivDtJODDkOt-val").dispatchEvent evt
End If
End Sub

'PMTCT_EID_HEI_POS
Sub PMTCT_EID_HEI_POS_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").dispatchEvent evt
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").dispatchEvent evt
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").dispatchEvent evt
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").dispatchEvent evt
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").dispatchEvent evt
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("PD4lzqx2CCu-TRTNKzpystS-val").dispatchEvent evt
IE.Document.GetElementByID("PD4lzqx2CCu-El4ysmXTL9r-val").dispatchEvent evt
IE.Document.GetElementByID("uMl3wp297tR-VG9llDXZfqR-val").dispatchEvent evt
IE.Document.GetElementByID("yNfuoYteftA-oYuICUnILbz-val").dispatchEvent evt
IE.Document.GetElementByID("uMl3wp297tR-liIscF6uc2E-val").dispatchEvent evt
IE.Document.GetElementByID("yNfuoYteftA-bZ4b1EW7Uw7-val").dispatchEvent evt
End If
End Sub

'TX_NEW_TX_CURR
Sub TX_NEW_TX_CURR_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("BunPg5H6AL9-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("QI0LrOAmBCG-vxBSF1mguas-val").dispatchEvent evt
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").dispatchEvent evt
IE.Document.GetElementByID("VGykA1pjgZz-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("yXZtvoYQXcD-rPO0WWEbKzL-val").dispatchEvent evt
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").dispatchEvent evt
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").dispatchEvent evt
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").dispatchEvent evt
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").dispatchEvent evt
IE.Document.GetElementByID("D2KvZp54CsB-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("Hyvw9VnZ2ch-rPO0WWEbKzL-val").dispatchEvent evt
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").dispatchEvent evt
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").dispatchEvent evt
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").dispatchEvent evt
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JqSiilvpE7v-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("JiEYm4EWwtR-vxBSF1mguas-val").dispatchEvent evt
IE.Document.GetElementByID("JiEYm4EWwtR-jaxEUorPKgv-val").dispatchEvent evt
IE.Document.GetElementByID("eTkiWqrqxkG-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("FjLaCnuoQWR-rPO0WWEbKzL-val").dispatchEvent evt
IE.Document.GetElementByID("a2BO57JIf4z-wIv7t5fSIlK-val").dispatchEvent evt
IE.Document.GetElementByID("a2BO57JIf4z-R6XPf8j0tYt-val").dispatchEvent evt
IE.Document.GetElementByID("a2BO57JIf4z-GhywTqKHQNM-val").dispatchEvent evt
IE.Document.GetElementByID("a2BO57JIf4z-ZnMtvRMKMWh-val").dispatchEvent evt
IE.Document.GetElementByID("moJA7xJZWuJ-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("ebCEt4u78PX-rPO0WWEbKzL-val").dispatchEvent evt
IE.Document.GetElementByID("qkjYvdfOakY-wIv7t5fSIlK-val").dispatchEvent evt
IE.Document.GetElementByID("qkjYvdfOakY-R6XPf8j0tYt-val").dispatchEvent evt
IE.Document.GetElementByID("qkjYvdfOakY-GhywTqKHQNM-val").dispatchEvent evt
IE.Document.GetElementByID("qkjYvdfOakY-ZnMtvRMKMWh-val").dispatchEvent evt
End If
End Sub

'PMTCT_ART
Sub PMTCT_ART_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("dfUOSQ4dypU-Q2EBeMBa8Ga-val").dispatchEvent evt
IE.Document.GetElementByID("dfUOSQ4dypU-RTYO8ycjbCt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("AbBlLexIsnr-Q2EBeMBa8Ga-val").dispatchEvent evt
IE.Document.GetElementByID("AbBlLexIsnr-RTYO8ycjbCt-val").dispatchEvent evt
End If
End Sub

'TB_PREV
Sub TB_PREV_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("wdNc4AeiH95-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("FqAdKlk9CuW-xTbmPjpd5sB-val").dispatchEvent evt
IE.Document.GetElementByID("FqAdKlk9CuW-ujD0vlLsULk-val").dispatchEvent evt
IE.Document.GetElementByID("gLYr2HkqACp-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("gLYr2HkqACp-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("gLYr2HkqACp-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("gLYr2HkqACp-rtt53W8KwRV-val").dispatchEvent evt
IE.Document.GetElementByID("DFOhwZmqmLA-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("v8ebDCsu6HA-xTbmPjpd5sB-val").dispatchEvent evt
IE.Document.GetElementByID("v8ebDCsu6HA-ujD0vlLsULk-val").dispatchEvent evt
IE.Document.GetElementByID("vHCvmxeOulc-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("vHCvmxeOulc-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("vHCvmxeOulc-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("vHCvmxeOulc-rtt53W8KwRV-val").dispatchEvent evt
Else
IE.Document.GetElementByID("f9kduaQUMKV-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("vdoRxRjgvFm-xTbmPjpd5sB-val").dispatchEvent evt
IE.Document.GetElementByID("vdoRxRjgvFm-ujD0vlLsULk-val").dispatchEvent evt
IE.Document.GetElementByID("h6WsUZjy18B-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("h6WsUZjy18B-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("h6WsUZjy18B-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("h6WsUZjy18B-rtt53W8KwRV-val").dispatchEvent evt
IE.Document.GetElementByID("NZGXcA4oHYe-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("Ge1F4eyI3lc-xTbmPjpd5sB-val").dispatchEvent evt
IE.Document.GetElementByID("Ge1F4eyI3lc-ujD0vlLsULk-val").dispatchEvent evt
IE.Document.GetElementByID("NFYlz2qYNka-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("NFYlz2qYNka-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("NFYlz2qYNka-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("NFYlz2qYNka-rtt53W8KwRV-val").dispatchEvent evt
End If
End Sub

'TB_STAT
Sub TB_STAT_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GLx5aAKX4MD-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-twCITCOvoZA-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-PVCB2tKuVGO-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-bXQKnndJcUy-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-a9IejiMkpxr-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-QrgQR5qqecn-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-qR9wVOZHs3F-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-YXt74Aa7CQB-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-H2d7tWiIX9V-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-zC0EQMShVZc-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-zjd6BsbodQV-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-cQQ1Cu0X0sU-val").dispatchEvent evt
IE.Document.GetElementByID("tnthrE5AclR-ewOK9Oo1KWm-val").dispatchEvent evt
IE.Document.GetElementByID("LZXAdOjlBwi-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("uOfuBlHwdn7-BGFCDhyk4M8-val").dispatchEvent evt
IE.Document.GetElementByID("uOfuBlHwdn7-SBUMYkq3pEs-val").dispatchEvent evt
IE.Document.GetElementByID("uOfuBlHwdn7-er95aeLbIHg-val").dispatchEvent evt
IE.Document.GetElementByID("uOfuBlHwdn7-RFKoE51NKAq-val").dispatchEvent evt
Else
IE.Document.GetElementByID("rTZdUyIFsGy-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-twCITCOvoZA-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-PVCB2tKuVGO-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-bXQKnndJcUy-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-a9IejiMkpxr-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-QrgQR5qqecn-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-qR9wVOZHs3F-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-YXt74Aa7CQB-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-H2d7tWiIX9V-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-zC0EQMShVZc-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-zjd6BsbodQV-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-cQQ1Cu0X0sU-val").dispatchEvent evt
IE.Document.GetElementByID("s0ZhN1hwLa6-ewOK9Oo1KWm-val").dispatchEvent evt
IE.Document.GetElementByID("TcyIxVHZd8I-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("AcTftDyXTzF-BGFCDhyk4M8-val").dispatchEvent evt
IE.Document.GetElementByID("AcTftDyXTzF-SBUMYkq3pEs-val").dispatchEvent evt
IE.Document.GetElementByID("AcTftDyXTzF-er95aeLbIHg-val").dispatchEvent evt
IE.Document.GetElementByID("AcTftDyXTzF-RFKoE51NKAq-val").dispatchEvent evt
End If
End Sub


'TB_ART
Sub TB_ART_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pecRCQ589Ip-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("TXqEC76VtrC-TQTMswJXhmR-val").dispatchEvent evt
IE.Document.GetElementByID("TXqEC76VtrC-CVQ1FRYe4Ra-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("bjpeWBZGkaV-rPO0WWEbKzL-val").dispatchEvent evt
Else
IE.Document.GetElementByID("J0EJi8BhnUC-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("ocBmpbqlNsi-TQTMswJXhmR-val").dispatchEvent evt
IE.Document.GetElementByID("ocBmpbqlNsi-CVQ1FRYe4Ra-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("fhBEkut3R3H-rPO0WWEbKzL-val").dispatchEvent evt
End If
End Sub

'TX_TB
Sub TX_TB_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bO90YLjSbox-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("CEANcO1xqgC-CVQ1FRYe4Ra-val").dispatchEvent evt
IE.Document.GetElementByID("CEANcO1xqgC-TQTMswJXhmR-val").dispatchEvent evt
IE.Document.GetElementByID("fexxrOGUvrv-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("fexxrOGUvrv-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("fexxrOGUvrv-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("fexxrOGUvrv-rtt53W8KwRV-val").dispatchEvent evt
IE.Document.GetElementByID("lo2c9TXkj5X-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("CTStqfWGP5K-s5fJZmqOejY-val").dispatchEvent evt
IE.Document.GetElementByID("CTStqfWGP5K-u6sRGIOBmoh-val").dispatchEvent evt
IE.Document.GetElementByID("CTStqfWGP5K-e2L487QXxft-val").dispatchEvent evt
IE.Document.GetElementByID("CTStqfWGP5K-shTc2NWLhMt-val").dispatchEvent evt
IE.Document.GetElementByID("jWXNXtGEGKn-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("jWXNXtGEGKn-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("jWXNXtGEGKn-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("jWXNXtGEGKn-rtt53W8KwRV-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ZdCidLkGGV4-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("WQowTtUTc97-CVQ1FRYe4Ra-val").dispatchEvent evt
IE.Document.GetElementByID("WQowTtUTc97-TQTMswJXhmR-val").dispatchEvent evt
IE.Document.GetElementByID("G6EQGNhixQe-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("G6EQGNhixQe-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("G6EQGNhixQe-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("G6EQGNhixQe-rtt53W8KwRV-val").dispatchEvent evt
IE.Document.GetElementByID("iBT0uRSIadN-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("cdacTAmnRph-s5fJZmqOejY-val").dispatchEvent evt
IE.Document.GetElementByID("cdacTAmnRph-u6sRGIOBmoh-val").dispatchEvent evt
IE.Document.GetElementByID("cdacTAmnRph-e2L487QXxft-val").dispatchEvent evt
IE.Document.GetElementByID("cdacTAmnRph-shTc2NWLhMt-val").dispatchEvent evt
IE.Document.GetElementByID("QBCFhUL0DsI-mdH8pnWvjf3-val").dispatchEvent evt
IE.Document.GetElementByID("QBCFhUL0DsI-M5tkYhf3wH0-val").dispatchEvent evt
IE.Document.GetElementByID("QBCFhUL0DsI-EinRX4vGJHS-val").dispatchEvent evt
IE.Document.GetElementByID("QBCFhUL0DsI-rtt53W8KwRV-val").dispatchEvent evt
End If
End Sub

'GEND_GBV
Sub GEND_GBV_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pWTXzF2L8lG-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-QdyvOZhmwfP-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-O8VSbT4lhbG-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-lQfjasPsxs3-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-Oz9mfDvGh0n-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-GmlEpQlBZJN-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-O6L8gP01Z7E-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-RRU8Xbcw6m2-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-nW1xLOwJNQ3-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-EMPdzS9xUZs-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-qRPbwt7xN8N-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-dWU2Qc1DBTx-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-zh1RfnjU3nw-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-EaFoYeVKtl1-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-eph8upo4KnI-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-kTLb3E6uG8m-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-njzg2pswvAa-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-l0fUVaWXRTe-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-sIES2ww1feR-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-wt4A4IVhK44-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-GGtPtwWGpuU-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-Cec3GHF5VQZ-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-UwV8YVOEVl3-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-NwrTfkWdED1-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-AH6J0MDYMZ0-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-wVVtzmD5xsT-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-HUNtR6x2i93-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-AGV475enDdO-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-ClVqXFbwu7z-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-YsGSdOrSGvO-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-qS6AUbNJKE8-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-pA604NbnktK-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-EUViVSqSaSx-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-KUP9oCrnXLm-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-VPXUnkqLbb4-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-iam0H1wLzgw-val").dispatchEvent evt
IE.Document.GetElementByID("GT81rJIJrrd-v5rsJlwfzWD-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-m0cv4FpuKcT-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-WZA61w3X97V-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-n3LvtfmkEfp-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-mfOtkXnJkEw-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-Tvu2J5Nr7JF-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-WJKtglKn0DE-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-YjCsCWpQVob-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-MytUkuWfSju-val").dispatchEvent evt
IE.Document.GetElementByID("owIr2CJUbwq-hiHSrG29erB-val").dispatchEvent evt
Else
IE.Document.GetElementByID("sIagQEZjSyy-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-QdyvOZhmwfP-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-O8VSbT4lhbG-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-lQfjasPsxs3-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-Oz9mfDvGh0n-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-GmlEpQlBZJN-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-O6L8gP01Z7E-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-RRU8Xbcw6m2-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-nW1xLOwJNQ3-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-EMPdzS9xUZs-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-qRPbwt7xN8N-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-dWU2Qc1DBTx-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-zh1RfnjU3nw-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-EaFoYeVKtl1-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-eph8upo4KnI-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-kTLb3E6uG8m-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-njzg2pswvAa-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-l0fUVaWXRTe-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-sIES2ww1feR-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-wt4A4IVhK44-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-GGtPtwWGpuU-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-Cec3GHF5VQZ-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-UwV8YVOEVl3-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-NwrTfkWdED1-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-AH6J0MDYMZ0-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-wVVtzmD5xsT-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-HUNtR6x2i93-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-AGV475enDdO-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-ClVqXFbwu7z-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-YsGSdOrSGvO-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-qS6AUbNJKE8-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-pA604NbnktK-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-EUViVSqSaSx-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-KUP9oCrnXLm-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-VPXUnkqLbb4-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-iam0H1wLzgw-val").dispatchEvent evt
IE.Document.GetElementByID("pKH3YTAShEe-v5rsJlwfzWD-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-m0cv4FpuKcT-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-WZA61w3X97V-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-n3LvtfmkEfp-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-mfOtkXnJkEw-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-Tvu2J5Nr7JF-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-WJKtglKn0DE-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-YjCsCWpQVob-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-MytUkuWfSju-val").dispatchEvent evt
IE.Document.GetElementByID("OZ9CHCMYJMS-hiHSrG29erB-val").dispatchEvent evt
End If
End Sub

'FPINT_SITE
Sub FPINT_SITE_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").dispatchEvent evt
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").dispatchEvent evt
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").dispatchEvent evt
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").dispatchEvent evt
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").dispatchEvent evt
End Sub

'TX_RET
Sub TX_RET_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KLHpJzK1SLy-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("Pxf0TEEIZFl-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("BnlDGvdjpYH-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("I9MO0VAFjar-vxBSF1mguas-val").dispatchEvent evt
IE.Document.GetElementByID("I9MO0VAFjar-jaxEUorPKgv-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("MOtGVQLwYmA-rPO0WWEbKzL-val").dispatchEvent evt
IE.Document.GetElementByID("VX3vV0hBeLy-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("LRovH4RfPxL-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("pnXn5yTXLvG-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("aal61UVcc5M-vxBSF1mguas-val").dispatchEvent evt
IE.Document.GetElementByID("aal61UVcc5M-jaxEUorPKgv-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("g6VQiVnU01o-rPO0WWEbKzL-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ZOU9pal2R3w-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("KWmsoOySlvp-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("bOnCafw9zhe-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("HdRYfCJUfsc-vxBSF1mguas-val").dispatchEvent evt
IE.Document.GetElementByID("HdRYfCJUfsc-jaxEUorPKgv-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("gmR0FxXhLyl-rPO0WWEbKzL-val").dispatchEvent evt
IE.Document.GetElementByID("SmaMR3maQMj-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("BWkdrGCoKhQ-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("X2m1PXxPAQe-LVcCRCAVjwj-val").dispatchEvent evt
IE.Document.GetElementByID("UGj6ot4NTm7-vxBSF1mguas-val").dispatchEvent evt
IE.Document.GetElementByID("UGj6ot4NTm7-jaxEUorPKgv-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-fYknd2lPzAm-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-CtnbWoya5d5-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-J7mbG9jKSpr-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-Ek2cTSEcl3p-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-zpiyTuKQQ2e-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-RED4BPdFO11-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-LljzDYxQ1Ga-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-TEgIyIVs5JA-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-F0cTl1AAJxz-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-lA60kBSujWH-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-S4urVfq4oVX-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-h5FQFklI9Vn-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-QNulEjcSLQT-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-iIZEtL6l6Hb-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-aQHB69TmOWe-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-T9kxtfDL0pn-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-cci2MH041nc-val").dispatchEvent evt
IE.Document.GetElementByID("ASBT43khvwp-rPO0WWEbKzL-val").dispatchEvent evt
End if
End Sub

'TX_PVLS
Sub TX_PVLS_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YQEFlW4vClz-lrJpKytkH7X-val").dispatchEvent evt
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").dispatchEvent evt
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-rkwWK8ELyYU-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-hHxtViWO56T-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-UGGi61VnaqU-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-iXIVm6C4tQq-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-zuJWcV2btWA-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-t6R7R9nTSKv-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-zl1GE91eGuB-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-M0IcDbmPyYm-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-oFMd0CIZhzb-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-pjlv85PehPp-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-WoCAr4g8sj6-val").dispatchEvent evt
IE.Document.GetElementByID("YvPOllVtINQ-oyrsEQWocsY-val").dispatchEvent evt
IE.Document.GetElementByID("baOWBUVWsx0-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("NtwSTwGUYzt-lrJpKytkH7X-val").dispatchEvent evt
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").dispatchEvent evt
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-rkwWK8ELyYU-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-hHxtViWO56T-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-UGGi61VnaqU-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-iXIVm6C4tQq-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-zuJWcV2btWA-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-t6R7R9nTSKv-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-zl1GE91eGuB-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-M0IcDbmPyYm-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-oFMd0CIZhzb-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-pjlv85PehPp-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-WoCAr4g8sj6-val").dispatchEvent evt
IE.Document.GetElementByID("kznQBykTtJt-oyrsEQWocsY-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ptcrUFB3k5M-lrJpKytkH7X-val").dispatchEvent evt
IE.Document.GetElementByID("pICN9lMKMAl-poFe6w8ZgCs-val").dispatchEvent evt
IE.Document.GetElementByID("pICN9lMKMAl-k78k8hp9kxN-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-rkwWK8ELyYU-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-hHxtViWO56T-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-UGGi61VnaqU-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-iXIVm6C4tQq-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-zuJWcV2btWA-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-t6R7R9nTSKv-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-zl1GE91eGuB-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-M0IcDbmPyYm-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-oFMd0CIZhzb-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-pjlv85PehPp-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-WoCAr4g8sj6-val").dispatchEvent evt
IE.Document.GetElementByID("MylJht530Cc-oyrsEQWocsY-val").dispatchEvent evt
IE.Document.GetElementByID("MMWrCwgC4yq-HllvX50cXC0-val").dispatchEvent evt
IE.Document.GetElementByID("YCJoGPP9akp-lrJpKytkH7X-val").dispatchEvent evt
IE.Document.GetElementByID("PsGw5Fibj3P-poFe6w8ZgCs-val").dispatchEvent evt
IE.Document.GetElementByID("PsGw5Fibj3P-k78k8hp9kxN-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-rkwWK8ELyYU-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-hHxtViWO56T-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-UGGi61VnaqU-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-iXIVm6C4tQq-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-zuJWcV2btWA-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-t6R7R9nTSKv-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-zl1GE91eGuB-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-M0IcDbmPyYm-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-oFMd0CIZhzb-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-pjlv85PehPp-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-WoCAr4g8sj6-val").dispatchEvent evt
IE.Document.GetElementByID("alP4jHSfacs-oyrsEQWocsY-val").dispatchEvent evt
End if
End Sub

'HRH
Sub HRH_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-DOwfGvVn9ck-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-ua5IEJcXKSZ-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-gM511Ccfn0j-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").dispatchEvent evt
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").dispatchEvent evt
IE.Document.GetElementByID("Kk4CdspETNQ-mkOfrTuz7tS-val").dispatchEvent evt
IE.Document.GetElementByID("Kk4CdspETNQ-j2gebSicoa8-val").dispatchEvent evt
IE.Document.GetElementByID("Kk4CdspETNQ-oaRfTQD4RLG-val").dispatchEvent evt
IE.Document.GetElementByID("Kk4CdspETNQ-itxIkeWqiE9-val").dispatchEvent evt
IE.Document.GetElementByID("Kk4CdspETNQ-a9N5X73zhET-val").dispatchEvent evt
IE.Document.GetElementByID("Kk4CdspETNQ-wKH5X6oHquw-val").dispatchEvent evt
End Sub

'LAB_PTCQI
Sub LAB_PTCQI_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").dispatchEvent evt
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").dispatchEvent evt
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").dispatchEvent evt
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").dispatchEvent evt
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").dispatchEvent evt
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").dispatchEvent evt
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").dispatchEvent evt
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").dispatchEvent evt
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").dispatchEvent evt
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").dispatchEvent evt
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").dispatchEvent evt
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").dispatchEvent evt
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").dispatchEvent evt 
End Sub

Sub SendEmailNotification()

    On Error GoTo Err

    Dim NewMail As Object
    Dim mailConfig As Object
    Dim fields As Variant
    Dim msConfigURL As String

    Set NewMail = CreateObject("CDO.Message")
    Set mailConfig = CreateObject("CDO.Configuration")

    ' load all default configurations
    mailConfig.Load -1

    Set fields = mailConfig.fields

    'Set All Email Properties
    With NewMail
        .Subject = "[DHIS-FGH/DATIM] Notificação de digitação automática completa (Facility)"
        .From = "dhis.fgh@gmail.com"
        .To = ""
        .CC = ""
        .BCC = "damasceno.lopes@fgh.org.mz;prosperino.mbalame@fgh.org.mz"
        .HTMLBody = "<table width=420><tr><td colspan='2' style='background-color:#D3D3D3;'>Notificação de digitação automática completa no DATIM</td></tr><tr><td colspan='2'>" & FormProgressBar.LabelCaption & "</td></tr><tr><td colspan='2'>" & FormProgressBar.LabelUserInfo & "</td></tr><tr><td colspan='2'>" & FormProgressBar.LabelUserAgentInfo & "</td></tr><tr><td colspan='2'>" & FormProgressBar.CheckBox1.Caption & "</td></tr><tr><td colspan='2'>" & FormProgressBar.CheckBox2.Caption & "</td></tr><tr><td colspan='2'>" & ThisWorkbook.Sheets("sheet1").Range("A4") & "</td></tr><tr><td>Unidades Organizacionais<br>digitadas:</td><td>" & ouList & "</td></tr><tr><td colspan='2'>" & Year(Now()) & " &copy; <a href='mailto:sis@fgh.org.mz'>sis@fgh.org.mz</a><br><i>Gerado automaticamente por VBA em " & Now & ".</i></td></tr></table>"
    End With

    msConfigURL = "http://schemas.microsoft.com/cdo/configuration"

    With fields
        'Enable SSL Authentication
        .Item(msConfigURL & "/smtpusessl") = True

        'Make SMTP authentication Enabled=true (1)
        .Item(msConfigURL & "/smtpauthenticate") = 1

        'Set the SMTP server and port Details
        'To get these details you can get on Settings Page of your Gmail Account
        .Item(msConfigURL & "/smtpserver") = "smtp.gmail.com"
        .Item(msConfigURL & "/smtpserverport") = 465
        .Item(msConfigURL & "/sendusing") = 2

        'Set your credentials of your Gmail Account
        .Item(msConfigURL & "/sendusername") = "dhis.fgh@gmail.com"
        .Item(msConfigURL & "/sendpassword") = "Pepfar2014"

        'Update the configuration fields
        .Update

    End With
    NewMail.Configuration = mailConfig
    NewMail.Send
    MsgBox "Dados enviados para o DATIM com sucesso!", vbInformation, "FGH-SIS"

Exit_Err:

    Set NewMail = Nothing
    Set mailConfig = Nothing
    End

Err:
    Select Case Err.Number

    Case -2147220973  'Could be because of Internet Connection
        MsgBox " Could be no Internet Connection !!  -- " & Err.Description

    Case -2147220975  'Incorrect credentials User ID or password
        MsgBox "Incorrect Credentials !!  -- " & Err.Description

    Case Else   'Rest other errors
        MsgBox "Error occured while sending the email !!  -- " & Err.Description
    End Select

    Resume Exit_Err

End Sub