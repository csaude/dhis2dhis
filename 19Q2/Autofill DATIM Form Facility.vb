' Copyright (C) 2017-2019, Friends in Global Health, LLC
' All rights reserved.

' This code allows a DATIM end user to automatically fill out the
' MER Results: Facility Based form for a specific quarterly period and
' Organizational Units. This code works with MS Excel file

'--------------------------------------------------------------------
'                             INSTRUCTIONS
'--------------------------------------------------------------------

' Before run this Macro make sure to login using internet explorer in 
' DATIM with Data Entry previleges, this approach only works with the Internet Explorer browser

Public IE As Object
Public ouList As String
Public fillDuration As Date
Public fillDuration2 As Date
Public lastRow As Long
Public startTime2 As Date
Public endTime2 As Date

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

Dim toComplete As Single
Dim startTime As Date
Dim endTime As Date

'FormProgressBar is Mandatory to use this code
FormProgressBar.LabelProgress.Width = 0
FormProgressBar.Label3.Caption = Now
startTime = Now
FormProgressBar.LabelCaption = "Preparando para digitar dados..."
FormProgressBar.LabelUserInfo = Environ("Username")
FormProgressBar.LabelUserAgentInfo = Environ("COMPUTERNAME") & ", " & Environ("OS") & ", " & Environ("PROCESSOR_ARCHITECTURE") & ", " & Environ("NUMBER_OF_PROCESSORS") & " CPU"
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

'30 seconds to ensure that the page loads all HTML/CSS/JS components
Application.Wait Now + TimeValue("00:00:30")

'Element that allows Org Unit selection
IE.Document.all.Item

Dim i As Integer
i = 1

'Possible to run over 1000 Health Facilities, change if overflow
Do While i < 1000

If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("A10")) Then
'End process if find line with blank Org Unit
i = i + 1000
FormProgressBar.Hide
Else

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("AGG10")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AGG10")) Then
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
    Call IE.Document.parentWindow.execScript("javascript:void selection.select( '" & ThisWorkbook.Sheets("sheet1").Range("AGG10") & "' )", "JavaScript")
    startTime2 = Now
    Application.Wait Now + TimeValue("00:00:30")
    
    'Select the Dataset and Period only at 1st time
    If i = 1 Then
    Set evt = IE.Document.createEvent("HTMLEvents")
    evt.initEvent "change", True, False
    'Select Dataset
    IE.Document.GetElementByID("selectedDataSetId").Value = "KWRj80vEfHU"
    IE.Document.GetElementByID("selectedDataSetId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:04")
    'Select the Period
    'Call IE.Document.parentWindow.execScript("previousPeriodsSelected()", "JavaScript")
    'Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("selectedPeriodId").Value = "2019Q1"
    IE.Document.GetElementByID("selectedPeriodId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:30")
    End If

    '--------------------------------------------------------------------
    '                        CALL FUNCTIONS
    '--------------------------------------------------------------------
    'PREVENTION
    'Select TAB
    IE.Document.GetElementByID("ui-id-2").Click
    Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("ui-id-7").Click
    Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    'Semiannually
    Call PrEP_NEW
    Call PrEP_CURR
    Call TB_PREV

    'TESTING
    'Select TAB
    IE.Document.GetElementByID("ui-id-3").Click
    Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("ui-id-10").Click
    Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call PICT_Inpatient
    Call PICT_Pediatric
    Call PICT_PostANC
    Call PICT_Emergency
    Call PICT_Other
    Call VCT
    Call HTS_Index
    Call PMTCT_STAT
    Call PMTCT_EID_HEI_POS
    Call TB_STAT
    'Semiannually
    Call CXCA_SCRN

    'TREATMENT
    'Select TAB
    IE.Document.GetElementByID("ui-id-4").Click
    Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("ui-id-12").Click
    Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call TX_NEW
    Call TX_CURR
    Call PMTCT_ART
    Call TB_ART
    'Semiannualy
    Call TX_ML
    Call TX_TB
    Call CXCA_TX

    'VIRAL SUPRESSION
    'Select TAB
    IE.Document.GetElementByID("ui-id-5").Click
    Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("ui-id-14").Click
    Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call TX_PVLS
    'Semiannually

    'Send E-mail notification
    'Calculate the total duration time
    endTime2 = Now
    fillDuration2 = endTime2 - startTime2
    Call SendEmailNotification
    Application.Wait Now + TimeValue("00:00:05")
    'Next HF
    ThisWorkbook.Sheets("sheet1").Rows(10).EntireRow.Delete
    Application.Wait Now + TimeValue("00:00:10")

End If
    
i = i + 1

End If
Loop

MsgBox "Dados enviados para o DATIM com sucesso!", vbInformation, "FGH-SIS"

'Calculate the total duration time
endTime = Now
fillDuration = endTime - startTime
FormProgressBar.CheckBox2.Value = True
FormProgressBar.Label5.Caption = Now 
'& ", Duração: " & Format(fillDuration, "hh") & ":" & Format(fillDuration, "nn:ss")

End Sub


' IIIII                                  ttt  iiii                       ttt  
' IIIII                                 tttt  iiii                      tttt  
' IIIII                                 tttt                            tttt  
' IIIII nnnnnnnn  ppppppppp    aaaaaa aatttttiiiii  eeeeee   nnnnnnnn nntttt  
' IIIII nnnnnnnnn pppppppppp  aaaaaaaaaatttttiiiii eeeeeeee  nnnnnnnnnnntttt  
' IIIII nnnn nnnnnppppp pppppaaaa aaaaa tttt  iiiieeee eeee  nnnn nnnnn tttt  
' IIIII nnnn  nnnnpppp   pppp    aaaaaa tttt  iiiieeee  eeee nnnn  nnnn tttt  
' IIIII nnnn  nnnnpppp   pppp aaaaaaaaa tttt  iiiieeeeeeeeee nnnn  nnnn tttt  
' IIIII nnnn  nnnnpppp   ppppaaaaaaaaaa tttt  iiiieeeeeeeeee nnnn  nnnn tttt  
' IIIII nnnn  nnnnpppp   ppppaaaa aaaaa tttt  iiiieeee       nnnn  nnnn tttt  
' IIIII nnnn  nnnnppppp pppppaaaa aaaaa tttt  iiiieeee  eeee nnnn  nnnn tttt  
' IIIII nnnn  nnnnpppppppppp aaaaaaaaaa tttttiiiii eeeeeeee  nnnn  nnnn tttt  
' IIIII nnnn  nnnnppppppppp   aaaaaaaaa tttttiiiii  eeeeee   nnnn  nnnn tttt  
'                 pppp                                                        
'                 pppp                                                        
'                 pppp                                                        
'                 pppp                               
Sub PICT_Inpatient()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("G10")) Then
'<1,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("G10")
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("O10")
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("P10")
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("S10")
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("T10")
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("U10")
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("V10")
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AF10")
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("AG10")
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AH10")
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("AI10")
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' PPPPPPPPP                   dddd diii            ttt         riii            ttt   
' PPPPPPPPPP                  dddd diii           attt         riii           cttt   
' PPPPPPPPPPP                 dddd                attt                        cttt   
' PPPP   PPPP  eeeeee    ddddddddd diii  aaaaaa aaattttttrrrrrrriii  cccccc ccctttt  
' PPPP   PPPP Peeeeeee  eddddddddd diii iaaaaaaaaaattttttrrrrrrriii icccccccccctttt  
' PPPPPPPPPPPPPee eeee eeddd ddddd diiiiiaa aaaaa attt ttrrr   riiiiiccc cccc cttt   
' PPPPPPPPPP PPee  eeeeeedd   dddd diii    aaaaaa attt ttrr    riiiiicc  ccc  cttt   
' PPPPPPPPP  PPeeeeeeeeeedd   dddd diii iaaaaaaaa attt ttrr    riiiiicc       cttt   
' PPPP       PPeeeeeeeeeedd   dddd diiiiiaaaaaaaa attt ttrr    riiiiicc       cttt   
' PPPP       PPee      eedd   dddd diiiiiaa aaaaa attt ttrr    riiiiicc  ccc  cttt   
' PPPP       PPee  eeeeeeddd ddddd diiiiiaa aaaaa attt ttrr    riiiiiccc cccc cttt   
' PPPP        Peeeeeee  eddddddddd diiiiiaaaaaaaa attttttrr    riii icccccccc ctttt  
' PPPP         eeeeee    ddddddddd diii iaaaaaaaa attttttrr    riii  cccccc   ctttt   
Sub PICT_Pediatric()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AU10")) Then
'1-4,F,Positive
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Negative
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Positive
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AW10")
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Negative
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("AX10")
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' PPPPPPPPP                         ttt          AAAAA     ANNN   NNNN    CCCCCCC     
' PPPPPPPPPP                       sttt          AAAAA     ANNNN  NNNN   CCCCCCCCC    
' PPPPPPPPPPP                      sttt         AAAAAA     ANNNN  NNNN  NCCCCCCCCCC   
' PPPP   PPPP   oooooo   ossssss sssttttt       AAAAAAA    ANNNNN NNNN  NCCC   CCCCC  
' PPPP   PPPP Poooooooo oossssssssssttttt      AAAAAAAA    ANNNNN NNNN NNCC     CCC   
' PPPPPPPPPPP Pooo oooooooss ssss  sttt        AAAAAAAA    ANNNNNNNNNN NNCC           
' PPPPPPPPPP PPoo   oooooosss      sttt        AAAA AAAA   ANNNNNNNNNN NNCC           
' PPPPPPPPP  PPoo   oooo osssss    sttt        AAAAAAAAA   ANNNNNNNNNN NNCC           
' PPPP       PPoo   oooo  sssssss  sttt        AAAAAAAAAA  ANNNNNNNNNN NNCC     CCC   
' PPPP       PPoo   oooo      ssss sttt        AAAAAAAAAA  ANNN NNNNNN  NCCC   CCCCC  
' PPPP        Pooo oooooooss  ssss sttt       AA    AAAA  ANNN  NNNNN  NCCCCCCCCCC   
' PPPP        Poooooooo oosssssss  sttttt     AA     AAAA ANNN  NNNNN   CCCCCCCCCC   
' PPPP          oooooo    ssssss   sttttt    AA     AAAA ANNN   NNNN    CCCCCCC  
Sub PICT_PostANC()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("BC10")) Then
'10-14,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").Value = ThisWorkbook.Sheets("sheet1").Range("BH10")
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").Value = ThisWorkbook.Sheets("sheet1").Range("BI10")
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").Value = ThisWorkbook.Sheets("sheet1").Range("BJ10")
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").Value = ThisWorkbook.Sheets("sheet1").Range("BK10")
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").Value = ThisWorkbook.Sheets("sheet1").Range("BL10")
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("BM10")
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").Value = ThisWorkbook.Sheets("sheet1").Range("BN10")
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").Value = ThisWorkbook.Sheets("sheet1").Range("BO10")
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("BP10")
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").Value = ThisWorkbook.Sheets("sheet1").Range("BQ10")
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").Value = ThisWorkbook.Sheets("sheet1").Range("BR10")
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BS10")
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").Value = ThisWorkbook.Sheets("sheet1").Range("BT10")
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' EEEEEEEEEEE                                                                                       
' EEEEEEEEEEE                                                                                       
' EEEEEEEEEEE                                                                                       
' EEEE       EEmmmmmmmmmmmm    eeeeee  eerrrrrr ggggggggg  eeeeee   ennnnnnn    cccccc cccy   yyyy  
' EEEE       EEmmmmmmmmmmmmm  meeeeeee eerrrrrrrggggggggg geeeeeee  ennnnnnnn  nccccccc ccyy  yyyy  
' EEEEEEEEEE EEmmm mmmmmmmmm mmee eeee eerrr  rrggg gggggggee eeee  ennn nnnnnnnccc ccccccyy  yyyy  
' EEEEEEEEEE EEmm  mmmm  mmmmmmee  eeeeeerr   rrgg   ggggggee  eeee ennn  nnnnnncc  ccc ccyy yyyy   
' EEEEEEEEEE EEmm  mmmm  mmmmmmeeeeeeeeeerr   rrgg   ggggggeeeeeeee ennn  nnnnnncc       cyyyyyyy   
' EEEE       EEmm  mmmm  mmmmmmeeeeeeeeeerr   rrgg   ggggggeeeeeeee ennn  nnnnnncc       cyyyyyy    
' EEEE       EEmm  mmmm  mmmmmmee      eerr   rrgg   ggggggee       ennn  nnnnnncc  ccc   yyyyyy    
' EEEEEEEEEEEEEmm  mmmm  mmmmmmee  eeeeeerr   rrggg gggggggee  eeee ennn  nnnnnnccc cccc  yyyyyy    
' EEEEEEEEEEEEEmm  mmmm  mmmm meeeeeee eerr    rggggggggg geeeeeee  ennn  nnnn ncccccccc  yyyyy     
' EEEEEEEEEEEEEmm  mmmm  mmmm  eeeeee  eerr     ggggggggg  eeeeee   ennn  nnnn  cccccc     yyyy     
'                                                    gggg                                  yyyy     
'                                             rrggg gggg                                  yyyy      
'                                              rgggggggg                                ccyyyy      
'                                               ggggggg                                 ccyyy       
Sub PICT_Emergency()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("BU10")) Then
'<1,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("BU10")
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("BV10")
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("BW10")
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("BX10")
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BY10")
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("BZ10")
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CA10")
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("CB10")
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("CC10")
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("CD10")
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("CE10")
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("CF10")
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("CG10")
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CH10")
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CI10")
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("CJ10")
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("CK10")
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("CL10")
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("CM10")
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("CN10")
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("CO10")
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("CP10")
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("CQ10")
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("CR10")
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("CS10")
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("CT10")
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("CU10")
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("CV10")
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("CW10")
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("CX10")
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("CY10")
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("CZ10")
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("DA10")
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("DB10")
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("DC10")
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("DD10")
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

