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

Else

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("AAV10")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AAV10")) Then
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
    Call IE.Document.parentWindow.execScript("javascript:void selection.select( '" & ThisWorkbook.Sheets("sheet1").Range("AAV10") & "' )", "JavaScript")
    Application.Wait Now + TimeValue("00:00:04")
    
    'Select the Dataset and Period only at 1st time
    If i = 1 Then
    Set evt = IE.Document.createEvent("HTMLEvents")
    evt.initEvent "change", True, False
    'Select Dataset
    IE.Document.GetElementByID("selectedDataSetId").Value = "tz1bQ3ZwUKJ"
    IE.Document.GetElementByID("selectedDataSetId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:04")
    'Select the Period
    IE.Document.GetElementByID("selectedPeriodId").Value = "2018Q3"
    IE.Document.GetElementByID("selectedPeriodId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:12")
    End If

    '--------------------------------------------------------------------
    '                        CALL FUNCTIONS
    '--------------------------------------------------------------------
    'Control here the Data that have to writed on DATIM Form
    'Quarterly
    Call PrEP
    Call HTS_TST_Numerator
    Call PICT_Inpatient
    Call PICT_Pediatric
    Call PICT_TB_Clinic
    Call PICT_PMTCT_ANC
    Call PICT_Emergency
    Call PICT_Other
    Call VCT
    Call Index_Testing
    Call PMTCT_STAT
    Call PMTCT_EID_HEI_POS
    Call TX_NEW_TX_CURR
    Call PMTCT_ART
    
    'Semiannually
    Call TB_PREV
    Call TB_STAT
    Call TB_ART
    Call TX_TB
    Call CXCA_SCRN
    Call CXCA_TX
    
    'Annually
    Call GEND_GBV
    Call FPINT_SITE
    Call TX_RET
    Call TX_PVLS
    Call HRH
    Call LAB_PTCQI
    'Call PMTCT_FO

    ThisWorkbook.Sheets("sheet1").Rows(10).EntireRow.Delete
    Application.Wait Now + TimeValue("00:00:04") 

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

