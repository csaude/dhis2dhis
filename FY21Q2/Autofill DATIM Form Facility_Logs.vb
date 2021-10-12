' Copyright (C) 2017-2021, Friends in Global Health, LLC
' All rights reserved.

' This code allows a DATIM end user to automatically fill out the
' MER Results: Facility Based form for a specific quarterly period and
' Organizational Units. This code works with MS Excel file

'--------------------------------------------------------------------
'                             INSTRUCTIONS
'--------------------------------------------------------------------

' Before run this Macro make sure to login using internet explorer in
' DATIM with Data Entry previleges, this approach only works with the Internet Explorer browser

Public ouList As String
Public fillDuration As Date
Public fillDuration2 As Date
Public lastRow As Long
Public startTime2 As Date
Public endTime2 As Date
Public i As Integer
Public zeroControl As Integer
'NEW
Public numRow As Integer
Public organisationunit As String
Public period As String
Public driver As New ChromeDriver


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

FormDataEntryType.ComboBox1.AddItem "SIM"
FormDataEntryType.ComboBox1.AddItem "NÃO"
FormDataEntryType.ComboBox1.Value = "SIM"
FormDataEntryType.Show

period = "2020Q4"


'FormProgressBar is Mandatory to use this code
FormProgressBar.LabelProgress.Width = 0
FormProgressBar.Label3.Caption = Now
startTime = Now
FormProgressBar.LabelCaption = "Preparando para digitar dados..."
FormProgressBar.LabelUserInfo = Environ("Username")
FormProgressBar.LabelUserAgentInfo = Environ("COMPUTERNAME") & ", " & Environ("OS") & ", " & Environ("PROCESSOR_ARCHITECTURE") & ", " & Environ("NUMBER_OF_PROCESSORS") & " CPU"
FormProgressBar.Show
'COUNT total OUs
Set myRange = Worksheets("sheet1").Range("A12:A302")
lastRow = Application.WorksheetFunction.CountA(myRange)

driver.Start
driver.Get "https://play.dhis2.org/2.34.2/dhis-web-dataentry/index.action"
'45 seconds to ensure that the page loads all HTML/CSS/JS components
Application.Wait Now + TimeValue("00:01:00")

For Each Sheet In ThisWorkbook.Worksheets
    If Sheet.Name = "DATIM_CSV_Logs" Then
        Application.DisplayAlerts = False
        Worksheets("DATIM_CSV_Logs").Delete
        Application.DisplayAlerts = True
    End If
Next Sheet

Application.Wait Now + TimeValue("00:00:05")

Set ws = ThisWorkbook.Sheets.Add(After:= _
             ThisWorkbook.Sheets(ThisWorkbook.Sheets.Count))
ws.Name = "DATIM_CSV_Logs"

ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("A1") = "dataelement"
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("B1") = "period"
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("C1") = "orgunit"
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("D1") = "categoryoptioncombo"
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("E1") = "attroptioncombo"
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("F1") = "value"

Application.Wait Now + TimeValue("00:00:02")

i = 1
numRow = 2

'Possible to run over 1000 Health Facilities, change if overflow
Do While i < 1000

If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("A12")) Then
'End process if find line with blank Org Unit
i = i + 1000
FormProgressBar.Hide
Else

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("C12")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("C12")) Then
'Delete row 10 if there is no identification of DATIM Org Unit
ThisWorkbook.Sheets("sheet1").Rows(12).EntireRow.Delete

Else

    'ProgressBar lifetime update
    ouList = ouList & ThisWorkbook.Sheets("sheet1").Range("A12") & " (" & ThisWorkbook.Sheets("sheet1").Range("B12") & ")" & "<br>"
    toComplete = i / lastRow
    With FormProgressBar
        .LabelCaption.Caption = "Digitando Unidade Organizacional nº " & i & " de " & lastRow
        .LabelOUInfo.Caption = "A digitar: " & ThisWorkbook.Sheets("sheet1").Range("A12") & " (" & ThisWorkbook.Sheets("sheet1").Range("B12") & ")"
        .LabelProgress.Width = toComplete * (.FrameProgress.Width)
    End With

    organisationunit = ThisWorkbook.Sheets("sheet1").Range("C12")
    startTime2 = Now
    
    'Call DHIS2 javascript function to select Org Unit on tree
    'driver.FindElementById("orgUnit" & organisationunit).Click
    driver.ExecuteScript ("javascript:void selection.select( '" & organisationunit & "' )")
    startTime2 = Now
    Application.Wait Now + TimeValue("00:01:00")
    
    'Select the Dataset and Period only at 1st time
    If i = 1 Then
   
    'Select Dataset
    driver.FindElementById("selectedDataSetId").AsSelect.SelectByValue ("IQ2Ja7BzFRK")
    Application.Wait Now + TimeValue("00:00:04")
    'Select the Period
    
    If period Like "*Q4*" Then
    driver.ExecuteScript ("previousPeriodsSelected()")
    End If

    Application.Wait Now + TimeValue("00:00:03")
    driver.FindElementById("selectedPeriodId").AsSelect.SelectByValue (period)
    
    Application.Wait Now + TimeValue("00:01:00")
    End If

    '--------------------------------------------------------------------
    '                        CALL FUNCTIONS
    '--------------------------------------------------------------------
    Call Data_importer
    
    endTime2 = Now
    fillDuration2 = endTime2 - startTime2
    Call SendEmailNotification
    Application.Wait Now + TimeValue("00:00:05")
    'Next Health Facility
    ThisWorkbook.Sheets("sheet1").Rows(12).EntireRow.Delete
    Application.Wait Now + TimeValue("00:00:05")

