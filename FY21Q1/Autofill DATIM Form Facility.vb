' Copyright (C) 2017-2020, Friends in Global Health, LLC
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
Public i As Integer

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

i = 1

'Possible to run over 1000 Health Facilities, change if overflow
Do While i < 1000

If IsEmpty(ThisWorkbook.Sheets("sheet1").Range("A10")) Then
'End process if find line with blank Org Unit
i = i + 1000
FormProgressBar.Hide
Else

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("AJE10")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AJE10")) Then
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
    Call IE.Document.parentWindow.execScript("javascript:void selection.select( '" & ThisWorkbook.Sheets("sheet1").Range("AJE10") & "' )", "JavaScript")
    startTime2 = Now
    Application.Wait Now + TimeValue("00:01:30")
    
    'Select the Dataset and Period only at 1st time
    If i = 1 Then
    Set evt = IE.Document.createEvent("HTMLEvents")
    evt.initEvent "change", True, False
    'Select Dataset
    IE.Document.GetElementByID("selectedDataSetId").Value = "jKdHXpBfWop"
    IE.Document.GetElementByID("selectedDataSetId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:04")
    'Select the Period
    'Uncomment below if you need to select a period from previous year
    Call IE.Document.parentWindow.execScript("previousPeriodsSelected()", "JavaScript")
    'Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("selectedPeriodId").Value = "2020Q4"
    IE.Document.GetElementByID("selectedPeriodId").dispatchEvent evt
    Application.Wait Now + TimeValue("00:00:50")
    End If

    '--------------------------------------------------------------------
    '                        CALL FUNCTIONS
    '--------------------------------------------------------------------
    'PREVENTION
    'Select TAB
    'IE.Document.GetElementByID("ui-id-2").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'IE.Document.GetElementByID("ui-id-7").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    'Semiannually
    'Call PrEP_NEW
    'Call PrEP_CURR
    'Call TB_PREV
    'Annually
    'Call GEND_GBV
    'Call FPINT_SITE

    'Testing - HTS_TST
    'Select TAB
    'IE.Document.GetElementByID("ui-id-3").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'IE.Document.GetElementByID("ui-id-9").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call KeyPopulation
    Call PICT_Inpatient
    Call PICT_Pediatric
    Call PICT_PostANC
    Call PICT_Emergency
    Call PICT_Other
    Call VCT

    'Testing - All Others
    'Select TAB
    'IE.Document.GetElementByID("ui-id-5").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'IE.Document.GetElementByID("ui-id-16").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call HTS_Index
    Call HTS_Self
    Call PMTCT_STAT
    Call PMTCT_EID_HEI_POS
    Call TB_STAT
    'Semiannually
    'Call CXCA_SCRN
    'Annually
    'Call PMTCT_FO


    'TREATMENT
    'Select TAB
    'IE.Document.GetElementByID("ui-id-6").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'IE.Document.GetElementByID("ui-id-18").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call TX_NEW
    Call TX_CURR
    Call TX_RTT
    Call TX_ML
    Call PMTCT_ART
    Call TB_ART
    'Semiannualy
    'Call TX_TB
    'Call CXCA_TX

    'VIRAL SUPRESSION
    'Select TAB
    'IE.Document.GetElementByID("ui-id-7").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'IE.Document.GetElementByID("ui-id-20").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call TX_PVLS
    'Semiannually

    'HEALTH SYSTEMS
    'Select TAB
    'IE.Document.GetElementByID("ui-id-6").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'IE.Document.GetElementByID("ui-id-16").Click
    'Application.Wait Now + TimeValue("00:00:03")
    'Annually
    'Call HRH
    'Call LAB_PTCQI

    'Send E-mail notification
    'Calculate the total duration time
    endTime2 = Now
    fillDuration2 = endTime2 - startTime2
    Call SendEmailNotification
    Application.Wait Now + TimeValue("00:00:05")
    'Next Health Facility
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