'--------------------------------------------------------------------
'                        FUNCTIONS
'--------------------------------------------------------------------
' PPPPPPPPP          rEEEEEEEEEE EPPPPPPPP    
' PPPPPPPPPP         rEEEEEEEEEE EPPPPPPPPP   
' PPPPPPPPPPP        rEEEEEEEEEE EPPPPPPPPPP  
' PPPP   PPPPPPrrrrrrrEEE        EPPP   PPPP  
' PPPP   PPPPPPrrrrrrrEEE        EPPP   PPPP  
' PPPPPPPPPPPPPrrr   rEEEEEEEEE  EPPPPPPPPPP  
' PPPPPPPPPP PPrr    rEEEEEEEEE  EPPPPPPPPP   
' PPPPPPPPP  PPrr    rEEEEEEEEE  EPPPPPPPP    
' PPPP       PPrr    rEEE        EPPP         
' PPPP       PPrr    rEEE        EPPP         
' PPPP       PPrr    rEEEEEEEEEE EPPP         
' PPPP       PPrr    rEEEEEEEEEE EPPP         
' PPPP       PPrr    rEEEEEEEEEE EPPP           
Sub PrEP()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-2").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-7").Click
Else
IE.Document.GetElementByID("ui-id-8").Click
End If
Application.Wait Now + TimeValue("00:00:03")
'PrEP_NEW
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("C10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WQqBCWI0gND-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("WQqBCWI0gND-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("C10")
IE.Document.GetElementByID("WQqBCWI0gND-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bz61aPNTomM-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("bz61aPNTomM-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("C10")
IE.Document.GetElementByID("bz61aPNTomM-HllvX50cXC0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female, 15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-rsDhJVueMlj-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-rsDhJVueMlj-val").Value = ThisWorkbook.Sheets("sheet1").Range("D10")
IE.Document.GetElementByID("KNO4emPfF91-rsDhJVueMlj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-rsDhJVueMlj-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-rsDhJVueMlj-val").Value = ThisWorkbook.Sheets("sheet1").Range("D10")
IE.Document.GetElementByID("b6OI9qB0Who-rsDhJVueMlj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female, 20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-Eb1wUeyQfm1-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-Eb1wUeyQfm1-val").Value = ThisWorkbook.Sheets("sheet1").Range("E10")
IE.Document.GetElementByID("KNO4emPfF91-Eb1wUeyQfm1-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-Eb1wUeyQfm1-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-Eb1wUeyQfm1-val").Value = ThisWorkbook.Sheets("sheet1").Range("E10")
IE.Document.GetElementByID("b6OI9qB0Who-Eb1wUeyQfm1-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female, 25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-SOyl1KfM62E-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-SOyl1KfM62E-val").Value = ThisWorkbook.Sheets("sheet1").Range("F10")
IE.Document.GetElementByID("KNO4emPfF91-SOyl1KfM62E-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-SOyl1KfM62E-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-SOyl1KfM62E-val").Value = ThisWorkbook.Sheets("sheet1").Range("F10")
IE.Document.GetElementByID("b6OI9qB0Who-SOyl1KfM62E-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female, 30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-WJs7WStaKb7-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-WJs7WStaKb7-val").Value = ThisWorkbook.Sheets("sheet1").Range("G10")
IE.Document.GetElementByID("KNO4emPfF91-WJs7WStaKb7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-WJs7WStaKb7-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-WJs7WStaKb7-val").Value = ThisWorkbook.Sheets("sheet1").Range("G10")
IE.Document.GetElementByID("b6OI9qB0Who-WJs7WStaKb7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female, 35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-D6I9GaYrrcy-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-D6I9GaYrrcy-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
IE.Document.GetElementByID("KNO4emPfF91-D6I9GaYrrcy-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-D6I9GaYrrcy-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-D6I9GaYrrcy-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
IE.Document.GetElementByID("b6OI9qB0Who-D6I9GaYrrcy-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female, 40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-ngxcu4ikzmm-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-ngxcu4ikzmm-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
IE.Document.GetElementByID("KNO4emPfF91-ngxcu4ikzmm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-ngxcu4ikzmm-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-ngxcu4ikzmm-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
IE.Document.GetElementByID("b6OI9qB0Who-ngxcu4ikzmm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female, 50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-kWUjVlYNfMC-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-kWUjVlYNfMC-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
IE.Document.GetElementByID("KNO4emPfF91-kWUjVlYNfMC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-kWUjVlYNfMC-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-kWUjVlYNfMC-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
IE.Document.GetElementByID("b6OI9qB0Who-kWUjVlYNfMC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male, 15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-ijirRiCapCK-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-ijirRiCapCK-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
IE.Document.GetElementByID("KNO4emPfF91-ijirRiCapCK-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-ijirRiCapCK-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-ijirRiCapCK-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
IE.Document.GetElementByID("b6OI9qB0Who-ijirRiCapCK-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male, 20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-twp0pnjjBhU-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-twp0pnjjBhU-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
IE.Document.GetElementByID("KNO4emPfF91-twp0pnjjBhU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-twp0pnjjBhU-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-twp0pnjjBhU-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
IE.Document.GetElementByID("b6OI9qB0Who-twp0pnjjBhU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male, 25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-w3Ke7t08Ca6-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-w3Ke7t08Ca6-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
IE.Document.GetElementByID("KNO4emPfF91-w3Ke7t08Ca6-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-w3Ke7t08Ca6-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-w3Ke7t08Ca6-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
IE.Document.GetElementByID("b6OI9qB0Who-w3Ke7t08Ca6-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male, 30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-dPRznpKPI5f-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-dPRznpKPI5f-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
IE.Document.GetElementByID("KNO4emPfF91-dPRznpKPI5f-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-dPRznpKPI5f-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-dPRznpKPI5f-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
IE.Document.GetElementByID("b6OI9qB0Who-dPRznpKPI5f-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male, 35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-UlVb0KF88sP-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-UlVb0KF88sP-val").Value = ThisWorkbook.Sheets("sheet1").Range("O10")
IE.Document.GetElementByID("KNO4emPfF91-UlVb0KF88sP-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-UlVb0KF88sP-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-UlVb0KF88sP-val").Value = ThisWorkbook.Sheets("sheet1").Range("O10")
IE.Document.GetElementByID("b6OI9qB0Who-UlVb0KF88sP-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male, 40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-lwaRLYm2Yc8-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-lwaRLYm2Yc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("P10")
IE.Document.GetElementByID("KNO4emPfF91-lwaRLYm2Yc8-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-lwaRLYm2Yc8-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-lwaRLYm2Yc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("P10")
IE.Document.GetElementByID("b6OI9qB0Who-lwaRLYm2Yc8-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male, 50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KNO4emPfF91-mpyFgAd2eTH-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-mpyFgAd2eTH-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
IE.Document.GetElementByID("KNO4emPfF91-mpyFgAd2eTH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("b6OI9qB0Who-mpyFgAd2eTH-val").Focus
IE.Document.GetElementByID("b6OI9qB0Who-mpyFgAd2eTH-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
IE.Document.GetElementByID("b6OI9qB0Who-mpyFgAd2eTH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PrEP
End Sub

' HHHH   HHHH  TTTTTTTTTTT SSSSSSS          TTTTTTTTTT SSSSSSS    STTTTTTTT  
' HHHH   HHHH  TTTTTTTTTTTSSSSSSSSS         TTTTTTTTTTSSSSSSSSS   STTTTTTTT  
' HHHH   HHHH  TTTTTTTTTTTSSSSSSSSSS        TTTTTTTTTTSSSSSSSSSS  STTTTTTTT  
' HHHH   HHHH     TTTT   TSSSS  SSSS          TTTT   TSSSS  SSSS     TTTT    
' HHHH   HHHH     TTTT   TSSSS                TTTT   TSSSS           TTTT    
' HHHHHHHHHHH     TTTT    SSSSSSS             TTTT    SSSSSSS        TTTT    
' HHHHHHHHHHH     TTTT     SSSSSSSSS          TTTT     SSSSSSSSS     TTTT    
' HHHHHHHHHHH     TTTT       SSSSSSS          TTTT       SSSSSSS     TTTT    
' HHHH   HHHH     TTTT          SSSSS         TTTT          SSSSS    TTTT    
' HHHH   HHHH     TTTT   TSSS    SSSS         TTTT   TSSS    SSSS    TTTT    
' HHHH   HHHH     TTTT   TSSSSSSSSSSS         TTTT   TSSSSSSSSSSS    TTTT    
' HHHH   HHHH     TTTT    SSSSSSSSSS          TTTT    SSSSSSSSSS     TTTT    
' HHHH   HHHH     TTTT     SSSSSSSS           TTTT     SSSSSSSS      TTTT 
Sub HTS_TST_Numerator()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-3").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-10").Click
Else
IE.Document.GetElementByID("ui-id-11").Click
End If
Application.Wait Now + TimeValue("00:00:03")
'HTS_TST (Facility)
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("R10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K6f6jR0NOcZ-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("K6f6jR0NOcZ-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
IE.Document.GetElementByID("K6f6jR0NOcZ-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FJSew4Ks0j3-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("FJSew4Ks0j3-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
IE.Document.GetElementByID("FJSew4Ks0j3-HllvX50cXC0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End HTS_TST (Facility)
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
'PITC Modality: Inpatient Services
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("W10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
IE.Document.GetElementByID("hvtNfA73XhN-tP2mjgakLVn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
IE.Document.GetElementByID("qZAq6ABJe2I-tP2mjgakLVn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
IE.Document.GetElementByID("hvtNfA73XhN-DszsJew1vQA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
IE.Document.GetElementByID("qZAq6ABJe2I-DszsJew1vQA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
IE.Document.GetElementByID("hvtNfA73XhN-VP9O0ao9MmZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
IE.Document.GetElementByID("qZAq6ABJe2I-VP9O0ao9MmZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
IE.Document.GetElementByID("hvtNfA73XhN-BSQvgbaINGZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
IE.Document.GetElementByID("qZAq6ABJe2I-BSQvgbaINGZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
IE.Document.GetElementByID("hvtNfA73XhN-sDHZqlgc0lv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
IE.Document.GetElementByID("qZAq6ABJe2I-sDHZqlgc0lv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
IE.Document.GetElementByID("hvtNfA73XhN-pz7dlDGQssH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
IE.Document.GetElementByID("qZAq6ABJe2I-pz7dlDGQssH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
IE.Document.GetElementByID("hvtNfA73XhN-GscVGDNCdwR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
IE.Document.GetElementByID("qZAq6ABJe2I-GscVGDNCdwR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
IE.Document.GetElementByID("hvtNfA73XhN-lfHFCxROkNE-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
IE.Document.GetElementByID("qZAq6ABJe2I-lfHFCxROkNE-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
IE.Document.GetElementByID("hvtNfA73XhN-HEpqnVEHzUA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
IE.Document.GetElementByID("qZAq6ABJe2I-HEpqnVEHzUA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AF10")
IE.Document.GetElementByID("hvtNfA73XhN-BOxW7hCTSjX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AF10")
IE.Document.GetElementByID("qZAq6ABJe2I-BOxW7hCTSjX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AG10")
IE.Document.GetElementByID("hvtNfA73XhN-SyBPyzv8HTC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AG10")
IE.Document.GetElementByID("qZAq6ABJe2I-SyBPyzv8HTC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-H250HduQyXi-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AH10")
IE.Document.GetElementByID("hvtNfA73XhN-H250HduQyXi-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-H250HduQyXi-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AH10")
IE.Document.GetElementByID("qZAq6ABJe2I-H250HduQyXi-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AI10")
IE.Document.GetElementByID("hvtNfA73XhN-FLlJURwLmAe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AI10")
IE.Document.GetElementByID("qZAq6ABJe2I-FLlJURwLmAe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
IE.Document.GetElementByID("hvtNfA73XhN-ZAVOIaOudWw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
IE.Document.GetElementByID("qZAq6ABJe2I-ZAVOIaOudWw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
IE.Document.GetElementByID("hvtNfA73XhN-lZiQLcYoM7M-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
IE.Document.GetElementByID("qZAq6ABJe2I-lZiQLcYoM7M-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
IE.Document.GetElementByID("hvtNfA73XhN-RWG4YLNHEdA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
IE.Document.GetElementByID("qZAq6ABJe2I-RWG4YLNHEdA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
IE.Document.GetElementByID("hvtNfA73XhN-E8XxGzk0kY7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
IE.Document.GetElementByID("qZAq6ABJe2I-E8XxGzk0kY7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
IE.Document.GetElementByID("hvtNfA73XhN-FnHZRFcropp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
IE.Document.GetElementByID("qZAq6ABJe2I-FnHZRFcropp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
IE.Document.GetElementByID("hvtNfA73XhN-Hbg53zGRcL7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
IE.Document.GetElementByID("qZAq6ABJe2I-Hbg53zGRcL7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
IE.Document.GetElementByID("hvtNfA73XhN-IHmmeJ1fyKy-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
IE.Document.GetElementByID("qZAq6ABJe2I-IHmmeJ1fyKy-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
IE.Document.GetElementByID("hvtNfA73XhN-dZYJREDXbfa-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
IE.Document.GetElementByID("qZAq6ABJe2I-dZYJREDXbfa-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
IE.Document.GetElementByID("hvtNfA73XhN-flyE54cGOkr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
IE.Document.GetElementByID("qZAq6ABJe2I-flyE54cGOkr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
IE.Document.GetElementByID("hvtNfA73XhN-h3WrcUxOPZ2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
IE.Document.GetElementByID("qZAq6ABJe2I-h3WrcUxOPZ2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("hvtNfA73XhN-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
IE.Document.GetElementByID("hvtNfA73XhN-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qZAq6ABJe2I-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("qZAq6ABJe2I-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
IE.Document.GetElementByID("qZAq6ABJe2I-HSpL3hSBx6F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PITC Modality: Inpatient Services
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
'PITC Modality: Pediatric Services
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AU10")) Then
'Positive,<5
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("SpjvCpxnc20-tfxXAPNxtUc-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-tfxXAPNxtUc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
IE.Document.GetElementByID("SpjvCpxnc20-tfxXAPNxtUc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("TUJPxclPx31-tfxXAPNxtUc-val").Focus
IE.Document.GetElementByID("TUJPxclPx31-tfxXAPNxtUc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
IE.Document.GetElementByID("TUJPxclPx31-tfxXAPNxtUc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Negative,<5
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("SpjvCpxnc20-QV7inC4TQdR-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-QV7inC4TQdR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
IE.Document.GetElementByID("SpjvCpxnc20-QV7inC4TQdR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("TUJPxclPx31-QV7inC4TQdR-val").Focus
IE.Document.GetElementByID("TUJPxclPx31-QV7inC4TQdR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
IE.Document.GetElementByID("TUJPxclPx31-QV7inC4TQdR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PITC Modality: Pediatric Services
End Sub

' TTTTTTTTTTT BBBBBBBBBB          CCCCCCC    llll iiii            iiii            
' TTTTTTTTTTT BBBBBBBBBBB        CCCCCCCCC   llll iiii            iiii            
' TTTTTTTTTTT BBBBBBBBBBB       CCCCCCCCCCC  llll                                 
'    TTTT     BBBB   BBBB       CCCC   CCCCC llll iiii nnnnnnnn   iiii  cccccc    
'    TTTT     BBBB   BBBB       CCC     CCC  llll iiii nnnnnnnnn  iiii cccccccc   
'    TTTT     BBBBBBBBBBB       CCC          llll iiii nnnn nnnnn iiiiicccc cccc  
'    TTTT     BBBBBBBBBB        CCC          llll iiii nnnn  nnnn iiiiiccc  ccc   
'    TTTT     BBBBBBBBBBB       CCC          llll iiii nnnn  nnnn iiiiiccc        
'    TTTT     BBBB    BBBB      CCC     CCC  llll iiii nnnn  nnnn iiiiiccc        
'    TTTT     BBBB    BBBB      CCCC   CCCCC llll iiii nnnn  nnnn iiiiiccc  ccc   
'    TTTT     BBBBBBBBBBBB      CCCCCCCCCCC  llll iiii nnnn  nnnn iiiiicccc cccc  
'    TTTT     BBBBBBBBBBB        CCCCCCCCCC  llll iiii nnnn  nnnn iiii ccccccccc  
'    TTTT     BBBBBBBBBB          CCCCCCC    llll iiii nnnn  nnnn iiii  cccccc 
Sub PICT_TB_Clinic()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'PITC Modality: TB Clinics
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("BA10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
IE.Document.GetElementByID("Ogm7REBudex-tP2mjgakLVn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
IE.Document.GetElementByID("KeklNQcVqTQ-tP2mjgakLVn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
IE.Document.GetElementByID("Ogm7REBudex-DszsJew1vQA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
IE.Document.GetElementByID("KeklNQcVqTQ-DszsJew1vQA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
IE.Document.GetElementByID("Ogm7REBudex-VP9O0ao9MmZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
IE.Document.GetElementByID("KeklNQcVqTQ-VP9O0ao9MmZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
IE.Document.GetElementByID("Ogm7REBudex-BSQvgbaINGZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
IE.Document.GetElementByID("KeklNQcVqTQ-BSQvgbaINGZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
IE.Document.GetElementByID("Ogm7REBudex-sDHZqlgc0lv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
IE.Document.GetElementByID("KeklNQcVqTQ-sDHZqlgc0lv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
IE.Document.GetElementByID("Ogm7REBudex-pz7dlDGQssH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
IE.Document.GetElementByID("KeklNQcVqTQ-pz7dlDGQssH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
IE.Document.GetElementByID("Ogm7REBudex-GscVGDNCdwR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
IE.Document.GetElementByID("KeklNQcVqTQ-GscVGDNCdwR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("BH10")
IE.Document.GetElementByID("Ogm7REBudex-lfHFCxROkNE-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("BH10")
IE.Document.GetElementByID("KeklNQcVqTQ-lfHFCxROkNE-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BI10")
IE.Document.GetElementByID("Ogm7REBudex-HEpqnVEHzUA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BI10")
IE.Document.GetElementByID("KeklNQcVqTQ-HEpqnVEHzUA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("BJ10")
IE.Document.GetElementByID("Ogm7REBudex-BOxW7hCTSjX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("BJ10")
IE.Document.GetElementByID("KeklNQcVqTQ-BOxW7hCTSjX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("BK10")
IE.Document.GetElementByID("Ogm7REBudex-SyBPyzv8HTC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("BK10")
IE.Document.GetElementByID("KeklNQcVqTQ-SyBPyzv8HTC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-H250HduQyXi-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("BL10")
IE.Document.GetElementByID("Ogm7REBudex-H250HduQyXi-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-H250HduQyXi-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("BL10")
IE.Document.GetElementByID("KeklNQcVqTQ-H250HduQyXi-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("BM10")
IE.Document.GetElementByID("Ogm7REBudex-FLlJURwLmAe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("BM10")
IE.Document.GetElementByID("KeklNQcVqTQ-FLlJURwLmAe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("BN10")
IE.Document.GetElementByID("Ogm7REBudex-ZAVOIaOudWw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("BN10")
IE.Document.GetElementByID("KeklNQcVqTQ-ZAVOIaOudWw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("BO10")
IE.Document.GetElementByID("Ogm7REBudex-lZiQLcYoM7M-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("BO10")
IE.Document.GetElementByID("KeklNQcVqTQ-lZiQLcYoM7M-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BP10")
IE.Document.GetElementByID("Ogm7REBudex-RWG4YLNHEdA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BP10")
IE.Document.GetElementByID("KeklNQcVqTQ-RWG4YLNHEdA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-qF9q6ImcE4Q-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-qF9q6ImcE4Q-val").Value = ThisWorkbook.Sheets("sheet1").Range("BQ10")
IE.Document.GetElementByID("Ogm7REBudex-qF9q6ImcE4Q-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-qF9q6ImcE4Q-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-qF9q6ImcE4Q-val").Value = ThisWorkbook.Sheets("sheet1").Range("BQ10")
IE.Document.GetElementByID("KeklNQcVqTQ-qF9q6ImcE4Q-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-LIuHxfndMvN-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-LIuHxfndMvN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BR10")
IE.Document.GetElementByID("Ogm7REBudex-LIuHxfndMvN-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-LIuHxfndMvN-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-LIuHxfndMvN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BR10")
IE.Document.GetElementByID("KeklNQcVqTQ-LIuHxfndMvN-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-zJAFlhIuWgH-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-zJAFlhIuWgH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BS10")
IE.Document.GetElementByID("Ogm7REBudex-zJAFlhIuWgH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-zJAFlhIuWgH-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-zJAFlhIuWgH-val").Value = ThisWorkbook.Sheets("sheet1").Range("BS10")
IE.Document.GetElementByID("KeklNQcVqTQ-zJAFlhIuWgH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-DX5hOcGmzO4-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-DX5hOcGmzO4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BT10")
IE.Document.GetElementByID("Ogm7REBudex-DX5hOcGmzO4-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-DX5hOcGmzO4-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-DX5hOcGmzO4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BT10")
IE.Document.GetElementByID("KeklNQcVqTQ-DX5hOcGmzO4-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-nm4ngD1r1hU-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-nm4ngD1r1hU-val").Value = ThisWorkbook.Sheets("sheet1").Range("BU10")
IE.Document.GetElementByID("Ogm7REBudex-nm4ngD1r1hU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-nm4ngD1r1hU-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-nm4ngD1r1hU-val").Value = ThisWorkbook.Sheets("sheet1").Range("BU10")
IE.Document.GetElementByID("KeklNQcVqTQ-nm4ngD1r1hU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-g4X5YaSBkbt-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-g4X5YaSBkbt-val").Value = ThisWorkbook.Sheets("sheet1").Range("BV10")
IE.Document.GetElementByID("Ogm7REBudex-g4X5YaSBkbt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-g4X5YaSBkbt-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-g4X5YaSBkbt-val").Value = ThisWorkbook.Sheets("sheet1").Range("BV10")
IE.Document.GetElementByID("KeklNQcVqTQ-g4X5YaSBkbt-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-SYFxsQKDZB6-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-SYFxsQKDZB6-val").Value = ThisWorkbook.Sheets("sheet1").Range("BW10")
IE.Document.GetElementByID("Ogm7REBudex-SYFxsQKDZB6-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-SYFxsQKDZB6-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-SYFxsQKDZB6-val").Value = ThisWorkbook.Sheets("sheet1").Range("BW10")
IE.Document.GetElementByID("KeklNQcVqTQ-SYFxsQKDZB6-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-X6qWVyu9XoN-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-X6qWVyu9XoN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BX10")
IE.Document.GetElementByID("Ogm7REBudex-X6qWVyu9XoN-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-X6qWVyu9XoN-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-X6qWVyu9XoN-val").Value = ThisWorkbook.Sheets("sheet1").Range("BX10")
IE.Document.GetElementByID("KeklNQcVqTQ-X6qWVyu9XoN-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-XpcFo6dVPT4-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-XpcFo6dVPT4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BY10")
IE.Document.GetElementByID("Ogm7REBudex-XpcFo6dVPT4-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-XpcFo6dVPT4-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-XpcFo6dVPT4-val").Value = ThisWorkbook.Sheets("sheet1").Range("BY10")
IE.Document.GetElementByID("KeklNQcVqTQ-XpcFo6dVPT4-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-xrbKLtiVPLr-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-xrbKLtiVPLr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BZ10")
IE.Document.GetElementByID("Ogm7REBudex-xrbKLtiVPLr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-xrbKLtiVPLr-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-xrbKLtiVPLr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BZ10")
IE.Document.GetElementByID("KeklNQcVqTQ-xrbKLtiVPLr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-K5N6EXwJKhq-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-K5N6EXwJKhq-val").Value = ThisWorkbook.Sheets("sheet1").Range("CA10")
IE.Document.GetElementByID("Ogm7REBudex-K5N6EXwJKhq-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-K5N6EXwJKhq-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-K5N6EXwJKhq-val").Value = ThisWorkbook.Sheets("sheet1").Range("CA10")
IE.Document.GetElementByID("KeklNQcVqTQ-K5N6EXwJKhq-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-V6sMmLkODqf-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-V6sMmLkODqf-val").Value = ThisWorkbook.Sheets("sheet1").Range("CB10")
IE.Document.GetElementByID("Ogm7REBudex-V6sMmLkODqf-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-V6sMmLkODqf-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-V6sMmLkODqf-val").Value = ThisWorkbook.Sheets("sheet1").Range("CB10")
IE.Document.GetElementByID("KeklNQcVqTQ-V6sMmLkODqf-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-RHmkwEYAkor-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-RHmkwEYAkor-val").Value = ThisWorkbook.Sheets("sheet1").Range("CC10")
IE.Document.GetElementByID("Ogm7REBudex-RHmkwEYAkor-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-RHmkwEYAkor-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-RHmkwEYAkor-val").Value = ThisWorkbook.Sheets("sheet1").Range("CC10")
IE.Document.GetElementByID("KeklNQcVqTQ-RHmkwEYAkor-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-SdpT6lSiyCM-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-SdpT6lSiyCM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CD10")
IE.Document.GetElementByID("Ogm7REBudex-SdpT6lSiyCM-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-SdpT6lSiyCM-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-SdpT6lSiyCM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CD10")
IE.Document.GetElementByID("KeklNQcVqTQ-SdpT6lSiyCM-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-j98NBCtzxly-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-j98NBCtzxly-val").Value = ThisWorkbook.Sheets("sheet1").Range("CE10")
IE.Document.GetElementByID("Ogm7REBudex-j98NBCtzxly-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-j98NBCtzxly-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-j98NBCtzxly-val").Value = ThisWorkbook.Sheets("sheet1").Range("CE10")
IE.Document.GetElementByID("KeklNQcVqTQ-j98NBCtzxly-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-HBu2SwE1QoF-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-HBu2SwE1QoF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CF10")
IE.Document.GetElementByID("Ogm7REBudex-HBu2SwE1QoF-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-HBu2SwE1QoF-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-HBu2SwE1QoF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CF10")
IE.Document.GetElementByID("KeklNQcVqTQ-HBu2SwE1QoF-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("CG10")
IE.Document.GetElementByID("Ogm7REBudex-dZYJREDXbfa-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("CG10")
IE.Document.GetElementByID("KeklNQcVqTQ-dZYJREDXbfa-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("CH10")
IE.Document.GetElementByID("Ogm7REBudex-flyE54cGOkr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("CH10")
IE.Document.GetElementByID("KeklNQcVqTQ-flyE54cGOkr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("CI10")
IE.Document.GetElementByID("Ogm7REBudex-h3WrcUxOPZ2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("CI10")
IE.Document.GetElementByID("KeklNQcVqTQ-h3WrcUxOPZ2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Ogm7REBudex-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("Ogm7REBudex-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("CJ10")
IE.Document.GetElementByID("Ogm7REBudex-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KeklNQcVqTQ-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("KeklNQcVqTQ-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("CJ10")
IE.Document.GetElementByID("KeklNQcVqTQ-HSpL3hSBx6F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PITC Modality: TB Clinics
End Sub

' PPPPPPPPP  PPMMMM   MMMMMM TTTTTTTTTTT  CCCCCCC    TTTTTTTTTTT        AAAAA     NNNN   NNNN    CCCCCCC    
' PPPPPPPPPP PPMMMM   MMMMMM TTTTTTTTTTT CCCCCCCCC   TTTTTTTTTTT        AAAAA     NNNNN  NNNN   CCCCCCCCC   
' PPPPPPPPPPPPPMMMM   MMMMMM TTTTTTTTTTTCCCCCCCCCCC  TTTTTTTTTTT       AAAAAA     NNNNN  NNNN  CCCCCCCCCCC  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT    CCCC   CCCCC    TTTT           AAAAAAA    NNNNNN NNNN  CCCC   CCCC  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT   TCCC     CCC     TTTT          AAAAAAAA    NNNNNN NNNN NCCC     CCC  
' PPPPPPPPPPPPPMMMMM MMMMMMM    TTTT   TCCC             TTTT          AAAAAAAA    NNNNNNNNNNN NCCC          
' PPPPPPPPPP PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT          AAAA AAAA   NNNNNNNNNNN NCCC          
' PPPPPPPPP  PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT         AAAAAAAAAA   NNNNNNNNNNN NCCC          
' PPPP       PPMMMMMMMMMMMMM    TTTT   TCCC     CCC     TTTT         AAAAAAAAAAA  NNNNNNNNNNN NCCC     CCC  
' PPPP       PPMM MMMMM MMMM    TTTT    CCCC   CCCCC    TTTT         AAAAAAAAAAA  NNNN NNNNNN  CCCC   CCCC  
' PPPP       PPMM MMMMM MMMM    TTTT    CCCCCCCCCCC     TTTT         AAA    AAAA  NNNN  NNNNN  CCCCCCCCCCC  
' PPPP       PPMM MMMMM MMMM    TTTT     CCCCCCCCCC     TTTT         AAA     AAAA NNNN  NNNNN   CCCCCCCCCC  
' PPPP       PPMM MMMMM MMMM    TTTT      CCCCCCC       TTTT        AAA     AAAA NNNN   NNNN    CCCCCCC    
Sub PICT_PMTCT_ANC()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'PITC Modality: PMTCT (ANC Only) Clinics
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("CQ10")) Then
'10-14,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-yLBZURYX4dM-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-yLBZURYX4dM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CQ10")
IE.Document.GetElementByID("tgHxA0DD5oL-yLBZURYX4dM-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-yLBZURYX4dM-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-yLBZURYX4dM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CQ10")
IE.Document.GetElementByID("RT8zvKCJaXC-yLBZURYX4dM-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-V3oXrjInRC5-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-V3oXrjInRC5-val").Value = ThisWorkbook.Sheets("sheet1").Range("CR10")
IE.Document.GetElementByID("tgHxA0DD5oL-V3oXrjInRC5-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-V3oXrjInRC5-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-V3oXrjInRC5-val").Value = ThisWorkbook.Sheets("sheet1").Range("CR10")
IE.Document.GetElementByID("RT8zvKCJaXC-V3oXrjInRC5-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-Nh2FihNXvdJ-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-Nh2FihNXvdJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CS10")
IE.Document.GetElementByID("tgHxA0DD5oL-Nh2FihNXvdJ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-Nh2FihNXvdJ-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-Nh2FihNXvdJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CS10")
IE.Document.GetElementByID("RT8zvKCJaXC-Nh2FihNXvdJ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-swdumJN00xH-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-swdumJN00xH-val").Value = ThisWorkbook.Sheets("sheet1").Range("CT10")
IE.Document.GetElementByID("tgHxA0DD5oL-swdumJN00xH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-swdumJN00xH-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-swdumJN00xH-val").Value = ThisWorkbook.Sheets("sheet1").Range("CT10")
IE.Document.GetElementByID("RT8zvKCJaXC-swdumJN00xH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-qSEFOXyVh36-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-qSEFOXyVh36-val").Value = ThisWorkbook.Sheets("sheet1").Range("CU10")
IE.Document.GetElementByID("tgHxA0DD5oL-qSEFOXyVh36-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-qSEFOXyVh36-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-qSEFOXyVh36-val").Value = ThisWorkbook.Sheets("sheet1").Range("CU10")
IE.Document.GetElementByID("RT8zvKCJaXC-qSEFOXyVh36-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-LUGZN0xJK8O-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-LUGZN0xJK8O-val").Value = ThisWorkbook.Sheets("sheet1").Range("CV10")
IE.Document.GetElementByID("tgHxA0DD5oL-LUGZN0xJK8O-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-LUGZN0xJK8O-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-LUGZN0xJK8O-val").Value = ThisWorkbook.Sheets("sheet1").Range("CV10")
IE.Document.GetElementByID("RT8zvKCJaXC-LUGZN0xJK8O-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,Posetive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-liB7pxJtaLm-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-liB7pxJtaLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("CW10")
IE.Document.GetElementByID("tgHxA0DD5oL-liB7pxJtaLm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-liB7pxJtaLm-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-liB7pxJtaLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("CW10")
IE.Document.GetElementByID("RT8zvKCJaXC-liB7pxJtaLm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tgHxA0DD5oL-hxYS9p5OORs-val").Focus
IE.Document.GetElementByID("tgHxA0DD5oL-hxYS9p5OORs-val").Value = ThisWorkbook.Sheets("sheet1").Range("CX10")
IE.Document.GetElementByID("tgHxA0DD5oL-hxYS9p5OORs-val").dispatchEvent evt
Else
IE.Document.GetElementByID("RT8zvKCJaXC-hxYS9p5OORs-val").Focus
IE.Document.GetElementByID("RT8zvKCJaXC-hxYS9p5OORs-val").Value = ThisWorkbook.Sheets("sheet1").Range("CX10")
IE.Document.GetElementByID("RT8zvKCJaXC-hxYS9p5OORs-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PITC Modality: PMTCT (ANC Only) Clinics
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
'PITC Modality: Emergency Ward
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("DE10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("DE10")
IE.Document.GetElementByID("m6oDgY6WhM4-tP2mjgakLVn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("viytbgNBMks-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("DE10")
IE.Document.GetElementByID("viytbgNBMks-tP2mjgakLVn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DF10")
IE.Document.GetElementByID("m6oDgY6WhM4-DszsJew1vQA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("viytbgNBMks-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DF10")
IE.Document.GetElementByID("viytbgNBMks-DszsJew1vQA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DG10")
IE.Document.GetElementByID("m6oDgY6WhM4-VP9O0ao9MmZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("viytbgNBMks-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DG10")
IE.Document.GetElementByID("viytbgNBMks-VP9O0ao9MmZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DH10")
IE.Document.GetElementByID("m6oDgY6WhM4-BSQvgbaINGZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("viytbgNBMks-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DH10")
IE.Document.GetElementByID("viytbgNBMks-BSQvgbaINGZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("DI10")
IE.Document.GetElementByID("m6oDgY6WhM4-sDHZqlgc0lv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("viytbgNBMks-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("DI10")
IE.Document.GetElementByID("viytbgNBMks-sDHZqlgc0lv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("DJ10")
IE.Document.GetElementByID("m6oDgY6WhM4-pz7dlDGQssH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("viytbgNBMks-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("DJ10")
IE.Document.GetElementByID("viytbgNBMks-pz7dlDGQssH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("DK10")
IE.Document.GetElementByID("m6oDgY6WhM4-GscVGDNCdwR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("viytbgNBMks-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("DK10")
IE.Document.GetElementByID("viytbgNBMks-GscVGDNCdwR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DL10")
IE.Document.GetElementByID("m6oDgY6WhM4-lfHFCxROkNE-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("viytbgNBMks-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DL10")
IE.Document.GetElementByID("viytbgNBMks-lfHFCxROkNE-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DM10")
IE.Document.GetElementByID("m6oDgY6WhM4-HEpqnVEHzUA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("viytbgNBMks-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DM10")
IE.Document.GetElementByID("viytbgNBMks-HEpqnVEHzUA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("DN10")
IE.Document.GetElementByID("m6oDgY6WhM4-BOxW7hCTSjX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("viytbgNBMks-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("DN10")
IE.Document.GetElementByID("viytbgNBMks-BOxW7hCTSjX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("DO10")
IE.Document.GetElementByID("m6oDgY6WhM4-SyBPyzv8HTC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("viytbgNBMks-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("DO10")
IE.Document.GetElementByID("viytbgNBMks-SyBPyzv8HTC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-H250HduQyXi-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("DP10")
IE.Document.GetElementByID("m6oDgY6WhM4-H250HduQyXi-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-H250HduQyXi-val").Focus
IE.Document.GetElementByID("viytbgNBMks-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("DP10")
IE.Document.GetElementByID("viytbgNBMks-H250HduQyXi-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("DQ10")
IE.Document.GetElementByID("m6oDgY6WhM4-FLlJURwLmAe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("viytbgNBMks-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("DQ10")
IE.Document.GetElementByID("viytbgNBMks-FLlJURwLmAe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("DR10")
IE.Document.GetElementByID("m6oDgY6WhM4-ZAVOIaOudWw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("viytbgNBMks-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("DR10")
IE.Document.GetElementByID("viytbgNBMks-ZAVOIaOudWw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("DS10")
IE.Document.GetElementByID("m6oDgY6WhM4-lZiQLcYoM7M-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("viytbgNBMks-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("DS10")
IE.Document.GetElementByID("viytbgNBMks-lZiQLcYoM7M-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DT10")
IE.Document.GetElementByID("m6oDgY6WhM4-RWG4YLNHEdA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("viytbgNBMks-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("DT10")
IE.Document.GetElementByID("viytbgNBMks-RWG4YLNHEdA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DU10")
IE.Document.GetElementByID("m6oDgY6WhM4-E8XxGzk0kY7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("viytbgNBMks-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DU10")
IE.Document.GetElementByID("viytbgNBMks-E8XxGzk0kY7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("DV10")
IE.Document.GetElementByID("m6oDgY6WhM4-FnHZRFcropp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("viytbgNBMks-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("DV10")
IE.Document.GetElementByID("viytbgNBMks-FnHZRFcropp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DW10")
IE.Document.GetElementByID("m6oDgY6WhM4-Hbg53zGRcL7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("viytbgNBMks-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("DW10")
IE.Document.GetElementByID("viytbgNBMks-Hbg53zGRcL7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("DX10")
IE.Document.GetElementByID("m6oDgY6WhM4-IHmmeJ1fyKy-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("viytbgNBMks-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("DX10")
IE.Document.GetElementByID("viytbgNBMks-IHmmeJ1fyKy-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("DY10")
IE.Document.GetElementByID("m6oDgY6WhM4-dZYJREDXbfa-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("viytbgNBMks-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("DY10")
IE.Document.GetElementByID("viytbgNBMks-dZYJREDXbfa-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("DZ10")
IE.Document.GetElementByID("m6oDgY6WhM4-flyE54cGOkr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("viytbgNBMks-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("DZ10")
IE.Document.GetElementByID("viytbgNBMks-flyE54cGOkr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("EA10")
IE.Document.GetElementByID("m6oDgY6WhM4-h3WrcUxOPZ2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("viytbgNBMks-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("EA10")
IE.Document.GetElementByID("viytbgNBMks-h3WrcUxOPZ2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("m6oDgY6WhM4-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("EB10")
IE.Document.GetElementByID("m6oDgY6WhM4-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("viytbgNBMks-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("viytbgNBMks-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("EB10")
IE.Document.GetElementByID("viytbgNBMks-HSpL3hSBx6F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PITC Modality: Emergency Ward
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
'PITC Modality: Other PICT
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("EE10")) Then
'Unknown,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-EpuxXtY71JG-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-EpuxXtY71JG-val").Value = ThisWorkbook.Sheets("sheet1").Range("EE10")
IE.Document.GetElementByID("H7Iu1SBCLTm-EpuxXtY71JG-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-EpuxXtY71JG-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-EpuxXtY71JG-val").Value = ThisWorkbook.Sheets("sheet1").Range("EE10")
IE.Document.GetElementByID("jHjC9XIJbhL-EpuxXtY71JG-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Unknown,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-YcXbNpQVqTA-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-YcXbNpQVqTA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EF10")
IE.Document.GetElementByID("H7Iu1SBCLTm-YcXbNpQVqTA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-YcXbNpQVqTA-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-YcXbNpQVqTA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EF10")
IE.Document.GetElementByID("jHjC9XIJbhL-YcXbNpQVqTA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("EG10")
IE.Document.GetElementByID("H7Iu1SBCLTm-tP2mjgakLVn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("EG10")
IE.Document.GetElementByID("jHjC9XIJbhL-tP2mjgakLVn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EH10")
IE.Document.GetElementByID("H7Iu1SBCLTm-DszsJew1vQA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EH10")
IE.Document.GetElementByID("jHjC9XIJbhL-DszsJew1vQA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EI10")
IE.Document.GetElementByID("H7Iu1SBCLTm-VP9O0ao9MmZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EI10")
IE.Document.GetElementByID("jHjC9XIJbhL-VP9O0ao9MmZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EJ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-BSQvgbaINGZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EJ10")
IE.Document.GetElementByID("jHjC9XIJbhL-BSQvgbaINGZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("EK10")
IE.Document.GetElementByID("H7Iu1SBCLTm-sDHZqlgc0lv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("EK10")
IE.Document.GetElementByID("jHjC9XIJbhL-sDHZqlgc0lv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("EL10")
IE.Document.GetElementByID("H7Iu1SBCLTm-pz7dlDGQssH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("EL10")
IE.Document.GetElementByID("jHjC9XIJbhL-pz7dlDGQssH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("EM10")
IE.Document.GetElementByID("H7Iu1SBCLTm-GscVGDNCdwR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("EM10")
IE.Document.GetElementByID("jHjC9XIJbhL-GscVGDNCdwR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("EN10")
IE.Document.GetElementByID("H7Iu1SBCLTm-lfHFCxROkNE-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("EN10")
IE.Document.GetElementByID("jHjC9XIJbhL-lfHFCxROkNE-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EO10")
IE.Document.GetElementByID("H7Iu1SBCLTm-HEpqnVEHzUA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EO10")
IE.Document.GetElementByID("jHjC9XIJbhL-HEpqnVEHzUA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("EP10")
IE.Document.GetElementByID("H7Iu1SBCLTm-BOxW7hCTSjX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("EP10")
IE.Document.GetElementByID("jHjC9XIJbhL-BOxW7hCTSjX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("EQ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-SyBPyzv8HTC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("EQ10")
IE.Document.GetElementByID("jHjC9XIJbhL-SyBPyzv8HTC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-H250HduQyXi-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ER10")
IE.Document.GetElementByID("H7Iu1SBCLTm-H250HduQyXi-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-H250HduQyXi-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ER10")
IE.Document.GetElementByID("jHjC9XIJbhL-H250HduQyXi-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("ES10")
IE.Document.GetElementByID("H7Iu1SBCLTm-FLlJURwLmAe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("ES10")
IE.Document.GetElementByID("jHjC9XIJbhL-FLlJURwLmAe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ET10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ZAVOIaOudWw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ET10")
IE.Document.GetElementByID("jHjC9XIJbhL-ZAVOIaOudWw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("EU10")
IE.Document.GetElementByID("H7Iu1SBCLTm-lZiQLcYoM7M-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("EU10")
IE.Document.GetElementByID("jHjC9XIJbhL-lZiQLcYoM7M-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EV10")
IE.Document.GetElementByID("H7Iu1SBCLTm-RWG4YLNHEdA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("EV10")
IE.Document.GetElementByID("jHjC9XIJbhL-RWG4YLNHEdA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EW10")
IE.Document.GetElementByID("H7Iu1SBCLTm-E8XxGzk0kY7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EW10")
IE.Document.GetElementByID("jHjC9XIJbhL-E8XxGzk0kY7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("EX10")
IE.Document.GetElementByID("H7Iu1SBCLTm-FnHZRFcropp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("EX10")
IE.Document.GetElementByID("jHjC9XIJbhL-FnHZRFcropp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EY10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Hbg53zGRcL7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("EY10")
IE.Document.GetElementByID("jHjC9XIJbhL-Hbg53zGRcL7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("EZ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-IHmmeJ1fyKy-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("EZ10")
IE.Document.GetElementByID("jHjC9XIJbhL-IHmmeJ1fyKy-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("FA10")
IE.Document.GetElementByID("H7Iu1SBCLTm-dZYJREDXbfa-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("FA10")
IE.Document.GetElementByID("jHjC9XIJbhL-dZYJREDXbfa-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("FB10")
IE.Document.GetElementByID("H7Iu1SBCLTm-flyE54cGOkr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("FB10")
IE.Document.GetElementByID("jHjC9XIJbhL-flyE54cGOkr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("FC10")
IE.Document.GetElementByID("H7Iu1SBCLTm-h3WrcUxOPZ2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("FC10")
IE.Document.GetElementByID("jHjC9XIJbhL-h3WrcUxOPZ2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("H7Iu1SBCLTm-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("FD10")
IE.Document.GetElementByID("H7Iu1SBCLTm-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("jHjC9XIJbhL-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("jHjC9XIJbhL-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("FD10")
IE.Document.GetElementByID("jHjC9XIJbhL-HSpL3hSBx6F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PITC Modality: Other PICT
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
'VCT
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("FI10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("FI10")
IE.Document.GetElementByID("K3I0l3A6fNt-tP2mjgakLVn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("FI10")
IE.Document.GetElementByID("YBdu7j2gGjC-tP2mjgakLVn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FJ10")
IE.Document.GetElementByID("K3I0l3A6fNt-DszsJew1vQA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FJ10")
IE.Document.GetElementByID("YBdu7j2gGjC-DszsJew1vQA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FK10")
IE.Document.GetElementByID("K3I0l3A6fNt-VP9O0ao9MmZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FK10")
IE.Document.GetElementByID("YBdu7j2gGjC-VP9O0ao9MmZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FL10")
IE.Document.GetElementByID("K3I0l3A6fNt-BSQvgbaINGZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FL10")
IE.Document.GetElementByID("YBdu7j2gGjC-BSQvgbaINGZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("FM10")
IE.Document.GetElementByID("K3I0l3A6fNt-sDHZqlgc0lv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("FM10")
IE.Document.GetElementByID("YBdu7j2gGjC-sDHZqlgc0lv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("FN10")
IE.Document.GetElementByID("K3I0l3A6fNt-pz7dlDGQssH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("FN10")
IE.Document.GetElementByID("YBdu7j2gGjC-pz7dlDGQssH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("FO10")
IE.Document.GetElementByID("K3I0l3A6fNt-GscVGDNCdwR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("FO10")
IE.Document.GetElementByID("YBdu7j2gGjC-GscVGDNCdwR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("FP10")
IE.Document.GetElementByID("K3I0l3A6fNt-lfHFCxROkNE-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("FP10")
IE.Document.GetElementByID("YBdu7j2gGjC-lfHFCxROkNE-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FQ10")
IE.Document.GetElementByID("K3I0l3A6fNt-HEpqnVEHzUA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FQ10")
IE.Document.GetElementByID("YBdu7j2gGjC-HEpqnVEHzUA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("FR10")
IE.Document.GetElementByID("K3I0l3A6fNt-BOxW7hCTSjX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("FR10")
IE.Document.GetElementByID("YBdu7j2gGjC-BOxW7hCTSjX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("FS10")
IE.Document.GetElementByID("K3I0l3A6fNt-SyBPyzv8HTC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("FS10")
IE.Document.GetElementByID("YBdu7j2gGjC-SyBPyzv8HTC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-H250HduQyXi-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("FT10")
IE.Document.GetElementByID("K3I0l3A6fNt-H250HduQyXi-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-H250HduQyXi-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("FT10")
IE.Document.GetElementByID("YBdu7j2gGjC-H250HduQyXi-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("FU10")
IE.Document.GetElementByID("K3I0l3A6fNt-FLlJURwLmAe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("FU10")
IE.Document.GetElementByID("YBdu7j2gGjC-FLlJURwLmAe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("FV10")
IE.Document.GetElementByID("K3I0l3A6fNt-ZAVOIaOudWw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("FV10")
IE.Document.GetElementByID("YBdu7j2gGjC-ZAVOIaOudWw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("FW10")
IE.Document.GetElementByID("K3I0l3A6fNt-lZiQLcYoM7M-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("FW10")
IE.Document.GetElementByID("YBdu7j2gGjC-lZiQLcYoM7M-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FX10")
IE.Document.GetElementByID("K3I0l3A6fNt-RWG4YLNHEdA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("FX10")
IE.Document.GetElementByID("YBdu7j2gGjC-RWG4YLNHEdA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("FY10")
IE.Document.GetElementByID("K3I0l3A6fNt-E8XxGzk0kY7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("FY10")
IE.Document.GetElementByID("YBdu7j2gGjC-E8XxGzk0kY7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("FZ10")
IE.Document.GetElementByID("K3I0l3A6fNt-FnHZRFcropp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("FZ10")
IE.Document.GetElementByID("YBdu7j2gGjC-FnHZRFcropp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("GA10")
IE.Document.GetElementByID("K3I0l3A6fNt-Hbg53zGRcL7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("GA10")
IE.Document.GetElementByID("YBdu7j2gGjC-Hbg53zGRcL7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("GB10")
IE.Document.GetElementByID("K3I0l3A6fNt-IHmmeJ1fyKy-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("GB10")
IE.Document.GetElementByID("YBdu7j2gGjC-IHmmeJ1fyKy-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
IE.Document.GetElementByID("K3I0l3A6fNt-dZYJREDXbfa-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
IE.Document.GetElementByID("YBdu7j2gGjC-dZYJREDXbfa-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("GD10")
IE.Document.GetElementByID("K3I0l3A6fNt-flyE54cGOkr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("GD10")
IE.Document.GetElementByID("YBdu7j2gGjC-flyE54cGOkr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("GE10")
IE.Document.GetElementByID("K3I0l3A6fNt-h3WrcUxOPZ2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("GE10")
IE.Document.GetElementByID("YBdu7j2gGjC-h3WrcUxOPZ2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K3I0l3A6fNt-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("GF10")
IE.Document.GetElementByID("K3I0l3A6fNt-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YBdu7j2gGjC-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("YBdu7j2gGjC-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("GF10")
IE.Document.GetElementByID("YBdu7j2gGjC-HSpL3hSBx6F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End VCT
End Sub

' IIIII                  dddd                           ttt                       ttt  iiii                        
' IIIII                  dddd                          tttt                      tttt  iiii                        
' IIIII                  dddd                          tttt                      tttt                              
' IIIII nnnnnnnn    ddddddddd  eeeeee  exxx  xxxx     tttttt eeeeee   sssssss ssttttttiiii nnnnnnnn    ggggggggg  
' IIIII nnnnnnnnn  dddddddddd eeeeeeee  xxxxxxxx      tttttteeeeeeee essssssssssttttttiiii nnnnnnnnn  gggggggggg  
' IIIII nnnn nnnnnddddd dddddeeee eeee  xxxxxxxx       tttt teee eeee esss ssss  tttt  iiii nnnn nnnnnngggg ggggg  
' IIIII nnnn  nnnndddd   ddddeeee  eeee  xxxxxx        tttt teee  eeeeessss      tttt  iiii nnnn  nnnnnggg   gggg  
' IIIII nnnn  nnnndddd   ddddeeeeeeeeee   xxxx         tttt teeeeeeeee ssssss    tttt  iiii nnnn  nnnnnggg   gggg  
' IIIII nnnn  nnnndddd   ddddeeeeeeeeee  xxxxxx        tttt teeeeeeeee  sssssss  tttt  iiii nnnn  nnnnnggg   gggg  
' IIIII nnnn  nnnndddd   ddddeeee        xxxxxx        tttt teee            ssss tttt  iiii nnnn  nnnnnggg   gggg  
' IIIII nnnn  nnnnddddd dddddeeee  eeee xxxxxxxx       tttt teee  eeeeesss  ssss tttt  iiii nnnn  nnnnngggg ggggg  
' IIIII nnnn  nnnn dddddddddd eeeeeeee exxxxxxxxx      tttttteeeeeeee essssssss  ttttttiiii nnnn  nnnn gggggggggg  
' IIIII nnnn  nnnn  ddddddddd  eeeeee  exxx  xxxx      tttttt eeeeee    ssssss   ttttttiiii nnnn  nnnn  ggggggggg  
'                                                                                                            gggg  
'                                                                                                     ngggg gggg   
'                                                                                                      ggggggggg   
'                                                                                                       ggggggg    
Sub Index_Testing()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Index Testing
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("GK10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("GK10")
IE.Document.GetElementByID("WSzB03ZCEuR-tP2mjgakLVn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-tP2mjgakLVn-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("GK10")
IE.Document.GetElementByID("JjDbcm9MfuJ-tP2mjgakLVn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GL10")
IE.Document.GetElementByID("WSzB03ZCEuR-DszsJew1vQA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-DszsJew1vQA-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GL10")
IE.Document.GetElementByID("JjDbcm9MfuJ-DszsJew1vQA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GM10")
IE.Document.GetElementByID("WSzB03ZCEuR-VP9O0ao9MmZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-VP9O0ao9MmZ-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GM10")
IE.Document.GetElementByID("JjDbcm9MfuJ-VP9O0ao9MmZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GN10")
IE.Document.GetElementByID("WSzB03ZCEuR-BSQvgbaINGZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-BSQvgbaINGZ-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GN10")
IE.Document.GetElementByID("JjDbcm9MfuJ-BSQvgbaINGZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("GO10")
IE.Document.GetElementByID("WSzB03ZCEuR-sDHZqlgc0lv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-sDHZqlgc0lv-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("GO10")
IE.Document.GetElementByID("JjDbcm9MfuJ-sDHZqlgc0lv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("GP10")
IE.Document.GetElementByID("WSzB03ZCEuR-pz7dlDGQssH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-pz7dlDGQssH-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("GP10")
IE.Document.GetElementByID("JjDbcm9MfuJ-pz7dlDGQssH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("GQ10")
IE.Document.GetElementByID("WSzB03ZCEuR-GscVGDNCdwR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-GscVGDNCdwR-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("GQ10")
IE.Document.GetElementByID("JjDbcm9MfuJ-GscVGDNCdwR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("GR10")
IE.Document.GetElementByID("WSzB03ZCEuR-lfHFCxROkNE-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-lfHFCxROkNE-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("GR10")
IE.Document.GetElementByID("JjDbcm9MfuJ-lfHFCxROkNE-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GS10")
IE.Document.GetElementByID("WSzB03ZCEuR-HEpqnVEHzUA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-HEpqnVEHzUA-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GS10")
IE.Document.GetElementByID("JjDbcm9MfuJ-HEpqnVEHzUA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("GT10")
IE.Document.GetElementByID("WSzB03ZCEuR-BOxW7hCTSjX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-BOxW7hCTSjX-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("GT10")
IE.Document.GetElementByID("JjDbcm9MfuJ-BOxW7hCTSjX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("GU10")
IE.Document.GetElementByID("WSzB03ZCEuR-SyBPyzv8HTC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-SyBPyzv8HTC-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("GU10")
IE.Document.GetElementByID("JjDbcm9MfuJ-SyBPyzv8HTC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-H250HduQyXi-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("GV10")
IE.Document.GetElementByID("WSzB03ZCEuR-H250HduQyXi-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-H250HduQyXi-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("GV10")
IE.Document.GetElementByID("JjDbcm9MfuJ-H250HduQyXi-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("GW10")
IE.Document.GetElementByID("WSzB03ZCEuR-FLlJURwLmAe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-FLlJURwLmAe-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("GW10")
IE.Document.GetElementByID("JjDbcm9MfuJ-FLlJURwLmAe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("GX10")
IE.Document.GetElementByID("WSzB03ZCEuR-ZAVOIaOudWw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-ZAVOIaOudWw-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("GX10")
IE.Document.GetElementByID("JjDbcm9MfuJ-ZAVOIaOudWw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("GY10")
IE.Document.GetElementByID("WSzB03ZCEuR-lZiQLcYoM7M-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-lZiQLcYoM7M-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("GY10")
IE.Document.GetElementByID("JjDbcm9MfuJ-lZiQLcYoM7M-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GZ10")
IE.Document.GetElementByID("WSzB03ZCEuR-RWG4YLNHEdA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-RWG4YLNHEdA-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("GZ10")
IE.Document.GetElementByID("JjDbcm9MfuJ-RWG4YLNHEdA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HA10")
IE.Document.GetElementByID("WSzB03ZCEuR-E8XxGzk0kY7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-E8XxGzk0kY7-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HA10")
IE.Document.GetElementByID("JjDbcm9MfuJ-E8XxGzk0kY7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("HB10")
IE.Document.GetElementByID("WSzB03ZCEuR-FnHZRFcropp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-FnHZRFcropp-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("HB10")
IE.Document.GetElementByID("JjDbcm9MfuJ-FnHZRFcropp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HC10")
IE.Document.GetElementByID("WSzB03ZCEuR-Hbg53zGRcL7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-Hbg53zGRcL7-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("HC10")
IE.Document.GetElementByID("JjDbcm9MfuJ-Hbg53zGRcL7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("HD10")
IE.Document.GetElementByID("WSzB03ZCEuR-IHmmeJ1fyKy-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-IHmmeJ1fyKy-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("HD10")
IE.Document.GetElementByID("JjDbcm9MfuJ-IHmmeJ1fyKy-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("HE10")
IE.Document.GetElementByID("WSzB03ZCEuR-dZYJREDXbfa-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-dZYJREDXbfa-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("HE10")
IE.Document.GetElementByID("JjDbcm9MfuJ-dZYJREDXbfa-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("HF10")
IE.Document.GetElementByID("WSzB03ZCEuR-flyE54cGOkr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-flyE54cGOkr-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("HF10")
IE.Document.GetElementByID("JjDbcm9MfuJ-flyE54cGOkr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HG10")
IE.Document.GetElementByID("WSzB03ZCEuR-h3WrcUxOPZ2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-h3WrcUxOPZ2-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HG10")
IE.Document.GetElementByID("JjDbcm9MfuJ-h3WrcUxOPZ2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("WSzB03ZCEuR-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("WSzB03ZCEuR-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("HH10")
IE.Document.GetElementByID("WSzB03ZCEuR-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JjDbcm9MfuJ-HSpL3hSBx6F-val").Focus
IE.Document.GetElementByID("JjDbcm9MfuJ-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("HH10")
IE.Document.GetElementByID("JjDbcm9MfuJ-HSpL3hSBx6F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End Index Testing
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
'PMTCT_STAT
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("HI10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("DsC5f5aN6Ef-Jwb1SWomgpk-val").Focus
IE.Document.GetElementByID("DsC5f5aN6Ef-Jwb1SWomgpk-val").Value = ThisWorkbook.Sheets("sheet1").Range("HI10")
IE.Document.GetElementByID("DsC5f5aN6Ef-Jwb1SWomgpk-val").dispatchEvent evt
Else
IE.Document.GetElementByID("EQiyFRSNeK2-Jwb1SWomgpk-val").Focus
IE.Document.GetElementByID("EQiyFRSNeK2-Jwb1SWomgpk-val").Value = ThisWorkbook.Sheets("sheet1").Range("HI10")
IE.Document.GetElementByID("EQiyFRSNeK2-Jwb1SWomgpk-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-tfLs2DP45Ls-val").Focus
IE.Document.GetElementByID("sVZKPce0Cd6-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("HL10")
IE.Document.GetElementByID("sVZKPce0Cd6-tfLs2DP45Ls-val").dispatchEvent evt
Else
IE.Document.GetElementByID("A6sEZh4ctKy-tfLs2DP45Ls-val").Focus
IE.Document.GetElementByID("A6sEZh4ctKy-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("HL10")
IE.Document.GetElementByID("A6sEZh4ctKy-tfLs2DP45Ls-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-PYDtXtMwEBg-val").Focus
IE.Document.GetElementByID("sVZKPce0Cd6-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("HM10")
IE.Document.GetElementByID("sVZKPce0Cd6-PYDtXtMwEBg-val").dispatchEvent evt
Else
IE.Document.GetElementByID("A6sEZh4ctKy-PYDtXtMwEBg-val").Focus
IE.Document.GetElementByID("A6sEZh4ctKy-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("HM10")
IE.Document.GetElementByID("A6sEZh4ctKy-PYDtXtMwEBg-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-BNxBrkZHoIj-val").Focus
IE.Document.GetElementByID("sVZKPce0Cd6-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HN10")
IE.Document.GetElementByID("sVZKPce0Cd6-BNxBrkZHoIj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("A6sEZh4ctKy-BNxBrkZHoIj-val").Focus
IE.Document.GetElementByID("A6sEZh4ctKy-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HN10")
IE.Document.GetElementByID("A6sEZh4ctKy-BNxBrkZHoIj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("sVZKPce0Cd6-ivDtJODDkOt-val").Focus
IE.Document.GetElementByID("sVZKPce0Cd6-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("HO10")
IE.Document.GetElementByID("sVZKPce0Cd6-ivDtJODDkOt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("A6sEZh4ctKy-ivDtJODDkOt-val").Focus
IE.Document.GetElementByID("A6sEZh4ctKy-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("HO10")
IE.Document.GetElementByID("A6sEZh4ctKy-ivDtJODDkOt-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Known+,Newly+,Newly-
'10-14,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-FATw338XdmD-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-FATw338XdmD-val").Value = ThisWorkbook.Sheets("sheet1").Range("HW10")
IE.Document.GetElementByID("fg53NvKg3EN-FATw338XdmD-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-FATw338XdmD-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-FATw338XdmD-val").Value = ThisWorkbook.Sheets("sheet1").Range("HW10")
IE.Document.GetElementByID("bII4eG3osk5-FATw338XdmD-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-PpWt03yRclQ-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-PpWt03yRclQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HX10")
IE.Document.GetElementByID("fg53NvKg3EN-PpWt03yRclQ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-PpWt03yRclQ-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-PpWt03yRclQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HX10")
IE.Document.GetElementByID("bII4eG3osk5-PpWt03yRclQ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'10-14,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-Wjm2Jejaqh2-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-Wjm2Jejaqh2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HY10")
IE.Document.GetElementByID("fg53NvKg3EN-Wjm2Jejaqh2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-Wjm2Jejaqh2-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-Wjm2Jejaqh2-val").Value = ThisWorkbook.Sheets("sheet1").Range("HY10")
IE.Document.GetElementByID("bII4eG3osk5-Wjm2Jejaqh2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-CQz1usv1yjJ-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-CQz1usv1yjJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HZ10")
IE.Document.GetElementByID("fg53NvKg3EN-CQz1usv1yjJ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-CQz1usv1yjJ-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-CQz1usv1yjJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HZ10")
IE.Document.GetElementByID("bII4eG3osk5-CQz1usv1yjJ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-bGJGYyYer7f-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-bGJGYyYer7f-val").Value = ThisWorkbook.Sheets("sheet1").Range("IA10")
IE.Document.GetElementByID("fg53NvKg3EN-bGJGYyYer7f-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-bGJGYyYer7f-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-bGJGYyYer7f-val").Value = ThisWorkbook.Sheets("sheet1").Range("IA10")
IE.Document.GetElementByID("bII4eG3osk5-bGJGYyYer7f-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-Cn4g5a16slF-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-Cn4g5a16slF-val").Value = ThisWorkbook.Sheets("sheet1").Range("IB10")
IE.Document.GetElementByID("fg53NvKg3EN-Cn4g5a16slF-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-Cn4g5a16slF-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-Cn4g5a16slF-val").Value = ThisWorkbook.Sheets("sheet1").Range("IB10")
IE.Document.GetElementByID("bII4eG3osk5-Cn4g5a16slF-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-aluqwhKuVku-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-aluqwhKuVku-val").Value = ThisWorkbook.Sheets("sheet1").Range("IC10")
IE.Document.GetElementByID("fg53NvKg3EN-aluqwhKuVku-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-aluqwhKuVku-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-aluqwhKuVku-val").Value = ThisWorkbook.Sheets("sheet1").Range("IC10")
IE.Document.GetElementByID("bII4eG3osk5-aluqwhKuVku-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-Dvi71PYwhYc-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-Dvi71PYwhYc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
IE.Document.GetElementByID("fg53NvKg3EN-Dvi71PYwhYc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-Dvi71PYwhYc-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-Dvi71PYwhYc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
IE.Document.GetElementByID("bII4eG3osk5-Dvi71PYwhYc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-aPB9hvARz8F-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-aPB9hvARz8F-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
IE.Document.GetElementByID("fg53NvKg3EN-aPB9hvARz8F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-aPB9hvARz8F-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-aPB9hvARz8F-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
IE.Document.GetElementByID("bII4eG3osk5-aPB9hvARz8F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,Known+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-rkCstFZdZ63-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-rkCstFZdZ63-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
IE.Document.GetElementByID("fg53NvKg3EN-rkCstFZdZ63-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-rkCstFZdZ63-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-rkCstFZdZ63-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
IE.Document.GetElementByID("bII4eG3osk5-rkCstFZdZ63-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,Newly+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-B0YaR1ETmQ5-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-B0YaR1ETmQ5-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
IE.Document.GetElementByID("fg53NvKg3EN-B0YaR1ETmQ5-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-B0YaR1ETmQ5-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-B0YaR1ETmQ5-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
IE.Document.GetElementByID("bII4eG3osk5-B0YaR1ETmQ5-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49,Newly-
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fg53NvKg3EN-M5WmuzUAdzH-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-M5WmuzUAdzH-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
IE.Document.GetElementByID("fg53NvKg3EN-M5WmuzUAdzH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bII4eG3osk5-M5WmuzUAdzH-val").Focus
IE.Document.GetElementByID("bII4eG3osk5-M5WmuzUAdzH-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
IE.Document.GetElementByID("bII4eG3osk5-M5WmuzUAdzH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'PMTCT_STAT
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IM10")) Then
'Denominator
'10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-tfLs2DP45Ls-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("IM10")
IE.Document.GetElementByID("RHN2Ui10Ivu-tfLs2DP45Ls-val").dispatchEvent evt
Else
IE.Document.GetElementByID("D3dXMIpnOfu-tfLs2DP45Ls-val").Focus
IE.Document.GetElementByID("D3dXMIpnOfu-tfLs2DP45Ls-val").Value = ThisWorkbook.Sheets("sheet1").Range("IM10")
IE.Document.GetElementByID("D3dXMIpnOfu-tfLs2DP45Ls-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-PYDtXtMwEBg-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("IN10")
IE.Document.GetElementByID("RHN2Ui10Ivu-PYDtXtMwEBg-val").dispatchEvent evt
Else
IE.Document.GetElementByID("D3dXMIpnOfu-PYDtXtMwEBg-val").Focus
IE.Document.GetElementByID("D3dXMIpnOfu-PYDtXtMwEBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("IN10")
IE.Document.GetElementByID("D3dXMIpnOfu-PYDtXtMwEBg-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-BNxBrkZHoIj-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IO10")
IE.Document.GetElementByID("RHN2Ui10Ivu-BNxBrkZHoIj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("D3dXMIpnOfu-BNxBrkZHoIj-val").Focus
IE.Document.GetElementByID("D3dXMIpnOfu-BNxBrkZHoIj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IO10")
IE.Document.GetElementByID("D3dXMIpnOfu-BNxBrkZHoIj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("RHN2Ui10Ivu-ivDtJODDkOt-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("IP10")
IE.Document.GetElementByID("RHN2Ui10Ivu-ivDtJODDkOt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("D3dXMIpnOfu-ivDtJODDkOt-val").Focus
IE.Document.GetElementByID("D3dXMIpnOfu-ivDtJODDkOt-val").Value = ThisWorkbook.Sheets("sheet1").Range("IP10")
IE.Document.GetElementByID("D3dXMIpnOfu-ivDtJODDkOt-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PMTCT_STAT
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
'PMTCT_EID
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IR10")) Then
'0-2
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Value = ThisWorkbook.Sheets("sheet1").Range("IR10")
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").dispatchEvent evt
Else
IE.Document.GetElementByID("PD4lzqx2CCu-TRTNKzpystS-val").Focus
IE.Document.GetElementByID("PD4lzqx2CCu-TRTNKzpystS-val").Value = ThisWorkbook.Sheets("sheet1").Range("IR10")
IE.Document.GetElementByID("PD4lzqx2CCu-TRTNKzpystS-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'2-12
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Value = ThisWorkbook.Sheets("sheet1").Range("IS10")
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").dispatchEvent evt
Else
IE.Document.GetElementByID("PD4lzqx2CCu-El4ysmXTL9r-val").Focus
IE.Document.GetElementByID("PD4lzqx2CCu-El4ysmXTL9r-val").Value = ThisWorkbook.Sheets("sheet1").Range("IS10")
IE.Document.GetElementByID("PD4lzqx2CCu-El4ysmXTL9r-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If

'PMTCT_HEI_POS
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IT10")) Then
'0-2,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Value = ThisWorkbook.Sheets("sheet1").Range("IT10")
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("uMl3wp297tR-VG9llDXZfqR-val").Focus
IE.Document.GetElementByID("uMl3wp297tR-VG9llDXZfqR-val").Value = ThisWorkbook.Sheets("sheet1").Range("IT10")
IE.Document.GetElementByID("uMl3wp297tR-VG9llDXZfqR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'0-2,art
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Value = ThisWorkbook.Sheets("sheet1").Range("IU10")
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("yNfuoYteftA-oYuICUnILbz-val").Focus
IE.Document.GetElementByID("yNfuoYteftA-oYuICUnILbz-val").Value = ThisWorkbook.Sheets("sheet1").Range("IU10")
IE.Document.GetElementByID("yNfuoYteftA-oYuICUnILbz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'2-12,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("IV10")
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").dispatchEvent evt
Else
IE.Document.GetElementByID("uMl3wp297tR-liIscF6uc2E-val").Focus
IE.Document.GetElementByID("uMl3wp297tR-liIscF6uc2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("IV10")
IE.Document.GetElementByID("uMl3wp297tR-liIscF6uc2E-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'2-12,art
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Value = ThisWorkbook.Sheets("sheet1").Range("IW10")
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").dispatchEvent evt
Else
IE.Document.GetElementByID("yNfuoYteftA-bZ4b1EW7Uw7-val").Focus
IE.Document.GetElementByID("yNfuoYteftA-bZ4b1EW7Uw7-val").Value = ThisWorkbook.Sheets("sheet1").Range("IW10")
IE.Document.GetElementByID("yNfuoYteftA-bZ4b1EW7Uw7-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:02")
End If
'End PMTCT_EID HEI_POS
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
Sub TX_NEW_TX_CURR()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-4").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-12").Click
Else
IE.Document.GetElementByID("ui-id-13").Click
End If
Application.Wait Now + TimeValue("00:00:03")
'TX_NEW
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IX10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("BunPg5H6AL9-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("BunPg5H6AL9-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IX10")
IE.Document.GetElementByID("BunPg5H6AL9-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JqSiilvpE7v-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("JqSiilvpE7v-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("IX10")
IE.Document.GetElementByID("JqSiilvpE7v-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Pregnant
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("QI0LrOAmBCG-vxBSF1mguas-val").Focus
IE.Document.GetElementByID("QI0LrOAmBCG-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("IY10")
IE.Document.GetElementByID("QI0LrOAmBCG-vxBSF1mguas-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JiEYm4EWwtR-vxBSF1mguas-val").Focus
IE.Document.GetElementByID("JiEYm4EWwtR-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("IY10")
IE.Document.GetElementByID("JiEYm4EWwtR-vxBSF1mguas-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Breastfeeding
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IZ10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("IZ10")
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("JiEYm4EWwtR-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("JiEYm4EWwtR-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("IZ10")
IE.Document.GetElementByID("JiEYm4EWwtR-jaxEUorPKgv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'TB
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JA10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("VGykA1pjgZz-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("VGykA1pjgZz-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JA10")
IE.Document.GetElementByID("VGykA1pjgZz-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("eTkiWqrqxkG-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("eTkiWqrqxkG-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JA10")
IE.Document.GetElementByID("eTkiWqrqxkG-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'<1
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JB10")
IE.Document.GetElementByID("yXZtvoYQXcD-fYknd2lPzAm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JB10")
IE.Document.GetElementByID("FjLaCnuoQWR-fYknd2lPzAm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'1-9
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JC10")
IE.Document.GetElementByID("yXZtvoYQXcD-CtnbWoya5d5-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JC10")
IE.Document.GetElementByID("FjLaCnuoQWR-CtnbWoya5d5-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,10-14
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("JD10")
IE.Document.GetElementByID("yXZtvoYQXcD-J7mbG9jKSpr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("JD10")
IE.Document.GetElementByID("FjLaCnuoQWR-J7mbG9jKSpr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,15-19
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("JE10")
IE.Document.GetElementByID("yXZtvoYQXcD-Ek2cTSEcl3p-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("JE10")
IE.Document.GetElementByID("FjLaCnuoQWR-Ek2cTSEcl3p-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,20-24
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("JF10")
IE.Document.GetElementByID("yXZtvoYQXcD-zpiyTuKQQ2e-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("JF10")
IE.Document.GetElementByID("FjLaCnuoQWR-zpiyTuKQQ2e-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,25-29
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("JG10")
IE.Document.GetElementByID("yXZtvoYQXcD-RED4BPdFO11-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("JG10")
IE.Document.GetElementByID("FjLaCnuoQWR-RED4BPdFO11-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,30-34
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("JH10")
IE.Document.GetElementByID("yXZtvoYQXcD-LljzDYxQ1Ga-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("JH10")
IE.Document.GetElementByID("FjLaCnuoQWR-LljzDYxQ1Ga-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,35-39
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("JI10")
IE.Document.GetElementByID("yXZtvoYQXcD-TEgIyIVs5JA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("JI10")
IE.Document.GetElementByID("FjLaCnuoQWR-TEgIyIVs5JA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,40-49
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("JJ10")
IE.Document.GetElementByID("yXZtvoYQXcD-F0cTl1AAJxz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("JJ10")
IE.Document.GetElementByID("FjLaCnuoQWR-F0cTl1AAJxz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,50+
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("JK10")
IE.Document.GetElementByID("yXZtvoYQXcD-lA60kBSujWH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("JK10")
IE.Document.GetElementByID("FjLaCnuoQWR-lA60kBSujWH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,10-14
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("JL10")
IE.Document.GetElementByID("yXZtvoYQXcD-S4urVfq4oVX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("JL10")
IE.Document.GetElementByID("FjLaCnuoQWR-S4urVfq4oVX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,15-19
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JM10")
IE.Document.GetElementByID("yXZtvoYQXcD-h5FQFklI9Vn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JM10")
IE.Document.GetElementByID("FjLaCnuoQWR-h5FQFklI9Vn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,20-24
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("JN10")
IE.Document.GetElementByID("yXZtvoYQXcD-QNulEjcSLQT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("JN10")
IE.Document.GetElementByID("FjLaCnuoQWR-QNulEjcSLQT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,25-29
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("JO10")
IE.Document.GetElementByID("yXZtvoYQXcD-iIZEtL6l6Hb-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("JO10")
IE.Document.GetElementByID("FjLaCnuoQWR-iIZEtL6l6Hb-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,30-34
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("JP10")
IE.Document.GetElementByID("yXZtvoYQXcD-aQHB69TmOWe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("JP10")
IE.Document.GetElementByID("FjLaCnuoQWR-aQHB69TmOWe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,35-39
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JQ10")
IE.Document.GetElementByID("yXZtvoYQXcD-T9kxtfDL0pn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("JQ10")
IE.Document.GetElementByID("FjLaCnuoQWR-T9kxtfDL0pn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,40-49
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-cci2MH041nc-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("JR10")
IE.Document.GetElementByID("yXZtvoYQXcD-cci2MH041nc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-cci2MH041nc-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("JR10")
IE.Document.GetElementByID("FjLaCnuoQWR-cci2MH041nc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,50+
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("yXZtvoYQXcD-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("JS10")
IE.Document.GetElementByID("yXZtvoYQXcD-rPO0WWEbKzL-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FjLaCnuoQWR-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("FjLaCnuoQWR-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("JS10")
IE.Document.GetElementByID("FjLaCnuoQWR-rPO0WWEbKzL-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,<15
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("JT10")
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").dispatchEvent evt
Else
IE.Document.GetElementByID("a2BO57JIf4z-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("a2BO57JIf4z-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("JT10")
IE.Document.GetElementByID("a2BO57JIf4z-wIv7t5fSIlK-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,15+
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("JU10")
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("a2BO57JIf4z-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("a2BO57JIf4z-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("JU10")
IE.Document.GetElementByID("a2BO57JIf4z-R6XPf8j0tYt-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,<15
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("JV10")
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").dispatchEvent evt
Else
IE.Document.GetElementByID("a2BO57JIf4z-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("a2BO57JIf4z-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("JV10")
IE.Document.GetElementByID("a2BO57JIf4z-GhywTqKHQNM-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,15+
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JB10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("JW10")
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").dispatchEvent evt
Else
IE.Document.GetElementByID("a2BO57JIf4z-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("a2BO57JIf4z-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("JW10")
IE.Document.GetElementByID("a2BO57JIf4z-ZnMtvRMKMWh-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
End If

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
'TX_CURR
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JX10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D2KvZp54CsB-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("D2KvZp54CsB-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JX10")
IE.Document.GetElementByID("D2KvZp54CsB-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("moJA7xJZWuJ-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("moJA7xJZWuJ-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JX10")
IE.Document.GetElementByID("moJA7xJZWuJ-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JY10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-fYknd2lPzAm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JY10")
IE.Document.GetElementByID("ebCEt4u78PX-fYknd2lPzAm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'1-9
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JZ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-CtnbWoya5d5-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("JZ10")
IE.Document.GetElementByID("ebCEt4u78PX-CtnbWoya5d5-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,10-14
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("KA10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-J7mbG9jKSpr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("KA10")
IE.Document.GetElementByID("ebCEt4u78PX-J7mbG9jKSpr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,15-19
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("KB10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-Ek2cTSEcl3p-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("KB10")
IE.Document.GetElementByID("ebCEt4u78PX-Ek2cTSEcl3p-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,20-24
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("KC10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zpiyTuKQQ2e-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("KC10")
IE.Document.GetElementByID("ebCEt4u78PX-zpiyTuKQQ2e-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,25-29
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("KD10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-RED4BPdFO11-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("KD10")
IE.Document.GetElementByID("ebCEt4u78PX-RED4BPdFO11-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,30-34
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KE10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-LljzDYxQ1Ga-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KE10")
IE.Document.GetElementByID("ebCEt4u78PX-LljzDYxQ1Ga-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,35-39
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("KF10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-TEgIyIVs5JA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("KF10")
IE.Document.GetElementByID("ebCEt4u78PX-TEgIyIVs5JA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,40-49
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("KG10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-F0cTl1AAJxz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("KG10")
IE.Document.GetElementByID("ebCEt4u78PX-F0cTl1AAJxz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,50+
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("KH10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-lA60kBSujWH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("KH10")
IE.Document.GetElementByID("ebCEt4u78PX-lA60kBSujWH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,10-14
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("KI10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-S4urVfq4oVX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("KI10")
IE.Document.GetElementByID("ebCEt4u78PX-S4urVfq4oVX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,15-19
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KJ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-h5FQFklI9Vn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KJ10")
IE.Document.GetElementByID("ebCEt4u78PX-h5FQFklI9Vn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,20-24
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("KK10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-QNulEjcSLQT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("KK10")
IE.Document.GetElementByID("ebCEt4u78PX-QNulEjcSLQT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,25-29
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("KL10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-iIZEtL6l6Hb-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("KL10")
IE.Document.GetElementByID("ebCEt4u78PX-iIZEtL6l6Hb-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,30-34
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("KM10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-aQHB69TmOWe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("KM10")
IE.Document.GetElementByID("ebCEt4u78PX-aQHB69TmOWe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,35-39
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KN10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-T9kxtfDL0pn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("KN10")
IE.Document.GetElementByID("ebCEt4u78PX-T9kxtfDL0pn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,40-49
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-cci2MH041nc-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("KO10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-cci2MH041nc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-cci2MH041nc-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("KO10")
IE.Document.GetElementByID("ebCEt4u78PX-cci2MH041nc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,50+
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Hyvw9VnZ2ch-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("KP10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-rPO0WWEbKzL-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ebCEt4u78PX-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("ebCEt4u78PX-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("KP10")
IE.Document.GetElementByID("ebCEt4u78PX-rPO0WWEbKzL-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,<15
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KQ10")
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qkjYvdfOakY-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("qkjYvdfOakY-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KQ10")
IE.Document.GetElementByID("qkjYvdfOakY-wIv7t5fSIlK-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Female,15+
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KR10")
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qkjYvdfOakY-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("qkjYvdfOakY-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KR10")
IE.Document.GetElementByID("qkjYvdfOakY-R6XPf8j0tYt-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,<15
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("KS10")
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qkjYvdfOakY-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("qkjYvdfOakY-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("KS10")
IE.Document.GetElementByID("qkjYvdfOakY-GhywTqKHQNM-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'Male,15+
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JY10")) Then
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("KT10")
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").dispatchEvent evt
Else
IE.Document.GetElementByID("qkjYvdfOakY-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("qkjYvdfOakY-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("KT10")
IE.Document.GetElementByID("qkjYvdfOakY-ZnMtvRMKMWh-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
End If
'End TX_NEW_TX_CURR
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
'PMTCT_ART
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("KU10")) Then
'Newly
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("dfUOSQ4dypU-Q2EBeMBa8Ga-val").Focus
IE.Document.GetElementByID("dfUOSQ4dypU-Q2EBeMBa8Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KU10")
IE.Document.GetElementByID("dfUOSQ4dypU-Q2EBeMBa8Ga-val").dispatchEvent evt
Else
IE.Document.GetElementByID("AbBlLexIsnr-Q2EBeMBa8Ga-val").Focus
IE.Document.GetElementByID("AbBlLexIsnr-Q2EBeMBa8Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("KU10")
IE.Document.GetElementByID("AbBlLexIsnr-Q2EBeMBa8Ga-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("dfUOSQ4dypU-RTYO8ycjbCt-val").Focus
IE.Document.GetElementByID("dfUOSQ4dypU-RTYO8ycjbCt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KV10")
IE.Document.GetElementByID("dfUOSQ4dypU-RTYO8ycjbCt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("AbBlLexIsnr-RTYO8ycjbCt-val").Focus
IE.Document.GetElementByID("AbBlLexIsnr-RTYO8ycjbCt-val").Value = ThisWorkbook.Sheets("sheet1").Range("KV10")
IE.Document.GetElementByID("AbBlLexIsnr-RTYO8ycjbCt-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End PMTCT_ART
End Sub

' TTTTTTTTTTTBBBBBBBBBB        PPPPPPPPP   PRRRRRRRRR   EEEEEEEEEEEEEVV    VVVV  
' TTTTTTTTTTTBBBBBBBBBBB       PPPPPPPPPP  PRRRRRRRRRR  EEEEEEEEEEEEEVV    VVVV  
' TTTTTTTTTTTBBBBBBBBBBB       PPPPPPPPPPP PRRRRRRRRRR  EEEEEEEEEEEEEVV    VVVV  
'    TTTT    BBBB   BBBB       PPPP   PPPP PRRR   RRRRR EEEE       EEVVV  VVVV   
'    TTTT    BBBB   BBBB       PPPP   PPPP PRRR   RRRRR EEEE        EVVV  VVVV   
'    TTTT    BBBBBBBBBBB       PPPPPPPPPPP PRRRRRRRRRR  EEEEEEEEEE  EVVV  VVVV   
'    TTTT    BBBBBBBBBB        PPPPPPPPPP  PRRRRRRRRRR  EEEEEEEEEE  EVVVVVVVV    
'    TTTT    BBBBBBBBBBB       PPPPPPPPP   PRRRRRRR     EEEEEEEEEE   VVVVVVVV    
'    TTTT    BBBB    BBBB      PPPP        PRRR RRRR    EEEE         VVVVVVVV    
'    TTTT    BBBB    BBBB      PPPP        PRRR  RRRR   EEEE         VVVVVVV     
'    TTTT    BBBBBBBBBBBB      PPPP        PRRR  RRRRR  EEEEEEEEEEE   VVVVVV     
'    TTTT    BBBBBBBBBBB       PPPP        PRRR   RRRRR EEEEEEEEEEE   VVVVVV     
'    TTTT    BBBBBBBBBB        PPPP        PRRR    RRRR EEEEEEEEEEE   VVVVV      
Sub TB_PREV()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-2").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-7").Click
Else
IE.Document.GetElementByID("ui-id-8").Click
End If
Application.Wait Now + TimeValue("00:00:03")
'TB_PREV
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("KW10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("wdNc4AeiH95-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("wdNc4AeiH95-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KW10")
IE.Document.GetElementByID("wdNc4AeiH95-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("f9kduaQUMKV-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("f9kduaQUMKV-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KW10")
IE.Document.GetElementByID("f9kduaQUMKV-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'IPT, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("FqAdKlk9CuW-xTbmPjpd5sB-val").Focus
IE.Document.GetElementByID("FqAdKlk9CuW-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("KX10")
IE.Document.GetElementByID("FqAdKlk9CuW-xTbmPjpd5sB-val").dispatchEvent evt
Else
IE.Document.GetElementByID("vdoRxRjgvFm-xTbmPjpd5sB-val").Focus
IE.Document.GetElementByID("vdoRxRjgvFm-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("KX10")
IE.Document.GetElementByID("vdoRxRjgvFm-xTbmPjpd5sB-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("FqAdKlk9CuW-ujD0vlLsULk-val").Focus
IE.Document.GetElementByID("FqAdKlk9CuW-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("KY10")
IE.Document.GetElementByID("FqAdKlk9CuW-ujD0vlLsULk-val").dispatchEvent evt
Else
IE.Document.GetElementByID("vdoRxRjgvFm-ujD0vlLsULk-val").Focus
IE.Document.GetElementByID("vdoRxRjgvFm-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("KY10")
IE.Document.GetElementByID("vdoRxRjgvFm-ujD0vlLsULk-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("gLYr2HkqACp-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LB10")
IE.Document.GetElementByID("gLYr2HkqACp-mdH8pnWvjf3-val").dispatchEvent evt
Else
IE.Document.GetElementByID("h6WsUZjy18B-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("h6WsUZjy18B-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LB10")
IE.Document.GetElementByID("h6WsUZjy18B-mdH8pnWvjf3-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("gLYr2HkqACp-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LC10")
IE.Document.GetElementByID("gLYr2HkqACp-M5tkYhf3wH0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("h6WsUZjy18B-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("h6WsUZjy18B-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LC10")
IE.Document.GetElementByID("h6WsUZjy18B-M5tkYhf3wH0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("gLYr2HkqACp-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LD10")
IE.Document.GetElementByID("gLYr2HkqACp-EinRX4vGJHS-val").dispatchEvent evt
Else
IE.Document.GetElementByID("h6WsUZjy18B-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("h6WsUZjy18B-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LD10")
IE.Document.GetElementByID("h6WsUZjy18B-EinRX4vGJHS-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("gLYr2HkqACp-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("gLYr2HkqACp-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LE10")
IE.Document.GetElementByID("gLYr2HkqACp-rtt53W8KwRV-val").dispatchEvent evt
Else
IE.Document.GetElementByID("h6WsUZjy18B-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("h6WsUZjy18B-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LE10")
IE.Document.GetElementByID("h6WsUZjy18B-rtt53W8KwRV-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("DFOhwZmqmLA-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("DFOhwZmqmLA-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("LF10")
IE.Document.GetElementByID("DFOhwZmqmLA-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("NZGXcA4oHYe-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("NZGXcA4oHYe-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("LF10")
IE.Document.GetElementByID("NZGXcA4oHYe-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'IPT, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("v8ebDCsu6HA-xTbmPjpd5sB-val").Focus
IE.Document.GetElementByID("v8ebDCsu6HA-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LG10")
IE.Document.GetElementByID("v8ebDCsu6HA-xTbmPjpd5sB-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Ge1F4eyI3lc-xTbmPjpd5sB-val").Focus
IE.Document.GetElementByID("Ge1F4eyI3lc-xTbmPjpd5sB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LG10")
IE.Document.GetElementByID("Ge1F4eyI3lc-xTbmPjpd5sB-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'IPT, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("v8ebDCsu6HA-ujD0vlLsULk-val").Focus
IE.Document.GetElementByID("v8ebDCsu6HA-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("LH10")
IE.Document.GetElementByID("v8ebDCsu6HA-ujD0vlLsULk-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Ge1F4eyI3lc-ujD0vlLsULk-val").Focus
IE.Document.GetElementByID("Ge1F4eyI3lc-ujD0vlLsULk-val").Value = ThisWorkbook.Sheets("sheet1").Range("LH10")
IE.Document.GetElementByID("Ge1F4eyI3lc-ujD0vlLsULk-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("vHCvmxeOulc-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LK10")
IE.Document.GetElementByID("vHCvmxeOulc-mdH8pnWvjf3-val").dispatchEvent evt
Else
IE.Document.GetElementByID("NFYlz2qYNka-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("NFYlz2qYNka-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("LK10")
IE.Document.GetElementByID("NFYlz2qYNka-mdH8pnWvjf3-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("vHCvmxeOulc-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LL10")
IE.Document.GetElementByID("vHCvmxeOulc-M5tkYhf3wH0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("NFYlz2qYNka-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("NFYlz2qYNka-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LL10")
IE.Document.GetElementByID("NFYlz2qYNka-M5tkYhf3wH0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("vHCvmxeOulc-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LM10")
IE.Document.GetElementByID("vHCvmxeOulc-EinRX4vGJHS-val").dispatchEvent evt
Else
IE.Document.GetElementByID("NFYlz2qYNka-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("NFYlz2qYNka-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("LM10")
IE.Document.GetElementByID("NFYlz2qYNka-EinRX4vGJHS-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("vHCvmxeOulc-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("vHCvmxeOulc-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LN10")
IE.Document.GetElementByID("vHCvmxeOulc-rtt53W8KwRV-val").dispatchEvent evt
Else
IE.Document.GetElementByID("NFYlz2qYNka-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("NFYlz2qYNka-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("LN10")
IE.Document.GetElementByID("NFYlz2qYNka-rtt53W8KwRV-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End TB_PREV
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
'Select TAB
IE.Document.GetElementByID("ui-id-3").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-10").Click
Else
IE.Document.GetElementByID("ui-id-11").Click
End If
Application.Wait Now + TimeValue("00:00:03")
'TB_STAT
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("LO10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GLx5aAKX4MD-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("GLx5aAKX4MD-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LO10")
IE.Document.GetElementByID("GLx5aAKX4MD-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("rTZdUyIFsGy-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("rTZdUyIFsGy-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("LO10")
IE.Document.GetElementByID("rTZdUyIFsGy-HllvX50cXC0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Known Positives
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-twCITCOvoZA-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-twCITCOvoZA-val").Value = ThisWorkbook.Sheets("sheet1").Range("LR10")
IE.Document.GetElementByID("tnthrE5AclR-twCITCOvoZA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-twCITCOvoZA-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-twCITCOvoZA-val").Value = ThisWorkbook.Sheets("sheet1").Range("LR10")
IE.Document.GetElementByID("s0ZhN1hwLa6-twCITCOvoZA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-PVCB2tKuVGO-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-PVCB2tKuVGO-val").Value = ThisWorkbook.Sheets("sheet1").Range("LS10")
IE.Document.GetElementByID("tnthrE5AclR-PVCB2tKuVGO-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-PVCB2tKuVGO-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-PVCB2tKuVGO-val").Value = ThisWorkbook.Sheets("sheet1").Range("LS10")
IE.Document.GetElementByID("s0ZhN1hwLa6-PVCB2tKuVGO-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-bXQKnndJcUy-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-bXQKnndJcUy-val").Value = ThisWorkbook.Sheets("sheet1").Range("LT10")
IE.Document.GetElementByID("tnthrE5AclR-bXQKnndJcUy-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-bXQKnndJcUy-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-bXQKnndJcUy-val").Value = ThisWorkbook.Sheets("sheet1").Range("LT10")
IE.Document.GetElementByID("s0ZhN1hwLa6-bXQKnndJcUy-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-a9IejiMkpxr-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-a9IejiMkpxr-val").Value = ThisWorkbook.Sheets("sheet1").Range("LU10")
IE.Document.GetElementByID("tnthrE5AclR-a9IejiMkpxr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-a9IejiMkpxr-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-a9IejiMkpxr-val").Value = ThisWorkbook.Sheets("sheet1").Range("LU10")
IE.Document.GetElementByID("s0ZhN1hwLa6-a9IejiMkpxr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Newly Tested Positives
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-QrgQR5qqecn-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-QrgQR5qqecn-val").Value = ThisWorkbook.Sheets("sheet1").Range("LX10")
IE.Document.GetElementByID("tnthrE5AclR-QrgQR5qqecn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-QrgQR5qqecn-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-QrgQR5qqecn-val").Value = ThisWorkbook.Sheets("sheet1").Range("LX10")
IE.Document.GetElementByID("s0ZhN1hwLa6-QrgQR5qqecn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-qR9wVOZHs3F-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-qR9wVOZHs3F-val").Value = ThisWorkbook.Sheets("sheet1").Range("LY10")
IE.Document.GetElementByID("tnthrE5AclR-qR9wVOZHs3F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-qR9wVOZHs3F-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-qR9wVOZHs3F-val").Value = ThisWorkbook.Sheets("sheet1").Range("LY10")
IE.Document.GetElementByID("s0ZhN1hwLa6-qR9wVOZHs3F-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-YXt74Aa7CQB-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-YXt74Aa7CQB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LZ10")
IE.Document.GetElementByID("tnthrE5AclR-YXt74Aa7CQB-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-YXt74Aa7CQB-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-YXt74Aa7CQB-val").Value = ThisWorkbook.Sheets("sheet1").Range("LZ10")
IE.Document.GetElementByID("s0ZhN1hwLa6-YXt74Aa7CQB-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-H2d7tWiIX9V-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-H2d7tWiIX9V-val").Value = ThisWorkbook.Sheets("sheet1").Range("MA10")
IE.Document.GetElementByID("tnthrE5AclR-H2d7tWiIX9V-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-H2d7tWiIX9V-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-H2d7tWiIX9V-val").Value = ThisWorkbook.Sheets("sheet1").Range("MA10")
IE.Document.GetElementByID("s0ZhN1hwLa6-H2d7tWiIX9V-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'New Negatives
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-zC0EQMShVZc-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-zC0EQMShVZc-val").Value = ThisWorkbook.Sheets("sheet1").Range("MD10")
IE.Document.GetElementByID("tnthrE5AclR-zC0EQMShVZc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-zC0EQMShVZc-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-zC0EQMShVZc-val").Value = ThisWorkbook.Sheets("sheet1").Range("MD10")
IE.Document.GetElementByID("s0ZhN1hwLa6-zC0EQMShVZc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-zjd6BsbodQV-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-zjd6BsbodQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ME10")
IE.Document.GetElementByID("tnthrE5AclR-zjd6BsbodQV-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-zjd6BsbodQV-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-zjd6BsbodQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ME10")
IE.Document.GetElementByID("s0ZhN1hwLa6-zjd6BsbodQV-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-cQQ1Cu0X0sU-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-cQQ1Cu0X0sU-val").Value = ThisWorkbook.Sheets("sheet1").Range("MF10")
IE.Document.GetElementByID("tnthrE5AclR-cQQ1Cu0X0sU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-cQQ1Cu0X0sU-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-cQQ1Cu0X0sU-val").Value = ThisWorkbook.Sheets("sheet1").Range("MF10")
IE.Document.GetElementByID("s0ZhN1hwLa6-cQQ1Cu0X0sU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("tnthrE5AclR-ewOK9Oo1KWm-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-ewOK9Oo1KWm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MG10")
IE.Document.GetElementByID("tnthrE5AclR-ewOK9Oo1KWm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("s0ZhN1hwLa6-ewOK9Oo1KWm-val").Focus
IE.Document.GetElementByID("s0ZhN1hwLa6-ewOK9Oo1KWm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MG10")
IE.Document.GetElementByID("s0ZhN1hwLa6-ewOK9Oo1KWm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("LZXAdOjlBwi-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("LZXAdOjlBwi-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("MH10")
IE.Document.GetElementByID("LZXAdOjlBwi-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("TcyIxVHZd8I-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("TcyIxVHZd8I-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("MH10")
IE.Document.GetElementByID("TcyIxVHZd8I-HllvX50cXC0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<15, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-BGFCDhyk4M8-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-BGFCDhyk4M8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MK10")
IE.Document.GetElementByID("uOfuBlHwdn7-BGFCDhyk4M8-val").dispatchEvent evt
Else
IE.Document.GetElementByID("AcTftDyXTzF-BGFCDhyk4M8-val").Focus
IE.Document.GetElementByID("AcTftDyXTzF-BGFCDhyk4M8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MK10")
IE.Document.GetElementByID("AcTftDyXTzF-BGFCDhyk4M8-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<15, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-SBUMYkq3pEs-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-SBUMYkq3pEs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ML10")
IE.Document.GetElementByID("uOfuBlHwdn7-SBUMYkq3pEs-val").dispatchEvent evt
Else
IE.Document.GetElementByID("AcTftDyXTzF-SBUMYkq3pEs-val").Focus
IE.Document.GetElementByID("AcTftDyXTzF-SBUMYkq3pEs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ML10")
IE.Document.GetElementByID("AcTftDyXTzF-SBUMYkq3pEs-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Female
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-er95aeLbIHg-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-er95aeLbIHg-val").Value = ThisWorkbook.Sheets("sheet1").Range("MM10")
IE.Document.GetElementByID("uOfuBlHwdn7-er95aeLbIHg-val").dispatchEvent evt
Else
IE.Document.GetElementByID("AcTftDyXTzF-er95aeLbIHg-val").Focus
IE.Document.GetElementByID("AcTftDyXTzF-er95aeLbIHg-val").Value = ThisWorkbook.Sheets("sheet1").Range("MM10")
IE.Document.GetElementByID("AcTftDyXTzF-er95aeLbIHg-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'15+, Male
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uOfuBlHwdn7-RFKoE51NKAq-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-RFKoE51NKAq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MN10")
IE.Document.GetElementByID("uOfuBlHwdn7-RFKoE51NKAq-val").dispatchEvent evt
Else
IE.Document.GetElementByID("AcTftDyXTzF-RFKoE51NKAq-val").Focus
IE.Document.GetElementByID("AcTftDyXTzF-RFKoE51NKAq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MN10")
IE.Document.GetElementByID("AcTftDyXTzF-RFKoE51NKAq-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End TB_STAT
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
'Select TAB
IE.Document.GetElementByID("ui-id-4").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-12").Click
Else
IE.Document.GetElementByID("ui-id-13").Click
End If
Application.Wait Now + TimeValue("00:00:03")
'TB_ART
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("MO10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pecRCQ589Ip-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("pecRCQ589Ip-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("MO10")
IE.Document.GetElementByID("pecRCQ589Ip-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("J0EJi8BhnUC-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("J0EJi8BhnUC-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("MO10")
IE.Document.GetElementByID("J0EJi8BhnUC-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("TXqEC76VtrC-TQTMswJXhmR-val").Focus
IE.Document.GetElementByID("TXqEC76VtrC-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("MP10")
IE.Document.GetElementByID("TXqEC76VtrC-TQTMswJXhmR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ocBmpbqlNsi-TQTMswJXhmR-val").Focus
IE.Document.GetElementByID("ocBmpbqlNsi-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("MP10")
IE.Document.GetElementByID("ocBmpbqlNsi-TQTMswJXhmR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("TXqEC76VtrC-CVQ1FRYe4Ra-val").Focus
IE.Document.GetElementByID("TXqEC76VtrC-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("MQ10")
IE.Document.GetElementByID("TXqEC76VtrC-CVQ1FRYe4Ra-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ocBmpbqlNsi-CVQ1FRYe4Ra-val").Focus
IE.Document.GetElementByID("ocBmpbqlNsi-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("MQ10")
IE.Document.GetElementByID("ocBmpbqlNsi-CVQ1FRYe4Ra-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MR10")
IE.Document.GetElementByID("bjpeWBZGkaV-fYknd2lPzAm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("MR10")
IE.Document.GetElementByID("fhBEkut3R3H-fYknd2lPzAm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("MS10")
IE.Document.GetElementByID("bjpeWBZGkaV-CtnbWoya5d5-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("MS10")
IE.Document.GetElementByID("fhBEkut3R3H-CtnbWoya5d5-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("MT10")
IE.Document.GetElementByID("bjpeWBZGkaV-J7mbG9jKSpr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("MT10")
IE.Document.GetElementByID("fhBEkut3R3H-J7mbG9jKSpr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("MU10")
IE.Document.GetElementByID("bjpeWBZGkaV-Ek2cTSEcl3p-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("MU10")
IE.Document.GetElementByID("fhBEkut3R3H-Ek2cTSEcl3p-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("MV10")
IE.Document.GetElementByID("bjpeWBZGkaV-zpiyTuKQQ2e-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("MV10")
IE.Document.GetElementByID("fhBEkut3R3H-zpiyTuKQQ2e-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("MW10")
IE.Document.GetElementByID("bjpeWBZGkaV-RED4BPdFO11-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("MW10")
IE.Document.GetElementByID("fhBEkut3R3H-RED4BPdFO11-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("MX10")
IE.Document.GetElementByID("bjpeWBZGkaV-LljzDYxQ1Ga-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("MX10")
IE.Document.GetElementByID("fhBEkut3R3H-LljzDYxQ1Ga-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("MY10")
IE.Document.GetElementByID("bjpeWBZGkaV-TEgIyIVs5JA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("MY10")
IE.Document.GetElementByID("fhBEkut3R3H-TEgIyIVs5JA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("MZ10")
IE.Document.GetElementByID("bjpeWBZGkaV-F0cTl1AAJxz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("MZ10")
IE.Document.GetElementByID("fhBEkut3R3H-F0cTl1AAJxz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("NA10")
IE.Document.GetElementByID("bjpeWBZGkaV-lA60kBSujWH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("NA10")
IE.Document.GetElementByID("fhBEkut3R3H-lA60kBSujWH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("NB10")
IE.Document.GetElementByID("bjpeWBZGkaV-S4urVfq4oVX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("NB10")
IE.Document.GetElementByID("fhBEkut3R3H-S4urVfq4oVX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NC10")
IE.Document.GetElementByID("bjpeWBZGkaV-h5FQFklI9Vn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NC10")
IE.Document.GetElementByID("fhBEkut3R3H-h5FQFklI9Vn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ND10")
IE.Document.GetElementByID("bjpeWBZGkaV-QNulEjcSLQT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ND10")
IE.Document.GetElementByID("fhBEkut3R3H-QNulEjcSLQT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("NE10")
IE.Document.GetElementByID("bjpeWBZGkaV-iIZEtL6l6Hb-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("NE10")
IE.Document.GetElementByID("fhBEkut3R3H-iIZEtL6l6Hb-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("NF10")
IE.Document.GetElementByID("bjpeWBZGkaV-aQHB69TmOWe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("NF10")
IE.Document.GetElementByID("fhBEkut3R3H-aQHB69TmOWe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NG10")
IE.Document.GetElementByID("bjpeWBZGkaV-T9kxtfDL0pn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("NG10")
IE.Document.GetElementByID("fhBEkut3R3H-T9kxtfDL0pn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-cci2MH041nc-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("NH10")
IE.Document.GetElementByID("bjpeWBZGkaV-cci2MH041nc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-cci2MH041nc-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("NH10")
IE.Document.GetElementByID("fhBEkut3R3H-cci2MH041nc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bjpeWBZGkaV-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("bjpeWBZGkaV-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("NI10")
IE.Document.GetElementByID("bjpeWBZGkaV-rPO0WWEbKzL-val").dispatchEvent evt
Else
IE.Document.GetElementByID("fhBEkut3R3H-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("fhBEkut3R3H-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("NI10")
IE.Document.GetElementByID("fhBEkut3R3H-rPO0WWEbKzL-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End TB_ART
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
'TX_TB
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("NJ10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("bO90YLjSbox-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("bO90YLjSbox-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NJ10")
IE.Document.GetElementByID("bO90YLjSbox-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ZdCidLkGGV4-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("ZdCidLkGGV4-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NJ10")
IE.Document.GetElementByID("ZdCidLkGGV4-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CEANcO1xqgC-CVQ1FRYe4Ra-val").Focus
IE.Document.GetElementByID("CEANcO1xqgC-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("NK10")
IE.Document.GetElementByID("CEANcO1xqgC-CVQ1FRYe4Ra-val").dispatchEvent evt
Else
IE.Document.GetElementByID("WQowTtUTc97-CVQ1FRYe4Ra-val").Focus
IE.Document.GetElementByID("WQowTtUTc97-CVQ1FRYe4Ra-val").Value = ThisWorkbook.Sheets("sheet1").Range("NK10")
IE.Document.GetElementByID("WQowTtUTc97-CVQ1FRYe4Ra-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CEANcO1xqgC-TQTMswJXhmR-val").Focus
IE.Document.GetElementByID("CEANcO1xqgC-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("NL10")
IE.Document.GetElementByID("CEANcO1xqgC-TQTMswJXhmR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("WQowTtUTc97-TQTMswJXhmR-val").Focus
IE.Document.GetElementByID("WQowTtUTc97-TQTMswJXhmR-val").Value = ThisWorkbook.Sheets("sheet1").Range("NL10")
IE.Document.GetElementByID("WQowTtUTc97-TQTMswJXhmR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("fexxrOGUvrv-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NM10")
IE.Document.GetElementByID("fexxrOGUvrv-mdH8pnWvjf3-val").dispatchEvent evt
Else
IE.Document.GetElementByID("G6EQGNhixQe-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("G6EQGNhixQe-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NM10")
IE.Document.GetElementByID("G6EQGNhixQe-mdH8pnWvjf3-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("fexxrOGUvrv-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("NN10")
IE.Document.GetElementByID("fexxrOGUvrv-M5tkYhf3wH0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("G6EQGNhixQe-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("G6EQGNhixQe-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("NN10")
IE.Document.GetElementByID("G6EQGNhixQe-M5tkYhf3wH0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("fexxrOGUvrv-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("NO10")
IE.Document.GetElementByID("fexxrOGUvrv-EinRX4vGJHS-val").dispatchEvent evt
Else
IE.Document.GetElementByID("G6EQGNhixQe-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("G6EQGNhixQe-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("NO10")
IE.Document.GetElementByID("G6EQGNhixQe-EinRX4vGJHS-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("fexxrOGUvrv-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("fexxrOGUvrv-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("NP10")
IE.Document.GetElementByID("fexxrOGUvrv-rtt53W8KwRV-val").dispatchEvent evt
Else
IE.Document.GetElementByID("G6EQGNhixQe-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("G6EQGNhixQe-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("NP10")
IE.Document.GetElementByID("G6EQGNhixQe-rtt53W8KwRV-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("lo2c9TXkj5X-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("lo2c9TXkj5X-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NQ10")
IE.Document.GetElementByID("lo2c9TXkj5X-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("iBT0uRSIadN-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("iBT0uRSIadN-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("NQ10")
IE.Document.GetElementByID("iBT0uRSIadN-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Positive, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-s5fJZmqOejY-val").Focus
IE.Document.GetElementByID("CTStqfWGP5K-s5fJZmqOejY-val").Value = ThisWorkbook.Sheets("sheet1").Range("NR10")
IE.Document.GetElementByID("CTStqfWGP5K-s5fJZmqOejY-val").dispatchEvent evt
Else
IE.Document.GetElementByID("cdacTAmnRph-s5fJZmqOejY-val").Focus
IE.Document.GetElementByID("cdacTAmnRph-s5fJZmqOejY-val").Value = ThisWorkbook.Sheets("sheet1").Range("NR10")
IE.Document.GetElementByID("cdacTAmnRph-s5fJZmqOejY-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Positive, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-u6sRGIOBmoh-val").Focus
IE.Document.GetElementByID("CTStqfWGP5K-u6sRGIOBmoh-val").Value = ThisWorkbook.Sheets("sheet1").Range("NS10")
IE.Document.GetElementByID("CTStqfWGP5K-u6sRGIOBmoh-val").dispatchEvent evt
Else
IE.Document.GetElementByID("cdacTAmnRph-u6sRGIOBmoh-val").Focus
IE.Document.GetElementByID("cdacTAmnRph-u6sRGIOBmoh-val").Value = ThisWorkbook.Sheets("sheet1").Range("NS10")
IE.Document.GetElementByID("cdacTAmnRph-u6sRGIOBmoh-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Negative, New
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-e2L487QXxft-val").Focus
IE.Document.GetElementByID("CTStqfWGP5K-e2L487QXxft-val").Value = ThisWorkbook.Sheets("sheet1").Range("NT10")
IE.Document.GetElementByID("CTStqfWGP5K-e2L487QXxft-val").dispatchEvent evt
Else
IE.Document.GetElementByID("cdacTAmnRph-e2L487QXxft-val").Focus
IE.Document.GetElementByID("cdacTAmnRph-e2L487QXxft-val").Value = ThisWorkbook.Sheets("sheet1").Range("NT10")
IE.Document.GetElementByID("cdacTAmnRph-e2L487QXxft-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Negative, Already
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("CTStqfWGP5K-shTc2NWLhMt-val").Focus
IE.Document.GetElementByID("CTStqfWGP5K-shTc2NWLhMt-val").Value = ThisWorkbook.Sheets("sheet1").Range("NU10")
IE.Document.GetElementByID("CTStqfWGP5K-shTc2NWLhMt-val").dispatchEvent evt
Else
IE.Document.GetElementByID("cdacTAmnRph-shTc2NWLhMt-val").Focus
IE.Document.GetElementByID("cdacTAmnRph-shTc2NWLhMt-val").Value = ThisWorkbook.Sheets("sheet1").Range("NU10")
IE.Document.GetElementByID("cdacTAmnRph-shTc2NWLhMt-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")

'Female,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("jWXNXtGEGKn-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NZ10")
IE.Document.GetElementByID("jWXNXtGEGKn-mdH8pnWvjf3-val").dispatchEvent evt
Else
IE.Document.GetElementByID("QBCFhUL0DsI-mdH8pnWvjf3-val").Focus
IE.Document.GetElementByID("QBCFhUL0DsI-mdH8pnWvjf3-val").Value = ThisWorkbook.Sheets("sheet1").Range("NZ10")
IE.Document.GetElementByID("QBCFhUL0DsI-mdH8pnWvjf3-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("jWXNXtGEGKn-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OA10")
IE.Document.GetElementByID("jWXNXtGEGKn-M5tkYhf3wH0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("QBCFhUL0DsI-M5tkYhf3wH0-val").Focus
IE.Document.GetElementByID("QBCFhUL0DsI-M5tkYhf3wH0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OA10")
IE.Document.GetElementByID("QBCFhUL0DsI-M5tkYhf3wH0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,<15
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("jWXNXtGEGKn-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("OB10")
IE.Document.GetElementByID("jWXNXtGEGKn-EinRX4vGJHS-val").dispatchEvent evt
Else
IE.Document.GetElementByID("QBCFhUL0DsI-EinRX4vGJHS-val").Focus
IE.Document.GetElementByID("QBCFhUL0DsI-EinRX4vGJHS-val").Value = ThisWorkbook.Sheets("sheet1").Range("OB10")
IE.Document.GetElementByID("QBCFhUL0DsI-EinRX4vGJHS-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jWXNXtGEGKn-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("jWXNXtGEGKn-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("OC10")
IE.Document.GetElementByID("jWXNXtGEGKn-rtt53W8KwRV-val").dispatchEvent evt
Else
IE.Document.GetElementByID("QBCFhUL0DsI-rtt53W8KwRV-val").Focus
IE.Document.GetElementByID("QBCFhUL0DsI-rtt53W8KwRV-val").Value = ThisWorkbook.Sheets("sheet1").Range("OC10")
IE.Document.GetElementByID("QBCFhUL0DsI-rtt53W8KwRV-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
'End TX_TB
End Sub

'     GGGGGGG    EEEEEEEEEEE NNNN   NNNN  DDDDDDDDD            GGGGGGG    BBBBBBBBBB BBVVV    VVVV  
'   GGGGGGGGGG   EEEEEEEEEEE NNNNN  NNNN  DDDDDDDDDD         GGGGGGGGGG   BBBBBBBBBBB BVVV    VVVV  
'  GGGGGGGGGGGG  EEEEEEEEEEE NNNNN  NNNN  DDDDDDDDDDD       GGGGGGGGGGGG  BBBBBBBBBBB BVVV    VVVV  
'  GGGGG  GGGGG  EEEE        NNNNNN NNNN  DDDD   DDDD       GGGGG  GGGGG  BBBB   BBBB BVVVV  VVVV   
' GGGGG    GGG   EEEE        NNNNNN NNNN  DDDD    DDDD      GGGG    GGG   BBBB   BBBB  VVVV  VVVV   
' GGGG           EEEEEEEEEE  NNNNNNNNNNN  DDDD    DDDD      GGG           BBBBBBBBBBB  VVVV  VVVV   
' GGGG  GGGGGGGG EEEEEEEEEE  NNNNNNNNNNN  DDDD    DDDD      GGG  GGGGGGGG BBBBBBBBBB   VVVVVVVVV    
' GGGG  GGGGGGGG EEEEEEEEEE  NNNNNNNNNNN  DDDD    DDDD      GGG  GGGGGGGG BBBBBBBBBBB   VVVVVVVV    
' GGGGG GGGGGGGG EEEE        NNNNNNNNNNN  DDDD    DDDD      GGGG GGGGGGGG BBBB    BBBB  VVVVVVVV    
'  GGGGG    GGGG EEEE        NNNN NNNNNN  DDDD   DDDDD      GGGGG    GGGG BBBB    BBBB  VVVVVVV     
'  GGGGGGGGGGGG  EEEEEEEEEEE NNNN  NNNNN  DDDDDDDDDDD       GGGGGGGGGGGG  BBBBBBBBBBBB   VVVVVV     
'   GGGGGGGGGG   EEEEEEEEEEE NNNN  NNNNN  DDDDDDDDDD         GGGGGGGGGG   BBBBBBBBBBB    VVVVVV     
'     GGGGGGG    EEEEEEEEEEE NNNN   NNNN  DDDDDDDDD            GGGGGGG    BBBBBBBBBB     VVVVV      
'GEND_GBV
Sub GEND_GBV()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-2").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-7").Click
Else
IE.Document.GetElementByID("ui-id-8").Click
End If
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OD10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pWTXzF2L8lG-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("pWTXzF2L8lG-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OD10")
IE.Document.GetElementByID("pWTXzF2L8lG-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("sIagQEZjSyy-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("sIagQEZjSyy-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("OD10")
IE.Document.GetElementByID("sIagQEZjSyy-HllvX50cXC0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Sexual Violence
'Female,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-QdyvOZhmwfP-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-QdyvOZhmwfP-val").Value = ThisWorkbook.Sheets("sheet1").Range("OE10")
IE.Document.GetElementByID("GT81rJIJrrd-QdyvOZhmwfP-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-QdyvOZhmwfP-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-QdyvOZhmwfP-val").Value = ThisWorkbook.Sheets("sheet1").Range("OE10")
IE.Document.GetElementByID("pKH3YTAShEe-QdyvOZhmwfP-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-O8VSbT4lhbG-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-O8VSbT4lhbG-val").Value = ThisWorkbook.Sheets("sheet1").Range("OF10")
IE.Document.GetElementByID("GT81rJIJrrd-O8VSbT4lhbG-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-O8VSbT4lhbG-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-O8VSbT4lhbG-val").Value = ThisWorkbook.Sheets("sheet1").Range("OF10")
IE.Document.GetElementByID("pKH3YTAShEe-O8VSbT4lhbG-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-lQfjasPsxs3-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-lQfjasPsxs3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OG10")
IE.Document.GetElementByID("GT81rJIJrrd-lQfjasPsxs3-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-lQfjasPsxs3-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-lQfjasPsxs3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OG10")
IE.Document.GetElementByID("pKH3YTAShEe-lQfjasPsxs3-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-Oz9mfDvGh0n-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-Oz9mfDvGh0n-val").Value = ThisWorkbook.Sheets("sheet1").Range("OH10")
IE.Document.GetElementByID("GT81rJIJrrd-Oz9mfDvGh0n-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-Oz9mfDvGh0n-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-Oz9mfDvGh0n-val").Value = ThisWorkbook.Sheets("sheet1").Range("OH10")
IE.Document.GetElementByID("pKH3YTAShEe-Oz9mfDvGh0n-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-GmlEpQlBZJN-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-GmlEpQlBZJN-val").Value = ThisWorkbook.Sheets("sheet1").Range("OI10")
IE.Document.GetElementByID("GT81rJIJrrd-GmlEpQlBZJN-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-GmlEpQlBZJN-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-GmlEpQlBZJN-val").Value = ThisWorkbook.Sheets("sheet1").Range("OI10")
IE.Document.GetElementByID("pKH3YTAShEe-GmlEpQlBZJN-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-O6L8gP01Z7E-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-O6L8gP01Z7E-val").Value = ThisWorkbook.Sheets("sheet1").Range("OJ10")
IE.Document.GetElementByID("GT81rJIJrrd-O6L8gP01Z7E-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-O6L8gP01Z7E-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-O6L8gP01Z7E-val").Value = ThisWorkbook.Sheets("sheet1").Range("OJ10")
IE.Document.GetElementByID("pKH3YTAShEe-O6L8gP01Z7E-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-RRU8Xbcw6m2-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-RRU8Xbcw6m2-val").Value = ThisWorkbook.Sheets("sheet1").Range("OK10")
IE.Document.GetElementByID("GT81rJIJrrd-RRU8Xbcw6m2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-RRU8Xbcw6m2-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-RRU8Xbcw6m2-val").Value = ThisWorkbook.Sheets("sheet1").Range("OK10")
IE.Document.GetElementByID("pKH3YTAShEe-RRU8Xbcw6m2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-nW1xLOwJNQ3-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-nW1xLOwJNQ3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OL10")
IE.Document.GetElementByID("GT81rJIJrrd-nW1xLOwJNQ3-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-nW1xLOwJNQ3-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-nW1xLOwJNQ3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OL10")
IE.Document.GetElementByID("pKH3YTAShEe-nW1xLOwJNQ3-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-EMPdzS9xUZs-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-EMPdzS9xUZs-val").Value = ThisWorkbook.Sheets("sheet1").Range("OM10")
IE.Document.GetElementByID("GT81rJIJrrd-EMPdzS9xUZs-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-EMPdzS9xUZs-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-EMPdzS9xUZs-val").Value = ThisWorkbook.Sheets("sheet1").Range("OM10")
IE.Document.GetElementByID("pKH3YTAShEe-EMPdzS9xUZs-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-qRPbwt7xN8N-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-qRPbwt7xN8N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ON10")
IE.Document.GetElementByID("GT81rJIJrrd-qRPbwt7xN8N-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-qRPbwt7xN8N-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-qRPbwt7xN8N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ON10")
IE.Document.GetElementByID("pKH3YTAShEe-qRPbwt7xN8N-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-dWU2Qc1DBTx-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-dWU2Qc1DBTx-val").Value = ThisWorkbook.Sheets("sheet1").Range("OO10")
IE.Document.GetElementByID("GT81rJIJrrd-dWU2Qc1DBTx-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-dWU2Qc1DBTx-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-dWU2Qc1DBTx-val").Value = ThisWorkbook.Sheets("sheet1").Range("OO10")
IE.Document.GetElementByID("pKH3YTAShEe-dWU2Qc1DBTx-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-zh1RfnjU3nw-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-zh1RfnjU3nw-val").Value = ThisWorkbook.Sheets("sheet1").Range("OP10")
IE.Document.GetElementByID("GT81rJIJrrd-zh1RfnjU3nw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-zh1RfnjU3nw-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-zh1RfnjU3nw-val").Value = ThisWorkbook.Sheets("sheet1").Range("OP10")
IE.Document.GetElementByID("pKH3YTAShEe-zh1RfnjU3nw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-EaFoYeVKtl1-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-EaFoYeVKtl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("OQ10")
IE.Document.GetElementByID("GT81rJIJrrd-EaFoYeVKtl1-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-EaFoYeVKtl1-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-EaFoYeVKtl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("OQ10")
IE.Document.GetElementByID("pKH3YTAShEe-EaFoYeVKtl1-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-eph8upo4KnI-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-eph8upo4KnI-val").Value = ThisWorkbook.Sheets("sheet1").Range("OR10")
IE.Document.GetElementByID("GT81rJIJrrd-eph8upo4KnI-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-eph8upo4KnI-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-eph8upo4KnI-val").Value = ThisWorkbook.Sheets("sheet1").Range("OR10")
IE.Document.GetElementByID("pKH3YTAShEe-eph8upo4KnI-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-kTLb3E6uG8m-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-kTLb3E6uG8m-val").Value = ThisWorkbook.Sheets("sheet1").Range("OS10")
IE.Document.GetElementByID("GT81rJIJrrd-kTLb3E6uG8m-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-kTLb3E6uG8m-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-kTLb3E6uG8m-val").Value = ThisWorkbook.Sheets("sheet1").Range("OS10")
IE.Document.GetElementByID("pKH3YTAShEe-kTLb3E6uG8m-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-njzg2pswvAa-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-njzg2pswvAa-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
IE.Document.GetElementByID("GT81rJIJrrd-njzg2pswvAa-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-njzg2pswvAa-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-njzg2pswvAa-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
IE.Document.GetElementByID("pKH3YTAShEe-njzg2pswvAa-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-l0fUVaWXRTe-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-l0fUVaWXRTe-val").Value = ThisWorkbook.Sheets("sheet1").Range("OU10")
IE.Document.GetElementByID("GT81rJIJrrd-l0fUVaWXRTe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-l0fUVaWXRTe-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-l0fUVaWXRTe-val").Value = ThisWorkbook.Sheets("sheet1").Range("OU10")
IE.Document.GetElementByID("pKH3YTAShEe-l0fUVaWXRTe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-sIES2ww1feR-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-sIES2ww1feR-val").Value = ThisWorkbook.Sheets("sheet1").Range("OV10")
IE.Document.GetElementByID("GT81rJIJrrd-sIES2ww1feR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-sIES2ww1feR-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-sIES2ww1feR-val").Value = ThisWorkbook.Sheets("sheet1").Range("OV10")
IE.Document.GetElementByID("pKH3YTAShEe-sIES2ww1feR-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Physical and / or Emotional Violence
'Female,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-wt4A4IVhK44-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-wt4A4IVhK44-val").Value = ThisWorkbook.Sheets("sheet1").Range("OW10")
IE.Document.GetElementByID("GT81rJIJrrd-wt4A4IVhK44-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-wt4A4IVhK44-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-wt4A4IVhK44-val").Value = ThisWorkbook.Sheets("sheet1").Range("OW10")
IE.Document.GetElementByID("pKH3YTAShEe-wt4A4IVhK44-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-GGtPtwWGpuU-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-GGtPtwWGpuU-val").Value = ThisWorkbook.Sheets("sheet1").Range("OX10")
IE.Document.GetElementByID("GT81rJIJrrd-GGtPtwWGpuU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-GGtPtwWGpuU-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-GGtPtwWGpuU-val").Value = ThisWorkbook.Sheets("sheet1").Range("OX10")
IE.Document.GetElementByID("pKH3YTAShEe-GGtPtwWGpuU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-Cec3GHF5VQZ-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-Cec3GHF5VQZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OY10")
IE.Document.GetElementByID("GT81rJIJrrd-Cec3GHF5VQZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-Cec3GHF5VQZ-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-Cec3GHF5VQZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OY10")
IE.Document.GetElementByID("pKH3YTAShEe-Cec3GHF5VQZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-UwV8YVOEVl3-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-UwV8YVOEVl3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OZ10")
IE.Document.GetElementByID("GT81rJIJrrd-UwV8YVOEVl3-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-UwV8YVOEVl3-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-UwV8YVOEVl3-val").Value = ThisWorkbook.Sheets("sheet1").Range("OZ10")
IE.Document.GetElementByID("pKH3YTAShEe-UwV8YVOEVl3-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-NwrTfkWdED1-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-NwrTfkWdED1-val").Value = ThisWorkbook.Sheets("sheet1").Range("PA10")
IE.Document.GetElementByID("GT81rJIJrrd-NwrTfkWdED1-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-NwrTfkWdED1-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-NwrTfkWdED1-val").Value = ThisWorkbook.Sheets("sheet1").Range("PA10")
IE.Document.GetElementByID("pKH3YTAShEe-NwrTfkWdED1-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-AH6J0MDYMZ0-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-AH6J0MDYMZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("PB10")
IE.Document.GetElementByID("GT81rJIJrrd-AH6J0MDYMZ0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-AH6J0MDYMZ0-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-AH6J0MDYMZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("PB10")
IE.Document.GetElementByID("pKH3YTAShEe-AH6J0MDYMZ0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-wVVtzmD5xsT-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-wVVtzmD5xsT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PC10")
IE.Document.GetElementByID("GT81rJIJrrd-wVVtzmD5xsT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-wVVtzmD5xsT-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-wVVtzmD5xsT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PC10")
IE.Document.GetElementByID("pKH3YTAShEe-wVVtzmD5xsT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-HUNtR6x2i93-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-HUNtR6x2i93-val").Value = ThisWorkbook.Sheets("sheet1").Range("PD10")
IE.Document.GetElementByID("GT81rJIJrrd-HUNtR6x2i93-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-HUNtR6x2i93-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-HUNtR6x2i93-val").Value = ThisWorkbook.Sheets("sheet1").Range("PD10")
IE.Document.GetElementByID("pKH3YTAShEe-HUNtR6x2i93-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-AGV475enDdO-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-AGV475enDdO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PE10")
IE.Document.GetElementByID("GT81rJIJrrd-AGV475enDdO-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-AGV475enDdO-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-AGV475enDdO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PE10")
IE.Document.GetElementByID("pKH3YTAShEe-AGV475enDdO-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-ClVqXFbwu7z-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-ClVqXFbwu7z-val").Value = ThisWorkbook.Sheets("sheet1").Range("PF10")
IE.Document.GetElementByID("GT81rJIJrrd-ClVqXFbwu7z-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-ClVqXFbwu7z-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-ClVqXFbwu7z-val").Value = ThisWorkbook.Sheets("sheet1").Range("PF10")
IE.Document.GetElementByID("pKH3YTAShEe-ClVqXFbwu7z-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-YsGSdOrSGvO-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-YsGSdOrSGvO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PG10")
IE.Document.GetElementByID("GT81rJIJrrd-YsGSdOrSGvO-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-YsGSdOrSGvO-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-YsGSdOrSGvO-val").Value = ThisWorkbook.Sheets("sheet1").Range("PG10")
IE.Document.GetElementByID("pKH3YTAShEe-YsGSdOrSGvO-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-qS6AUbNJKE8-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-qS6AUbNJKE8-val").Value = ThisWorkbook.Sheets("sheet1").Range("PH10")
IE.Document.GetElementByID("GT81rJIJrrd-qS6AUbNJKE8-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-qS6AUbNJKE8-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-qS6AUbNJKE8-val").Value = ThisWorkbook.Sheets("sheet1").Range("PH10")
IE.Document.GetElementByID("pKH3YTAShEe-qS6AUbNJKE8-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-pA604NbnktK-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-pA604NbnktK-val").Value = ThisWorkbook.Sheets("sheet1").Range("PI10")
IE.Document.GetElementByID("GT81rJIJrrd-pA604NbnktK-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-pA604NbnktK-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-pA604NbnktK-val").Value = ThisWorkbook.Sheets("sheet1").Range("PI10")
IE.Document.GetElementByID("pKH3YTAShEe-pA604NbnktK-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-EUViVSqSaSx-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-EUViVSqSaSx-val").Value = ThisWorkbook.Sheets("sheet1").Range("PJ10")
IE.Document.GetElementByID("GT81rJIJrrd-EUViVSqSaSx-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-EUViVSqSaSx-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-EUViVSqSaSx-val").Value = ThisWorkbook.Sheets("sheet1").Range("PJ10")
IE.Document.GetElementByID("pKH3YTAShEe-EUViVSqSaSx-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-KUP9oCrnXLm-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-KUP9oCrnXLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("PK10")
IE.Document.GetElementByID("GT81rJIJrrd-KUP9oCrnXLm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-KUP9oCrnXLm-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-KUP9oCrnXLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("PK10")
IE.Document.GetElementByID("pKH3YTAShEe-KUP9oCrnXLm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-VPXUnkqLbb4-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-VPXUnkqLbb4-val").Value = ThisWorkbook.Sheets("sheet1").Range("PL10")
IE.Document.GetElementByID("GT81rJIJrrd-VPXUnkqLbb4-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-VPXUnkqLbb4-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-VPXUnkqLbb4-val").Value = ThisWorkbook.Sheets("sheet1").Range("PL10")
IE.Document.GetElementByID("pKH3YTAShEe-VPXUnkqLbb4-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-iam0H1wLzgw-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-iam0H1wLzgw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PM10")
IE.Document.GetElementByID("GT81rJIJrrd-iam0H1wLzgw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-iam0H1wLzgw-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-iam0H1wLzgw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PM10")
IE.Document.GetElementByID("pKH3YTAShEe-iam0H1wLzgw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("GT81rJIJrrd-v5rsJlwfzWD-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-v5rsJlwfzWD-val").Value = ThisWorkbook.Sheets("sheet1").Range("PN10")
IE.Document.GetElementByID("GT81rJIJrrd-v5rsJlwfzWD-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pKH3YTAShEe-v5rsJlwfzWD-val").Focus
IE.Document.GetElementByID("pKH3YTAShEe-v5rsJlwfzWD-val").Value = ThisWorkbook.Sheets("sheet1").Range("PN10")
IE.Document.GetElementByID("pKH3YTAShEe-v5rsJlwfzWD-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'PEP
'Female,<10
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-m0cv4FpuKcT-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-m0cv4FpuKcT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PO10")
IE.Document.GetElementByID("owIr2CJUbwq-m0cv4FpuKcT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-m0cv4FpuKcT-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-m0cv4FpuKcT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PO10")
IE.Document.GetElementByID("OZ9CHCMYJMS-m0cv4FpuKcT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-WZA61w3X97V-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-WZA61w3X97V-val").Value = ThisWorkbook.Sheets("sheet1").Range("PP10")
IE.Document.GetElementByID("owIr2CJUbwq-WZA61w3X97V-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-WZA61w3X97V-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-WZA61w3X97V-val").Value = ThisWorkbook.Sheets("sheet1").Range("PP10")
IE.Document.GetElementByID("OZ9CHCMYJMS-WZA61w3X97V-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-n3LvtfmkEfp-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-n3LvtfmkEfp-val").Value = ThisWorkbook.Sheets("sheet1").Range("PQ10")
IE.Document.GetElementByID("owIr2CJUbwq-n3LvtfmkEfp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-n3LvtfmkEfp-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-n3LvtfmkEfp-val").Value = ThisWorkbook.Sheets("sheet1").Range("PQ10")
IE.Document.GetElementByID("OZ9CHCMYJMS-n3LvtfmkEfp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-mfOtkXnJkEw-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-mfOtkXnJkEw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PR10")
IE.Document.GetElementByID("owIr2CJUbwq-mfOtkXnJkEw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-mfOtkXnJkEw-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-mfOtkXnJkEw-val").Value = ThisWorkbook.Sheets("sheet1").Range("PR10")
IE.Document.GetElementByID("OZ9CHCMYJMS-mfOtkXnJkEw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-Tvu2J5Nr7JF-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-Tvu2J5Nr7JF-val").Value = ThisWorkbook.Sheets("sheet1").Range("PS10")
IE.Document.GetElementByID("owIr2CJUbwq-Tvu2J5Nr7JF-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-Tvu2J5Nr7JF-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-Tvu2J5Nr7JF-val").Value = ThisWorkbook.Sheets("sheet1").Range("PS10")
IE.Document.GetElementByID("OZ9CHCMYJMS-Tvu2J5Nr7JF-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-WJKtglKn0DE-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-WJKtglKn0DE-val").Value = ThisWorkbook.Sheets("sheet1").Range("PT10")
IE.Document.GetElementByID("owIr2CJUbwq-WJKtglKn0DE-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-WJKtglKn0DE-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-WJKtglKn0DE-val").Value = ThisWorkbook.Sheets("sheet1").Range("PT10")
IE.Document.GetElementByID("OZ9CHCMYJMS-WJKtglKn0DE-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-YjCsCWpQVob-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-YjCsCWpQVob-val").Value = ThisWorkbook.Sheets("sheet1").Range("PU10")
IE.Document.GetElementByID("owIr2CJUbwq-YjCsCWpQVob-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-YjCsCWpQVob-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-YjCsCWpQVob-val").Value = ThisWorkbook.Sheets("sheet1").Range("PU10")
IE.Document.GetElementByID("OZ9CHCMYJMS-YjCsCWpQVob-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-MytUkuWfSju-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-MytUkuWfSju-val").Value = ThisWorkbook.Sheets("sheet1").Range("PV10")
IE.Document.GetElementByID("owIr2CJUbwq-MytUkuWfSju-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-MytUkuWfSju-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-MytUkuWfSju-val").Value = ThisWorkbook.Sheets("sheet1").Range("PV10")
IE.Document.GetElementByID("OZ9CHCMYJMS-MytUkuWfSju-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("owIr2CJUbwq-hiHSrG29erB-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-hiHSrG29erB-val").Value = ThisWorkbook.Sheets("sheet1").Range("PW10")
IE.Document.GetElementByID("owIr2CJUbwq-hiHSrG29erB-val").dispatchEvent evt
Else
IE.Document.GetElementByID("OZ9CHCMYJMS-hiHSrG29erB-val").Focus
IE.Document.GetElementByID("OZ9CHCMYJMS-hiHSrG29erB-val").Value = ThisWorkbook.Sheets("sheet1").Range("PW10")
IE.Document.GetElementByID("OZ9CHCMYJMS-hiHSrG29erB-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' FFFFFFFFFF PPPPPPPPP  PPIII INNN   NNNN  NTTTTTTTTTT      SSSSSSS   SSIII ITTTTTTTTTTEEEEEEEEEEE  
' FFFFFFFFFF PPPPPPPPPP PPIII INNNN  NNNN  NTTTTTTTTTT     SSSSSSSSS  SSIII ITTTTTTTTTTEEEEEEEEEEE  
' FFFFFFFFFF PPPPPPPPPPPPPIII INNNN  NNNN  NTTTTTTTTTT     SSSSSSSSSS SSIII ITTTTTTTTTTEEEEEEEEEEE  
' FFFF       PPPP   PPPPPPIII INNNNN NNNN     TTTT         SSSS  SSSS SSIII    TTTT    EEEE         
' FFFF       PPPP   PPPPPPIII INNNNN NNNN     TTTT         SSSS       SSIII    TTTT    EEEE         
' FFFFFFFFF  PPPPPPPPPPPPPIII INNNNNNNNNN     TTTT         SSSSSSS    SSIII    TTTT    EEEEEEEEEE   
' FFFFFFFFF  PPPPPPPPPP PPIII INNNNNNNNNN     TTTT          SSSSSSSSS SSIII    TTTT    EEEEEEEEEE   
' FFFFFFFFF  PPPPPPPPP  PPIII INNNNNNNNNN     TTTT            SSSSSSS SSIII    TTTT    EEEEEEEEEE   
' FFFF       PPPP       PPIII INNNNNNNNNN     TTTT               SSSSSSSIII    TTTT    EEEE         
' FFFF       PPPP       PPIII INNN NNNNNN     TTTT         SSS    SSSSSSIII    TTTT    EEEE         
' FFFF       PPPP       PPIII INNN  NNNNN     TTTT         SSSSSSSSSSSSSIII    TTTT    EEEEEEEEEEE  
' FFFF       PPPP       PPIII INNN  NNNNN     TTTT         SSSSSSSSSS SSIII    TTTT    EEEEEEEEEEE  
' FFFF       PPPP       PPIII INNN   NNNN     TTTT          SSSSSSSS  SSIII    TTTT    EEEEEEEEEEE  
'FPINT_SITE
Sub FPINT_SITE()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-9").Click
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("QG10")) Then
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").Value = ThisWorkbook.Sheets("sheet1").Range("QG10")
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").Value = ThisWorkbook.Sheets("sheet1").Range("QH10")
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").Value = ThisWorkbook.Sheets("sheet1").Range("QI10")
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").Value = ThisWorkbook.Sheets("sheet1").Range("QJ10")
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").Value = ThisWorkbook.Sheets("sheet1").Range("QK10")
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' TTTTTTTTTTTXXXX  XXXXX       RRRRRRRRR   REEEEEEEEEE ETTTTTTTTT  
' TTTTTTTTTTTXXXX  XXXX        RRRRRRRRRR  REEEEEEEEEE ETTTTTTTTT  
' TTTTTTTTTTTXXXXXXXXXX        RRRRRRRRRR  REEEEEEEEEE ETTTTTTTTT  
'    TTTT     XXXXXXXX         RRR   RRRRR REEE           TTTT     
'    TTTT      XXXXXX          RRR   RRRRR REEE           TTTT     
'    TTTT      XXXXXX          RRRRRRRRRR  REEEEEEEEE     TTTT     
'    TTTT      XXXXX           RRRRRRRRRR  REEEEEEEEE     TTTT     
'    TTTT      XXXXXX          RRRRRRR     REEEEEEEEE     TTTT     
'    TTTT     XXXXXXXX         RRR RRRR    REEE           TTTT     
'    TTTT     XXXXXXXX         RRR  RRRR   REEE           TTTT     
'    TTTT    XXXX XXXXX        RRR  RRRRR  REEEEEEEEEE    TTTT     
'    TTTT   TXXXX  XXXXX       RRR   RRRRR REEEEEEEEEE    TTTT     
'    TTTT   TXXX    XXXX       RRR    RRRR REEEEEEEEEE    TTTT     
'TX_RET
Sub TX_RET()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-5").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-14").Click
Else
IE.Document.GetElementByID("ui-id-15").Click
End If
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("QL10")) Then
'Numerator
'12 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KLHpJzK1SLy-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("KLHpJzK1SLy-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QL10")
IE.Document.GetElementByID("KLHpJzK1SLy-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ZOU9pal2R3w-LVcCRCAVjwj").Focus
IE.Document.GetElementByID("ZOU9pal2R3w-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QL10")
IE.Document.GetElementByID("ZOU9pal2R3w-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'24 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("Pxf0TEEIZFl-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("Pxf0TEEIZFl-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QM10")
IE.Document.GetElementByID("Pxf0TEEIZFl-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("KWmsoOySlvp-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("KWmsoOySlvp-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QM10")
IE.Document.GetElementByID("KWmsoOySlvp-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'36 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("BnlDGvdjpYH-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("BnlDGvdjpYH-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QN10")
IE.Document.GetElementByID("BnlDGvdjpYH-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("bOnCafw9zhe-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("bOnCafw9zhe-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("QN10")
IE.Document.GetElementByID("bOnCafw9zhe-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9MO0VAFjar-vxBSF1mguas-val").Focus
IE.Document.GetElementByID("I9MO0VAFjar-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("QO10")
IE.Document.GetElementByID("I9MO0VAFjar-vxBSF1mguas-val").dispatchEvent evt
Else
IE.Document.GetElementByID("HdRYfCJUfsc-vxBSF1mguas-val").Focus
IE.Document.GetElementByID("HdRYfCJUfsc-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("QO10")
IE.Document.GetElementByID("HdRYfCJUfsc-vxBSF1mguas-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("I9MO0VAFjar-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("I9MO0VAFjar-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("QP10")
IE.Document.GetElementByID("I9MO0VAFjar-jaxEUorPKgv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("HdRYfCJUfsc-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("HdRYfCJUfsc-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("QP10")
IE.Document.GetElementByID("HdRYfCJUfsc-jaxEUorPKgv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("QQ10")
IE.Document.GetElementByID("MOtGVQLwYmA-fYknd2lPzAm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("QQ10")
IE.Document.GetElementByID("gmR0FxXhLyl-fYknd2lPzAm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("QR10")
IE.Document.GetElementByID("MOtGVQLwYmA-CtnbWoya5d5-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("QR10")
IE.Document.GetElementByID("gmR0FxXhLyl-CtnbWoya5d5-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("QS10")
IE.Document.GetElementByID("MOtGVQLwYmA-J7mbG9jKSpr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("QS10")
IE.Document.GetElementByID("gmR0FxXhLyl-J7mbG9jKSpr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("QT10")
IE.Document.GetElementByID("MOtGVQLwYmA-Ek2cTSEcl3p-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("QT10")
IE.Document.GetElementByID("gmR0FxXhLyl-Ek2cTSEcl3p-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("QU10")
IE.Document.GetElementByID("MOtGVQLwYmA-zpiyTuKQQ2e-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("QU10")
IE.Document.GetElementByID("gmR0FxXhLyl-zpiyTuKQQ2e-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("QV10")
IE.Document.GetElementByID("MOtGVQLwYmA-RED4BPdFO11-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("QV10")
IE.Document.GetElementByID("gmR0FxXhLyl-RED4BPdFO11-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("QW10")
IE.Document.GetElementByID("MOtGVQLwYmA-LljzDYxQ1Ga-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("QW10")
IE.Document.GetElementByID("gmR0FxXhLyl-LljzDYxQ1Ga-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("QX10")
IE.Document.GetElementByID("MOtGVQLwYmA-TEgIyIVs5JA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("QX10")
IE.Document.GetElementByID("gmR0FxXhLyl-TEgIyIVs5JA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("QY10")
IE.Document.GetElementByID("MOtGVQLwYmA-F0cTl1AAJxz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("QY10")
IE.Document.GetElementByID("gmR0FxXhLyl-F0cTl1AAJxz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("QZ10")
IE.Document.GetElementByID("MOtGVQLwYmA-lA60kBSujWH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("QZ10")
IE.Document.GetElementByID("gmR0FxXhLyl-lA60kBSujWH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RA10")
IE.Document.GetElementByID("MOtGVQLwYmA-S4urVfq4oVX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RA10")
IE.Document.GetElementByID("gmR0FxXhLyl-S4urVfq4oVX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RB10")
IE.Document.GetElementByID("MOtGVQLwYmA-h5FQFklI9Vn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RB10")
IE.Document.GetElementByID("gmR0FxXhLyl-h5FQFklI9Vn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RC10")
IE.Document.GetElementByID("MOtGVQLwYmA-QNulEjcSLQT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RC10")
IE.Document.GetElementByID("gmR0FxXhLyl-QNulEjcSLQT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("RD10")
IE.Document.GetElementByID("MOtGVQLwYmA-iIZEtL6l6Hb-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("RD10")
IE.Document.GetElementByID("gmR0FxXhLyl-iIZEtL6l6Hb-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("RE10")
IE.Document.GetElementByID("MOtGVQLwYmA-aQHB69TmOWe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("RE10")
IE.Document.GetElementByID("gmR0FxXhLyl-aQHB69TmOWe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RF10")
IE.Document.GetElementByID("MOtGVQLwYmA-T9kxtfDL0pn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RF10")
IE.Document.GetElementByID("gmR0FxXhLyl-T9kxtfDL0pn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-cci2MH041nc-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("RG10")
IE.Document.GetElementByID("MOtGVQLwYmA-cci2MH041nc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-cci2MH041nc-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("RG10")
IE.Document.GetElementByID("gmR0FxXhLyl-cci2MH041nc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("MOtGVQLwYmA-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("MOtGVQLwYmA-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("RH10")
IE.Document.GetElementByID("MOtGVQLwYmA-rPO0WWEbKzL-val").dispatchEvent evt
Else
IE.Document.GetElementByID("gmR0FxXhLyl-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("gmR0FxXhLyl-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("RH10")
IE.Document.GetElementByID("gmR0FxXhLyl-rPO0WWEbKzL-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
Application.Wait Now + TimeValue("00:00:01")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("RI10")) Then
'Denominator
'12 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("VX3vV0hBeLy-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("VX3vV0hBeLy-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RI10")
IE.Document.GetElementByID("VX3vV0hBeLy-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("SmaMR3maQMj-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("SmaMR3maQMj-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RI10")
IE.Document.GetElementByID("SmaMR3maQMj-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'24 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("LRovH4RfPxL-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("LRovH4RfPxL-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RJ10")
IE.Document.GetElementByID("LRovH4RfPxL-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("BWkdrGCoKhQ-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("BWkdrGCoKhQ-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RJ10")
IE.Document.GetElementByID("BWkdrGCoKhQ-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'36 months
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("pnXn5yTXLvG-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("pnXn5yTXLvG-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RK10")
IE.Document.GetElementByID("pnXn5yTXLvG-LVcCRCAVjwj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("X2m1PXxPAQe-LVcCRCAVjwj-val").Focus
IE.Document.GetElementByID("X2m1PXxPAQe-LVcCRCAVjwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RK10")
IE.Document.GetElementByID("X2m1PXxPAQe-LVcCRCAVjwj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("aal61UVcc5M-vxBSF1mguas-val").Focus
IE.Document.GetElementByID("aal61UVcc5M-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("RL10")
IE.Document.GetElementByID("aal61UVcc5M-vxBSF1mguas-val").dispatchEvent evt
Else
IE.Document.GetElementByID("UGj6ot4NTm7-vxBSF1mguas-val").Focus
IE.Document.GetElementByID("UGj6ot4NTm7-vxBSF1mguas-val").Value = ThisWorkbook.Sheets("sheet1").Range("RL10")
IE.Document.GetElementByID("UGj6ot4NTm7-vxBSF1mguas-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("aal61UVcc5M-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("aal61UVcc5M-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("RM10")
IE.Document.GetElementByID("aal61UVcc5M-jaxEUorPKgv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("UGj6ot4NTm7-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("UGj6ot4NTm7-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("RM10")
IE.Document.GetElementByID("UGj6ot4NTm7-jaxEUorPKgv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("RN10")
IE.Document.GetElementByID("g6VQiVnU01o-fYknd2lPzAm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-fYknd2lPzAm-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-fYknd2lPzAm-val").Value = ThisWorkbook.Sheets("sheet1").Range("RN10")
IE.Document.GetElementByID("ASBT43khvwp-fYknd2lPzAm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RO10")
IE.Document.GetElementByID("g6VQiVnU01o-CtnbWoya5d5-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-CtnbWoya5d5-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-CtnbWoya5d5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RO10")
IE.Document.GetElementByID("ASBT43khvwp-CtnbWoya5d5-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("RP10")
IE.Document.GetElementByID("g6VQiVnU01o-J7mbG9jKSpr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-J7mbG9jKSpr-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-J7mbG9jKSpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("RP10")
IE.Document.GetElementByID("ASBT43khvwp-J7mbG9jKSpr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("RQ10")
IE.Document.GetElementByID("g6VQiVnU01o-Ek2cTSEcl3p-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-Ek2cTSEcl3p-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-Ek2cTSEcl3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("RQ10")
IE.Document.GetElementByID("ASBT43khvwp-Ek2cTSEcl3p-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("RR10")
IE.Document.GetElementByID("g6VQiVnU01o-zpiyTuKQQ2e-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-zpiyTuKQQ2e-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-zpiyTuKQQ2e-val").Value = ThisWorkbook.Sheets("sheet1").Range("RR10")
IE.Document.GetElementByID("ASBT43khvwp-zpiyTuKQQ2e-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("RS10")
IE.Document.GetElementByID("g6VQiVnU01o-RED4BPdFO11-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-RED4BPdFO11-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-RED4BPdFO11-val").Value = ThisWorkbook.Sheets("sheet1").Range("RS10")
IE.Document.GetElementByID("ASBT43khvwp-RED4BPdFO11-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("RT10")
IE.Document.GetElementByID("g6VQiVnU01o-LljzDYxQ1Ga-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-LljzDYxQ1Ga-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-LljzDYxQ1Ga-val").Value = ThisWorkbook.Sheets("sheet1").Range("RT10")
IE.Document.GetElementByID("ASBT43khvwp-LljzDYxQ1Ga-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("RU10")
IE.Document.GetElementByID("g6VQiVnU01o-TEgIyIVs5JA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-TEgIyIVs5JA-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-TEgIyIVs5JA-val").Value = ThisWorkbook.Sheets("sheet1").Range("RU10")
IE.Document.GetElementByID("ASBT43khvwp-TEgIyIVs5JA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("RV10")
IE.Document.GetElementByID("g6VQiVnU01o-F0cTl1AAJxz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-F0cTl1AAJxz-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-F0cTl1AAJxz-val").Value = ThisWorkbook.Sheets("sheet1").Range("RV10")
IE.Document.GetElementByID("ASBT43khvwp-F0cTl1AAJxz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("RW10")
IE.Document.GetElementByID("g6VQiVnU01o-lA60kBSujWH-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-lA60kBSujWH-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-lA60kBSujWH-val").Value = ThisWorkbook.Sheets("sheet1").Range("RW10")
IE.Document.GetElementByID("ASBT43khvwp-lA60kBSujWH-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RX10")
IE.Document.GetElementByID("g6VQiVnU01o-S4urVfq4oVX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-S4urVfq4oVX-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-S4urVfq4oVX-val").Value = ThisWorkbook.Sheets("sheet1").Range("RX10")
IE.Document.GetElementByID("ASBT43khvwp-S4urVfq4oVX-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RY10")
IE.Document.GetElementByID("g6VQiVnU01o-h5FQFklI9Vn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-h5FQFklI9Vn-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-h5FQFklI9Vn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RY10")
IE.Document.GetElementByID("ASBT43khvwp-h5FQFklI9Vn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RZ10")
IE.Document.GetElementByID("g6VQiVnU01o-QNulEjcSLQT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-QNulEjcSLQT-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-QNulEjcSLQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("RZ10")
IE.Document.GetElementByID("ASBT43khvwp-QNulEjcSLQT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SA10")
IE.Document.GetElementByID("g6VQiVnU01o-iIZEtL6l6Hb-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-iIZEtL6l6Hb-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-iIZEtL6l6Hb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SA10")
IE.Document.GetElementByID("ASBT43khvwp-iIZEtL6l6Hb-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("SB10")
IE.Document.GetElementByID("g6VQiVnU01o-aQHB69TmOWe-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-aQHB69TmOWe-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-aQHB69TmOWe-val").Value = ThisWorkbook.Sheets("sheet1").Range("SB10")
IE.Document.GetElementByID("ASBT43khvwp-aQHB69TmOWe-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("SC10")
IE.Document.GetElementByID("g6VQiVnU01o-T9kxtfDL0pn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-T9kxtfDL0pn-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-T9kxtfDL0pn-val").Value = ThisWorkbook.Sheets("sheet1").Range("SC10")
IE.Document.GetElementByID("ASBT43khvwp-T9kxtfDL0pn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,40-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-cci2MH041nc-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("SD10")
IE.Document.GetElementByID("g6VQiVnU01o-cci2MH041nc-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-cci2MH041nc-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-cci2MH041nc-val").Value = ThisWorkbook.Sheets("sheet1").Range("SD10")
IE.Document.GetElementByID("ASBT43khvwp-cci2MH041nc-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("g6VQiVnU01o-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("g6VQiVnU01o-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("SE10")
IE.Document.GetElementByID("g6VQiVnU01o-rPO0WWEbKzL-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ASBT43khvwp-rPO0WWEbKzL-val").Focus
IE.Document.GetElementByID("ASBT43khvwp-rPO0WWEbKzL-val").Value = ThisWorkbook.Sheets("sheet1").Range("SE10")
IE.Document.GetElementByID("ASBT43khvwp-rPO0WWEbKzL-val").dispatchEvent evt
End If
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
'TX_PVLS
Sub TX_PVLS()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Numerator
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("SF10")) Then
'Indication
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YQEFlW4vClz-lrJpKytkH7X-val").Focus
IE.Document.GetElementByID("YQEFlW4vClz-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SF10")
IE.Document.GetElementByID("YQEFlW4vClz-lrJpKytkH7X-val").dispatchEvent evt
Else
IE.Document.GetElementByID("ptcrUFB3k5M-lrJpKytkH7X-val").Focus
IE.Document.GetElementByID("ptcrUFB3k5M-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SF10")
IE.Document.GetElementByID("ptcrUFB3k5M-lrJpKytkH7X-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SG10")
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pICN9lMKMAl-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("pICN9lMKMAl-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SG10")
IE.Document.GetElementByID("pICN9lMKMAl-poFe6w8ZgCs-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SH10")
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").dispatchEvent evt
Else
IE.Document.GetElementByID("pICN9lMKMAl-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("pICN9lMKMAl-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SH10")
IE.Document.GetElementByID("pICN9lMKMAl-k78k8hp9kxN-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-rkwWK8ELyYU-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SI10")
IE.Document.GetElementByID("YvPOllVtINQ-rkwWK8ELyYU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-rkwWK8ELyYU-val").Focus
IE.Document.GetElementByID("MylJht530Cc-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SI10")
IE.Document.GetElementByID("MylJht530Cc-rkwWK8ELyYU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-hHxtViWO56T-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SJ10")
IE.Document.GetElementByID("YvPOllVtINQ-hHxtViWO56T-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-hHxtViWO56T-val").Focus
IE.Document.GetElementByID("MylJht530Cc-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SJ10")
IE.Document.GetElementByID("MylJht530Cc-hHxtViWO56T-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-UGGi61VnaqU-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SK10")
IE.Document.GetElementByID("YvPOllVtINQ-UGGi61VnaqU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-UGGi61VnaqU-val").Focus
IE.Document.GetElementByID("MylJht530Cc-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SK10")
IE.Document.GetElementByID("MylJht530Cc-UGGi61VnaqU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-iXIVm6C4tQq-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SL10")
IE.Document.GetElementByID("YvPOllVtINQ-iXIVm6C4tQq-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-iXIVm6C4tQq-val").Focus
IE.Document.GetElementByID("MylJht530Cc-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SL10")
IE.Document.GetElementByID("MylJht530Cc-iXIVm6C4tQq-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-zuJWcV2btWA-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("SM10")
IE.Document.GetElementByID("YvPOllVtINQ-zuJWcV2btWA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-zuJWcV2btWA-val").Focus
IE.Document.GetElementByID("MylJht530Cc-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("SM10")
IE.Document.GetElementByID("MylJht530Cc-zuJWcV2btWA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-t6R7R9nTSKv-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("SN10")
IE.Document.GetElementByID("YvPOllVtINQ-t6R7R9nTSKv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-t6R7R9nTSKv-val").Focus
IE.Document.GetElementByID("MylJht530Cc-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("SN10")
IE.Document.GetElementByID("MylJht530Cc-t6R7R9nTSKv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-zl1GE91eGuB-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("SO10")
IE.Document.GetElementByID("YvPOllVtINQ-zl1GE91eGuB-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-zl1GE91eGuB-val").Focus
IE.Document.GetElementByID("MylJht530Cc-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("SO10")
IE.Document.GetElementByID("MylJht530Cc-zl1GE91eGuB-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-M0IcDbmPyYm-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SP10")
IE.Document.GetElementByID("YvPOllVtINQ-M0IcDbmPyYm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-M0IcDbmPyYm-val").Focus
IE.Document.GetElementByID("MylJht530Cc-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SP10")
IE.Document.GetElementByID("MylJht530Cc-M0IcDbmPyYm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-oFMd0CIZhzb-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SQ10")
IE.Document.GetElementByID("YvPOllVtINQ-oFMd0CIZhzb-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-oFMd0CIZhzb-val").Focus
IE.Document.GetElementByID("MylJht530Cc-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("SQ10")
IE.Document.GetElementByID("MylJht530Cc-oFMd0CIZhzb-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-pjlv85PehPp-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("SR10")
IE.Document.GetElementByID("YvPOllVtINQ-pjlv85PehPp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-pjlv85PehPp-val").Focus
IE.Document.GetElementByID("MylJht530Cc-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("SR10")
IE.Document.GetElementByID("MylJht530Cc-pjlv85PehPp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-WoCAr4g8sj6-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("SS10")
IE.Document.GetElementByID("YvPOllVtINQ-WoCAr4g8sj6-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-WoCAr4g8sj6-val").Focus
IE.Document.GetElementByID("MylJht530Cc-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("SS10")
IE.Document.GetElementByID("MylJht530Cc-WoCAr4g8sj6-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("YvPOllVtINQ-oyrsEQWocsY-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ST10")
IE.Document.GetElementByID("YvPOllVtINQ-oyrsEQWocsY-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MylJht530Cc-oyrsEQWocsY-val").Focus
IE.Document.GetElementByID("MylJht530Cc-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ST10")
IE.Document.GetElementByID("MylJht530Cc-oyrsEQWocsY-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If

'Denominator
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("SU10")) Then
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("baOWBUVWsx0-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("baOWBUVWsx0-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("SU10")
IE.Document.GetElementByID("baOWBUVWsx0-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("MMWrCwgC4yq-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("MMWrCwgC4yq-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("SU10")
IE.Document.GetElementByID("MMWrCwgC4yq-HllvX50cXC0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Indication
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("NtwSTwGUYzt-lrJpKytkH7X-val").Focus
IE.Document.GetElementByID("NtwSTwGUYzt-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SV10")
IE.Document.GetElementByID("NtwSTwGUYzt-lrJpKytkH7X-val").dispatchEvent evt
Else
IE.Document.GetElementByID("YCJoGPP9akp-lrJpKytkH7X-val").Focus
IE.Document.GetElementByID("YCJoGPP9akp-lrJpKytkH7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("SV10")
IE.Document.GetElementByID("YCJoGPP9akp-lrJpKytkH7X-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Pregnant
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SW10")
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").dispatchEvent evt
Else
IE.Document.GetElementByID("PsGw5Fibj3P-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("PsGw5Fibj3P-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("SW10")
IE.Document.GetElementByID("PsGw5Fibj3P-poFe6w8ZgCs-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Breastfeeding
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SX10")
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").dispatchEvent evt
Else
IE.Document.GetElementByID("PsGw5Fibj3P-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("PsGw5Fibj3P-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("SX10")
IE.Document.GetElementByID("PsGw5Fibj3P-k78k8hp9kxN-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'<1
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-rkwWK8ELyYU-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SY10")
IE.Document.GetElementByID("kznQBykTtJt-rkwWK8ELyYU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-rkwWK8ELyYU-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-rkwWK8ELyYU-val").Value = ThisWorkbook.Sheets("sheet1").Range("SY10")
IE.Document.GetElementByID("alP4jHSfacs-rkwWK8ELyYU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'1-9
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-hHxtViWO56T-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SZ10")
IE.Document.GetElementByID("kznQBykTtJt-hHxtViWO56T-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-hHxtViWO56T-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-hHxtViWO56T-val").Value = ThisWorkbook.Sheets("sheet1").Range("SZ10")
IE.Document.GetElementByID("alP4jHSfacs-hHxtViWO56T-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-UGGi61VnaqU-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("TA10")
IE.Document.GetElementByID("kznQBykTtJt-UGGi61VnaqU-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-UGGi61VnaqU-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-UGGi61VnaqU-val").Value = ThisWorkbook.Sheets("sheet1").Range("TA10")
IE.Document.GetElementByID("alP4jHSfacs-UGGi61VnaqU-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-iXIVm6C4tQq-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("TB10")
IE.Document.GetElementByID("kznQBykTtJt-iXIVm6C4tQq-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-iXIVm6C4tQq-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-iXIVm6C4tQq-val").Value = ThisWorkbook.Sheets("sheet1").Range("TB10")
IE.Document.GetElementByID("alP4jHSfacs-iXIVm6C4tQq-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-zuJWcV2btWA-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("TC10")
IE.Document.GetElementByID("kznQBykTtJt-zuJWcV2btWA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-zuJWcV2btWA-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-zuJWcV2btWA-val").Value = ThisWorkbook.Sheets("sheet1").Range("TC10")
IE.Document.GetElementByID("alP4jHSfacs-zuJWcV2btWA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-t6R7R9nTSKv-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("TD10")
IE.Document.GetElementByID("kznQBykTtJt-t6R7R9nTSKv-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-t6R7R9nTSKv-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-t6R7R9nTSKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("TD10")
IE.Document.GetElementByID("alP4jHSfacs-t6R7R9nTSKv-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Female,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-zl1GE91eGuB-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("TE10")
IE.Document.GetElementByID("kznQBykTtJt-zl1GE91eGuB-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-zl1GE91eGuB-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-zl1GE91eGuB-val").Value = ThisWorkbook.Sheets("sheet1").Range("TE10")
IE.Document.GetElementByID("alP4jHSfacs-zl1GE91eGuB-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,10-14
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-M0IcDbmPyYm-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("TF10")
IE.Document.GetElementByID("kznQBykTtJt-M0IcDbmPyYm-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-M0IcDbmPyYm-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-M0IcDbmPyYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("TF10")
IE.Document.GetElementByID("alP4jHSfacs-M0IcDbmPyYm-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-oFMd0CIZhzb-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("TG10")
IE.Document.GetElementByID("kznQBykTtJt-oFMd0CIZhzb-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-oFMd0CIZhzb-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-oFMd0CIZhzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("TG10")
IE.Document.GetElementByID("alP4jHSfacs-oFMd0CIZhzb-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-pjlv85PehPp-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TH10")
IE.Document.GetElementByID("kznQBykTtJt-pjlv85PehPp-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-pjlv85PehPp-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-pjlv85PehPp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TH10")
IE.Document.GetElementByID("alP4jHSfacs-pjlv85PehPp-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,25-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-WoCAr4g8sj6-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("TI10")
IE.Document.GetElementByID("kznQBykTtJt-WoCAr4g8sj6-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-WoCAr4g8sj6-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-WoCAr4g8sj6-val").Value = ThisWorkbook.Sheets("sheet1").Range("TI10")
IE.Document.GetElementByID("alP4jHSfacs-WoCAr4g8sj6-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Male,50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("kznQBykTtJt-oyrsEQWocsY-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("TJ10")
IE.Document.GetElementByID("kznQBykTtJt-oyrsEQWocsY-val").dispatchEvent evt
Else
IE.Document.GetElementByID("alP4jHSfacs-oyrsEQWocsY-val").Focus
IE.Document.GetElementByID("alP4jHSfacs-oyrsEQWocsY-val").Value = ThisWorkbook.Sheets("sheet1").Range("TJ10")
IE.Document.GetElementByID("alP4jHSfacs-oyrsEQWocsY-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' HHHH   HHHH  RRRRRRRRRR   HHHH   HHHH  
' HHHH   HHHH  RRRRRRRRRRR  HHHH   HHHH  
' HHHH   HHHH  RRRRRRRRRRR  HHHH   HHHH  
' HHHH   HHHH  RRRR   RRRRR HHHH   HHHH  
' HHHH   HHHH  RRRR   RRRRR HHHH   HHHH  
' HHHHHHHHHHH  RRRRRRRRRRR  HHHHHHHHHHH  
' HHHHHHHHHHH  RRRRRRRRRRR  HHHHHHHHHHH  
' HHHHHHHHHHH  RRRRRRRR     HHHHHHHHHHH  
' HHHH   HHHH  RRRR RRRR    HHHH   HHHH  
' HHHH   HHHH  RRRR  RRRR   HHHH   HHHH  
' HHHH   HHHH  RRRR  RRRRR  HHHH   HHHH  
' HHHH   HHHH  RRRR   RRRRR HHHH   HHHH  
' HHHH   HHHH  RRRR    RRRR HHHH   HHHH  
'HRH
Sub HRH()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-6").Click
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("TK10")) Then
'HRH_CURR
'Clinical
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").Value = ThisWorkbook.Sheets("sheet1").Range("TK10")
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("TL10")
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("TM10")
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Clinical Support
IE.Document.GetElementByID("XL1jnbmgXje-DOwfGvVn9ck-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-DOwfGvVn9ck-val").Value = ThisWorkbook.Sheets("sheet1").Range("TN10")
IE.Document.GetElementByID("XL1jnbmgXje-DOwfGvVn9ck-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-ua5IEJcXKSZ-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-ua5IEJcXKSZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("TO10")
IE.Document.GetElementByID("XL1jnbmgXje-ua5IEJcXKSZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-gM511Ccfn0j-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-gM511Ccfn0j-val").Value = ThisWorkbook.Sheets("sheet1").Range("TP10")
IE.Document.GetElementByID("XL1jnbmgXje-gM511Ccfn0j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Management
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").Value = ThisWorkbook.Sheets("sheet1").Range("TQ10")
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").Value = ThisWorkbook.Sheets("sheet1").Range("TR10")
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TS10")
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Social Service
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").Value = ThisWorkbook.Sheets("sheet1").Range("TT10")
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").Value = ThisWorkbook.Sheets("sheet1").Range("TU10")
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").Value = ThisWorkbook.Sheets("sheet1").Range("TV10")
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Lay
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").Value = ThisWorkbook.Sheets("sheet1").Range("TW10")
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").Value = ThisWorkbook.Sheets("sheet1").Range("TX10")
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").Value = ThisWorkbook.Sheets("sheet1").Range("TY10")
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Other
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TZ10")
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").Value = ThisWorkbook.Sheets("sheet1").Range("UA10")
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("UB10")
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
'HRH_STAFF
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("UC10")) Then
IE.Document.GetElementByID("Kk4CdspETNQ-mkOfrTuz7tS-val").Focus
IE.Document.GetElementByID("Kk4CdspETNQ-mkOfrTuz7tS-val").Value = ThisWorkbook.Sheets("sheet1").Range("UC10")
IE.Document.GetElementByID("Kk4CdspETNQ-mkOfrTuz7tS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Kk4CdspETNQ-j2gebSicoa8-val").Focus
IE.Document.GetElementByID("Kk4CdspETNQ-j2gebSicoa8-val").Value = ThisWorkbook.Sheets("sheet1").Range("UD10")
IE.Document.GetElementByID("Kk4CdspETNQ-j2gebSicoa8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Kk4CdspETNQ-oaRfTQD4RLG-val").Focus
IE.Document.GetElementByID("Kk4CdspETNQ-oaRfTQD4RLG-val").Value = ThisWorkbook.Sheets("sheet1").Range("UE10")
IE.Document.GetElementByID("Kk4CdspETNQ-oaRfTQD4RLG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Kk4CdspETNQ-itxIkeWqiE9-val").Focus
IE.Document.GetElementByID("Kk4CdspETNQ-itxIkeWqiE9-val").Value = ThisWorkbook.Sheets("sheet1").Range("UF10")
IE.Document.GetElementByID("Kk4CdspETNQ-itxIkeWqiE9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Kk4CdspETNQ-a9N5X73zhET-val").Focus
IE.Document.GetElementByID("Kk4CdspETNQ-a9N5X73zhET-val").Value = ThisWorkbook.Sheets("sheet1").Range("UG10")
IE.Document.GetElementByID("Kk4CdspETNQ-a9N5X73zhET-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("Kk4CdspETNQ-wKH5X6oHquw-val").Focus
IE.Document.GetElementByID("Kk4CdspETNQ-wKH5X6oHquw-val").Value = ThisWorkbook.Sheets("sheet1").Range("UH10")
IE.Document.GetElementByID("Kk4CdspETNQ-wKH5X6oHquw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' LLLL          AAAAA     BBBBBBBBBB        PPPPPPPPP   TTTTTTTTTTT  CCCCCCC       QQQQQQQ   QIII  
' LLLL          AAAAA     BBBBBBBBBBB       PPPPPPPPPP  TTTTTTTTTTT CCCCCCCCC    QQQQQQQQQQ  QIII  
' LLLL         AAAAAA     BBBBBBBBBBB       PPPPPPPPPPP TTTTTTTTTTTCCCCCCCCCCC  QQQQQQQQQQQQ QIII  
' LLLL         AAAAAAA    BBBB   BBBB       PPPP   PPPP    TTTT    CCCC   CCCCC QQQQQ  QQQQQ QIII  
' LLLL        AAAAAAAA    BBBB   BBBB       PPPP   PPPP    TTTT   TCCC     CCC CQQQQ     QQQQQIII  
' LLLL        AAAAAAAA    BBBBBBBBBBB       PPPPPPPPPPP    TTTT   TCCC         CQQQ      QQQQQIII  
' LLLL        AAAA AAAA   BBBBBBBBBB        PPPPPPPPPP     TTTT   TCCC         CQQQ      QQQQQIII  
' LLLL       AAAAAAAAAA   BBBBBBBBBBB       PPPPPPPPP      TTTT   TCCC         CQQQ  QQQ QQQQQIII  
' LLLL       AAAAAAAAAAA  BBBB    BBBB      PPPP           TTTT   TCCC     CCC CQQQQ QQQQQQQQQIII  
' LLLL       AAAAAAAAAAA  BBBB    BBBB      PPPP           TTTT    CCCC   CCCCC QQQQQ QQQQQQ QIII  
' LLLLLLLLLLLAAA    AAAA  BBBBBBBBBBBB      PPPP           TTTT    CCCCCCCCCCC  QQQQQQQQQQQQ QIII  
' LLLLLLLLLLLAAA     AAAA BBBBBBBBBBB       PPPP           TTTT     CCCCCCCCCC   QQQQQQQQQQQ QIII  
' LLLLLLLLLLLAAA     AAAA BBBBBBBBBB        PPPP           TTTT      CCCCCCC       QQQQQQQQQQQIII  
'                                                                                         QQQ      
'LAB_PTCQI
Sub LAB_PTCQI()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'LAB_Based
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("UN10")) Then
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").Value = ThisWorkbook.Sheets("sheet1").Range("UN10")
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").Value = ThisWorkbook.Sheets("sheet1").Range("UO10")
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").Value = ThisWorkbook.Sheets("sheet1").Range("UP10")
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").Value = ThisWorkbook.Sheets("sheet1").Range("UQ10")
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV IVT/EID
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").Value = ThisWorkbook.Sheets("sheet1").Range("UR10")
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").Value = ThisWorkbook.Sheets("sheet1").Range("US10")
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").Value = ThisWorkbook.Sheets("sheet1").Range("UT10")
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").Value = ThisWorkbook.Sheets("sheet1").Range("UU10")
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV Viral Load
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").Value = ThisWorkbook.Sheets("sheet1").Range("UV10")
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").Value = ThisWorkbook.Sheets("sheet1").Range("UW10")
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").Value = ThisWorkbook.Sheets("sheet1").Range("UX10")
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").Value = ThisWorkbook.Sheets("sheet1").Range("UY10")
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB Xpert
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").Value = ThisWorkbook.Sheets("sheet1").Range("UZ10")
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").Value = ThisWorkbook.Sheets("sheet1").Range("VA10")
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").Value = ThisWorkbook.Sheets("sheet1").Range("VB10")
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").Value = ThisWorkbook.Sheets("sheet1").Range("VC10")
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB AFB
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").Value = ThisWorkbook.Sheets("sheet1").Range("VD10")
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").Value = ThisWorkbook.Sheets("sheet1").Range("VE10")
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").Value = ThisWorkbook.Sheets("sheet1").Range("VF10")
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").Value = ThisWorkbook.Sheets("sheet1").Range("VG10")
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB Culture
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").Value = ThisWorkbook.Sheets("sheet1").Range("VH10")
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").Value = ThisWorkbook.Sheets("sheet1").Range("VI10")
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").Value = ThisWorkbook.Sheets("sheet1").Range("VJ10")
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").Value = ThisWorkbook.Sheets("sheet1").Range("VK10")
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'CD4
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").Value = ThisWorkbook.Sheets("sheet1").Range("VL10")
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").Value = ThisWorkbook.Sheets("sheet1").Range("VM10")
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").Value = ThisWorkbook.Sheets("sheet1").Range("VN10")
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").Value = ThisWorkbook.Sheets("sheet1").Range("VO10")
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Other
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").Value = ThisWorkbook.Sheets("sheet1").Range("VP10")
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").Value = ThisWorkbook.Sheets("sheet1").Range("VQ10")
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").Value = ThisWorkbook.Sheets("sheet1").Range("VR10")
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").Value = ThisWorkbook.Sheets("sheet1").Range("VS10")
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'2
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").Value = ThisWorkbook.Sheets("sheet1").Range("VT10")
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").Value = ThisWorkbook.Sheets("sheet1").Range("VU10")
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").Value = ThisWorkbook.Sheets("sheet1").Range("VV10")
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV IVT/EID
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").Value = ThisWorkbook.Sheets("sheet1").Range("VW10")
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").Value = ThisWorkbook.Sheets("sheet1").Range("VX10")
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").Value = ThisWorkbook.Sheets("sheet1").Range("VY10")
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV Viral Load
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").Value = ThisWorkbook.Sheets("sheet1").Range("VZ10")
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").Value = ThisWorkbook.Sheets("sheet1").Range("WA10")
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").Value = ThisWorkbook.Sheets("sheet1").Range("WB10")
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB Xpert
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").Value = ThisWorkbook.Sheets("sheet1").Range("WC10")
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("WD10")
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").Value = ThisWorkbook.Sheets("sheet1").Range("WE10")
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB AFB
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").Value = ThisWorkbook.Sheets("sheet1").Range("WF10")
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").Value = ThisWorkbook.Sheets("sheet1").Range("WG10")
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").Value = ThisWorkbook.Sheets("sheet1").Range("WH10")
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB Culture
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").Value = ThisWorkbook.Sheets("sheet1").Range("WI10")
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").Value = ThisWorkbook.Sheets("sheet1").Range("WJ10")
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").Value = ThisWorkbook.Sheets("sheet1").Range("WK10")
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'CD4
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").Value = ThisWorkbook.Sheets("sheet1").Range("WL10")
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").Value = ThisWorkbook.Sheets("sheet1").Range("WM10")
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("WN10")
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Other
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").Value = ThisWorkbook.Sheets("sheet1").Range("WO10")
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").Value = ThisWorkbook.Sheets("sheet1").Range("WP10")
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").Value = ThisWorkbook.Sheets("sheet1").Range("WQ10")
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Specimens received
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").Value = ThisWorkbook.Sheets("sheet1").Range("WR10")
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").Value = ThisWorkbook.Sheets("sheet1").Range("WS10")
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").Value = ThisWorkbook.Sheets("sheet1").Range("WT10")
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").Value = ThisWorkbook.Sheets("sheet1").Range("WU10")
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").Value = ThisWorkbook.Sheets("sheet1").Range("WV10")
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").Value = ThisWorkbook.Sheets("sheet1").Range("WW10")
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").Value = ThisWorkbook.Sheets("sheet1").Range("WX10")
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").Value = ThisWorkbook.Sheets("sheet1").Range("WY10")
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
'POCT_Based
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("WZ10")) Then
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").Value = ThisWorkbook.Sheets("sheet1").Range("WZ10")
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").Value = ThisWorkbook.Sheets("sheet1").Range("XA10")
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").Value = ThisWorkbook.Sheets("sheet1").Range("XB10")
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").Value = ThisWorkbook.Sheets("sheet1").Range("XC10")
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").Value = ThisWorkbook.Sheets("sheet1").Range("XD10")
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV IVT/EID
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").Value = ThisWorkbook.Sheets("sheet1").Range("XE10")
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").Value = ThisWorkbook.Sheets("sheet1").Range("XF10")
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").Value = ThisWorkbook.Sheets("sheet1").Range("XG10")
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").Value = ThisWorkbook.Sheets("sheet1").Range("XH10")
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").Value = ThisWorkbook.Sheets("sheet1").Range("XI10")
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV Viral Load
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").Value = ThisWorkbook.Sheets("sheet1").Range("XJ10")
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").Value = ThisWorkbook.Sheets("sheet1").Range("XK10")
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").Value = ThisWorkbook.Sheets("sheet1").Range("XL10")
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").Value = ThisWorkbook.Sheets("sheet1").Range("XM10")
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").Value = ThisWorkbook.Sheets("sheet1").Range("XN10")
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB Xpert
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").Value = ThisWorkbook.Sheets("sheet1").Range("XO10")
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").Value = ThisWorkbook.Sheets("sheet1").Range("XP10")
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").Value = ThisWorkbook.Sheets("sheet1").Range("XQ10")
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").Value = ThisWorkbook.Sheets("sheet1").Range("XR10")
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("XS10")
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB AFB
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").Value = ThisWorkbook.Sheets("sheet1").Range("XT10")
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").Value = ThisWorkbook.Sheets("sheet1").Range("XU10")
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").Value = ThisWorkbook.Sheets("sheet1").Range("XV10")
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").Value = ThisWorkbook.Sheets("sheet1").Range("XW10")
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").Value = ThisWorkbook.Sheets("sheet1").Range("XX10")
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'CD4
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").Value = ThisWorkbook.Sheets("sheet1").Range("XY10")
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").Value = ThisWorkbook.Sheets("sheet1").Range("XZ10")
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").Value = ThisWorkbook.Sheets("sheet1").Range("YA10")
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").Value = ThisWorkbook.Sheets("sheet1").Range("YB10")
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").Value = ThisWorkbook.Sheets("sheet1").Range("YC10")
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Other
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("YD10")
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").Value = ThisWorkbook.Sheets("sheet1").Range("YE10")
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").Value = ThisWorkbook.Sheets("sheet1").Range("YF10")
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").Value = ThisWorkbook.Sheets("sheet1").Range("YG10")
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").Value = ThisWorkbook.Sheets("sheet1").Range("YH10")
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'2
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").Value = ThisWorkbook.Sheets("sheet1").Range("YI10")
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").Value = ThisWorkbook.Sheets("sheet1").Range("YJ10")
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").Value = ThisWorkbook.Sheets("sheet1").Range("YK10")
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV IVT/EID
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").Value = ThisWorkbook.Sheets("sheet1").Range("YL10")
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").Value = ThisWorkbook.Sheets("sheet1").Range("YM10")
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").Value = ThisWorkbook.Sheets("sheet1").Range("YN10")
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'HIV Viral Load
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").Value = ThisWorkbook.Sheets("sheet1").Range("YO10")
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").Value = ThisWorkbook.Sheets("sheet1").Range("YP10")
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").Value = ThisWorkbook.Sheets("sheet1").Range("YQ10")
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB Xpert
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").Value = ThisWorkbook.Sheets("sheet1").Range("YR10")
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").Value = ThisWorkbook.Sheets("sheet1").Range("YS10")
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").Value = ThisWorkbook.Sheets("sheet1").Range("YT10")
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'TB AFB
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").Value = ThisWorkbook.Sheets("sheet1").Range("YU10")
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").Value = ThisWorkbook.Sheets("sheet1").Range("YV10")
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").Value = ThisWorkbook.Sheets("sheet1").Range("YW10")
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'CD4
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("YX10")
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").Value = ThisWorkbook.Sheets("sheet1").Range("YY10")
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").Value = ThisWorkbook.Sheets("sheet1").Range("YZ10")
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Other
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZA10")
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZB10")
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZC10")
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Specimens received
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZD10")
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZE10")
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZF10")
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZG10")
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZH10")
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZI10")
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZJ10") 
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
End If
End Sub

' PPPPPPPPP  PPMMMM   MMMMMM TTTTTTTTTTT  CCCCCCC    TTTTTTTTTTT     FFFFFFFFFF   OOOOOOO     
' PPPPPPPPPP PPMMMM   MMMMMM TTTTTTTTTTT CCCCCCCCC   TTTTTTTTTTT     FFFFFFFFFF  OOOOOOOOOO   
' PPPPPPPPPPPPPMMMM   MMMMMM TTTTTTTTTTTCCCCCCCCCCC  TTTTTTTTTTT     FFFFFFFFFF OOOOOOOOOOOO  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT    CCCC   CCCCC    TTTT         FFFF       OOOOO  OOOOO  
' PPPP   PPPPPPMMMMM MMMMMMM    TTTT   TCCC     CCC     TTTT         FFFF      FOOOO    OOOO  
' PPPPPPPPPPPPPMMMMM MMMMMMM    TTTT   TCCC             TTTT         FFFFFFFFF FOOO      OOO  
' PPPPPPPPPP PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT         FFFFFFFFF FOOO      OOO  
' PPPPPPPPP  PPMMMMMMMMMMMMM    TTTT   TCCC             TTTT         FFFFFFFFF FOOO      OOO  
' PPPP       PPMMMMMMMMMMMMM    TTTT   TCCC     CCC     TTTT         FFFF      FOOOO    OOOO  
' PPPP       PPMM MMMMM MMMM    TTTT    CCCC   CCCCC    TTTT         FFFF       OOOOO  OOOOO  
' PPPP       PPMM MMMMM MMMM    TTTT    CCCCCCCCCCC     TTTT         FFFF       OOOOOOOOOOOO  
' PPPP       PPMM MMMMM MMMM    TTTT     CCCCCCCCCC     TTTT         FFFF        OOOOOOOOOO   
' PPPP       PPMM MMMMM MMMM    TTTT      CCCCCCC       TTTT         FFFF          OOOOOO     
'PMTCT_FO
Sub PMTCT_FO()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-3").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-10").Click
Else
IE.Document.GetElementByID("ui-id-11").Click
End If
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ZK10")) Then
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("jskukqOhI5M-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("jskukqOhI5M-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZK10")
IE.Document.GetElementByID("jskukqOhI5M-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("hhPP8o3Ey3P-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("hhPP8o3Ey3P-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZK10")
IE.Document.GetElementByID("hhPP8o3Ey3P-HllvX50cXC0-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'HIV-infected
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KYjkpApPVjU-XXVM3fPoj9N-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-XXVM3fPoj9N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZL10")
IE.Document.GetElementByID("KYjkpApPVjU-XXVM3fPoj9N-val").dispatchEvent evt
Else
IE.Document.GetElementByID("lImd8FuLzSU-XXVM3fPoj9N-val").Focus
IE.Document.GetElementByID("lImd8FuLzSU-XXVM3fPoj9N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZL10")
IE.Document.GetElementByID("lImd8FuLzSU-XXVM3fPoj9N-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'HIV-uninfected
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KYjkpApPVjU-Jz2ibrOD00K-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-Jz2ibrOD00K-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZM10")
IE.Document.GetElementByID("KYjkpApPVjU-Jz2ibrOD00K-val").dispatchEvent evt
Else
IE.Document.GetElementByID("lImd8FuLzSU-Jz2ibrOD00K-val").Focus
IE.Document.GetElementByID("lImd8FuLzSU-Jz2ibrOD00K-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZM10")
IE.Document.GetElementByID("lImd8FuLzSU-Jz2ibrOD00K-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'HIV-final status unknown
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KYjkpApPVjU-CWMkQRQI2Rj-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-CWMkQRQI2Rj-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZN10")
IE.Document.GetElementByID("KYjkpApPVjU-CWMkQRQI2Rj-val").dispatchEvent evt
Else
IE.Document.GetElementByID("lImd8FuLzSU-CWMkQRQI2Rj-val").Focus
IE.Document.GetElementByID("lImd8FuLzSU-CWMkQRQI2Rj-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZN10")
IE.Document.GetElementByID("lImd8FuLzSU-CWMkQRQI2Rj-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Died without status known
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("KYjkpApPVjU-n2lC5CRLwnR-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-n2lC5CRLwnR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZO10")
IE.Document.GetElementByID("KYjkpApPVjU-n2lC5CRLwnR-val").dispatchEvent evt
Else
IE.Document.GetElementByID("lImd8FuLzSU-n2lC5CRLwnR-val").Focus
IE.Document.GetElementByID("lImd8FuLzSU-n2lC5CRLwnR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZO10")
IE.Document.GetElementByID("lImd8FuLzSU-n2lC5CRLwnR-val").dispatchEvent evt
End If
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
'CXCA_SCRN
Sub CXCA_SCRN()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-3").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-10").Click
Else
IE.Document.GetElementByID("ui-id-11").Click
End If
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ZP10")) Then
'Cervical Cancer screen: Positive
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZP10")
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-dh4TQ68p2SC-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-dh4TQ68p2SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZP10")
IE.Document.GetElementByID("XWK6yAwhol8-dh4TQ68p2SC-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZQ10")
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-pdCeAB4EYYM-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-pdCeAB4EYYM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZQ10")
IE.Document.GetElementByID("XWK6yAwhol8-pdCeAB4EYYM-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZR10")
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-qgGxi9db8sQ-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-qgGxi9db8sQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZR10")
IE.Document.GetElementByID("XWK6yAwhol8-qgGxi9db8sQ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZS10")
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-ZLqwxAM0rDn-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-ZLqwxAM0rDn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZS10")
IE.Document.GetElementByID("XWK6yAwhol8-ZLqwxAM0rDn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZT10")
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-k6PpW7YsDek-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-k6PpW7YsDek-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZT10")
IE.Document.GetElementByID("XWK6yAwhol8-k6PpW7YsDek-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-44
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZU10")
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-Rs8GH9wo2Iq-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-Rs8GH9wo2Iq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZU10")
IE.Document.GetElementByID("XWK6yAwhol8-Rs8GH9wo2Iq-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'45-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZV10")
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-dyxvzwmNPGZ-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-dyxvzwmNPGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZV10")
IE.Document.GetElementByID("XWK6yAwhol8-dyxvzwmNPGZ-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZW10")
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-dr2VUvtgDGn-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-dr2VUvtgDGn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZW10")
IE.Document.GetElementByID("XWK6yAwhol8-dr2VUvtgDGn-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Cervical Cancer screen: Positive
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZX10")
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-fJ4uotAMsvK-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-fJ4uotAMsvK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZX10")
IE.Document.GetElementByID("XWK6yAwhol8-fJ4uotAMsvK-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZY10")
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-HMzo64LcweA-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-HMzo64LcweA-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZY10")
IE.Document.GetElementByID("XWK6yAwhol8-HMzo64LcweA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZZ10")
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-vW2cAkyRE1o-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-vW2cAkyRE1o-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZZ10")
IE.Document.GetElementByID("XWK6yAwhol8-vW2cAkyRE1o-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAA10")
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-O7xahbUykIN-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-O7xahbUykIN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAA10")
IE.Document.GetElementByID("XWK6yAwhol8-O7xahbUykIN-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAB10")
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-t30vaBv4cPu-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-t30vaBv4cPu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAB10")
IE.Document.GetElementByID("XWK6yAwhol8-t30vaBv4cPu-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-44
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAC10")
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-lGLhiwNxWOk-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-lGLhiwNxWOk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAC10")
IE.Document.GetElementByID("XWK6yAwhol8-lGLhiwNxWOk-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'45-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAD10")
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-TSVq2SiVSqr-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-TSVq2SiVSqr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAD10")
IE.Document.GetElementByID("XWK6yAwhol8-TSVq2SiVSqr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAE10")
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-SXr2dJIXau2-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-SXr2dJIXau2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAE10")
IE.Document.GetElementByID("XWK6yAwhol8-SXr2dJIXau2-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'Cervical Cancer screen: Suspected
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAF10")
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-nI9rG3vPWQz-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-nI9rG3vPWQz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAF10")
IE.Document.GetElementByID("XWK6yAwhol8-nI9rG3vPWQz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAG10")
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-bUHsLsQL80m-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-bUHsLsQL80m-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAG10")
IE.Document.GetElementByID("XWK6yAwhol8-bUHsLsQL80m-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAH10")
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-sngMFN7RcpA-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-sngMFN7RcpA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAH10")
IE.Document.GetElementByID("XWK6yAwhol8-sngMFN7RcpA-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAI10")
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-nFHijHYOiFf-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-nFHijHYOiFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAI10")
IE.Document.GetElementByID("XWK6yAwhol8-nFHijHYOiFf-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAJ10")
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-E37hIruafwo-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-E37hIruafwo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAJ10")
IE.Document.GetElementByID("XWK6yAwhol8-E37hIruafwo-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-44
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAK10")
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-bbH8Y4ejXSr-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-bbH8Y4ejXSr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAK10")
IE.Document.GetElementByID("XWK6yAwhol8-bbH8Y4ejXSr-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'45-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAL10")
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-B5fJ4gs57Jz-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-B5fJ4gs57Jz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAL10")
IE.Document.GetElementByID("XWK6yAwhol8-B5fJ4gs57Jz-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAM10")
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").dispatchEvent evt
Else
IE.Document.GetElementByID("XWK6yAwhol8-GGSHmwiOMQX-val").Focus
IE.Document.GetElementByID("XWK6yAwhol8-GGSHmwiOMQX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAM10")
IE.Document.GetElementByID("XWK6yAwhol8-GGSHmwiOMQX-val").dispatchEvent evt
End If
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
'CXCA_TX
Sub CXCA_TX()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'Select TAB
IE.Document.GetElementByID("ui-id-4").Click
Application.Wait Now + TimeValue("00:00:03")
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("ui-id-12").Click
Else
IE.Document.GetElementByID("ui-id-13").Click
End If
Application.Wait Now + TimeValue("00:00:03")
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AAN10")) Then
'Cervical Cancer screen: Cryotherapy
'15-19
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAN10")
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-Njt3hvrCNIO-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-Njt3hvrCNIO-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAN10")
IE.Document.GetElementByID("Z6qsl1ezjTS-Njt3hvrCNIO-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'20-24
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAO10")
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-ycC6TYD1fK8-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-ycC6TYD1fK8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAO10")
IE.Document.GetElementByID("Z6qsl1ezjTS-ycC6TYD1fK8-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'25-29
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAP10")
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-esEoT2zyIAD-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-esEoT2zyIAD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAP10")
IE.Document.GetElementByID("Z6qsl1ezjTS-esEoT2zyIAD-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'30-34
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAQ10")
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-RMeYVgQI1xD-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-RMeYVgQI1xD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAQ10")
IE.Document.GetElementByID("Z6qsl1ezjTS-RMeYVgQI1xD-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'35-39
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAR10")
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-yUZniFjLR4K-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-yUZniFjLR4K-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAR10")
IE.Document.GetElementByID("Z6qsl1ezjTS-yUZniFjLR4K-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'40-44
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAS10")
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-ca7gG3WIozw-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-ca7gG3WIozw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAS10")
IE.Document.GetElementByID("Z6qsl1ezjTS-ca7gG3WIozw-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'45-49
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAT10")
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-wk3ttV4GTnT-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-wk3ttV4GTnT-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAT10")
IE.Document.GetElementByID("Z6qsl1ezjTS-wk3ttV4GTnT-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
'50+
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAU10")
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").dispatchEvent evt
Else
IE.Document.GetElementByID("Z6qsl1ezjTS-iV3JZe1JRsk-val").Focus
IE.Document.GetElementByID("Z6qsl1ezjTS-iV3JZe1JRsk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAU10")
IE.Document.GetElementByID("Z6qsl1ezjTS-iV3JZe1JRsk-val").dispatchEvent evt
End If
Application.Wait Now + TimeValue("00:00:01")
End If
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
        .BCC = "damasceno.lopes@fgh.org.mz;prosperino.mbalame@fgh.org.mz;hamilton.mutemba@fgh.org.mz;eurico.jose@fgh.org.mz;antonio.mastala@fgh.org.mz;idelina.albano@fgh.org.mz"
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