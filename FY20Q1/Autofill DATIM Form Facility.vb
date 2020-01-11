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

If WorksheetFunction.IsNA(ThisWorkbook.Sheets("sheet1").Range("AUM10")) Or IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AUM10")) Then
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
    Call IE.Document.parentWindow.execScript("javascript:void selection.select( '" & ThisWorkbook.Sheets("sheet1").Range("AUM10") & "' )", "JavaScript")
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
    'Uncomment below if you need to select a period from previous year
    'Call IE.Document.parentWindow.execScript("previousPeriodsSelected()", "JavaScript")
    'Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("selectedPeriodId").Value = "2019Q3"
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
    'Annually
    Call GEND_GBV
    Call FPINT_SITE

    'TESTING
    'Select TAB
    IE.Document.GetElementByID("ui-id-3").Click
    Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("ui-id-10").Click
    Application.Wait Now + TimeValue("00:00:03")
    'Quarterly
    Call KeyPopulation
    Call PICT_Inpatient
    Call PICT_Pediatric
    Call PICT_PostANC
    Call PICT_Emergency
    Call PICT_Other
    Call VCT
    Call HTS_Index
    Call HTS_Self
    Call PMTCT_STAT
    Call PMTCT_EID_HEI_POS
    Call TB_STAT
    'Semiannually
    Call CXCA_SCRN
    'Annually
    Call PMTCT_FO

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

    'HEALTH SYSTEMS
    'Select TAB
    IE.Document.GetElementByID("ui-id-6").Click
    Application.Wait Now + TimeValue("00:00:03")
    IE.Document.GetElementByID("ui-id-16").Click
    Application.Wait Now + TimeValue("00:00:03")
    'Annually
    Call HRH
    Call LAB_PTCQI

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

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("E10")) Then
'<PWID Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-xYyVHiXrvSi-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-xYyVHiXrvSi-val").Value = ThisWorkbook.Sheets("sheet1").Range("E10")
IE.Document.GetElementByID("qhGxKnmrZBd-xYyVHiXrvSi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<PWID Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-nEKvoyX7K7X-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-nEKvoyX7K7X-val").Value = ThisWorkbook.Sheets("sheet1").Range("F10")
IE.Document.GetElementByID("qhGxKnmrZBd-nEKvoyX7K7X-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<MSM Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-i8VDE8xLSWJ-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-i8VDE8xLSWJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("G10")
IE.Document.GetElementByID("qhGxKnmrZBd-i8VDE8xLSWJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<MSM Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-kkkbGchekdj-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-kkkbGchekdj-val").Value = ThisWorkbook.Sheets("sheet1").Range("H10")
IE.Document.GetElementByID("qhGxKnmrZBd-kkkbGchekdj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<Transgender People Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-vvV2d1YvSSA-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-vvV2d1YvSSA-val").Value = ThisWorkbook.Sheets("sheet1").Range("I10")
IE.Document.GetElementByID("qhGxKnmrZBd-vvV2d1YvSSA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<Transgender People Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-KnvSi171hvx-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-KnvSi171hvx-val").Value = ThisWorkbook.Sheets("sheet1").Range("J10")
IE.Document.GetElementByID("qhGxKnmrZBd-KnvSi171hvx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<FSW Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-YtrkH2Xrb12-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-YtrkH2Xrb12-val").Value = ThisWorkbook.Sheets("sheet1").Range("K10")
IE.Document.GetElementByID("qhGxKnmrZBd-YtrkH2Xrb12-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<FSW Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-moJTjWdUcXY-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-moJTjWdUcXY-val").Value = ThisWorkbook.Sheets("sheet1").Range("L10")
IE.Document.GetElementByID("qhGxKnmrZBd-moJTjWdUcXY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<People in prison and other closed settings Posiitivos
IE.Document.GetElementByID("qhGxKnmrZBd-NMYN9FAPqWa-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-NMYN9FAPqWa-val").Value = ThisWorkbook.Sheets("sheet1").Range("M10")
IE.Document.GetElementByID("qhGxKnmrZBd-NMYN9FAPqWa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<People in prison and other closed settings Negativos
IE.Document.GetElementByID("qhGxKnmrZBd-qyNXQhzWglM-val").Focus
IE.Document.GetElementByID("qhGxKnmrZBd-qyNXQhzWglM-val").Value = ThisWorkbook.Sheets("sheet1").Range("N10")
IE.Document.GetElementByID("qhGxKnmrZBd-qyNXQhzWglM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

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

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("Q10")) Then
'<1,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("Q10")
IE.Document.GetElementByID("hvtNfA73XhN-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("R10")
IE.Document.GetElementByID("hvtNfA73XhN-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("S10")
IE.Document.GetElementByID("hvtNfA73XhN-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("T10")
IE.Document.GetElementByID("hvtNfA73XhN-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("U10")
IE.Document.GetElementByID("hvtNfA73XhN-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("V10")
IE.Document.GetElementByID("hvtNfA73XhN-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("W10")
IE.Document.GetElementByID("hvtNfA73XhN-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("X10")
IE.Document.GetElementByID("hvtNfA73XhN-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("Y10")
IE.Document.GetElementByID("hvtNfA73XhN-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("Z10")
IE.Document.GetElementByID("hvtNfA73XhN-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AA10")
IE.Document.GetElementByID("hvtNfA73XhN-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AB10")
IE.Document.GetElementByID("hvtNfA73XhN-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AC10")
IE.Document.GetElementByID("hvtNfA73XhN-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AD10")
IE.Document.GetElementByID("hvtNfA73XhN-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AE10")
IE.Document.GetElementByID("hvtNfA73XhN-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AF10")
IE.Document.GetElementByID("hvtNfA73XhN-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AG10")
IE.Document.GetElementByID("hvtNfA73XhN-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("AH10")
IE.Document.GetElementByID("hvtNfA73XhN-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AI10")
IE.Document.GetElementByID("hvtNfA73XhN-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJ10")
IE.Document.GetElementByID("hvtNfA73XhN-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AK10")
IE.Document.GetElementByID("hvtNfA73XhN-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AL10")
IE.Document.GetElementByID("hvtNfA73XhN-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("AM10")
IE.Document.GetElementByID("hvtNfA73XhN-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AN10")
IE.Document.GetElementByID("hvtNfA73XhN-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AO10")
IE.Document.GetElementByID("hvtNfA73XhN-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AP10")
IE.Document.GetElementByID("hvtNfA73XhN-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQ10")
IE.Document.GetElementByID("hvtNfA73XhN-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("AR10")
IE.Document.GetElementByID("hvtNfA73XhN-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("AS10")
IE.Document.GetElementByID("hvtNfA73XhN-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("AT10")
IE.Document.GetElementByID("hvtNfA73XhN-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AU10")
IE.Document.GetElementByID("hvtNfA73XhN-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("AV10")
IE.Document.GetElementByID("hvtNfA73XhN-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("AW10")
IE.Document.GetElementByID("hvtNfA73XhN-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("AX10")
IE.Document.GetElementByID("hvtNfA73XhN-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AY10")
IE.Document.GetElementByID("hvtNfA73XhN-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("AZ10")
IE.Document.GetElementByID("hvtNfA73XhN-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("BA10")
IE.Document.GetElementByID("hvtNfA73XhN-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("BB10")
IE.Document.GetElementByID("hvtNfA73XhN-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("BC10")
IE.Document.GetElementByID("hvtNfA73XhN-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("BD10")
IE.Document.GetElementByID("hvtNfA73XhN-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("BE10")
IE.Document.GetElementByID("hvtNfA73XhN-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("BF10")
IE.Document.GetElementByID("hvtNfA73XhN-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("BG10")
IE.Document.GetElementByID("hvtNfA73XhN-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("BH10")
IE.Document.GetElementByID("hvtNfA73XhN-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Positive
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("BI10")
IE.Document.GetElementByID("hvtNfA73XhN-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Negative
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("BJ10")
IE.Document.GetElementByID("hvtNfA73XhN-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Positive
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("BK10")
IE.Document.GetElementByID("hvtNfA73XhN-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Negative
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("BL10")
IE.Document.GetElementByID("hvtNfA73XhN-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("BQ10")) Then
'1-4,F,Positive
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").Value = ThisWorkbook.Sheets("sheet1").Range("BQ10")
IE.Document.GetElementByID("SpjvCpxnc20-WW9zQXPweSr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Negative
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").Value = ThisWorkbook.Sheets("sheet1").Range("BR10")
IE.Document.GetElementByID("SpjvCpxnc20-D9dXFmijBGl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Positive
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").Value = ThisWorkbook.Sheets("sheet1").Range("BS10")
IE.Document.GetElementByID("SpjvCpxnc20-oYSW4DGffvA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Negative
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").Focus
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("BT10")
IE.Document.GetElementByID("SpjvCpxnc20-OcnRuPmsFUq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("BY10")) Then
'10-14,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").Value = ThisWorkbook.Sheets("sheet1").Range("BY10")
IE.Document.GetElementByID("uNEH5voNvTC-t0Yya4MImnS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("BZ10")
IE.Document.GetElementByID("uNEH5voNvTC-nGcx0LefZBV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").Value = ThisWorkbook.Sheets("sheet1").Range("CA10")
IE.Document.GetElementByID("uNEH5voNvTC-nkvwIq2NBOh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").Value = ThisWorkbook.Sheets("sheet1").Range("CB10")
IE.Document.GetElementByID("uNEH5voNvTC-mYJxoKsrY9s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").Value = ThisWorkbook.Sheets("sheet1").Range("CC10")
IE.Document.GetElementByID("uNEH5voNvTC-aRTr56B7STz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").Value = ThisWorkbook.Sheets("sheet1").Range("CD10")
IE.Document.GetElementByID("uNEH5voNvTC-wC0BzPgXlyS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").Value = ThisWorkbook.Sheets("sheet1").Range("CE10")
IE.Document.GetElementByID("uNEH5voNvTC-lRLgTqrkSUb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").Value = ThisWorkbook.Sheets("sheet1").Range("CF10")
IE.Document.GetElementByID("uNEH5voNvTC-vMqqlUlWcHY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").Value = ThisWorkbook.Sheets("sheet1").Range("CG10")
IE.Document.GetElementByID("uNEH5voNvTC-A2MPGbUmeyX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").Value = ThisWorkbook.Sheets("sheet1").Range("CH10")
IE.Document.GetElementByID("uNEH5voNvTC-UwlQTn6TWp8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("CI10")
IE.Document.GetElementByID("uNEH5voNvTC-dIZKcE7VOzb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CJ10")
IE.Document.GetElementByID("uNEH5voNvTC-dNpO4A1jvDF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").Value = ThisWorkbook.Sheets("sheet1").Range("CK10")
IE.Document.GetElementByID("uNEH5voNvTC-pOo1PjtGdoO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("CL10")
IE.Document.GetElementByID("uNEH5voNvTC-JAaAaNVbkAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").Value = ThisWorkbook.Sheets("sheet1").Range("CM10")
IE.Document.GetElementByID("uNEH5voNvTC-TKDDSbTuQNp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").Value = ThisWorkbook.Sheets("sheet1").Range("CN10")
IE.Document.GetElementByID("uNEH5voNvTC-nX4I6OWgLhK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Positive
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").Value = ThisWorkbook.Sheets("sheet1").Range("CO10")
IE.Document.GetElementByID("uNEH5voNvTC-BVy7dN8KTEA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Negative
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").Focus
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").Value = ThisWorkbook.Sheets("sheet1").Range("CP10")
IE.Document.GetElementByID("uNEH5voNvTC-D0FAkQYhM51-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("CQ10")) Then
'<1,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("CQ10")
IE.Document.GetElementByID("m6oDgY6WhM4-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("CR10")
IE.Document.GetElementByID("m6oDgY6WhM4-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("CS10")
IE.Document.GetElementByID("m6oDgY6WhM4-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("CT10")
IE.Document.GetElementByID("m6oDgY6WhM4-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("CU10")
IE.Document.GetElementByID("m6oDgY6WhM4-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("CV10")
IE.Document.GetElementByID("m6oDgY6WhM4-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("CW10")
IE.Document.GetElementByID("m6oDgY6WhM4-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("CX10")
IE.Document.GetElementByID("m6oDgY6WhM4-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("CY10")
IE.Document.GetElementByID("m6oDgY6WhM4-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("CZ10")
IE.Document.GetElementByID("m6oDgY6WhM4-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("DA10")
IE.Document.GetElementByID("m6oDgY6WhM4-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("DB10")
IE.Document.GetElementByID("m6oDgY6WhM4-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("DC10")
IE.Document.GetElementByID("m6oDgY6WhM4-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DD10")
IE.Document.GetElementByID("m6oDgY6WhM4-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("DE10")
IE.Document.GetElementByID("m6oDgY6WhM4-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("DF10")
IE.Document.GetElementByID("m6oDgY6WhM4-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("DG10")
IE.Document.GetElementByID("m6oDgY6WhM4-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("DH10")
IE.Document.GetElementByID("m6oDgY6WhM4-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("DI10")
IE.Document.GetElementByID("m6oDgY6WhM4-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("DJ10")
IE.Document.GetElementByID("m6oDgY6WhM4-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("DK10")
IE.Document.GetElementByID("m6oDgY6WhM4-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("DL10")
IE.Document.GetElementByID("m6oDgY6WhM4-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("DM10")
IE.Document.GetElementByID("m6oDgY6WhM4-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("DN10")
IE.Document.GetElementByID("m6oDgY6WhM4-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("DO10")
IE.Document.GetElementByID("m6oDgY6WhM4-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("DP10")
IE.Document.GetElementByID("m6oDgY6WhM4-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("DQ10")
IE.Document.GetElementByID("m6oDgY6WhM4-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("DR10")
IE.Document.GetElementByID("m6oDgY6WhM4-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("DS10")
IE.Document.GetElementByID("m6oDgY6WhM4-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("DT10")
IE.Document.GetElementByID("m6oDgY6WhM4-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("DU10")
IE.Document.GetElementByID("m6oDgY6WhM4-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("DV10")
IE.Document.GetElementByID("m6oDgY6WhM4-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("DW10")
IE.Document.GetElementByID("m6oDgY6WhM4-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("DX10")
IE.Document.GetElementByID("m6oDgY6WhM4-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("DY10")
IE.Document.GetElementByID("m6oDgY6WhM4-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("DZ10")
IE.Document.GetElementByID("m6oDgY6WhM4-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("EA10")
IE.Document.GetElementByID("m6oDgY6WhM4-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("EB10")
IE.Document.GetElementByID("m6oDgY6WhM4-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("EC10")
IE.Document.GetElementByID("m6oDgY6WhM4-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ED10")
IE.Document.GetElementByID("m6oDgY6WhM4-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("EE10")
IE.Document.GetElementByID("m6oDgY6WhM4-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("EF10")
IE.Document.GetElementByID("m6oDgY6WhM4-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("EG10")
IE.Document.GetElementByID("m6oDgY6WhM4-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("EH10")
IE.Document.GetElementByID("m6oDgY6WhM4-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("EI10")
IE.Document.GetElementByID("m6oDgY6WhM4-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("EJ10")
IE.Document.GetElementByID("m6oDgY6WhM4-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Positive
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("EK10")
IE.Document.GetElementByID("m6oDgY6WhM4-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Negative
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("EL10")
IE.Document.GetElementByID("m6oDgY6WhM4-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("EO10")) Then
'Unknown age,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").Value = ThisWorkbook.Sheets("sheet1").Range("EO10")
IE.Document.GetElementByID("H7Iu1SBCLTm-lbfOsYfiypV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Unknown age,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").Value = ThisWorkbook.Sheets("sheet1").Range("EP10")
IE.Document.GetElementByID("H7Iu1SBCLTm-c2lLmaFNeoE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("EQ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("ER10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ES10")
IE.Document.GetElementByID("H7Iu1SBCLTm-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("ET10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("EU10")
IE.Document.GetElementByID("H7Iu1SBCLTm-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("EV10")
IE.Document.GetElementByID("H7Iu1SBCLTm-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("EW10")
IE.Document.GetElementByID("H7Iu1SBCLTm-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("EX10")
IE.Document.GetElementByID("H7Iu1SBCLTm-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("EY10")
IE.Document.GetElementByID("H7Iu1SBCLTm-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("EZ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("FA10")
IE.Document.GetElementByID("H7Iu1SBCLTm-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("FB10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("FC10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FD10")
IE.Document.GetElementByID("H7Iu1SBCLTm-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("FE10")
IE.Document.GetElementByID("H7Iu1SBCLTm-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("FF10")
IE.Document.GetElementByID("H7Iu1SBCLTm-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("FG10")
IE.Document.GetElementByID("H7Iu1SBCLTm-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("FH10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("FI10")
IE.Document.GetElementByID("H7Iu1SBCLTm-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("FJ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("FK10")
IE.Document.GetElementByID("H7Iu1SBCLTm-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("FL10")
IE.Document.GetElementByID("H7Iu1SBCLTm-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("FM10")
IE.Document.GetElementByID("H7Iu1SBCLTm-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("FN10")
IE.Document.GetElementByID("H7Iu1SBCLTm-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("FO10")
IE.Document.GetElementByID("H7Iu1SBCLTm-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("FP10")
IE.Document.GetElementByID("H7Iu1SBCLTm-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("FQ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("FR10")
IE.Document.GetElementByID("H7Iu1SBCLTm-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("FS10")
IE.Document.GetElementByID("H7Iu1SBCLTm-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("FT10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("FU10")
IE.Document.GetElementByID("H7Iu1SBCLTm-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("FV10")
IE.Document.GetElementByID("H7Iu1SBCLTm-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("FW10")
IE.Document.GetElementByID("H7Iu1SBCLTm-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("FX10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("FY10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("FZ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("GA10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("GB10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("GC10")
IE.Document.GetElementByID("H7Iu1SBCLTm-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("GD10")
IE.Document.GetElementByID("H7Iu1SBCLTm-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("GE10")
IE.Document.GetElementByID("H7Iu1SBCLTm-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("GF10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("GG10")
IE.Document.GetElementByID("H7Iu1SBCLTm-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("GH10")
IE.Document.GetElementByID("H7Iu1SBCLTm-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("GI10")
IE.Document.GetElementByID("H7Iu1SBCLTm-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("GJ10")
IE.Document.GetElementByID("H7Iu1SBCLTm-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Positive
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("GK10")
IE.Document.GetElementByID("H7Iu1SBCLTm-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Negative
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("GL10")
IE.Document.GetElementByID("H7Iu1SBCLTm-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("GM10")) Then
'<1,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").Value = ThisWorkbook.Sheets("sheet1").Range("GM10")
IE.Document.GetElementByID("K3I0l3A6fNt-PPg7Yzjq0oF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").Value = ThisWorkbook.Sheets("sheet1").Range("GN10")
IE.Document.GetElementByID("K3I0l3A6fNt-X9GstRdTsEy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").Value = ThisWorkbook.Sheets("sheet1").Range("GO10")
IE.Document.GetElementByID("K3I0l3A6fNt-renXtk3VqTM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").Value = ThisWorkbook.Sheets("sheet1").Range("GP10")
IE.Document.GetElementByID("K3I0l3A6fNt-QNgjY1xNF2S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").Value = ThisWorkbook.Sheets("sheet1").Range("GQ10")
IE.Document.GetElementByID("K3I0l3A6fNt-rZH5lIUD4nH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").Value = ThisWorkbook.Sheets("sheet1").Range("GR10")
IE.Document.GetElementByID("K3I0l3A6fNt-prSfkXlKE2r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GS10")
IE.Document.GetElementByID("K3I0l3A6fNt-RnaDS67VAvQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").Value = ThisWorkbook.Sheets("sheet1").Range("GT10")
IE.Document.GetElementByID("K3I0l3A6fNt-yDfHPRaDxwe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").Value = ThisWorkbook.Sheets("sheet1").Range("GU10")
IE.Document.GetElementByID("K3I0l3A6fNt-OdBhPUGWQ5m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").Value = ThisWorkbook.Sheets("sheet1").Range("GV10")
IE.Document.GetElementByID("K3I0l3A6fNt-PFWJho4V0Bq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").Value = ThisWorkbook.Sheets("sheet1").Range("GW10")
IE.Document.GetElementByID("K3I0l3A6fNt-T6zWRBnlJhR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").Value = ThisWorkbook.Sheets("sheet1").Range("GX10")
IE.Document.GetElementByID("K3I0l3A6fNt-X8pGUJitiVE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").Value = ThisWorkbook.Sheets("sheet1").Range("GY10")
IE.Document.GetElementByID("K3I0l3A6fNt-QdKC55saRRw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("GZ10")
IE.Document.GetElementByID("K3I0l3A6fNt-frIsAnU6KOZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("HA10")
IE.Document.GetElementByID("K3I0l3A6fNt-irSyYG6qqBZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").Value = ThisWorkbook.Sheets("sheet1").Range("HB10")
IE.Document.GetElementByID("K3I0l3A6fNt-RnKGfzcpePu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").Value = ThisWorkbook.Sheets("sheet1").Range("HC10")
IE.Document.GetElementByID("K3I0l3A6fNt-KAyyHkzmuL1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").Value = ThisWorkbook.Sheets("sheet1").Range("HD10")
IE.Document.GetElementByID("K3I0l3A6fNt-ltwvGENFQ0F-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").Value = ThisWorkbook.Sheets("sheet1").Range("HE10")
IE.Document.GetElementByID("K3I0l3A6fNt-fhtynTWtvqv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").Value = ThisWorkbook.Sheets("sheet1").Range("HF10")
IE.Document.GetElementByID("K3I0l3A6fNt-QZCuRi4MOLN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").Value = ThisWorkbook.Sheets("sheet1").Range("HG10")
IE.Document.GetElementByID("K3I0l3A6fNt-HYtbCWnAdG9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").Value = ThisWorkbook.Sheets("sheet1").Range("HH10")
IE.Document.GetElementByID("K3I0l3A6fNt-hyVPPHNEwLB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").Value = ThisWorkbook.Sheets("sheet1").Range("HI10")
IE.Document.GetElementByID("K3I0l3A6fNt-eSoHGswqAsd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").Value = ThisWorkbook.Sheets("sheet1").Range("HJ10")
IE.Document.GetElementByID("K3I0l3A6fNt-az6WUd9cNW8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").Value = ThisWorkbook.Sheets("sheet1").Range("HK10")
IE.Document.GetElementByID("K3I0l3A6fNt-BoN2WhPnYl1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").Value = ThisWorkbook.Sheets("sheet1").Range("HL10")
IE.Document.GetElementByID("K3I0l3A6fNt-TU97qv4vJ5O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").Value = ThisWorkbook.Sheets("sheet1").Range("HM10")
IE.Document.GetElementByID("K3I0l3A6fNt-FmEMWg0TP1j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").Value = ThisWorkbook.Sheets("sheet1").Range("HN10")
IE.Document.GetElementByID("K3I0l3A6fNt-c4FaWCHZi2O-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").Value = ThisWorkbook.Sheets("sheet1").Range("HO10")
IE.Document.GetElementByID("K3I0l3A6fNt-zrFplyGIhtL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").Value = ThisWorkbook.Sheets("sheet1").Range("HP10")
IE.Document.GetElementByID("K3I0l3A6fNt-ydvrOz9X2My-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").Value = ThisWorkbook.Sheets("sheet1").Range("HQ10")
IE.Document.GetElementByID("K3I0l3A6fNt-tDVcPbjxTPK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("HR10")
IE.Document.GetElementByID("K3I0l3A6fNt-ldWyKRgvIyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-z6KOjZfpQcx-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-z6KOjZfpQcx-val").Value = ThisWorkbook.Sheets("sheet1").Range("HS10")
IE.Document.GetElementByID("K3I0l3A6fNt-z6KOjZfpQcx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-NHtO8EwLQ9l-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NHtO8EwLQ9l-val").Value = ThisWorkbook.Sheets("sheet1").Range("HT10")
IE.Document.GetElementByID("K3I0l3A6fNt-NHtO8EwLQ9l-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-NlZJe4oDEFK-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NlZJe4oDEFK-val").Value = ThisWorkbook.Sheets("sheet1").Range("HU10")
IE.Document.GetElementByID("K3I0l3A6fNt-NlZJe4oDEFK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-UQaQKObbrwj-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-UQaQKObbrwj-val").Value = ThisWorkbook.Sheets("sheet1").Range("HV10")
IE.Document.GetElementByID("K3I0l3A6fNt-UQaQKObbrwj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-Q27GSYLDkGk-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Q27GSYLDkGk-val").Value = ThisWorkbook.Sheets("sheet1").Range("HW10")
IE.Document.GetElementByID("K3I0l3A6fNt-Q27GSYLDkGk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-NFKXwU6Oeta-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NFKXwU6Oeta-val").Value = ThisWorkbook.Sheets("sheet1").Range("HX10")
IE.Document.GetElementByID("K3I0l3A6fNt-NFKXwU6Oeta-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-KY39qXVMOj1-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-KY39qXVMOj1-val").Value = ThisWorkbook.Sheets("sheet1").Range("HY10")
IE.Document.GetElementByID("K3I0l3A6fNt-KY39qXVMOj1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-pe07Wvr90Zc-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-pe07Wvr90Zc-val").Value = ThisWorkbook.Sheets("sheet1").Range("HZ10")
IE.Document.GetElementByID("K3I0l3A6fNt-pe07Wvr90Zc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-MMyMkF05moq-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-MMyMkF05moq-val").Value = ThisWorkbook.Sheets("sheet1").Range("IA10")
IE.Document.GetElementByID("K3I0l3A6fNt-MMyMkF05moq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-Z0jVIrTmC1P-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Z0jVIrTmC1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("IB10")
IE.Document.GetElementByID("K3I0l3A6fNt-Z0jVIrTmC1P-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-NGYepD2stMO-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-NGYepD2stMO-val").Value = ThisWorkbook.Sheets("sheet1").Range("IC10")
IE.Document.GetElementByID("K3I0l3A6fNt-NGYepD2stMO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-VZNJvQNlECI-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-VZNJvQNlECI-val").Value = ThisWorkbook.Sheets("sheet1").Range("ID10")
IE.Document.GetElementByID("K3I0l3A6fNt-VZNJvQNlECI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").Value = ThisWorkbook.Sheets("sheet1").Range("IE10")
IE.Document.GetElementByID("K3I0l3A6fNt-yPnEtFpqtt5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("IF10")
IE.Document.GetElementByID("K3I0l3A6fNt-f95YntMQY6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Positive
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").Value = ThisWorkbook.Sheets("sheet1").Range("IG10")
IE.Document.GetElementByID("K3I0l3A6fNt-Z2jmPAIHrel-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Negative
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").Focus
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").Value = ThisWorkbook.Sheets("sheet1").Range("IH10")
IE.Document.GetElementByID("K3I0l3A6fNt-X1ckVzLvwRB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("IJ10")) Then
'<1,F
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("IJ10")
IE.Document.GetElementByID("JuMoiYn1jKB-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                               
'1-4,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("IK10")
IE.Document.GetElementByID("JuMoiYn1jKB-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))   
'5-9,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("IL10")
IE.Document.GetElementByID("JuMoiYn1jKB-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'10-14,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("IM10")
IE.Document.GetElementByID("JuMoiYn1jKB-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))      
'15-19,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("IN10")
IE.Document.GetElementByID("JuMoiYn1jKB-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))  
'20-24,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("IO10")
IE.Document.GetElementByID("JuMoiYn1jKB-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))  
'25-29,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("IP10")
IE.Document.GetElementByID("JuMoiYn1jKB-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'30-34,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("IQ10")
IE.Document.GetElementByID("JuMoiYn1jKB-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))  
'35-39,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("IR10")
IE.Document.GetElementByID("JuMoiYn1jKB-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'40-44,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("IS10")
IE.Document.GetElementByID("JuMoiYn1jKB-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2)) 
'45-49,F                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("IT10")
IE.Document.GetElementByID("JuMoiYn1jKB-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'50+,F                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("IU10")
IE.Document.GetElementByID("JuMoiYn1jKB-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                             
'<1,M                                                                                                   
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("IW10")
IE.Document.GetElementByID("JuMoiYn1jKB-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                      
'1-4,M                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("IX10")
IE.Document.GetElementByID("JuMoiYn1jKB-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                                 
'5-9,M                                                                                                  
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("IY10")
IE.Document.GetElementByID("JuMoiYn1jKB-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                        
'10-14,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("IZ10")
IE.Document.GetElementByID("JuMoiYn1jKB-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                               
'15-19,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JA10")
IE.Document.GetElementByID("JuMoiYn1jKB-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                              
'20-24,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("JB10")
IE.Document.GetElementByID("JuMoiYn1jKB-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                                
'25-29,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("JC10")
IE.Document.GetElementByID("JuMoiYn1jKB-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                           
'30-34,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("JD10")
IE.Document.GetElementByID("JuMoiYn1jKB-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                           
'35-39,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("JE10")
IE.Document.GetElementByID("JuMoiYn1jKB-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                             
'40-44,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JF10")
IE.Document.GetElementByID("JuMoiYn1jKB-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                              
'45-49,M                                                                                                
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("JG10")
IE.Document.GetElementByID("JuMoiYn1jKB-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,M
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("JH10")
IE.Document.GetElementByID("JuMoiYn1jKB-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If

'Accepted
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("JJ10")) Then
'<1,F
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("JJ10")
IE.Document.GetElementByID("wkMmlftfTvx-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                               
'1-4,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("JK10")
IE.Document.GetElementByID("wkMmlftfTvx-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))   
'5-9,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("JL10")
IE.Document.GetElementByID("wkMmlftfTvx-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'10-14,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("JM10")
IE.Document.GetElementByID("wkMmlftfTvx-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))      
'15-19,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("JN10")
IE.Document.GetElementByID("wkMmlftfTvx-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))  
'20-24,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("JO10")
IE.Document.GetElementByID("wkMmlftfTvx-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))  
'25-29,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("JP10")
IE.Document.GetElementByID("wkMmlftfTvx-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'30-34,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("JQ10")
IE.Document.GetElementByID("wkMmlftfTvx-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))  
'35-39,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("JR10")
IE.Document.GetElementByID("wkMmlftfTvx-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'40-44,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("JS10")
IE.Document.GetElementByID("wkMmlftfTvx-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2)) 
'45-49,F                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("JT10")
IE.Document.GetElementByID("wkMmlftfTvx-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))    
'50+,F                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("JU10")
IE.Document.GetElementByID("wkMmlftfTvx-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                             
'<1,M                                                                                                   
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("JW10")
IE.Document.GetElementByID("wkMmlftfTvx-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                      
'1-4,M                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("JX10")
IE.Document.GetElementByID("wkMmlftfTvx-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                                 
'5-9,M                                                                                                  
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("JY10")
IE.Document.GetElementByID("wkMmlftfTvx-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                        
'10-14,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("JZ10")
IE.Document.GetElementByID("wkMmlftfTvx-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                               
'15-19,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KA10")
IE.Document.GetElementByID("wkMmlftfTvx-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                              
'20-24,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("KB10")
IE.Document.GetElementByID("wkMmlftfTvx-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                                
'25-29,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("KC10")
IE.Document.GetElementByID("wkMmlftfTvx-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                           
'30-34,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("KD10")
IE.Document.GetElementByID("wkMmlftfTvx-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                           
'35-39,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("KE10")
IE.Document.GetElementByID("wkMmlftfTvx-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                             
'40-44,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("KF10")
IE.Document.GetElementByID("wkMmlftfTvx-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                                                                              
'45-49,M                                                                                                
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("KG10")
IE.Document.GetElementByID("wkMmlftfTvx-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,M
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("KH10")
IE.Document.GetElementByID("wkMmlftfTvx-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("KJ10")) Then
'Elicited
'Unknown age,M
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").Value = ThisWorkbook.Sheets("sheet1").Range("KJ10")
IE.Document.GetElementByID("fpW7iq7zFNN-iQArB1Jys2K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15,F,
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").Value = ThisWorkbook.Sheets("sheet1").Range("KK10")
IE.Document.GetElementByID("fpW7iq7zFNN-BGFCDhyk4M8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15,M
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").Value = ThisWorkbook.Sheets("sheet1").Range("KL10")
IE.Document.GetElementByID("fpW7iq7zFNN-SBUMYkq3pEs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15+,F
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").Value = ThisWorkbook.Sheets("sheet1").Range("KM10")
IE.Document.GetElementByID("fpW7iq7zFNN-er95aeLbIHg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15+,M
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").Focus
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").Value = ThisWorkbook.Sheets("sheet1").Range("KN10")
IE.Document.GetElementByID("fpW7iq7zFNN-RFKoE51NKAq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'New Positives
'Unknown age,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").Value = ThisWorkbook.Sheets("sheet1").Range("KO10")
IE.Document.GetElementByID("Os9GkOOHHJR-Rxd6hW5bqRu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").Value = ThisWorkbook.Sheets("sheet1").Range("KP10")
IE.Document.GetElementByID("Os9GkOOHHJR-gWPhDYzmbw5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").Value = ThisWorkbook.Sheets("sheet1").Range("KQ10")
IE.Document.GetElementByID("Os9GkOOHHJR-LokBv4egnfg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("KR10")
IE.Document.GetElementByID("Os9GkOOHHJR-IsuCX2xSvKQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").Value = ThisWorkbook.Sheets("sheet1").Range("KS10")
IE.Document.GetElementByID("Os9GkOOHHJR-o3zyOwZyxi7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KT10")
IE.Document.GetElementByID("Os9GkOOHHJR-hLjLWfjGWpK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").Value = ThisWorkbook.Sheets("sheet1").Range("KU10")
IE.Document.GetElementByID("Os9GkOOHHJR-uPn8wdfqpnK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("KV10")
IE.Document.GetElementByID("Os9GkOOHHJR-T7F0DwyrbBV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").Value = ThisWorkbook.Sheets("sheet1").Range("KW10")
IE.Document.GetElementByID("Os9GkOOHHJR-vUUk6jQrXdb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").Value = ThisWorkbook.Sheets("sheet1").Range("KX10")
IE.Document.GetElementByID("Os9GkOOHHJR-wem5QqoRkkh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("KY10")
IE.Document.GetElementByID("Os9GkOOHHJR-VemdciGizc8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").Value = ThisWorkbook.Sheets("sheet1").Range("KZ10")
IE.Document.GetElementByID("Os9GkOOHHJR-V6ykris04Kr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("LA10")
IE.Document.GetElementByID("Os9GkOOHHJR-dywO69YrrUq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").Value = ThisWorkbook.Sheets("sheet1").Range("LB10")
IE.Document.GetElementByID("Os9GkOOHHJR-zDtqexNpaj8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").Value = ThisWorkbook.Sheets("sheet1").Range("LC10")
IE.Document.GetElementByID("Os9GkOOHHJR-ClRyt3CO2CU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").Value = ThisWorkbook.Sheets("sheet1").Range("LD10")
IE.Document.GetElementByID("Os9GkOOHHJR-ewxqtAm93uz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").Value = ThisWorkbook.Sheets("sheet1").Range("LE10")
IE.Document.GetElementByID("Os9GkOOHHJR-rHymehDGb3n-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-ew4H9zzs0GI-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-ew4H9zzs0GI-val").Value = ThisWorkbook.Sheets("sheet1").Range("LF10")
IE.Document.GetElementByID("Os9GkOOHHJR-ew4H9zzs0GI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-eVb1NqOEUoq-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-eVb1NqOEUoq-val").Value = ThisWorkbook.Sheets("sheet1").Range("LG10")
IE.Document.GetElementByID("Os9GkOOHHJR-eVb1NqOEUoq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-Ys91wCxDGwp-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-Ys91wCxDGwp-val").Value = ThisWorkbook.Sheets("sheet1").Range("LH10")
IE.Document.GetElementByID("Os9GkOOHHJR-Ys91wCxDGwp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-Lq9WappoJ2W-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-Lq9WappoJ2W-val").Value = ThisWorkbook.Sheets("sheet1").Range("LI10")
IE.Document.GetElementByID("Os9GkOOHHJR-Lq9WappoJ2W-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-oBVan2Rcsdj-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-oBVan2Rcsdj-val").Value = ThisWorkbook.Sheets("sheet1").Range("LJ10")
IE.Document.GetElementByID("Os9GkOOHHJR-oBVan2Rcsdj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M,NP                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-zzHeHMx5Mh1-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-zzHeHMx5Mh1-val").Value = ThisWorkbook.Sheets("sheet1").Range("LK10")
IE.Document.GetElementByID("Os9GkOOHHJR-zzHeHMx5Mh1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))       
'50+,F,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").Value = ThisWorkbook.Sheets("sheet1").Range("LL10")
IE.Document.GetElementByID("Os9GkOOHHJR-fpnwXTQGmD5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Positive
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").Value = ThisWorkbook.Sheets("sheet1").Range("LM10")
IE.Document.GetElementByID("Os9GkOOHHJR-hjgWcKahM96-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'New Negatives
'Unknown age,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").Value = ThisWorkbook.Sheets("sheet1").Range("LN10")
IE.Document.GetElementByID("Os9GkOOHHJR-tb2OliToe2g-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").Value = ThisWorkbook.Sheets("sheet1").Range("LO10")
IE.Document.GetElementByID("Os9GkOOHHJR-G6ksZzf4PuP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("LP10")
IE.Document.GetElementByID("Os9GkOOHHJR-mA6G2IcNQ5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").Value = ThisWorkbook.Sheets("sheet1").Range("LQ10")
IE.Document.GetElementByID("Os9GkOOHHJR-zRdpU5xlOQI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").Value = ThisWorkbook.Sheets("sheet1").Range("LR10")
IE.Document.GetElementByID("Os9GkOOHHJR-fu8H9OdUyZ6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("LS10")
IE.Document.GetElementByID("Os9GkOOHHJR-XqbMOMJhdoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").Value = ThisWorkbook.Sheets("sheet1").Range("LT10")
IE.Document.GetElementByID("Os9GkOOHHJR-WUOsioCfTH1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").Value = ThisWorkbook.Sheets("sheet1").Range("LU10")
IE.Document.GetElementByID("Os9GkOOHHJR-tNnfZGycqoK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").Value = ThisWorkbook.Sheets("sheet1").Range("LV10")
IE.Document.GetElementByID("Os9GkOOHHJR-FsaFnYgYYiE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").Value = ThisWorkbook.Sheets("sheet1").Range("LW10")
IE.Document.GetElementByID("Os9GkOOHHJR-HTuFkqNl46u-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").Value = ThisWorkbook.Sheets("sheet1").Range("LX10")
IE.Document.GetElementByID("Os9GkOOHHJR-EsEgz70ex5M-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").Value = ThisWorkbook.Sheets("sheet1").Range("LY10")
IE.Document.GetElementByID("Os9GkOOHHJR-XDgqQlbNOma-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").Value = ThisWorkbook.Sheets("sheet1").Range("LZ10")
IE.Document.GetElementByID("Os9GkOOHHJR-GcAEOo6pgjG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").Value = ThisWorkbook.Sheets("sheet1").Range("MA10")
IE.Document.GetElementByID("Os9GkOOHHJR-fN5EhNea5na-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").Value = ThisWorkbook.Sheets("sheet1").Range("MB10")
IE.Document.GetElementByID("Os9GkOOHHJR-O4M73r7CEs1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").Value = ThisWorkbook.Sheets("sheet1").Range("MC10")
IE.Document.GetElementByID("Os9GkOOHHJR-GJBPjJZBrRn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").Value = ThisWorkbook.Sheets("sheet1").Range("MD10")
IE.Document.GetElementByID("Os9GkOOHHJR-JqROtRoCBHP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-GNrMxECWqDp-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-GNrMxECWqDp-val").Value = ThisWorkbook.Sheets("sheet1").Range("ME10")
IE.Document.GetElementByID("Os9GkOOHHJR-GNrMxECWqDp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-aReRE4UUoKW-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-aReRE4UUoKW-val").Value = ThisWorkbook.Sheets("sheet1").Range("MF10")
IE.Document.GetElementByID("Os9GkOOHHJR-aReRE4UUoKW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-XEIYBLvAzIb-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-XEIYBLvAzIb-val").Value = ThisWorkbook.Sheets("sheet1").Range("MG10")
IE.Document.GetElementByID("Os9GkOOHHJR-XEIYBLvAzIb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-pVFmF7dKnTq-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-pVFmF7dKnTq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MH10")
IE.Document.GetElementByID("Os9GkOOHHJR-pVFmF7dKnTq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-pW32ZkMbRSO-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-pW32ZkMbRSO-val").Value = ThisWorkbook.Sheets("sheet1").Range("MI10")
IE.Document.GetElementByID("Os9GkOOHHJR-pW32ZkMbRSO-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M,NN                                                                                             
IE.Document.GetElementByID("Os9GkOOHHJR-BiJwnz9vw41-val").Focus                                         
IE.Document.GetElementByID("Os9GkOOHHJR-BiJwnz9vw41-val").Value = ThisWorkbook.Sheets("sheet1").Range("MJ10")
IE.Document.GetElementByID("Os9GkOOHHJR-BiJwnz9vw41-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").Value = ThisWorkbook.Sheets("sheet1").Range("MK10")
IE.Document.GetElementByID("Os9GkOOHHJR-mN07ApGjAKh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,Negative
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").Focus
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").Value = ThisWorkbook.Sheets("sheet1").Range("ML10")
IE.Document.GetElementByID("Os9GkOOHHJR-rL9fEh5MSHf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("MN10")) Then
'<10-14 Female
IE.Document.GetElementByID("IvI3KbJILcD-vpJXRljbooI-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-vpJXRljbooI-val").Value = ThisWorkbook.Sheets("sheet1").Range("MN10")
IE.Document.GetElementByID("IvI3KbJILcD-vpJXRljbooI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15-19 Female
IE.Document.GetElementByID("IvI3KbJILcD-nN1BTeF5WuG-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-nN1BTeF5WuG-val").Value = ThisWorkbook.Sheets("sheet1").Range("MO10")
IE.Document.GetElementByID("IvI3KbJILcD-nN1BTeF5WuG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<20-24 Female
IE.Document.GetElementByID("IvI3KbJILcD-NyElGSpWLWv-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-NyElGSpWLWv-val").Value = ThisWorkbook.Sheets("sheet1").Range("MP10")
IE.Document.GetElementByID("IvI3KbJILcD-NyElGSpWLWv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<25-29 Female
IE.Document.GetElementByID("IvI3KbJILcD-ptqjXkxioQB-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-ptqjXkxioQB-val").Value = ThisWorkbook.Sheets("sheet1").Range("MQ10")
IE.Document.GetElementByID("IvI3KbJILcD-ptqjXkxioQB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<30-34 Female
IE.Document.GetElementByID("IvI3KbJILcD-sQ2iBuN22yj-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-sQ2iBuN22yj-val").Value = ThisWorkbook.Sheets("sheet1").Range("MR10")
IE.Document.GetElementByID("IvI3KbJILcD-sQ2iBuN22yj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<35-39 Female
IE.Document.GetElementByID("IvI3KbJILcD-U65bkLSdUp7-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-U65bkLSdUp7-val").Value = ThisWorkbook.Sheets("sheet1").Range("MS10")
IE.Document.GetElementByID("IvI3KbJILcD-U65bkLSdUp7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<40-44 Female
IE.Document.GetElementByID("IvI3KbJILcD-U9RGD1yB6AS-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-U9RGD1yB6AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("MT10")
IE.Document.GetElementByID("IvI3KbJILcD-U9RGD1yB6AS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<45-49 Female
IE.Document.GetElementByID("IvI3KbJILcD-UEccZfdUNLf-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-UEccZfdUNLf-val").Value = ThisWorkbook.Sheets("sheet1").Range("MU10")
IE.Document.GetElementByID("IvI3KbJILcD-UEccZfdUNLf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<50+ Female
IE.Document.GetElementByID("IvI3KbJILcD-m9JzOvqcfIX-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-m9JzOvqcfIX-val").Value = ThisWorkbook.Sheets("sheet1").Range("MV10")
IE.Document.GetElementByID("IvI3KbJILcD-m9JzOvqcfIX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))



'<10-14 Male
IE.Document.GetElementByID("IvI3KbJILcD-WvcKCUGBlWW-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-WvcKCUGBlWW-val").Value = ThisWorkbook.Sheets("sheet1").Range("MW10")
IE.Document.GetElementByID("IvI3KbJILcD-WvcKCUGBlWW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15-19 Male
IE.Document.GetElementByID("IvI3KbJILcD-Mvt3gRxWbl8-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-Mvt3gRxWbl8-val").Value = ThisWorkbook.Sheets("sheet1").Range("MX10")
IE.Document.GetElementByID("IvI3KbJILcD-Mvt3gRxWbl8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<20-24 Male
IE.Document.GetElementByID("IvI3KbJILcD-wS6c6pKnBzB-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-wS6c6pKnBzB-val").Value = ThisWorkbook.Sheets("sheet1").Range("MY10")
IE.Document.GetElementByID("IvI3KbJILcD-wS6c6pKnBzB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<25-29 Male
IE.Document.GetElementByID("IvI3KbJILcD-cakoLejWzwq-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-cakoLejWzwq-val").Value = ThisWorkbook.Sheets("sheet1").Range("MZ10")
IE.Document.GetElementByID("IvI3KbJILcD-cakoLejWzwq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<30-34 Male
IE.Document.GetElementByID("IvI3KbJILcD-RZKQIoa9koW-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-RZKQIoa9koW-val").Value = ThisWorkbook.Sheets("sheet1").Range("NA10")
IE.Document.GetElementByID("IvI3KbJILcD-RZKQIoa9koW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<35-39 Male
IE.Document.GetElementByID("IvI3KbJILcD-GoGACmQl6uY-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-GoGACmQl6uY-val").Value = ThisWorkbook.Sheets("sheet1").Range("NB10")
IE.Document.GetElementByID("IvI3KbJILcD-GoGACmQl6uY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<40-44 Male
IE.Document.GetElementByID("IvI3KbJILcD-iUqbs9vu7Uu-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-iUqbs9vu7Uu-val").Value = ThisWorkbook.Sheets("sheet1").Range("NC10")
IE.Document.GetElementByID("IvI3KbJILcD-iUqbs9vu7Uu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<45-49 Male
IE.Document.GetElementByID("IvI3KbJILcD-gqPrEjurqem-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-gqPrEjurqem-val").Value = ThisWorkbook.Sheets("sheet1").Range("ND10")
IE.Document.GetElementByID("IvI3KbJILcD-gqPrEjurqem-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<50+ Male
IE.Document.GetElementByID("IvI3KbJILcD-X7NYFk3xhP8-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-X7NYFk3xhP8-val").Value = ThisWorkbook.Sheets("sheet1").Range("NE10")
IE.Document.GetElementByID("IvI3KbJILcD-X7NYFk3xhP8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'.............................................................................................................
'.............................................................................................................

'<10-14 Female
IE.Document.GetElementByID("IvI3KbJILcD-ZlfvMsPqqmT-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-ZlfvMsPqqmT-val").Value = ThisWorkbook.Sheets("sheet1").Range("NF10")
IE.Document.GetElementByID("IvI3KbJILcD-ZlfvMsPqqmT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15-19 Female
IE.Document.GetElementByID("IvI3KbJILcD-tbwp7QwAXxa-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-tbwp7QwAXxa-val").Value = ThisWorkbook.Sheets("sheet1").Range("NG10")
IE.Document.GetElementByID("IvI3KbJILcD-tbwp7QwAXxa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<20-24 Female
IE.Document.GetElementByID("IvI3KbJILcD-mOXqNYPrtUD-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-mOXqNYPrtUD-val").Value = ThisWorkbook.Sheets("sheet1").Range("NH10")
IE.Document.GetElementByID("IvI3KbJILcD-mOXqNYPrtUD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<25-29 Female
IE.Document.GetElementByID("IvI3KbJILcD-Y5oW92HtesZ-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-Y5oW92HtesZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("NI10")
IE.Document.GetElementByID("IvI3KbJILcD-Y5oW92HtesZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<30-34 Female
IE.Document.GetElementByID("IvI3KbJILcD-onyrqPv9KNE-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-onyrqPv9KNE-val").Value = ThisWorkbook.Sheets("sheet1").Range("NJ10")
IE.Document.GetElementByID("IvI3KbJILcD-onyrqPv9KNE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<35-39 Female
IE.Document.GetElementByID("IvI3KbJILcD-d20MZrn4Eln-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-d20MZrn4Eln-val").Value = ThisWorkbook.Sheets("sheet1").Range("NK10")
IE.Document.GetElementByID("IvI3KbJILcD-d20MZrn4Eln-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<40-44 Female
IE.Document.GetElementByID("IvI3KbJILcD-k7RAtvkyMUR-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-k7RAtvkyMUR-val").Value = ThisWorkbook.Sheets("sheet1").Range("NL10")
IE.Document.GetElementByID("IvI3KbJILcD-k7RAtvkyMUR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<45-49 Female
IE.Document.GetElementByID("IvI3KbJILcD-VPru2f26ZSB-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-VPru2f26ZSB-val").Value = ThisWorkbook.Sheets("sheet1").Range("NM10")
IE.Document.GetElementByID("IvI3KbJILcD-VPru2f26ZSB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<50+ Female
IE.Document.GetElementByID("IvI3KbJILcD-FrSv7fuPqvi-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-FrSv7fuPqvi-val").Value = ThisWorkbook.Sheets("sheet1").Range("NN10")
IE.Document.GetElementByID("IvI3KbJILcD-FrSv7fuPqvi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))


'<10-14 Male
IE.Document.GetElementByID("IvI3KbJILcD-ey60Eh4RyK9-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-ey60Eh4RyK9-val").Value = ThisWorkbook.Sheets("sheet1").Range("NO10")
IE.Document.GetElementByID("IvI3KbJILcD-ey60Eh4RyK9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15-19 Male
IE.Document.GetElementByID("IvI3KbJILcD-rEyueo9TR84-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-rEyueo9TR84-val").Value = ThisWorkbook.Sheets("sheet1").Range("NP10")
IE.Document.GetElementByID("IvI3KbJILcD-rEyueo9TR84-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<20-24 Male
IE.Document.GetElementByID("IvI3KbJILcD-iPgWd22TJoU-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-iPgWd22TJoU-val").Value = ThisWorkbook.Sheets("sheet1").Range("NQ10")
IE.Document.GetElementByID("IvI3KbJILcD-iPgWd22TJoU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<25-29 Male
IE.Document.GetElementByID("IvI3KbJILcD-yrwFtriUxF7-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-yrwFtriUxF7-val").Value = ThisWorkbook.Sheets("sheet1").Range("NR10")
IE.Document.GetElementByID("IvI3KbJILcD-yrwFtriUxF7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<30-34 Male
IE.Document.GetElementByID("IvI3KbJILcD-QKbiiiEUYIO-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-QKbiiiEUYIO-val").Value = ThisWorkbook.Sheets("sheet1").Range("NS10")
IE.Document.GetElementByID("IvI3KbJILcD-QKbiiiEUYIO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<35-39 Male
IE.Document.GetElementByID("IvI3KbJILcD-F3VzQk7J54W-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-F3VzQk7J54W-val").Value = ThisWorkbook.Sheets("sheet1").Range("NT10")
IE.Document.GetElementByID("IvI3KbJILcD-F3VzQk7J54W-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<40-44 Male
IE.Document.GetElementByID("IvI3KbJILcD-O9nOl3oQyBF-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-O9nOl3oQyBF-val").Value = ThisWorkbook.Sheets("sheet1").Range("NU10")
IE.Document.GetElementByID("IvI3KbJILcD-O9nOl3oQyBF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<45-49 Male
IE.Document.GetElementByID("IvI3KbJILcD-Oyo1mxlQwOh-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-Oyo1mxlQwOh-val").Value = ThisWorkbook.Sheets("sheet1").Range("NV10")
IE.Document.GetElementByID("IvI3KbJILcD-Oyo1mxlQwOh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<50+ Male
IE.Document.GetElementByID("IvI3KbJILcD-yy0VIRCYJy9-val").Focus
IE.Document.GetElementByID("IvI3KbJILcD-yy0VIRCYJy9-val").Value = ThisWorkbook.Sheets("sheet1").Range("NW10")
IE.Document.GetElementByID("IvI3KbJILcD-yy0VIRCYJy9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'.............................................................................................................
'.............................................................................................................

'<PWID  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-cVQALQbbdeJ-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-cVQALQbbdeJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("NX10")
IE.Document.GetElementByID("CfSIX5yTSdw-cVQALQbbdeJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<PWID  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-lm6WNi1cnU4-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-lm6WNi1cnU4-val").Value = ThisWorkbook.Sheets("sheet1").Range("OC10")
IE.Document.GetElementByID("CfSIX5yTSdw-lm6WNi1cnU4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<MSM  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-jEDTO4WJAzl-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-jEDTO4WJAzl-val").Value = ThisWorkbook.Sheets("sheet1").Range("NY10")
IE.Document.GetElementByID("CfSIX5yTSdw-jEDTO4WJAzl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<MSM  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-t4teq5No1lb-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-t4teq5No1lb-val").Value = ThisWorkbook.Sheets("sheet1").Range("OD10")
IE.Document.GetElementByID("CfSIX5yTSdw-t4teq5No1lb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<Transgender People  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-URR9fz0msKi-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-URR9fz0msKi-val").Value = ThisWorkbook.Sheets("sheet1").Range("NZ10")
IE.Document.GetElementByID("CfSIX5yTSdw-URR9fz0msKi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<Transgender People  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-tR1agKinTUi-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-tR1agKinTUi-val").Value = ThisWorkbook.Sheets("sheet1").Range("OE10")
IE.Document.GetElementByID("CfSIX5yTSdw-tR1agKinTUi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<FSW  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-oT1KinoX60T-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-oT1KinoX60T-val").Value = ThisWorkbook.Sheets("sheet1").Range("OA10")
IE.Document.GetElementByID("CfSIX5yTSdw-oT1KinoX60T-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<FSW  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-UpkVZP5xLHK-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-UpkVZP5xLHK-val").Value = ThisWorkbook.Sheets("sheet1").Range("OF10")
IE.Document.GetElementByID("CfSIX5yTSdw-UpkVZP5xLHK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<People in prison and other closed settings  Directly Assisted
IE.Document.GetElementByID("CfSIX5yTSdw-z9AHJ7VXAUI-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-z9AHJ7VXAUI-val").Value = ThisWorkbook.Sheets("sheet1").Range("OB10")
IE.Document.GetElementByID("CfSIX5yTSdw-z9AHJ7VXAUI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<People in prison and other closed settings  Unassisted
IE.Document.GetElementByID("CfSIX5yTSdw-bZVkZBLtX1i-val").Focus
IE.Document.GetElementByID("CfSIX5yTSdw-bZVkZBLtX1i-val").Value = ThisWorkbook.Sheets("sheet1").Range("OG10")
IE.Document.GetElementByID("CfSIX5yTSdw-bZVkZBLtX1i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

'<Unassisted self-testing kit used by: Self
'IE.Document.GetElementByID("ovQaECwOS1M-mYMRmrtoxVn-val").Focus
'IE.Document.GetElementByID("ovQaECwOS1M-mYMRmrtoxVn-val").Value = ThisWorkbook.Sheets("sheet1").Range("OH10")
'IE.Document.GetElementByID("ovQaECwOS1M-mYMRmrtoxVn-val").dispatchEvent evt
'Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<Unassisted self-testing kit used by: Sex Partner
IE.Document.GetElementByID("ovQaECwOS1M-loZmPoGpvEZ-val").Focus
IE.Document.GetElementByID("ovQaECwOS1M-loZmPoGpvEZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OI10")
IE.Document.GetElementByID("ovQaECwOS1M-loZmPoGpvEZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<Unassisted self-testing kit used by: Other
IE.Document.GetElementByID("ovQaECwOS1M-fPFQkPZwhi8-val").Focus
IE.Document.GetElementByID("ovQaECwOS1M-fPFQkPZwhi8-val").Value = ThisWorkbook.Sheets("sheet1").Range("OJ10")
IE.Document.GetElementByID("ovQaECwOS1M-fPFQkPZwhi8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OL10")) Then
'Numerator
'10-14,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").Value = ThisWorkbook.Sheets("sheet1").Range("OL10")
IE.Document.GetElementByID("fg53NvKg3EN-VAzPX0jofbR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").Value = ThisWorkbook.Sheets("sheet1").Range("OM10")
IE.Document.GetElementByID("fg53NvKg3EN-lno7KOoC6A6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").Value = ThisWorkbook.Sheets("sheet1").Range("ON10")
IE.Document.GetElementByID("fg53NvKg3EN-t6J1nthxMhI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").Value = ThisWorkbook.Sheets("sheet1").Range("OO10")
IE.Document.GetElementByID("fg53NvKg3EN-lQcycFNg0rl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").Value = ThisWorkbook.Sheets("sheet1").Range("OP10")
IE.Document.GetElementByID("fg53NvKg3EN-niWaVaEzwro-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").Value = ThisWorkbook.Sheets("sheet1").Range("OQ10")
IE.Document.GetElementByID("fg53NvKg3EN-v1SkxpwKWND-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").Value = ThisWorkbook.Sheets("sheet1").Range("OR10")
IE.Document.GetElementByID("fg53NvKg3EN-HKWsaDC3VlV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").Value = ThisWorkbook.Sheets("sheet1").Range("OS10")
IE.Document.GetElementByID("fg53NvKg3EN-M1YseWnfCmm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").Value = ThisWorkbook.Sheets("sheet1").Range("OT10")
IE.Document.GetElementByID("fg53NvKg3EN-jzATmmu61Pq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,KP
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").Value = ThisWorkbook.Sheets("sheet1").Range("OU10")
IE.Document.GetElementByID("fg53NvKg3EN-E6ivU7AttrG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,NP
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").Value = ThisWorkbook.Sheets("sheet1").Range("OV10")
IE.Document.GetElementByID("fg53NvKg3EN-aDO5rKzIUjj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F,NN
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").Focus
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").Value = ThisWorkbook.Sheets("sheet1").Range("OW10")
IE.Document.GetElementByID("fg53NvKg3EN-mFpk2mIJQzt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End if
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("OY10")) Then
'Denominator
'10-14,F
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").Value = ThisWorkbook.Sheets("sheet1").Range("OY10")
IE.Document.GetElementByID("RHN2Ui10Ivu-QazyoPSt2XH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,F
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("OZ10")
IE.Document.GetElementByID("RHN2Ui10Ivu-UN0vy0VSyHQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").Value = ThisWorkbook.Sheets("sheet1").Range("PA10")
IE.Document.GetElementByID("RHN2Ui10Ivu-zCrKbLh9x6i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").Focus
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").Value = ThisWorkbook.Sheets("sheet1").Range("PB10")
IE.Document.GetElementByID("RHN2Ui10Ivu-AkOKGZjTuJH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("PD10")) Then
'EID
'0-2
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").Value = ThisWorkbook.Sheets("sheet1").Range("PD10")
IE.Document.GetElementByID("I9vfJMV5x7A-TRTNKzpystS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'2-12
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Focus
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").Value = ThisWorkbook.Sheets("sheet1").Range("PE10")
IE.Document.GetElementByID("I9vfJMV5x7A-El4ysmXTL9r-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End if
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("PG10")) Then
'HEI_POS
'0-2
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").Value = ThisWorkbook.Sheets("sheet1").Range("PG10")
IE.Document.GetElementByID("y1sRrKaPeKe-VG9llDXZfqR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'2-12
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Focus
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").Value = ThisWorkbook.Sheets("sheet1").Range("PH10")
IE.Document.GetElementByID("y1sRrKaPeKe-liIscF6uc2E-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'ART
'0-2
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").Value = ThisWorkbook.Sheets("sheet1").Range("PI10")
IE.Document.GetElementByID("XuHtzXGDS00-oYuICUnILbz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'2-12
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Focus
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").Value = ThisWorkbook.Sheets("sheet1").Range("PJ10")
IE.Document.GetElementByID("XuHtzXGDS00-bZ4b1EW7Uw7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("PL10")) Then
'Known Positives
'<1,F,KP
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").Value = ThisWorkbook.Sheets("sheet1").Range("PL10")
IE.Document.GetElementByID("tnthrE5AclR-SJ6ny6KglYz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,KP
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").Value = ThisWorkbook.Sheets("sheet1").Range("PM10")
IE.Document.GetElementByID("tnthrE5AclR-lS34HFr7wcT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").Value = ThisWorkbook.Sheets("sheet1").Range("PN10")
IE.Document.GetElementByID("tnthrE5AclR-iqG5y4IclYv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").Value = ThisWorkbook.Sheets("sheet1").Range("PO10")
IE.Document.GetElementByID("tnthrE5AclR-vHcPl7i3ldt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").Value = ThisWorkbook.Sheets("sheet1").Range("PP10")
IE.Document.GetElementByID("tnthrE5AclR-ljbRunlmafF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").Value = ThisWorkbook.Sheets("sheet1").Range("PQ10")
IE.Document.GetElementByID("tnthrE5AclR-Fv4AnNRCi8b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").Value = ThisWorkbook.Sheets("sheet1").Range("PR10")
IE.Document.GetElementByID("tnthrE5AclR-nr8KgqTWYe8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").Value = ThisWorkbook.Sheets("sheet1").Range("PS10")
IE.Document.GetElementByID("tnthrE5AclR-X9oQCOXFLpS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").Value = ThisWorkbook.Sheets("sheet1").Range("PT10")
IE.Document.GetElementByID("tnthrE5AclR-jVLZPId7wiX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").Value = ThisWorkbook.Sheets("sheet1").Range("PU10")
IE.Document.GetElementByID("tnthrE5AclR-R0YTc9AapF2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("PV10")
IE.Document.GetElementByID("tnthrE5AclR-ivu836qG5iQ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").Value = ThisWorkbook.Sheets("sheet1").Range("PW10")
IE.Document.GetElementByID("tnthrE5AclR-JV0F6TJ0vRu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").Value = ThisWorkbook.Sheets("sheet1").Range("PX10")
IE.Document.GetElementByID("tnthrE5AclR-rbhnf7MLIGp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").Value = ThisWorkbook.Sheets("sheet1").Range("PY10")
IE.Document.GetElementByID("tnthrE5AclR-VrVDyUAH0Ee-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").Value = ThisWorkbook.Sheets("sheet1").Range("PZ10")
IE.Document.GetElementByID("tnthrE5AclR-dzXe1VrUu9f-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").Value = ThisWorkbook.Sheets("sheet1").Range("QA10")
IE.Document.GetElementByID("tnthrE5AclR-rutEzItUoZs-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").Value = ThisWorkbook.Sheets("sheet1").Range("QB10")
IE.Document.GetElementByID("tnthrE5AclR-O0qSiQtS832-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").Value = ThisWorkbook.Sheets("sheet1").Range("QC10")
IE.Document.GetElementByID("tnthrE5AclR-BdeLiKwXiCI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").Value = ThisWorkbook.Sheets("sheet1").Range("QD10")
IE.Document.GetElementByID("tnthrE5AclR-fRexSBGA7FN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").Value = ThisWorkbook.Sheets("sheet1").Range("QE10")
IE.Document.GetElementByID("tnthrE5AclR-p3xNmMndXrl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").Value = ThisWorkbook.Sheets("sheet1").Range("QF10")
IE.Document.GetElementByID("tnthrE5AclR-BZHzwUBVP7u-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M,KP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").Value = ThisWorkbook.Sheets("sheet1").Range("QG10")
IE.Document.GetElementByID("tnthrE5AclR-dezDoHYzUWu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F,KP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").Value = ThisWorkbook.Sheets("sheet1").Range("QH10")
IE.Document.GetElementByID("tnthrE5AclR-W2jt0eaDKcD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,KP
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").Value = ThisWorkbook.Sheets("sheet1").Range("QI10")
IE.Document.GetElementByID("tnthrE5AclR-rGASCBRaR2U-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("QJ10")) Then
'New Positives
'<1,F,NP
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").Value = ThisWorkbook.Sheets("sheet1").Range("QJ10")
IE.Document.GetElementByID("tnthrE5AclR-gWPhDYzmbw5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,NP
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").Value = ThisWorkbook.Sheets("sheet1").Range("QK10")
IE.Document.GetElementByID("tnthrE5AclR-LokBv4egnfg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,NP
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("QL10")
IE.Document.GetElementByID("tnthrE5AclR-IsuCX2xSvKQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,NP
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").Value = ThisWorkbook.Sheets("sheet1").Range("QM10")
IE.Document.GetElementByID("tnthrE5AclR-o3zyOwZyxi7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").Value = ThisWorkbook.Sheets("sheet1").Range("QN10")
IE.Document.GetElementByID("tnthrE5AclR-hLjLWfjGWpK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").Value = ThisWorkbook.Sheets("sheet1").Range("QO10")
IE.Document.GetElementByID("tnthrE5AclR-uPn8wdfqpnK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").Value = ThisWorkbook.Sheets("sheet1").Range("QP10")
IE.Document.GetElementByID("tnthrE5AclR-T7F0DwyrbBV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").Value = ThisWorkbook.Sheets("sheet1").Range("QQ10")
IE.Document.GetElementByID("tnthrE5AclR-vUUk6jQrXdb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").Value = ThisWorkbook.Sheets("sheet1").Range("QR10")
IE.Document.GetElementByID("tnthrE5AclR-wem5QqoRkkh-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").Value = ThisWorkbook.Sheets("sheet1").Range("QS10")
IE.Document.GetElementByID("tnthrE5AclR-VemdciGizc8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").Value = ThisWorkbook.Sheets("sheet1").Range("QT10")
IE.Document.GetElementByID("tnthrE5AclR-V6ykris04Kr-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").Value = ThisWorkbook.Sheets("sheet1").Range("QU10")
IE.Document.GetElementByID("tnthrE5AclR-dywO69YrrUq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").Value = ThisWorkbook.Sheets("sheet1").Range("QV10")
IE.Document.GetElementByID("tnthrE5AclR-zDtqexNpaj8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").Value = ThisWorkbook.Sheets("sheet1").Range("QW10")
IE.Document.GetElementByID("tnthrE5AclR-ClRyt3CO2CU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").Value = ThisWorkbook.Sheets("sheet1").Range("QX10")
IE.Document.GetElementByID("tnthrE5AclR-ewxqtAm93uz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").Value = ThisWorkbook.Sheets("sheet1").Range("QY10")
IE.Document.GetElementByID("tnthrE5AclR-rHymehDGb3n-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").Value = ThisWorkbook.Sheets("sheet1").Range("QZ10")
IE.Document.GetElementByID("tnthrE5AclR-ew4H9zzs0GI-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").Value = ThisWorkbook.Sheets("sheet1").Range("RA10")
IE.Document.GetElementByID("tnthrE5AclR-eVb1NqOEUoq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").Value = ThisWorkbook.Sheets("sheet1").Range("RB10")
IE.Document.GetElementByID("tnthrE5AclR-Ys91wCxDGwp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").Value = ThisWorkbook.Sheets("sheet1").Range("RC10")
IE.Document.GetElementByID("tnthrE5AclR-Lq9WappoJ2W-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").Value = ThisWorkbook.Sheets("sheet1").Range("RD10")
IE.Document.GetElementByID("tnthrE5AclR-oBVan2Rcsdj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M,NP                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").Value = ThisWorkbook.Sheets("sheet1").Range("RE10")
IE.Document.GetElementByID("tnthrE5AclR-zzHeHMx5Mh1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F,NP                                                                                               
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").Value = ThisWorkbook.Sheets("sheet1").Range("RF10")
IE.Document.GetElementByID("tnthrE5AclR-fpnwXTQGmD5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,NP
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").Value = ThisWorkbook.Sheets("sheet1").Range("RG10")
IE.Document.GetElementByID("tnthrE5AclR-hjgWcKahM96-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("RH10")) Then
'New Negatives
'<1,F,NN
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").Value = ThisWorkbook.Sheets("sheet1").Range("RH10")
IE.Document.GetElementByID("tnthrE5AclR-G6ksZzf4PuP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<1,M,NN
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("RI10")
IE.Document.GetElementByID("tnthrE5AclR-mA6G2IcNQ5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F,NN
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").Value = ThisWorkbook.Sheets("sheet1").Range("RJ10")
IE.Document.GetElementByID("tnthrE5AclR-zRdpU5xlOQI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,M,NN
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").Value = ThisWorkbook.Sheets("sheet1").Range("RK10")
IE.Document.GetElementByID("tnthrE5AclR-fu8H9OdUyZ6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F,NN
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("RL10")
IE.Document.GetElementByID("tnthrE5AclR-XqbMOMJhdoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,M,NN
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").Value = ThisWorkbook.Sheets("sheet1").Range("RM10")
IE.Document.GetElementByID("tnthrE5AclR-WUOsioCfTH1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F,NN
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").Value = ThisWorkbook.Sheets("sheet1").Range("RN10")
IE.Document.GetElementByID("tnthrE5AclR-tNnfZGycqoK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").Value = ThisWorkbook.Sheets("sheet1").Range("RO10")
IE.Document.GetElementByID("tnthrE5AclR-FsaFnYgYYiE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").Value = ThisWorkbook.Sheets("sheet1").Range("RP10")
IE.Document.GetElementByID("tnthrE5AclR-HTuFkqNl46u-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").Value = ThisWorkbook.Sheets("sheet1").Range("RQ10")
IE.Document.GetElementByID("tnthrE5AclR-EsEgz70ex5M-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").Value = ThisWorkbook.Sheets("sheet1").Range("RR10")
IE.Document.GetElementByID("tnthrE5AclR-XDgqQlbNOma-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").Value = ThisWorkbook.Sheets("sheet1").Range("RS10")
IE.Document.GetElementByID("tnthrE5AclR-GcAEOo6pgjG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").Value = ThisWorkbook.Sheets("sheet1").Range("RT10")
IE.Document.GetElementByID("tnthrE5AclR-fN5EhNea5na-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").Value = ThisWorkbook.Sheets("sheet1").Range("RU10")
IE.Document.GetElementByID("tnthrE5AclR-O4M73r7CEs1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").Value = ThisWorkbook.Sheets("sheet1").Range("RV10")
IE.Document.GetElementByID("tnthrE5AclR-GJBPjJZBrRn-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").Value = ThisWorkbook.Sheets("sheet1").Range("RW10")
IE.Document.GetElementByID("tnthrE5AclR-JqROtRoCBHP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").Value = ThisWorkbook.Sheets("sheet1").Range("RX10")
IE.Document.GetElementByID("tnthrE5AclR-GNrMxECWqDp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").Value = ThisWorkbook.Sheets("sheet1").Range("RY10")
IE.Document.GetElementByID("tnthrE5AclR-aReRE4UUoKW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").Value = ThisWorkbook.Sheets("sheet1").Range("RZ10")
IE.Document.GetElementByID("tnthrE5AclR-XEIYBLvAzIb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SA10")
IE.Document.GetElementByID("tnthrE5AclR-pVFmF7dKnTq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").Value = ThisWorkbook.Sheets("sheet1").Range("SB10")
IE.Document.GetElementByID("tnthrE5AclR-pW32ZkMbRSO-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M,NN                                                                                             
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").Focus                                         
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").Value = ThisWorkbook.Sheets("sheet1").Range("SC10")
IE.Document.GetElementByID("tnthrE5AclR-BiJwnz9vw41-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,F,NN
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").Value = ThisWorkbook.Sheets("sheet1").Range("SD10")
IE.Document.GetElementByID("tnthrE5AclR-mN07ApGjAKh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M,NN
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").Focus
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").Value = ThisWorkbook.Sheets("sheet1").Range("SE10")
IE.Document.GetElementByID("tnthrE5AclR-rL9fEh5MSHf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("SG10")) Then
'Denominator
'<1,F
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").Value = ThisWorkbook.Sheets("sheet1").Range("SG10")
IE.Document.GetElementByID("uOfuBlHwdn7-azsFj6a0LS2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").Value = ThisWorkbook.Sheets("sheet1").Range("SH10")
IE.Document.GetElementByID("uOfuBlHwdn7-T6boOyU77Ow-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").Value = ThisWorkbook.Sheets("sheet1").Range("SI10")
IE.Document.GetElementByID("uOfuBlHwdn7-QoyZ4jR8W84-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").Value = ThisWorkbook.Sheets("sheet1").Range("SJ10")
IE.Document.GetElementByID("uOfuBlHwdn7-t3gknDpzlB3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").Value = ThisWorkbook.Sheets("sheet1").Range("SK10")
IE.Document.GetElementByID("uOfuBlHwdn7-csHwh8Os7Ly-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").Value = ThisWorkbook.Sheets("sheet1").Range("SL10")
IE.Document.GetElementByID("uOfuBlHwdn7-aoVZsO1PZWR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").Value = ThisWorkbook.Sheets("sheet1").Range("SM10")
IE.Document.GetElementByID("uOfuBlHwdn7-lf9E3w8D5Hf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").Value = ThisWorkbook.Sheets("sheet1").Range("SN10")
IE.Document.GetElementByID("uOfuBlHwdn7-xWKHVx9CSng-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").Value = ThisWorkbook.Sheets("sheet1").Range("SO10")
IE.Document.GetElementByID("uOfuBlHwdn7-kF58z8fRC42-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").Value = ThisWorkbook.Sheets("sheet1").Range("SP10")
IE.Document.GetElementByID("uOfuBlHwdn7-Mey121eVKzj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").Value = ThisWorkbook.Sheets("sheet1").Range("SQ10")
IE.Document.GetElementByID("uOfuBlHwdn7-kbUM9XmC0Id-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").Value = ThisWorkbook.Sheets("sheet1").Range("SR10")
IE.Document.GetElementByID("uOfuBlHwdn7-IuD1jatkIvP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").Value = ThisWorkbook.Sheets("sheet1").Range("SS10")
IE.Document.GetElementByID("uOfuBlHwdn7-xTYRwz7vBql-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ST10")
IE.Document.GetElementByID("uOfuBlHwdn7-tbzlWEKQNNF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").Value = ThisWorkbook.Sheets("sheet1").Range("SU10")
IE.Document.GetElementByID("uOfuBlHwdn7-Z6fOXuimofv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").Value = ThisWorkbook.Sheets("sheet1").Range("SV10")
IE.Document.GetElementByID("uOfuBlHwdn7-whrB9hVH3Lq-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").Value = ThisWorkbook.Sheets("sheet1").Range("SW10")
IE.Document.GetElementByID("uOfuBlHwdn7-CD9WafYSd0R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").Value = ThisWorkbook.Sheets("sheet1").Range("SX10")
IE.Document.GetElementByID("uOfuBlHwdn7-lV8cuSvl3Hj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SY10")
IE.Document.GetElementByID("uOfuBlHwdn7-WHl3CaJheMm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").Value = ThisWorkbook.Sheets("sheet1").Range("SZ10")
IE.Document.GetElementByID("uOfuBlHwdn7-SUIeS5MHsLm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TA10")
IE.Document.GetElementByID("uOfuBlHwdn7-NcQqIZNfkdp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").Value = ThisWorkbook.Sheets("sheet1").Range("TB10")
IE.Document.GetElementByID("uOfuBlHwdn7-tMJdJ24gicp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").Focus                                         
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").Value = ThisWorkbook.Sheets("sheet1").Range("TC10")
IE.Document.GetElementByID("uOfuBlHwdn7-c0uiEFUIFvC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").Focus
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").Value = ThisWorkbook.Sheets("sheet1").Range("TD10")
IE.Document.GetElementByID("uOfuBlHwdn7-BKmAjLKuCss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("TF10")) Then
'Breastfeeding
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Focus
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").Value = ThisWorkbook.Sheets("sheet1").Range("TF10")
IE.Document.GetElementByID("QI0LrOAmBCG-jaxEUorPKgv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))

If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("UE10:UH10")) = 0  Then
'<1,F
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").Value = ThisWorkbook.Sheets("sheet1").Range("TG10")
IE.Document.GetElementByID("yXZtvoYQXcD-OMVFa98P0Yg-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").Value = ThisWorkbook.Sheets("sheet1").Range("TH10")
IE.Document.GetElementByID("yXZtvoYQXcD-dRjezxQktoz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").Value = ThisWorkbook.Sheets("sheet1").Range("TI10")
IE.Document.GetElementByID("yXZtvoYQXcD-zLbjm4E1NsG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").Value = ThisWorkbook.Sheets("sheet1").Range("TJ10")
IE.Document.GetElementByID("yXZtvoYQXcD-AG0milXShQM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").Value = ThisWorkbook.Sheets("sheet1").Range("TK10")
IE.Document.GetElementByID("yXZtvoYQXcD-QqlHrg6f0Sm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").Value = ThisWorkbook.Sheets("sheet1").Range("TL10")
IE.Document.GetElementByID("yXZtvoYQXcD-LyXZybq6Sjf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").Value = ThisWorkbook.Sheets("sheet1").Range("TM10")
IE.Document.GetElementByID("yXZtvoYQXcD-zqARzn2wVj5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").Value = ThisWorkbook.Sheets("sheet1").Range("TN10")
IE.Document.GetElementByID("yXZtvoYQXcD-Vi8sd7mvZW4-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").Value = ThisWorkbook.Sheets("sheet1").Range("TO10")
IE.Document.GetElementByID("yXZtvoYQXcD-hRq4baaUamW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").Value = ThisWorkbook.Sheets("sheet1").Range("TP10")
IE.Document.GetElementByID("yXZtvoYQXcD-PEXIFVXGP9S-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").Value = ThisWorkbook.Sheets("sheet1").Range("TQ10")
IE.Document.GetElementByID("yXZtvoYQXcD-J8fGj3Iefbc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").Value = ThisWorkbook.Sheets("sheet1").Range("TR10")
IE.Document.GetElementByID("yXZtvoYQXcD-lR2zeQ9VfB8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").Value = ThisWorkbook.Sheets("sheet1").Range("TS10")
IE.Document.GetElementByID("yXZtvoYQXcD-GnpJeq2XENE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").Value = ThisWorkbook.Sheets("sheet1").Range("TT10")
IE.Document.GetElementByID("yXZtvoYQXcD-jjUGfPF0ObP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").Value = ThisWorkbook.Sheets("sheet1").Range("TU10")
IE.Document.GetElementByID("yXZtvoYQXcD-p1HABZs9ydt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").Value = ThisWorkbook.Sheets("sheet1").Range("TV10")
IE.Document.GetElementByID("yXZtvoYQXcD-tEMe0224zlP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").Value = ThisWorkbook.Sheets("sheet1").Range("TW10")
IE.Document.GetElementByID("yXZtvoYQXcD-LpnJL4zZxRH-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").Value = ThisWorkbook.Sheets("sheet1").Range("TX10")
IE.Document.GetElementByID("yXZtvoYQXcD-NCnIv37EwU1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").Value = ThisWorkbook.Sheets("sheet1").Range("TY10")
IE.Document.GetElementByID("yXZtvoYQXcD-y9LP85d8t4b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").Value = ThisWorkbook.Sheets("sheet1").Range("TZ10")
IE.Document.GetElementByID("yXZtvoYQXcD-YDzeLL6xf5o-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("UA10")
IE.Document.GetElementByID("yXZtvoYQXcD-XcW5HWccYYZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("UB10")
IE.Document.GetElementByID("yXZtvoYQXcD-zouTxRQ0kXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").Focus                                         
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").Value = ThisWorkbook.Sheets("sheet1").Range("UC10")
IE.Document.GetElementByID("yXZtvoYQXcD-zUjkTTlva36-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").Focus
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").Value = ThisWorkbook.Sheets("sheet1").Range("UD10")
IE.Document.GetElementByID("yXZtvoYQXcD-QwUdNwRA8Uc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
Else
'<15,F
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("UE10")
IE.Document.GetElementByID("NBLKn7nRBfo-wIv7t5fSIlK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15+,F
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("UF10")
IE.Document.GetElementByID("NBLKn7nRBfo-R6XPf8j0tYt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15,M
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("UG10")
IE.Document.GetElementByID("NBLKn7nRBfo-GhywTqKHQNM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15+,M
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("UH10")
IE.Document.GetElementByID("NBLKn7nRBfo-ZnMtvRMKMWh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("UJ10")) Then
If WorksheetFunction.Sum(ThisWorkbook.Sheets("sheet1").Range("VH10:VK10")) = 0 Then
'<1,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").Value = ThisWorkbook.Sheets("sheet1").Range("UJ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-OMVFa98P0Yg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'1-4,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").Value = ThisWorkbook.Sheets("sheet1").Range("UK10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-dRjezxQktoz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'5-9,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").Value = ThisWorkbook.Sheets("sheet1").Range("UL10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zLbjm4E1NsG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'10-14,F
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").Value = ThisWorkbook.Sheets("sheet1").Range("UM10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-AG0milXShQM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").Value = ThisWorkbook.Sheets("sheet1").Range("UN10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-QqlHrg6f0Sm-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").Value = ThisWorkbook.Sheets("sheet1").Range("UO10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-LyXZybq6Sjf-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").Value = ThisWorkbook.Sheets("sheet1").Range("UP10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zqARzn2wVj5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").Value = ThisWorkbook.Sheets("sheet1").Range("UQ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-Vi8sd7mvZW4-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").Value = ThisWorkbook.Sheets("sheet1").Range("UR10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-hRq4baaUamW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").Value = ThisWorkbook.Sheets("sheet1").Range("US10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-PEXIFVXGP9S-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").Value = ThisWorkbook.Sheets("sheet1").Range("UT10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-J8fGj3Iefbc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").Value = ThisWorkbook.Sheets("sheet1").Range("UU10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-lR2zeQ9VfB8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").Value = ThisWorkbook.Sheets("sheet1").Range("UV10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-GnpJeq2XENE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").Value = ThisWorkbook.Sheets("sheet1").Range("UW10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-jjUGfPF0ObP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").Value = ThisWorkbook.Sheets("sheet1").Range("UX10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-p1HABZs9ydt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").Value = ThisWorkbook.Sheets("sheet1").Range("UY10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-tEMe0224zlP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").Value = ThisWorkbook.Sheets("sheet1").Range("UZ10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-LpnJL4zZxRH-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").Value = ThisWorkbook.Sheets("sheet1").Range("VA10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-NCnIv37EwU1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").Value = ThisWorkbook.Sheets("sheet1").Range("VB10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-y9LP85d8t4b-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").Value = ThisWorkbook.Sheets("sheet1").Range("VC10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-YDzeLL6xf5o-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("VD10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-XcW5HWccYYZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("VE10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zouTxRQ0kXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").Focus                                         
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").Value = ThisWorkbook.Sheets("sheet1").Range("VF10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-zUjkTTlva36-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").Focus
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").Value = ThisWorkbook.Sheets("sheet1").Range("VG10")
IE.Document.GetElementByID("Hyvw9VnZ2ch-QwUdNwRA8Uc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
Else
'<15,F
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Focus
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").Value = ThisWorkbook.Sheets("sheet1").Range("VH10")
IE.Document.GetElementByID("c03urRVExYe-wIv7t5fSIlK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15+,F
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Focus
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").Value = ThisWorkbook.Sheets("sheet1").Range("VI10")
IE.Document.GetElementByID("c03urRVExYe-R6XPf8j0tYt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'<15,M
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Focus
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").Value = ThisWorkbook.Sheets("sheet1").Range("VJ10")
IE.Document.GetElementByID("c03urRVExYe-GhywTqKHQNM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15+,M
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Focus
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").Value = ThisWorkbook.Sheets("sheet1").Range("VK10")
IE.Document.GetElementByID("c03urRVExYe-ZnMtvRMKMWh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("VM10")) Then
'New on ART
'10-14
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").Value = ThisWorkbook.Sheets("sheet1").Range("VM10")
IE.Document.GetElementByID("iAYee99BIjX-kjmB7uKc99Z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").Value = ThisWorkbook.Sheets("sheet1").Range("VN10")
IE.Document.GetElementByID("iAYee99BIjX-Io640W5BM1N-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").Value = ThisWorkbook.Sheets("sheet1").Range("VO10")
IE.Document.GetElementByID("iAYee99BIjX-yBopqmUtvhv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("VP10")
IE.Document.GetElementByID("iAYee99BIjX-q8kWTLZlUdZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Already on ART
'10-14
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").Value = ThisWorkbook.Sheets("sheet1").Range("VQ10")
IE.Document.GetElementByID("iAYee99BIjX-sPByZmFYnZh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").Value = ThisWorkbook.Sheets("sheet1").Range("VR10")
IE.Document.GetElementByID("iAYee99BIjX-rCrHJrYGJSl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").Value = ThisWorkbook.Sheets("sheet1").Range("VS10")
IE.Document.GetElementByID("iAYee99BIjX-jz0vTkTNFGy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").Focus
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").Value = ThisWorkbook.Sheets("sheet1").Range("VT10")
IE.Document.GetElementByID("iAYee99BIjX-dyREvvyOXaq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("VV10")) Then
'Numerator
'Already on ART
'<1,F
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").Value = ThisWorkbook.Sheets("sheet1").Range("VV10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Cq5xrLF7MiB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").Value = ThisWorkbook.Sheets("sheet1").Range("VW10")
IE.Document.GetElementByID("Qc1AaYpKsjs-E2lY8t3CmI5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").Value = ThisWorkbook.Sheets("sheet1").Range("VX10")
IE.Document.GetElementByID("Qc1AaYpKsjs-F6uPBw7dmhp-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").Value = ThisWorkbook.Sheets("sheet1").Range("VY10")
IE.Document.GetElementByID("Qc1AaYpKsjs-rS9g7UL0rDN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").Value = ThisWorkbook.Sheets("sheet1").Range("VZ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ZufsQv0cYSM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").Value = ThisWorkbook.Sheets("sheet1").Range("WA10")
IE.Document.GetElementByID("Qc1AaYpKsjs-r1p6hui37CP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").Value = ThisWorkbook.Sheets("sheet1").Range("WB10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kgvhGR4EKcK-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").Value = ThisWorkbook.Sheets("sheet1").Range("WC10")
IE.Document.GetElementByID("Qc1AaYpKsjs-GpSNvYc07tz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").Value = ThisWorkbook.Sheets("sheet1").Range("WD10")
IE.Document.GetElementByID("Qc1AaYpKsjs-zq43uEufKnG-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").Value = ThisWorkbook.Sheets("sheet1").Range("WE10")
IE.Document.GetElementByID("Qc1AaYpKsjs-utzUqBePahs-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").Value = ThisWorkbook.Sheets("sheet1").Range("WF10")
IE.Document.GetElementByID("Qc1AaYpKsjs-EJ5vQnO5114-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").Value = ThisWorkbook.Sheets("sheet1").Range("WG10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Rmwyz2pyabR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").Value = ThisWorkbook.Sheets("sheet1").Range("WH10")
IE.Document.GetElementByID("Qc1AaYpKsjs-QU5aTm14uA5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").Value = ThisWorkbook.Sheets("sheet1").Range("WI10")
IE.Document.GetElementByID("Qc1AaYpKsjs-X49cjRccRAw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").Value = ThisWorkbook.Sheets("sheet1").Range("WJ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kb4QVVLaKnA-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").Value = ThisWorkbook.Sheets("sheet1").Range("WK10")
IE.Document.GetElementByID("Qc1AaYpKsjs-pjBfnMMU8yB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").Value = ThisWorkbook.Sheets("sheet1").Range("WL10")
IE.Document.GetElementByID("Qc1AaYpKsjs-xp6h8T3cOfh-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").Value = ThisWorkbook.Sheets("sheet1").Range("WM10")
IE.Document.GetElementByID("Qc1AaYpKsjs-kutUEi1Fp8G-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").Value = ThisWorkbook.Sheets("sheet1").Range("WN10")
IE.Document.GetElementByID("Qc1AaYpKsjs-gzztFm4KH6T-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").Value = ThisWorkbook.Sheets("sheet1").Range("WO10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Kx0Ow7YSDv3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").Value = ThisWorkbook.Sheets("sheet1").Range("WP10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ZfvmeFeTV45-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").Value = ThisWorkbook.Sheets("sheet1").Range("WQ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-SFpj8nvfCkv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").Value = ThisWorkbook.Sheets("sheet1").Range("WR10")
IE.Document.GetElementByID("Qc1AaYpKsjs-KSZqwBFQVqD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").Value = ThisWorkbook.Sheets("sheet1").Range("WS10")
IE.Document.GetElementByID("Qc1AaYpKsjs-fWwSMmi37De-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'New on ART
'<1,F
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").Value = ThisWorkbook.Sheets("sheet1").Range("WT10")
IE.Document.GetElementByID("Qc1AaYpKsjs-cW1wQgs5hyV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").Value = ThisWorkbook.Sheets("sheet1").Range("WU10")
IE.Document.GetElementByID("Qc1AaYpKsjs-MQZqURahCb8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").Value = ThisWorkbook.Sheets("sheet1").Range("WV10")
IE.Document.GetElementByID("Qc1AaYpKsjs-JTZmQVEtlTV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").Value = ThisWorkbook.Sheets("sheet1").Range("WW10")
IE.Document.GetElementByID("Qc1AaYpKsjs-ay15X6h55Py-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").Value = ThisWorkbook.Sheets("sheet1").Range("WX10")
IE.Document.GetElementByID("Qc1AaYpKsjs-AGQa2tzIoc1-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").Value = ThisWorkbook.Sheets("sheet1").Range("WY10")
IE.Document.GetElementByID("Qc1AaYpKsjs-suJrZbdKKRW-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").Value = ThisWorkbook.Sheets("sheet1").Range("WZ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-LlsXRvw2WCa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").Value = ThisWorkbook.Sheets("sheet1").Range("XA10")
IE.Document.GetElementByID("Qc1AaYpKsjs-B3GuvVsPezs-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").Value = ThisWorkbook.Sheets("sheet1").Range("XB10")
IE.Document.GetElementByID("Qc1AaYpKsjs-VLZuKB5ZxAS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").Value = ThisWorkbook.Sheets("sheet1").Range("XC10")
IE.Document.GetElementByID("Qc1AaYpKsjs-L94UC0mTPiS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").Value = ThisWorkbook.Sheets("sheet1").Range("XD10")
IE.Document.GetElementByID("Qc1AaYpKsjs-FckvpCkm80Y-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").Value = ThisWorkbook.Sheets("sheet1").Range("XE10")
IE.Document.GetElementByID("Qc1AaYpKsjs-CTdgwVnmU4t-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").Value = ThisWorkbook.Sheets("sheet1").Range("XF10")
IE.Document.GetElementByID("Qc1AaYpKsjs-PZfvIT6x87t-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").Value = ThisWorkbook.Sheets("sheet1").Range("XG10")
IE.Document.GetElementByID("Qc1AaYpKsjs-okUjaLgimz6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").Value = ThisWorkbook.Sheets("sheet1").Range("XH10")
IE.Document.GetElementByID("Qc1AaYpKsjs-sNN69TORr55-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").Value = ThisWorkbook.Sheets("sheet1").Range("XI10")
IE.Document.GetElementByID("Qc1AaYpKsjs-PjCWWE6SRJc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").Value = ThisWorkbook.Sheets("sheet1").Range("XJ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-NM0O8rpozsb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").Value = ThisWorkbook.Sheets("sheet1").Range("XK10")
IE.Document.GetElementByID("Qc1AaYpKsjs-o7pTMaoJf1P-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").Value = ThisWorkbook.Sheets("sheet1").Range("XL10")
IE.Document.GetElementByID("Qc1AaYpKsjs-uK81Q5JSE2C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").Value = ThisWorkbook.Sheets("sheet1").Range("XM10")
IE.Document.GetElementByID("Qc1AaYpKsjs-E7IY48LF1ai-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").Value = ThisWorkbook.Sheets("sheet1").Range("XN10")
IE.Document.GetElementByID("Qc1AaYpKsjs-nMY8JaK7MKa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").Value = ThisWorkbook.Sheets("sheet1").Range("XO10")
IE.Document.GetElementByID("Qc1AaYpKsjs-cPjx1nSG7kh-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").Focus                                         
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").Value = ThisWorkbook.Sheets("sheet1").Range("XP10")
IE.Document.GetElementByID("Qc1AaYpKsjs-Kf4QAMTrtmg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").Focus
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").Value = ThisWorkbook.Sheets("sheet1").Range("XQ10")
IE.Document.GetElementByID("Qc1AaYpKsjs-GgZWK5MpPQ5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("XS10")) Then
'Routine, Pregnant
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").Value = ThisWorkbook.Sheets("sheet1").Range("XS10")
IE.Document.GetElementByID("JTmqyoIWNsj-b1veZoOczoR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Routine, Breastfeeding
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").Value = ThisWorkbook.Sheets("sheet1").Range("XT10")
IE.Document.GetElementByID("JTmqyoIWNsj-jBJaVu6svtP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Undocumented, Pregnant
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("XU10")
IE.Document.GetElementByID("JTmqyoIWNsj-poFe6w8ZgCs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Undocumented, Breastfeeding
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("XV10")
IE.Document.GetElementByID("JTmqyoIWNsj-k78k8hp9kxN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Routine
'<1,F
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").Value = ThisWorkbook.Sheets("sheet1").Range("XW10")
IE.Document.GetElementByID("YvPOllVtINQ-YVmIiOo8V17-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").Value = ThisWorkbook.Sheets("sheet1").Range("XX10")
IE.Document.GetElementByID("YvPOllVtINQ-HDhg4LTHBRa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("XY10")
IE.Document.GetElementByID("YvPOllVtINQ-rAvlLbG5dAb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").Value = ThisWorkbook.Sheets("sheet1").Range("XZ10")
IE.Document.GetElementByID("YvPOllVtINQ-dpFsZrc6Ffc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").Value = ThisWorkbook.Sheets("sheet1").Range("YA10")
IE.Document.GetElementByID("YvPOllVtINQ-A30fQSASmum-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").Value = ThisWorkbook.Sheets("sheet1").Range("YB10")
IE.Document.GetElementByID("YvPOllVtINQ-d7veFTMK1Jw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").Value = ThisWorkbook.Sheets("sheet1").Range("YC10")
IE.Document.GetElementByID("YvPOllVtINQ-I0zEWK2C11q-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").Value = ThisWorkbook.Sheets("sheet1").Range("YD10")
IE.Document.GetElementByID("YvPOllVtINQ-RKp8rxNgQAX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").Value = ThisWorkbook.Sheets("sheet1").Range("YE10")
IE.Document.GetElementByID("YvPOllVtINQ-MRnYv4nt5gc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").Value = ThisWorkbook.Sheets("sheet1").Range("YF10")
IE.Document.GetElementByID("YvPOllVtINQ-wOxLLZhNrPi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").Value = ThisWorkbook.Sheets("sheet1").Range("YG10")
IE.Document.GetElementByID("YvPOllVtINQ-ONQ9uSvOkGB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("YH10")
IE.Document.GetElementByID("YvPOllVtINQ-U9R0CAPL0AS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").Value = ThisWorkbook.Sheets("sheet1").Range("YI10")
IE.Document.GetElementByID("YvPOllVtINQ-vIZW4Jv7qqy-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").Value = ThisWorkbook.Sheets("sheet1").Range("YJ10")
IE.Document.GetElementByID("YvPOllVtINQ-bQY52yJFcaj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").Value = ThisWorkbook.Sheets("sheet1").Range("YK10")
IE.Document.GetElementByID("YvPOllVtINQ-sjBprG9Atqw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").Value = ThisWorkbook.Sheets("sheet1").Range("YL10")
IE.Document.GetElementByID("YvPOllVtINQ-Cz8TfD9G4NS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").Value = ThisWorkbook.Sheets("sheet1").Range("YM10")
IE.Document.GetElementByID("YvPOllVtINQ-hX01YQ8Xd0A-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("YN10")
IE.Document.GetElementByID("YvPOllVtINQ-Slv7vEZKRXb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").Value = ThisWorkbook.Sheets("sheet1").Range("YO10")
IE.Document.GetElementByID("YvPOllVtINQ-X3iUwZMRbpC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("YP10")
IE.Document.GetElementByID("YvPOllVtINQ-ABHnQuSJzZJ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").Value = ThisWorkbook.Sheets("sheet1").Range("YQ10")
IE.Document.GetElementByID("YvPOllVtINQ-PRsdy4olkFE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("YR10")
IE.Document.GetElementByID("YvPOllVtINQ-TcbPwuDGR7C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").Value = ThisWorkbook.Sheets("sheet1").Range("YS10")
IE.Document.GetElementByID("YvPOllVtINQ-Ba3F9Cdo4TM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").Value = ThisWorkbook.Sheets("sheet1").Range("YT10")
IE.Document.GetElementByID("YvPOllVtINQ-hrDvHLgNfrf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Not Documented
'<1,F
IE.Document.GetElementByID("YvPOllVtINQ-KX9PVyZU0SC-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-KX9PVyZU0SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("YU10")
IE.Document.GetElementByID("YvPOllVtINQ-KX9PVyZU0SC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-L1ObFoxjva6-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-L1ObFoxjva6-val").Value = ThisWorkbook.Sheets("sheet1").Range("YV10")
IE.Document.GetElementByID("YvPOllVtINQ-L1ObFoxjva6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-MEmyd94Q6WV-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-MEmyd94Q6WV-val").Value = ThisWorkbook.Sheets("sheet1").Range("YW10")
IE.Document.GetElementByID("YvPOllVtINQ-MEmyd94Q6WV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-XdPalqXCZoU-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-XdPalqXCZoU-val").Value = ThisWorkbook.Sheets("sheet1").Range("YX10")
IE.Document.GetElementByID("YvPOllVtINQ-XdPalqXCZoU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-bF0weSMLcXP-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-bF0weSMLcXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("YY10")
IE.Document.GetElementByID("YvPOllVtINQ-bF0weSMLcXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-RtATUnvscNN-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-RtATUnvscNN-val").Value = ThisWorkbook.Sheets("sheet1").Range("YZ10")
IE.Document.GetElementByID("YvPOllVtINQ-RtATUnvscNN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-sIQwZRXuYwt-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-sIQwZRXuYwt-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZA10")
IE.Document.GetElementByID("YvPOllVtINQ-sIQwZRXuYwt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-LhEFchQfNOo-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-LhEFchQfNOo-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZB10")
IE.Document.GetElementByID("YvPOllVtINQ-LhEFchQfNOo-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-VwiNQ9ZBi6N-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-VwiNQ9ZBi6N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZC10")
IE.Document.GetElementByID("YvPOllVtINQ-VwiNQ9ZBi6N-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ZbXKfTyFNc2-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ZbXKfTyFNc2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZD10")
IE.Document.GetElementByID("YvPOllVtINQ-ZbXKfTyFNc2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-E9mZCkjKTrk-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-E9mZCkjKTrk-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZE10")
IE.Document.GetElementByID("YvPOllVtINQ-E9mZCkjKTrk-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-Mmj6PfG0MD2-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-Mmj6PfG0MD2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZF10")
IE.Document.GetElementByID("YvPOllVtINQ-Mmj6PfG0MD2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("YvPOllVtINQ-j9nkZnYOQ2j-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-j9nkZnYOQ2j-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZG10")
IE.Document.GetElementByID("YvPOllVtINQ-j9nkZnYOQ2j-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-ugfxT6Y9fVT-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ugfxT6Y9fVT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZH10")
IE.Document.GetElementByID("YvPOllVtINQ-ugfxT6Y9fVT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("YvPOllVtINQ-GTyaeyYttO7-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-GTyaeyYttO7-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZI10")
IE.Document.GetElementByID("YvPOllVtINQ-GTyaeyYttO7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-GsqfEv7ONZC-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-GsqfEv7ONZC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZJ10")
IE.Document.GetElementByID("YvPOllVtINQ-GsqfEv7ONZC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-PrDW5lYkfid-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-PrDW5lYkfid-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZK10")
IE.Document.GetElementByID("YvPOllVtINQ-PrDW5lYkfid-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-k5zqWba6iGZ-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-k5zqWba6iGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZL10")
IE.Document.GetElementByID("YvPOllVtINQ-k5zqWba6iGZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-g8GIFx03IlN-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-g8GIFx03IlN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZM10")
IE.Document.GetElementByID("YvPOllVtINQ-g8GIFx03IlN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-BoVxsZvmVD3-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-BoVxsZvmVD3-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZN10")
IE.Document.GetElementByID("YvPOllVtINQ-BoVxsZvmVD3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-ooErPHdkcUi-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-ooErPHdkcUi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZO10")
IE.Document.GetElementByID("YvPOllVtINQ-ooErPHdkcUi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-lIjZjuzUGWd-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-lIjZjuzUGWd-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZP10")
IE.Document.GetElementByID("YvPOllVtINQ-lIjZjuzUGWd-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("YvPOllVtINQ-bYjNYUiHRzF-val").Focus                                         
IE.Document.GetElementByID("YvPOllVtINQ-bYjNYUiHRzF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZQ10")
IE.Document.GetElementByID("YvPOllVtINQ-bYjNYUiHRzF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("YvPOllVtINQ-E4AmAvdxkJA-val").Focus
IE.Document.GetElementByID("YvPOllVtINQ-E4AmAvdxkJA-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZR10")
IE.Document.GetElementByID("YvPOllVtINQ-E4AmAvdxkJA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
'Denominator
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ZT10")) Then
'Routine, Pregnant
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZT10")
IE.Document.GetElementByID("eQdclZl2AoR-b1veZoOczoR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Routine, Breastfeeding
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZU10")
IE.Document.GetElementByID("eQdclZl2AoR-jBJaVu6svtP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Undocumented, Pregnant
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZV10")
IE.Document.GetElementByID("eQdclZl2AoR-poFe6w8ZgCs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Undocumented, Breastfeeding
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").Focus
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZW10")
IE.Document.GetElementByID("eQdclZl2AoR-k78k8hp9kxN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Routine
'<1,F
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZX10")
IE.Document.GetElementByID("kznQBykTtJt-YVmIiOo8V17-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZY10")
IE.Document.GetElementByID("kznQBykTtJt-HDhg4LTHBRa-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ZZ10")
IE.Document.GetElementByID("kznQBykTtJt-rAvlLbG5dAb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAA10")
IE.Document.GetElementByID("kznQBykTtJt-dpFsZrc6Ffc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAB10")
IE.Document.GetElementByID("kznQBykTtJt-A30fQSASmum-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAC10")
IE.Document.GetElementByID("kznQBykTtJt-d7veFTMK1Jw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAD10")
IE.Document.GetElementByID("kznQBykTtJt-I0zEWK2C11q-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAE10")
IE.Document.GetElementByID("kznQBykTtJt-RKp8rxNgQAX-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAF10")
IE.Document.GetElementByID("kznQBykTtJt-MRnYv4nt5gc-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAG10")
IE.Document.GetElementByID("kznQBykTtJt-wOxLLZhNrPi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAH10")
IE.Document.GetElementByID("kznQBykTtJt-ONQ9uSvOkGB-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAI10")
IE.Document.GetElementByID("kznQBykTtJt-U9R0CAPL0AS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAJ10")
IE.Document.GetElementByID("kznQBykTtJt-vIZW4Jv7qqy-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAK10")
IE.Document.GetElementByID("kznQBykTtJt-bQY52yJFcaj-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAL10")
IE.Document.GetElementByID("kznQBykTtJt-sjBprG9Atqw-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAM10")
IE.Document.GetElementByID("kznQBykTtJt-Cz8TfD9G4NS-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAN10")
IE.Document.GetElementByID("kznQBykTtJt-hX01YQ8Xd0A-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAO10")
IE.Document.GetElementByID("kznQBykTtJt-Slv7vEZKRXb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAP10")
IE.Document.GetElementByID("kznQBykTtJt-X3iUwZMRbpC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAQ10")
IE.Document.GetElementByID("kznQBykTtJt-ABHnQuSJzZJ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAR10")
IE.Document.GetElementByID("kznQBykTtJt-PRsdy4olkFE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAS10")
IE.Document.GetElementByID("kznQBykTtJt-TcbPwuDGR7C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAT10")
IE.Document.GetElementByID("kznQBykTtJt-Ba3F9Cdo4TM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAU10")
IE.Document.GetElementByID("kznQBykTtJt-hrDvHLgNfrf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Not Documented
'<1,F
IE.Document.GetElementByID("kznQBykTtJt-KX9PVyZU0SC-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-KX9PVyZU0SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAV10")
IE.Document.GetElementByID("kznQBykTtJt-KX9PVyZU0SC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-L1ObFoxjva6-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-L1ObFoxjva6-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAW10")
IE.Document.GetElementByID("kznQBykTtJt-L1ObFoxjva6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-MEmyd94Q6WV-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-MEmyd94Q6WV-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAX10")
IE.Document.GetElementByID("kznQBykTtJt-MEmyd94Q6WV-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-XdPalqXCZoU-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-XdPalqXCZoU-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAY10")
IE.Document.GetElementByID("kznQBykTtJt-XdPalqXCZoU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-bF0weSMLcXP-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-bF0weSMLcXP-val").Value = ThisWorkbook.Sheets("sheet1").Range("AAZ10")
IE.Document.GetElementByID("kznQBykTtJt-bF0weSMLcXP-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-RtATUnvscNN-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-RtATUnvscNN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABA10")
IE.Document.GetElementByID("kznQBykTtJt-RtATUnvscNN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-sIQwZRXuYwt-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-sIQwZRXuYwt-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABB10")
IE.Document.GetElementByID("kznQBykTtJt-sIQwZRXuYwt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-LhEFchQfNOo-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-LhEFchQfNOo-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABC10")
IE.Document.GetElementByID("kznQBykTtJt-LhEFchQfNOo-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-VwiNQ9ZBi6N-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-VwiNQ9ZBi6N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABD10")
IE.Document.GetElementByID("kznQBykTtJt-VwiNQ9ZBi6N-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ZbXKfTyFNc2-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ZbXKfTyFNc2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABE10")
IE.Document.GetElementByID("kznQBykTtJt-ZbXKfTyFNc2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-E9mZCkjKTrk-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-E9mZCkjKTrk-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABF10")
IE.Document.GetElementByID("kznQBykTtJt-E9mZCkjKTrk-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-Mmj6PfG0MD2-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-Mmj6PfG0MD2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABG10")
IE.Document.GetElementByID("kznQBykTtJt-Mmj6PfG0MD2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M                                                                                                   
IE.Document.GetElementByID("kznQBykTtJt-j9nkZnYOQ2j-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-j9nkZnYOQ2j-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABH10")
IE.Document.GetElementByID("kznQBykTtJt-j9nkZnYOQ2j-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-ugfxT6Y9fVT-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ugfxT6Y9fVT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABI10")
IE.Document.GetElementByID("kznQBykTtJt-ugfxT6Y9fVT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M                                                                                                  
IE.Document.GetElementByID("kznQBykTtJt-GTyaeyYttO7-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-GTyaeyYttO7-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABJ10")
IE.Document.GetElementByID("kznQBykTtJt-GTyaeyYttO7-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-GsqfEv7ONZC-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-GsqfEv7ONZC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABK10")
IE.Document.GetElementByID("kznQBykTtJt-GsqfEv7ONZC-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-PrDW5lYkfid-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-PrDW5lYkfid-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABL10")
IE.Document.GetElementByID("kznQBykTtJt-PrDW5lYkfid-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-k5zqWba6iGZ-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-k5zqWba6iGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABM10")
IE.Document.GetElementByID("kznQBykTtJt-k5zqWba6iGZ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-g8GIFx03IlN-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-g8GIFx03IlN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABN10")
IE.Document.GetElementByID("kznQBykTtJt-g8GIFx03IlN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-BoVxsZvmVD3-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-BoVxsZvmVD3-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABO10")
IE.Document.GetElementByID("kznQBykTtJt-BoVxsZvmVD3-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-ooErPHdkcUi-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-ooErPHdkcUi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABP10")
IE.Document.GetElementByID("kznQBykTtJt-ooErPHdkcUi-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-lIjZjuzUGWd-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-lIjZjuzUGWd-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABQ10")
IE.Document.GetElementByID("kznQBykTtJt-lIjZjuzUGWd-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M                                                                                                
IE.Document.GetElementByID("kznQBykTtJt-bYjNYUiHRzF-val").Focus                                         
IE.Document.GetElementByID("kznQBykTtJt-bYjNYUiHRzF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABR10")
IE.Document.GetElementByID("kznQBykTtJt-bYjNYUiHRzF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+,M
IE.Document.GetElementByID("kznQBykTtJt-E4AmAvdxkJA-val").Focus
IE.Document.GetElementByID("kznQBykTtJt-E4AmAvdxkJA-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABS10")
IE.Document.GetElementByID("kznQBykTtJt-E4AmAvdxkJA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
End Sub

'   SSSSSSS       AAAAA     PPPPPPPPP   RRRRRRRRRR    
'  SSSSSSSSS      AAAAA     PPPPPPPPPP  RRRRRRRRRRR   
'  SSSSSSSSSS    AAAAAA     PPPPPPPPPPP RRRRRRRRRRR   
' SSSSS  SSSS    AAAAAAA    PPPP   PPPP RRRR   RRRRR  
' SSSSS         AAAAAAAA    PPPP   PPPP RRRR   RRRRR  
'  SSSSSSS      AAAAAAAA    PPPPPPPPPPP RRRRRRRRRRR   
'   SSSSSSSSS   AAAA AAAA   PPPPPPPPPP  RRRRRRRRRRR   
'     SSSSSSS  AAAAAAAAAA   PPPPPPPPP   RRRRRRRR      
'        SSSSS AAAAAAAAAAA  PPPP        RRRR RRRR     
' SSSS    SSSS AAAAAAAAAAA  PPPP        RRRR  RRRR    
' SSSSSSSSSSSSSAAA    AAAA  PPPP        RRRR  RRRRR   
'  SSSSSSSSSS SAAA     AAAA PPPP        RRRR   RRRRR  
'   SSSSSSSS SSAAA     AAAA PPPP        RRRR    RRRR  

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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ABU10")) Then
'15-19,F  
IE.Document.GetElementByID("KNO4emPfF91-BYmlmGMcCWx-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-BYmlmGMcCWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABU10")
IE.Document.GetElementByID("KNO4emPfF91-BYmlmGMcCWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F  
IE.Document.GetElementByID("KNO4emPfF91-zE5NFpGXDy4-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-zE5NFpGXDy4-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABV10")
IE.Document.GetElementByID("KNO4emPfF91-zE5NFpGXDy4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F  
IE.Document.GetElementByID("KNO4emPfF91-u88hOHhmLuF-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-u88hOHhmLuF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABW10")
IE.Document.GetElementByID("KNO4emPfF91-u88hOHhmLuF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F  
IE.Document.GetElementByID("KNO4emPfF91-tcJ9vZbCWcO-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-tcJ9vZbCWcO-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABX10")
IE.Document.GetElementByID("KNO4emPfF91-tcJ9vZbCWcO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F  
IE.Document.GetElementByID("KNO4emPfF91-WghEsgfAUAb-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-WghEsgfAUAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABY10")
IE.Document.GetElementByID("KNO4emPfF91-WghEsgfAUAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F  
IE.Document.GetElementByID("KNO4emPfF91-Ij7k6DBjI3i-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-Ij7k6DBjI3i-val").Value = ThisWorkbook.Sheets("sheet1").Range("ABZ10")
IE.Document.GetElementByID("KNO4emPfF91-Ij7k6DBjI3i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F  
IE.Document.GetElementByID("KNO4emPfF91-dIfXCJxd5bY-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-dIfXCJxd5bY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACA10")
IE.Document.GetElementByID("KNO4emPfF91-dIfXCJxd5bY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50,F  
IE.Document.GetElementByID("KNO4emPfF91-xqiQnxlVCYm-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-xqiQnxlVCYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACB10")
IE.Document.GetElementByID("KNO4emPfF91-xqiQnxlVCYm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M 
IE.Document.GetElementByID("KNO4emPfF91-kQ58FETBxFn-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-kQ58FETBxFn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACC10")
IE.Document.GetElementByID("KNO4emPfF91-kQ58FETBxFn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M  
IE.Document.GetElementByID("KNO4emPfF91-jJifRzf2Z8j-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-jJifRzf2Z8j-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACD10")
IE.Document.GetElementByID("KNO4emPfF91-jJifRzf2Z8j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M  
IE.Document.GetElementByID("KNO4emPfF91-necuVZOR1HB-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-necuVZOR1HB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACE10")
IE.Document.GetElementByID("KNO4emPfF91-necuVZOR1HB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M  
IE.Document.GetElementByID("KNO4emPfF91-HnDmWypXRdG-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-HnDmWypXRdG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACF10")
IE.Document.GetElementByID("KNO4emPfF91-HnDmWypXRdG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M  
IE.Document.GetElementByID("KNO4emPfF91-Sq9vathzQd9-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-Sq9vathzQd9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACG10")
IE.Document.GetElementByID("KNO4emPfF91-Sq9vathzQd9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M 
IE.Document.GetElementByID("KNO4emPfF91-f6m1joVHJgj-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-f6m1joVHJgj-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACH10")
IE.Document.GetElementByID("KNO4emPfF91-f6m1joVHJgj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M 
IE.Document.GetElementByID("KNO4emPfF91-efXnrOzWCGW-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-efXnrOzWCGW-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACI10")
IE.Document.GetElementByID("KNO4emPfF91-efXnrOzWCGW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50,M 
IE.Document.GetElementByID("KNO4emPfF91-fSgFPhUpbWq-val").Focus
IE.Document.GetElementByID("KNO4emPfF91-fSgFPhUpbWq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACJ10")
IE.Document.GetElementByID("KNO4emPfF91-fSgFPhUpbWq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ACL10")) Then
'15-19,F  
IE.Document.GetElementByID("x5H3nrR8BNW-BYmlmGMcCWx-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-BYmlmGMcCWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACL10")
IE.Document.GetElementByID("x5H3nrR8BNW-BYmlmGMcCWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,F  
IE.Document.GetElementByID("x5H3nrR8BNW-zE5NFpGXDy4-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-zE5NFpGXDy4-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACM10")
IE.Document.GetElementByID("x5H3nrR8BNW-zE5NFpGXDy4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,F  
IE.Document.GetElementByID("x5H3nrR8BNW-u88hOHhmLuF-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-u88hOHhmLuF-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACN10")
IE.Document.GetElementByID("x5H3nrR8BNW-u88hOHhmLuF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,F  
IE.Document.GetElementByID("x5H3nrR8BNW-tcJ9vZbCWcO-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-tcJ9vZbCWcO-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACO10")
IE.Document.GetElementByID("x5H3nrR8BNW-tcJ9vZbCWcO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,F  
IE.Document.GetElementByID("x5H3nrR8BNW-WghEsgfAUAb-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-WghEsgfAUAb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACP10")
IE.Document.GetElementByID("x5H3nrR8BNW-WghEsgfAUAb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,F  
IE.Document.GetElementByID("x5H3nrR8BNW-Ij7k6DBjI3i-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-Ij7k6DBjI3i-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACQ10")
IE.Document.GetElementByID("x5H3nrR8BNW-Ij7k6DBjI3i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,F  
IE.Document.GetElementByID("x5H3nrR8BNW-dIfXCJxd5bY-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-dIfXCJxd5bY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACR10")
IE.Document.GetElementByID("x5H3nrR8BNW-dIfXCJxd5bY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50,F  
IE.Document.GetElementByID("x5H3nrR8BNW-xqiQnxlVCYm-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-xqiQnxlVCYm-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACS10")
IE.Document.GetElementByID("x5H3nrR8BNW-xqiQnxlVCYm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'15-19,M 
IE.Document.GetElementByID("x5H3nrR8BNW-kQ58FETBxFn-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-kQ58FETBxFn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACT10")
IE.Document.GetElementByID("x5H3nrR8BNW-kQ58FETBxFn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24,M  
IE.Document.GetElementByID("x5H3nrR8BNW-jJifRzf2Z8j-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-jJifRzf2Z8j-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACU10")
IE.Document.GetElementByID("x5H3nrR8BNW-jJifRzf2Z8j-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29,M  
IE.Document.GetElementByID("x5H3nrR8BNW-necuVZOR1HB-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-necuVZOR1HB-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACV10")
IE.Document.GetElementByID("x5H3nrR8BNW-necuVZOR1HB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34,M  
IE.Document.GetElementByID("x5H3nrR8BNW-HnDmWypXRdG-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-HnDmWypXRdG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACW10")
IE.Document.GetElementByID("x5H3nrR8BNW-HnDmWypXRdG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39,M  
IE.Document.GetElementByID("x5H3nrR8BNW-Sq9vathzQd9-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-Sq9vathzQd9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACX10")
IE.Document.GetElementByID("x5H3nrR8BNW-Sq9vathzQd9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44,M 
IE.Document.GetElementByID("x5H3nrR8BNW-f6m1joVHJgj-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-f6m1joVHJgj-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACY10")
IE.Document.GetElementByID("x5H3nrR8BNW-f6m1joVHJgj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49,M 
IE.Document.GetElementByID("x5H3nrR8BNW-efXnrOzWCGW-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-efXnrOzWCGW-val").Value = ThisWorkbook.Sheets("sheet1").Range("ACZ10")
IE.Document.GetElementByID("x5H3nrR8BNW-efXnrOzWCGW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50,M 
IE.Document.GetElementByID("x5H3nrR8BNW-fSgFPhUpbWq-val").Focus
IE.Document.GetElementByID("x5H3nrR8BNW-fSgFPhUpbWq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADA10")
IE.Document.GetElementByID("x5H3nrR8BNW-fSgFPhUpbWq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Positive
IE.Document.GetElementByID("YJ29Pdq78W9-KZLKkTI9JDW-val").Focus
IE.Document.GetElementByID("YJ29Pdq78W9-KZLKkTI9JDW-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADB10")
IE.Document.GetElementByID("YJ29Pdq78W9-KZLKkTI9JDW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Negative
IE.Document.GetElementByID("YJ29Pdq78W9-wk0iX1oD0k8-val").Focus
IE.Document.GetElementByID("YJ29Pdq78W9-wk0iX1oD0k8-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADC10")
IE.Document.GetElementByID("YJ29Pdq78W9-wk0iX1oD0k8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Three month
IE.Document.GetElementByID("YJ29Pdq78W9-IYCY7by7MB6-val").Focus
IE.Document.GetElementByID("YJ29Pdq78W9-IYCY7by7MB6-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADD10")
IE.Document.GetElementByID("YJ29Pdq78W9-IYCY7by7MB6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ADF10")) Then
'Numerator
'IPT, Newly, <15, F
IE.Document.GetElementByID("snsnfDStk7C-mi7E9CADWSN-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-mi7E9CADWSN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADF10")
IE.Document.GetElementByID("snsnfDStk7C-mi7E9CADWSN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Newly, 15+, F
IE.Document.GetElementByID("snsnfDStk7C-JR95o8Xtizl-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-JR95o8Xtizl-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADG10")
IE.Document.GetElementByID("snsnfDStk7C-JR95o8Xtizl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Newly, <15, M
IE.Document.GetElementByID("snsnfDStk7C-wf5dnqcNzsC-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-wf5dnqcNzsC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADH10")
IE.Document.GetElementByID("snsnfDStk7C-wf5dnqcNzsC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Newly, 15+, M
IE.Document.GetElementByID("snsnfDStk7C-DYWHCdJGVCo-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-DYWHCdJGVCo-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADI10")
IE.Document.GetElementByID("snsnfDStk7C-DYWHCdJGVCo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, <15, F
IE.Document.GetElementByID("snsnfDStk7C-EtjoXVvdmke-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-EtjoXVvdmke-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADJ10")
IE.Document.GetElementByID("snsnfDStk7C-EtjoXVvdmke-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, 15+, F
IE.Document.GetElementByID("snsnfDStk7C-M4jO9QCDbGa-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-M4jO9QCDbGa-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADK10")
IE.Document.GetElementByID("snsnfDStk7C-M4jO9QCDbGa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, <15, M
IE.Document.GetElementByID("snsnfDStk7C-H7mVNYfFpZK-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-H7mVNYfFpZK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADL10")
IE.Document.GetElementByID("snsnfDStk7C-H7mVNYfFpZK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, 15+, M
IE.Document.GetElementByID("snsnfDStk7C-UhCTzS8qdWx-val").Focus
IE.Document.GetElementByID("snsnfDStk7C-UhCTzS8qdWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADM10")
IE.Document.GetElementByID("snsnfDStk7C-UhCTzS8qdWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ADW10")) Then
'Denominator
'IPT, Newly, <15, F
IE.Document.GetElementByID("KTrXeuvf4iQ-mi7E9CADWSN-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-mi7E9CADWSN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADW10")
IE.Document.GetElementByID("KTrXeuvf4iQ-mi7E9CADWSN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Newly, 15+, F
IE.Document.GetElementByID("KTrXeuvf4iQ-JR95o8Xtizl-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-JR95o8Xtizl-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADX10")
IE.Document.GetElementByID("KTrXeuvf4iQ-JR95o8Xtizl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Newly, <15, M
IE.Document.GetElementByID("KTrXeuvf4iQ-wf5dnqcNzsC-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-wf5dnqcNzsC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADY10")
IE.Document.GetElementByID("KTrXeuvf4iQ-wf5dnqcNzsC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Newly, 15+, M
IE.Document.GetElementByID("KTrXeuvf4iQ-DYWHCdJGVCo-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-DYWHCdJGVCo-val").Value = ThisWorkbook.Sheets("sheet1").Range("ADZ10")
IE.Document.GetElementByID("KTrXeuvf4iQ-DYWHCdJGVCo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, <15, F
IE.Document.GetElementByID("KTrXeuvf4iQ-EtjoXVvdmke-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-EtjoXVvdmke-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEA10")
IE.Document.GetElementByID("KTrXeuvf4iQ-EtjoXVvdmke-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, 15+, F
IE.Document.GetElementByID("KTrXeuvf4iQ-M4jO9QCDbGa-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-M4jO9QCDbGa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEB10")
IE.Document.GetElementByID("KTrXeuvf4iQ-M4jO9QCDbGa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, <15, M
IE.Document.GetElementByID("KTrXeuvf4iQ-H7mVNYfFpZK-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-H7mVNYfFpZK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEC10")
IE.Document.GetElementByID("KTrXeuvf4iQ-H7mVNYfFpZK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'IPT, Already, 15+, M
IE.Document.GetElementByID("KTrXeuvf4iQ-UhCTzS8qdWx-val").Focus
IE.Document.GetElementByID("KTrXeuvf4iQ-UhCTzS8qdWx-val").Value = ThisWorkbook.Sheets("sheet1").Range("AED10")
IE.Document.GetElementByID("KTrXeuvf4iQ-UhCTzS8qdWx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AEN10")) Then
'Negative
'15-19
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEN10")
IE.Document.GetElementByID("XboLlTkc4Av-dh4TQ68p2SC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEO10")
IE.Document.GetElementByID("XboLlTkc4Av-pdCeAB4EYYM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEP10")
IE.Document.GetElementByID("XboLlTkc4Av-qgGxi9db8sQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEQ10")
IE.Document.GetElementByID("XboLlTkc4Av-ZLqwxAM0rDn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").Value = ThisWorkbook.Sheets("sheet1").Range("AER10")
IE.Document.GetElementByID("XboLlTkc4Av-k6PpW7YsDek-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").Value = ThisWorkbook.Sheets("sheet1").Range("AES10")
IE.Document.GetElementByID("XboLlTkc4Av-Rs8GH9wo2Iq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AET10")
IE.Document.GetElementByID("XboLlTkc4Av-dyxvzwmNPGZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEU10")
IE.Document.GetElementByID("XboLlTkc4Av-dr2VUvtgDGn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Positive
'15-19
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEV10")
IE.Document.GetElementByID("XboLlTkc4Av-fJ4uotAMsvK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEW10")
IE.Document.GetElementByID("XboLlTkc4Av-HMzo64LcweA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEX10")
IE.Document.GetElementByID("XboLlTkc4Av-vW2cAkyRE1o-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEY10")
IE.Document.GetElementByID("XboLlTkc4Av-O7xahbUykIN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AEZ10")
IE.Document.GetElementByID("XboLlTkc4Av-t30vaBv4cPu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFA10")
IE.Document.GetElementByID("XboLlTkc4Av-lGLhiwNxWOk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFB10")
IE.Document.GetElementByID("XboLlTkc4Av-TSVq2SiVSqr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFC10")
IE.Document.GetElementByID("XboLlTkc4Av-SXr2dJIXau2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Suspected
'15-19
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFD10")
IE.Document.GetElementByID("XboLlTkc4Av-nI9rG3vPWQz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFE10")
IE.Document.GetElementByID("XboLlTkc4Av-bUHsLsQL80m-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFF10")
IE.Document.GetElementByID("XboLlTkc4Av-sngMFN7RcpA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFG10")
IE.Document.GetElementByID("XboLlTkc4Av-nFHijHYOiFf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFH10")
IE.Document.GetElementByID("XboLlTkc4Av-E37hIruafwo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFI10")
IE.Document.GetElementByID("XboLlTkc4Av-bbH8Y4ejXSr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFJ10")
IE.Document.GetElementByID("XboLlTkc4Av-B5fJ4gs57Jz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").Focus
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFK10")
IE.Document.GetElementByID("XboLlTkc4Av-GGSHmwiOMQX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AFM10")) Then
'<1,F,Died
IE.Document.GetElementByID("DRRao8jDO3b-HCBbyzN9hg8-val").Focus
IE.Document.GetElementByID("DRRao8jDO3b-HCBbyzN9hg8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFM10")
IE.Document.GetElementByID("DRRao8jDO3b-HCBbyzN9hg8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-DuKFTCDTm36-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-DuKFTCDTm36-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFN10")
IE.Document.GetElementByID("DRRao8jDO3b-DuKFTCDTm36-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-UbzJ7tg5zo2-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-UbzJ7tg5zo2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFO10")
IE.Document.GetElementByID("DRRao8jDO3b-UbzJ7tg5zo2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-zh9NgGkXtF8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-zh9NgGkXtF8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFP10")
IE.Document.GetElementByID("DRRao8jDO3b-zh9NgGkXtF8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Hs4V3lH4yQU-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Hs4V3lH4yQU-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFQ10")
IE.Document.GetElementByID("DRRao8jDO3b-Hs4V3lH4yQU-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-UmxJVH7qDiF-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-UmxJVH7qDiF-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFR10")
IE.Document.GetElementByID("DRRao8jDO3b-UmxJVH7qDiF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Equr4VbOl5H-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Equr4VbOl5H-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFS10")
IE.Document.GetElementByID("DRRao8jDO3b-Equr4VbOl5H-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-LInafos6gzb-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-LInafos6gzb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFT10")
IE.Document.GetElementByID("DRRao8jDO3b-LInafos6gzb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-C87iWhgzBDu-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-C87iWhgzBDu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFU10")
IE.Document.GetElementByID("DRRao8jDO3b-C87iWhgzBDu-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-JQEU6nKw7gb-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-JQEU6nKw7gb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFV10")
IE.Document.GetElementByID("DRRao8jDO3b-JQEU6nKw7gb-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-P0NgrRvn84T-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-P0NgrRvn84T-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFW10")
IE.Document.GetElementByID("DRRao8jDO3b-P0NgrRvn84T-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-yybElZFCO86-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-yybElZFCO86-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFX10")
IE.Document.GetElementByID("DRRao8jDO3b-yybElZFCO86-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M,Died                                                                                                   
IE.Document.GetElementByID("DRRao8jDO3b-jWiak0ltNja-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-jWiak0ltNja-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFY10")
IE.Document.GetElementByID("DRRao8jDO3b-jWiak0ltNja-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-e8nZ8Rb8EMt-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-e8nZ8Rb8EMt-val").Value = ThisWorkbook.Sheets("sheet1").Range("AFZ10")
IE.Document.GetElementByID("DRRao8jDO3b-e8nZ8Rb8EMt-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-xVjQHjVzAU0-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-xVjQHjVzAU0-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGA10")
IE.Document.GetElementByID("DRRao8jDO3b-xVjQHjVzAU0-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-mjJM5dG14VO-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-mjJM5dG14VO-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGB10")
IE.Document.GetElementByID("DRRao8jDO3b-mjJM5dG14VO-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-E8qNYIDZfnQ-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-E8qNYIDZfnQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGC10")
IE.Document.GetElementByID("DRRao8jDO3b-E8qNYIDZfnQ-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-WMOWrnR0Tk6-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-WMOWrnR0Tk6-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGD10")
IE.Document.GetElementByID("DRRao8jDO3b-WMOWrnR0Tk6-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Ftq9p9Xzahl-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Ftq9p9Xzahl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGE10")
IE.Document.GetElementByID("DRRao8jDO3b-Ftq9p9Xzahl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-QKoLnrKVGpz-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-QKoLnrKVGpz-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGF10")
IE.Document.GetElementByID("DRRao8jDO3b-QKoLnrKVGpz-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-fNEJdk6Vl8e-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-fNEJdk6Vl8e-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGG10")
IE.Document.GetElementByID("DRRao8jDO3b-fNEJdk6Vl8e-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-GnyPqshMifv-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-GnyPqshMifv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGH10")
IE.Document.GetElementByID("DRRao8jDO3b-GnyPqshMifv-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M,Died                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-P7KWqQDn7W5-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-P7KWqQDn7W5-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGI10")
IE.Document.GetElementByID("DRRao8jDO3b-P7KWqQDn7W5-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,M,Died                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-oBEwjtWfAr1-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-oBEwjtWfAr1-val").Value = ThisWorkbook.Sheets("sheet1").Range("AGJ10")
IE.Document.GetElementByID("DRRao8jDO3b-oBEwjtWfAr1-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AHI10")) Then
'<1,F,Traced
IE.Document.GetElementByID("DRRao8jDO3b-HV1wVebGpMx-val").Focus
IE.Document.GetElementByID("DRRao8jDO3b-HV1wVebGpMx-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHI10")
IE.Document.GetElementByID("DRRao8jDO3b-HV1wVebGpMx-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,F,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-ZaX7T1mm60R-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ZaX7T1mm60R-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHJ10")
IE.Document.GetElementByID("DRRao8jDO3b-ZaX7T1mm60R-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,F,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-VMun3Ah6e2k-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-VMun3Ah6e2k-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHK10")
IE.Document.GetElementByID("DRRao8jDO3b-VMun3Ah6e2k-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-LllUyIWhS95-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-LllUyIWhS95-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHL10")
IE.Document.GetElementByID("DRRao8jDO3b-LllUyIWhS95-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-EUfl8e8BFwN-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-EUfl8e8BFwN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHM10")
IE.Document.GetElementByID("DRRao8jDO3b-EUfl8e8BFwN-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-yGoN7frP7i8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-yGoN7frP7i8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHN10")
IE.Document.GetElementByID("DRRao8jDO3b-yGoN7frP7i8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-ku6Q0SHxw6c-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ku6Q0SHxw6c-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHO10")
IE.Document.GetElementByID("DRRao8jDO3b-ku6Q0SHxw6c-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-uKQCp8AOQUL-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-uKQCp8AOQUL-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHP10")
IE.Document.GetElementByID("DRRao8jDO3b-uKQCp8AOQUL-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-l1DgaTNLde2-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-l1DgaTNLde2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHQ10")
IE.Document.GetElementByID("DRRao8jDO3b-l1DgaTNLde2-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-Qw8gl4XnlCl-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Qw8gl4XnlCl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHR10")
IE.Document.GetElementByID("DRRao8jDO3b-Qw8gl4XnlCl-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,F,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-We6rTd6cmTn-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-We6rTd6cmTn-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHS10")
IE.Document.GetElementByID("DRRao8jDO3b-We6rTd6cmTn-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,F,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-Sf78ll04lov-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-Sf78ll04lov-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHT10")
IE.Document.GetElementByID("DRRao8jDO3b-Sf78ll04lov-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'<1,M,Traced                                                                                                   
IE.Document.GetElementByID("DRRao8jDO3b-ZRAcFMpcVKE-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-ZRAcFMpcVKE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHU10")
IE.Document.GetElementByID("DRRao8jDO3b-ZRAcFMpcVKE-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'1-4,M,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-gDy1YoIcG47-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-gDy1YoIcG47-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHV10")
IE.Document.GetElementByID("DRRao8jDO3b-gDy1YoIcG47-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'5-9,M,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-rHMVe4mVaaF-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-rHMVe4mVaaF-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHW10")
IE.Document.GetElementByID("DRRao8jDO3b-rHMVe4mVaaF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'10-14,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-QDMMRyv1b7C-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-QDMMRyv1b7C-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHX10")
IE.Document.GetElementByID("DRRao8jDO3b-QDMMRyv1b7C-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'15-19,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-MnuYBsHKprM-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-MnuYBsHKprM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHY10")
IE.Document.GetElementByID("DRRao8jDO3b-MnuYBsHKprM-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'20-24,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-e5VaP9zoRlF-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-e5VaP9zoRlF-val").Value = ThisWorkbook.Sheets("sheet1").Range("AHZ10")
IE.Document.GetElementByID("DRRao8jDO3b-e5VaP9zoRlF-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'25-29,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-d7q0I4AnH38-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-d7q0I4AnH38-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIA10")
IE.Document.GetElementByID("DRRao8jDO3b-d7q0I4AnH38-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'30-34,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-iCf9JjKSCs9-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-iCf9JjKSCs9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIB10")
IE.Document.GetElementByID("DRRao8jDO3b-iCf9JjKSCs9-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'35-39,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-sZC9E3g2YMR-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-sZC9E3g2YMR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIC10")
IE.Document.GetElementByID("DRRao8jDO3b-sZC9E3g2YMR-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'40-44,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-DkxCY8ooSbT-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-DkxCY8ooSbT-val").Value = ThisWorkbook.Sheets("sheet1").Range("AID10")
IE.Document.GetElementByID("DRRao8jDO3b-DkxCY8ooSbT-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'45-49,M,Traced                                                                                                
IE.Document.GetElementByID("DRRao8jDO3b-B9qdd7xhhV8-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-B9qdd7xhhV8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIE10")
IE.Document.GetElementByID("DRRao8jDO3b-B9qdd7xhhV8-val").dispatchEvent evt                             
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))                                                            
'50+,M,Traced                                                                                                  
IE.Document.GetElementByID("DRRao8jDO3b-GNsVNj0Ixaf-val").Focus                                         
IE.Document.GetElementByID("DRRao8jDO3b-GNsVNj0Ixaf-val").Value = ThisWorkbook.Sheets("sheet1").Range("AIF10")
IE.Document.GetElementByID("DRRao8jDO3b-GNsVNj0Ixaf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AJF10")) Then
'Numerator
'New,F,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-ptrqjblDpVl-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-ptrqjblDpVl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJF10")
IE.Document.GetElementByID("DHhB2W8z4k6-ptrqjblDpVl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'New,F,15+                                                                                        
IE.Document.GetElementByID("DHhB2W8z4k6-hcF36Hpaxmu-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-hcF36Hpaxmu-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJG10")
IE.Document.GetElementByID("DHhB2W8z4k6-hcF36Hpaxmu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'New,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-EP6ShhD5ntH-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-EP6ShhD5ntH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJH10")
IE.Document.GetElementByID("DHhB2W8z4k6-EP6ShhD5ntH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'New,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-b2lYKJk1pWg-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-b2lYKJk1pWg-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJI10")
IE.Document.GetElementByID("DHhB2W8z4k6-b2lYKJk1pWg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Already,F,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-ujjzYH3AbhZ-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-ujjzYH3AbhZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJJ10")
IE.Document.GetElementByID("DHhB2W8z4k6-ujjzYH3AbhZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Already,F,15+                                                                                        
IE.Document.GetElementByID("DHhB2W8z4k6-IKLIV8BEfT2-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-IKLIV8BEfT2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJK10")
IE.Document.GetElementByID("DHhB2W8z4k6-IKLIV8BEfT2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Already,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-Cqb6VN74EwO-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-Cqb6VN74EwO-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJL10")
IE.Document.GetElementByID("DHhB2W8z4k6-Cqb6VN74EwO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Already,M,<15                                                                                          
IE.Document.GetElementByID("DHhB2W8z4k6-TWPXb0rvc3p-val").Focus                                         
IE.Document.GetElementByID("DHhB2W8z4k6-TWPXb0rvc3p-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJM10")
IE.Document.GetElementByID("DHhB2W8z4k6-TWPXb0rvc3p-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AJO10")) Then
'Denominator
'SP, Newly, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-qEv2Oi1bHsp-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-qEv2Oi1bHsp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJO10")
IE.Document.GetElementByID("YVqdD78gGE1-qEv2Oi1bHsp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'SP, Newly, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-BpjQgbuhZoo-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-BpjQgbuhZoo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJP10")
IE.Document.GetElementByID("YVqdD78gGE1-BpjQgbuhZoo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'SP, Newly, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-zpOXupkpl7i-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-zpOXupkpl7i-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJQ10")
IE.Document.GetElementByID("YVqdD78gGE1-zpOXupkpl7i-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'SP, Newly, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-Y9GhVNf8jUd-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-Y9GhVNf8jUd-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJR10")
IE.Document.GetElementByID("YVqdD78gGE1-Y9GhVNf8jUd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'SP, Already, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-qBj9XLbUigZ-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-qBj9XLbUigZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJS10")
IE.Document.GetElementByID("YVqdD78gGE1-qBj9XLbUigZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'SP, Already, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-vsVKGzHxDua-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-vsVKGzHxDua-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJT10")
IE.Document.GetElementByID("YVqdD78gGE1-vsVKGzHxDua-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'SP, Already, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-VyeN2c8Zdi4-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-VyeN2c8Zdi4-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJU10")
IE.Document.GetElementByID("YVqdD78gGE1-VyeN2c8Zdi4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'SP, Already, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-SZ3D287on4h-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-SZ3D287on4h-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJV10")
IE.Document.GetElementByID("YVqdD78gGE1-SZ3D287on4h-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Newly, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-KcI8l7j9oeX-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-KcI8l7j9oeX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJW10")
IE.Document.GetElementByID("YVqdD78gGE1-KcI8l7j9oeX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Newly, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-kCzjNAGH5GY-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-kCzjNAGH5GY-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJX10")
IE.Document.GetElementByID("YVqdD78gGE1-kCzjNAGH5GY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Newly, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-JURc3Uxzcr9-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-JURc3Uxzcr9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJY10")
IE.Document.GetElementByID("YVqdD78gGE1-JURc3Uxzcr9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Newly, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-rktDV3ZuQjl-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-rktDV3ZuQjl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AJZ10")
IE.Document.GetElementByID("YVqdD78gGE1-rktDV3ZuQjl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Already, <15, F
IE.Document.GetElementByID("YVqdD78gGE1-yxdKq1ZC8fS-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-yxdKq1ZC8fS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKA10")
IE.Document.GetElementByID("YVqdD78gGE1-yxdKq1ZC8fS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Already, 15+, F
IE.Document.GetElementByID("YVqdD78gGE1-DFLZuSpRYKv-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-DFLZuSpRYKv-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKB10")
IE.Document.GetElementByID("YVqdD78gGE1-DFLZuSpRYKv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Already, <15, M
IE.Document.GetElementByID("YVqdD78gGE1-NrvW7I8iYbo-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-NrvW7I8iYbo-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKC10")
IE.Document.GetElementByID("YVqdD78gGE1-NrvW7I8iYbo-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'NP, Already, 15+, M
IE.Document.GetElementByID("YVqdD78gGE1-u53iyNLwf4u-val").Focus
IE.Document.GetElementByID("YVqdD78gGE1-u53iyNLwf4u-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKD10")
IE.Document.GetElementByID("YVqdD78gGE1-u53iyNLwf4u-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AKK10")) Then
'Cervical Cancer screen: Cryotherapy
'15-19
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKK10")
IE.Document.GetElementByID("D8gXql7mhrZ-Njt3hvrCNIO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'20-24
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKL10")
IE.Document.GetElementByID("D8gXql7mhrZ-ycC6TYD1fK8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'25-29
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKM10")
IE.Document.GetElementByID("D8gXql7mhrZ-esEoT2zyIAD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'30-34
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKN10")
IE.Document.GetElementByID("D8gXql7mhrZ-RMeYVgQI1xD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'35-39
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKO10")
IE.Document.GetElementByID("D8gXql7mhrZ-yUZniFjLR4K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'40-44
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKP10")
IE.Document.GetElementByID("D8gXql7mhrZ-ca7gG3WIozw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'45-49
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKQ10")
IE.Document.GetElementByID("D8gXql7mhrZ-wk3ttV4GTnT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'50+
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").Focus
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKR10")
IE.Document.GetElementByID("D8gXql7mhrZ-iV3JZe1JRsk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
End Sub

'      AAAAAAA      PPPPPPPPPPPPP    RRRRRRRRRRRRR    
'      AAAAAAA      PPPPPPPPPPPPPP   RRRRRRRRRRRRRR   
'     AAAAAAAA      PPPPPPPPPPPPPPP  RRRRRRRRRRRRRR   
'     AAAAAAAAA     PPPPP   PPPPPPP  RRRR    RRRRRRR  
'     AAAAAAAAA     PPPPP     PPPPP  RRRR      RRRRR  
'    AAAAAAAAAAA    PPPPP     PPPPP  RRRR      RRRRR  
'    AAAAA AAAAA    PPPPP     PPPPP  RRRR    RRRRRRR  
'   AAAAAA AAAAA    PPPPP   PPPPPPP  RRRRRRRRRRRRRR   
'   AAAAA  AAAAAA   PPPPPPPPPPPPPP   RRRRRRRRRRRRRR   
'   AAAAA   AAAAA   PPPPPPPPPPPPPP   RRRRRRRRRRRR     
'  AAAAAAAAAAAAAA   PPPPPPPPPPPPP    RRRR RRRRRRR     
'  AAAAAAAAAAAAAAA  PPPPP            RRRR   RRRRRR    
'  AAAAAAAAAAAAAAA  PPPPP            RRRR   RRRRRRR   
' AAAAAA     AAAAAA PPPPP            RRRR    RRRRRR   
' AAAAA      AAAAAA PPPPP            RRRR     RRRRRR  
' AAAAA       AAAAA PPPPP            RRRR     RRRRRR  
' AAAAA       AAAAAAPPPPP            RRRR      RRRRR

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

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("AKT10")) Then
'Sexual Violence
'Female,<10
IE.Document.GetElementByID("GT81rJIJrrd-zq6hDM0eyHD-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-zq6hDM0eyHD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKT10")
IE.Document.GetElementByID("GT81rJIJrrd-zq6hDM0eyHD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,10-14
IE.Document.GetElementByID("GT81rJIJrrd-SgTYo6S71cR-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-SgTYo6S71cR-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKU10")
IE.Document.GetElementByID("GT81rJIJrrd-SgTYo6S71cR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,15-19
IE.Document.GetElementByID("GT81rJIJrrd-aUwnyHuwMoM-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-aUwnyHuwMoM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKV10")
IE.Document.GetElementByID("GT81rJIJrrd-aUwnyHuwMoM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,20-24
IE.Document.GetElementByID("GT81rJIJrrd-zcgpWAmwXDe-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-zcgpWAmwXDe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKW10")
IE.Document.GetElementByID("GT81rJIJrrd-zcgpWAmwXDe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,25-29
IE.Document.GetElementByID("GT81rJIJrrd-IO9GD263u2H-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-IO9GD263u2H-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKX10")
IE.Document.GetElementByID("GT81rJIJrrd-IO9GD263u2H-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,30-34
IE.Document.GetElementByID("GT81rJIJrrd-qFe4iOwYox4-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-qFe4iOwYox4-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKY10")
IE.Document.GetElementByID("GT81rJIJrrd-qFe4iOwYox4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,35-39
IE.Document.GetElementByID("GT81rJIJrrd-ewXoNYCdpYZ-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-ewXoNYCdpYZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("AKZ10")
IE.Document.GetElementByID("GT81rJIJrrd-ewXoNYCdpYZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,40-44
IE.Document.GetElementByID("GT81rJIJrrd-xaE1rwbDcrA-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-xaE1rwbDcrA-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALA10")
IE.Document.GetElementByID("GT81rJIJrrd-xaE1rwbDcrA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,45-49
IE.Document.GetElementByID("GT81rJIJrrd-f5UCCdzK3Tv-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-f5UCCdzK3Tv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALB10")
IE.Document.GetElementByID("GT81rJIJrrd-f5UCCdzK3Tv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,50+
IE.Document.GetElementByID("GT81rJIJrrd-zu9HrgDHyQT-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-zu9HrgDHyQT-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALC10")
IE.Document.GetElementByID("GT81rJIJrrd-zu9HrgDHyQT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,<10
IE.Document.GetElementByID("GT81rJIJrrd-EjDC8XG5FTV-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-EjDC8XG5FTV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALD10")
IE.Document.GetElementByID("GT81rJIJrrd-EjDC8XG5FTV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,10-14
IE.Document.GetElementByID("GT81rJIJrrd-rMROM7S9IcM-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-rMROM7S9IcM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALE10")
IE.Document.GetElementByID("GT81rJIJrrd-rMROM7S9IcM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,15-19
IE.Document.GetElementByID("GT81rJIJrrd-iZDhpMYrUhD-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-iZDhpMYrUhD-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALF10")
IE.Document.GetElementByID("GT81rJIJrrd-iZDhpMYrUhD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,20-24
IE.Document.GetElementByID("GT81rJIJrrd-RX6Bt5WZBTp-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-RX6Bt5WZBTp-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALG10")
IE.Document.GetElementByID("GT81rJIJrrd-RX6Bt5WZBTp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,25-29
IE.Document.GetElementByID("GT81rJIJrrd-mm3OwXbMrDO-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-mm3OwXbMrDO-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALH10")
IE.Document.GetElementByID("GT81rJIJrrd-mm3OwXbMrDO-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,30-34
IE.Document.GetElementByID("GT81rJIJrrd-qbvstlhbKQN-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-qbvstlhbKQN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALI10")
IE.Document.GetElementByID("GT81rJIJrrd-qbvstlhbKQN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,35-39
IE.Document.GetElementByID("GT81rJIJrrd-DWK907m2A1w-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-DWK907m2A1w-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALJ10")
IE.Document.GetElementByID("GT81rJIJrrd-DWK907m2A1w-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,40-44
IE.Document.GetElementByID("GT81rJIJrrd-nL4Hn7rQRkH-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-nL4Hn7rQRkH-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALK10")
IE.Document.GetElementByID("GT81rJIJrrd-nL4Hn7rQRkH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,45-49
IE.Document.GetElementByID("GT81rJIJrrd-NDSiHWlZgdn-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-NDSiHWlZgdn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALL10")
IE.Document.GetElementByID("GT81rJIJrrd-NDSiHWlZgdn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,50+
IE.Document.GetElementByID("GT81rJIJrrd-t6SVZj25Y51-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-t6SVZj25Y51-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALM10")
IE.Document.GetElementByID("GT81rJIJrrd-t6SVZj25Y51-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Physical and / or Emotional Violence
'Female,<10
IE.Document.GetElementByID("GT81rJIJrrd-rZkSjF483iM-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-rZkSjF483iM-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALN10")
IE.Document.GetElementByID("GT81rJIJrrd-rZkSjF483iM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,10-14
IE.Document.GetElementByID("GT81rJIJrrd-FAVPrIMm5hQ-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-FAVPrIMm5hQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALO10")
IE.Document.GetElementByID("GT81rJIJrrd-FAVPrIMm5hQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,15-19
IE.Document.GetElementByID("GT81rJIJrrd-FAw0peqrDtE-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-FAw0peqrDtE-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALP10")
IE.Document.GetElementByID("GT81rJIJrrd-FAw0peqrDtE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,20-24
IE.Document.GetElementByID("GT81rJIJrrd-n1vpOIvT6Xv-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-n1vpOIvT6Xv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALQ10")
IE.Document.GetElementByID("GT81rJIJrrd-n1vpOIvT6Xv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,25-29
IE.Document.GetElementByID("GT81rJIJrrd-h0g9DokFKAZ-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-h0g9DokFKAZ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALR10")
IE.Document.GetElementByID("GT81rJIJrrd-h0g9DokFKAZ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,30-34
IE.Document.GetElementByID("GT81rJIJrrd-IpGAJ8qpFHU-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-IpGAJ8qpFHU-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALS10")
IE.Document.GetElementByID("GT81rJIJrrd-IpGAJ8qpFHU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,35-39
IE.Document.GetElementByID("GT81rJIJrrd-ba5JcnE1DUJ-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-ba5JcnE1DUJ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALT10")
IE.Document.GetElementByID("GT81rJIJrrd-ba5JcnE1DUJ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,40-44
IE.Document.GetElementByID("GT81rJIJrrd-RK5FpyT6bYE-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-RK5FpyT6bYE-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALU10")
IE.Document.GetElementByID("GT81rJIJrrd-RK5FpyT6bYE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,45-49
IE.Document.GetElementByID("GT81rJIJrrd-uRHqJGCDJgi-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-uRHqJGCDJgi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALV10")
IE.Document.GetElementByID("GT81rJIJrrd-uRHqJGCDJgi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,50+
IE.Document.GetElementByID("GT81rJIJrrd-CHWnztu6NhK-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-CHWnztu6NhK-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALW10")
IE.Document.GetElementByID("GT81rJIJrrd-CHWnztu6NhK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,<10
IE.Document.GetElementByID("GT81rJIJrrd-YKar5VC8roP-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-YKar5VC8roP-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALX10")
IE.Document.GetElementByID("GT81rJIJrrd-YKar5VC8roP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,10-14
IE.Document.GetElementByID("GT81rJIJrrd-bIuKoX80N2Z-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-bIuKoX80N2Z-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALY10")
IE.Document.GetElementByID("GT81rJIJrrd-bIuKoX80N2Z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,15-19
IE.Document.GetElementByID("GT81rJIJrrd-KQErAdoXLqV-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-KQErAdoXLqV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ALZ10")
IE.Document.GetElementByID("GT81rJIJrrd-KQErAdoXLqV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,20-24
IE.Document.GetElementByID("GT81rJIJrrd-UE87jwNYjtB-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-UE87jwNYjtB-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMA10")
IE.Document.GetElementByID("GT81rJIJrrd-UE87jwNYjtB-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,25-29
IE.Document.GetElementByID("GT81rJIJrrd-d4eyjtfMJjV-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-d4eyjtfMJjV-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMB10")
IE.Document.GetElementByID("GT81rJIJrrd-d4eyjtfMJjV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,30-34
IE.Document.GetElementByID("GT81rJIJrrd-TtarAq69fxc-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-TtarAq69fxc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMC10")
IE.Document.GetElementByID("GT81rJIJrrd-TtarAq69fxc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,35-39
IE.Document.GetElementByID("GT81rJIJrrd-I6c24vig2M7-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-I6c24vig2M7-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMD10")
IE.Document.GetElementByID("GT81rJIJrrd-I6c24vig2M7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,40-44
IE.Document.GetElementByID("GT81rJIJrrd-ZjLjyxbIXcD-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-ZjLjyxbIXcD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AME10")
IE.Document.GetElementByID("GT81rJIJrrd-ZjLjyxbIXcD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,45-49
IE.Document.GetElementByID("GT81rJIJrrd-CQQuvHn7dJa-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-CQQuvHn7dJa-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMF10")
IE.Document.GetElementByID("GT81rJIJrrd-CQQuvHn7dJa-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Male,50+
IE.Document.GetElementByID("GT81rJIJrrd-NRQe2llLF96-val").Focus
IE.Document.GetElementByID("GT81rJIJrrd-NRQe2llLF96-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMG10")
IE.Document.GetElementByID("GT81rJIJrrd-NRQe2llLF96-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'PEP
'Female,<10
IE.Document.GetElementByID("owIr2CJUbwq-sjNNy0f1X7D-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-sjNNy0f1X7D-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMH10")
IE.Document.GetElementByID("owIr2CJUbwq-sjNNy0f1X7D-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,10-14
IE.Document.GetElementByID("owIr2CJUbwq-v8fxZD3T83S-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-v8fxZD3T83S-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMI10")
IE.Document.GetElementByID("owIr2CJUbwq-v8fxZD3T83S-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,15-19
IE.Document.GetElementByID("owIr2CJUbwq-inZOMc3H9rs-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-inZOMc3H9rs-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMJ10")
IE.Document.GetElementByID("owIr2CJUbwq-inZOMc3H9rs-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,20-24
IE.Document.GetElementByID("owIr2CJUbwq-xTOWzqp35pE-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-xTOWzqp35pE-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMK10")
IE.Document.GetElementByID("owIr2CJUbwq-xTOWzqp35pE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,25-29
IE.Document.GetElementByID("owIr2CJUbwq-BepIh8WFKdy-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-BepIh8WFKdy-val").Value = ThisWorkbook.Sheets("sheet1").Range("AML10")
IE.Document.GetElementByID("owIr2CJUbwq-BepIh8WFKdy-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,30-34
IE.Document.GetElementByID("owIr2CJUbwq-PmPf5Baevie-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-PmPf5Baevie-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMM10")
IE.Document.GetElementByID("owIr2CJUbwq-PmPf5Baevie-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,35-39
IE.Document.GetElementByID("owIr2CJUbwq-uAxwBfK44jM-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-uAxwBfK44jM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMN10")
IE.Document.GetElementByID("owIr2CJUbwq-uAxwBfK44jM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,40-44
IE.Document.GetElementByID("owIr2CJUbwq-zOgyHZqFRfd-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-zOgyHZqFRfd-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMO10")
IE.Document.GetElementByID("owIr2CJUbwq-zOgyHZqFRfd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,45-49
IE.Document.GetElementByID("owIr2CJUbwq-QYqTPplzqyH-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-QYqTPplzqyH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMP10")
IE.Document.GetElementByID("owIr2CJUbwq-QYqTPplzqyH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Female,50+
IE.Document.GetElementByID("owIr2CJUbwq-DpcmJovCBpx-val").Focus
IE.Document.GetElementByID("owIr2CJUbwq-DpcmJovCBpx-val").Value = ThisWorkbook.Sheets("sheet1").Range("AMQ10")
IE.Document.GetElementByID("owIr2CJUbwq-DpcmJovCBpx-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ANB10")) Then
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANB10")
IE.Document.GetElementByID("Duf3Ks5vfNL-BbOgaCiB7BE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANC10")
IE.Document.GetElementByID("Duf3Ks5vfNL-wboZw8GvF3V-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").Value = ThisWorkbook.Sheets("sheet1").Range("AND10")
IE.Document.GetElementByID("Duf3Ks5vfNL-SthWYE5e0FG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANE10")
IE.Document.GetElementByID("Duf3Ks5vfNL-CPooeOVlJA4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").Focus
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANF10")
IE.Document.GetElementByID("Duf3Ks5vfNL-lsOHpBFk3Nn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
Sub PMTCT_FO()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ANG10")) Then
'Denominator
IE.Document.GetElementByID("jskukqOhI5M-HllvX50cXC0-val").Focus
IE.Document.GetElementByID("jskukqOhI5M-HllvX50cXC0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANG10")
IE.Document.GetElementByID("jskukqOhI5M-HllvX50cXC0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV-infected
IE.Document.GetElementByID("KYjkpApPVjU-XXVM3fPoj9N-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-XXVM3fPoj9N-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANI10")
IE.Document.GetElementByID("KYjkpApPVjU-XXVM3fPoj9N-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV-uninfected
IE.Document.GetElementByID("KYjkpApPVjU-Jz2ibrOD00K-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-Jz2ibrOD00K-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANJ10")
IE.Document.GetElementByID("KYjkpApPVjU-Jz2ibrOD00K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV-final status unknown
IE.Document.GetElementByID("KYjkpApPVjU-CWMkQRQI2Rj-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-CWMkQRQI2Rj-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANK10")
IE.Document.GetElementByID("KYjkpApPVjU-CWMkQRQI2Rj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Died without status known
IE.Document.GetElementByID("KYjkpApPVjU-n2lC5CRLwnR-val").Focus
IE.Document.GetElementByID("KYjkpApPVjU-n2lC5CRLwnR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANL10")
IE.Document.GetElementByID("KYjkpApPVjU-n2lC5CRLwnR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
Sub HRH()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False

If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ANN10")) Then
'.............................
'Deduplicated staff by Cadre..
'.............................
'Clinical Total # of Deduplicated staff by Cadre
IE.Document.GetElementByID("fv2OMXMwnJA-mkOfrTuz7tS-val").Focus
IE.Document.GetElementByID("fv2OMXMwnJA-mkOfrTuz7tS-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANN10")
IE.Document.GetElementByID("fv2OMXMwnJA-mkOfrTuz7tS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Pharmacy Total # of Deduplicated staff by Cadre
IE.Document.GetElementByID("fv2OMXMwnJA-VYMJrOJU5rQ-val").Focus
IE.Document.GetElementByID("fv2OMXMwnJA-VYMJrOJU5rQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANO10")
IE.Document.GetElementByID("fv2OMXMwnJA-VYMJrOJU5rQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Laboratory Total # of Deduplicated staff by Cadre
IE.Document.GetElementByID("fv2OMXMwnJA-T1jZtIrfVkq-val").Focus
IE.Document.GetElementByID("fv2OMXMwnJA-T1jZtIrfVkq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANP10")
IE.Document.GetElementByID("fv2OMXMwnJA-T1jZtIrfVkq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Management Total # of Deduplicated staff by Cadre
IE.Document.GetElementByID("fv2OMXMwnJA-oaRfTQD4RLG-val").Focus
IE.Document.GetElementByID("fv2OMXMwnJA-oaRfTQD4RLG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANQ10")
IE.Document.GetElementByID("fv2OMXMwnJA-oaRfTQD4RLG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Social Service Total # of Deduplicated staff by Cadre
IE.Document.GetElementByID("fv2OMXMwnJA-itxIkeWqiE9-val").Focus
IE.Document.GetElementByID("fv2OMXMwnJA-itxIkeWqiE9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANR10")
IE.Document.GetElementByID("fv2OMXMwnJA-itxIkeWqiE9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Lay Service Total # of Deduplicated staff by Cadre
IE.Document.GetElementByID("fv2OMXMwnJA-a9N5X73zhET-val").Focus
IE.Document.GetElementByID("fv2OMXMwnJA-a9N5X73zhET-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANS10")
IE.Document.GetElementByID("fv2OMXMwnJA-a9N5X73zhET-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Other Service Total # of Deduplicated staff by Cadre
IE.Document.GetElementByID("fv2OMXMwnJA-wKH5X6oHquw-val").Focus
IE.Document.GetElementByID("fv2OMXMwnJA-wKH5X6oHquw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANT10")
IE.Document.GetElementByID("fv2OMXMwnJA-wKH5X6oHquw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Clinical
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANU10")
IE.Document.GetElementByID("XL1jnbmgXje-lcEoncRc5Yt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-lcEoncRc5Yt-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-lcEoncRc5Yt-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANV10")
IE.Document.GetElementByID("yoxGr2OW5vT-lcEoncRc5Yt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANW10")
IE.Document.GetElementByID("XL1jnbmgXje-j53J4R7GFQV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-j53J4R7GFQV-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-j53J4R7GFQV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANX10")
IE.Document.GetElementByID("yoxGr2OW5vT-j53J4R7GFQV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANY10")
IE.Document.GetElementByID("XL1jnbmgXje-amcMmQaGHZ0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-amcMmQaGHZ0-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-amcMmQaGHZ0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ANZ10")
IE.Document.GetElementByID("yoxGr2OW5vT-amcMmQaGHZ0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Pharmacy
IE.Document.GetElementByID("XL1jnbmgXje-npLVwj9uAPF-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-npLVwj9uAPF-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOA10")
IE.Document.GetElementByID("XL1jnbmgXje-npLVwj9uAPF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-npLVwj9uAPF-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-npLVwj9uAPF-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOB10")
IE.Document.GetElementByID("yoxGr2OW5vT-npLVwj9uAPF-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-daiD4uNdH0M-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-daiD4uNdH0M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOC10")
IE.Document.GetElementByID("XL1jnbmgXje-daiD4uNdH0M-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-daiD4uNdH0M-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-daiD4uNdH0M-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOD10")
IE.Document.GetElementByID("yoxGr2OW5vT-daiD4uNdH0M-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-HyBf938HWMD-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-HyBf938HWMD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOE10")
IE.Document.GetElementByID("XL1jnbmgXje-HyBf938HWMD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-HyBf938HWMD-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-HyBf938HWMD-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOF10")
IE.Document.GetElementByID("yoxGr2OW5vT-HyBf938HWMD-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Laboratory
IE.Document.GetElementByID("XL1jnbmgXje-UJS3zRPmYdr-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-UJS3zRPmYdr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOG10")
IE.Document.GetElementByID("XL1jnbmgXje-UJS3zRPmYdr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-UJS3zRPmYdr-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-UJS3zRPmYdr-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOH10")
IE.Document.GetElementByID("yoxGr2OW5vT-UJS3zRPmYdr-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-jmxwyRzR8lM-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-jmxwyRzR8lM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOI10")
IE.Document.GetElementByID("XL1jnbmgXje-jmxwyRzR8lM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-jmxwyRzR8lM-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-jmxwyRzR8lM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOJ10")
IE.Document.GetElementByID("yoxGr2OW5vT-jmxwyRzR8lM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-RUuS9eTCv09-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-RUuS9eTCv09-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOK10")
IE.Document.GetElementByID("XL1jnbmgXje-RUuS9eTCv09-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-RUuS9eTCv09-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-RUuS9eTCv09-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOL10")
IE.Document.GetElementByID("yoxGr2OW5vT-RUuS9eTCv09-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Management
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOM10")
IE.Document.GetElementByID("XL1jnbmgXje-Ktp5As6zWxl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-Ktp5As6zWxl-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-Ktp5As6zWxl-val").Value = ThisWorkbook.Sheets("sheet1").Range("AON10")
IE.Document.GetElementByID("yoxGr2OW5vT-Ktp5As6zWxl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOO10")
IE.Document.GetElementByID("XL1jnbmgXje-rMgmbJPMxw2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-rMgmbJPMxw2-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-rMgmbJPMxw2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOP10")
IE.Document.GetElementByID("yoxGr2OW5vT-rMgmbJPMxw2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOQ10")
IE.Document.GetElementByID("XL1jnbmgXje-cskUzbj4asc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-cskUzbj4asc-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-cskUzbj4asc-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOR10")
IE.Document.GetElementByID("yoxGr2OW5vT-cskUzbj4asc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Social Service
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOS10")
IE.Document.GetElementByID("XL1jnbmgXje-iAQmGQJLuJi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-iAQmGQJLuJi-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-iAQmGQJLuJi-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOT10")
IE.Document.GetElementByID("yoxGr2OW5vT-iAQmGQJLuJi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOU10")
IE.Document.GetElementByID("XL1jnbmgXje-Os4enuLPVkA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-Os4enuLPVkA-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-Os4enuLPVkA-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOV10")
IE.Document.GetElementByID("yoxGr2OW5vT-Os4enuLPVkA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOW10")
IE.Document.GetElementByID("XL1jnbmgXje-nt6Mv9rOBFP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-nt6Mv9rOBFP-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-nt6Mv9rOBFP-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOX10")
IE.Document.GetElementByID("yoxGr2OW5vT-nt6Mv9rOBFP-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Lay Service
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOY10")
IE.Document.GetElementByID("XL1jnbmgXje-xh2pAMw81mS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-xh2pAMw81mS-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-xh2pAMw81mS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AOZ10")
IE.Document.GetElementByID("yoxGr2OW5vT-xh2pAMw81mS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").Value = ThisWorkbook.Sheets("sheet1").Range("APA10")
IE.Document.GetElementByID("XL1jnbmgXje-z8uoJOcMd8n-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-z8uoJOcMd8n-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-z8uoJOcMd8n-val").Value = ThisWorkbook.Sheets("sheet1").Range("APB10")
IE.Document.GetElementByID("yoxGr2OW5vT-z8uoJOcMd8n-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").Value = ThisWorkbook.Sheets("sheet1").Range("APC10")
IE.Document.GetElementByID("XL1jnbmgXje-CXYUkjSk3gC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-CXYUkjSk3gC-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-CXYUkjSk3gC-val").Value = ThisWorkbook.Sheets("sheet1").Range("APD10")
IE.Document.GetElementByID("yoxGr2OW5vT-CXYUkjSk3gC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Other Service
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").Value = ThisWorkbook.Sheets("sheet1").Range("APE10")
IE.Document.GetElementByID("XL1jnbmgXje-PDCEdxrmbWc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-PDCEdxrmbWc-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-PDCEdxrmbWc-val").Value = ThisWorkbook.Sheets("sheet1").Range("APF10")
IE.Document.GetElementByID("yoxGr2OW5vT-PDCEdxrmbWc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").Value = ThisWorkbook.Sheets("sheet1").Range("APG10")
IE.Document.GetElementByID("XL1jnbmgXje-r8CF58PRLMk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-r8CF58PRLMk-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-r8CF58PRLMk-val").Value = ThisWorkbook.Sheets("sheet1").Range("APH10")
IE.Document.GetElementByID("yoxGr2OW5vT-r8CF58PRLMk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").Focus
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("API10")
IE.Document.GetElementByID("XL1jnbmgXje-YAofbwYDMFf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("yoxGr2OW5vT-YAofbwYDMFf-val").Focus
IE.Document.GetElementByID("yoxGr2OW5vT-YAofbwYDMFf-val").Value = ThisWorkbook.Sheets("sheet1").Range("APJ10")
IE.Document.GetElementByID("yoxGr2OW5vT-YAofbwYDMFf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
Sub LAB_PTCQI()
Set evt = IE.Document.createEvent("HTMLEvents")
evt.initEvent "change", True, False
'LAB_Based
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("APP10")) Then
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").Value = ThisWorkbook.Sheets("sheet1").Range("APP10")
IE.Document.GetElementByID("mJONpM4NS83-wjvrjctVIFl-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").Value = ThisWorkbook.Sheets("sheet1").Range("APQ10")
IE.Document.GetElementByID("mJONpM4NS83-dvzWOOwlCTL-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").Value = ThisWorkbook.Sheets("sheet1").Range("APR10")
IE.Document.GetElementByID("mJONpM4NS83-bBYFupWkFv5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").Value = ThisWorkbook.Sheets("sheet1").Range("APS10")
IE.Document.GetElementByID("mJONpM4NS83-kvmsInuJ6Rm-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV IVT/EID
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").Value = ThisWorkbook.Sheets("sheet1").Range("APT10")
IE.Document.GetElementByID("mJONpM4NS83-fgc78xUuXYN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").Value = ThisWorkbook.Sheets("sheet1").Range("APU10")
IE.Document.GetElementByID("mJONpM4NS83-Jf9Wcow932c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").Value = ThisWorkbook.Sheets("sheet1").Range("APV10")
IE.Document.GetElementByID("mJONpM4NS83-gCzhExxbNYd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").Value = ThisWorkbook.Sheets("sheet1").Range("APW10")
IE.Document.GetElementByID("mJONpM4NS83-bKFJOpx3RRG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV Viral Load
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").Value = ThisWorkbook.Sheets("sheet1").Range("APX10")
IE.Document.GetElementByID("mJONpM4NS83-agGmRAeaZiV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").Value = ThisWorkbook.Sheets("sheet1").Range("APY10")
IE.Document.GetElementByID("mJONpM4NS83-Z0qfOiODpLT-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").Value = ThisWorkbook.Sheets("sheet1").Range("APZ10")
IE.Document.GetElementByID("mJONpM4NS83-ss1UjocOpi8-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQA10")
IE.Document.GetElementByID("mJONpM4NS83-g2onz7XRaAN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB Xpert
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQB10")
IE.Document.GetElementByID("mJONpM4NS83-ZahS9NJoKXW-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQC10")
IE.Document.GetElementByID("mJONpM4NS83-aU6B7ARLC5D-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQD10")
IE.Document.GetElementByID("mJONpM4NS83-Pq31JMqCwCh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQE10")
IE.Document.GetElementByID("mJONpM4NS83-HN71aSgygm2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB AFB
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQF10")
IE.Document.GetElementByID("mJONpM4NS83-WBmklDDpMK9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQG10")
IE.Document.GetElementByID("mJONpM4NS83-PwYC0dYJTi0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQH10")
IE.Document.GetElementByID("mJONpM4NS83-NW9C5LxQSaw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQI10")
IE.Document.GetElementByID("mJONpM4NS83-BC8M2tzZuzK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB Culture
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQJ10")
IE.Document.GetElementByID("mJONpM4NS83-mBqCymU7iDH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQK10")
IE.Document.GetElementByID("mJONpM4NS83-HbburZGhdc6-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQL10")
IE.Document.GetElementByID("mJONpM4NS83-PEmcDc3l3Ma-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQM10")
IE.Document.GetElementByID("mJONpM4NS83-hro5eQVT06z-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'CD4
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQN10")
IE.Document.GetElementByID("mJONpM4NS83-w97PFBrriFb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQO10")
IE.Document.GetElementByID("mJONpM4NS83-EUngOIhkk2K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQP10")
IE.Document.GetElementByID("mJONpM4NS83-Xgy1dZs6LpY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQQ10")
IE.Document.GetElementByID("mJONpM4NS83-BHOcyZmY4KV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Other
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQR10")
IE.Document.GetElementByID("mJONpM4NS83-on7sWkx3GcK-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQS10")
IE.Document.GetElementByID("mJONpM4NS83-tWUeCanlxoS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQT10")
IE.Document.GetElementByID("mJONpM4NS83-xk7MyebpXBb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").Focus
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQU10")
IE.Document.GetElementByID("mJONpM4NS83-PeDDjUaHEJS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'2
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQV10")
IE.Document.GetElementByID("ifqUg8hufqa-M5ETn6L06TX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQW10")
IE.Document.GetElementByID("ifqUg8hufqa-yqP8sdEslHe-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQX10")
IE.Document.GetElementByID("ifqUg8hufqa-SwijqDKg39a-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV IVT/EID
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQY10")
IE.Document.GetElementByID("ifqUg8hufqa-fPsjgJS4Y1b-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AQZ10")
IE.Document.GetElementByID("ifqUg8hufqa-yARDsUl7jL2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARA10")
IE.Document.GetElementByID("ifqUg8hufqa-kPseq1szL7a-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV Viral Load
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARB10")
IE.Document.GetElementByID("ifqUg8hufqa-lx8MrZoeqbu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARC10")
IE.Document.GetElementByID("ifqUg8hufqa-pgOsuoYuuqI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARD10")
IE.Document.GetElementByID("ifqUg8hufqa-Md2wJHpfZLS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB Xpert
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARE10")
IE.Document.GetElementByID("ifqUg8hufqa-ateI9jWePpi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARF10")
IE.Document.GetElementByID("ifqUg8hufqa-MO0XrsKbX5s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARG10")
IE.Document.GetElementByID("ifqUg8hufqa-ZlaikKV6Fjb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB AFB
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARH10")
IE.Document.GetElementByID("ifqUg8hufqa-OZ7ZpzpRDOG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARI10")
IE.Document.GetElementByID("ifqUg8hufqa-bME9lhrNZw2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARJ10")
IE.Document.GetElementByID("ifqUg8hufqa-ro8CgNFng17-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB Culture
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARK10")
IE.Document.GetElementByID("ifqUg8hufqa-XdD5EAst7OH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARL10")
IE.Document.GetElementByID("ifqUg8hufqa-tp3PpSM67pw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARM10")
IE.Document.GetElementByID("ifqUg8hufqa-m7YxHE5TgAv-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'CD4
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARN10")
IE.Document.GetElementByID("ifqUg8hufqa-LxXClsdXZgg-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARO10")
IE.Document.GetElementByID("ifqUg8hufqa-kU09A3lqJDR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARP10")
IE.Document.GetElementByID("ifqUg8hufqa-oXNvAdTPZXb-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Other
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARQ10")
IE.Document.GetElementByID("ifqUg8hufqa-og3bd0Ph8nj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARR10")
IE.Document.GetElementByID("ifqUg8hufqa-hjobBGwqCQp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").Focus
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARS10")
IE.Document.GetElementByID("ifqUg8hufqa-PMUw1K3ybr5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Specimens received
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ART10")
IE.Document.GetElementByID("iCBrw4jfZpW-oCr3aOvULR9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARU10")
IE.Document.GetElementByID("iCBrw4jfZpW-lyLlOQn9Fp2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARV10")
IE.Document.GetElementByID("iCBrw4jfZpW-wROfCcdTvss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARW10")
IE.Document.GetElementByID("iCBrw4jfZpW-hL4XtxFcUly-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARX10")
IE.Document.GetElementByID("iCBrw4jfZpW-YMEVFWa9k4c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARY10")
IE.Document.GetElementByID("iCBrw4jfZpW-ErICyBbbakd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").Value = ThisWorkbook.Sheets("sheet1").Range("ARZ10")
IE.Document.GetElementByID("iCBrw4jfZpW-SowytNTBD0k-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").Focus
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASA10")
IE.Document.GetElementByID("iCBrw4jfZpW-oKmaZM3W8u4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
End If
'POCT_Based
If Not IsEmpty(ThisWorkbook.Sheets("sheet1").Range("ASB10")) Then
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASB10")
IE.Document.GetElementByID("kIec9Ct3rmW-hInFtmuzHDf-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASC10")
IE.Document.GetElementByID("kIec9Ct3rmW-nfUIRf3FMoC-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASD10")
IE.Document.GetElementByID("kIec9Ct3rmW-OMV9exs4Jwh-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASE10")
IE.Document.GetElementByID("kIec9Ct3rmW-zSBp3PaZbyV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASF10")
IE.Document.GetElementByID("kIec9Ct3rmW-GTYD2Jz4jy9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV IVT/EID
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASG10")
IE.Document.GetElementByID("kIec9Ct3rmW-HEE8IQsRKSH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASH10")
IE.Document.GetElementByID("kIec9Ct3rmW-WZjzgiQNVQG-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASI10")
IE.Document.GetElementByID("kIec9Ct3rmW-f3Fp4ZcpgUE-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASJ10")
IE.Document.GetElementByID("kIec9Ct3rmW-RLhCaY19QGX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASK10")
IE.Document.GetElementByID("kIec9Ct3rmW-ldFSGD0yoXI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV Viral Load
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASL10")
IE.Document.GetElementByID("kIec9Ct3rmW-VVws7Bnkxj2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASM10")
IE.Document.GetElementByID("kIec9Ct3rmW-Ee6RJqyoaND-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASN10")
IE.Document.GetElementByID("kIec9Ct3rmW-vk0up5uA22L-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASO10")
IE.Document.GetElementByID("kIec9Ct3rmW-t0X7kuP5ITu-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASP10")
IE.Document.GetElementByID("kIec9Ct3rmW-gBHiHjh867b-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB Xpert
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASQ10")
IE.Document.GetElementByID("kIec9Ct3rmW-JYRrkeyoS5K-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASR10")
IE.Document.GetElementByID("kIec9Ct3rmW-LVKpFMHDCVS-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASS10")
IE.Document.GetElementByID("kIec9Ct3rmW-uZxKzmy1gT9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").Value = ThisWorkbook.Sheets("sheet1").Range("AST10")
IE.Document.GetElementByID("kIec9Ct3rmW-W3BCOcida7x-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASU10")
IE.Document.GetElementByID("kIec9Ct3rmW-jGeWA56aMyU-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB AFB
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASV10")
IE.Document.GetElementByID("kIec9Ct3rmW-cywAcu4UVW0-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASW10")
IE.Document.GetElementByID("kIec9Ct3rmW-fLz6DbRk6Mw-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASX10")
IE.Document.GetElementByID("kIec9Ct3rmW-lrhlvZHtWX9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASY10")
IE.Document.GetElementByID("kIec9Ct3rmW-BNw9GNp6tV5-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").Value = ThisWorkbook.Sheets("sheet1").Range("ASZ10")
IE.Document.GetElementByID("kIec9Ct3rmW-ZUVlmJ1164I-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'CD4
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATA10")
IE.Document.GetElementByID("kIec9Ct3rmW-gwHKAKHznIt-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATB10")
IE.Document.GetElementByID("kIec9Ct3rmW-KyAYHU2FTyY-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATC10")
IE.Document.GetElementByID("kIec9Ct3rmW-cITP8LkNcAj-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATD10")
IE.Document.GetElementByID("kIec9Ct3rmW-Y6uJrlohWwk-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATE10")
IE.Document.GetElementByID("kIec9Ct3rmW-YrJMntMq0oI-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Other
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATF10")
IE.Document.GetElementByID("kIec9Ct3rmW-ZnmN6tgY0NQ-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATG10")
IE.Document.GetElementByID("kIec9Ct3rmW-AYmLMcikVrX-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATH10")
IE.Document.GetElementByID("kIec9Ct3rmW-lehXF1LRHqA-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATI10")
IE.Document.GetElementByID("kIec9Ct3rmW-r0xdQ7Kp8Eq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").Focus
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATJ10")
IE.Document.GetElementByID("kIec9Ct3rmW-I8X0GYqzTeR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'2
'HIV Serology/Diagnostic Testing
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATK10")
IE.Document.GetElementByID("bHk1JDK2258-WTwRddezAcN-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATL10")
IE.Document.GetElementByID("bHk1JDK2258-OiQAT4scJab-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATM10")
IE.Document.GetElementByID("bHk1JDK2258-FmtEs0FhrI3-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV IVT/EID
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATN10")
IE.Document.GetElementByID("bHk1JDK2258-x1ZhynBLOIi-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATO10")
IE.Document.GetElementByID("bHk1JDK2258-cPzQeUyMQZc-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATP10")
IE.Document.GetElementByID("bHk1JDK2258-oX3ldNgOeUH-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'HIV Viral Load
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATQ10")
IE.Document.GetElementByID("bHk1JDK2258-ODKM7OHCRjz-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATR10")
IE.Document.GetElementByID("bHk1JDK2258-PFkP1b4ANZq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATS10")
IE.Document.GetElementByID("bHk1JDK2258-xhmIGOSW30y-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB Xpert
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATT10")
IE.Document.GetElementByID("bHk1JDK2258-vR29RErQpWn-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATU10")
IE.Document.GetElementByID("bHk1JDK2258-yY9Dl2GZnP7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATV10")
IE.Document.GetElementByID("bHk1JDK2258-hFUic9x0Ouq-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'TB AFB
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATW10")
IE.Document.GetElementByID("bHk1JDK2258-aaGH9ISti24-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATX10")
IE.Document.GetElementByID("bHk1JDK2258-YHLx3VeYEcV-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATY10")
IE.Document.GetElementByID("bHk1JDK2258-smN1gR96NfR-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'CD4
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").Value = ThisWorkbook.Sheets("sheet1").Range("ATZ10")
IE.Document.GetElementByID("bHk1JDK2258-xj65GAubNL7-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUA10")
IE.Document.GetElementByID("bHk1JDK2258-onZfonByj2s-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUB10")
IE.Document.GetElementByID("bHk1JDK2258-RpONrp3gGku-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Other
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUC10")
IE.Document.GetElementByID("bHk1JDK2258-d3BHuxTH1cp-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUD10")
IE.Document.GetElementByID("bHk1JDK2258-jT7bpHN3WlM-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").Focus
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUE10")
IE.Document.GetElementByID("bHk1JDK2258-CKlcawPMejd-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
'Specimens received
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUF10")
IE.Document.GetElementByID("KMtAtCRNZl8-oCr3aOvULR9-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUG10")
IE.Document.GetElementByID("KMtAtCRNZl8-lyLlOQn9Fp2-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUH10")
IE.Document.GetElementByID("KMtAtCRNZl8-wROfCcdTvss-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUI10")
IE.Document.GetElementByID("KMtAtCRNZl8-hL4XtxFcUly-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUJ10")
IE.Document.GetElementByID("KMtAtCRNZl8-YMEVFWa9k4c-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUK10")
IE.Document.GetElementByID("KMtAtCRNZl8-SowytNTBD0k-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").Focus
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").Value = ThisWorkbook.Sheets("sheet1").Range("AUL10") 
IE.Document.GetElementByID("KMtAtCRNZl8-oKmaZM3W8u4-val").dispatchEvent evt
Application.Wait Now + TimeValue("00:00:0" & Int ((5 - 2 + 1) * Rnd + 2))
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
    lStr =  lStr & "<tr><td bgcolor='#F3F3F3'>Observação:</td><td>" & ThisWorkbook.Sheets("sheet1").Range("A5") & "</td></tr><tr><td colspan='2' style='text-align:center;background-color:#0288D1;color:white;'> <a href='http://197.235.11.130:8181/dhis'><span style='color:#00FFFF;'>DHIS-FGH</span></a><br><a href='https://www.datim.org/'><span style='color:#00FFFF;'>DATIM</span></a><br>" & Year(Now()) & " &copy; <a href='mailto:sis@fgh.org.mz'><span style='color:#00FFFF;'>sis@fgh.org.mz</span></a></td></tr></table>"

    'Set All Email Properties
    With NewMail
        .Subject = "[DHIS-FGH] Autofill DATIM"  & ", nº " & i & " de " & lastRow & " (" & ThisWorkbook.Sheets("sheet1").Range("B10") & "): "  & ThisWorkbook.Sheets("sheet1").Range("A10") 
        .From = "dhis.fgh@gmail.com"
        .To = ""
        .CC = ""
        '.BCC= "damasceno.lopes@fgh.org.mz;prosperino.mbalame@fgh.org.mz"
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