'     QQQQQQQ    UUUU   UUUU     AAAAA     RRRRRRRRRR   TTTTTTTTTTEEEEEEEEEEEE RRRRRRRRRR   LLLL    LLYY    YYYY  
'   QQQQQQQQQQ   UUUU   UUUU     AAAAA     RRRRRRRRRRR  TTTTTTTTTTEEEEEEEEEEEE RRRRRRRRRRR  LLLL    LLYYY   YYYY  
'  QQQQQQQQQQQQ  UUUU   UUUU    AAAAAA     RRRRRRRRRRR  TTTTTTTTTTEEEEEEEEEEEE RRRRRRRRRRR  LLLL     LYYYY YYYY   
'  QQQQQ  QQQQQ  UUUU   UUUU    AAAAAAA    RRRR   RRRRR    TTTT    EEEE        RRRR   RRRRR LLLL      YYYY YYYY   
' QQQQQ     QQQQ UUUU   UUUU   AAAAAAAA    RRRR   RRRRR    TTTT    EEEE        RRRR   RRRRR LLLL      YYYYYYYY    
' QQQQ      QQQQ UUUU   UUUU   AAAAAAAA    RRRRRRRRRRR     TTTT    EEEEEEEEEE  RRRRRRRRRRR  LLLL       YYYYYYY    
' QQQQ      QQQQ UUUU   UUUU   AAAA AAAA   RRRRRRRRRRR     TTTT    EEEEEEEEEE  RRRRRRRRRRR  LLLL        YYYYY     
' QQQQ  QQQ QQQQ UUUU   UUUU  AAAAAAAAAA   RRRRRRRR        TTTT    EEEEEEEEEE  RRRRRRRR     LLLL        YYYY      
' QQQQQ QQQQQQQQ UUUU   UUUU  AAAAAAAAAAA  RRRR RRRR       TTTT    EEEE        RRRR RRRR    LLLL        YYYY      
'  QQQQQ QQQQQQ  UUUU   UUUU  AAAAAAAAAAA  RRRR  RRRR      TTTT    EEEE        RRRR  RRRR   LLLL        YYYY      
'  QQQQQQQQQQQQ  UUUUUUUUUUU AAAA    AAAA  RRRR  RRRRR     TTTT    EEEEEEEEEEE RRRR  RRRRR  LLLLLLLLLL  YYYY      
'   QQQQQQQQQQQ   UUUUUUUUU  AAAA     AAAA RRRR   RRRRR    TTTT    EEEEEEEEEEE RRRR   RRRRR LLLLLLLLLL  YYYY      
'     QQQQQQQQQQ   UUUUUUU  UAAAA     AAAA RRRR    RRRR    TTTT    EEEEEEEEEEE RRRR    RRRR LLLLLLLLLL  YYYY      
'            QQQ                                                                                                  
'.....................................................................................................................................
'.KKKK...KKKKK.......................... PPPPPPPP....................................ulll............ttt..tiii........................
'.KKKK..KKKKK........................... PPPPPPPPP...................................ulll...........attt..tiii........................
'.KKKK.KKKKK............................ PPPPPPPPPP..................................ulll...........attt..............................
'.KKKKKKKKK.....eeeeee.eeey...yyyy...... PPP...PPPP...oooooo..ooppppppp..ppuu..uuuuu.ulll..aaaaaa.aaattttttiii...oooooo...onnnnnnn....
'.KKKKKKKK.....eeeeeeee.eeyy..yyyy...... PPP...PPPP.Poooooooo.oopppppppp.ppuu..uuuuu.ulll.laaaaaaaaaattttttiii.ioooooooo..onnnnnnnn...
'.KKKKKKKK....Keee.eeee.eeyy..yyyy...... PPPPPPPPPP.Pooo.oooooooppp.pppppppuu..uuuuu.ulllllaa.aaaaa.attt..tiii.iooo.ooooo.onnn.nnnnn..
'.KKKKKKKK....Keee..eeeeeeyy.yyyy....... PPPPPPPPP.PPoo...oooooopp...ppppppuu..uuuuu.ulll....aaaaaa.attt..tiiiiioo...oooo.onnn..nnnn..
'.KKKKKKKKK...Keeeeeeeee.eyyyyyyy....... PPPPPPPP..PPoo...oooooopp...ppppppuu..uuuuu.ulll.laaaaaaaa.attt..tiiiiioo...oooo.onnn..nnnn..
'.KKKK.KKKKK..Keeeeeeeee.eyyyyyy........ PPP.......PPoo...oooooopp...ppppppuu..uuuuu.ulllllaaaaaaaa.attt..tiiiiioo...oooo.onnn..nnnn..
'.KKKK..KKKK..Keee........yyyyyy........ PPP.......PPoo...oooooopp...ppppppuu..uuuuu.ulllllaa.aaaaa.attt..tiiiiioo...oooo.onnn..nnnn..
'.KKKK..KKKKK.Keee..eeee..yyyyyy........ PPP........Pooo.oooooooppp.pppppppuuu.uuuuu.ulllllaa.aaaaa.attt..tiii.iooo.ooooo.onnn..nnnn..
'.KKKK...KKKKK.eeeeeeee...yyyyy......... PPP........Poooooooo.oopppppppp..puuuuuuuuu.ulllllaaaaaaaa.attttttiii.ioooooooo..onnn..nnnn..
'.KKKK...KKKKK..eeeeee.....yyyy......... PPP..........oooooo..ooppppppp....uuuuuuuuu.ulll.laaaaaaaa.attttttiii...oooooo...onnn..nnnn..
'..........................yyyy...............................oopp....................................................................
'.........................yyyy................................oopp....................................................................
'.......................eeyyyy................................oopp....................................................................
'.......................eeyyy.................................oopp....................................................................
'.....................................................................................................................................
Sub KeyPopulation()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("E10:N10")) > 0 Then
'<PWID Positivos
If ThisWorkbook.Sheets("sheet1").Range("E10") > 0 Then
IE.Document.GetElementByID("qhGxKnmrZBd-xYyVHiXrvSi-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-xYyVHiXrvSi-val").Value = ThisWorkbook.Sheets("sheet1").Range("E10")
IE.Document.GetElementByID("qhGxKnmrZBd-xYyVHiXrvSi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("F10") > 0 Then
'<PWID Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-nEKvoyX7K7X-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-nEKvoyX7K7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("F10")
IE.Document.GetElementByID("qhGxKnmrZBd-nEKvoyX7K7X-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("G10") > 0 Then
'<MSM Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-i8VDE8xLSWJ-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-i8VDE8xLSWJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("G10")
IE.Document.GetElementByID("qhGxKnmrZBd-i8VDE8xLSWJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("H10") > 0 Then
'<MSM Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-kkkbGchekdj-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-kkkbGchekdj-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
IE.Document.GetElementByID("qhGxKnmrZBd-kkkbGchekdj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("I10") > 0 Then
'<Transgender People Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-vvV2d1YvSSA-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-vvV2d1YvSSA-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
IE.Document.GetElementByID("qhGxKnmrZBd-vvV2d1YvSSA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("J10") > 0 Then
'<Transgender People Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-KnvSi171hvx-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-KnvSi171hvx-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
IE.Document.GetElementByID("qhGxKnmrZBd-KnvSi171hvx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("K10") > 0 Then
'<FSW Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-YtrkH2Xrb12-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-YtrkH2Xrb12-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
IE.Document.GetElementByID("qhGxKnmrZBd-YtrkH2Xrb12-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("L10") > 0 Then
'<FSW Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-moJTjWdUcXY-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-moJTjWdUcXY-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
IE.Document.GetElementByID("qhGxKnmrZBd-moJTjWdUcXY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("M10") > 0 Then
'<People in prison and other closed settings Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-NMYN9FAPqWa-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-NMYN9FAPqWa-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
IE.Document.GetElementByID("qhGxKnmrZBd-NMYN9FAPqWa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("N10") > 0 Then
'<People in prison and other closed settings Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-qyNXQhzWglM-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-qyNXQhzWglM-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
IE.Document.GetElementByID("qhGxKnmrZBd-qyNXQhzWglM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

End If
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

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("Q10:BL10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("Q10") > 0 Then
'<1,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("R10") > 0 Then
'<1,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("S10") > 0 Then
'<1,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("S10")
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("T10") > 0 Then
'<1,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("T10")
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("U10") > 0 Then
'1-4,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("U10")
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("V10") > 0 Then
'1-4,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("V10")
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("W10") > 0 Then
'1-4,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("X10") > 0 Then
'1-4,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("Y10") > 0 Then
'5-9,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("Z10") > 0 Then
'5-9,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AA10") > 0 Then
'5-9,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AB10") > 0 Then
'5-9,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AC10") > 0 Then
'10-14,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AD10") > 0 Then
'10-14,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AE10") > 0 Then
'10-14,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AF10") > 0 Then
'10-14,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AF10")
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AG10") > 0 Then
'15-19,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AG10")
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AH10") > 0 Then
'15-19,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AH10")
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AI10") > 0 Then
'15-19,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AI10")
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AJ10") > 0 Then
'15-19,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AK10") > 0 Then
'20-24,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AL10") > 0 Then
'20-24,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AM10") > 0 Then
'20-24,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AN10") > 0 Then
'20-24,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AO10") > 0 Then
'25-29,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AP10") > 0 Then
'25-29,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AQ10") > 0 Then
'25-29,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AR10") > 0 Then
'25-29,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AS10") > 0 Then
'30-34,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AT10") > 0 Then
'30-34,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AU10") > 0 Then
'30-34,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AV10") > 0 Then
'30-34,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AW10") > 0 Then
'35-39,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("AW10")
IE.Document.GetElementByID("hvtNfA73XhN-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AX10") > 0 Then
'35-39,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("AX10")
IE.Document.GetElementByID("hvtNfA73XhN-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AY10") > 0 Then
'35-39,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AY10")
IE.Document.GetElementByID("hvtNfA73XhN-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("AZ10") > 0 Then
'35-39,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("AZ10")
IE.Document.GetElementByID("hvtNfA73XhN-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BA10") > 0 Then
'40-44,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
IE.Document.GetElementByID("hvtNfA73XhN-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BB10") > 0 Then
'40-44,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
IE.Document.GetElementByID("hvtNfA73XhN-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BC10") > 0 Then
'40-44,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
IE.Document.GetElementByID("hvtNfA73XhN-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BD10") > 0 Then
'40-44,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
IE.Document.GetElementByID("hvtNfA73XhN-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BE10") > 0 Then
'45-49,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
IE.Document.GetElementByID("hvtNfA73XhN-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BF10") > 0 Then
'45-49,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
IE.Document.GetElementByID("hvtNfA73XhN-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BG10") > 0 Then
'45-49,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
IE.Document.GetElementByID("hvtNfA73XhN-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BH10") > 0 Then
'45-49,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("BH10")
IE.Document.GetElementByID("hvtNfA73XhN-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BI10") > 0 Then
'50+,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("BI10")
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BJ10") > 0 Then
'50+,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("BJ10")
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BK10") > 0 Then
'50+,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("BK10")
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BL10") > 0 Then
'50+,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("BL10")
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("BQ10:BT10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("BQ10") > 0 Then
'1-4,F,Positive
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BQ10")
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BR10") > 0 Then
'1-4,F,Negative
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").Value = ThisWorkbook.Sheets("sheet1").Range("BR10")
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BS10") > 0 Then
'1-4,M,Positive
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BS10")
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BT10") > 0 Then
'1-4,M,Negative
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("BT10")
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("BY10:CP10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("BY10") > 0 Then
'10-14,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").Value = ThisWorkbook.Sheets("sheet1").Range("BY10")
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("BZ10") > 0 Then
'10-14,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("BZ10")
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CA10") > 0 Then
'15-19,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").Value = ThisWorkbook.Sheets("sheet1").Range("CA10")
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CB10") > 0 Then
'15-19,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").Value = ThisWorkbook.Sheets("sheet1").Range("CB10")
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CC10") > 0 Then
'20-24,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").Value = ThisWorkbook.Sheets("sheet1").Range("CC10")
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CD10") > 0 Then
'20-24,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").Value = ThisWorkbook.Sheets("sheet1").Range("CD10")
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CE10") > 0 Then
'25-29,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").Value = ThisWorkbook.Sheets("sheet1").Range("CE10")
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CF10") > 0 Then
'25-29,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").Value = ThisWorkbook.Sheets("sheet1").Range("CF10")
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CG10") > 0 Then
'30-34,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").Value = ThisWorkbook.Sheets("sheet1").Range("CG10")
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CH10") > 0 Then
'30-34,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").Value = ThisWorkbook.Sheets("sheet1").Range("CH10")
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CI10") > 0 Then
'35-39,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("CI10")
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CJ10") > 0 Then
'35-39,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CJ10")
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CK10") > 0 Then
'40-44,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").Value = ThisWorkbook.Sheets("sheet1").Range("CK10")
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CL10") > 0 Then
'40-44,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("CL10")
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CM10") > 0 Then
'45-49,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").Value = ThisWorkbook.Sheets("sheet1").Range("CM10")
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CN10") > 0 Then
'45-49,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").Value = ThisWorkbook.Sheets("sheet1").Range("CN10")
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CO10") > 0 Then
'50+,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").Value = ThisWorkbook.Sheets("sheet1").Range("CO10")
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CP10") > 0 Then
'50+,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").Value = ThisWorkbook.Sheets("sheet1").Range("CP10")
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("CQ10:EL10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("CQ10") > 0 Then
'<1,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CQ10")
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CR10") > 0 Then
'<1,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("CR10")
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CS10") > 0 Then
'<1,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CS10")
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CT10") > 0 Then
'<1,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("CT10")
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CU10") > 0 Then
'1-4,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("CU10")
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CV10") > 0 Then
'1-4,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("CV10")
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CW10") > 0 Then
'1-4,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CW10")
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CX10") > 0 Then
'1-4,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("CX10")
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CY10") > 0 Then
'5-9,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("CY10")
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("CZ10") > 0 Then
'5-9,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("CZ10")
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DA10") > 0 Then
'5-9,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("DA10")
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DB10") > 0 Then
'5-9,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DB10")
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DC10") > 0 Then
'10-14,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("DC10")
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DD10") > 0 Then
'10-14,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DD10")
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DE10") > 0 Then
'10-14,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DE10")
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DF10") > 0 Then
'10-14,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("DF10")
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DG10") > 0 Then
'15-19,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("DG10")
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DH10") > 0 Then
'15-19,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("DH10")
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DI10") > 0 Then
'15-19,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("DI10")
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DJ10") > 0 Then
'15-19,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("DJ10")
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DK10") > 0 Then
'20-24,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("DK10")
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DL10") > 0 Then
'20-24,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("DL10")
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DM10") > 0 Then
'20-24,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("DM10")
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DN10") > 0 Then
'20-24,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("DN10")
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DO10") > 0 Then
'25-29,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("DO10")
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DP10") > 0 Then
'25-29,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("DP10")
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DQ10") > 0 Then
'25-29,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("DQ10")
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DR10") > 0 Then
'25-29,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("DR10")
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DS10") > 0 Then
'30-34,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("DS10")
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DT10") > 0 Then
'30-34,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("DT10")
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DU10") > 0 Then
'30-34,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("DU10")
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DV10") > 0 Then
'30-34,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("DV10")
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DW10") > 0 Then
'35-39,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("DW10")
IE.Document.GetElementByID("m6oDgY6WhM4-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DX10") > 0 Then
'35-39,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("DX10")
IE.Document.GetElementByID("m6oDgY6WhM4-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DY10") > 0 Then
'35-39,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("DY10")
IE.Document.GetElementByID("m6oDgY6WhM4-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("DZ10") > 0 Then
'35-39,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("DZ10")
IE.Document.GetElementByID("m6oDgY6WhM4-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EA10") > 0 Then
'40-44,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("EA10")
IE.Document.GetElementByID("m6oDgY6WhM4-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EB10") > 0 Then
'40-44,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("EB10")
IE.Document.GetElementByID("m6oDgY6WhM4-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EC10") > 0 Then
'40-44,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("EC10")
IE.Document.GetElementByID("m6oDgY6WhM4-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("ED10") > 0 Then
'40-44,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ED10")
IE.Document.GetElementByID("m6oDgY6WhM4-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EE10") > 0 Then
'45-49,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("EE10")
IE.Document.GetElementByID("m6oDgY6WhM4-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EF10") > 0 Then
'45-49,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("EF10")
IE.Document.GetElementByID("m6oDgY6WhM4-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EG10") > 0 Then
'45-49,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("EG10")
IE.Document.GetElementByID("m6oDgY6WhM4-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EH10") > 0 Then
'45-49,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("EH10")
IE.Document.GetElementByID("m6oDgY6WhM4-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EI10") > 0 Then
'50+,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("EI10")
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EJ10") > 0 Then
'50+,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("EJ10")
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EK10") > 0 Then
'50+,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("EK10")
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

If ThisWorkbook.Sheets("sheet1").Range("EL10") > 0 Then
'50+,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("EL10")
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End If

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("EO10:GL10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("EO10") > 0 Then
'Unknown age,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").Value = ThisWorkbook.Sheets("sheet1").Range("EO10")
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EP10") > 0 Then
'Unknown age,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").Value = ThisWorkbook.Sheets("sheet1").Range("EP10")
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EQ10") > 0 Then
'<1,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("EQ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ER10") > 0 Then
'<1,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("ER10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ES10") > 0 Then
'<1,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ES10")
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ET10") > 0 Then
'<1,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("ET10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EU10") > 0 Then
'1-4,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("EU10")
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EV10") > 0 Then
'1-4,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("EV10")
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EW10") > 0 Then
'1-4,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EW10")
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EX10") > 0 Then
'1-4,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("EX10")
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EY10") > 0 Then
'5-9,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("EY10")
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("EZ10") > 0 Then
'5-9,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("EZ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FA10") > 0 Then
'5-9,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("FA10")
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FB10") > 0 Then
'5-9,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("FB10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FC10") > 0 Then
'10-14,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("FC10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FD10") > 0 Then
'10-14,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FD10")
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FE10") > 0 Then
'10-14,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FE10")
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FF10") > 0 Then
'10-14,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("FF10")
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FG10") > 0 Then
'15-19,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("FG10")
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FH10") > 0 Then
'15-19,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("FH10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FI10") > 0 Then
'15-19,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("FI10")
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FJ10") > 0 Then
'15-19,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("FJ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FK10") > 0 Then
'20-24,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("FK10")
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FL10") > 0 Then
'20-24,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("FL10")
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FM10") > 0 Then
'20-24,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("FM10")
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FN10") > 0 Then
'20-24,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("FN10")
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FO10") > 0 Then
'25-29,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("FO10")
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FP10") > 0 Then
'25-29,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("FP10")
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FQ10") > 0 Then
'25-29,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("FQ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FR10") > 0 Then
'25-29,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("FR10")
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FS10") > 0 Then
'30-34,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("FS10")
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FT10") > 0 Then
'30-34,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("FT10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FU10") > 0 Then
'30-34,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("FU10")
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FV10") > 0 Then
'30-34,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("FV10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FW10") > 0 Then
'35-39,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("FW10")
IE.Document.GetElementByID("H7Iu1SBCLTm-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FX10") > 0 Then
'35-39,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("FX10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FY10") > 0 Then
'35-39,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("FY10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("FZ10") > 0 Then
'35-39,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("FZ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GA10") > 0 Then
'40-44,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("GA10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GB10") > 0 Then
'40-44,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("GB10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GC10") > 0 Then
'40-44,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
IE.Document.GetElementByID("H7Iu1SBCLTm-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GD10") > 0 Then
'40-44,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("GD10")
IE.Document.GetElementByID("H7Iu1SBCLTm-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GE10") > 0 Then
'45-49,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("GE10")
IE.Document.GetElementByID("H7Iu1SBCLTm-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GF10") > 0 Then
'45-49,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("GF10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GG10") > 0 Then
'45-49,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("GG10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GH10") > 0 Then
'45-49,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("GH10")
IE.Document.GetElementByID("H7Iu1SBCLTm-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GI10") > 0 Then
'50+,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("GI10")
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GJ10") > 0 Then
'50+,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("GJ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GK10") > 0 Then
'50+,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("GK10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GL10") > 0 Then
'50+,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("GL10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("GM10:IH10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("GM10") > 0 Then
'<1,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("GM10")
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GN10") > 0 Then
'<1,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("GN10")
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GO10") > 0 Then
'<1,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("GO10")
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GP10") > 0 Then
'<1,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("GP10")
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GQ10") > 0 Then
'1-4,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("GQ10")
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GR10") > 0 Then
'1-4,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("GR10")
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GS10") > 0 Then
'1-4,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GS10")
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GT10") > 0 Then
'1-4,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("GT10")
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GU10") > 0 Then
'5-9,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("GU10")
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GV10") > 0 Then
'5-9,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("GV10")
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GW10") > 0 Then
'5-9,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("GW10")
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GX10") > 0 Then
'5-9,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("GX10")
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GY10") > 0 Then
'10-14,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("GY10")
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("GZ10") > 0 Then
'10-14,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GZ10")
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HA10") > 0 Then
'10-14,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HA10")
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HB10") > 0 Then
'10-14,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("HB10")
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HC10") > 0 Then
'15-19,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("HC10")
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HD10") > 0 Then
'15-19,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("HD10")
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HE10") > 0 Then
'15-19,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("HE10")
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HF10") > 0 Then
'15-19,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("HF10")
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HG10") > 0 Then
'20-24,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("HG10")
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HH10") > 0 Then
'20-24,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("HH10")
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HI10") > 0 Then
'20-24,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("HI10")
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HJ10") > 0 Then
'20-24,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("HJ10")
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HK10") > 0 Then
'25-29,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("HK10")
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HL10") > 0 Then
'25-29,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("HL10")
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HM10") > 0 Then
'25-29,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("HM10")
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HN10") > 0 Then
'25-29,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("HN10")
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HO10") > 0 Then
'30-34,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("HO10")
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HP10") > 0 Then
'30-34,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("HP10")
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HQ10") > 0 Then
'30-34,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("HQ10")
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HR10") > 0 Then
'30-34,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("HR10")
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HS10") > 0 Then
'35-39,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("HS10")
IE.Document.GetElementByID("K3I0l3A6fNt-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HT10") > 0 Then
'35-39,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("HT10")
IE.Document.GetElementByID("K3I0l3A6fNt-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HU10") > 0 Then
'35-39,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("HU10")
IE.Document.GetElementByID("K3I0l3A6fNt-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HV10") > 0 Then
'35-39,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HV10")
IE.Document.GetElementByID("K3I0l3A6fNt-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HW10") > 0 Then
'40-44,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("HW10")
IE.Document.GetElementByID("K3I0l3A6fNt-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HX10") > 0 Then
'40-44,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("HX10")
IE.Document.GetElementByID("K3I0l3A6fNt-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HY10") > 0 Then
'40-44,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("HY10")
IE.Document.GetElementByID("K3I0l3A6fNt-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("HZ10") > 0 Then
'40-44,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("HZ10")
IE.Document.GetElementByID("K3I0l3A6fNt-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("IA10") > 0 Then
'45-49,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("IA10")
IE.Document.GetElementByID("K3I0l3A6fNt-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("IB10") > 0 Then
'45-49,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("IB10")
IE.Document.GetElementByID("K3I0l3A6fNt-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("IC10") > 0 Then
'45-49,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("IC10")
IE.Document.GetElementByID("K3I0l3A6fNt-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ID10") > 0 Then
'45-49,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
IE.Document.GetElementByID("K3I0l3A6fNt-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("IE10") > 0 Then
'50+,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("IF10") > 0 Then
'50+,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("IG10") > 0 Then
'50+,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("IH10") > 0 Then
'50+,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if


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

'Offered
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("IJ10:JH10")) > 0 Then
If ThisWorkbook.Sheets("sheet1").Range("IJ10") > 0 Then
'<1,F
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("IJ10")
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                               
If ThisWorkbook.Sheets("sheet1").Range("IK10") > 0 Then
'1-4,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("IK10")
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
   
If ThisWorkbook.Sheets("sheet1").Range("IL10") > 0 Then
'5-9,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("IL10")
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("IM10") > 0 Then
'10-14,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("IM10")
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
      
If ThisWorkbook.Sheets("sheet1").Range("IN10") > 0 Then
'15-19,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("IN10")
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
  
If ThisWorkbook.Sheets("sheet1").Range("IO10") > 0 Then
'20-24,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("IO10")
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
  
If ThisWorkbook.Sheets("sheet1").Range("IP10") > 0 Then
'25-29,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("IP10")
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("IQ10") > 0 Then
'30-34,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("IQ10")
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
  
If ThisWorkbook.Sheets("sheet1").Range("IR10") > 0 Then
'35-39,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("IR10")
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("IS10") > 0 Then
'40-44,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("IS10")
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
 
If ThisWorkbook.Sheets("sheet1").Range("IT10") > 0 Then
'45-49,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("IT10")
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("IU10") > 0 Then
'50+,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("IU10")
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                             
If ThisWorkbook.Sheets("sheet1").Range("IW10") > 0 Then
'<1,M                                                                                                   
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("IW10")
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                      
If ThisWorkbook.Sheets("sheet1").Range("IX10") > 0 Then
'1-4,M                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("IX10")
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                                 
If ThisWorkbook.Sheets("sheet1").Range("IY10") > 0 Then
'5-9,M                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("IY10")
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                        
If ThisWorkbook.Sheets("sheet1").Range("IZ10") > 0 Then
'10-14,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("IZ10")
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                               
If ThisWorkbook.Sheets("sheet1").Range("JA10") > 0 Then
'15-19,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JA10")
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                              
If ThisWorkbook.Sheets("sheet1").Range("JB10") > 0 Then
'20-24,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("JB10")
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                                
If ThisWorkbook.Sheets("sheet1").Range("JC10") > 0 Then
'25-29,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("JC10")
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                           
If ThisWorkbook.Sheets("sheet1").Range("JD10") > 0 Then
'30-34,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("JD10")
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                           
If ThisWorkbook.Sheets("sheet1").Range("JE10") > 0 Then
'35-39,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JE10")
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                             
If ThisWorkbook.Sheets("sheet1").Range("JF10") > 0 Then
'40-44,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JF10")
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                              
If ThisWorkbook.Sheets("sheet1").Range("JG10") > 0 Then
'45-49,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("JG10")
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("JH10") > 0 Then
'50+,M
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("JH10")
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If

'Accepted
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("JJ10:KH10")) > 0 Then
If ThisWorkbook.Sheets("sheet1").Range("JJ10") > 0 Then
'<1,F
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("JJ10")
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                               
If ThisWorkbook.Sheets("sheet1").Range("JK10") > 0 Then
'1-4,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("JK10")
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
   
If ThisWorkbook.Sheets("sheet1").Range("JL10") > 0 Then
'5-9,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("JL10")
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("JM10") > 0 Then
'10-14,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("JM10")
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
      
If ThisWorkbook.Sheets("sheet1").Range("JN10") > 0 Then
'15-19,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("JN10")
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
  
If ThisWorkbook.Sheets("sheet1").Range("JO10") > 0 Then
'20-24,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("JO10")
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
  
If ThisWorkbook.Sheets("sheet1").Range("JP10") > 0 Then
'25-29,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("JP10")
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("JQ10") > 0 Then
'30-34,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("JQ10")
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
  
If ThisWorkbook.Sheets("sheet1").Range("JR10") > 0 Then
'35-39,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("JR10")
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("JS10") > 0 Then
'40-44,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JS10")
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
 
If ThisWorkbook.Sheets("sheet1").Range("JT10") > 0 Then
'45-49,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("JT10")
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
    
If ThisWorkbook.Sheets("sheet1").Range("JU10") > 0 Then
'50+,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("JU10")
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                             
If ThisWorkbook.Sheets("sheet1").Range("JW10") > 0 Then
'<1,M                                                                                                   
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("JW10")
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                      
If ThisWorkbook.Sheets("sheet1").Range("JX10") > 0 Then
'1-4,M                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("JX10")
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                                 
If ThisWorkbook.Sheets("sheet1").Range("JY10") > 0 Then
'5-9,M                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("JY10")
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                        
If ThisWorkbook.Sheets("sheet1").Range("JZ10") > 0 Then
'10-14,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("JZ10")
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                               
If ThisWorkbook.Sheets("sheet1").Range("KA10") > 0 Then
'15-19,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KA10")
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                              
If ThisWorkbook.Sheets("sheet1").Range("KB10") > 0 Then
'20-24,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("KB10")
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                                
If ThisWorkbook.Sheets("sheet1").Range("KC10") > 0 Then
'25-29,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("KC10")
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                           
If ThisWorkbook.Sheets("sheet1").Range("KD10") > 0 Then
'30-34,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("KD10")
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                           
If ThisWorkbook.Sheets("sheet1").Range("KE10") > 0 Then
'35-39,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KE10")
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                             
If ThisWorkbook.Sheets("sheet1").Range("KF10") > 0 Then
'40-44,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("KF10")
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                                                                              
If ThisWorkbook.Sheets("sheet1").Range("KG10") > 0 Then
'45-49,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("KG10")
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("KH10") > 0 Then
'50+,M
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("KH10")
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("KJ10:KN10")) > 0 Then
'Elicited
If ThisWorkbook.Sheets("sheet1").Range("KJ10") > 0 Then
'Unknown age,M
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").Value = ThisWorkbook.Sheets("sheet1").Range("KJ10")
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KK10") > 0 Then
'<15,F,
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").Value = ThisWorkbook.Sheets("sheet1").Range("KK10")
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KL10") > 0 Then
'<15,M
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").Value = ThisWorkbook.Sheets("sheet1").Range("KL10")
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KM10") > 0 Then
'15+,F
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").Value = ThisWorkbook.Sheets("sheet1").Range("KM10")
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KN10") > 0 Then
'15+,M
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").Value = ThisWorkbook.Sheets("sheet1").Range("KN10")
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("KO10:ML10")) > 0 Then
'New Positives
If ThisWorkbook.Sheets("sheet1").Range("KO10") > 0 Then
'Unknown age,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").Value = ThisWorkbook.Sheets("sheet1").Range("KO10")
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KP10") > 0 Then
'<1,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").Value = ThisWorkbook.Sheets("sheet1").Range("KP10")
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KQ10") > 0 Then
'<1,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").Value = ThisWorkbook.Sheets("sheet1").Range("KQ10")
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KR10") > 0 Then
'1-4,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("KR10")
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KS10") > 0 Then
'1-4,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").Value = ThisWorkbook.Sheets("sheet1").Range("KS10")
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KT10") > 0 Then
'5-9,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KT10")
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KU10") > 0 Then
'5-9,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KU10")
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KV10") > 0 Then
'10-14,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("KV10")
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KW10") > 0 Then
'10-14,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").Value = ThisWorkbook.Sheets("sheet1").Range("KW10")
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KX10") > 0 Then
'15-19,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").Value = ThisWorkbook.Sheets("sheet1").Range("KX10")
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KY10") > 0 Then
'15-19,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("KY10")
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("KZ10") > 0 Then
'20-24,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").Value = ThisWorkbook.Sheets("sheet1").Range("KZ10")
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LA10") > 0 Then
'20-24,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("LA10")
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LB10") > 0 Then
'25-29,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").Value = ThisWorkbook.Sheets("sheet1").Range("LB10")
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LC10") > 0 Then
'25-29,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").Value = ThisWorkbook.Sheets("sheet1").Range("LC10")
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LD10") > 0 Then
'30-34,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").Value = ThisWorkbook.Sheets("sheet1").Range("LD10")
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LE10") > 0 Then
'30-34,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").Value = ThisWorkbook.Sheets("sheet1").Range("LE10")
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LF10") > 0 Then
'35-39,F,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-ew4H9zzs0GI-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-ew4H9zzs0GI-val").Value = ThisWorkbook.Sheets("sheet1").Range("LF10")
IE.Document.GetElementByID("Os9GkOOHHJR-ew4H9zzs0GI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("LG10") > 0 Then
'35-39,M,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-eVb1NqOEUoq-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-eVb1NqOEUoq-val").Value = ThisWorkbook.Sheets("sheet1").Range("LG10")
IE.Document.GetElementByID("Os9GkOOHHJR-eVb1NqOEUoq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("LH10") > 0 Then
'40-44,F,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-Ys91wCxDGwp-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-Ys91wCxDGwp-val").Value = ThisWorkbook.Sheets("sheet1").Range("LH10")
IE.Document.GetElementByID("Os9GkOOHHJR-Ys91wCxDGwp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("LI10") > 0 Then
'40-44,M,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-Lq9WappoJ2W-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-Lq9WappoJ2W-val").Value = ThisWorkbook.Sheets("sheet1").Range("LI10")
IE.Document.GetElementByID("Os9GkOOHHJR-Lq9WappoJ2W-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("LJ10") > 0 Then
'45-49,F,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-oBVan2Rcsdj-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-oBVan2Rcsdj-val").Value = ThisWorkbook.Sheets("sheet1").Range("LJ10")
IE.Document.GetElementByID("Os9GkOOHHJR-oBVan2Rcsdj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("LK10") > 0 Then
'45-49,M,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-zzHeHMx5Mh1-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-zzHeHMx5Mh1-val").Value = ThisWorkbook.Sheets("sheet1").Range("LK10")
IE.Document.GetElementByID("Os9GkOOHHJR-zzHeHMx5Mh1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
       
If ThisWorkbook.Sheets("sheet1").Range("LL10") > 0 Then
'50+,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").Value = ThisWorkbook.Sheets("sheet1").Range("LL10")
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LM10") > 0 Then
'50+,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").Value = ThisWorkbook.Sheets("sheet1").Range("LM10")
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

'New Negatives
If ThisWorkbook.Sheets("sheet1").Range("LN10") > 0 Then
'Unknown age,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").Value = ThisWorkbook.Sheets("sheet1").Range("LN10")
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LO10") > 0 Then
'<1,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").Value = ThisWorkbook.Sheets("sheet1").Range("LO10")
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LP10") > 0 Then
'<1,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("LP10")
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LQ10") > 0 Then
'1-4,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").Value = ThisWorkbook.Sheets("sheet1").Range("LQ10")
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LR10") > 0 Then
'1-4,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").Value = ThisWorkbook.Sheets("sheet1").Range("LR10")
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LS10") > 0 Then
'5-9,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("LS10")
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LT10") > 0 Then
'5-9,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").Value = ThisWorkbook.Sheets("sheet1").Range("LT10")
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LU10") > 0 Then
'10-14,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").Value = ThisWorkbook.Sheets("sheet1").Range("LU10")
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LV10") > 0 Then
'10-14,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").Value = ThisWorkbook.Sheets("sheet1").Range("LV10")
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LW10") > 0 Then
'15-19,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").Value = ThisWorkbook.Sheets("sheet1").Range("LW10")
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LX10") > 0 Then
'15-19,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").Value = ThisWorkbook.Sheets("sheet1").Range("LX10")
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LY10") > 0 Then
'20-24,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").Value = ThisWorkbook.Sheets("sheet1").Range("LY10")
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("LZ10") > 0 Then
'20-24,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").Value = ThisWorkbook.Sheets("sheet1").Range("LZ10")
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MA10") > 0 Then
'25-29,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").Value = ThisWorkbook.Sheets("sheet1").Range("MA10")
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MB10") > 0 Then
'25-29,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").Value = ThisWorkbook.Sheets("sheet1").Range("MB10")
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MC10") > 0 Then
'30-34,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").Value = ThisWorkbook.Sheets("sheet1").Range("MC10")
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MD10") > 0 Then
'30-34,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").Value = ThisWorkbook.Sheets("sheet1").Range("MD10")
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ME10") > 0 Then
'35-39,F,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-GNrMxECWqDp-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-GNrMxECWqDp-val").Value = ThisWorkbook.Sheets("sheet1").Range("ME10")
IE.Document.GetElementByID("Os9GkOOHHJR-GNrMxECWqDp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("MF10") > 0 Then
'35-39,M,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-aReRE4UUoKW-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-aReRE4UUoKW-val").Value = ThisWorkbook.Sheets("sheet1").Range("MF10")
IE.Document.GetElementByID("Os9GkOOHHJR-aReRE4UUoKW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("MG10") > 0 Then
'40-44,F,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-XEIYBLvAzIb-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-XEIYBLvAzIb-val").Value = ThisWorkbook.Sheets("sheet1").Range("MG10")
IE.Document.GetElementByID("Os9GkOOHHJR-XEIYBLvAzIb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("MH10") > 0 Then
'40-44,M,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-pVFmF7dKnTq-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-pVFmF7dKnTq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MH10")
IE.Document.GetElementByID("Os9GkOOHHJR-pVFmF7dKnTq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("MI10") > 0 Then
'45-49,F,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-pW32ZkMbRSO-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-pW32ZkMbRSO-val").Value = ThisWorkbook.Sheets("sheet1").Range("MI10")
IE.Document.GetElementByID("Os9GkOOHHJR-pW32ZkMbRSO-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("MJ10") > 0 Then
'45-49,M,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-BiJwnz9vw41-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-BiJwnz9vw41-val").Value = ThisWorkbook.Sheets("sheet1").Range("MJ10")
IE.Document.GetElementByID("Os9GkOOHHJR-BiJwnz9vw41-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MK10") > 0 Then
'50+,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").Value = ThisWorkbook.Sheets("sheet1").Range("MK10")
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ML10") > 0 Then
'50+,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").Value = ThisWorkbook.Sheets("sheet1").Range("ML10")
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If
End Sub
'.................................................................................................................................
'.HHHHH.....HHHHH..HTTTTTTTTTTTTTT..SSSSSSSSSS...........................SSSSSSSSSS....SEEEEEEEEEEEEEE..LLLL..........LFFFFFFFFFFFF..
'.HHHHH.....HHHHH..HTTTTTTTTTTTTTT.SSSSSSSSSSSS.........................SSSSSSSSSSSS...SEEEEEEEEEEEEEE..LLLL..........LFFFFFFFFFFFF..
'.HHHHH.....HHHHH..HTTTTTTTTTTTTTTSSSSSSSSSSSSS........................ SSSSSSSSSSSSS..SEEEEEEEEEEEEEE..LLLL..........LFFFFFFFFFFFF..
'.HHHHH.....HHHHH.......TTTTT.....SSSSSS.SSSSSSS....................... SSSSSS.SSSSSS..SEEEE............LLLL..........LFFFF..........
'.HHHHH.....HHHHH.......TTTTT.....SSSSS....SSSSS....................... SSSS....SSSSS..SEEEE............LLLL..........LFFFF..........
'.HHHHH.....HHHHH.......TTTTT.....SSSSSSS.............................. SSSSSS.........SEEEE............LLLL..........LFFFF..........
'.HHHHH.....HHHHH.......TTTTT.....SSSSSSSSSS........................... SSSSSSSSSS.....SEEEE............LLLL..........LFFFF..........
'.HHHHHHHHHHHHHHH.......TTTTT......SSSSSSSSSSSS.........................SSSSSSSSSSSS...SEEEEEEEEEEEEE...LLLL..........LFFFFFFFFFFF...
'.HHHHHHHHHHHHHHH.......TTTTT.......SSSSSSSSSSSS.........................SSSSSSSSSSSS..SEEEEEEEEEEEEE...LLLL..........LFFFFFFFFFFF...
'.HHHHHHHHHHHHHHH.......TTTTT.........SSSSSSSSSS........ -------...........SSSSSSSSSSS.SEEEEEEEEEEEEE...LLLL..........LFFFFFFFFFFF...
'.HHHHH.....HHHHH.......TTTTT.............SSSSSS........ -------...............SSSSSSS.SEEEE............LLLL..........LFFFF..........
'.HHHHH.....HHHHH.......TTTTT....TSSSS......SSSSS....... -------...... SSSS.....SSSSS.SEEEE............LLLL..........LFFFF..........
'.HHHHH.....HHHHH.......TTTTT....TSSSSS....SSSSSS...................... SSSS.....SSSSS.SEEEE............LLLL..........LFFFF..........
'.HHHHH.....HHHHH.......TTTTT.....SSSSSSSSSSSSSS....................... SSSSSS.SSSSSSS.SEEEE............LLLL..........LFFFF..........
'.HHHHH.....HHHHH.......TTTTT.....SSSSSSSSSSSSSS....................... SSSSSSSSSSSSS..SEEEEEEEEEEEEEE..LLLLLLLLLLLLL.LFFFF..........
'.HHHHH.....HHHHH.......TTTTT......SSSSSSSSSSSS.........................SSSSSSSSSSSSS..SEEEEEEEEEEEEEE..LLLLLLLLLLLLL.LFFFF..........
'.HHHHH.....HHHHH.......TTTTT.......SSSSSSSSSS...........................SSSSSSSSSS....SEEEEEEEEEEEEEE..LLLLLLLLLLLLL.LFFFF..........
'....................................................................................................................................
Sub HTS_Self()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("MN10:NE10")) > 0 Then
If ThisWorkbook.Sheets("sheet1").Range("MN10") > 0 Then
'<10-14 Female
IE.Document.GetElementByID("IvI3KbJILcD-vpJXRljbooI-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-vpJXRljbooI-val").Value = ThisWorkbook.Sheets("sheet1").Range("MN10")
IE.Document.GetElementByID("IvI3KbJILcD-vpJXRljbooI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MO10") > 0 Then
'<15-19 Female
IE.Document.GetElementByID("IvI3KbJILcD-nN1BTeF5WuG-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-nN1BTeF5WuG-val").Value = ThisWorkbook.Sheets("sheet1").Range("MO10")
IE.Document.GetElementByID("IvI3KbJILcD-nN1BTeF5WuG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MP10") > 0 Then
'<20-24 Female
IE.Document.GetElementByID("IvI3KbJILcD-NyElGSpWLWv-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-NyElGSpWLWv-val").Value = ThisWorkbook.Sheets("sheet1").Range("MP10")
IE.Document.GetElementByID("IvI3KbJILcD-NyElGSpWLWv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MQ10") > 0 Then
'<25-29 Female
IE.Document.GetElementByID("IvI3KbJILcD-ptqjXkxioQB-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-ptqjXkxioQB-val").Value = ThisWorkbook.Sheets("sheet1").Range("MQ10")
IE.Document.GetElementByID("IvI3KbJILcD-ptqjXkxioQB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MR10") > 0 Then
'<30-34 Female
IE.Document.GetElementByID("IvI3KbJILcD-sQ2iBuN22yj-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-sQ2iBuN22yj-val").Value = ThisWorkbook.Sheets("sheet1").Range("MR10")
IE.Document.GetElementByID("IvI3KbJILcD-sQ2iBuN22yj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MS10") > 0 Then
'<35-39 Female
IE.Document.GetElementByID("IvI3KbJILcD-U65bkLSdUp7-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-U65bkLSdUp7-val").Value = ThisWorkbook.Sheets("sheet1").Range("MS10")
IE.Document.GetElementByID("IvI3KbJILcD-U65bkLSdUp7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MT10") > 0 Then
'<40-44 Female
IE.Document.GetElementByID("IvI3KbJILcD-U9RGD1yB6AS-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-U9RGD1yB6AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("MT10")
IE.Document.GetElementByID("IvI3KbJILcD-U9RGD1yB6AS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MU10") > 0 Then
'<45-49 Female
IE.Document.GetElementByID("IvI3KbJILcD-UEccZfdUNLf-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-UEccZfdUNLf-val").Value = ThisWorkbook.Sheets("sheet1").Range("MU10")
IE.Document.GetElementByID("IvI3KbJILcD-UEccZfdUNLf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MV10") > 0 Then
'<50+ Female
IE.Document.GetElementByID("IvI3KbJILcD-m9JzOvqcfIX-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-m9JzOvqcfIX-val").Value = ThisWorkbook.Sheets("sheet1").Range("MV10")
IE.Document.GetElementByID("IvI3KbJILcD-m9JzOvqcfIX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MW10") > 0 Then
'<10-14 Male
IE.Document.GetElementByID("IvI3KbJILcD-WvcKCUGBlWW-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-WvcKCUGBlWW-val").Value = ThisWorkbook.Sheets("sheet1").Range("MW10")
IE.Document.GetElementByID("IvI3KbJILcD-WvcKCUGBlWW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MX10") > 0 Then
'<15-19 Male
IE.Document.GetElementByID("IvI3KbJILcD-Mvt3gRxWbl8-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-Mvt3gRxWbl8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MX10")
IE.Document.GetElementByID("IvI3KbJILcD-Mvt3gRxWbl8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MY10") > 0 Then
'<20-24 Male
IE.Document.GetElementByID("IvI3KbJILcD-wS6c6pKnBzB-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-wS6c6pKnBzB-val").Value = ThisWorkbook.Sheets("sheet1").Range("MY10")
IE.Document.GetElementByID("IvI3KbJILcD-wS6c6pKnBzB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("MZ10") > 0 Then
'<25-29 Male
IE.Document.GetElementByID("IvI3KbJILcD-cakoLejWzwq-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-cakoLejWzwq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MZ10")
IE.Document.GetElementByID("IvI3KbJILcD-cakoLejWzwq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NA10") > 0 Then
'<30-34 Male
IE.Document.GetElementByID("IvI3KbJILcD-RZKQIoa9koW-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-RZKQIoa9koW-val").Value = ThisWorkbook.Sheets("sheet1").Range("NA10")
IE.Document.GetElementByID("IvI3KbJILcD-RZKQIoa9koW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NB10") > 0 Then
'<35-39 Male
IE.Document.GetElementByID("IvI3KbJILcD-GoGACmQl6uY-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-GoGACmQl6uY-val").Value = ThisWorkbook.Sheets("sheet1").Range("NB10")
IE.Document.GetElementByID("IvI3KbJILcD-GoGACmQl6uY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NC10") > 0 Then
'<40-44 Male
IE.Document.GetElementByID("IvI3KbJILcD-iUqbs9vu7Uu-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-iUqbs9vu7Uu-val").Value = ThisWorkbook.Sheets("sheet1").Range("NC10")
IE.Document.GetElementByID("IvI3KbJILcD-iUqbs9vu7Uu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ND10") > 0 Then
'<45-49 Male
IE.Document.GetElementByID("IvI3KbJILcD-gqPrEjurqem-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-gqPrEjurqem-val").Value = ThisWorkbook.Sheets("sheet1").Range("ND10")
IE.Document.GetElementByID("IvI3KbJILcD-gqPrEjurqem-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NE10") > 0 Then
'<50+ Male
IE.Document.GetElementByID("IvI3KbJILcD-X7NYFk3xhP8-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-X7NYFk3xhP8-val").Value = ThisWorkbook.Sheets("sheet1").Range("NE10")
IE.Document.GetElementByID("IvI3KbJILcD-X7NYFk3xhP8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if


End If

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("NF10:NW10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("NF10") > 0 Then
'<10-14 Female
IE.Document.GetElementByID("IvI3KbJILcD-ZlfvMsPqqmT-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-ZlfvMsPqqmT-val").Value = ThisWorkbook.Sheets("sheet1").Range("NF10")
IE.Document.GetElementByID("IvI3KbJILcD-ZlfvMsPqqmT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NG10") > 0 Then
'<15-19 Female
IE.Document.GetElementByID("IvI3KbJILcD-tbwp7QwAXxa-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-tbwp7QwAXxa-val").Value = ThisWorkbook.Sheets("sheet1").Range("NG10")
IE.Document.GetElementByID("IvI3KbJILcD-tbwp7QwAXxa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NH10") > 0 Then
'<20-24 Female
IE.Document.GetElementByID("IvI3KbJILcD-mOXqNYPrtUD-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-mOXqNYPrtUD-val").Value = ThisWorkbook.Sheets("sheet1").Range("NH10")
IE.Document.GetElementByID("IvI3KbJILcD-mOXqNYPrtUD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NI10") > 0 Then
'<25-29 Female
IE.Document.GetElementByID("IvI3KbJILcD-Y5oW92HtesZ-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-Y5oW92HtesZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("NI10")
IE.Document.GetElementByID("IvI3KbJILcD-Y5oW92HtesZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NJ10") > 0 Then
'<30-34 Female
IE.Document.GetElementByID("IvI3KbJILcD-onyrqPv9KNE-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-onyrqPv9KNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("NJ10")
IE.Document.GetElementByID("IvI3KbJILcD-onyrqPv9KNE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NK10") > 0 Then
'<35-39 Female
IE.Document.GetElementByID("IvI3KbJILcD-d20MZrn4Eln-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-d20MZrn4Eln-val").Value = ThisWorkbook.Sheets("sheet1").Range("NK10")
IE.Document.GetElementByID("IvI3KbJILcD-d20MZrn4Eln-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NL10") > 0 Then
'<40-44 Female
IE.Document.GetElementByID("IvI3KbJILcD-k7RAtvkyMUR-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-k7RAtvkyMUR-val").Value = ThisWorkbook.Sheets("sheet1").Range("NL10")
IE.Document.GetElementByID("IvI3KbJILcD-k7RAtvkyMUR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NM10") > 0 Then
'<45-49 Female
IE.Document.GetElementByID("IvI3KbJILcD-VPru2f26ZSB-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-VPru2f26ZSB-val").Value = ThisWorkbook.Sheets("sheet1").Range("NM10")
IE.Document.GetElementByID("IvI3KbJILcD-VPru2f26ZSB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NN10") > 0 Then
'<50+ Female
IE.Document.GetElementByID("IvI3KbJILcD-FrSv7fuPqvi-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-FrSv7fuPqvi-val").Value = ThisWorkbook.Sheets("sheet1").Range("NN10")
IE.Document.GetElementByID("IvI3KbJILcD-FrSv7fuPqvi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NO10") > 0 Then
'<10-14 Male
IE.Document.GetElementByID("IvI3KbJILcD-ey60Eh4RyK9-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-ey60Eh4RyK9-val").Value = ThisWorkbook.Sheets("sheet1").Range("NO10")
IE.Document.GetElementByID("IvI3KbJILcD-ey60Eh4RyK9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NP10") > 0 Then
'<15-19 Male
IE.Document.GetElementByID("IvI3KbJILcD-rEyueo9TR84-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-rEyueo9TR84-val").Value = ThisWorkbook.Sheets("sheet1").Range("NP10")
IE.Document.GetElementByID("IvI3KbJILcD-rEyueo9TR84-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NQ10") > 0 Then
'<20-24 Male
IE.Document.GetElementByID("IvI3KbJILcD-iPgWd22TJoU-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-iPgWd22TJoU-val").Value = ThisWorkbook.Sheets("sheet1").Range("NQ10")
IE.Document.GetElementByID("IvI3KbJILcD-iPgWd22TJoU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NR10") > 0 Then
'<25-29 Male
IE.Document.GetElementByID("IvI3KbJILcD-yrwFtriUxF7-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-yrwFtriUxF7-val").Value = ThisWorkbook.Sheets("sheet1").Range("NR10")
IE.Document.GetElementByID("IvI3KbJILcD-yrwFtriUxF7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NS10") > 0 Then
'<30-34 Male
IE.Document.GetElementByID("IvI3KbJILcD-QKbiiiEUYIO-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-QKbiiiEUYIO-val").Value = ThisWorkbook.Sheets("sheet1").Range("NS10")
IE.Document.GetElementByID("IvI3KbJILcD-QKbiiiEUYIO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NT10") > 0 Then
'<35-39 Male
IE.Document.GetElementByID("IvI3KbJILcD-F3VzQk7J54W-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-F3VzQk7J54W-val").Value = ThisWorkbook.Sheets("sheet1").Range("NT10")
IE.Document.GetElementByID("IvI3KbJILcD-F3VzQk7J54W-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NU10") > 0 Then
'<40-44 Male
IE.Document.GetElementByID("IvI3KbJILcD-O9nOl3oQyBF-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-O9nOl3oQyBF-val").Value = ThisWorkbook.Sheets("sheet1").Range("NU10")
IE.Document.GetElementByID("IvI3KbJILcD-O9nOl3oQyBF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NV10") > 0 Then
'<45-49 Male
IE.Document.GetElementByID("IvI3KbJILcD-Oyo1mxlQwOh-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-Oyo1mxlQwOh-val").Value = ThisWorkbook.Sheets("sheet1").Range("NV10")
IE.Document.GetElementByID("IvI3KbJILcD-Oyo1mxlQwOh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("NW10") > 0 Then
'<50+ Male
IE.Document.GetElementByID("IvI3KbJILcD-yy0VIRCYJy9-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-yy0VIRCYJy9-val").Value = ThisWorkbook.Sheets("sheet1").Range("NW10")
IE.Document.GetElementByID("IvI3KbJILcD-yy0VIRCYJy9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("NX10:OG10")) > 0 Then
If ThisWorkbook.Sheets("sheet1").Range("NX10") > 0 Then
'<PWID  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-cVQALQbbdeJ-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-cVQALQbbdeJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("NX10")
IE.Document.GetElementByID("CfSIX5yTSdw-cVQALQbbdeJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OC10") > 0 Then
'<PWID  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-lm6WNi1cnU4-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-lm6WNi1cnU4-val").Value = ThisWorkbook.Sheets("sheet1").Range("OC10")
IE.Document.GetElementByID("CfSIX5yTSdw-lm6WNi1cnU4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if


If ThisWorkbook.Sheets("sheet1").Range("NY10") > 0 Then
'<MSM  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-jEDTO4WJAzl-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-jEDTO4WJAzl-val").Value = ThisWorkbook.Sheets("sheet1").Range("NY10")
IE.Document.GetElementByID("CfSIX5yTSdw-jEDTO4WJAzl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OD10") > 0 Then
'<MSM  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-t4teq5No1lb-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-t4teq5No1lb-val").Value = ThisWorkbook.Sheets("sheet1").Range("OD10")
IE.Document.GetElementByID("CfSIX5yTSdw-t4teq5No1lb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if


If ThisWorkbook.Sheets("sheet1").Range("NZ10") > 0 Then
'<Transgender People  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-URR9fz0msKi-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-URR9fz0msKi-val").Value = ThisWorkbook.Sheets("sheet1").Range("NZ10")
IE.Document.GetElementByID("CfSIX5yTSdw-URR9fz0msKi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OE10") > 0 Then
'<Transgender People  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-tR1agKinTUi-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-tR1agKinTUi-val").Value = ThisWorkbook.Sheets("sheet1").Range("OE10")
IE.Document.GetElementByID("CfSIX5yTSdw-tR1agKinTUi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if


If ThisWorkbook.Sheets("sheet1").Range("OA10") > 0 Then
'<FSW  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-oT1KinoX60T-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-oT1KinoX60T-val").Value = ThisWorkbook.Sheets("sheet1").Range("OA10")
IE.Document.GetElementByID("CfSIX5yTSdw-oT1KinoX60T-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OF10") > 0 Then
'<FSW  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-UpkVZP5xLHK-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-UpkVZP5xLHK-val").Value = ThisWorkbook.Sheets("sheet1").Range("OF10")
IE.Document.GetElementByID("CfSIX5yTSdw-UpkVZP5xLHK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if


If ThisWorkbook.Sheets("sheet1").Range("OB10") > 0 Then
'<People in prison and other closed settings  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-z9AHJ7VXAUI-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-z9AHJ7VXAUI-val").Value = ThisWorkbook.Sheets("sheet1").Range("OB10")
IE.Document.GetElementByID("CfSIX5yTSdw-z9AHJ7VXAUI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OG10") > 0 Then
'<People in prison and other closed settings  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-bZVkZBLtX1i-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-bZVkZBLtX1i-val").Value = ThisWorkbook.Sheets("sheet1").Range("OG10")
IE.Document.GetElementByID("CfSIX5yTSdw-bZVkZBLtX1i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("OI10:OJ10")) > 0 Then
'<Unassisted self-testing kit used by: Self
'IE.Document.GetElementByID("ovQaECwOS1M-mYMRmrtoxVn-val").Focus
'IE.Document.GetElementByID("ovQaECwOS1M-mYMRmrtoxVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("OH10")
'IE.Document.GetElementByID("ovQaECwOS1M-mYMRmrtoxVn-val").dispatchEvent evt
'Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))

If ThisWorkbook.Sheets("sheet1").Range("OI10") > 0 Then
'<Unassisted self-testing kit used by: Sex Partner
IE.Document.GetElementByID("ovQaECwOS1M-loZmPoGpvEZ-val").Focus
IE.Document.GetElementByID("ovQaECwOS1M-loZmPoGpvEZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OI10")
IE.Document.GetElementByID("ovQaECwOS1M-loZmPoGpvEZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OJ10") > 0 Then
'<Unassisted self-testing kit used by: Other
IE.Document.GetElementByID("ovQaECwOS1M-fPFQkPZwhi8-val").Focus
IE.Document.GetElementByID("ovQaECwOS1M-fPFQkPZwhi8-val").Value = ThisWorkbook.Sheets("sheet1").Range("OJ10")
IE.Document.GetElementByID("ovQaECwOS1M-fPFQkPZwhi8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

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

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("OL10:OW10")) > 0 Then
'Numerator
If ThisWorkbook.Sheets("sheet1").Range("OL10") > 0 Then
'10-14,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").Value = ThisWorkbook.Sheets("sheet1").Range("OL10")
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OM10") > 0 Then
'10-14,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").Value = ThisWorkbook.Sheets("sheet1").Range("OM10")
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ON10") > 0 Then
'10-14,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").Value = ThisWorkbook.Sheets("sheet1").Range("ON10")
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OO10") > 0 Then
'15-19,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").Value = ThisWorkbook.Sheets("sheet1").Range("OO10")
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OP10") > 0 Then
'15-19,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").Value = ThisWorkbook.Sheets("sheet1").Range("OP10")
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OQ10") > 0 Then
'15-19,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").Value = ThisWorkbook.Sheets("sheet1").Range("OQ10")
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OR10") > 0 Then
'20-24,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").Value = ThisWorkbook.Sheets("sheet1").Range("OR10")
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OS10") > 0 Then
'20-24,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").Value = ThisWorkbook.Sheets("sheet1").Range("OS10")
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OT10") > 0 Then
'20-24,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OU10") > 0 Then
'25-29,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").Value = ThisWorkbook.Sheets("sheet1").Range("OU10")
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OV10") > 0 Then
'25-29,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").Value = ThisWorkbook.Sheets("sheet1").Range("OV10")
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OW10") > 0 Then
'25-29,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").Value = ThisWorkbook.Sheets("sheet1").Range("OW10")
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End if
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("OY10:PB10")) > 0 Then
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("OY10") > 0 Then
'10-14,F
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").Value = ThisWorkbook.Sheets("sheet1").Range("OY10")
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("OZ10") > 0 Then
'15-19,F
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OZ10")
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("PA10") > 0 Then
'20-24,F
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("PA10")
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("PB10") > 0 Then
'25-29,F
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").Value = ThisWorkbook.Sheets("sheet1").Range("PB10")
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("PD10:PE10")) > 0 Then
'EID
If ThisWorkbook.Sheets("sheet1").Range("PD10") > 0 Then
'0-2
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Value = ThisWorkbook.Sheets("sheet1").Range("PD10")
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("PE10") > 0 Then
'2-12
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Value = ThisWorkbook.Sheets("sheet1").Range("PE10")
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End if
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("PG10:PJ10")) > 0 Then
'HEI_POS
If ThisWorkbook.Sheets("sheet1").Range("PG10") > 0 Then
'0-2
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Value = ThisWorkbook.Sheets("sheet1").Range("PG10")
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("PH10") > 0 Then
'2-12
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("PH10")
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

'ART
If ThisWorkbook.Sheets("sheet1").Range("PI10") > 0 Then
'0-2
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Value = ThisWorkbook.Sheets("sheet1").Range("PI10")
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("PJ10") > 0 Then
'2-12
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Value = ThisWorkbook.Sheets("sheet1").Range("PJ10")
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

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

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("PL10:QI10")) > 0 Then
'Known Positives
If ThisWorkbook.Sheets("sheet1").Range("PL10") > 0 Then
'<1,F,KP
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").Value = ThisWorkbook.Sheets("sheet1").Range("PL10")
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("PM10") > 0 Then
'<1,M,KP
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PM10")
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PN10") > 0 Then
'1-4,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").Value = ThisWorkbook.Sheets("sheet1").Range("PN10")
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PO10") > 0 Then
'1-4,M,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").Value = ThisWorkbook.Sheets("sheet1").Range("PO10")
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PP10") > 0 Then
'5-9,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").Value = ThisWorkbook.Sheets("sheet1").Range("PP10")
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PQ10") > 0 Then
'5-9,M,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").Value = ThisWorkbook.Sheets("sheet1").Range("PQ10")
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PR10") > 0 Then
'10-14,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").Value = ThisWorkbook.Sheets("sheet1").Range("PR10")
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PS10") > 0 Then
'10-14,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").Value = ThisWorkbook.Sheets("sheet1").Range("PS10")
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PT10") > 0 Then
'15-19,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").Value = ThisWorkbook.Sheets("sheet1").Range("PT10")
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PU10") > 0 Then
'15-19,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").Value = ThisWorkbook.Sheets("sheet1").Range("PU10")
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PV10") > 0 Then
'20-24,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("PV10")
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PW10") > 0 Then
'20-24,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").Value = ThisWorkbook.Sheets("sheet1").Range("PW10")
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PX10") > 0 Then
'25-29,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").Value = ThisWorkbook.Sheets("sheet1").Range("PX10")
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PY10") > 0 Then
'25-29,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").Value = ThisWorkbook.Sheets("sheet1").Range("PY10")
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("PZ10") > 0 Then
'30-34,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").Value = ThisWorkbook.Sheets("sheet1").Range("PZ10")
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QA10") > 0 Then
'30-34,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").Value = ThisWorkbook.Sheets("sheet1").Range("QA10")
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QB10") > 0 Then
'35-39,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").Value = ThisWorkbook.Sheets("sheet1").Range("QB10")
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QC10") > 0 Then
'35-39,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").Value = ThisWorkbook.Sheets("sheet1").Range("QC10")
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QD10") > 0 Then
'40-44,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").Value = ThisWorkbook.Sheets("sheet1").Range("QD10")
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QE10") > 0 Then
'40-44,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").Value = ThisWorkbook.Sheets("sheet1").Range("QE10")
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QF10") > 0 Then
'45-49,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").Value = ThisWorkbook.Sheets("sheet1").Range("QF10")
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QG10") > 0 Then
'45-49,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").Value = ThisWorkbook.Sheets("sheet1").Range("QG10")
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QH10") > 0 Then
'50+,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").Value = ThisWorkbook.Sheets("sheet1").Range("QH10")
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("QI10") > 0 Then
'50+,M,KP
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").Value = ThisWorkbook.Sheets("sheet1").Range("QI10")
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("QJ10:RG10")) > 0 Then
'New Positives
If ThisWorkbook.Sheets("sheet1").Range("QJ10") > 0 Then
'<1,F,NP
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").Value = ThisWorkbook.Sheets("sheet1").Range("QJ10")
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("QK10") > 0 Then
'<1,M,NP
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").Value = ThisWorkbook.Sheets("sheet1").Range("QK10")
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("QL10") > 0 Then
'1-4,F,NP
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("QL10")
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("QM10") > 0 Then
'1-4,M,NP
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").Value = ThisWorkbook.Sheets("sheet1").Range("QM10")
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QN10") > 0 Then
'5-9,F,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").Value = ThisWorkbook.Sheets("sheet1").Range("QN10")
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QO10") > 0 Then
'5-9,M,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").Value = ThisWorkbook.Sheets("sheet1").Range("QO10")
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QP10") > 0 Then
'10-14,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("QP10")
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QQ10") > 0 Then
'10-14,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").Value = ThisWorkbook.Sheets("sheet1").Range("QQ10")
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QR10") > 0 Then
'15-19,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").Value = ThisWorkbook.Sheets("sheet1").Range("QR10")
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QS10") > 0 Then
'15-19,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("QS10")
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QT10") > 0 Then
'20-24,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").Value = ThisWorkbook.Sheets("sheet1").Range("QT10")
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QU10") > 0 Then
'20-24,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("QU10")
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QV10") > 0 Then
'25-29,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").Value = ThisWorkbook.Sheets("sheet1").Range("QV10")
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QW10") > 0 Then
'25-29,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").Value = ThisWorkbook.Sheets("sheet1").Range("QW10")
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QX10") > 0 Then
'30-34,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").Value = ThisWorkbook.Sheets("sheet1").Range("QX10")
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QY10") > 0 Then
'30-34,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").Value = ThisWorkbook.Sheets("sheet1").Range("QY10")
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("QZ10") > 0 Then
'35-39,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").Value = ThisWorkbook.Sheets("sheet1").Range("QZ10")
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RA10") > 0 Then
'35-39,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").Value = ThisWorkbook.Sheets("sheet1").Range("RA10")
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RB10") > 0 Then
'40-44,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").Value = ThisWorkbook.Sheets("sheet1").Range("RB10")
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RC10") > 0 Then
'40-44,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").Value = ThisWorkbook.Sheets("sheet1").Range("RC10")
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RD10") > 0 Then
'45-49,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RD10")
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RE10") > 0 Then
'45-49,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").Value = ThisWorkbook.Sheets("sheet1").Range("RE10")
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RF10") > 0 Then
'50+,F,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RF10")
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("RG10") > 0 Then
'50+,M,NP
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").Value = ThisWorkbook.Sheets("sheet1").Range("RG10")
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("RH10:SE10")) > 0 Then
'New Negatives
If ThisWorkbook.Sheets("sheet1").Range("RH10") > 0 Then
'<1,F,NN
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").Value = ThisWorkbook.Sheets("sheet1").Range("RH10")
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("RI10") > 0 Then
'<1,M,NN
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("RI10")
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("RJ10") > 0 Then
'1-4,F,NN
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").Value = ThisWorkbook.Sheets("sheet1").Range("RJ10")
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("RK10") > 0 Then
'1-4,M,NN
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").Value = ThisWorkbook.Sheets("sheet1").Range("RK10")
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("RL10") > 0 Then
'5-9,F,NN
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("RL10")
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("RM10") > 0 Then
'5-9,M,NN
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").Value = ThisWorkbook.Sheets("sheet1").Range("RM10")
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("RN10") > 0 Then
'10-14,F,NN
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").Value = ThisWorkbook.Sheets("sheet1").Range("RN10")
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RO10") > 0 Then
'10-14,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").Value = ThisWorkbook.Sheets("sheet1").Range("RO10")
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RP10") > 0 Then
'15-19,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").Value = ThisWorkbook.Sheets("sheet1").Range("RP10")
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RQ10") > 0 Then
'15-19,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").Value = ThisWorkbook.Sheets("sheet1").Range("RQ10")
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RR10") > 0 Then
'20-24,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").Value = ThisWorkbook.Sheets("sheet1").Range("RR10")
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RS10") > 0 Then
'20-24,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").Value = ThisWorkbook.Sheets("sheet1").Range("RS10")
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RT10") > 0 Then
'25-29,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").Value = ThisWorkbook.Sheets("sheet1").Range("RT10")
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RU10") > 0 Then
'25-29,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").Value = ThisWorkbook.Sheets("sheet1").Range("RU10")
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RV10") > 0 Then
'30-34,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RV10")
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RW10") > 0 Then
'30-34,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").Value = ThisWorkbook.Sheets("sheet1").Range("RW10")
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RX10") > 0 Then
'35-39,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").Value = ThisWorkbook.Sheets("sheet1").Range("RX10")
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RY10") > 0 Then
'35-39,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").Value = ThisWorkbook.Sheets("sheet1").Range("RY10")
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("RZ10") > 0 Then
'40-44,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").Value = ThisWorkbook.Sheets("sheet1").Range("RZ10")
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SA10") > 0 Then
'40-44,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SA10")
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SB10") > 0 Then
'45-49,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").Value = ThisWorkbook.Sheets("sheet1").Range("SB10")
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SC10") > 0 Then
'45-49,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").Value = ThisWorkbook.Sheets("sheet1").Range("SC10")
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("SD10") > 0 Then
'50+,F,NN
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").Value = ThisWorkbook.Sheets("sheet1").Range("SD10")
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("SE10") > 0 Then
'50+,M,NN
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").Value = ThisWorkbook.Sheets("sheet1").Range("SE10")
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

End If
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("SG10:TD10")) > 0 Then
'Denominator
If ThisWorkbook.Sheets("sheet1").Range("SG10") > 0 Then
'<1,F
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("SG10")
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SH10") > 0 Then
'<1,M                                                                                                   
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("SH10")
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SI10") > 0 Then
'1-4,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("SI10")
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SJ10") > 0 Then
'1-4,M                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("SJ10")
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SK10") > 0 Then
'5-9,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("SK10")
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SL10") > 0 Then
'5-9,M                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("SL10")
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SM10") > 0 Then
'10-14,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("SM10")
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SN10") > 0 Then
'10-14,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("SN10")
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SO10") > 0 Then
'15-19,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("SO10")
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SP10") > 0 Then
'15-19,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("SP10")
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SQ10") > 0 Then
'20-24,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("SQ10")
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SR10") > 0 Then
'20-24,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("SR10")
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SS10") > 0 Then
'25-29,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("SS10")
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("ST10") > 0 Then
'25-29,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ST10")
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SU10") > 0 Then
'30-34,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("SU10")
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SV10") > 0 Then
'30-34,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SV10")
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SW10") > 0 Then
'35-39,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("SW10")
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SX10") > 0 Then
'35-39,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("SX10")
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SY10") > 0 Then
'40-44,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SY10")
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("SZ10") > 0 Then
'40-44,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SZ10")
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("TA10") > 0 Then
'45-49,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TA10")
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("TB10") > 0 Then
'45-49,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TB10")
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if
                                                            
If ThisWorkbook.Sheets("sheet1").Range("TC10") > 0 Then
'50+,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("TC10")
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TD10") > 0 Then
'50+,M
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("TD10")
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((6 - 3 + 1) * Rnd + 3))
End if

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

If ThisWorkbook.Sheets("sheet1").Range("TF10") > 0 Then
'Breastfeeding
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("TF10")
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End If


If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("UE10:UH10")) = 0 Then
If ThisWorkbook.Sheets("sheet1").Range("TG10") > 0 Then
'<1,F
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").Value = ThisWorkbook.Sheets("sheet1").Range("TG10")
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TH10") > 0 Then
'1-4,F
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").Value = ThisWorkbook.Sheets("sheet1").Range("TH10")
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TI10") > 0 Then
'5-9,F
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").Value = ThisWorkbook.Sheets("sheet1").Range("TI10")
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TJ10") > 0 Then
'10-14,F
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").Value = ThisWorkbook.Sheets("sheet1").Range("TJ10")
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TK10") > 0 Then
'15-19,F
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").Value = ThisWorkbook.Sheets("sheet1").Range("TK10")
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TL10") > 0 Then
'20-24,F
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").Value = ThisWorkbook.Sheets("sheet1").Range("TL10")
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TM10") > 0 Then
'25-29,F
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").Value = ThisWorkbook.Sheets("sheet1").Range("TM10")
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TN10") > 0 Then
'30-34,F
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").Value = ThisWorkbook.Sheets("sheet1").Range("TN10")
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TO10") > 0 Then
'35-39,F
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").Value = ThisWorkbook.Sheets("sheet1").Range("TO10")
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TP10") > 0 Then
'40-44,F
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").Value = ThisWorkbook.Sheets("sheet1").Range("TP10")
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TQ10") > 0 Then
'45-49,F
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TQ10")
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TR10") > 0 Then
'50+,F
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").Value = ThisWorkbook.Sheets("sheet1").Range("TR10")
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TS10") > 0 Then
'<1,M
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").Value = ThisWorkbook.Sheets("sheet1").Range("TS10")
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TT10") > 0 Then
'1-4,M
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").Value = ThisWorkbook.Sheets("sheet1").Range("TT10")
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TU10") > 0 Then
'5-9,M
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").Value = ThisWorkbook.Sheets("sheet1").Range("TU10")
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TV10") > 0 Then
'10-14,M
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").Value = ThisWorkbook.Sheets("sheet1").Range("TV10")
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TW10") > 0 Then
'15-19,M
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").Value = ThisWorkbook.Sheets("sheet1").Range("TW10")
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TX10") > 0 Then
'20-24,M
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").Value = ThisWorkbook.Sheets("sheet1").Range("TX10")
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TY10") > 0 Then
'25-29,M
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").Value = ThisWorkbook.Sheets("sheet1").Range("TY10")
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("TZ10") > 0 Then
'30-34,M
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").Value = ThisWorkbook.Sheets("sheet1").Range("TZ10")
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UA10") > 0 Then
'35-39,M
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("UA10")
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UB10") > 0 Then
'40-44,M
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("UB10")
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UC10") > 0 Then
'45-49,M
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").Value = ThisWorkbook.Sheets("sheet1").Range("UC10")
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UD10") > 0 Then
'50+,M
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").Value = ThisWorkbook.Sheets("sheet1").Range("UD10")
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

Else

If ThisWorkbook.Sheets("sheet1").Range("UE10") > 0 Then
'<15,F
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("UE10")
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UF10") > 0 Then
'15+,F
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("UF10")
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UG10") > 0 Then
'<15,M
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("UG10")
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UH10") > 0 Then
'15+,M
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("UH10")
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

End if

'Disaggregated by key population type
If ThisWorkbook.Sheets("sheet1").Range("UI10") > 0 Then
'PWID 
IE.Document.GetElementByID("u3Whcy4Frlt-FyhQbdBMM1p-val").Focus
IE.Document.GetElementByID("u3Whcy4Frlt-FyhQbdBMM1p-val").Value = ThisWorkbook.Sheets("sheet1").Range("UI10")
IE.Document.GetElementByID("u3Whcy4Frlt-FyhQbdBMM1p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UJ10") > 0 Then
'MSM
IE.Document.GetElementByID("u3Whcy4Frlt-wbJ9Nh2jqUG-val").Focus
IE.Document.GetElementByID("u3Whcy4Frlt-wbJ9Nh2jqUG-val").Value = ThisWorkbook.Sheets("sheet1").Range("UJ10")
IE.Document.GetElementByID("u3Whcy4Frlt-wbJ9Nh2jqUG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UK10") > 0 Then
'TG
IE.Document.GetElementByID("u3Whcy4Frlt-fCiy8R7Dv9x-val").Focus
IE.Document.GetElementByID("u3Whcy4Frlt-fCiy8R7Dv9x-val").Value = ThisWorkbook.Sheets("sheet1").Range("UK10")
IE.Document.GetElementByID("u3Whcy4Frlt-fCiy8R7Dv9x-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UL10") > 0 Then
'FSW
IE.Document.GetElementByID("u3Whcy4Frlt-dUCNvz8ByrS-val").Focus
IE.Document.GetElementByID("u3Whcy4Frlt-dUCNvz8ByrS-val").Value = ThisWorkbook.Sheets("sheet1").Range("UL10")
IE.Document.GetElementByID("u3Whcy4Frlt-dUCNvz8ByrS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UM10") > 0 Then
'PRISON
IE.Document.GetElementByID("u3Whcy4Frlt-VCEoYHLyTxk-val").Focus
IE.Document.GetElementByID("u3Whcy4Frlt-VCEoYHLyTxk-val").Value = ThisWorkbook.Sheets("sheet1").Range("UM10")
IE.Document.GetElementByID("u3Whcy4Frlt-VCEoYHLyTxk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

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

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("VM10:VP10")) = 0 Then
If ThisWorkbook.Sheets("sheet1").Range("UO10") > 0 Then
'<1,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").Value = ThisWorkbook.Sheets("sheet1").Range("UO10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UP10") > 0 Then
'1-4,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").Value = ThisWorkbook.Sheets("sheet1").Range("UP10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UQ10") > 0 Then
'5-9,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").Value = ThisWorkbook.Sheets("sheet1").Range("UQ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UR10") > 0 Then
'10-14,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").Value = ThisWorkbook.Sheets("sheet1").Range("UR10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("US10") > 0 Then
'15-19,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").Value = ThisWorkbook.Sheets("sheet1").Range("US10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UT10") > 0 Then
'20-24,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").Value = ThisWorkbook.Sheets("sheet1").Range("UT10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UU10") > 0 Then
'25-29,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").Value = ThisWorkbook.Sheets("sheet1").Range("UU10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UV10") > 0 Then
'30-34,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").Value = ThisWorkbook.Sheets("sheet1").Range("UV10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UW10") > 0 Then
'35-39,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").Value = ThisWorkbook.Sheets("sheet1").Range("UW10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UX10") > 0 Then
'40-44,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").Value = ThisWorkbook.Sheets("sheet1").Range("UX10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UY10") > 0 Then
'45-49,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").Value = ThisWorkbook.Sheets("sheet1").Range("UY10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("UZ10") > 0 Then
'50+,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").Value = ThisWorkbook.Sheets("sheet1").Range("UZ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VA10") > 0 Then
'<1,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").Value = ThisWorkbook.Sheets("sheet1").Range("VA10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VB10") > 0 Then
'1-4,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").Value = ThisWorkbook.Sheets("sheet1").Range("VB10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VC10") > 0 Then
'5-9,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").Value = ThisWorkbook.Sheets("sheet1").Range("VC10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VD10") > 0 Then
'10-14,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").Value = ThisWorkbook.Sheets("sheet1").Range("VD10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VE10") > 0 Then
'15-19,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").Value = ThisWorkbook.Sheets("sheet1").Range("VE10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VF10") > 0 Then
'20-24,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").Value = ThisWorkbook.Sheets("sheet1").Range("VF10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VG10") > 0 Then
'25-29,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").Value = ThisWorkbook.Sheets("sheet1").Range("VG10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VH10") > 0 Then
'30-34,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").Value = ThisWorkbook.Sheets("sheet1").Range("VH10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VI10") > 0 Then
'35-39,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("VI10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VJ10") > 0 Then
'40-44,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("VJ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VK10") > 0 Then
'45-49,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").Value = ThisWorkbook.Sheets("sheet1").Range("VK10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VL10") > 0 Then
'50+,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").Value = ThisWorkbook.Sheets("sheet1").Range("VL10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

Else

If ThisWorkbook.Sheets("sheet1").Range("VM10") > 0 Then
'<15,F
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("VM10")
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VN10") > 0 Then
'15+,F
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("VN10")
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VO10") > 0 Then
'<15,M
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("VO10")
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VP10") > 0 Then
'15+,M
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("VP10")
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

End if

'Disaggregated by key population type
If ThisWorkbook.Sheets("sheet1").Range("VQ10") > 0 Then
'PWID 
IE.Document.GetElementByID("ScQASwweWXL-FyhQbdBMM1p-val").Focus
IE.Document.GetElementByID("ScQASwweWXL-FyhQbdBMM1p-val").Value = ThisWorkbook.Sheets("sheet1").Range("VQ10")
IE.Document.GetElementByID("ScQASwweWXL-FyhQbdBMM1p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VR10") > 0 Then
'MSM
IE.Document.GetElementByID("ScQASwweWXL-wbJ9Nh2jqUG-val").Focus
IE.Document.GetElementByID("ScQASwweWXL-wbJ9Nh2jqUG-val").Value = ThisWorkbook.Sheets("sheet1").Range("VR10")
IE.Document.GetElementByID("ScQASwweWXL-wbJ9Nh2jqUG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VS10") > 0 Then
'TG
IE.Document.GetElementByID("ScQASwweWXL-fCiy8R7Dv9x-val").Focus
IE.Document.GetElementByID("ScQASwweWXL-fCiy8R7Dv9x-val").Value = ThisWorkbook.Sheets("sheet1").Range("VS10")
IE.Document.GetElementByID("ScQASwweWXL-fCiy8R7Dv9x-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VT10") > 0 Then
'FSW
IE.Document.GetElementByID("ScQASwweWXL-dUCNvz8ByrS-val").Focus
IE.Document.GetElementByID("ScQASwweWXL-dUCNvz8ByrS-val").Value = ThisWorkbook.Sheets("sheet1").Range("VT10")
IE.Document.GetElementByID("ScQASwweWXL-dUCNvz8ByrS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VU10") > 0 Then
'PRISON
IE.Document.GetElementByID("ScQASwweWXL-VCEoYHLyTxk-val").Focus
IE.Document.GetElementByID("ScQASwweWXL-VCEoYHLyTxk-val").Value = ThisWorkbook.Sheets("sheet1").Range("VU10")
IE.Document.GetElementByID("ScQASwweWXL-VCEoYHLyTxk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if


'Disaggregated by ARV Dispensing Quantity by Coarse Age/Sex
'<3 months of ARVs (not MMD)
If ThisWorkbook.Sheets("sheet1").Range("VV10") > 0 Then
'F<15
IE.Document.GetElementByID("TjPwm5FAwoE-nyOuOyIWz1j-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-nyOuOyIWz1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("VV10")
IE.Document.GetElementByID("TjPwm5FAwoE-nyOuOyIWz1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VW10") > 0 Then
'F<15+
IE.Document.GetElementByID("TjPwm5FAwoE-DIHSb7sDAdx-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-DIHSb7sDAdx-val").Value = ThisWorkbook.Sheets("sheet1").Range("VW10")
IE.Document.GetElementByID("TjPwm5FAwoE-DIHSb7sDAdx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VX10") > 0 Then
'M<15
IE.Document.GetElementByID("TjPwm5FAwoE-KBabS6dmzeX-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-KBabS6dmzeX-val").Value = ThisWorkbook.Sheets("sheet1").Range("VX10")
IE.Document.GetElementByID("TjPwm5FAwoE-KBabS6dmzeX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("VY10") > 0 Then
'M<15+
IE.Document.GetElementByID("TjPwm5FAwoE-lPz9wTFy34l-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-lPz9wTFy34l-val").Value = ThisWorkbook.Sheets("sheet1").Range("VY10")
IE.Document.GetElementByID("TjPwm5FAwoE-lPz9wTFy34l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'3-5 months of ARVs
If ThisWorkbook.Sheets("sheet1").Range("VZ10") > 0 Then
'F<15
IE.Document.GetElementByID("TjPwm5FAwoE-FujzW8ejTb6-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-FujzW8ejTb6-val").Value = ThisWorkbook.Sheets("sheet1").Range("VZ10")
IE.Document.GetElementByID("TjPwm5FAwoE-FujzW8ejTb6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WA10") > 0 Then
'F<15+
IE.Document.GetElementByID("TjPwm5FAwoE-zis92j8IxWw-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-zis92j8IxWw-val").Value = ThisWorkbook.Sheets("sheet1").Range("WA10")
IE.Document.GetElementByID("TjPwm5FAwoE-zis92j8IxWw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WB10") > 0 Then
'M<15
IE.Document.GetElementByID("TjPwm5FAwoE-LavQWaDxw65-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-LavQWaDxw65-val").Value = ThisWorkbook.Sheets("sheet1").Range("WB10")
IE.Document.GetElementByID("TjPwm5FAwoE-LavQWaDxw65-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WC10") > 0 Then
'M<15+
IE.Document.GetElementByID("TjPwm5FAwoE-rsmnUja7gKQ-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-rsmnUja7gKQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("WC10")
IE.Document.GetElementByID("TjPwm5FAwoE-rsmnUja7gKQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'6 or more months of ARVs
If ThisWorkbook.Sheets("sheet1").Range("WD10") > 0 Then
'F<15
IE.Document.GetElementByID("TjPwm5FAwoE-BI8xcqAAUG5-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-BI8xcqAAUG5-val").Value = ThisWorkbook.Sheets("sheet1").Range("WD10")
IE.Document.GetElementByID("TjPwm5FAwoE-BI8xcqAAUG5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WE10") > 0 Then
'F<15+
IE.Document.GetElementByID("TjPwm5FAwoE-oEwZb35vkK8-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-oEwZb35vkK8-val").Value = ThisWorkbook.Sheets("sheet1").Range("WE10")
IE.Document.GetElementByID("TjPwm5FAwoE-oEwZb35vkK8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WF10") > 0 Then
'M<15
IE.Document.GetElementByID("TjPwm5FAwoE-xiN0MnMoX6X-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-xiN0MnMoX6X-val").Value = ThisWorkbook.Sheets("sheet1").Range("WF10")
IE.Document.GetElementByID("TjPwm5FAwoE-xiN0MnMoX6X-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WG10") > 0 Then
'M<15+
IE.Document.GetElementByID("TjPwm5FAwoE-mYjRxV1Tcpr-val").Focus
IE.Document.GetElementByID("TjPwm5FAwoE-mYjRxV1Tcpr-val").Value = ThisWorkbook.Sheets("sheet1").Range("WG10")
IE.Document.GetElementByID("TjPwm5FAwoE-mYjRxV1Tcpr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

End Sub


'                                                                                                                   
' TTTTTTTTTTTTTTTTTTTXXXXX      XXXXXXX                  _RRRRRRRRRRRRRRRR     TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT  
' TTTTTTTTTTTTTTTTTTTXXXXXX    XXXXXXX                   _RRRRRRRRRRRRRRRRR    TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT  
' TTTTTTTTTTTTTTTTTT XXXXXXX   XXXXXXX                   _RRRRRRRRRRRRRRRRRR   TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT  
' TTTTTTTTTTTTTTTTTT XXXXXXX  XXXXXXX                    _RRRRRRRRRRRRRRRRRR   TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT  
'       TTTTTT        XXXXXXX XXXXXXX                    _RRRRR     RRRRRRRR         TTTTTT            TTTTTT       
'       TTTTTT         XXXXXXXXXXXXX                     _RRRRR       RRRRRR         TTTTTT            TTTTTT       
'       TTTTTT         XXXXXXXXXXXX                      _RRRRR       RRRRRR         TTTTTT            TTTTTT       
'       TTTTTT          XXXXXXXXXXX                      _RRRRR       RRRRRR         TTTTTT            TTTTTT       
'       TTTTTT           XXXXXXXXX                       _RRRRR     RRRRRRRR         TTTTTT            TTTTTT       
'       TTTTTT           XXXXXXXX                        _RRRRRRRRRRRRRRRRRR         TTTTTT            TTTTTT       
'       TTTTTT            XXXXXXX                        _RRRRRRRRRRRRRRRRR          TTTTTT            TTTTTT       
'       TTTTTT           XXXXXXXX                        _RRRRRRRRRRRRRRRR           TTTTTT            TTTTTT       
'       TTTTTT          XXXXXXXXXX                       _RRRRRRRRRRRRRR             TTTTTT            TTTTTT       
'       TTTTTT          XXXXXXXXXXX                      _RRRRR RRRRRRRRR            TTTTTT            TTTTTT       
'       TTTTTT         XXXXXXXXXXXX                      _RRRRR   RRRRRRRR           TTTTTT            TTTTTT       
'       TTTTTT         XXXXXXXXXXXXX                     _RRRRR    RRRRRRR           TTTTTT            TTTTTT       
'       TTTTTT        XXXXXXX XXXXXXX                    _RRRRR     RRRRRRR          TTTTTT            TTTTTT       
'       TTTTTT       XXXXXXX  XXXXXXX                    _RRRRR     RRRRRRRR         TTTTTT            TTTTTT       
'       TTTTTT       XXXXXXX   XXXXXXX                   _RRRRR      RRRRRRR         TTTTTT            TTTTTT       
'       TTTTTT      TXXXXXX     XXXXXXX                  _RRRRR       RRRRRRR        TTTTTT            TTTTTT       
'       TTTTTT     TTXXXXX      XXXXXXX                  _RRRRR       RRRRRRRR       TTTTTT            TTTTTT       
'       TTTTTT     TTXXXXX       XXXXXXX                 _RRRRR        RRRRRRR       TTTTTT            TTTTTT       
'                    
'                                                                                                                  

Sub TX_RTT()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("WI10:XF10")) > 0 Then

If ThisWorkbook.Sheets("sheet1").Range("WI10") > 0 Then
'<1,F
IE.Document.GetElementByID("LF5i7HKmy1v-OMVFa98P0Yg-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-OMVFa98P0Yg-val").Value = ThisWorkbook.Sheets("sheet1").Range("WI10")
IE.Document.GetElementByID("LF5i7HKmy1v-OMVFa98P0Yg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WJ10") > 0 Then
'1-4,F
IE.Document.GetElementByID("LF5i7HKmy1v-dRjezxQktoz-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-dRjezxQktoz-val").Value = ThisWorkbook.Sheets("sheet1").Range("WJ10")
IE.Document.GetElementByID("LF5i7HKmy1v-dRjezxQktoz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WK10") > 0 Then
'5-9,F
IE.Document.GetElementByID("LF5i7HKmy1v-zLbjm4E1NsG-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-zLbjm4E1NsG-val").Value = ThisWorkbook.Sheets("sheet1").Range("WK10")
IE.Document.GetElementByID("LF5i7HKmy1v-zLbjm4E1NsG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WL10") > 0 Then
'10-14,F
IE.Document.GetElementByID("LF5i7HKmy1v-AG0milXShQM-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-AG0milXShQM-val").Value = ThisWorkbook.Sheets("sheet1").Range("WL10")
IE.Document.GetElementByID("LF5i7HKmy1v-AG0milXShQM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WM10") > 0 Then
'15-19,F
IE.Document.GetElementByID("LF5i7HKmy1v-QqlHrg6f0Sm-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-QqlHrg6f0Sm-val").Value = ThisWorkbook.Sheets("sheet1").Range("WM10")
IE.Document.GetElementByID("LF5i7HKmy1v-QqlHrg6f0Sm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WN10") > 0 Then
'20-24,F
IE.Document.GetElementByID("LF5i7HKmy1v-LyXZybq6Sjf-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-LyXZybq6Sjf-val").Value = ThisWorkbook.Sheets("sheet1").Range("WN10")
IE.Document.GetElementByID("LF5i7HKmy1v-LyXZybq6Sjf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WO10") > 0 Then
'25-29,F
IE.Document.GetElementByID("LF5i7HKmy1v-zqARzn2wVj5-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-zqARzn2wVj5-val").Value = ThisWorkbook.Sheets("sheet1").Range("WO10")
IE.Document.GetElementByID("LF5i7HKmy1v-zqARzn2wVj5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WP10") > 0 Then
'30-34,F
IE.Document.GetElementByID("LF5i7HKmy1v-Vi8sd7mvZW4-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-Vi8sd7mvZW4-val").Value = ThisWorkbook.Sheets("sheet1").Range("WP10")
IE.Document.GetElementByID("LF5i7HKmy1v-Vi8sd7mvZW4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WQ10") > 0 Then
'35-39,F
IE.Document.GetElementByID("LF5i7HKmy1v-hRq4baaUamW-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-hRq4baaUamW-val").Value = ThisWorkbook.Sheets("sheet1").Range("WQ10")
IE.Document.GetElementByID("LF5i7HKmy1v-hRq4baaUamW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WR10") > 0 Then
'40-44,F
IE.Document.GetElementByID("LF5i7HKmy1v-PEXIFVXGP9S-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-PEXIFVXGP9S-val").Value = ThisWorkbook.Sheets("sheet1").Range("WR10")
IE.Document.GetElementByID("LF5i7HKmy1v-PEXIFVXGP9S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WS10") > 0 Then
'45-49,F
IE.Document.GetElementByID("LF5i7HKmy1v-J8fGj3Iefbc-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-J8fGj3Iefbc-val").Value = ThisWorkbook.Sheets("sheet1").Range("WS10")
IE.Document.GetElementByID("LF5i7HKmy1v-J8fGj3Iefbc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WT10") > 0 Then
'50+,F
IE.Document.GetElementByID("LF5i7HKmy1v-lR2zeQ9VfB8-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-lR2zeQ9VfB8-val").Value = ThisWorkbook.Sheets("sheet1").Range("WT10")
IE.Document.GetElementByID("LF5i7HKmy1v-lR2zeQ9VfB8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WU10") > 0 Then
'<1,M
IE.Document.GetElementByID("LF5i7HKmy1v-GnpJeq2XENE-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-GnpJeq2XENE-val").Value = ThisWorkbook.Sheets("sheet1").Range("WU10")
IE.Document.GetElementByID("LF5i7HKmy1v-GnpJeq2XENE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WV10") > 0 Then
'1-4,M
IE.Document.GetElementByID("LF5i7HKmy1v-jjUGfPF0ObP-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-jjUGfPF0ObP-val").Value = ThisWorkbook.Sheets("sheet1").Range("WV10")
IE.Document.GetElementByID("LF5i7HKmy1v-jjUGfPF0ObP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WW10") > 0 Then
'5-9,M
IE.Document.GetElementByID("LF5i7HKmy1v-p1HABZs9ydt-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-p1HABZs9ydt-val").Value = ThisWorkbook.Sheets("sheet1").Range("WW10")
IE.Document.GetElementByID("LF5i7HKmy1v-p1HABZs9ydt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WX10") > 0 Then
'10-14,M
IE.Document.GetElementByID("LF5i7HKmy1v-tEMe0224zlP-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-tEMe0224zlP-val").Value = ThisWorkbook.Sheets("sheet1").Range("WX10")
IE.Document.GetElementByID("LF5i7HKmy1v-tEMe0224zlP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WY10") > 0 Then
'15-19,M
IE.Document.GetElementByID("LF5i7HKmy1v-LpnJL4zZxRH-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-LpnJL4zZxRH-val").Value = ThisWorkbook.Sheets("sheet1").Range("WY10")
IE.Document.GetElementByID("LF5i7HKmy1v-LpnJL4zZxRH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("WZ10") > 0 Then
'20-24,M
IE.Document.GetElementByID("LF5i7HKmy1v-NCnIv37EwU1-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-NCnIv37EwU1-val").Value = ThisWorkbook.Sheets("sheet1").Range("WZ10")
IE.Document.GetElementByID("LF5i7HKmy1v-NCnIv37EwU1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XA10") > 0 Then
'25-29,M
IE.Document.GetElementByID("LF5i7HKmy1v-y9LP85d8t4b-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-y9LP85d8t4b-val").Value = ThisWorkbook.Sheets("sheet1").Range("XA10")
IE.Document.GetElementByID("LF5i7HKmy1v-y9LP85d8t4b-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XB10") > 0 Then
'30-34,M
IE.Document.GetElementByID("LF5i7HKmy1v-YDzeLL6xf5o-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-YDzeLL6xf5o-val").Value = ThisWorkbook.Sheets("sheet1").Range("XB10")
IE.Document.GetElementByID("LF5i7HKmy1v-YDzeLL6xf5o-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XC10") > 0 Then
'35-39,M
IE.Document.GetElementByID("LF5i7HKmy1v-XcW5HWccYYZ-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-XcW5HWccYYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("XC10")
IE.Document.GetElementByID("LF5i7HKmy1v-XcW5HWccYYZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XD10") > 0 Then
'40-44,M
IE.Document.GetElementByID("LF5i7HKmy1v-zouTxRQ0kXP-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-zouTxRQ0kXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("XD10")
IE.Document.GetElementByID("LF5i7HKmy1v-zouTxRQ0kXP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XE10") > 0 Then
'45-49,M
IE.Document.GetElementByID("LF5i7HKmy1v-zUjkTTlva36-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-zUjkTTlva36-val").Value = ThisWorkbook.Sheets("sheet1").Range("XE10")
IE.Document.GetElementByID("LF5i7HKmy1v-zUjkTTlva36-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XF10") > 0 Then
'50+,M
IE.Document.GetElementByID("LF5i7HKmy1v-QwUdNwRA8Uc-val").Focus
IE.Document.GetElementByID("LF5i7HKmy1v-QwUdNwRA8Uc-val").Value = ThisWorkbook.Sheets("sheet1").Range("XF10")
IE.Document.GetElementByID("LF5i7HKmy1v-QwUdNwRA8Uc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

End if

'Disaggregated by key population type
If ThisWorkbook.Sheets("sheet1").Range("XG10") > 0 Then
'PWID 
IE.Document.GetElementByID("plyJBtIGPTL-FyhQbdBMM1p-val").Focus
IE.Document.GetElementByID("plyJBtIGPTL-FyhQbdBMM1p-val").Value = ThisWorkbook.Sheets("sheet1").Range("XG10")
IE.Document.GetElementByID("plyJBtIGPTL-FyhQbdBMM1p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XH10") > 0 Then
'MSM
IE.Document.GetElementByID("plyJBtIGPTL-wbJ9Nh2jqUG-val").Focus
IE.Document.GetElementByID("plyJBtIGPTL-wbJ9Nh2jqUG-val").Value = ThisWorkbook.Sheets("sheet1").Range("XH10")
IE.Document.GetElementByID("plyJBtIGPTL-wbJ9Nh2jqUG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XI10") > 0 Then
'TG
IE.Document.GetElementByID("plyJBtIGPTL-fCiy8R7Dv9x-val").Focus
IE.Document.GetElementByID("plyJBtIGPTL-fCiy8R7Dv9x-val").Value = ThisWorkbook.Sheets("sheet1").Range("XI10")
IE.Document.GetElementByID("plyJBtIGPTL-fCiy8R7Dv9x-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XJ10") > 0 Then
'FSW
IE.Document.GetElementByID("plyJBtIGPTL-dUCNvz8ByrS-val").Focus
IE.Document.GetElementByID("plyJBtIGPTL-dUCNvz8ByrS-val").Value = ThisWorkbook.Sheets("sheet1").Range("XJ10")
IE.Document.GetElementByID("plyJBtIGPTL-dUCNvz8ByrS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XK10") > 0 Then
'PRISON
IE.Document.GetElementByID("plyJBtIGPTL-VCEoYHLyTxk-val").Focus
IE.Document.GetElementByID("plyJBtIGPTL-VCEoYHLyTxk-val").Value = ThisWorkbook.Sheets("sheet1").Range("XK10")
IE.Document.GetElementByID("plyJBtIGPTL-VCEoYHLyTxk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

End Sub


' TTTTTTTTTTTTTTTTTTTXXXXX      XXXXXXX                  _MMMMMMM       MMMMMMMM   LLLLL             
' TTTTTTTTTTTTTTTTTTTXXXXXX    XXXXXXX                   _MMMMMMMM     MMMMMMMMM   LLLLL             
' TTTTTTTTTTTTTTTTTT XXXXXXX   XXXXXXX                   _MMMMMMMM     MMMMMMMMM   LLLLL             
' TTTTTTTTTTTTTTTTTT XXXXXXX  XXXXXXX                    _MMMMMMMM     MMMMMMMMM   LLLLL             
'       TTTTTT        XXXXXXX XXXXXXX                    _MMMMMMMMM    MMMMMMMMM   LLLLL             
'       TTTTTT         XXXXXXXXXXXXX                     _MMMMMMMMM   MMMMMMMMMM   LLLLL             
'       TTTTTT         XXXXXXXXXXXX                      _MMMMMMMMM   MMMMMMMMMM   LLLLL             
'       TTTTTT          XXXXXXXXXXX                      _MMMMMMMMM   MMMMMMMMMM   LLLLL             
'       TTTTTT           XXXXXXXXX                       _MMMMMMMMMM  MMMMMMMMMM   LLLLL             
'       TTTTTT           XXXXXXXX                        _MMMMMMMMMM MMMMMMMMMMM   LLLLL             
'       TTTTTT            XXXXXXX                        _MMMMMMMMMM MMMMMMMMMMM   LLLLL             
'       TTTTTT           XXXXXXXX                        _MMMMMMMMMM MMMMMMMMMMM   LLLLL             
'       TTTTTT          XXXXXXXXXX                       _MMMMM MMMMMMMMMMMMMMMM   LLLLL             
'       TTTTTT          XXXXXXXXXXX                      _MMMMM MMMMMMMMM MMMMMM   LLLLL             
'       TTTTTT         XXXXXXXXXXXX                      _MMMMM MMMMMMMMM MMMMMM   LLLLL             
'       TTTTTT         XXXXXXXXXXXXX                     _MMMMM MMMMMMMMM MMMMMM   LLLLL             
'       TTTTTT        XXXXXXX XXXXXXX                    _MMMMM MMMMMMMMM MMMMMM   LLLLL             
'       TTTTTT       XXXXXXX  XXXXXXX                    _MMMMM  MMMMMMM  MMMMMM   LLLLL             
'       TTTTTT       XXXXXXX   XXXXXXX                   _MMMMM  MMMMMMM  MMMMMM   LLLLLLLLLLLLLLLL  
'       TTTTTT      TXXXXXX     XXXXXXX                  _MMMMM  MMMMMMM  MMMMMM   LLLLLLLLLLLLLLLL  
'       TTTTTT     TTXXXXX      XXXXXXX                  _MMMMM  MMMMMMM  MMMMMM   LLLLLLLLLLLLLLLL  
'       TTTTTT     TTXXXXX       XXXXXXX                 _MMMMM   MMMMM   MMMMMM   LLLLLLLLLLLLLLLL  
'                                                             
Sub TX_ML()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("XM10:YJ10")) > 0 Then
'Died
If ThisWorkbook.Sheets("sheet1").Range("XM10") > 0 Then
'<1,F
IE.Document.GetElementByID("A5A8LKqJw4w-RatVvjTJ4fW-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-RatVvjTJ4fW-val").Value = ThisWorkbook.Sheets("sheet1").Range("XM10")
IE.Document.GetElementByID("A5A8LKqJw4w-RatVvjTJ4fW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XN10") > 0 Then
'1-4,F
IE.Document.GetElementByID("A5A8LKqJw4w-EcD0yQAv6kq-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-EcD0yQAv6kq-val").Value = ThisWorkbook.Sheets("sheet1").Range("XN10")
IE.Document.GetElementByID("A5A8LKqJw4w-EcD0yQAv6kq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XO10") > 0 Then
'5-9,F
IE.Document.GetElementByID("A5A8LKqJw4w-SAazhVXMq1k-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-SAazhVXMq1k-val").Value = ThisWorkbook.Sheets("sheet1").Range("XO10")
IE.Document.GetElementByID("A5A8LKqJw4w-SAazhVXMq1k-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XP10") > 0 Then
'10-14,F
IE.Document.GetElementByID("A5A8LKqJw4w-zLxYKvkV3jz-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-zLxYKvkV3jz-val").Value = ThisWorkbook.Sheets("sheet1").Range("XP10")
IE.Document.GetElementByID("A5A8LKqJw4w-zLxYKvkV3jz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XQ10") > 0 Then
'15-19,F
IE.Document.GetElementByID("A5A8LKqJw4w-k2Gy2ENq4NA-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-k2Gy2ENq4NA-val").Value = ThisWorkbook.Sheets("sheet1").Range("XQ10")
IE.Document.GetElementByID("A5A8LKqJw4w-k2Gy2ENq4NA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XR10") > 0 Then
'20-24,F
IE.Document.GetElementByID("A5A8LKqJw4w-b5e17ZsCGVP-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-b5e17ZsCGVP-val").Value = ThisWorkbook.Sheets("sheet1").Range("XR10")
IE.Document.GetElementByID("A5A8LKqJw4w-b5e17ZsCGVP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XS10") > 0 Then
'25-29,F
IE.Document.GetElementByID("A5A8LKqJw4w-Ay9Exyx7pQf-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Ay9Exyx7pQf-val").Value = ThisWorkbook.Sheets("sheet1").Range("XS10")
IE.Document.GetElementByID("A5A8LKqJw4w-Ay9Exyx7pQf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XT10") > 0 Then
'30-34,F
IE.Document.GetElementByID("A5A8LKqJw4w-Ezt2wNTEk1R-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Ezt2wNTEk1R-val").Value = ThisWorkbook.Sheets("sheet1").Range("XT10")
IE.Document.GetElementByID("A5A8LKqJw4w-Ezt2wNTEk1R-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XU10") > 0 Then
'35-39,F
IE.Document.GetElementByID("A5A8LKqJw4w-tOnf3aDjXXn-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-tOnf3aDjXXn-val").Value = ThisWorkbook.Sheets("sheet1").Range("XU10")
IE.Document.GetElementByID("A5A8LKqJw4w-tOnf3aDjXXn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XV10") > 0 Then
'40-44,F
IE.Document.GetElementByID("A5A8LKqJw4w-AJhfJC3pGa0-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-AJhfJC3pGa0-val").Value = ThisWorkbook.Sheets("sheet1").Range("XV10")
IE.Document.GetElementByID("A5A8LKqJw4w-AJhfJC3pGa0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XW10") > 0 Then
'45-49,F
IE.Document.GetElementByID("A5A8LKqJw4w-tMZpupX5WIf-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-tMZpupX5WIf-val").Value = ThisWorkbook.Sheets("sheet1").Range("XW10")
IE.Document.GetElementByID("A5A8LKqJw4w-tMZpupX5WIf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XX10") > 0 Then
'50+,F
IE.Document.GetElementByID("A5A8LKqJw4w-eGJpmcZYtGE-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-eGJpmcZYtGE-val").Value = ThisWorkbook.Sheets("sheet1").Range("XX10")
IE.Document.GetElementByID("A5A8LKqJw4w-eGJpmcZYtGE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XY10") > 0 Then
'<1,M
IE.Document.GetElementByID("A5A8LKqJw4w-NSLkzvAdhRw-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-NSLkzvAdhRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("XY10")
IE.Document.GetElementByID("A5A8LKqJw4w-NSLkzvAdhRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("XZ10") > 0 Then
'1-4,M
IE.Document.GetElementByID("A5A8LKqJw4w-OSriJJaXtNJ-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-OSriJJaXtNJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("XZ10")
IE.Document.GetElementByID("A5A8LKqJw4w-OSriJJaXtNJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YA10") > 0 Then
'5-9,M
IE.Document.GetElementByID("A5A8LKqJw4w-k59QPOfcP3u-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-k59QPOfcP3u-val").Value = ThisWorkbook.Sheets("sheet1").Range("YA10")
IE.Document.GetElementByID("A5A8LKqJw4w-k59QPOfcP3u-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YB10") > 0 Then
'10-14,M
IE.Document.GetElementByID("A5A8LKqJw4w-GsxMXvEa5Ql-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-GsxMXvEa5Ql-val").Value = ThisWorkbook.Sheets("sheet1").Range("YB10")
IE.Document.GetElementByID("A5A8LKqJw4w-GsxMXvEa5Ql-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YC10") > 0 Then
'15-19,M
IE.Document.GetElementByID("A5A8LKqJw4w-BAV3b6n7mPv-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-BAV3b6n7mPv-val").Value = ThisWorkbook.Sheets("sheet1").Range("YC10")
IE.Document.GetElementByID("A5A8LKqJw4w-BAV3b6n7mPv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YD10") > 0 Then
'20-24,M
IE.Document.GetElementByID("A5A8LKqJw4w-c97TTwhTzUh-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-c97TTwhTzUh-val").Value = ThisWorkbook.Sheets("sheet1").Range("YD10")
IE.Document.GetElementByID("A5A8LKqJw4w-c97TTwhTzUh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YE10") > 0 Then
'25-29,M
IE.Document.GetElementByID("A5A8LKqJw4w-lF8rCs1t0cW-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-lF8rCs1t0cW-val").Value = ThisWorkbook.Sheets("sheet1").Range("YE10")
IE.Document.GetElementByID("A5A8LKqJw4w-lF8rCs1t0cW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YF10") > 0 Then
'30-34,M
IE.Document.GetElementByID("A5A8LKqJw4w-N5wGAwGdE8T-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-N5wGAwGdE8T-val").Value = ThisWorkbook.Sheets("sheet1").Range("YF10")
IE.Document.GetElementByID("A5A8LKqJw4w-N5wGAwGdE8T-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YG10") > 0 Then
'35-39,M
IE.Document.GetElementByID("A5A8LKqJw4w-pGf2ML3SigH-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-pGf2ML3SigH-val").Value = ThisWorkbook.Sheets("sheet1").Range("YG10")
IE.Document.GetElementByID("A5A8LKqJw4w-pGf2ML3SigH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YH10") > 0 Then
'40-44,M
IE.Document.GetElementByID("A5A8LKqJw4w-EEjtHVBGr2E-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-EEjtHVBGr2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("YH10")
IE.Document.GetElementByID("A5A8LKqJw4w-EEjtHVBGr2E-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YI10") > 0 Then
'45-49,M
IE.Document.GetElementByID("A5A8LKqJw4w-syeVn2eVjNh-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-syeVn2eVjNh-val").Value = ThisWorkbook.Sheets("sheet1").Range("YI10")
IE.Document.GetElementByID("A5A8LKqJw4w-syeVn2eVjNh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YJ10") > 0 Then
'50+,M
IE.Document.GetElementByID("A5A8LKqJw4w-eXPqcMstrMu-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-eXPqcMstrMu-val").Value = ThisWorkbook.Sheets("sheet1").Range("YJ10")
IE.Document.GetElementByID("A5A8LKqJw4w-eXPqcMstrMu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if


End if

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("YK10:ZH10")) > 0 Then
'Lost to Follow-Up After being on Treatment for < 3 months
If ThisWorkbook.Sheets("sheet1").Range("YK10") > 0 Then
'<1,F
IE.Document.GetElementByID("A5A8LKqJw4w-JM0yA1v6vva-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-JM0yA1v6vva-val").Value = ThisWorkbook.Sheets("sheet1").Range("YK10")
IE.Document.GetElementByID("A5A8LKqJw4w-JM0yA1v6vva-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YL10") > 0 Then
'1-4,F
IE.Document.GetElementByID("A5A8LKqJw4w-yOrK9FLook5-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-yOrK9FLook5-val").Value = ThisWorkbook.Sheets("sheet1").Range("YL10")
IE.Document.GetElementByID("A5A8LKqJw4w-yOrK9FLook5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YM10") > 0 Then
'5-9,F
IE.Document.GetElementByID("A5A8LKqJw4w-TIdAM0BbcIN-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-TIdAM0BbcIN-val").Value = ThisWorkbook.Sheets("sheet1").Range("YM10")
IE.Document.GetElementByID("A5A8LKqJw4w-TIdAM0BbcIN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YN10") > 0 Then
'10-14,F
IE.Document.GetElementByID("A5A8LKqJw4w-Q3QCFpTuON9-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Q3QCFpTuON9-val").Value = ThisWorkbook.Sheets("sheet1").Range("YN10")
IE.Document.GetElementByID("A5A8LKqJw4w-Q3QCFpTuON9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YO10") > 0 Then
'15-19,F
IE.Document.GetElementByID("A5A8LKqJw4w-iAlkU4D36A2-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-iAlkU4D36A2-val").Value = ThisWorkbook.Sheets("sheet1").Range("YO10")
IE.Document.GetElementByID("A5A8LKqJw4w-iAlkU4D36A2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YP10") > 0 Then
'20-24,F
IE.Document.GetElementByID("A5A8LKqJw4w-h1teKDQrYZv-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-h1teKDQrYZv-val").Value = ThisWorkbook.Sheets("sheet1").Range("YP10")
IE.Document.GetElementByID("A5A8LKqJw4w-h1teKDQrYZv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YQ10") > 0 Then
'25-29,F
IE.Document.GetElementByID("A5A8LKqJw4w-lPOdOm8qB56-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-lPOdOm8qB56-val").Value = ThisWorkbook.Sheets("sheet1").Range("YQ10")
IE.Document.GetElementByID("A5A8LKqJw4w-lPOdOm8qB56-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YR10") > 0 Then
'30-34,F
IE.Document.GetElementByID("A5A8LKqJw4w-CAqegtopONU-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-CAqegtopONU-val").Value = ThisWorkbook.Sheets("sheet1").Range("YR10")
IE.Document.GetElementByID("A5A8LKqJw4w-CAqegtopONU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YS10") > 0 Then
'35-39,F
IE.Document.GetElementByID("A5A8LKqJw4w-qWmfHASider-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-qWmfHASider-val").Value = ThisWorkbook.Sheets("sheet1").Range("YS10")
IE.Document.GetElementByID("A5A8LKqJw4w-qWmfHASider-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YT10") > 0 Then
'40-44,F
IE.Document.GetElementByID("A5A8LKqJw4w-qB90d21QM0S-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-qB90d21QM0S-val").Value = ThisWorkbook.Sheets("sheet1").Range("YT10")
IE.Document.GetElementByID("A5A8LKqJw4w-qB90d21QM0S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YU10") > 0 Then
'45-49,F
IE.Document.GetElementByID("A5A8LKqJw4w-osVUhnpfrBx-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-osVUhnpfrBx-val").Value = ThisWorkbook.Sheets("sheet1").Range("YU10")
IE.Document.GetElementByID("A5A8LKqJw4w-osVUhnpfrBx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YV10") > 0 Then
'50+,F
IE.Document.GetElementByID("A5A8LKqJw4w-WSsWxXHSUQd-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-WSsWxXHSUQd-val").Value = ThisWorkbook.Sheets("sheet1").Range("YV10")
IE.Document.GetElementByID("A5A8LKqJw4w-WSsWxXHSUQd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YW10") > 0 Then
'<1,M
IE.Document.GetElementByID("A5A8LKqJw4w-hHMSsHNE7Ov-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-hHMSsHNE7Ov-val").Value = ThisWorkbook.Sheets("sheet1").Range("YW10")
IE.Document.GetElementByID("A5A8LKqJw4w-hHMSsHNE7Ov-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YX10") > 0 Then
'1-4,M
IE.Document.GetElementByID("A5A8LKqJw4w-rM5Ckdelr1c-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-rM5Ckdelr1c-val").Value = ThisWorkbook.Sheets("sheet1").Range("YX10")
IE.Document.GetElementByID("A5A8LKqJw4w-rM5Ckdelr1c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YY10") > 0 Then
'5-9,M
IE.Document.GetElementByID("A5A8LKqJw4w-OomwzzpQ09G-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-OomwzzpQ09G-val").Value = ThisWorkbook.Sheets("sheet1").Range("YY10")
IE.Document.GetElementByID("A5A8LKqJw4w-OomwzzpQ09G-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("YZ10") > 0 Then
'10-14,M
IE.Document.GetElementByID("A5A8LKqJw4w-mwkpiAUKHEQ-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-mwkpiAUKHEQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("YZ10")
IE.Document.GetElementByID("A5A8LKqJw4w-mwkpiAUKHEQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZA10") > 0 Then
'15-19,M
IE.Document.GetElementByID("A5A8LKqJw4w-GSxJdBeZbf2-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-GSxJdBeZbf2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZA10")
IE.Document.GetElementByID("A5A8LKqJw4w-GSxJdBeZbf2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZB10") > 0 Then
'20-24,M
IE.Document.GetElementByID("A5A8LKqJw4w-e8LD3b5NYvH-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-e8LD3b5NYvH-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZB10")
IE.Document.GetElementByID("A5A8LKqJw4w-e8LD3b5NYvH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZC10") > 0 Then
'25-29,M
IE.Document.GetElementByID("A5A8LKqJw4w-WWiLJt24pLu-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-WWiLJt24pLu-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZC10")
IE.Document.GetElementByID("A5A8LKqJw4w-WWiLJt24pLu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZD10") > 0 Then
'30-34,M
IE.Document.GetElementByID("A5A8LKqJw4w-YrvxIzmxvpT-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-YrvxIzmxvpT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZD10")
IE.Document.GetElementByID("A5A8LKqJw4w-YrvxIzmxvpT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZE10") > 0 Then
'35-39,M
IE.Document.GetElementByID("A5A8LKqJw4w-K5GeJ5R4kHf-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-K5GeJ5R4kHf-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZE10")
IE.Document.GetElementByID("A5A8LKqJw4w-K5GeJ5R4kHf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZF10") > 0 Then
'40-44,M
IE.Document.GetElementByID("A5A8LKqJw4w-rm4WmQXiu2I-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-rm4WmQXiu2I-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZF10")
IE.Document.GetElementByID("A5A8LKqJw4w-rm4WmQXiu2I-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZG10") > 0 Then
'45-49,M
IE.Document.GetElementByID("A5A8LKqJw4w-UNYwGxDucY1-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-UNYwGxDucY1-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZG10")
IE.Document.GetElementByID("A5A8LKqJw4w-UNYwGxDucY1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZH10") > 0 Then
'50+,M
IE.Document.GetElementByID("A5A8LKqJw4w-LM1TskaJ8rL-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-LM1TskaJ8rL-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZH10")
IE.Document.GetElementByID("A5A8LKqJw4w-LM1TskaJ8rL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if


End if

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("ZI10:AAF10")) > 0 Then

'Lost to Follow-Up After being on Treatment for > 3 months
If ThisWorkbook.Sheets("sheet1").Range("ZI10") > 0 Then
'<1,F
IE.Document.GetElementByID("A5A8LKqJw4w-ARBsrjIHZN5-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-ARBsrjIHZN5-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZI10")
IE.Document.GetElementByID("A5A8LKqJw4w-ARBsrjIHZN5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZJ10") > 0 Then
'1-4,F
IE.Document.GetElementByID("A5A8LKqJw4w-rccM5R72tHF-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-rccM5R72tHF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZJ10")
IE.Document.GetElementByID("A5A8LKqJw4w-rccM5R72tHF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZK10") > 0 Then
'5-9,F
IE.Document.GetElementByID("A5A8LKqJw4w-QVlkySgBdgD-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-QVlkySgBdgD-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZK10")
IE.Document.GetElementByID("A5A8LKqJw4w-QVlkySgBdgD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZL10") > 0 Then
'10-14,F
IE.Document.GetElementByID("A5A8LKqJw4w-oq8GBQWCJ5W-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-oq8GBQWCJ5W-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZL10")
IE.Document.GetElementByID("A5A8LKqJw4w-oq8GBQWCJ5W-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZM10") > 0 Then
'15-19,F
IE.Document.GetElementByID("A5A8LKqJw4w-pn73jSw4Htv-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-pn73jSw4Htv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZM10")
IE.Document.GetElementByID("A5A8LKqJw4w-pn73jSw4Htv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZN10") > 0 Then
'20-24,F
IE.Document.GetElementByID("A5A8LKqJw4w-y4nxSRIyacT-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-y4nxSRIyacT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZN10")
IE.Document.GetElementByID("A5A8LKqJw4w-y4nxSRIyacT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZO10") > 0 Then
'25-29,F
IE.Document.GetElementByID("A5A8LKqJw4w-zXnVdVZfcfv-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-zXnVdVZfcfv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZO10")
IE.Document.GetElementByID("A5A8LKqJw4w-zXnVdVZfcfv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZP10") > 0 Then
'30-34,F
IE.Document.GetElementByID("A5A8LKqJw4w-Ythd1r9SUX2-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Ythd1r9SUX2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZP10")
IE.Document.GetElementByID("A5A8LKqJw4w-Ythd1r9SUX2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZQ10") > 0 Then
'35-39,F
IE.Document.GetElementByID("A5A8LKqJw4w-fmXSkERwgN3-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-fmXSkERwgN3-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZQ10")
IE.Document.GetElementByID("A5A8LKqJw4w-fmXSkERwgN3-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZR10") > 0 Then
'40-44,F
IE.Document.GetElementByID("A5A8LKqJw4w-M7hQF3EdMeJ-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-M7hQF3EdMeJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZR10")
IE.Document.GetElementByID("A5A8LKqJw4w-M7hQF3EdMeJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZS10") > 0 Then
'45-49,F
IE.Document.GetElementByID("A5A8LKqJw4w-qmYI4jxdSNK-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-qmYI4jxdSNK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZS10")
IE.Document.GetElementByID("A5A8LKqJw4w-qmYI4jxdSNK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZT10") > 0 Then
'50+,F
IE.Document.GetElementByID("A5A8LKqJw4w-FKO1O2wKujr-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-FKO1O2wKujr-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZT10")
IE.Document.GetElementByID("A5A8LKqJw4w-FKO1O2wKujr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZU10") > 0 Then
'<1,M
IE.Document.GetElementByID("A5A8LKqJw4w-AhLz2IxjfwZ-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-AhLz2IxjfwZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZU10")
IE.Document.GetElementByID("A5A8LKqJw4w-AhLz2IxjfwZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZV10") > 0 Then
'1-4,M
IE.Document.GetElementByID("A5A8LKqJw4w-fz7cmbK3Mdo-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-fz7cmbK3Mdo-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZV10")
IE.Document.GetElementByID("A5A8LKqJw4w-fz7cmbK3Mdo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZW10") > 0 Then
'5-9,M
IE.Document.GetElementByID("A5A8LKqJw4w-oFMaPp3YOAy-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-oFMaPp3YOAy-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZW10")
IE.Document.GetElementByID("A5A8LKqJw4w-oFMaPp3YOAy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZX10") > 0 Then
'10-14,M
IE.Document.GetElementByID("A5A8LKqJw4w-UMj0R6Br6UQ-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-UMj0R6Br6UQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZX10")
IE.Document.GetElementByID("A5A8LKqJw4w-UMj0R6Br6UQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZY10") > 0 Then
'15-19,M
IE.Document.GetElementByID("A5A8LKqJw4w-bULpx4GAuXv-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-bULpx4GAuXv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZY10")
IE.Document.GetElementByID("A5A8LKqJw4w-bULpx4GAuXv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ZZ10") > 0 Then
'20-24,M
IE.Document.GetElementByID("A5A8LKqJw4w-on9uH6H3Yk9-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-on9uH6H3Yk9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZZ10")
IE.Document.GetElementByID("A5A8LKqJw4w-on9uH6H3Yk9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAA10") > 0 Then
'25-29,M
IE.Document.GetElementByID("A5A8LKqJw4w-jr0rVfWl1RP-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-jr0rVfWl1RP-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAA10")
IE.Document.GetElementByID("A5A8LKqJw4w-jr0rVfWl1RP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAB10") > 0 Then
'30-34,M
IE.Document.GetElementByID("A5A8LKqJw4w-BCQyZzO2bJe-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-BCQyZzO2bJe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAB10")
IE.Document.GetElementByID("A5A8LKqJw4w-BCQyZzO2bJe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAC10") > 0 Then
'35-39,M
IE.Document.GetElementByID("A5A8LKqJw4w-REi2VHAgsHF-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-REi2VHAgsHF-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAC10")
IE.Document.GetElementByID("A5A8LKqJw4w-REi2VHAgsHF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAD10") > 0 Then
'40-44,M
IE.Document.GetElementByID("A5A8LKqJw4w-pAdya4dQkZn-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-pAdya4dQkZn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAD10")
IE.Document.GetElementByID("A5A8LKqJw4w-pAdya4dQkZn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAE10") > 0 Then
'45-49,M
IE.Document.GetElementByID("A5A8LKqJw4w-WsMQcJpjFr5-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-WsMQcJpjFr5-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAE10")
IE.Document.GetElementByID("A5A8LKqJw4w-WsMQcJpjFr5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAF10") > 0 Then
'50+,M
IE.Document.GetElementByID("A5A8LKqJw4w-d0IZ0gXHmjX-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-d0IZ0gXHmjX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAF10")
IE.Document.GetElementByID("A5A8LKqJw4w-d0IZ0gXHmjX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if


End if

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("AAG10:ABD10")) > 0 Then

'Transferred Out
If ThisWorkbook.Sheets("sheet1").Range("AAG10") > 0 Then
'<1,F
IE.Document.GetElementByID("A5A8LKqJw4w-rpjAwXPibLm-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-rpjAwXPibLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAG10")
IE.Document.GetElementByID("A5A8LKqJw4w-rpjAwXPibLm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAH10") > 0 Then
'1-4,F
IE.Document.GetElementByID("A5A8LKqJw4w-AWYFd7hY5Ad-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-AWYFd7hY5Ad-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAH10")
IE.Document.GetElementByID("A5A8LKqJw4w-AWYFd7hY5Ad-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAI10") > 0 Then
'5-9,F
IE.Document.GetElementByID("A5A8LKqJw4w-izkWiUwD9ik-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-izkWiUwD9ik-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAI10")
IE.Document.GetElementByID("A5A8LKqJw4w-izkWiUwD9ik-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAJ10") > 0 Then
'10-14,F
IE.Document.GetElementByID("A5A8LKqJw4w-JnJDcjUa9T4-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-JnJDcjUa9T4-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAJ10")
IE.Document.GetElementByID("A5A8LKqJw4w-JnJDcjUa9T4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAK10") > 0 Then
'15-19,F
IE.Document.GetElementByID("A5A8LKqJw4w-Yeyi4MKHk9n-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Yeyi4MKHk9n-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAK10")
IE.Document.GetElementByID("A5A8LKqJw4w-Yeyi4MKHk9n-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAL10") > 0 Then
'20-24,F
IE.Document.GetElementByID("A5A8LKqJw4w-WqurwSIqEU7-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-WqurwSIqEU7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAL10")
IE.Document.GetElementByID("A5A8LKqJw4w-WqurwSIqEU7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAM10") > 0 Then
'25-29,F
IE.Document.GetElementByID("A5A8LKqJw4w-wWCzAzpuLyG-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-wWCzAzpuLyG-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAM10")
IE.Document.GetElementByID("A5A8LKqJw4w-wWCzAzpuLyG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAN10") > 0 Then
'30-34,F
IE.Document.GetElementByID("A5A8LKqJw4w-DkpU4cPkFvi-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-DkpU4cPkFvi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAN10")
IE.Document.GetElementByID("A5A8LKqJw4w-DkpU4cPkFvi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAO10") > 0 Then
'35-39,F
IE.Document.GetElementByID("A5A8LKqJw4w-LhWBhUPo2pr-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-LhWBhUPo2pr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAO10")
IE.Document.GetElementByID("A5A8LKqJw4w-LhWBhUPo2pr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAP10") > 0 Then
'40-44,F
IE.Document.GetElementByID("A5A8LKqJw4w-OidXeIspzhm-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-OidXeIspzhm-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAP10")
IE.Document.GetElementByID("A5A8LKqJw4w-OidXeIspzhm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAQ10") > 0 Then
'45-49,F
IE.Document.GetElementByID("A5A8LKqJw4w-YL8YhKVIt0J-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-YL8YhKVIt0J-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAQ10")
IE.Document.GetElementByID("A5A8LKqJw4w-YL8YhKVIt0J-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAR10") > 0 Then
'50+,F
IE.Document.GetElementByID("A5A8LKqJw4w-kTb5xmUtyGw-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-kTb5xmUtyGw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAR10")
IE.Document.GetElementByID("A5A8LKqJw4w-kTb5xmUtyGw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAS10") > 0 Then
'<1,M
IE.Document.GetElementByID("A5A8LKqJw4w-PAw0s1Cg9wA-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-PAw0s1Cg9wA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAS10")
IE.Document.GetElementByID("A5A8LKqJw4w-PAw0s1Cg9wA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAT10") > 0 Then
'1-4,M
IE.Document.GetElementByID("A5A8LKqJw4w-awWrQSsARco-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-awWrQSsARco-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAT10")
IE.Document.GetElementByID("A5A8LKqJw4w-awWrQSsARco-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAU10") > 0 Then
'5-9,M
IE.Document.GetElementByID("A5A8LKqJw4w-xWfbpqXemE7-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-xWfbpqXemE7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAU10")
IE.Document.GetElementByID("A5A8LKqJw4w-xWfbpqXemE7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAV10") > 0 Then
'10-14,M
IE.Document.GetElementByID("A5A8LKqJw4w-l7xtGidktnc-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-l7xtGidktnc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAV10")
IE.Document.GetElementByID("A5A8LKqJw4w-l7xtGidktnc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAW10") > 0 Then
'15-19,M
IE.Document.GetElementByID("A5A8LKqJw4w-Y3uCNvUiOrA-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Y3uCNvUiOrA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAW10")
IE.Document.GetElementByID("A5A8LKqJw4w-Y3uCNvUiOrA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAX10") > 0 Then
'20-24,M
IE.Document.GetElementByID("A5A8LKqJw4w-lA8vh3lAWYR-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-lA8vh3lAWYR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAX10")
IE.Document.GetElementByID("A5A8LKqJw4w-lA8vh3lAWYR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAY10") > 0 Then
'25-29,M
IE.Document.GetElementByID("A5A8LKqJw4w-y5kX7AZ7mBg-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-y5kX7AZ7mBg-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAY10")
IE.Document.GetElementByID("A5A8LKqJw4w-y5kX7AZ7mBg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AAZ10") > 0 Then
'30-34,M
IE.Document.GetElementByID("A5A8LKqJw4w-sTzPBKgXXFo-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-sTzPBKgXXFo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAZ10")
IE.Document.GetElementByID("A5A8LKqJw4w-sTzPBKgXXFo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABA10") > 0 Then
'35-39,M
IE.Document.GetElementByID("A5A8LKqJw4w-vcFcgYJeJwq-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-vcFcgYJeJwq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABA10")
IE.Document.GetElementByID("A5A8LKqJw4w-vcFcgYJeJwq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABB10") > 0 Then
'40-44,M
IE.Document.GetElementByID("A5A8LKqJw4w-OUjsD0fPgIG-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-OUjsD0fPgIG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABB10")
IE.Document.GetElementByID("A5A8LKqJw4w-OUjsD0fPgIG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABC10") > 0 Then
'45-49,M
IE.Document.GetElementByID("A5A8LKqJw4w-Ce5ZLv98jW0-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Ce5ZLv98jW0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABC10")
IE.Document.GetElementByID("A5A8LKqJw4w-Ce5ZLv98jW0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABD10") > 0 Then
'50+,M
IE.Document.GetElementByID("A5A8LKqJw4w-gpsG1vryF1J-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-gpsG1vryF1J-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABD10")
IE.Document.GetElementByID("A5A8LKqJw4w-gpsG1vryF1J-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if


End if

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("ABE10:ACB10")) > 0 Then

'Refused (Stopped) Treatment
If ThisWorkbook.Sheets("sheet1").Range("ABE10") > 0 Then
'<1,F
IE.Document.GetElementByID("A5A8LKqJw4w-mTdH1Oa7oHR-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-mTdH1Oa7oHR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABE10")
IE.Document.GetElementByID("A5A8LKqJw4w-mTdH1Oa7oHR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABF10") > 0 Then
'1-4,F
IE.Document.GetElementByID("A5A8LKqJw4w-sGO5qC91U7G-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-sGO5qC91U7G-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABF10")
IE.Document.GetElementByID("A5A8LKqJw4w-sGO5qC91U7G-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABG10") > 0 Then
'5-9,F
IE.Document.GetElementByID("A5A8LKqJw4w-sgOwlczVC7c-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-sgOwlczVC7c-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABG10")
IE.Document.GetElementByID("A5A8LKqJw4w-sgOwlczVC7c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABH10") > 0 Then
'10-14,F
IE.Document.GetElementByID("A5A8LKqJw4w-EvkKEbvkP1H-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-EvkKEbvkP1H-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABH10")
IE.Document.GetElementByID("A5A8LKqJw4w-EvkKEbvkP1H-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABI10") > 0 Then
'15-19,F
IE.Document.GetElementByID("A5A8LKqJw4w-LEhDG4hHJPM-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-LEhDG4hHJPM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABI10")
IE.Document.GetElementByID("A5A8LKqJw4w-LEhDG4hHJPM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABJ10") > 0 Then
'20-24,F
IE.Document.GetElementByID("A5A8LKqJw4w-jX13BNPu12p-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-jX13BNPu12p-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABJ10")
IE.Document.GetElementByID("A5A8LKqJw4w-jX13BNPu12p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABK10") > 0 Then
'25-29,F
IE.Document.GetElementByID("A5A8LKqJw4w-Zpq9tFpwE7F-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Zpq9tFpwE7F-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABK10")
IE.Document.GetElementByID("A5A8LKqJw4w-Zpq9tFpwE7F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABL10") > 0 Then
'30-34,F
IE.Document.GetElementByID("A5A8LKqJw4w-gHIXz1hAmxR-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-gHIXz1hAmxR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABL10")
IE.Document.GetElementByID("A5A8LKqJw4w-gHIXz1hAmxR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABM10") > 0 Then
'35-39,F
IE.Document.GetElementByID("A5A8LKqJw4w-wdemCNRlJaT-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-wdemCNRlJaT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABM10")
IE.Document.GetElementByID("A5A8LKqJw4w-wdemCNRlJaT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABN10") > 0 Then
'40-44,F
IE.Document.GetElementByID("A5A8LKqJw4w-L7j3koEncg8-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-L7j3koEncg8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABN10")
IE.Document.GetElementByID("A5A8LKqJw4w-L7j3koEncg8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABO10") > 0 Then
'45-49,F
IE.Document.GetElementByID("A5A8LKqJw4w-TyhbDH7bH68-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-TyhbDH7bH68-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABO10")
IE.Document.GetElementByID("A5A8LKqJw4w-TyhbDH7bH68-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABP10") > 0 Then
'50+,F
IE.Document.GetElementByID("A5A8LKqJw4w-jOZUwHSe9wV-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-jOZUwHSe9wV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABP10")
IE.Document.GetElementByID("A5A8LKqJw4w-jOZUwHSe9wV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABQ10") > 0 Then
'<1,M
IE.Document.GetElementByID("A5A8LKqJw4w-tKyqG7JOAXL-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-tKyqG7JOAXL-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABQ10")
IE.Document.GetElementByID("A5A8LKqJw4w-tKyqG7JOAXL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABR10") > 0 Then
'1-4,M
IE.Document.GetElementByID("A5A8LKqJw4w-nltMOkAV1FS-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-nltMOkAV1FS-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABR10")
IE.Document.GetElementByID("A5A8LKqJw4w-nltMOkAV1FS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABS10") > 0 Then
'5-9,M
IE.Document.GetElementByID("A5A8LKqJw4w-RLxtYdau8ft-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-RLxtYdau8ft-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABS10")
IE.Document.GetElementByID("A5A8LKqJw4w-RLxtYdau8ft-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABT10") > 0 Then
'10-14,M
IE.Document.GetElementByID("A5A8LKqJw4w-xObCzHhyQS2-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-xObCzHhyQS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABT10")
IE.Document.GetElementByID("A5A8LKqJw4w-xObCzHhyQS2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABU10") > 0 Then
'15-19,M
IE.Document.GetElementByID("A5A8LKqJw4w-CgnONHK2F0B-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-CgnONHK2F0B-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABU10")
IE.Document.GetElementByID("A5A8LKqJw4w-CgnONHK2F0B-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABV10") > 0 Then
'20-24,M
IE.Document.GetElementByID("A5A8LKqJw4w-tWpjMYC3Q0h-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-tWpjMYC3Q0h-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABV10")
IE.Document.GetElementByID("A5A8LKqJw4w-tWpjMYC3Q0h-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABW10") > 0 Then
'25-29,M
IE.Document.GetElementByID("A5A8LKqJw4w-TZuiCh50vFh-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-TZuiCh50vFh-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABW10")
IE.Document.GetElementByID("A5A8LKqJw4w-TZuiCh50vFh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABX10") > 0 Then
'30-34,M
IE.Document.GetElementByID("A5A8LKqJw4w-dfrkk62Fhen-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-dfrkk62Fhen-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABX10")
IE.Document.GetElementByID("A5A8LKqJw4w-dfrkk62Fhen-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABY10") > 0 Then
'35-39,M
IE.Document.GetElementByID("A5A8LKqJw4w-Ru9wXpGLd5p-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-Ru9wXpGLd5p-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABY10")
IE.Document.GetElementByID("A5A8LKqJw4w-Ru9wXpGLd5p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ABZ10") > 0 Then
'40-44,M
IE.Document.GetElementByID("A5A8LKqJw4w-V8sRJK35quK-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-V8sRJK35quK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABZ10")
IE.Document.GetElementByID("A5A8LKqJw4w-V8sRJK35quK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACA10") > 0 Then
'45-49,M
IE.Document.GetElementByID("A5A8LKqJw4w-fm0b6BnCytd-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-fm0b6BnCytd-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACA10")
IE.Document.GetElementByID("A5A8LKqJw4w-fm0b6BnCytd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACB10") > 0 Then
'50+,M
IE.Document.GetElementByID("A5A8LKqJw4w-JA1xiCEiU5p-val").Focus
IE.Document.GetElementByID("A5A8LKqJw4w-JA1xiCEiU5p-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACB10")
IE.Document.GetElementByID("A5A8LKqJw4w-JA1xiCEiU5p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("ACD10:ACK10")) > 0 Then
'New on ART
If ThisWorkbook.Sheets("sheet1").Range("ACD10") > 0 Then
'10-14
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACD10")
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACE10") > 0 Then
'15-19
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACE10")
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACF10") > 0 Then
'20-24
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACF10")
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACG10") > 0 Then
'25-29
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACG10")
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Already on ART
If ThisWorkbook.Sheets("sheet1").Range("ACH10") > 0 Then
'10-14
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACH10")
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACI10") > 0 Then
'15-19
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACI10")
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACJ10") > 0 Then
'20-24
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACJ10")
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACK10") > 0 Then
'25-29
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACK10")
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("ACM10:AEH10")) > 0 Then
'Numerator
'Already on ART
If ThisWorkbook.Sheets("sheet1").Range("ACM10") > 0 Then
'<1,F
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACM10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACN10") > 0 Then
'<1,M
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACN10")
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACO10") > 0 Then
'1-4,F
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACO10")
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACP10") > 0 Then
'1-4,M
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACP10")
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACQ10") > 0 Then
'5-9,F
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACQ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACR10") > 0 Then
'5-9,M
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACR10")
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACS10") > 0 Then
'10-14,F
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACS10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACT10") > 0 Then
'10-14,M
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACT10")
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACU10") > 0 Then
'15-19,F
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACU10")
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACV10") > 0 Then
'15-19,M
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACV10")
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACW10") > 0 Then
'20-24,F
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACW10")
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACX10") > 0 Then
'20-24,M
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACX10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACY10") > 0 Then
'25-29,F
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACY10")
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ACZ10") > 0 Then
'25-29,M
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACZ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADA10") > 0 Then
'30-34,F
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADA10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADB10") > 0 Then
'30-34,M
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADB10")
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADC10") > 0 Then
'35-39,F
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADC10")
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADD10") > 0 Then
'35-39,M
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADD10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADE10") > 0 Then
'40-44,F
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADE10")
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADF10") > 0 Then
'40-44,M
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADF10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADG10") > 0 Then
'45-49,F
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADG10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADH10") > 0 Then
'45-49,M
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADH10")
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADI10") > 0 Then
'50+,F
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADI10")
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADJ10") > 0 Then
'50+,M
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADJ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'New on ART
If ThisWorkbook.Sheets("sheet1").Range("ADK10") > 0 Then
'<1,F
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADK10")
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADL10") > 0 Then
'<1,M
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADL10")
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADM10") > 0 Then
'1-4,F
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADM10")
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADN10") > 0 Then
'1-4,M
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADN10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADO10") > 0 Then
'5-9,F
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADO10")
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADP10") > 0 Then
'5-9,M
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADP10")
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADQ10") > 0 Then
'10-14,F
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADQ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADR10") > 0 Then
'10-14,M
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADR10")
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADS10") > 0 Then
'15-19,F
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADS10")
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADT10") > 0 Then
'15-19,M
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADT10")
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADU10") > 0 Then
'20-24,F
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADU10")
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADV10") > 0 Then
'20-24,M
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADV10")
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADW10") > 0 Then
'25-29,F
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADW10")
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADX10") > 0 Then
'25-29,M
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADX10")
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADY10") > 0 Then
'30-34,F
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADY10")
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("ADZ10") > 0 Then
'30-34,M
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADZ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEA10") > 0 Then
'35-39,F
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEA10")
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEB10") > 0 Then
'35-39,M
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEB10")
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEC10") > 0 Then
'40-44,F
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEC10")
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AED10") > 0 Then
'40-44,M
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").Value = ThisWorkbook.Sheets("sheet1").Range("AED10")
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEE10") > 0 Then
'45-49,F
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEE10")
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEF10") > 0 Then
'45-49,M
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEF10")
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEG10") > 0 Then
'50+,F
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEG10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEH10") > 0 Then
'50+,M
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEH10")
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

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
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("AEN10:AGI10")) > 0 Then
If ThisWorkbook.Sheets("sheet1").Range("AEJ10") > 0 Then
'Routine, Pregnant
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEJ10")
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEK10") > 0 Then
'Routine, Breastfeeding
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEK10")
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEL10") > 0 Then
'Undocumented/Targeted, Pregnant
IE.Document.GetElementByID("JTmqyoIWNsj-FR9ZDmeA4Az-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-FR9ZDmeA4Az-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEL10")
IE.Document.GetElementByID("JTmqyoIWNsj-FR9ZDmeA4Az-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEM10") > 0 Then
'Undocumented/Targeted, Breastfeeding
IE.Document.GetElementByID("JTmqyoIWNsj-xxGho4palSB-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-xxGho4palSB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEM10")
IE.Document.GetElementByID("JTmqyoIWNsj-xxGho4palSB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Routine
If ThisWorkbook.Sheets("sheet1").Range("AEN10") > 0 Then
'<1,F
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEN10")
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEO10") > 0 Then
'1-4,F
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEO10")
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEP10") > 0 Then
'5-9,F
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEP10")
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEQ10") > 0 Then
'10-14,F
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEQ10")
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AER10") > 0 Then
'15-19,F
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").Value = ThisWorkbook.Sheets("sheet1").Range("AER10")
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AES10") > 0 Then
'20-24,F
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AES10")
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AET10") > 0 Then
'25-29,F
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").Value = ThisWorkbook.Sheets("sheet1").Range("AET10")
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEU10") > 0 Then
'30-34,F
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEU10")
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEV10") > 0 Then
'35-39,F
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEV10")
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEW10") > 0 Then
'40-44,F
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEW10")
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEX10") > 0 Then
'45-49,F
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEX10")
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEY10") > 0 Then
'50+,F
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEY10")
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AEZ10") > 0 Then
'<1,M
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEZ10")
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFA10") > 0 Then
'1-4,M
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFA10")
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFB10") > 0 Then
'5-9,M
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFB10")
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFC10") > 0 Then
'10-14,M
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFC10")
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFD10") > 0 Then
'15-19,M
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFD10")
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFE10") > 0 Then
'20-24,M
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFE10")
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFF10") > 0 Then
'25-29,M
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFF10")
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFG10") > 0 Then
'30-34,M
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFG10")
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFH10") > 0 Then
'35-39,M
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFH10")
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFI10") > 0 Then
'40-44,M
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFI10")
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFJ10") > 0 Then
'45-49,M
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFJ10")
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFK10") > 0 Then
'50+,M
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFK10")
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Not Documented/Targeted
If ThisWorkbook.Sheets("sheet1").Range("AFL10") > 0 Then
'<1,F
IE.Document.GetElementByID("YvPOllVtINQ-pjkXBdgweKp-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-pjkXBdgweKp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFL10")
IE.Document.GetElementByID("YvPOllVtINQ-pjkXBdgweKp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFM10") > 0 Then
'1-4,F
IE.Document.GetElementByID("YvPOllVtINQ-UmKpnaBWKNG-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-UmKpnaBWKNG-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFM10")
IE.Document.GetElementByID("YvPOllVtINQ-UmKpnaBWKNG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFN10") > 0 Then
'5-9,F
IE.Document.GetElementByID("YvPOllVtINQ-mR4xiOSrCOb-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-mR4xiOSrCOb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFN10")
IE.Document.GetElementByID("YvPOllVtINQ-mR4xiOSrCOb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFO10") > 0 Then
'10-14,F
IE.Document.GetElementByID("YvPOllVtINQ-Wl6Xe4IRe5N-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-Wl6Xe4IRe5N-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFO10")
IE.Document.GetElementByID("YvPOllVtINQ-Wl6Xe4IRe5N-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFP10") > 0 Then
'15-19,F
IE.Document.GetElementByID("YvPOllVtINQ-B3YJoWLCkue-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-B3YJoWLCkue-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFP10")
IE.Document.GetElementByID("YvPOllVtINQ-B3YJoWLCkue-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFQ10") > 0 Then
'20-24,F
IE.Document.GetElementByID("YvPOllVtINQ-XkXgVeD7zWW-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-XkXgVeD7zWW-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFQ10")
IE.Document.GetElementByID("YvPOllVtINQ-XkXgVeD7zWW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFR10") > 0 Then
'25-29,F
IE.Document.GetElementByID("YvPOllVtINQ-nVgwQTwVWng-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-nVgwQTwVWng-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFR10")
IE.Document.GetElementByID("YvPOllVtINQ-nVgwQTwVWng-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFS10") > 0 Then
'30-34,F
IE.Document.GetElementByID("YvPOllVtINQ-oDCkdeCOlft-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-oDCkdeCOlft-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFS10")
IE.Document.GetElementByID("YvPOllVtINQ-oDCkdeCOlft-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFT10") > 0 Then
'35-39,F
IE.Document.GetElementByID("YvPOllVtINQ-Xv7byNPl3sp-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-Xv7byNPl3sp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFT10")
IE.Document.GetElementByID("YvPOllVtINQ-Xv7byNPl3sp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFU10") > 0 Then
'40-44,F
IE.Document.GetElementByID("YvPOllVtINQ-mKoxFv2cCli-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-mKoxFv2cCli-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFU10")
IE.Document.GetElementByID("YvPOllVtINQ-mKoxFv2cCli-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFV10") > 0 Then
'45-49,F
IE.Document.GetElementByID("YvPOllVtINQ-mGvZHOcps52-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-mGvZHOcps52-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFV10")
IE.Document.GetElementByID("YvPOllVtINQ-mGvZHOcps52-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFW10") > 0 Then
'50+,F
IE.Document.GetElementByID("YvPOllVtINQ-i9oC3RD2uGE-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-i9oC3RD2uGE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFW10")
IE.Document.GetElementByID("YvPOllVtINQ-i9oC3RD2uGE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFX10") > 0 Then
'<1,M
IE.Document.GetElementByID("YvPOllVtINQ-UBAW8zO2PXf-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-UBAW8zO2PXf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFX10")
IE.Document.GetElementByID("YvPOllVtINQ-UBAW8zO2PXf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFY10") > 0 Then
'1-4,M
IE.Document.GetElementByID("YvPOllVtINQ-CUcChuyrJO2-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-CUcChuyrJO2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFY10")
IE.Document.GetElementByID("YvPOllVtINQ-CUcChuyrJO2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AFZ10") > 0 Then
'5-9,M
IE.Document.GetElementByID("YvPOllVtINQ-WCUwCrmtbTo-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-WCUwCrmtbTo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFZ10")
IE.Document.GetElementByID("YvPOllVtINQ-WCUwCrmtbTo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGA10") > 0 Then
'10-14,M
IE.Document.GetElementByID("YvPOllVtINQ-WalMMpT8Ue2-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-WalMMpT8Ue2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGA10")
IE.Document.GetElementByID("YvPOllVtINQ-WalMMpT8Ue2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGB10") > 0 Then
'15-19,M
IE.Document.GetElementByID("YvPOllVtINQ-MEG4maaWoA7-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-MEG4maaWoA7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGB10")
IE.Document.GetElementByID("YvPOllVtINQ-MEG4maaWoA7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGC10") > 0 Then
'20-24,M
IE.Document.GetElementByID("YvPOllVtINQ-dsq0QpQMPj0-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-dsq0QpQMPj0-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGC10")
IE.Document.GetElementByID("YvPOllVtINQ-dsq0QpQMPj0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGD10") > 0 Then
'25-29,M
IE.Document.GetElementByID("YvPOllVtINQ-FKErASt2t1z-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-FKErASt2t1z-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGD10")
IE.Document.GetElementByID("YvPOllVtINQ-FKErASt2t1z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGE10") > 0 Then
'30-34,M
IE.Document.GetElementByID("YvPOllVtINQ-dVZwJhviGrl-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-dVZwJhviGrl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGE10")
IE.Document.GetElementByID("YvPOllVtINQ-dVZwJhviGrl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGF10") > 0 Then
'35-39,M
IE.Document.GetElementByID("YvPOllVtINQ-uQJ2RFlLZ8L-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-uQJ2RFlLZ8L-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGF10")
IE.Document.GetElementByID("YvPOllVtINQ-uQJ2RFlLZ8L-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGG10") > 0 Then
'40-44,M
IE.Document.GetElementByID("YvPOllVtINQ-Gi32xq0roZx-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-Gi32xq0roZx-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGG10")
IE.Document.GetElementByID("YvPOllVtINQ-Gi32xq0roZx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGH10") > 0 Then
'45-49,M
IE.Document.GetElementByID("YvPOllVtINQ-RtzNjHlVYXH-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-RtzNjHlVYXH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGH10")
IE.Document.GetElementByID("YvPOllVtINQ-RtzNjHlVYXH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGI10") > 0 Then
'50+,M
IE.Document.GetElementByID("YvPOllVtINQ-ru0hDqbhyku-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-ru0hDqbhyku-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGI10")
IE.Document.GetElementByID("YvPOllVtINQ-ru0hDqbhyku-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if


'Disaggregated by key population type
'Routine
If ThisWorkbook.Sheets("sheet1").Range("AGJ10") > 0 Then
'PWID
IE.Document.GetElementByID("Fs6OLZSb2mg-wQEJHaLbSn1-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-wQEJHaLbSn1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGJ10")
IE.Document.GetElementByID("Fs6OLZSb2mg-wQEJHaLbSn1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGK10") > 0 Then
'MSM
IE.Document.GetElementByID("Fs6OLZSb2mg-oMV1pF48ZLc-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-oMV1pF48ZLc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGK10")
IE.Document.GetElementByID("Fs6OLZSb2mg-oMV1pF48ZLc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGL10") > 0 Then
'TG
IE.Document.GetElementByID("Fs6OLZSb2mg-yuVedHVF5au-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-yuVedHVF5au-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGL10")
IE.Document.GetElementByID("Fs6OLZSb2mg-yuVedHVF5au-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGM10") > 0 Then
'FSW
IE.Document.GetElementByID("Fs6OLZSb2mg-e6laBt0a4H5-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-e6laBt0a4H5-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGM10")
IE.Document.GetElementByID("Fs6OLZSb2mg-e6laBt0a4H5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGN10") > 0 Then
'Prison
IE.Document.GetElementByID("Fs6OLZSb2mg-vG5FAcGH9US-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-vG5FAcGH9US-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGN10")
IE.Document.GetElementByID("Fs6OLZSb2mg-vG5FAcGH9US-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Targeted
If ThisWorkbook.Sheets("sheet1").Range("AGO10") > 0 Then
'PWID
IE.Document.GetElementByID("Fs6OLZSb2mg-hOmBYbgBZ0O-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-hOmBYbgBZ0O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGO10")
IE.Document.GetElementByID("Fs6OLZSb2mg-hOmBYbgBZ0O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGP10") > 0 Then
'MSM
IE.Document.GetElementByID("Fs6OLZSb2mg-qbFLLU6Fimz-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-qbFLLU6Fimz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGP10")
IE.Document.GetElementByID("Fs6OLZSb2mg-qbFLLU6Fimz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGQ10") > 0 Then
'TG
IE.Document.GetElementByID("Fs6OLZSb2mg-SkrleMTebAa-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-SkrleMTebAa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGQ10")
IE.Document.GetElementByID("Fs6OLZSb2mg-SkrleMTebAa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGR10") > 0 Then
'FSW
IE.Document.GetElementByID("Fs6OLZSb2mg-g0Y3klhGDYM-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-g0Y3klhGDYM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGR10")
IE.Document.GetElementByID("Fs6OLZSb2mg-g0Y3klhGDYM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGS10") > 0 Then
'Prison
IE.Document.GetElementByID("Fs6OLZSb2mg-qaqq0s49le3-val").Focus
IE.Document.GetElementByID("Fs6OLZSb2mg-qaqq0s49le3-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGS10")
IE.Document.GetElementByID("Fs6OLZSb2mg-qaqq0s49le3-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

End If
'Denominator
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("AGY10:AIT10")) > 0 Then
If ThisWorkbook.Sheets("sheet1").Range("AGU10") > 0 Then
'Routine, Pregnant
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGU10")
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGV10") > 0 Then
'Routine, Breastfeeding
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGV10")
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGW10") > 0 Then
'Undocumented/Targeted, Pregnant
IE.Document.GetElementByID("eQdclZl2AoR-FR9ZDmeA4Az-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-FR9ZDmeA4Az-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGW10")
IE.Document.GetElementByID("eQdclZl2AoR-FR9ZDmeA4Az-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGX10") > 0 Then
'Undocumented/Targeted, Breastfeeding
IE.Document.GetElementByID("eQdclZl2AoR-xxGho4palSB-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-xxGho4palSB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGX10")
IE.Document.GetElementByID("eQdclZl2AoR-xxGho4palSB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Routine
If ThisWorkbook.Sheets("sheet1").Range("AGY10") > 0 Then
'<1,F
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGY10")
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AGZ10") > 0 Then
'1-4,F
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGZ10")
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHA10") > 0 Then
'5-9,F
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHA10")
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHB10") > 0 Then
'10-14,F
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHB10")
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHC10") > 0 Then
'15-19,F
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHC10")
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHD10") > 0 Then
'20-24,F
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHD10")
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHE10") > 0 Then
'25-29,F
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHE10")
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHF10") > 0 Then
'30-34,F
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHF10")
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHG10") > 0 Then
'35-39,F
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHG10")
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHH10") > 0 Then
'40-44,F
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHH10")
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHI10") > 0 Then
'45-49,F
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHI10")
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHJ10") > 0 Then
'50+,F
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHJ10")
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHK10") > 0 Then
'<1,M
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHK10")
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHL10") > 0 Then
'1-4,M
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHL10")
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHM10") > 0 Then
'5-9,M
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHM10")
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHN10") > 0 Then
'10-14,M
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHN10")
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHO10") > 0 Then
'15-19,M
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHO10")
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHP10") > 0 Then
'20-24,M
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHP10")
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHQ10") > 0 Then
'25-29,M
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHQ10")
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHR10") > 0 Then
'30-34,M
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHR10")
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHS10") > 0 Then
'35-39,M
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHS10")
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHT10") > 0 Then
'40-44,M
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHT10")
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHU10") > 0 Then
'45-49,M
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHU10")
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHV10") > 0 Then
'50+,M
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHV10")
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Not Documented/Targeted
If ThisWorkbook.Sheets("sheet1").Range("AHW10") > 0 Then
'<1,F
IE.Document.GetElementByID("kznQBykTtJt-pjkXBdgweKp-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-pjkXBdgweKp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHW10")
IE.Document.GetElementByID("kznQBykTtJt-pjkXBdgweKp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHX10") > 0 Then
'1-4,F
IE.Document.GetElementByID("kznQBykTtJt-UmKpnaBWKNG-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-UmKpnaBWKNG-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHX10")
IE.Document.GetElementByID("kznQBykTtJt-UmKpnaBWKNG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHY10") > 0 Then
'5-9,F
IE.Document.GetElementByID("kznQBykTtJt-mR4xiOSrCOb-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-mR4xiOSrCOb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHY10")
IE.Document.GetElementByID("kznQBykTtJt-mR4xiOSrCOb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AHZ10") > 0 Then
'10-14,F
IE.Document.GetElementByID("kznQBykTtJt-Wl6Xe4IRe5N-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-Wl6Xe4IRe5N-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHZ10")
IE.Document.GetElementByID("kznQBykTtJt-Wl6Xe4IRe5N-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIA10") > 0 Then
'15-19,F
IE.Document.GetElementByID("kznQBykTtJt-B3YJoWLCkue-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-B3YJoWLCkue-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIA10")
IE.Document.GetElementByID("kznQBykTtJt-B3YJoWLCkue-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIB10") > 0 Then
'20-24,F
IE.Document.GetElementByID("kznQBykTtJt-XkXgVeD7zWW-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-XkXgVeD7zWW-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIB10")
IE.Document.GetElementByID("kznQBykTtJt-XkXgVeD7zWW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIC10") > 0 Then
'25-29,F
IE.Document.GetElementByID("kznQBykTtJt-nVgwQTwVWng-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-nVgwQTwVWng-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIC10")
IE.Document.GetElementByID("kznQBykTtJt-nVgwQTwVWng-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AID10") > 0 Then
'30-34,F
IE.Document.GetElementByID("kznQBykTtJt-oDCkdeCOlft-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-oDCkdeCOlft-val").Value = ThisWorkbook.Sheets("sheet1").Range("AID10")
IE.Document.GetElementByID("kznQBykTtJt-oDCkdeCOlft-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIE10") > 0 Then
'35-39,F
IE.Document.GetElementByID("kznQBykTtJt-Xv7byNPl3sp-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-Xv7byNPl3sp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIE10")
IE.Document.GetElementByID("kznQBykTtJt-Xv7byNPl3sp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIF10") > 0 Then
'40-44,F
IE.Document.GetElementByID("kznQBykTtJt-mKoxFv2cCli-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-mKoxFv2cCli-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIF10")
IE.Document.GetElementByID("kznQBykTtJt-mKoxFv2cCli-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIG10") > 0 Then
'45-49,F
IE.Document.GetElementByID("kznQBykTtJt-mGvZHOcps52-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-mGvZHOcps52-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIG10")
IE.Document.GetElementByID("kznQBykTtJt-mGvZHOcps52-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIH10") > 0 Then
'50+,F
IE.Document.GetElementByID("kznQBykTtJt-i9oC3RD2uGE-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-i9oC3RD2uGE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIH10")
IE.Document.GetElementByID("kznQBykTtJt-i9oC3RD2uGE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AII10") > 0 Then
'<1,M
IE.Document.GetElementByID("kznQBykTtJt-UBAW8zO2PXf-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-UBAW8zO2PXf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AII10")
IE.Document.GetElementByID("kznQBykTtJt-UBAW8zO2PXf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIJ10") > 0 Then
'1-4,M
IE.Document.GetElementByID("kznQBykTtJt-CUcChuyrJO2-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-CUcChuyrJO2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIJ10")
IE.Document.GetElementByID("kznQBykTtJt-CUcChuyrJO2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIK10") > 0 Then
'5-9,M
IE.Document.GetElementByID("kznQBykTtJt-WCUwCrmtbTo-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-WCUwCrmtbTo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIK10")
IE.Document.GetElementByID("kznQBykTtJt-WCUwCrmtbTo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIL10") > 0 Then
'10-14,M
IE.Document.GetElementByID("kznQBykTtJt-WalMMpT8Ue2-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-WalMMpT8Ue2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIL10")
IE.Document.GetElementByID("kznQBykTtJt-WalMMpT8Ue2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIM10") > 0 Then
'15-19,M
IE.Document.GetElementByID("kznQBykTtJt-MEG4maaWoA7-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-MEG4maaWoA7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIM10")
IE.Document.GetElementByID("kznQBykTtJt-MEG4maaWoA7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIN10") > 0 Then
'20-24,M
IE.Document.GetElementByID("kznQBykTtJt-dsq0QpQMPj0-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-dsq0QpQMPj0-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIN10")
IE.Document.GetElementByID("kznQBykTtJt-dsq0QpQMPj0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIO10") > 0 Then
'25-29,M
IE.Document.GetElementByID("kznQBykTtJt-FKErASt2t1z-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-FKErASt2t1z-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIO10")
IE.Document.GetElementByID("kznQBykTtJt-FKErASt2t1z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIP10") > 0 Then
'30-34,M
IE.Document.GetElementByID("kznQBykTtJt-dVZwJhviGrl-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-dVZwJhviGrl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIP10")
IE.Document.GetElementByID("kznQBykTtJt-dVZwJhviGrl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIQ10") > 0 Then
'35-39,M
IE.Document.GetElementByID("kznQBykTtJt-uQJ2RFlLZ8L-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-uQJ2RFlLZ8L-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIQ10")
IE.Document.GetElementByID("kznQBykTtJt-uQJ2RFlLZ8L-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIR10") > 0 Then
'40-44,M
IE.Document.GetElementByID("kznQBykTtJt-Gi32xq0roZx-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-Gi32xq0roZx-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIR10")
IE.Document.GetElementByID("kznQBykTtJt-Gi32xq0roZx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIS10") > 0 Then
'45-49,M
IE.Document.GetElementByID("kznQBykTtJt-RtzNjHlVYXH-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-RtzNjHlVYXH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIS10")
IE.Document.GetElementByID("kznQBykTtJt-RtzNjHlVYXH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIT10") > 0 Then
'50+,M
IE.Document.GetElementByID("kznQBykTtJt-ru0hDqbhyku-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-ru0hDqbhyku-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIT10")
IE.Document.GetElementByID("kznQBykTtJt-ru0hDqbhyku-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Disaggregated by key population type
'Routine
If ThisWorkbook.Sheets("sheet1").Range("AIU10") > 0 Then
'PWID
IE.Document.GetElementByID("KqVN4pDxEGq-wQEJHaLbSn1-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-wQEJHaLbSn1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIU10")
IE.Document.GetElementByID("KqVN4pDxEGq-wQEJHaLbSn1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIV10") > 0 Then
'MSM
IE.Document.GetElementByID("KqVN4pDxEGq-oMV1pF48ZLc-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-oMV1pF48ZLc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIV10")
IE.Document.GetElementByID("KqVN4pDxEGq-oMV1pF48ZLc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIW10") > 0 Then
'TG
IE.Document.GetElementByID("KqVN4pDxEGq-yuVedHVF5au-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-yuVedHVF5au-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIW10")
IE.Document.GetElementByID("KqVN4pDxEGq-yuVedHVF5au-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIX10") > 0 Then
'FSW
IE.Document.GetElementByID("KqVN4pDxEGq-e6laBt0a4H5-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-e6laBt0a4H5-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIX10")
IE.Document.GetElementByID("KqVN4pDxEGq-e6laBt0a4H5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AIY10") > 0 Then
'Prison
IE.Document.GetElementByID("KqVN4pDxEGq-vG5FAcGH9US-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-vG5FAcGH9US-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIY10")
IE.Document.GetElementByID("KqVN4pDxEGq-vG5FAcGH9US-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

'Targeted
If ThisWorkbook.Sheets("sheet1").Range("AIZ10") > 0 Then
'PWID
IE.Document.GetElementByID("KqVN4pDxEGq-hOmBYbgBZ0O-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-hOmBYbgBZ0O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIZ10")
IE.Document.GetElementByID("KqVN4pDxEGq-hOmBYbgBZ0O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AJA10") > 0 Then
'MSM
IE.Document.GetElementByID("KqVN4pDxEGq-qbFLLU6Fimz-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-qbFLLU6Fimz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJA10")
IE.Document.GetElementByID("KqVN4pDxEGq-qbFLLU6Fimz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AJB10") > 0 Then
'TG
IE.Document.GetElementByID("KqVN4pDxEGq-SkrleMTebAa-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-SkrleMTebAa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJB10")
IE.Document.GetElementByID("KqVN4pDxEGq-SkrleMTebAa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AJC10") > 0 Then
'FSW
IE.Document.GetElementByID("KqVN4pDxEGq-g0Y3klhGDYM-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-g0Y3klhGDYM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJC10")
IE.Document.GetElementByID("KqVN4pDxEGq-g0Y3klhGDYM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

If ThisWorkbook.Sheets("sheet1").Range("AJD10") > 0 Then
'Prison
IE.Document.GetElementByID("KqVN4pDxEGq-qaqq0s49le3-val").Focus
IE.Document.GetElementByID("KqVN4pDxEGq-qaqq0s49le3-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJD10")
IE.Document.GetElementByID("KqVN4pDxEGq-qaqq0s49le3-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int((6 - 3 + 1) * Rnd + 3))
End if

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
    lStr =  lStr & "<table border='1' style='border-color:#EEEEEE;' cellspacing='0' cellpadding='5' width=420><tr><td colspan='2' style='background-color:#0288D1;color:white;text-align:center;'>Digitação automática completa no DATIM</td></tr><tr><td bgcolor='#F3F3F3'>Nome do Utilizador do<br>Sistema Operacional:</td><td>" & FormProgressBar.LabelUserInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Agente do Utilizador:</td><td>" & FormProgressBar.LabelUserAgentInfo & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora inicial:</td><td>" & startTime2 & "</td></tr><tr><td bgcolor='#F3F3F3'>Hora final:</td><td>" & endTime2 & "</td></tr><tr><td bgcolor='#F3F3F3'>Duração:</td><td>" & Format(fillDuration2, "hh") & ":" & Format(fillDuration2, "nn:ss") & "</td></tr><tr><td bgcolor='#F3F3F3'>Período de reportagem:</td><td>" & Replace(ThisWorkbook.Sheets("sheet1").Range("A4"),"Period:","") & "</td></tr>"
    lStr =  lStr & "<tr><td bgcolor='#F3F3F3'>Unidade Organizacional<br>digitada:</td><td>" & ThisWorkbook.Sheets("sheet1").Range("A10") & " (" & ThisWorkbook.Sheets("sheet1").Range("B10") & ")" & "</td></tr>"
    lStr =  lStr & "<tr><td bgcolor='#F3F3F3'>Observação:</td><td>" & ThisWorkbook.Sheets("sheet1").Range("A5") & "</td></tr><tr><td colspan='2' style='text-align:center;background-color:#0288D1;color:white;'> <a href='http://197.235.11.130:8181/dhis'><span style='color:#00FFFF;'>DHIS-FGH</span></a><br><a href='https://www.datim.org/'><span style='color:#00FFFF;'>DATIM</span></a><br>" & Year(Now()) & " &copy; <a href='mailto:sis@fgh.org.mz'><span style='color:#00FFFF;'>sis@fgh.org.mz</span></a></td></tr></table>"

    'Set All Email Properties
    With NewMail
        .Subject = "[SIS-FGH] Autofill DATIM"  & ", nº " & i & " de " & lastRow & " (" & ThisWorkbook.Sheets("sheet1").Range("B10") & "): "  & ThisWorkbook.Sheets("sheet1").Range("A10") 
        .From = "noreply@fgh.org.mz"
        .To = ""
        .CC = ""
        '.BCC= "damasceno.lopes@fgh.org.mz;"
        .BCC = "damasceno.lopes@fgh.org.mz;prosperino.mbalame@fgh.org.mz;fernanda.alvim@fgh.org.mz;eurico.jose@fgh.org.mz;antonio.mastala@fgh.org.mz;idelina.albano@fgh.org.mz;luis.macave@fgh.org.mz;armando.macuacua@fgh.org.mz;sidonio.samugi@fgh.org.mz"
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