'    OOOOOOO      ttt  hhhh                         
'   OOOOOOOOOO   tttt  hhhh                         
'  OOOOOOOOOOOO  tttt  hhhh                         
'  OOOOO  OOOOOOOttttthhhhhhhhh    eeeeee  errrrrr  
' OOOOO    OOOOOOttttthhhhhhhhhh  eeeeeeee errrrrr  
' OOOO      OOOO tttt  hhhh hhhhheeee eeee errrr    
' OOOO      OOOO tttt  hhhh  hhhheeee  eeeeerrr     
' OOOO      OOOO tttt  hhhh  hhhheeeeeeeeeeerrr     
' OOOOO    OOOOO tttt  hhhh  hhhheeeeeeeeeeerrr     
'  OOOOO  OOOOO  tttt  hhhh  hhhheeee      errr     
'  OOOOOOOOOOOO  tttt  hhhh  hhhheeee  eeeeerrr     
'   OOOOOOOOOO   ttttthhhhh  hhhh eeeeeeee errr     
'     OOOOOO     ttttthhhhh  hhhh  eeeeee  errr   
Sub PICT_Other()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("DG10")) Then
'Unknown age,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").Value = ThisWorkbook.Sheets("sheet1").Range("DG10")
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Unknown age,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DH10")
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("DI10")
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("DJ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("DK10")
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("DL10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("DM10")
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("DN10")
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DO10")
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("DP10")
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("DQ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("DR10")
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("DS10")
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DT10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("DU10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DV10")
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DW10")
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("DX10")
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("DY10")
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("DZ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("EA10")
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("EB10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("EC10")
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ED10")
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("EE10")
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("EF10")
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("EG10")
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("EH10")
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("EI10")
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("EJ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("EK10")
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("EL10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("EM10")
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("EN10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("EO10")
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("EP10")
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("EQ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ER10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' VVVV    VVVVV  CCCCCCC    TTTTTTTTTT  
' VVVV    VVVV  CCCCCCCCC   TTTTTTTTTT  
' VVVV    VVVV CCCCCCCCCCC  TTTTTTTTTT  
' VVVVV  VVVV  CCCC   CCCCC    TTTT     
'  VVVV  VVVV VCCC     CCC     TTTT     
'  VVVV  VVVV VCCC             TTTT     
'  VVVVVVVVV  VCCC             TTTT     
'   VVVVVVVV  VCCC             TTTT     
'   VVVVVVVV  VCCC     CCC     TTTT     
'   VVVVVVV    CCCC   CCCCC    TTTT     
'    VVVVVV    CCCCCCCCCCC     TTTT     
'    VVVVVV     CCCCCCCCCC     TTTT     
'    VVVVV       CCCCCCC       TTTT     
Sub VCT()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ES10")) Then
'<1,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ES10")
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("ET10")
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("EU10")
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("EV10")
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("EW10")
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("EX10")
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EY10")
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("EZ10")
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("FA10")
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("FB10")
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("FC10")
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("FD10")
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("FE10")
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FF10")
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FG10")
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("FH10")
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("FI10")
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("FJ10")
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("FK10")
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("FL10")
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("FM10")
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("FN10")
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("FO10")
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("FP10")
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("FQ10")
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("FR10")
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("FS10")
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("FT10")
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("FU10")
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("FV10")
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("FW10")
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("FX10")
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("FY10")
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("FZ10")
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("GA10")
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("GB10")
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' HHHH   HHHH  TTTTTTTTTTT SSSSSSS         III                  dddd                      
' HHHH   HHHH  TTTTTTTTTTTSSSSSSSSS        III                  dddd                      
' HHHH   HHHH  TTTTTTTTTTTSSSSSSSSSS       III                  dddd                      
' HHHH   HHHH     TTTT   TSSSS  SSSS       III Innnnnnn    ddddddddd  eeeeee  eexx  xxxx  
' HHHH   HHHH     TTTT   TSSSS             III Innnnnnnn  dddddddddd eeeeeeee  exxxxxxx   
' HHHHHHHHHHH     TTTT    SSSSSSS          III Innn nnnnnndddd ddddddeee eeee  exxxxxxx   
' HHHHHHHHHHH     TTTT     SSSSSSSSS       III Innn  nnnnnddd   dddddeee  eeee  xxxxxx    
' HHHHHHHHHHH     TTTT       SSSSSSS       III Innn  nnnnnddd   dddddeeeeeeeee   xxxx     
' HHHH   HHHH     TTTT          SSSSS      III Innn  nnnnnddd   dddddeeeeeeeee  xxxxxx    
' HHHH   HHHH     TTTT   TSSS    SSSS      III Innn  nnnnnddd   dddddeee        xxxxxx    
' HHHH   HHHH     TTTT   TSSSSSSSSSSS      III Innn  nnnnndddd ddddddeee  eeee exxxxxxx   
' HHHH   HHHH     TTTT    SSSSSSSSSS       III Innn  nnnn dddddddddd eeeeeeee eexxxxxxxx  
' HHHH   HHHH     TTTT     SSSSSSSS        III Innn  nnnn  ddddddddd  eeeeee  eexx  xxxx  
Sub HTS_Index()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

'DHIS
'If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("GC10")) Then
'Offered
'Unknown age,F
'IE.Document.GetElementByID("JuMoiYn1jKB-FUaRzF095hM-val").Focus
'IE.Document.GetElementByID("JuMoiYn1jKB-FUaRzF095hM-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
'IE.Document.GetElementByID("JuMoiYn1jKB-FUaRzF095hM-val").dispatchEvent evt
'Application.Wait Now + TimeValue("00:00:01")
'10-14,F
'IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Focus
'IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("GG10")
'IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").dispatchEvent evt
'Application.Wait Now + TimeValue("00:00:01")
'15-19,F
'IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Focus
'IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("GH10")
'IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").dispatchEvent evt
'Application.Wait Now + TimeValue("00:00:01")
'20-24,F
'IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Focus
'IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("GI10")
'IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").dispatchEvent evt
'Application.Wait Now + TimeValue("00:00:01")
'25-29,F
'IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Focus
'IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("GJ10")
'IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").dispatchEvent evt
'Application.Wait Now + TimeValue("00:00:01")
'End If

'OpenMRS
'Offered
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("GD10")) Then
'<1,F
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("GD10")
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                               
'1-4,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("GE10")
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")   
'5-9,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("GF10")
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'10-14,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("GG10")
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")      
'15-19,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("GH10")
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")  
'20-24,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("GI10")
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")  
'25-29,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("GJ10")
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'30-34,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("GK10")
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")  
'35-39,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("GL10")
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'40-44,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("GM10")
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01") 
'45-49,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("GN10")
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'50+,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("GO10")
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")                                             
'<1,M                                                                                                   
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("GQ10")
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                      
'1-4,M                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("GR10")
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                                 
'5-9,M                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("GS10")
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                        
'10-14,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("GT10")
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                               
'15-19,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("GU10")
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                              
'20-24,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("GV10")
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                                
'25-29,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("GW10")
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                           
'30-34,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("GX10")
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                           
'35-39,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("GY10")
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                             
'40-44,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("GZ10")
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                              
'45-49,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("HA10")
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,M
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("HB10")
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If

'Accepted
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("HD10")) Then
'<1,F
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HD10")
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                               
'1-4,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("HE10")
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")   
'5-9,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("HF10")
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'10-14,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("HG10")
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")      
'15-19,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("HH10")
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")  
'20-24,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("HI10")
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")  
'25-29,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("HJ10")
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'30-34,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("HK10")
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")  
'35-39,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("HL10")
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'40-44,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("HM10")
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01") 
'45-49,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("HN10")
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")    
'50+,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("HO10")
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")                                             
'<1,M                                                                                                   
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("HQ10")
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                      
'1-4,M                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("HR10")
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                                 
'5-9,M                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("HS10")
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                        
'10-14,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("HT10")
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                               
'15-19,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HU10")
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                              
'20-24,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("HV10")
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                                
'25-29,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("HW10")
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                           
'30-34,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("HX10")
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                           
'35-39,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HY10")
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                             
'40-44,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("HZ10")
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                                                                              
'45-49,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("IA10")
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,M
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("IB10")
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ID10")) Then
'Elicited
'Unknown age,M
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,F,
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,M
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,F
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,M
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New Positives
'Unknown age,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").Value = ThisWorkbook.Sheets("sheet1").Range("IM10")
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").Value = ThisWorkbook.Sheets("sheet1").Range("IN10")
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").Value = ThisWorkbook.Sheets("sheet1").Range("IO10")
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("IP10")
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").Value = ThisWorkbook.Sheets("sheet1").Range("IQ10")
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").Value = ThisWorkbook.Sheets("sheet1").Range("IR10")
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").Value = ThisWorkbook.Sheets("sheet1").Range("IS10")
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("IT10")
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").Value = ThisWorkbook.Sheets("sheet1").Range("IU10")
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").Value = ThisWorkbook.Sheets("sheet1").Range("IV10")
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("IW10")
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").Value = ThisWorkbook.Sheets("sheet1").Range("IX10")
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("IY10")
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").Value = ThisWorkbook.Sheets("sheet1").Range("IZ10")
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").Value = ThisWorkbook.Sheets("sheet1").Range("JA10")
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").Value = ThisWorkbook.Sheets("sheet1").Range("JB10")
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").Value = ThisWorkbook.Sheets("sheet1").Range("JC10")
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JD10")
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").Value = ThisWorkbook.Sheets("sheet1").Range("JE10")
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New Negatives
'Unknown age,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").Value = ThisWorkbook.Sheets("sheet1").Range("JF10")
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").Value = ThisWorkbook.Sheets("sheet1").Range("JG10")
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("JH10")
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").Value = ThisWorkbook.Sheets("sheet1").Range("JI10")
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").Value = ThisWorkbook.Sheets("sheet1").Range("JJ10")
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("JK10")
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").Value = ThisWorkbook.Sheets("sheet1").Range("JL10")
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").Value = ThisWorkbook.Sheets("sheet1").Range("JM10")
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").Value = ThisWorkbook.Sheets("sheet1").Range("JN10")
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").Value = ThisWorkbook.Sheets("sheet1").Range("JO10")
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").Value = ThisWorkbook.Sheets("sheet1").Range("JP10")
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").Value = ThisWorkbook.Sheets("sheet1").Range("JQ10")
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").Value = ThisWorkbook.Sheets("sheet1").Range("JR10")
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").Value = ThisWorkbook.Sheets("sheet1").Range("JS10")
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").Value = ThisWorkbook.Sheets("sheet1").Range("JT10")
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JU10")
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").Value = ThisWorkbook.Sheets("sheet1").Range("JV10")
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").Value = ThisWorkbook.Sheets("sheet1").Range("JW10")
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").Value = ThisWorkbook.Sheets("sheet1").Range("JX10")
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' PPPPPPPPP  PPMMMM   MMMMMM TTTTTTTTTTT  CCCCCCC    TTTTTTTTTTT      SSSSSSS    TTTTTTTTTTT  AAAA    AAATTTTTTT  
' PPPPPPPPPP PPMMMM   MMMMMM TTTTTTTTTTT CCCCCCCCC   TTTTTTTTTTT     SSSSSSSSS   TTTTTTTTTTT AAAAAA   AAATTTTTTT  
' PPPPPPPPPPPPPMMMM   MMMMMM TTTTTTTTTTTCCCCCCCCCCC  TTTTTTTTTTT     SSSSSSSSSS  TTTTTTTTTTT AAAAAA   AAATTTTTTT  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT    CCCC   CCCCC    TTTT         SSSS  SSSS     TTTT     AAAAAAA      TTTT    
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT   TCCC     CCC     TTTT         SSSS           TTTT    AAAAAAAA      TTTT    
' PPPPPPPPPPPPPMMMMM MMMMMMM    TTTT   TCCC             TTTT         SSSSSSS        TTTT    AAAAAAAA      TTTT    
' PPPPPPPPPP PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT          SSSSSSSSS     TTTT    AAAA AAAA     TTTT    
' PPPPPPPPP  PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT            SSSSSSS     TTTT   TAAAAAAAAA     TTTT    
' PPPP       PPMMMMMMMMMMMMM    TTTT   TCCC     CCC     TTTT               SSSSS    TTTT   TAAAAAAAAAA    TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT    CCCC   CCCCC    TTTT         SSS    SSSS    TTTT  TTAAAAAAAAAA    TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT    CCCCCCCCCCC     TTTT         SSSSSSSSSSS    TTTT  TTAA    AAAA    TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT     CCCCCCCCCC     TTTT         SSSSSSSSSS     TTTT  TTAA    AAAAA   TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT      CCCCCCC       TTTT          SSSSSSSS      TTTT TTTAA     AAAA   TTTT    
Sub PMTCT_STAT()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JZ10")) Then
'Numerator
'10-14,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").Value = ThisWorkbook.Sheets("sheet1").Range("JZ10")
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").Value = ThisWorkbook.Sheets("sheet1").Range("KA10")
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").Value = ThisWorkbook.Sheets("sheet1").Range("KB10")
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").Value = ThisWorkbook.Sheets("sheet1").Range("KC10")
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").Value = ThisWorkbook.Sheets("sheet1").Range("KD10")
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").Value = ThisWorkbook.Sheets("sheet1").Range("KE10")
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").Value = ThisWorkbook.Sheets("sheet1").Range("KF10")
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").Value = ThisWorkbook.Sheets("sheet1").Range("KG10")
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").Value = ThisWorkbook.Sheets("sheet1").Range("KH10")
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").Value = ThisWorkbook.Sheets("sheet1").Range("KI10")
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KJ10")
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KK10")
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Denominator
'10-14,F
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").Value = ThisWorkbook.Sheets("sheet1").Range("KM10")
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,F
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("KN10")
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("KO10")
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").Value = ThisWorkbook.Sheets("sheet1").Range("KP10")
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End if
End Sub

' PPPPPPPPP  PPMMMM   MMMMMM TTTTTTTTTTT  CCCCCCC    TTTTTTTTTTT     EEEEEEEEEEEEIIII DDDDDDDDD    
' PPPPPPPPPP PPMMMM   MMMMMM TTTTTTTTTTT CCCCCCCCC   TTTTTTTTTTT     EEEEEEEEEEEEIIII DDDDDDDDDD   
' PPPPPPPPPPPPPMMMM   MMMMMM TTTTTTTTTTTCCCCCCCCCCC  TTTTTTTTTTT     EEEEEEEEEEEEIIII DDDDDDDDDDD  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT    CCCC   CCCCC    TTTT         EEEE       EIIII DDDD   DDDD  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT   TCCC     CCC     TTTT         EEEE       EIIII DDDD    DDD  
' PPPPPPPPPPPPPMMMMM MMMMMMM    TTTT   TCCC             TTTT         EEEEEEEEEE EIIII DDDD    DDD  
' PPPPPPPPPP PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT         EEEEEEEEEE EIIII DDDD    DDD  
' PPPPPPPPP  PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT         EEEEEEEEEE EIIII DDDD    DDD  
' PPPP       PPMMMMMMMMMMMMM    TTTT   TCCC     CCC     TTTT         EEEE       EIIII DDDD    DDD  
' PPPP       PPMM MMMMM MMMM    TTTT    CCCC   CCCCC    TTTT         EEEE       EIIII DDDD   DDDD  
' PPPP       PPMM MMMMM MMMM    TTTT    CCCCCCCCCCC     TTTT         EEEEEEEEEEEEIIII DDDDDDDDDDD  
' PPPP       PPMM MMMMM MMMM    TTTT     CCCCCCCCCC     TTTT         EEEEEEEEEEEEIIII DDDDDDDDDD   
' PPPP       PPMM MMMMM MMMM    TTTT      CCCCCCC       TTTT         EEEEEEEEEEEEIIII DDDDDDDDD    
Sub PMTCT_EID_HEI_POS()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("KR10")) Then
'EID
'0-2
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Value = ThisWorkbook.Sheets("sheet1").Range("KR10")
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'2-12
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Value = ThisWorkbook.Sheets("sheet1").Range("KS10")
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HEI_POS
'0-2
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Value = ThisWorkbook.Sheets("sheet1").Range("KU10")
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'2-12
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("KV10")
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'ART
'0-2
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Value = ThisWorkbook.Sheets("sheet1").Range("KW10")
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'2-12
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Value = ThisWorkbook.Sheets("sheet1").Range("KX10")
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End if
End Sub

' TTTTTTTTTTTBBBBBBBBBB         SSSSSSS    STTTTTTTTTT  AAAA    AAATTTTTTT  
' TTTTTTTTTTTBBBBBBBBBBB       SSSSSSSSS   STTTTTTTTTT AAAAAA   AAATTTTTTT  
' TTTTTTTTTTTBBBBBBBBBBB       SSSSSSSSSS  STTTTTTTTTT AAAAAA   AAATTTTTTT  
'    TTTT    BBBB   BBBB       SSSS  SSSS     TTTT     AAAAAAA      TTTT    
'    TTTT    BBBB   BBBB       SSSS           TTTT    AAAAAAAA      TTTT    
'    TTTT    BBBBBBBBBBB       SSSSSSS        TTTT    AAAAAAAA      TTTT    
'    TTTT    BBBBBBBBBB         SSSSSSSSS     TTTT    AAAA AAAA     TTTT    
'    TTTT    BBBBBBBBBBB          SSSSSSS     TTTT   TAAAAAAAAA     TTTT    
'    TTTT    BBBB    BBBB            SSSSS    TTTT   TAAAAAAAAAA    TTTT    
'    TTTT    BBBB    BBBB      SSS    SSSS    TTTT  TTAAAAAAAAAA    TTTT    
'    TTTT    BBBBBBBBBBBB      SSSSSSSSSSS    TTTT  TTAA    AAAA    TTTT    
'    TTTT    BBBBBBBBBBB       SSSSSSSSSS     TTTT  TTAA    AAAAA   TTTT    
'    TTTT    BBBBBBBBBB         SSSSSSSS      TTTT TTTAA     AAAA   TTTT    
Sub TB_STAT()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("KZ10")) Then
'Known Positives
'<1,F,KP
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").Value = ThisWorkbook.Sheets("sheet1").Range("KZ10")
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,KP
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").Value = ThisWorkbook.Sheets("sheet1").Range("LA10")
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").Value = ThisWorkbook.Sheets("sheet1").Range("LB10")
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").Value = ThisWorkbook.Sheets("sheet1").Range("LC10")
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").Value = ThisWorkbook.Sheets("sheet1").Range("LD10")
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").Value = ThisWorkbook.Sheets("sheet1").Range("LE10")
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").Value = ThisWorkbook.Sheets("sheet1").Range("LF10")
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LG10")
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").Value = ThisWorkbook.Sheets("sheet1").Range("LH10")
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").Value = ThisWorkbook.Sheets("sheet1").Range("LI10")
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("LJ10")
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").Value = ThisWorkbook.Sheets("sheet1").Range("LK10")
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").Value = ThisWorkbook.Sheets("sheet1").Range("LL10")
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").Value = ThisWorkbook.Sheets("sheet1").Range("LM10")
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").Value = ThisWorkbook.Sheets("sheet1").Range("LN10")
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").Value = ThisWorkbook.Sheets("sheet1").Range("LO10")
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").Value = ThisWorkbook.Sheets("sheet1").Range("LP10")
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").Value = ThisWorkbook.Sheets("sheet1").Range("LQ10")
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").Value = ThisWorkbook.Sheets("sheet1").Range("LR10")
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").Value = ThisWorkbook.Sheets("sheet1").Range("LS10")
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").Value = ThisWorkbook.Sheets("sheet1").Range("LT10")
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").Value = ThisWorkbook.Sheets("sheet1").Range("LU10")
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").Value = ThisWorkbook.Sheets("sheet1").Range("LV10")
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,KP
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").Value = ThisWorkbook.Sheets("sheet1").Range("LW10")
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New Positives
'<1,F,NP
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").Value = ThisWorkbook.Sheets("sheet1").Range("LX10")
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,NP
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").Value = ThisWorkbook.Sheets("sheet1").Range("LY10")
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,NP
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("LZ10")
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,NP
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").Value = ThisWorkbook.Sheets("sheet1").Range("MA10")
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").Value = ThisWorkbook.Sheets("sheet1").Range("MB10")
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").Value = ThisWorkbook.Sheets("sheet1").Range("MC10")
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("MD10")
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ME10")
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").Value = ThisWorkbook.Sheets("sheet1").Range("MF10")
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MG10")
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").Value = ThisWorkbook.Sheets("sheet1").Range("MH10")
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MI10")
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MJ10")
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").Value = ThisWorkbook.Sheets("sheet1").Range("MK10")
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").Value = ThisWorkbook.Sheets("sheet1").Range("ML10")
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").Value = ThisWorkbook.Sheets("sheet1").Range("MM10")
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").Value = ThisWorkbook.Sheets("sheet1").Range("MN10")
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MO10")
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").Value = ThisWorkbook.Sheets("sheet1").Range("MP10")
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").Value = ThisWorkbook.Sheets("sheet1").Range("MQ10")
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").Value = ThisWorkbook.Sheets("sheet1").Range("MR10")
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").Value = ThisWorkbook.Sheets("sheet1").Range("MS10")
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").Value = ThisWorkbook.Sheets("sheet1").Range("MT10")
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,NP
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").Value = ThisWorkbook.Sheets("sheet1").Range("MU10")
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New Negatives
'<1,F,NN
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").Value = ThisWorkbook.Sheets("sheet1").Range("MV10")
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<1,M,NN
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("MW10")
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F,NN
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").Value = ThisWorkbook.Sheets("sheet1").Range("MX10")
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,M,NN
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").Value = ThisWorkbook.Sheets("sheet1").Range("MY10")
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F,NN
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("MZ10")
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,M,NN
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").Value = ThisWorkbook.Sheets("sheet1").Range("NA10")
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,NN
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").Value = ThisWorkbook.Sheets("sheet1").Range("NB10")
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").Value = ThisWorkbook.Sheets("sheet1").Range("NC10")
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").Value = ThisWorkbook.Sheets("sheet1").Range("ND10")
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").Value = ThisWorkbook.Sheets("sheet1").Range("NE10")
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").Value = ThisWorkbook.Sheets("sheet1").Range("NF10")
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").Value = ThisWorkbook.Sheets("sheet1").Range("NG10")
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").Value = ThisWorkbook.Sheets("sheet1").Range("NH10")
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").Value = ThisWorkbook.Sheets("sheet1").Range("NI10")
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NJ10")
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").Value = ThisWorkbook.Sheets("sheet1").Range("NK10")
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").Value = ThisWorkbook.Sheets("sheet1").Range("NL10")
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").Value = ThisWorkbook.Sheets("sheet1").Range("NM10")
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").Value = ThisWorkbook.Sheets("sheet1").Range("NN10")
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").Value = ThisWorkbook.Sheets("sheet1").Range("NO10")
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").Value = ThisWorkbook.Sheets("sheet1").Range("NP10")
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").Value = ThisWorkbook.Sheets("sheet1").Range("NQ10")
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,F,NN
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").Value = ThisWorkbook.Sheets("sheet1").Range("NR10")
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M,NN
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").Value = ThisWorkbook.Sheets("sheet1").Range("NS10")
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("NU10")) Then
'Denominator
'<1,F
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("NU10")
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("NV10")
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("NW10")
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NX10")
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("NY10")
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("NZ10")
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("OA10")
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("OB10")
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("OC10")
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("OD10")
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("OE10")
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("OF10")
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("OG10")
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("OH10")
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("OI10")
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("OJ10")
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("OK10")
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("OL10")
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("OM10")
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("ON10")
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("OO10")
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("OP10")
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("OQ10")
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("OR10")
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' TTTTTTTTTTTXXXX  XXXXX       NNN   NNNN  NEEEEEEEEEEEEWW  WWWWW   WWWW 
' TTTTTTTTTTTXXXX  XXXX        NNNN  NNNN  NEEEEEEEEEEEEWW  WWWWW  WWWW  
' TTTTTTTTTTTXXXXXXXXXX        NNNN  NNNN  NEEEEEEEEEEEEWW  WWWWWW WWWW  
'    TTTT     XXXXXXXX         NNNNN NNNN  NEEE       EEWW WWWWWWW WWWW  
'    TTTT      XXXXXX          NNNNN NNNN  NEEE       EEWW WWWWWWW WWWW  
'    TTTT      XXXXXX          NNNNNNNNNN  NEEEEEEEEE  EWWWWWWWWWW WWW   
'    TTTT      XXXXX           NNNNNNNNNN  NEEEEEEEEE  EWWWWWW WWWWWWW   
'    TTTT      XXXXXX          NNNNNNNNNN  NEEEEEEEEE  EWWWWWW WWWWWWW   
'    TTTT     XXXXXXXX         NNNNNNNNNN  NEEE        EWWWWWW WWWWWWW   
'    TTTT     XXXXXXXX         NNN NNNNNN  NEEE        EWWWWWW WWWWWWW   
'    TTTT    XXXX XXXXX        NNN  NNNNN  NEEEEEEEEEE  WWWWW   WWWWW    
'    TTTT   TXXXX  XXXXX       NNN  NNNNN  NEEEEEEEEEE  WWWWW   WWWWW    
'    TTTT   TXXX    XXXX       NNN   NNNN  NEEEEEEEEEE  WWWWW   WWWWW   
Sub TX_NEW()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OT10")) Then
'Breastfeeding
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("PS10:PV10")) = 0  Then
'<1,F
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").Value = ThisWorkbook.Sheets("sheet1").Range("OU10")
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").Value = ThisWorkbook.Sheets("sheet1").Range("OV10")
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").Value = ThisWorkbook.Sheets("sheet1").Range("OW10")
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").Value = ThisWorkbook.Sheets("sheet1").Range("OX10")
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").Value = ThisWorkbook.Sheets("sheet1").Range("OY10")
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").Value = ThisWorkbook.Sheets("sheet1").Range("OZ10")
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").Value = ThisWorkbook.Sheets("sheet1").Range("PA10")
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").Value = ThisWorkbook.Sheets("sheet1").Range("PB10")
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").Value = ThisWorkbook.Sheets("sheet1").Range("PC10")
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").Value = ThisWorkbook.Sheets("sheet1").Range("PD10")
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").Value = ThisWorkbook.Sheets("sheet1").Range("PE10")
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").Value = ThisWorkbook.Sheets("sheet1").Range("PF10")
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").Value = ThisWorkbook.Sheets("sheet1").Range("PG10")
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").Value = ThisWorkbook.Sheets("sheet1").Range("PH10")
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").Value = ThisWorkbook.Sheets("sheet1").Range("PI10")
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").Value = ThisWorkbook.Sheets("sheet1").Range("PJ10")
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").Value = ThisWorkbook.Sheets("sheet1").Range("PK10")
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").Value = ThisWorkbook.Sheets("sheet1").Range("PL10")
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").Value = ThisWorkbook.Sheets("sheet1").Range("PM10")
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").Value = ThisWorkbook.Sheets("sheet1").Range("PN10")
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("PO10")
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("PP10")
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").Value = ThisWorkbook.Sheets("sheet1").Range("PQ10")
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").Value = ThisWorkbook.Sheets("sheet1").Range("PR10")
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
Else
'<15,F
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("PS10")
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,F
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("PT10")
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,M
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("PU10")
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,M
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("PV10")
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End If
End Sub

' TTTTTTTTTTTXXXX  XXXXX        CCCCCCC    UUUU   UUUU  RRRRRRRRRR   RRRRRRRRRR   
' TTTTTTTTTTTXXXX  XXXX        CCCCCCCCC   UUUU   UUUU  RRRRRRRRRRR  RRRRRRRRRRR  
' TTTTTTTTTTTXXXXXXXXXX       CCCCCCCCCCC  UUUU   UUUU  RRRRRRRRRRR  RRRRRRRRRRR  
'    TTTT     XXXXXXXX        CCCC   CCCCC UUUU   UUUU  RRRR   RRRRR RRRR   RRRR  
'    TTTT      XXXXXX         CCC     CCC  UUUU   UUUU  RRRR   RRRRR RRRR   RRRR  
'    TTTT      XXXXXX         CCC          UUUU   UUUU  RRRRRRRRRRR  RRRRRRRRRRR  
'    TTTT      XXXXX          CCC          UUUU   UUUU  RRRRRRRRRRR  RRRRRRRRRRR  
'    TTTT      XXXXXX         CCC          UUUU   UUUU  RRRRRRRR     RRRRRRRR     
'    TTTT     XXXXXXXX        CCC     CCC  UUUU   UUUU  RRRR RRRR    RRRR RRRR    
'    TTTT     XXXXXXXX        CCCC   CCCCC UUUU   UUUU  RRRR  RRRR   RRRR  RRRR   
'    TTTT    XXXX XXXXX       CCCCCCCCCCC  UUUUUUUUUUU  RRRR  RRRRR  RRRR  RRRRR  
'    TTTT   TXXXX  XXXXX       CCCCCCCCCC   UUUUUUUUU   RRRR   RRRRR RRRR   RRRR  
'    TTTT   TXXX    XXXX        CCCCCCC      UUUUUUU    RRRR    RRRR RRRR    RRR  
Sub TX_CURR()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("PX10")) Then
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("QV10:QY10")) = 0 Then
'<1,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").Value = ThisWorkbook.Sheets("sheet1").Range("PX10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'1-4,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").Value = ThisWorkbook.Sheets("sheet1").Range("PY10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'5-9,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").Value = ThisWorkbook.Sheets("sheet1").Range("PZ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'10-14,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").Value = ThisWorkbook.Sheets("sheet1").Range("QA10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").Value = ThisWorkbook.Sheets("sheet1").Range("QB10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").Value = ThisWorkbook.Sheets("sheet1").Range("QC10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").Value = ThisWorkbook.Sheets("sheet1").Range("QD10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").Value = ThisWorkbook.Sheets("sheet1").Range("QE10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").Value = ThisWorkbook.Sheets("sheet1").Range("QF10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").Value = ThisWorkbook.Sheets("sheet1").Range("QG10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").Value = ThisWorkbook.Sheets("sheet1").Range("QH10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").Value = ThisWorkbook.Sheets("sheet1").Range("QI10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").Value = ThisWorkbook.Sheets("sheet1").Range("QJ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").Value = ThisWorkbook.Sheets("sheet1").Range("QK10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").Value = ThisWorkbook.Sheets("sheet1").Range("QL10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").Value = ThisWorkbook.Sheets("sheet1").Range("QM10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").Value = ThisWorkbook.Sheets("sheet1").Range("QN10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").Value = ThisWorkbook.Sheets("sheet1").Range("QO10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").Value = ThisWorkbook.Sheets("sheet1").Range("QP10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").Value = ThisWorkbook.Sheets("sheet1").Range("QQ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("QR10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("QS10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").Value = ThisWorkbook.Sheets("sheet1").Range("QT10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").Value = ThisWorkbook.Sheets("sheet1").Range("QU10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
Else
'<15,F
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("QV10")
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,F
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("QW10")
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,M
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("QX10")
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,M
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("QY10")
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End If
End Sub

' PPPPPPPPP  PPMMMM   MMMMMM TTTTTTTTTTT  CCCCCCC    TTTTTTTTTTT        AAAAA     RRRRRRRRRR   TTTTTTTTT  
' PPPPPPPPPP PPMMMM   MMMMMM TTTTTTTTTTT CCCCCCCCC   TTTTTTTTTTT        AAAAA     RRRRRRRRRRR  TTTTTTTTT  
' PPPPPPPPPPPPPMMMM   MMMMMM TTTTTTTTTTTCCCCCCCCCCC  TTTTTTTTTTT       AAAAAA     RRRRRRRRRRR  TTTTTTTTT  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT    CCCC   CCCCC    TTTT           AAAAAAA    RRRR   RRRRR    TTTT    
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT   TCCC     CCC     TTTT          AAAAAAAA    RRRR   RRRRR    TTTT    
' PPPPPPPPPPPPPMMMMM MMMMMMM    TTTT   TCCC             TTTT          AAAAAAAA    RRRRRRRRRRR     TTTT    
' PPPPPPPPPP PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT          AAAA AAAA   RRRRRRRRRRR     TTTT    
' PPPPPPPPP  PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT         AAAAAAAAAA   RRRRRRRR        TTTT    
' PPPP       PPMMMMMMMMMMMMM    TTTT   TCCC     CCC     TTTT         AAAAAAAAAAA  RRRR RRRR       TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT    CCCC   CCCCC    TTTT         AAAAAAAAAAA  RRRR  RRRR      TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT    CCCCCCCCCCC     TTTT         AAA    AAAA  RRRR  RRRRR     TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT     CCCCCCCCCC     TTTT         AAA     AAAA RRRR   RRRRR    TTTT    
' PPPP       PPMM MMMMM MMMM    TTTT      CCCCCCC       TTTT        AAA     AAAA RRRR    RRRR    TTTT    
Sub PMTCT_ART()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("RA10")) Then
'New on ART
'10-14
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").Value = ThisWorkbook.Sheets("sheet1").Range("RA10")
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").Value = ThisWorkbook.Sheets("sheet1").Range("RB10")
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").Value = ThisWorkbook.Sheets("sheet1").Range("RC10")
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("RD10")
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Already on ART
'10-14
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").Value = ThisWorkbook.Sheets("sheet1").Range("RE10")
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").Value = ThisWorkbook.Sheets("sheet1").Range("RF10")
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").Value = ThisWorkbook.Sheets("sheet1").Range("RG10")
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").Value = ThisWorkbook.Sheets("sheet1").Range("RH10")
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' TTTTTTTTTTTBBBBBBBBBB           AAAAA     RRRRRRRRRR   TTTTTTTTT  
' TTTTTTTTTTTBBBBBBBBBBB          AAAAA     RRRRRRRRRRR  TTTTTTTTT  
' TTTTTTTTTTTBBBBBBBBBBB         AAAAAA     RRRRRRRRRRR  TTTTTTTTT  
'    TTTT    BBBB   BBBB         AAAAAAA    RRRR   RRRRR    TTTT    
'    TTTT    BBBB   BBBB        AAAAAAAA    RRRR   RRRRR    TTTT    
'    TTTT    BBBBBBBBBBB        AAAAAAAA    RRRRRRRRRRR     TTTT    
'    TTTT    BBBBBBBBBB         AAAA AAAA   RRRRRRRRRRR     TTTT    
'    TTTT    BBBBBBBBBBB       AAAAAAAAAA   RRRRRRRR        TTTT    
'    TTTT    BBBB    BBBB      AAAAAAAAAAA  RRRR RRRR       TTTT    
'    TTTT    BBBB    BBBB      AAAAAAAAAAA  RRRR  RRRR      TTTT    
'    TTTT    BBBBBBBBBBBB      AAA    AAAA  RRRR  RRRRR     TTTT    
'    TTTT    BBBBBBBBBBB       AAA     AAAA RRRR   RRRRR    TTTT    
'    TTTT    BBBBBBBBBB       AAA     AAAA RRRR    RRRR    TTTT    
Sub TB_ART()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("RJ10")) Then
'Numerator
'Already on ART
'<1,F
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").Value = ThisWorkbook.Sheets("sheet1").Range("RJ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RK10")
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").Value = ThisWorkbook.Sheets("sheet1").Range("RL10")
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").Value = ThisWorkbook.Sheets("sheet1").Range("RM10")
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").Value = ThisWorkbook.Sheets("sheet1").Range("RN10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").Value = ThisWorkbook.Sheets("sheet1").Range("RO10")
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").Value = ThisWorkbook.Sheets("sheet1").Range("RP10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").Value = ThisWorkbook.Sheets("sheet1").Range("RQ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").Value = ThisWorkbook.Sheets("sheet1").Range("RR10")
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").Value = ThisWorkbook.Sheets("sheet1").Range("RS10")
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").Value = ThisWorkbook.Sheets("sheet1").Range("RT10")
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").Value = ThisWorkbook.Sheets("sheet1").Range("RU10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RV10")
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").Value = ThisWorkbook.Sheets("sheet1").Range("RW10")
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").Value = ThisWorkbook.Sheets("sheet1").Range("RX10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").Value = ThisWorkbook.Sheets("sheet1").Range("RY10")
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").Value = ThisWorkbook.Sheets("sheet1").Range("RZ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").Value = ThisWorkbook.Sheets("sheet1").Range("SA10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SB10")
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").Value = ThisWorkbook.Sheets("sheet1").Range("SC10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").Value = ThisWorkbook.Sheets("sheet1").Range("SD10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").Value = ThisWorkbook.Sheets("sheet1").Range("SE10")
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").Value = ThisWorkbook.Sheets("sheet1").Range("SF10")
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").Value = ThisWorkbook.Sheets("sheet1").Range("SG10")
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New on ART
'<1,F
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").Value = ThisWorkbook.Sheets("sheet1").Range("SH10")
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").Value = ThisWorkbook.Sheets("sheet1").Range("SI10")
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").Value = ThisWorkbook.Sheets("sheet1").Range("SJ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").Value = ThisWorkbook.Sheets("sheet1").Range("SK10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").Value = ThisWorkbook.Sheets("sheet1").Range("SL10")
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").Value = ThisWorkbook.Sheets("sheet1").Range("SM10")
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").Value = ThisWorkbook.Sheets("sheet1").Range("SN10")
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SO10")
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").Value = ThisWorkbook.Sheets("sheet1").Range("SP10")
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").Value = ThisWorkbook.Sheets("sheet1").Range("SQ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").Value = ThisWorkbook.Sheets("sheet1").Range("SR10")
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").Value = ThisWorkbook.Sheets("sheet1").Range("SS10")
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").Value = ThisWorkbook.Sheets("sheet1").Range("ST10")
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").Value = ThisWorkbook.Sheets("sheet1").Range("SU10")
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").Value = ThisWorkbook.Sheets("sheet1").Range("SV10")
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").Value = ThisWorkbook.Sheets("sheet1").Range("SW10")
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SX10")
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("SY10")
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").Value = ThisWorkbook.Sheets("sheet1").Range("SZ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").Value = ThisWorkbook.Sheets("sheet1").Range("TA10")
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").Value = ThisWorkbook.Sheets("sheet1").Range("TB10")
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").Value = ThisWorkbook.Sheets("sheet1").Range("TC10")
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").Value = ThisWorkbook.Sheets("sheet1").Range("TD10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").Value = ThisWorkbook.Sheets("sheet1").Range("TE10")
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' TTTTTTTTTTTXXXX  XXXXX       PPPPPPPP PPPVV    VVVVVVLLL        SSSSSSS     
' TTTTTTTTTTTXXXX  XXXX        PPPPPPPPP PPVV    VVVV VLLL       LSSSSSSSS    
' TTTTTTTTTTTXXXXXXXXXX        PPPPPPPPPPPPVV    VVVV VLLL       LSSSSSSSSS   
'    TTTT     XXXXXXXX         PPP   PPPPPPVVV  VVVV  VLLL      LLSSS  SSSS   
'    TTTT      XXXXXX          PPP   PPPP PVVV  VVVV  VLLL      LLSSS         
'    TTTT      XXXXXX          PPPPPPPPPP PVVV  VVVV  VLLL       LSSSSSS      
'    TTTT      XXXXX           PPPPPPPPP  PVVVVVVVV   VLLL        SSSSSSSSS   
'    TTTT      XXXXXX          PPPPPPPP    VVVVVVVV   VLLL          SSSSSSS   
'    TTTT     XXXXXXXX         PPP         VVVVVVVV   VLLL             SSSSS  
'    TTTT     XXXXXXXX         PPP         VVVVVVV    VLLL      LLSS    SSSS  
'    TTTT    XXXX XXXXX        PPP          VVVVVV    VLLLLLLLLLLLSSSSSSSSSS  
'    TTTT   TXXXX  XXXXX       PPP          VVVVVV    VLLLLLLLLL LSSSSSSSSS   
'    TTTT   TXXX    XXXX       PPP          VVVVV     VLLLLLLLLL  SSSSSSSS
Sub TX_PVLS()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

