'Author:
'   V. Sudharsan (vsudharsan@novell.com)
'
' (C) 2005 Novell, Inc.

'System.OverflowException

Imports System
Imports Nunit.Framework

<TestFixture>_
Public Class ImpConversionSingletoIntA
	_<Test, ExpectedException (GetType (System.OverflowException))>
        Public Sub TestForException()	
		Dim a as Integer 
		Dim b as Single = 3000000000
		a = b
        End Sub
End Class 