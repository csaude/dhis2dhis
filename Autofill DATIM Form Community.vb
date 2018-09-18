' Copyright (C) 2017-2018, Friends in Global Health, LLC
' All rights reserved.

' This code allows a DATIM end user to automatically fill out the
' MER Results: Community Based form for a specific quarterly period and
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

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("BH10")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("BH10")) Then
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
    Call IE.Document.parentWindow.execScript("javascript:void selection.select( '" & ThisWorkbook.Sheets("sheet1").Range("BH10") & "' )", "JavaScript")
    Application.Wait Now + TimeValue("00:00:05")
    
    'Select the Dataset and Period only at 1st time
    If i = 1 Then
    Set evt = IE.Document.createEvent("HTMLEvents")
    evt.initEvent "change", True, False
    'Select Dataset
    IE.Document.GetElementByID("selectedDataSetId").Value = "WbszaIdCi92"
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
    '                          CALL WRITE FUNCTIONS
    '--------------------------------------------------------------------
    'Control here the Data that have to writed on DATIM Form
    'Quarterly
    Call HTS_TST_Numerator_write
    Call Index_Service_Modality_write
    Call Mobile_Service_Modality_write
    

    '--------------------------------------------------------------------
    '                          CALL PERSIST FUNCTIONS
    '--------------------------------------------------------------------
    'Control here the Data that have to persisted on DATIM Form
    Application.Wait Now + TimeValue("00:00:05") 
    'Quarterly
    Call HTS_TST_Numerator_persist
    Call Index_Service_Modality_persist
    Call Mobile_Service_Modality_persist

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
IE.Document.GetElementByID("ui-id-5").Click
Else
IE.Document.GetElementByID("ui-id-6").Click
End If
End Sub