End If
    
i = i + 1

End If
Loop

MsgBox "Dados digitados no DATIM com sucesso!", vbInformation, "FGH-SIS"

'Calculate the total duration time
endTime = Now
fillDuration = endTime - startTime
FormProgressBar.CheckBox2.Value = True
FormProgressBar.Label5.Caption = Now
'& ", Duração: " & Format(fillDuration, "hh") & ":" & Format(fillDuration, "nn:ss")

End Sub



Sub Data_importer()
Dim columnNum As Integer
columnNum = 3
Do While columnNum < 1500

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Cells(10, columnNum).Value) And ThisWorkbook.Sheets("sheet1").Cells(12, columnNum).Value > zeroControl And Not IsEmpty(ThisWorkbook.Sheets("sheet1").Cells(12, columnNum).Value) Then
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("A" & numRow) = ThisWorkbook.Sheets("sheet1").Cells(10, columnNum).Value
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("B" & numRow) = period
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("C" & numRow) = organisationunit
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("D" & numRow) = ThisWorkbook.Sheets("sheet1").Cells(11, columnNum).Value
ThisWorkbook.Sheets("DATIM_CSV_Logs").Range("F" & numRow) = ThisWorkbook.Sheets("sheet1").Cells(12, columnNum).Value
driver.FindElementById(ThisWorkbook.Sheets("sheet1").Cells(10, columnNum).Value & "-" & ThisWorkbook.Sheets("sheet1").Cells(11, columnNum).Value & "-val").Clear
driver.FindElementById(ThisWorkbook.Sheets("sheet1").Cells(10, columnNum).Value & "-" & ThisWorkbook.Sheets("sheet1").Cells(11, columnNum).Value & "-val").SendKeys (ThisWorkbook.Sheets("sheet1").Cells(12, columnNum).Value)
driver.FindElementById(ThisWorkbook.Sheets("sheet1").Cells(10, columnNum).Value & "-" & ThisWorkbook.Sheets("sheet1").Cells(11, columnNum).Value & "-val").SendKeys (driver.Keys.Tab)

numRow = numRow + 1
Application.Wait Now + TimeValue("00:00:06")
End If

columnNum = columnNum + 1
Loop

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
    lStr = lStr & "<table border='1' style='border-color:#EEEEEE;' cellspacing='0' cellpadding='5' width=420><tr><td colspan='2' style='background-color:#0288D1;color:white;text-align:center;'>Digitação automática completa no DATIM</td></tr><tr><td bgcolor='#F3F3F3'>Nome do Utilizador do<br>Sistema Operacional:</td><td>" & FormProgressBar.LabelUserInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Agente do Utilizador:</td><td>" & FormProgressBar.LabelUserAgentInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora inicial:</td><td>" & startTime2 & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora final:</td><td>" & endTime2 & "</td></tr><tr><td bgcolor='#F3F3F3'>Duração:</td><td>" & Format(fillDuration2, "hh") & ":" & Format(fillDuration2, "nn:ss") & "</td></tr><tr><td bgcolor='#F3F3F3'>Período de reportagem:</td><td>" & Replace(ThisWorkbook.Sheets("sheet1").Range("A4"), "Period:", "") & "</td></tr>"
    lStr = lStr & "<tr><td bgcolor='#F3F3F3'>Unidade Organizacional<br>digitada:</td><td>" & ThisWorkbook.Sheets("sheet1").Range("A12") & " (" & ThisWorkbook.Sheets("sheet1").Range("C12") & ")" & "</td></tr>"
    lStr = lStr & "<tr><td colspan='2' style='text-align:center;background-color:#0288D1;color:white;'> <a href='https://dhis2.fgh.org.mz/'><span style='color:#00FFFF;'>DHIS-FGH</span></a><br><a href='https://www.datim.org/'><span style='color:#00FFFF;'>DATIM</span></a><br>" & Year(Now()) & " &copy; <a href='mailto:sis.quelimane@fgh.org.mz'><span style='color:#00FFFF;'>sis.quelimane@fgh.org.mz</span></a></td></tr></table>"

    'Set All Email Properties
    With NewMail
        .Subject = "[SIS-FGH] Autofill DATIM" & ", nº " & i & " de " & lastRow & ": " & ThisWorkbook.Sheets("sheet1").Range("A12")
        .From = "noreply@fgh.org.mz"
        .To = ""
        .CC = ""
        .BCC = "damasceno.lopes@fgh.org.mz;"
        '.BCC = "sis.quelimane@fgh.org.mz;fernanda.alvim@fgh.org.mz;antonio.mastala@fgh.org.mz;idelina.albano@fgh.org.mz;luis.macave@fgh.org.mz;armando.macuacua@fgh.org.mz;nico.silima@fgh.org.mz;roberto.lucasse@fgh.org.mz;celcio.major@fgh.org.mz"
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
        .Item(msConfigURL & "/sendusername") = "noreply@fgh.org.mz"
        .Item(msConfigURL & "/sendpassword") = "L0k@l12345*"

        'Update the configuration fields
        .Update

    End With
    NewMail.Configuration = mailConfig
    NewMail.Send
   


End Sub

