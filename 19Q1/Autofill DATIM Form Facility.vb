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
Public lastRow As Long

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

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("XH10")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("XH10")) Then
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
    Call IE.Document.parentWindow.execScript("javascript:void selection.select( '" & ThisWorkbook.Sheets("sheet1").Range("XH10") & "' )", "JavaScript")
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
    Call IE.Document.parentWindow.execScript("previousPeriodsSelected()", "JavaScript")
    Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("selectedPeriodId").Value = "2018Q4"
    IE.Document.GetElementByID("selectedPeriodId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:30")
    End If

    '--------------------------------------------------------------------
    '                        CALL FUNCTIONS
    '--------------------------------------------------------------------
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
    Call TX_NEW
    Call TX_CURR
    Call PMTCT_ART
    Call TB_ART
    Call TX_PVLS

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
FormProgressBar.Label5.Caption = Now 
'& ", Duração: " & Format(fillDuration, "hh") & ":" & Format(fillDuration, "nn:ss")

'Send E-mail notification
Call SendEmailNotification

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
'Select TAB
IE.Document.GetElementByID("ui-id-3").Click
Application.Wait Now + TimeValue("00:00:03")
IE.Document.GetElementByID("ui-id-10").Click
Application.Wait Now + TimeValue("00:00:03")

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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("GC10")) Then
'Offered
'Unknown age,F
IE.Document.GetElementByID("JuMoiYn1jKB-FUaRzF095hM-val").Focus
IE.Document.GetElementByID("JuMoiYn1jKB-FUaRzF095hM-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
IE.Document.GetElementByID("JuMoiYn1jKB-FUaRzF095hM-val").dispatchEvent evt
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
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IC10")) Then
'Elicited
'Unknown age,M,Positive
IE.Document.GetElementByID("fpW7iq7zFNN-DPm7BhmXOxE-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-DPm7BhmXOxE-val").Value = ThisWorkbook.Sheets("sheet1").Range("IC10")
IE.Document.GetElementByID("fpW7iq7zFNN-DPm7BhmXOxE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'Unknown age,M,Negative
IE.Document.GetElementByID("fpW7iq7zFNN-qHDVyDsArNr-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-qHDVyDsArNr-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
IE.Document.GetElementByID("fpW7iq7zFNN-qHDVyDsArNr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,F,Positive
IE.Document.GetElementByID("fpW7iq7zFNN-wxeNrxr2bpX-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-wxeNrxr2bpX-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
IE.Document.GetElementByID("fpW7iq7zFNN-wxeNrxr2bpX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,F,Negative
IE.Document.GetElementByID("fpW7iq7zFNN-vh0inX0iOrJ-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-vh0inX0iOrJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
IE.Document.GetElementByID("fpW7iq7zFNN-vh0inX0iOrJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,M,Positive
IE.Document.GetElementByID("fpW7iq7zFNN-eT4S5wImsdD-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-eT4S5wImsdD-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
IE.Document.GetElementByID("fpW7iq7zFNN-eT4S5wImsdD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'<15,M,Negative
IE.Document.GetElementByID("fpW7iq7zFNN-iNkAagR3OvP-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-iNkAagR3OvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
IE.Document.GetElementByID("fpW7iq7zFNN-iNkAagR3OvP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,F,Positive
IE.Document.GetElementByID("fpW7iq7zFNN-NGiXg1tctg4-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-NGiXg1tctg4-val").Value = ThisWorkbook.Sheets("sheet1").Range("II10")
IE.Document.GetElementByID("fpW7iq7zFNN-NGiXg1tctg4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,F,Negative
IE.Document.GetElementByID("fpW7iq7zFNN-G0yHk4QiVkF-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-G0yHk4QiVkF-val").Value = ThisWorkbook.Sheets("sheet1").Range("IJ10")
IE.Document.GetElementByID("fpW7iq7zFNN-G0yHk4QiVkF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,M,Positive
IE.Document.GetElementByID("fpW7iq7zFNN-HbCq1j6TzX7-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-HbCq1j6TzX7-val").Value = ThisWorkbook.Sheets("sheet1").Range("IK10")
IE.Document.GetElementByID("fpW7iq7zFNN-HbCq1j6TzX7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")
'15+,M,Negative
IE.Document.GetElementByID("fpW7iq7zFNN-JDPcigTC2yw-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-JDPcigTC2yw-val").Value = ThisWorkbook.Sheets("sheet1").Range("IL10")
IE.Document.GetElementByID("fpW7iq7zFNN-JDPcigTC2yw-val").dispatchEvent evt
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
'Select TAB
IE.Document.GetElementByID("ui-id-4").Click
Application.Wait Now + TimeValue("00:00:03")
IE.Document.GetElementByID("ui-id-12").Click
Application.Wait Now + TimeValue("00:00:03")

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OT10")) Then
'Breastfeeding
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:01")

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OU10")) Then
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
End If
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OU10")) Then
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
End If
If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("PX10")) Then
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("QV10")) Then
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
'Select TAB
IE.Document.GetElementByID("ui-id-5").Click
Application.Wait Now + TimeValue("00:00:03")
IE.Document.GetElementByID("ui-id-14").Click
Application.Wait Now + TimeValue("00:00:03")

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

    Dim lStr As String
    lStr = ""
    lStr =  lStr & "<table border='1' style='border-color:#EEEEEE;' cellspacing='0' cellpadding='5' width=420><tr><td colspan='2' style='background-color:#0288D1;color:white;text-align:center;'>Digitação automática completa no DATIM</td></tr><tr><td bgcolor='#F3F3F3'>Nome do Utilizador:</td><td>" & FormProgressBar.LabelUserInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Agente do Utilizador:</td><td>" & FormProgressBar.LabelUserAgentInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora inicial:</td><td>" & FormProgressBar.Label3 & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora final:</td><td>" & FormProgressBar.Label5 & "</td></tr><tr><td bgcolor='#F3F3F3'>Duração:</td><td>" & Format(fillDuration, "hh") & ":" & Format(fillDuration, "nn:ss") & "</td></tr><tr><td bgcolor='#F3F3F3'>Período:</td><td>" & Replace(FormProgressBar.Label5,"Period:","") & "</td></tr><tr><td bgcolor='#F3F3F3'>Unidades Organizacionais<br>digitadas:</td><td>" & ouList & "</td></tr>"
    lStr =  lStr & "<tr><td bgcolor='#F3F3F3'>Nº de UO digitadas:</td><td>" & lastRow & "</td></tr><tr><td colspan='2' style='text-align:center;background-color:#0288D1;color:white;'> <a href='http://196.28.230.195:8080/dhis'><span style='color:#00FFFF;'>DHIS-FGH</span></a><br><a href='https://www.datim.org/'><span style='color:#00FFFF;'>DATIM</span></a><br>" & Year(Now()) & " &copy; <a href='mailto:sis@fgh.org.mz'><span style='color:#00FFFF;'>sis@fgh.org.mz</span></a></td></tr></table>"

    'Set All Email Properties
    With NewMail
        .Subject = "[DHIS-FGH] Digitação automática completa no DATIM: " & FormProgressBar.LabelUserInfo & ", " & Now
        .From = "dhis.fgh@gmail.com"
        .To = ""
        .CC = ""
        .BCC = "damasceno.lopes@fgh.org.mz;prosperino.mbalame@fgh.org.mz"
        .HTMLBody = lStr
    End With

'damasceno.lopes@fgh.org.mz;prosperino.mbalame@fgh.org.mz;hamilton.mutemba@fgh.org.mz;eurico.jose@fgh.org.mz;antonio.mastala@fgh.org.mz;idelina.albano@fgh.org.mz

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