'Numerator
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("TG10")) Then
'Routine, Pregnant
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").Value = ThisWorkbook.Sheets("sheet1").Range("TG10")
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Routine, Breastfeeding
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").Value = ThisWorkbook.Sheets("sheet1").Range("TH10")
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Undocumented, Pregnant
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("TI10")
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Undocumented, Breastfeeding
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("TJ10")
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Routine
'<1,F
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").Value = ThisWorkbook.Sheets("sheet1").Range("TK10")
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").Value = ThisWorkbook.Sheets("sheet1").Range("TL10")
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("TM10")
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TN10")
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").Value = ThisWorkbook.Sheets("sheet1").Range("TO10")
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").Value = ThisWorkbook.Sheets("sheet1").Range("TP10")
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").Value = ThisWorkbook.Sheets("sheet1").Range("TQ10")
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").Value = ThisWorkbook.Sheets("sheet1").Range("TR10")
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TS10")
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").Value = ThisWorkbook.Sheets("sheet1").Range("TT10")
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").Value = ThisWorkbook.Sheets("sheet1").Range("TU10")
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("TV10")
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").Value = ThisWorkbook.Sheets("sheet1").Range("TW10")
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").Value = ThisWorkbook.Sheets("sheet1").Range("TX10")
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").Value = ThisWorkbook.Sheets("sheet1").Range("TY10")
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").Value = ThisWorkbook.Sheets("sheet1").Range("TZ10")
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").Value = ThisWorkbook.Sheets("sheet1").Range("UA10")
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("UB10")
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").Value = ThisWorkbook.Sheets("sheet1").Range("UC10")
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("UD10")
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").Value = ThisWorkbook.Sheets("sheet1").Range("UE10")
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("UF10")
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").Value = ThisWorkbook.Sheets("sheet1").Range("UG10")
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").Value = ThisWorkbook.Sheets("sheet1").Range("UH10")
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Not Documented
'<1,F
IE.Document.GetElementByID("YvPOllVtINQ-KX9PVyZU0SC-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-KX9PVyZU0SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("UI10")
IE.Document.GetElementByID("YvPOllVtINQ-KX9PVyZU0SC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-L1ObFoxjva6-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-L1ObFoxjva6-val").Value = ThisWorkbook.Sheets("sheet1").Range("UJ10")
IE.Document.GetElementByID("YvPOllVtINQ-L1ObFoxjva6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-MEmyd94Q6WV-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-MEmyd94Q6WV-val").Value = ThisWorkbook.Sheets("sheet1").Range("UK10")
IE.Document.GetElementByID("YvPOllVtINQ-MEmyd94Q6WV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-XdPalqXCZoU-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-XdPalqXCZoU-val").Value = ThisWorkbook.Sheets("sheet1").Range("UL10")
IE.Document.GetElementByID("YvPOllVtINQ-XdPalqXCZoU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-bF0weSMLcXP-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-bF0weSMLcXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("UM10")
IE.Document.GetElementByID("YvPOllVtINQ-bF0weSMLcXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-RtATUnvscNN-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-RtATUnvscNN-val").Value = ThisWorkbook.Sheets("sheet1").Range("UN10")
IE.Document.GetElementByID("YvPOllVtINQ-RtATUnvscNN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-sIQwZRXuYwt-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-sIQwZRXuYwt-val").Value = ThisWorkbook.Sheets("sheet1").Range("UO10")
IE.Document.GetElementByID("YvPOllVtINQ-sIQwZRXuYwt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-LhEFchQfNOo-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-LhEFchQfNOo-val").Value = ThisWorkbook.Sheets("sheet1").Range("UP10")
IE.Document.GetElementByID("YvPOllVtINQ-LhEFchQfNOo-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-VwiNQ9ZBi6N-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-VwiNQ9ZBi6N-val").Value = ThisWorkbook.Sheets("sheet1").Range("UQ10")
IE.Document.GetElementByID("YvPOllVtINQ-VwiNQ9ZBi6N-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ZbXKfTyFNc2-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ZbXKfTyFNc2-val").Value = ThisWorkbook.Sheets("sheet1").Range("UR10")
IE.Document.GetElementByID("YvPOllVtINQ-ZbXKfTyFNc2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-E9mZCkjKTrk-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-E9mZCkjKTrk-val").Value = ThisWorkbook.Sheets("sheet1").Range("US10")
IE.Document.GetElementByID("YvPOllVtINQ-E9mZCkjKTrk-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-Mmj6PfG0MD2-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Mmj6PfG0MD2-val").Value = ThisWorkbook.Sheets("sheet1").Range("UT10")
IE.Document.GetElementByID("YvPOllVtINQ-Mmj6PfG0MD2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("YvPOllVtINQ-j9nkZnYOQ2j-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-j9nkZnYOQ2j-val").Value = ThisWorkbook.Sheets("sheet1").Range("UU10")
IE.Document.GetElementByID("YvPOllVtINQ-j9nkZnYOQ2j-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-ugfxT6Y9fVT-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ugfxT6Y9fVT-val").Value = ThisWorkbook.Sheets("sheet1").Range("UV10")
IE.Document.GetElementByID("YvPOllVtINQ-ugfxT6Y9fVT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-GTyaeyYttO7-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-GTyaeyYttO7-val").Value = ThisWorkbook.Sheets("sheet1").Range("UW10")
IE.Document.GetElementByID("YvPOllVtINQ-GTyaeyYttO7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-GsqfEv7ONZC-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-GsqfEv7ONZC-val").Value = ThisWorkbook.Sheets("sheet1").Range("UX10")
IE.Document.GetElementByID("YvPOllVtINQ-GsqfEv7ONZC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-PrDW5lYkfid-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-PrDW5lYkfid-val").Value = ThisWorkbook.Sheets("sheet1").Range("UY10")
IE.Document.GetElementByID("YvPOllVtINQ-PrDW5lYkfid-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-k5zqWba6iGZ-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-k5zqWba6iGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("UZ10")
IE.Document.GetElementByID("YvPOllVtINQ-k5zqWba6iGZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-g8GIFx03IlN-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-g8GIFx03IlN-val").Value = ThisWorkbook.Sheets("sheet1").Range("VA10")
IE.Document.GetElementByID("YvPOllVtINQ-g8GIFx03IlN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-BoVxsZvmVD3-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-BoVxsZvmVD3-val").Value = ThisWorkbook.Sheets("sheet1").Range("VB10")
IE.Document.GetElementByID("YvPOllVtINQ-BoVxsZvmVD3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ooErPHdkcUi-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ooErPHdkcUi-val").Value = ThisWorkbook.Sheets("sheet1").Range("VC10")
IE.Document.GetElementByID("YvPOllVtINQ-ooErPHdkcUi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-lIjZjuzUGWd-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-lIjZjuzUGWd-val").Value = ThisWorkbook.Sheets("sheet1").Range("VD10")
IE.Document.GetElementByID("YvPOllVtINQ-lIjZjuzUGWd-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-bYjNYUiHRzF-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-bYjNYUiHRzF-val").Value = ThisWorkbook.Sheets("sheet1").Range("VE10")
IE.Document.GetElementByID("YvPOllVtINQ-bYjNYUiHRzF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("YvPOllVtINQ-E4AmAvdxkJA-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-E4AmAvdxkJA-val").Value = ThisWorkbook.Sheets("sheet1").Range("VF10")
IE.Document.GetElementByID("YvPOllVtINQ-E4AmAvdxkJA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
'Denominator
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("VH10")) Then
'Routine, Pregnant
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").Value = ThisWorkbook.Sheets("sheet1").Range("VH10")
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Routine, Breastfeeding
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").Value = ThisWorkbook.Sheets("sheet1").Range("VI10")
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Undocumented, Pregnant
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("VJ10")
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Undocumented, Breastfeeding
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("VK10")
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Routine
'<1,F
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").Value = ThisWorkbook.Sheets("sheet1").Range("VL10")
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").Value = ThisWorkbook.Sheets("sheet1").Range("VM10")
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("VN10")
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").Value = ThisWorkbook.Sheets("sheet1").Range("VO10")
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").Value = ThisWorkbook.Sheets("sheet1").Range("VP10")
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").Value = ThisWorkbook.Sheets("sheet1").Range("VQ10")
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").Value = ThisWorkbook.Sheets("sheet1").Range("VR10")
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").Value = ThisWorkbook.Sheets("sheet1").Range("VS10")
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").Value = ThisWorkbook.Sheets("sheet1").Range("VT10")
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").Value = ThisWorkbook.Sheets("sheet1").Range("VU10")
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").Value = ThisWorkbook.Sheets("sheet1").Range("VV10")
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("VW10")
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").Value = ThisWorkbook.Sheets("sheet1").Range("VX10")
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").Value = ThisWorkbook.Sheets("sheet1").Range("VY10")
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").Value = ThisWorkbook.Sheets("sheet1").Range("VZ10")
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").Value = ThisWorkbook.Sheets("sheet1").Range("WA10")
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").Value = ThisWorkbook.Sheets("sheet1").Range("WB10")
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("WC10")
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").Value = ThisWorkbook.Sheets("sheet1").Range("WD10")
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("WE10")
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").Value = ThisWorkbook.Sheets("sheet1").Range("WF10")
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("WG10")
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").Value = ThisWorkbook.Sheets("sheet1").Range("WH10")
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").Value = ThisWorkbook.Sheets("sheet1").Range("WI10")
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Not Documented
'<1,F
IE.Document.GetElementByID("kznQBykTtJt-KX9PVyZU0SC-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-KX9PVyZU0SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("WJ10")
IE.Document.GetElementByID("kznQBykTtJt-KX9PVyZU0SC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-L1ObFoxjva6-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-L1ObFoxjva6-val").Value = ThisWorkbook.Sheets("sheet1").Range("WK10")
IE.Document.GetElementByID("kznQBykTtJt-L1ObFoxjva6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-MEmyd94Q6WV-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-MEmyd94Q6WV-val").Value = ThisWorkbook.Sheets("sheet1").Range("WL10")
IE.Document.GetElementByID("kznQBykTtJt-MEmyd94Q6WV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-XdPalqXCZoU-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-XdPalqXCZoU-val").Value = ThisWorkbook.Sheets("sheet1").Range("WM10")
IE.Document.GetElementByID("kznQBykTtJt-XdPalqXCZoU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-bF0weSMLcXP-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-bF0weSMLcXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("WN10")
IE.Document.GetElementByID("kznQBykTtJt-bF0weSMLcXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-RtATUnvscNN-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-RtATUnvscNN-val").Value = ThisWorkbook.Sheets("sheet1").Range("WO10")
IE.Document.GetElementByID("kznQBykTtJt-RtATUnvscNN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-sIQwZRXuYwt-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-sIQwZRXuYwt-val").Value = ThisWorkbook.Sheets("sheet1").Range("WP10")
IE.Document.GetElementByID("kznQBykTtJt-sIQwZRXuYwt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-LhEFchQfNOo-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-LhEFchQfNOo-val").Value = ThisWorkbook.Sheets("sheet1").Range("WQ10")
IE.Document.GetElementByID("kznQBykTtJt-LhEFchQfNOo-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-VwiNQ9ZBi6N-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-VwiNQ9ZBi6N-val").Value = ThisWorkbook.Sheets("sheet1").Range("WR10")
IE.Document.GetElementByID("kznQBykTtJt-VwiNQ9ZBi6N-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ZbXKfTyFNc2-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ZbXKfTyFNc2-val").Value = ThisWorkbook.Sheets("sheet1").Range("WS10")
IE.Document.GetElementByID("kznQBykTtJt-ZbXKfTyFNc2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-E9mZCkjKTrk-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-E9mZCkjKTrk-val").Value = ThisWorkbook.Sheets("sheet1").Range("WT10")
IE.Document.GetElementByID("kznQBykTtJt-E9mZCkjKTrk-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-Mmj6PfG0MD2-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Mmj6PfG0MD2-val").Value = ThisWorkbook.Sheets("sheet1").Range("WU10")
IE.Document.GetElementByID("kznQBykTtJt-Mmj6PfG0MD2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("kznQBykTtJt-j9nkZnYOQ2j-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-j9nkZnYOQ2j-val").Value = ThisWorkbook.Sheets("sheet1").Range("WV10")
IE.Document.GetElementByID("kznQBykTtJt-j9nkZnYOQ2j-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-ugfxT6Y9fVT-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ugfxT6Y9fVT-val").Value = ThisWorkbook.Sheets("sheet1").Range("WW10")
IE.Document.GetElementByID("kznQBykTtJt-ugfxT6Y9fVT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-GTyaeyYttO7-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-GTyaeyYttO7-val").Value = ThisWorkbook.Sheets("sheet1").Range("WX10")
IE.Document.GetElementByID("kznQBykTtJt-GTyaeyYttO7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-GsqfEv7ONZC-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-GsqfEv7ONZC-val").Value = ThisWorkbook.Sheets("sheet1").Range("WY10")
IE.Document.GetElementByID("kznQBykTtJt-GsqfEv7ONZC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-PrDW5lYkfid-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-PrDW5lYkfid-val").Value = ThisWorkbook.Sheets("sheet1").Range("WZ10")
IE.Document.GetElementByID("kznQBykTtJt-PrDW5lYkfid-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-k5zqWba6iGZ-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-k5zqWba6iGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("XA10")
IE.Document.GetElementByID("kznQBykTtJt-k5zqWba6iGZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-g8GIFx03IlN-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-g8GIFx03IlN-val").Value = ThisWorkbook.Sheets("sheet1").Range("XB10")
IE.Document.GetElementByID("kznQBykTtJt-g8GIFx03IlN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-BoVxsZvmVD3-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-BoVxsZvmVD3-val").Value = ThisWorkbook.Sheets("sheet1").Range("XC10")
IE.Document.GetElementByID("kznQBykTtJt-BoVxsZvmVD3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ooErPHdkcUi-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ooErPHdkcUi-val").Value = ThisWorkbook.Sheets("sheet1").Range("XD10")
IE.Document.GetElementByID("kznQBykTtJt-ooErPHdkcUi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-lIjZjuzUGWd-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-lIjZjuzUGWd-val").Value = ThisWorkbook.Sheets("sheet1").Range("XE10")
IE.Document.GetElementByID("kznQBykTtJt-lIjZjuzUGWd-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-bYjNYUiHRzF-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-bYjNYUiHRzF-val").Value = ThisWorkbook.Sheets("sheet1").Range("XF10")
IE.Document.GetElementByID("kznQBykTtJt-bYjNYUiHRzF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+,M
IE.Document.GetElementByID("kznQBykTtJt-E4AmAvdxkJA-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-E4AmAvdxkJA-val").Value = ThisWorkbook.Sheets("sheet1").Range("XG10")
IE.Document.GetElementByID("kznQBykTtJt-E4AmAvdxkJA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' PPPPPPPPP          rEEEEEEEEEE EPPPPPPPP         NNN   NNNN  NEEEEEEEEEEEEWW  WWWWW   WWW  
' PPPPPPPPPP         rEEEEEEEEEE EPPPPPPPPP        NNNN  NNNN  NEEEEEEEEEEEEWW  WWWWW  WWWW  
' PPPPPPPPPPP        rEEEEEEEEEE EPPPPPPPPPP       NNNN  NNNN  NEEEEEEEEEEEEWW  WWWWWW WWWW  
' PPPP   PPPPPPrrrrrrrEEE        EPPP   PPPP       NNNNN NNNN  NEEE       EEWW WWWWWWW WWWW  
' PPPP   PPPPPPrrrrrrrEEE        EPPP   PPPP       NNNNN NNNN  NEEE       EEWW WWWWWWW WWWW  
' PPPPPPPPPPPPPrrr   rEEEEEEEEE  EPPPPPPPPPP       NNNNNNNNNN  NEEEEEEEEE  EWWWWWWWWWW WWW   
' PPPPPPPPPP PPrr    rEEEEEEEEE  EPPPPPPPPP        NNNNNNNNNN  NEEEEEEEEE  EWWWWWW WWWWWWW   
' PPPPPPPPP  PPrr    rEEEEEEEEE  EPPPPPPPP         NNNNNNNNNN  NEEEEEEEEE  EWWWWWW WWWWWWW   
' PPPP       PPrr    rEEE        EPPP              NNNNNNNNNN  NEEE        EWWWWWW WWWWWWW   
' PPPP       PPrr    rEEE        EPPP              NNN NNNNNN  NEEE        EWWWWWW WWWWWWW   
' PPPP       PPrr    rEEEEEEEEEE EPPP              NNN  NNNNN  NEEEEEEEEEE  WWWWW   WWWWW    
' PPPP       PPrr    rEEEEEEEEEE EPPP              NNN  NNNNN  NEEEEEEEEEE  WWWWW   WWWWW    
' PPPP       PPrr    rEEEEEEEEEE EPPP              NNN   NNNN  NEEEEEEEEEE  WWWWW   WWWWW    
Sub PrEP_NEW()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("XI10")) Then
'15-19,F  
IE.Document.GetElementByID("KNO4emPfF91-BYmlmGMcCWx-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-BYmlmGMcCWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("XI10")
IE.Document.GetElementByID("KNO4emPfF91-BYmlmGMcCWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F  
IE.Document.GetElementByID("KNO4emPfF91-zE5NFpGXDy4-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-zE5NFpGXDy4-val").Value = ThisWorkbook.Sheets("sheet1").Range("XJ10")
IE.Document.GetElementByID("KNO4emPfF91-zE5NFpGXDy4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F  
IE.Document.GetElementByID("KNO4emPfF91-u88hOHhmLuF-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-u88hOHhmLuF-val").Value = ThisWorkbook.Sheets("sheet1").Range("XK10")
IE.Document.GetElementByID("KNO4emPfF91-u88hOHhmLuF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F  
IE.Document.GetElementByID("KNO4emPfF91-tcJ9vZbCWcO-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-tcJ9vZbCWcO-val").Value = ThisWorkbook.Sheets("sheet1").Range("XL10")
IE.Document.GetElementByID("KNO4emPfF91-tcJ9vZbCWcO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39,F  
IE.Document.GetElementByID("KNO4emPfF91-WghEsgfAUAb-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-WghEsgfAUAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("XM10")
IE.Document.GetElementByID("KNO4emPfF91-WghEsgfAUAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44,F  
IE.Document.GetElementByID("KNO4emPfF91-Ij7k6DBjI3i-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-Ij7k6DBjI3i-val").Value = ThisWorkbook.Sheets("sheet1").Range("XN10")
IE.Document.GetElementByID("KNO4emPfF91-Ij7k6DBjI3i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49,F  
IE.Document.GetElementByID("KNO4emPfF91-dIfXCJxd5bY-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-dIfXCJxd5bY-val").Value = ThisWorkbook.Sheets("sheet1").Range("XO10")
IE.Document.GetElementByID("KNO4emPfF91-dIfXCJxd5bY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50,F  
IE.Document.GetElementByID("KNO4emPfF91-xqiQnxlVCYm-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-xqiQnxlVCYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("XP10")
IE.Document.GetElementByID("KNO4emPfF91-xqiQnxlVCYm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M 
IE.Document.GetElementByID("KNO4emPfF91-kQ58FETBxFn-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-kQ58FETBxFn-val").Value = ThisWorkbook.Sheets("sheet1").Range("XQ10")
IE.Document.GetElementByID("KNO4emPfF91-kQ58FETBxFn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M  
IE.Document.GetElementByID("KNO4emPfF91-jJifRzf2Z8j-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-jJifRzf2Z8j-val").Value = ThisWorkbook.Sheets("sheet1").Range("XR10")
IE.Document.GetElementByID("KNO4emPfF91-jJifRzf2Z8j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M  
IE.Document.GetElementByID("KNO4emPfF91-necuVZOR1HB-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-necuVZOR1HB-val").Value = ThisWorkbook.Sheets("sheet1").Range("XS10")
IE.Document.GetElementByID("KNO4emPfF91-necuVZOR1HB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M  
IE.Document.GetElementByID("KNO4emPfF91-HnDmWypXRdG-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-HnDmWypXRdG-val").Value = ThisWorkbook.Sheets("sheet1").Range("XT10")
IE.Document.GetElementByID("KNO4emPfF91-HnDmWypXRdG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39,M  
IE.Document.GetElementByID("KNO4emPfF91-Sq9vathzQd9-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-Sq9vathzQd9-val").Value = ThisWorkbook.Sheets("sheet1").Range("XU10")
IE.Document.GetElementByID("KNO4emPfF91-Sq9vathzQd9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44,M 
IE.Document.GetElementByID("KNO4emPfF91-f6m1joVHJgj-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-f6m1joVHJgj-val").Value = ThisWorkbook.Sheets("sheet1").Range("XV10")
IE.Document.GetElementByID("KNO4emPfF91-f6m1joVHJgj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49,M 
IE.Document.GetElementByID("KNO4emPfF91-efXnrOzWCGW-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-efXnrOzWCGW-val").Value = ThisWorkbook.Sheets("sheet1").Range("XW10")
IE.Document.GetElementByID("KNO4emPfF91-efXnrOzWCGW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50,M 
IE.Document.GetElementByID("KNO4emPfF91-fSgFPhUpbWq-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-fSgFPhUpbWq-val").Value = ThisWorkbook.Sheets("sheet1").Range("XX10")
IE.Document.GetElementByID("KNO4emPfF91-fSgFPhUpbWq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End if
End Sub

'PPPPPPPPP          rEEEEEEEEEE EPPPPPPPP          CCCCCCC    CUUU   UUUU  URRRRRRRRR   RRRRRRRRRR    
'PPPPPPPPPP         rEEEEEEEEEE EPPPPPPPPP        CCCCCCCCC   CUUU   UUUU  URRRRRRRRRR  RRRRRRRRRRR   
'PPPPPPPPPPP        rEEEEEEEEEE EPPPPPPPPPP       CCCCCCCCCC  CUUU   UUUU  URRRRRRRRRR  RRRRRRRRRRR   
'PPPP   PPPPPPrrrrrrrEEE        EPPP   PPPP       CCC   CCCCC CUUU   UUUU  URRR   RRRRR RRRR   RRRRR  
'PPPP   PPPPPPrrrrrrrEEE        EPPP   PPPP       CC     CCC  CUUU   UUUU  URRR   RRRRR RRRR   RRRRR  
'PPPPPPPPPPPPPrrr   rEEEEEEEEE  EPPPPPPPPPP       CC          CUUU   UUUU  URRRRRRRRRR  RRRRRRRRRRR   
'PPPPPPPPPP PPrr    rEEEEEEEEE  EPPPPPPPPP        CC          CUUU   UUUU  URRRRRRRRRR  RRRRRRRRRRR   
'PPPPPPPPP  PPrr    rEEEEEEEEE  EPPPPPPPP         CC          CUUU   UUUU  URRRRRRR     RRRRRRRR      
'PPPP       PPrr    rEEE        EPPP              CC     CCC  CUUU   UUUU  URRR RRRR    RRRR RRRR     
'PPPP       PPrr    rEEE        EPPP              CCC   CCCCC CUUU   UUUU  URRR  RRRR   RRRR  RRRR    
'PPPP       PPrr    rEEEEEEEEEE EPPP              CCCCCCCCCC  CUUUUUUUUUU  URRR  RRRRR  RRRR  RRRRR   
'PPPP       PPrr    rEEEEEEEEEE EPPP              CCCCCCCCCC   UUUUUUUUU   URRR   RRRRR RRRR   RRRRR  
'PPPP       PPrr    rEEEEEEEEEE EPPP               CCCCCCC      UUUUUUU    URRR    RRRR RRRR    RRRR  
Sub PrEP_CURR()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("XZ10")) Then
'15-19,F  
IE.Document.GetElementByID("x5H3nrR8BNW-BYmlmGMcCWx-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-BYmlmGMcCWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("XZ10")
IE.Document.GetElementByID("x5H3nrR8BNW-BYmlmGMcCWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,F  
IE.Document.GetElementByID("x5H3nrR8BNW-zE5NFpGXDy4-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-zE5NFpGXDy4-val").Value = ThisWorkbook.Sheets("sheet1").Range("YA10")
IE.Document.GetElementByID("x5H3nrR8BNW-zE5NFpGXDy4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,F  
IE.Document.GetElementByID("x5H3nrR8BNW-u88hOHhmLuF-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-u88hOHhmLuF-val").Value = ThisWorkbook.Sheets("sheet1").Range("YB10")
IE.Document.GetElementByID("x5H3nrR8BNW-u88hOHhmLuF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,F  
IE.Document.GetElementByID("x5H3nrR8BNW-tcJ9vZbCWcO-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-tcJ9vZbCWcO-val").Value = ThisWorkbook.Sheets("sheet1").Range("YC10")
IE.Document.GetElementByID("x5H3nrR8BNW-tcJ9vZbCWcO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39,F  
IE.Document.GetElementByID("x5H3nrR8BNW-WghEsgfAUAb-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-WghEsgfAUAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("YD10")
IE.Document.GetElementByID("x5H3nrR8BNW-WghEsgfAUAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44,F  
IE.Document.GetElementByID("x5H3nrR8BNW-Ij7k6DBjI3i-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-Ij7k6DBjI3i-val").Value = ThisWorkbook.Sheets("sheet1").Range("YE10")
IE.Document.GetElementByID("x5H3nrR8BNW-Ij7k6DBjI3i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49,F  
IE.Document.GetElementByID("x5H3nrR8BNW-dIfXCJxd5bY-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-dIfXCJxd5bY-val").Value = ThisWorkbook.Sheets("sheet1").Range("YF10")
IE.Document.GetElementByID("x5H3nrR8BNW-dIfXCJxd5bY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50,F  
IE.Document.GetElementByID("x5H3nrR8BNW-xqiQnxlVCYm-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-xqiQnxlVCYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("YG10")
IE.Document.GetElementByID("x5H3nrR8BNW-xqiQnxlVCYm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15-19,M 
IE.Document.GetElementByID("x5H3nrR8BNW-kQ58FETBxFn-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-kQ58FETBxFn-val").Value = ThisWorkbook.Sheets("sheet1").Range("YH10")
IE.Document.GetElementByID("x5H3nrR8BNW-kQ58FETBxFn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24,M  
IE.Document.GetElementByID("x5H3nrR8BNW-jJifRzf2Z8j-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-jJifRzf2Z8j-val").Value = ThisWorkbook.Sheets("sheet1").Range("YI10")
IE.Document.GetElementByID("x5H3nrR8BNW-jJifRzf2Z8j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29,M  
IE.Document.GetElementByID("x5H3nrR8BNW-necuVZOR1HB-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-necuVZOR1HB-val").Value = ThisWorkbook.Sheets("sheet1").Range("YJ10")
IE.Document.GetElementByID("x5H3nrR8BNW-necuVZOR1HB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34,M  
IE.Document.GetElementByID("x5H3nrR8BNW-HnDmWypXRdG-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-HnDmWypXRdG-val").Value = ThisWorkbook.Sheets("sheet1").Range("YK10")
IE.Document.GetElementByID("x5H3nrR8BNW-HnDmWypXRdG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39,M  
IE.Document.GetElementByID("x5H3nrR8BNW-Sq9vathzQd9-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-Sq9vathzQd9-val").Value = ThisWorkbook.Sheets("sheet1").Range("YL10")
IE.Document.GetElementByID("x5H3nrR8BNW-Sq9vathzQd9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44,M 
IE.Document.GetElementByID("x5H3nrR8BNW-f6m1joVHJgj-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-f6m1joVHJgj-val").Value = ThisWorkbook.Sheets("sheet1").Range("YM10")
IE.Document.GetElementByID("x5H3nrR8BNW-f6m1joVHJgj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49,M 
IE.Document.GetElementByID("x5H3nrR8BNW-efXnrOzWCGW-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-efXnrOzWCGW-val").Value = ThisWorkbook.Sheets("sheet1").Range("YN10")
IE.Document.GetElementByID("x5H3nrR8BNW-efXnrOzWCGW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50,M 
IE.Document.GetElementByID("x5H3nrR8BNW-fSgFPhUpbWq-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-fSgFPhUpbWq-val").Value = ThisWorkbook.Sheets("sheet1").Range("YO10")
IE.Document.GetElementByID("x5H3nrR8BNW-fSgFPhUpbWq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Positive
IE.Document.GetElementByID("YJ29Pdq78W9-KZLKkTI9JDW-val").Focus
IE.Document.GetElementByID("YJ29Pdq78W9-KZLKkTI9JDW-val").Value = ThisWorkbook.Sheets("sheet1").Range("YP10")
IE.Document.GetElementByID("YJ29Pdq78W9-KZLKkTI9JDW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Negative
IE.Document.GetElementByID("YJ29Pdq78W9-wk0iX1oD0k8-val").Focus
IE.Document.GetElementByID("YJ29Pdq78W9-wk0iX1oD0k8-val").Value = ThisWorkbook.Sheets("sheet1").Range("YQ10")
IE.Document.GetElementByID("YJ29Pdq78W9-wk0iX1oD0k8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Three month
IE.Document.GetElementByID("YJ29Pdq78W9-IYCY7by7MB6-val").Focus
IE.Document.GetElementByID("YJ29Pdq78W9-IYCY7by7MB6-val").Value = ThisWorkbook.Sheets("sheet1").Range("YR10")
IE.Document.GetElementByID("YJ29Pdq78W9-IYCY7by7MB6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End if
End Sub

'TTTTTTTTTTTBBBBBBBBBB        PPPPPPPPP   PRRRRRRRRR   EEEEEEEEEEEEEVV    VVVV  
'TTTTTTTTTTTBBBBBBBBBBB       PPPPPPPPPP  PRRRRRRRRRR  EEEEEEEEEEEEEVV    VVVV  
'TTTTTTTTTTTBBBBBBBBBBB       PPPPPPPPPPP PRRRRRRRRRR  EEEEEEEEEEEEEVV    VVVV  
'   TTTT    BBBB   BBBB       PPPP   PPPP PRRR   RRRRR EEEE       EEVVV  VVVV   
'   TTTT    BBBB   BBBB       PPPP   PPPP PRRR   RRRRR EEEE        EVVV  VVVV   
'   TTTT    BBBBBBBBBBB       PPPPPPPPPPP PRRRRRRRRRR  EEEEEEEEEE  EVVV  VVVV   
'   TTTT    BBBBBBBBBB        PPPPPPPPPP  PRRRRRRRRRR  EEEEEEEEEE  EVVVVVVVV    
'   TTTT    BBBBBBBBBBB       PPPPPPPPP   PRRRRRRR     EEEEEEEEEE   VVVVVVVV    
'   TTTT    BBBB    BBBB      PPPP        PRRR RRRR    EEEE         VVVVVVVV    
'   TTTT    BBBB    BBBB      PPPP        PRRR  RRRR   EEEE         VVVVVVV     
'   TTTT    BBBBBBBBBBBB      PPPP        PRRR  RRRRR  EEEEEEEEEEE   VVVVVV     
'   TTTT    BBBBBBBBBBB       PPPP        PRRR   RRRRR EEEEEEEEEEE   VVVVVV     
'   TTTT    BBBBBBBBBB        PPPP        PRRR    RRRR EEEEEEEEEEE   VVVVV  
Sub TB_PREV()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("YT10")) Then
'Numerator
'IPT, Newly, <15, F
IE.Document.GetElementByID("snsnfDStk7C-mi7E9CADWSN-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-mi7E9CADWSN-val").Value = ThisWorkbook.Sheets("sheet1").Range("YT10")
IE.Document.GetElementByID("snsnfDStk7C-mi7E9CADWSN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Newly, 15+, F
IE.Document.GetElementByID("snsnfDStk7C-JR95o8Xtizl-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-JR95o8Xtizl-val").Value = ThisWorkbook.Sheets("sheet1").Range("YU10")
IE.Document.GetElementByID("snsnfDStk7C-JR95o8Xtizl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Newly, <15, M
IE.Document.GetElementByID("snsnfDStk7C-wf5dnqcNzsC-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-wf5dnqcNzsC-val").Value = ThisWorkbook.Sheets("sheet1").Range("YV10")
IE.Document.GetElementByID("snsnfDStk7C-wf5dnqcNzsC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Newly, 15+, M
IE.Document.GetElementByID("snsnfDStk7C-DYWHCdJGVCo-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-DYWHCdJGVCo-val").Value = ThisWorkbook.Sheets("sheet1").Range("YW10")
IE.Document.GetElementByID("snsnfDStk7C-DYWHCdJGVCo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, <15, F
IE.Document.GetElementByID("snsnfDStk7C-EtjoXVvdmke-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-EtjoXVvdmke-val").Value = ThisWorkbook.Sheets("sheet1").Range("YX10")
IE.Document.GetElementByID("snsnfDStk7C-EtjoXVvdmke-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, 15+, F
IE.Document.GetElementByID("snsnfDStk7C-M4jO9QCDbGa-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-M4jO9QCDbGa-val").Value = ThisWorkbook.Sheets("sheet1").Range("YY10")
IE.Document.GetElementByID("snsnfDStk7C-M4jO9QCDbGa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, <15, M
IE.Document.GetElementByID("snsnfDStk7C-H7mVNYfFpZK-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-H7mVNYfFpZK-val").Value = ThisWorkbook.Sheets("sheet1").Range("YZ10")
IE.Document.GetElementByID("snsnfDStk7C-H7mVNYfFpZK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, 15+, M
IE.Document.GetElementByID("snsnfDStk7C-UhCTzS8qdWx-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-UhCTzS8qdWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZA10")
IE.Document.GetElementByID("snsnfDStk7C-UhCTzS8qdWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, <15, F
IE.Document.GetElementByID("snsnfDStk7C-l2FnKuSuntB-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-l2FnKuSuntB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZB10")
IE.Document.GetElementByID("snsnfDStk7C-l2FnKuSuntB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, 15+, F
IE.Document.GetElementByID("snsnfDStk7C-LOEuWArojN7-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-LOEuWArojN7-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZC10")
IE.Document.GetElementByID("snsnfDStk7C-LOEuWArojN7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, <15, M
IE.Document.GetElementByID("snsnfDStk7C-moyK8BYZIvs-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-moyK8BYZIvs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZD10")
IE.Document.GetElementByID("snsnfDStk7C-moyK8BYZIvs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, 15+, M
IE.Document.GetElementByID("snsnfDStk7C-YR98qZg7lGb-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-YR98qZg7lGb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZE10")
IE.Document.GetElementByID("snsnfDStk7C-YR98qZg7lGb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, <15, F
IE.Document.GetElementByID("snsnfDStk7C-pgiGwqvipEi-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-pgiGwqvipEi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZF10")
IE.Document.GetElementByID("snsnfDStk7C-pgiGwqvipEi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, 15+, F
IE.Document.GetElementByID("snsnfDStk7C-WU9HyL17b2S-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-WU9HyL17b2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZG10")
IE.Document.GetElementByID("snsnfDStk7C-WU9HyL17b2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, <15, M
IE.Document.GetElementByID("snsnfDStk7C-UVIXQTIxILK-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-UVIXQTIxILK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZH10")
IE.Document.GetElementByID("snsnfDStk7C-UVIXQTIxILK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, 15+, M
IE.Document.GetElementByID("snsnfDStk7C-B4XkBcZAtsu-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-B4XkBcZAtsu-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZI10")
IE.Document.GetElementByID("snsnfDStk7C-B4XkBcZAtsu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ZK10")) Then
'Denominator
'IPT, Newly, <15, F
IE.Document.GetElementByID("KTrXeuvf4iQ-mi7E9CADWSN-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-mi7E9CADWSN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZK10")
IE.Document.GetElementByID("KTrXeuvf4iQ-mi7E9CADWSN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Newly, 15+, F
IE.Document.GetElementByID("KTrXeuvf4iQ-JR95o8Xtizl-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-JR95o8Xtizl-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZL10")
IE.Document.GetElementByID("KTrXeuvf4iQ-JR95o8Xtizl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Newly, <15, M
IE.Document.GetElementByID("KTrXeuvf4iQ-wf5dnqcNzsC-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-wf5dnqcNzsC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZM10")
IE.Document.GetElementByID("KTrXeuvf4iQ-wf5dnqcNzsC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Newly, 15+, M
IE.Document.GetElementByID("KTrXeuvf4iQ-DYWHCdJGVCo-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-DYWHCdJGVCo-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZN10")
IE.Document.GetElementByID("KTrXeuvf4iQ-DYWHCdJGVCo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, <15, F
IE.Document.GetElementByID("KTrXeuvf4iQ-EtjoXVvdmke-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-EtjoXVvdmke-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZO10")
IE.Document.GetElementByID("KTrXeuvf4iQ-EtjoXVvdmke-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, 15+, F
IE.Document.GetElementByID("KTrXeuvf4iQ-M4jO9QCDbGa-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-M4jO9QCDbGa-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZP10")
IE.Document.GetElementByID("KTrXeuvf4iQ-M4jO9QCDbGa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, <15, M
IE.Document.GetElementByID("KTrXeuvf4iQ-H7mVNYfFpZK-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-H7mVNYfFpZK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZQ10")
IE.Document.GetElementByID("KTrXeuvf4iQ-H7mVNYfFpZK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already, 15+, M
IE.Document.GetElementByID("KTrXeuvf4iQ-UhCTzS8qdWx-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-UhCTzS8qdWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZR10")
IE.Document.GetElementByID("KTrXeuvf4iQ-UhCTzS8qdWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, <15, F
IE.Document.GetElementByID("KTrXeuvf4iQ-l2FnKuSuntB-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-l2FnKuSuntB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZS10")
IE.Document.GetElementByID("KTrXeuvf4iQ-l2FnKuSuntB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, 15+, F
IE.Document.GetElementByID("KTrXeuvf4iQ-LOEuWArojN7-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-LOEuWArojN7-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZT10")
IE.Document.GetElementByID("KTrXeuvf4iQ-LOEuWArojN7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, <15, M
IE.Document.GetElementByID("KTrXeuvf4iQ-moyK8BYZIvs-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-moyK8BYZIvs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZU10")
IE.Document.GetElementByID("KTrXeuvf4iQ-moyK8BYZIvs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Newly, 15+, M
IE.Document.GetElementByID("KTrXeuvf4iQ-YR98qZg7lGb-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-YR98qZg7lGb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZV10")
IE.Document.GetElementByID("KTrXeuvf4iQ-YR98qZg7lGb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, <15, F
IE.Document.GetElementByID("KTrXeuvf4iQ-pgiGwqvipEi-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-pgiGwqvipEi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZW10")
IE.Document.GetElementByID("KTrXeuvf4iQ-pgiGwqvipEi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, 15+, F
IE.Document.GetElementByID("KTrXeuvf4iQ-WU9HyL17b2S-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-WU9HyL17b2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZX10")
IE.Document.GetElementByID("KTrXeuvf4iQ-WU9HyL17b2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, <15, M
IE.Document.GetElementByID("KTrXeuvf4iQ-UVIXQTIxILK-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-UVIXQTIxILK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZY10")
IE.Document.GetElementByID("KTrXeuvf4iQ-UVIXQTIxILK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Alternate, Already, 15+, M
IE.Document.GetElementByID("KTrXeuvf4iQ-B4XkBcZAtsu-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-B4XkBcZAtsu-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZZ10")
IE.Document.GetElementByID("KTrXeuvf4iQ-B4XkBcZAtsu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

'    CCCCCCC   XXXXX  XXXXX   CCCCCCC       AAAAA           SSSSSSS      CCCCCCC    RRRRRRRRRR   NNNN   NNNN  
'   CCCCCCCCC   XXXX  XXXX   CCCCCCCCC      AAAAA          SSSSSSSSS    CCCCCCCCC   RRRRRRRRRRR  NNNNN  NNNN  
'  CCCCCCCCCCC  XXXXXXXXXX  CCCCCCCCCCC    AAAAAA          SSSSSSSSSS  CCCCCCCCCCC  RRRRRRRRRRR  NNNNN  NNNN  
'  CCCC   CCCCC  XXXXXXXX   CCCC   CCCCC   AAAAAAA         SSSS  SSSS  CCCC   CCCCC RRRR   RRRRR NNNNNN NNNN  
' CCCC     CCC    XXXXXX   XCCC     CCC   AAAAAAAA         SSSS       SCCC     CCC  RRRR   RRRRR NNNNNN NNNN  
' CCCC            XXXXXX   XCCC           AAAAAAAA         SSSSSSS    SCCC          RRRRRRRRRRR  NNNNNNNNNNN  
' CCCC            XXXXX    XCCC           AAAA AAAA         SSSSSSSSS SCCC          RRRRRRRRRRR  NNNNNNNNNNN  
' CCCC            XXXXXX   XCCC          AAAAAAAAAA           SSSSSSS SCCC          RRRRRRRR     NNNNNNNNNNN  
' CCCC     CCC   XXXXXXXX  XCCC     CCC  AAAAAAAAAAA             SSSSSSCCC     CCC  RRRR RRRR    NNNNNNNNNNN  
'  CCCC   CCCCC  XXXXXXXX   CCCC   CCCCC AAAAAAAAAAA       SSS    SSSS CCCC   CCCCC RRRR  RRRR   NNNN NNNNNN  
'  CCCCCCCCCCC  XXXX XXXXX  CCCCCCCCCCC CAAA    AAAA       SSSSSSSSSSS CCCCCCCCCCC  RRRR  RRRRR  NNNN  NNNNN  
'   CCCCCCCCCC XXXXX  XXXXX  CCCCCCCCCC CAAA     AAAA      SSSSSSSSSS   CCCCCCCCCC  RRRR   RRRRR NNNN  NNNNN  
'    CCCCCCC   XXXX    XXXX   CCCCCCC  CCAAA     AAAA       SSSSSSSS     CCCCCCC    RRRR    RRRR NNNN   NNNN  
Sub CXCA_SCRN()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AAB10")) Then
'Negative
'15-19
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAB10")
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAC10")
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAD10")
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAE10")
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAF10")
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAG10")
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAH10")
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAI10")
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Positive
'15-19
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAJ10")
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAK10")
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAL10")
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAM10")
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAN10")
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAO10")
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAP10")
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAQ10")
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Suspected
'15-19
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAR10")
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAS10")
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAT10")
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAU10")
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAV10")
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAW10")
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAX10")
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAY10")
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

'TTTTTTTTTTTXXXX  XXXXX      MMMM   MMMMMM LLLL       
'TTTTTTTTTTTXXXX  XXXX       MMMM   MMMMMM LLLL       
'TTTTTTTTTTTXXXXXXXXXX       MMMM   MMMMMM LLLL       
'   TTTT     XXXXXXXX        MMMMM MMMMMMM LLLL       
'   TTTT      XXXXXX         MMMMM MMMMMMM LLLL       
'   TTTT      XXXXXX         MMMMM MMMMMMM LLLL       
'   TTTT      XXXXX          MMMMMMMMMMMMM LLLL       
'   TTTT      XXXXXX         MMMMMMMMMMMMM LLLL       
'   TTTT     XXXXXXXX        MMMMMMMMMMMMM LLLL       
'   TTTT     XXXXXXXX        MM MMMMM MMMM LLLL       
'   TTTT    XXXX XXXXX       MM MMMMM MMMM LLLLLLLLL  
'   TTTT   TXXXX  XXXXX      MM MMMMM MMMM LLLLLLLLL  
'   TTTT   TXXX    XXXX      MM MMMMM MMMM LLLLLLLLL  
Sub TX_ML()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ABA10")) Then
'<1,F,Died
IE.Document.GetElementByID("DRRao8jDO3b-HCBbyzN9hg8-val").Focus
IE.Document.GetElementByID("DRRao8jDO3b-HCBbyzN9hg8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABA10")
IE.Document.GetElementByID("DRRao8jDO3b-HCBbyzN9hg8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-DuKFTCDTm36-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-DuKFTCDTm36-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABB10")
IE.Document.GetElementByID("DRRao8jDO3b-DuKFTCDTm36-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-UbzJ7tg5zo2-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-UbzJ7tg5zo2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABC10")
IE.Document.GetElementByID("DRRao8jDO3b-UbzJ7tg5zo2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-zh9NgGkXtF8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-zh9NgGkXtF8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABD10")
IE.Document.GetElementByID("DRRao8jDO3b-zh9NgGkXtF8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Hs4V3lH4yQU-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Hs4V3lH4yQU-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABE10")
IE.Document.GetElementByID("DRRao8jDO3b-Hs4V3lH4yQU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-UmxJVH7qDiF-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-UmxJVH7qDiF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABF10")
IE.Document.GetElementByID("DRRao8jDO3b-UmxJVH7qDiF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Equr4VbOl5H-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Equr4VbOl5H-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABG10")
IE.Document.GetElementByID("DRRao8jDO3b-Equr4VbOl5H-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-LInafos6gzb-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-LInafos6gzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABH10")
IE.Document.GetElementByID("DRRao8jDO3b-LInafos6gzb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-C87iWhgzBDu-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-C87iWhgzBDu-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABI10")
IE.Document.GetElementByID("DRRao8jDO3b-C87iWhgzBDu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-JQEU6nKw7gb-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-JQEU6nKw7gb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABJ10")
IE.Document.GetElementByID("DRRao8jDO3b-JQEU6nKw7gb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-P0NgrRvn84T-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-P0NgrRvn84T-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABK10")
IE.Document.GetElementByID("DRRao8jDO3b-P0NgrRvn84T-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-yybElZFCO86-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-yybElZFCO86-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABL10")
IE.Document.GetElementByID("DRRao8jDO3b-yybElZFCO86-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M,Died                                                                                                   
IE.Document.GetElementByID("DRRao8jDO3b-jWiak0ltNja-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-jWiak0ltNja-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABM10")
IE.Document.GetElementByID("DRRao8jDO3b-jWiak0ltNja-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-e8nZ8Rb8EMt-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-e8nZ8Rb8EMt-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABN10")
IE.Document.GetElementByID("DRRao8jDO3b-e8nZ8Rb8EMt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-xVjQHjVzAU0-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-xVjQHjVzAU0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABO10")
IE.Document.GetElementByID("DRRao8jDO3b-xVjQHjVzAU0-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-mjJM5dG14VO-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-mjJM5dG14VO-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABP10")
IE.Document.GetElementByID("DRRao8jDO3b-mjJM5dG14VO-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-E8qNYIDZfnQ-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-E8qNYIDZfnQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABQ10")
IE.Document.GetElementByID("DRRao8jDO3b-E8qNYIDZfnQ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-WMOWrnR0Tk6-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-WMOWrnR0Tk6-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABR10")
IE.Document.GetElementByID("DRRao8jDO3b-WMOWrnR0Tk6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Ftq9p9Xzahl-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Ftq9p9Xzahl-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABS10")
IE.Document.GetElementByID("DRRao8jDO3b-Ftq9p9Xzahl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-QKoLnrKVGpz-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-QKoLnrKVGpz-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABT10")
IE.Document.GetElementByID("DRRao8jDO3b-QKoLnrKVGpz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-fNEJdk6Vl8e-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-fNEJdk6Vl8e-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABU10")
IE.Document.GetElementByID("DRRao8jDO3b-fNEJdk6Vl8e-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-GnyPqshMifv-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-GnyPqshMifv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABV10")
IE.Document.GetElementByID("DRRao8jDO3b-GnyPqshMifv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-P7KWqQDn7W5-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-P7KWqQDn7W5-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABW10")
IE.Document.GetElementByID("DRRao8jDO3b-P7KWqQDn7W5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,M,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-oBEwjtWfAr1-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-oBEwjtWfAr1-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABX10")
IE.Document.GetElementByID("DRRao8jDO3b-oBEwjtWfAr1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ABY10")) Then
'<1,F,Undocumented
IE.Document.GetElementByID("DRRao8jDO3b-jcGn34hM7CM-val").Focus
IE.Document.GetElementByID("DRRao8jDO3b-jcGn34hM7CM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABY10")
IE.Document.GetElementByID("DRRao8jDO3b-jcGn34hM7CM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F,Undocumented                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-snzivZEJGbS-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-snzivZEJGbS-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABZ10")
IE.Document.GetElementByID("DRRao8jDO3b-snzivZEJGbS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F,Undocumented                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-lAeUhj40On2-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-lAeUhj40On2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACA10")
IE.Document.GetElementByID("DRRao8jDO3b-lAeUhj40On2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-M9K61pkTRQ7-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-M9K61pkTRQ7-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACB10")
IE.Document.GetElementByID("DRRao8jDO3b-M9K61pkTRQ7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-xquAaKS2vus-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-xquAaKS2vus-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACC10")
IE.Document.GetElementByID("DRRao8jDO3b-xquAaKS2vus-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-nT8jUXqnSZb-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-nT8jUXqnSZb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACD10")
IE.Document.GetElementByID("DRRao8jDO3b-nT8jUXqnSZb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-v2PeaF7bkNQ-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-v2PeaF7bkNQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACE10")
IE.Document.GetElementByID("DRRao8jDO3b-v2PeaF7bkNQ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-bSYbnekjG80-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-bSYbnekjG80-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACF10")
IE.Document.GetElementByID("DRRao8jDO3b-bSYbnekjG80-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-FDfLnvQHv36-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-FDfLnvQHv36-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACG10")
IE.Document.GetElementByID("DRRao8jDO3b-FDfLnvQHv36-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-sSCq0rQzP3N-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-sSCq0rQzP3N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACH10")
IE.Document.GetElementByID("DRRao8jDO3b-sSCq0rQzP3N-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-GSreeLJQ9zl-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-GSreeLJQ9zl-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACI10")
IE.Document.GetElementByID("DRRao8jDO3b-GSreeLJQ9zl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F,Undocumented                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-Wmb3xexdwAm-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Wmb3xexdwAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACJ10")
IE.Document.GetElementByID("DRRao8jDO3b-Wmb3xexdwAm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M,Undocumented                                                                                                   
IE.Document.GetElementByID("DRRao8jDO3b-w2CW3477MZM-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-w2CW3477MZM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACK10")
IE.Document.GetElementByID("DRRao8jDO3b-w2CW3477MZM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M,Undocumented                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-jxzbYhmX5nG-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-jxzbYhmX5nG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACL10")
IE.Document.GetElementByID("DRRao8jDO3b-jxzbYhmX5nG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M,Undocumented                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-TcEjofQpSBV-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-TcEjofQpSBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACM10")
IE.Document.GetElementByID("DRRao8jDO3b-TcEjofQpSBV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Fqe0m1jYRXf-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Fqe0m1jYRXf-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACN10")
IE.Document.GetElementByID("DRRao8jDO3b-Fqe0m1jYRXf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-QuXcOl4tIsf-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-QuXcOl4tIsf-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACO10")
IE.Document.GetElementByID("DRRao8jDO3b-QuXcOl4tIsf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-hUSzr4Oih8g-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-hUSzr4Oih8g-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACP10")
IE.Document.GetElementByID("DRRao8jDO3b-hUSzr4Oih8g-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-MfGPeF35m97-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-MfGPeF35m97-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACQ10")
IE.Document.GetElementByID("DRRao8jDO3b-MfGPeF35m97-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-y3dBv0HtQYZ-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-y3dBv0HtQYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACR10")
IE.Document.GetElementByID("DRRao8jDO3b-y3dBv0HtQYZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-ZDG6xrz1vws-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ZDG6xrz1vws-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACS10")
IE.Document.GetElementByID("DRRao8jDO3b-ZDG6xrz1vws-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-IKqHtXAF5M4-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-IKqHtXAF5M4-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACT10")
IE.Document.GetElementByID("DRRao8jDO3b-IKqHtXAF5M4-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M,Undocumented                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-T3KexHFBsiY-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-T3KexHFBsiY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACU10")
IE.Document.GetElementByID("DRRao8jDO3b-T3KexHFBsiY-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,M,Undocumented                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-L10xZJdRTfn-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-L10xZJdRTfn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACV10")
IE.Document.GetElementByID("DRRao8jDO3b-L10xZJdRTfn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ACW10")) Then
'<1,F,Traced
IE.Document.GetElementByID("DRRao8jDO3b-HV1wVebGpMx-val").Focus
IE.Document.GetElementByID("DRRao8jDO3b-HV1wVebGpMx-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACW10")
IE.Document.GetElementByID("DRRao8jDO3b-HV1wVebGpMx-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-ZaX7T1mm60R-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ZaX7T1mm60R-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACX10")
IE.Document.GetElementByID("DRRao8jDO3b-ZaX7T1mm60R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-VMun3Ah6e2k-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-VMun3Ah6e2k-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACY10")
IE.Document.GetElementByID("DRRao8jDO3b-VMun3Ah6e2k-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-LllUyIWhS95-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-LllUyIWhS95-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACZ10")
IE.Document.GetElementByID("DRRao8jDO3b-LllUyIWhS95-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-EUfl8e8BFwN-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-EUfl8e8BFwN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADA10")
IE.Document.GetElementByID("DRRao8jDO3b-EUfl8e8BFwN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-yGoN7frP7i8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-yGoN7frP7i8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADB10")
IE.Document.GetElementByID("DRRao8jDO3b-yGoN7frP7i8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-ku6Q0SHxw6c-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ku6Q0SHxw6c-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADC10")
IE.Document.GetElementByID("DRRao8jDO3b-ku6Q0SHxw6c-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-uKQCp8AOQUL-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-uKQCp8AOQUL-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADD10")
IE.Document.GetElementByID("DRRao8jDO3b-uKQCp8AOQUL-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-l1DgaTNLde2-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-l1DgaTNLde2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADE10")
IE.Document.GetElementByID("DRRao8jDO3b-l1DgaTNLde2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Qw8gl4XnlCl-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Qw8gl4XnlCl-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADF10")
IE.Document.GetElementByID("DRRao8jDO3b-Qw8gl4XnlCl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-We6rTd6cmTn-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-We6rTd6cmTn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADG10")
IE.Document.GetElementByID("DRRao8jDO3b-We6rTd6cmTn-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-Sf78ll04lov-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Sf78ll04lov-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADH10")
IE.Document.GetElementByID("DRRao8jDO3b-Sf78ll04lov-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M,Traced                                                                                                   
IE.Document.GetElementByID("DRRao8jDO3b-ZRAcFMpcVKE-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ZRAcFMpcVKE-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADI10")
IE.Document.GetElementByID("DRRao8jDO3b-ZRAcFMpcVKE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-gDy1YoIcG47-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-gDy1YoIcG47-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADJ10")
IE.Document.GetElementByID("DRRao8jDO3b-gDy1YoIcG47-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-rHMVe4mVaaF-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-rHMVe4mVaaF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADK10")
IE.Document.GetElementByID("DRRao8jDO3b-rHMVe4mVaaF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-QDMMRyv1b7C-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-QDMMRyv1b7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADL10")
IE.Document.GetElementByID("DRRao8jDO3b-QDMMRyv1b7C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-MnuYBsHKprM-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-MnuYBsHKprM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADM10")
IE.Document.GetElementByID("DRRao8jDO3b-MnuYBsHKprM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-e5VaP9zoRlF-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-e5VaP9zoRlF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADN10")
IE.Document.GetElementByID("DRRao8jDO3b-e5VaP9zoRlF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-d7q0I4AnH38-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-d7q0I4AnH38-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADO10")
IE.Document.GetElementByID("DRRao8jDO3b-d7q0I4AnH38-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-iCf9JjKSCs9-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-iCf9JjKSCs9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADP10")
IE.Document.GetElementByID("DRRao8jDO3b-iCf9JjKSCs9-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-sZC9E3g2YMR-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-sZC9E3g2YMR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADQ10")
IE.Document.GetElementByID("DRRao8jDO3b-sZC9E3g2YMR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-DkxCY8ooSbT-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-DkxCY8ooSbT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADR10")
IE.Document.GetElementByID("DRRao8jDO3b-DkxCY8ooSbT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-B9qdd7xhhV8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-B9qdd7xhhV8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADS10")
IE.Document.GetElementByID("DRRao8jDO3b-B9qdd7xhhV8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,M,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-GNsVNj0Ixaf-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-GNsVNj0Ixaf-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADT10")
IE.Document.GetElementByID("DRRao8jDO3b-GNsVNj0Ixaf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ADU10")) Then
'<1,F,Not Traced
IE.Document.GetElementByID("DRRao8jDO3b-WaZ44hZGwnz-val").Focus
IE.Document.GetElementByID("DRRao8jDO3b-WaZ44hZGwnz-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADU10")
IE.Document.GetElementByID("DRRao8jDO3b-WaZ44hZGwnz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,F,Not Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-GXFo4k45eAM-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-GXFo4k45eAM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADV10")
IE.Document.GetElementByID("DRRao8jDO3b-GXFo4k45eAM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,F,Not Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-vKg75GjS5QU-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-vKg75GjS5QU-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADW10")
IE.Document.GetElementByID("DRRao8jDO3b-vKg75GjS5QU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-dZwhp1lGH3p-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-dZwhp1lGH3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADX10")
IE.Document.GetElementByID("DRRao8jDO3b-dZwhp1lGH3p-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Q8IE6eZFU6b-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Q8IE6eZFU6b-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADY10")
IE.Document.GetElementByID("DRRao8jDO3b-Q8IE6eZFU6b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-sFYVPJeZeF8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-sFYVPJeZeF8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADZ10")
IE.Document.GetElementByID("DRRao8jDO3b-sFYVPJeZeF8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-EOlZOp0zPC8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-EOlZOp0zPC8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEA10")
IE.Document.GetElementByID("DRRao8jDO3b-EOlZOp0zPC8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-dN1vezY5hMc-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-dN1vezY5hMc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEB10")
IE.Document.GetElementByID("DRRao8jDO3b-dN1vezY5hMc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-FrXeF1L4Cai-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-FrXeF1L4Cai-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEC10")
IE.Document.GetElementByID("DRRao8jDO3b-FrXeF1L4Cai-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-I3s48dA0POC-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-I3s48dA0POC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AED10")
IE.Document.GetElementByID("DRRao8jDO3b-I3s48dA0POC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,F,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-DRuqLDykEsD-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-DRuqLDykEsD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEE10")
IE.Document.GetElementByID("DRRao8jDO3b-DRuqLDykEsD-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,F,Not Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-O5R93yZV2vI-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-O5R93yZV2vI-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEF10")
IE.Document.GetElementByID("DRRao8jDO3b-O5R93yZV2vI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'<1,M,Not Traced                                                                                                   
IE.Document.GetElementByID("DRRao8jDO3b-O5eSRv5ilPX-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-O5eSRv5ilPX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEG10")
IE.Document.GetElementByID("DRRao8jDO3b-O5eSRv5ilPX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'1-4,M,Not Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-s7cVR8kuw6O-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-s7cVR8kuw6O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEH10")
IE.Document.GetElementByID("DRRao8jDO3b-s7cVR8kuw6O-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'5-9,M,Not Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-lYZr3YQFhJT-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-lYZr3YQFhJT-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEI10")
IE.Document.GetElementByID("DRRao8jDO3b-lYZr3YQFhJT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'10-14,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Pl43wEY2mzc-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Pl43wEY2mzc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEJ10")
IE.Document.GetElementByID("DRRao8jDO3b-Pl43wEY2mzc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'15-19,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-fiPPb7yWErg-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-fiPPb7yWErg-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEK10")
IE.Document.GetElementByID("DRRao8jDO3b-fiPPb7yWErg-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'20-24,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Ruc2yLIdJ9j-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Ruc2yLIdJ9j-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEL10")
IE.Document.GetElementByID("DRRao8jDO3b-Ruc2yLIdJ9j-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'25-29,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-KMZYnlijkNP-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-KMZYnlijkNP-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEM10")
IE.Document.GetElementByID("DRRao8jDO3b-KMZYnlijkNP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'30-34,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Dd09elTPhgB-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Dd09elTPhgB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEN10")
IE.Document.GetElementByID("DRRao8jDO3b-Dd09elTPhgB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'35-39,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-qIUoao32x7G-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-qIUoao32x7G-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEO10")
IE.Document.GetElementByID("DRRao8jDO3b-qIUoao32x7G-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'40-44,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-BqaHdvdIGjY-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-BqaHdvdIGjY-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEP10")
IE.Document.GetElementByID("DRRao8jDO3b-BqaHdvdIGjY-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'45-49,M,Not Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-ZgKfWGQK5xR-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ZgKfWGQK5xR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEQ10")
IE.Document.GetElementByID("DRRao8jDO3b-ZgKfWGQK5xR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:01")                                                            
'50+,M,Not Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-RSNoAYua8oo-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-RSNoAYua8oo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AER10")
IE.Document.GetElementByID("DRRao8jDO3b-RSNoAYua8oo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' TTTTTTTTTTTXXXX  XXXXX       TTTTTTTTTTBBBBBBBBBB   
' TTTTTTTTTTTXXXX  XXXX        TTTTTTTTTTBBBBBBBBBBB  
' TTTTTTTTTTTXXXXXXXXXX        TTTTTTTTTTBBBBBBBBBBB  
'    TTTT     XXXXXXXX           TTTT    BBBB   BBBB  
'    TTTT      XXXXXX            TTTT    BBBB   BBBB  
'    TTTT      XXXXXX            TTTT    BBBBBBBBBBB  
'    TTTT      XXXXX             TTTT    BBBBBBBBBB   
'    TTTT      XXXXXX            TTTT    BBBBBBBBBBB  
'    TTTT     XXXXXXXX           TTTT    BBBB    BBB  
'    TTTT     XXXXXXXX           TTTT    BBBB    BBB  
'    TTTT    XXXX XXXXX          TTTT    BBBBBBBBBBB  
'    TTTT   TXXXX  XXXXX         TTTT    BBBBBBBBBBB  
'    TTTT   TXXX    XXXX         TTTT    BBBBBBBBBB   
Sub TX_TB()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AET10")) Then
'Numerator
'New,F,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-ptrqjblDpVl-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-ptrqjblDpVl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AET10")
IE.Document.GetElementByID("DHhB2W8z4k6-ptrqjblDpVl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New,F,15+                                                                                        
IE.Document.GetElementByID("DHhB2W8z4k6-hcF36Hpaxmu-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-hcF36Hpaxmu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEU10")
IE.Document.GetElementByID("DHhB2W8z4k6-hcF36Hpaxmu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-EP6ShhD5ntH-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-EP6ShhD5ntH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEV10")
IE.Document.GetElementByID("DHhB2W8z4k6-EP6ShhD5ntH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'New,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-b2lYKJk1pWg-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-b2lYKJk1pWg-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEW10")
IE.Document.GetElementByID("DHhB2W8z4k6-b2lYKJk1pWg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Already,F,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-ujjzYH3AbhZ-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-ujjzYH3AbhZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEX10")
IE.Document.GetElementByID("DHhB2W8z4k6-ujjzYH3AbhZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Already,F,15+                                                                                        
IE.Document.GetElementByID("DHhB2W8z4k6-IKLIV8BEfT2-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-IKLIV8BEfT2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEY10")
IE.Document.GetElementByID("DHhB2W8z4k6-IKLIV8BEfT2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Already,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-Cqb6VN74EwO-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-Cqb6VN74EwO-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEZ10")
IE.Document.GetElementByID("DHhB2W8z4k6-Cqb6VN74EwO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Already,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-TWPXb0rvc3p-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-TWPXb0rvc3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFA10")
IE.Document.GetElementByID("DHhB2W8z4k6-TWPXb0rvc3p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AFC10")) Then
'Denominator
'SP, Newly, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-qEv2Oi1bHsp-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-qEv2Oi1bHsp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFC10")
IE.Document.GetElementByID("YVqdD78gGE1-qEv2Oi1bHsp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'SP, Newly, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-BpjQgbuhZoo-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-BpjQgbuhZoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFD10")
IE.Document.GetElementByID("YVqdD78gGE1-BpjQgbuhZoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'SP, Newly, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-zpOXupkpl7i-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-zpOXupkpl7i-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFE10")
IE.Document.GetElementByID("YVqdD78gGE1-zpOXupkpl7i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'SP, Newly, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-Y9GhVNf8jUd-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-Y9GhVNf8jUd-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFF10")
IE.Document.GetElementByID("YVqdD78gGE1-Y9GhVNf8jUd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'SP, Already, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-qBj9XLbUigZ-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-qBj9XLbUigZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFG10")
IE.Document.GetElementByID("YVqdD78gGE1-qBj9XLbUigZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'SP, Already, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-vsVKGzHxDua-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-vsVKGzHxDua-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFH10")
IE.Document.GetElementByID("YVqdD78gGE1-vsVKGzHxDua-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'SP, Already, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-VyeN2c8Zdi4-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-VyeN2c8Zdi4-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFI10")
IE.Document.GetElementByID("YVqdD78gGE1-VyeN2c8Zdi4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'SP, Already, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-SZ3D287on4h-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-SZ3D287on4h-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFJ10")
IE.Document.GetElementByID("YVqdD78gGE1-SZ3D287on4h-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Newly, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-KcI8l7j9oeX-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-KcI8l7j9oeX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFK10")
IE.Document.GetElementByID("YVqdD78gGE1-KcI8l7j9oeX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Newly, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-kCzjNAGH5GY-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-kCzjNAGH5GY-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFL10")
IE.Document.GetElementByID("YVqdD78gGE1-kCzjNAGH5GY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Newly, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-JURc3Uxzcr9-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-JURc3Uxzcr9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFM10")
IE.Document.GetElementByID("YVqdD78gGE1-JURc3Uxzcr9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Newly, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-rktDV3ZuQjl-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-rktDV3ZuQjl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFN10")
IE.Document.GetElementByID("YVqdD78gGE1-rktDV3ZuQjl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Already, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-yxdKq1ZC8fS-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-yxdKq1ZC8fS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFO10")
IE.Document.GetElementByID("YVqdD78gGE1-yxdKq1ZC8fS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Already, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-DFLZuSpRYKv-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-DFLZuSpRYKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFP10")
IE.Document.GetElementByID("YVqdD78gGE1-DFLZuSpRYKv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Already, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-NrvW7I8iYbo-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-NrvW7I8iYbo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFQ10")
IE.Document.GetElementByID("YVqdD78gGE1-NrvW7I8iYbo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'NP, Already, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-u53iyNLwf4u-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-u53iyNLwf4u-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFR10")
IE.Document.GetElementByID("YVqdD78gGE1-u53iyNLwf4u-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Specimen Sent
IE.Document.GetElementByID("PoKIzQ3T4lw-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("PoKIzQ3T4lw-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFS10")
IE.Document.GetElementByID("PoKIzQ3T4lw-LVcCRCAVjwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Smear Only
IE.Document.GetElementByID("USg8dlTs8WO-JNmiNNuzOP4-val").Focus
IE.Document.GetElementByID("USg8dlTs8WO-JNmiNNuzOP4-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFT10")
IE.Document.GetElementByID("USg8dlTs8WO-JNmiNNuzOP4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Gene Xpert
IE.Document.GetElementByID("USg8dlTs8WO-QHwgGBc0snC-val").Focus
IE.Document.GetElementByID("USg8dlTs8WO-QHwgGBc0snC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFU10")
IE.Document.GetElementByID("USg8dlTs8WO-QHwgGBc0snC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Other
IE.Document.GetElementByID("USg8dlTs8WO-zfBoZZIHjmY-val").Focus
IE.Document.GetElementByID("USg8dlTs8WO-zfBoZZIHjmY-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFV10")
IE.Document.GetElementByID("USg8dlTs8WO-zfBoZZIHjmY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Positve returned
IE.Document.GetElementByID("njaIfoj0S6a-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("njaIfoj0S6a-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFW10")
IE.Document.GetElementByID("njaIfoj0S6a-LVcCRCAVjwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

'    CCCCCCC   XXXXX  XXXXX   CCCCCCC       AAAAA          TTTTTTTTTTXXXXX  XXXXX  
'   CCCCCCCCC   XXXX  XXXX   CCCCCCCCC      AAAAA          TTTTTTTTTTXXXXX  XXXX   
'  CCCCCCCCCCC  XXXXXXXXXX  CCCCCCCCCCC    AAAAAA          TTTTTTTTTTXXXXXXXXXXX   
'  CCCC   CCCCC  XXXXXXXX   CCCC   CCCCC   AAAAAAA            TTTT     XXXXXXXX    
' CCCC     CCC    XXXXXX   XCCC     CCC   AAAAAAAA            TTTT      XXXXXX     
' CCCC            XXXXXX   XCCC           AAAAAAAA            TTTT      XXXXXX     
' CCCC            XXXXX    XCCC           AAAA AAAA           TTTT      XXXXX      
' CCCC            XXXXXX   XCCC          AAAAAAAAAA           TTTT      XXXXXX     
' CCCC     CCC   XXXXXXXX  XCCC     CCC  AAAAAAAAAAA          TTTT     XXXXXXXX    
'  CCCC   CCCCC  XXXXXXXX   CCCC   CCCCC AAAAAAAAAAA          TTTT     XXXXXXXX    
'  CCCCCCCCCCC  XXXX XXXXX  CCCCCCCCCCC CAAA    AAAA          TTTT    XXXX XXXXX   
'   CCCCCCCCCC XXXXX  XXXXX  CCCCCCCCCC CAAA     AAAA         TTTT   XXXXX  XXXXX  
'    CCCCCCC   XXXX    XXXX   CCCCCCC  CCAAA     AAAA         TTTT   XXXX    XXXX  
Sub CXCA_TX()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AFY10")) Then
'Cervical Cancer screen: Cryotherapy
'15-19
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFY10")
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'20-24
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFZ10")
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'25-29
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGA10")
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'30-34
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGB10")
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'35-39
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGC10")
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'40-44
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGD10")
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'45-49
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGE10")
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'50+
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGF10")
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

Sub SendEmailNotification()

    Dim NewMail As Object
    Dim mailConfig As Object
    Dim fields As Variant
    Dim msConfigURL As String

    Set NewMail = CreateObject("CDO.Message")
    Set mailConfig = CreateObject("CDO.Configuration")

    ' load all default configurations
    mailConfig.Load -1

    Set fields = mailConfig.fields

    Dim lStr As String
    lStr = ""
    lStr =  lStr & "<table border='1' style='border-color:#EEEEEE;' cellspacing='0' cellpadding='5' width=420><tr><td colspan='2' style='background-color:#0288D1;color:white;text-align:center;'>Digitação automática completa no DATIM</td></tr><tr><td bgcolor='#F3F3F3'>Nome do Utilizador do<br>Sistema Operativo:</td><td>" & FormProgressBar.LabelUserInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Agente do Utilizador:</td><td>" & FormProgressBar.LabelUserAgentInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora inicial:</td><td>" & startTime2 & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora final:</td><td>" & endTime2 & "</td></tr><tr><td bgcolor='#F3F3F3'>Duração:</td><td>" & Format(fillDuration2, "hh") & ":" & Format(fillDuration2, "nn:ss") & "</td></tr><tr><td bgcolor='#F3F3F3'>Período de reportagem:</td><td>" & Replace(ThisWorkbook.Sheets("sheet1").Range("A4"),"Period:","") & "</td></tr>"
    lStr =  lStr & "<tr><td bgcolor='#F3F3F3'>Unidade Organizacional<br>digitada:</td><td>" & ThisWorkbook.Sheets("sheet1").Range("A10") & " (" & ThisWorkbook.Sheets("sheet1").Range("B10") & ")" & "</td></tr>"
    lStr =  lStr & "<tr><td bgcolor='#F3F3F3'>Observação:</td><td>" & ThisWorkbook.Sheets("sheet1").Range("A5") & "</td></tr><tr><td colspan='2' style='text-align:center;background-color:#0288D1;color:white;'> <a href='http://196.28.230.195:8080/dhis'><span style='color:#00FFFF;'>DHIS-FGH</span></a><br><a href='https://www.datim.org/'><span style='color:#00FFFF;'>DATIM</span></a><br>" & Year(Now()) & " &copy; <a href='mailto:sis@fgh.org.mz'><span style='color:#00FFFF;'>sis@fgh.org.mz</span></a></td></tr></table>"

    'Set All Email Properties
    With NewMail
        .Subject = "[SIS-FGH] Digitação automática completa no DATIM"
        .From = "dhis.fgh@gmail.com"
        .To = ""
        .CC = ""
        '.BCC= "damasceno.lopes@fgh.org.mz"
        .BCC = "damasceno.lopes@fgh.org.mz;prosperino.mbalame@fgh.org.mz;hamilton.mutemba@fgh.org.mz;eurico.jose@fgh.org.mz;antonio.mastala@fgh.org.mz;idelina.albano@fgh.org.mz;luis.macave@fgh.org.mz"
        .HTMLBody = lStr
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
   


End Sub