Imports System
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics

Public Module DebugNunitModule
    Sub DebugNunit()
        Try
            Dim dbg2 As EnvDTE80.Debugger2 = DTE.Debugger
            Dim trans As EnvDTE80.Transport = dbg2.Transports.Item("Default")
            Dim dbgeng(1) As EnvDTE80.Engine
            dbgeng(0) = trans.Engines.Item("Managed")
            Dim proc2 As EnvDTE80.Process2 = dbg2.GetProcesses(trans, ".").Item("nunit.exe")
            proc2.Attach2(dbgeng)
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Module