'--------------------------------------------------------------------
'                             WRITE FUNCTIONS
'--------------------------------------------------------------------
'HTS_TST Community
Sub HTS_TST_Numerator_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("C10")) Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K6f6jR0NOcZ-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("C10")
Else
IE.Document.GetElementByID("FJSew4Ks0j3-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("C10")
End If
End If
End Sub

'Index Service Modality
Sub Index_Service_Modality_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("H10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
Else
IE.Document.GetElementByID("brZrxriiF0a-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
Else
IE.Document.GetElementByID("brZrxriiF0a-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
Else
IE.Document.GetElementByID("brZrxriiF0a-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
Else
IE.Document.GetElementByID("brZrxriiF0a-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
Else
IE.Document.GetElementByID("brZrxriiF0a-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
Else
IE.Document.GetElementByID("brZrxriiF0a-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
Else
IE.Document.GetElementByID("brZrxriiF0a-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("O10")
Else
IE.Document.GetElementByID("brZrxriiF0a-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("O10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("P10")
Else
IE.Document.GetElementByID("brZrxriiF0a-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("P10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
Else
IE.Document.GetElementByID("brZrxriiF0a-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
Else
IE.Document.GetElementByID("brZrxriiF0a-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("S10")
Else
IE.Document.GetElementByID("brZrxriiF0a-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("S10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("T10")
Else
IE.Document.GetElementByID("brZrxriiF0a-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("T10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("U10")
Else
IE.Document.GetElementByID("brZrxriiF0a-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("U10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("V10")
Else
IE.Document.GetElementByID("brZrxriiF0a-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("V10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
Else
IE.Document.GetElementByID("brZrxriiF0a-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
End If
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
Else
IE.Document.GetElementByID("brZrxriiF0a-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
End If
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
Else
IE.Document.GetElementByID("brZrxriiF0a-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
End If
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
Else
IE.Document.GetElementByID("brZrxriiF0a-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
End If
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
Else
IE.Document.GetElementByID("brZrxriiF0a-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
Else
IE.Document.GetElementByID("brZrxriiF0a-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
Else
IE.Document.GetElementByID("brZrxriiF0a-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
Else
IE.Document.GetElementByID("brZrxriiF0a-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
Else
IE.Document.GetElementByID("brZrxriiF0a-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
End If
End If
End Sub

'Mobile Service Modality
Sub Mobile_Service_Modality_write()
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AJ10")) Then
'<1,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-tP2mjgakLVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
End If
'<1,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-DszsJew1vQA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
End If
'1-9,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-VP9O0ao9MmZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
End If
'1-9,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-BSQvgbaINGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
End If
'10-14,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-sDHZqlgc0lv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
End If
'10-14,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-pz7dlDGQssH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
End If
'10-14,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-GscVGDNCdwR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
End If
'10-14,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-lfHFCxROkNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
End If
'15-19,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-HEpqnVEHzUA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
End If
'15-19,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-BOxW7hCTSjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
End If
'15-19,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-SyBPyzv8HTC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
End If
'15-19,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-H250HduQyXi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
End If
'20-24,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-FLlJURwLmAe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
End If
'20-24,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AW10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-ZAVOIaOudWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AW10")
End If
'20-24,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AX10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-lZiQLcYoM7M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AX10")
End If
'20-24,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AY10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-RWG4YLNHEdA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AY10")
End If
'25-49,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AZ10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-E8XxGzk0kY7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AZ10")
End If
'25-49,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-FnHZRFcropp-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
End If
'25-49,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-Hbg53zGRcL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
End If
'25-49,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-IHmmeJ1fyKy-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
End If
'50+,F,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-dZYJREDXbfa-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
End If
'50+,F,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-flyE54cGOkr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
End If
'50+,M,Positive
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-h3WrcUxOPZ2-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
End If
'50+,M,Negative
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-HSpL3hSBx6F-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
End If
End If
End Sub

'--------------------------------------------------------------------
'                           PERSIST FUNCTIONS
'--------------------------------------------------------------------
'HTS_TST Community
Sub HTS_TST_Numerator_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("K6f6jR0NOcZ-HllvX50cXC0-val").dispatchEvent evt
Else
IE.Document.GetElementByID("FJSew4Ks0j3-HllvX50cXC0-val").dispatchEvent evt
End If
End Sub

'Index Service Modality
Sub Index_Service_Modality_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("uSDvLTfmyZL-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("uSDvLTfmyZL-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("brZrxriiF0a-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("brZrxriiF0a-HSpL3hSBx6F-val").dispatchEvent evt
End If
End Sub

'Mobile Service Modality
Sub Mobile_Service_Modality_persist()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
If ThisWorkbook.Sheets("sheet1").Range("B10") = "DSD" Then
IE.Document.GetElementByID("qkV2omqh4Xw-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("qkV2omqh4Xw-HSpL3hSBx6F-val").dispatchEvent evt
Else
IE.Document.GetElementByID("HWlPIUSm4jJ-tP2mjgakLVn-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-DszsJew1vQA-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-VP9O0ao9MmZ-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-BSQvgbaINGZ-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-sDHZqlgc0lv-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-pz7dlDGQssH-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-GscVGDNCdwR-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-lfHFCxROkNE-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-HEpqnVEHzUA-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-BOxW7hCTSjX-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-SyBPyzv8HTC-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-H250HduQyXi-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-FLlJURwLmAe-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-ZAVOIaOudWw-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-lZiQLcYoM7M-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-RWG4YLNHEdA-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-E8XxGzk0kY7-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-FnHZRFcropp-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-Hbg53zGRcL7-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-IHmmeJ1fyKy-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-dZYJREDXbfa-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-flyE54cGOkr-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-h3WrcUxOPZ2-val").dispatchEvent evt
IE.Document.GetElementByID("HWlPIUSm4jJ-HSpL3hSBx6F-val").dispatchEvent evt
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
        .Subject = "[DHIS-FGH/DATIM] Notificação de digitação automática completa (Community)"
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