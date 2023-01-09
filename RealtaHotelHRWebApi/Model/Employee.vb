Namespace Model
    Public Class Employee
        Private _empId As Integer
        Private _empNationalId As String
        Private _empBirthDate As DateTime
        Private _empMaritalStatus As Char
        Private _empGender As Char
        Private _empHireDate As DateTime
        Private _empSalariedFlag As Char
        Private _empVacationHours As Integer = 0
        Private _empSickleaveHours As Integer = 0
        Private _empCurrentFlag As Integer = 0
        Private _empPhoto As String = ""
        Private _empModifiedDate As DateTime = DateTime.Now
        Private _empEmpId As Integer = 0
        Private _empJoroId As Integer

        Public Sub New()
        End Sub

        Public Sub New(empId As Integer, empNationalId As String, empBirthDate As Date, empMaritalStatus As Char, empGender As Char, empHireDate As Date, empSalariedFlag As Char, empVacationHours As Integer, empSickleaveHours As Integer, empCurrentFlag As Integer, empPhoto As String, empModifiedDate As Date, empEmpId As Integer, empJoroId As Integer)
            Me.EmpId = empId
            Me.EmpNationalId = empNationalId
            Me.EmpBirthDate = empBirthDate
            Me.EmpMaritalStatus = empMaritalStatus
            Me.EmpGender = empGender
            Me.EmpHireDate = empHireDate
            Me.EmpSalariedFlag = empSalariedFlag
            Me.EmpVacationHours = empVacationHours
            Me.EmpSickleaveHours = empSickleaveHours
            Me.EmpCurrentFlag = empCurrentFlag
            Me.EmpPhoto = empPhoto
            Me.EmpModifiedDate = empModifiedDate
            Me.EmpEmpId = empEmpId
            Me.EmpJoroId = empJoroId
        End Sub

        Public Overrides Function ToString() As String
            Return $"EmpId : {_empId}, EmpNationalId : {_empNationalId}, EmpBirthDate : {_empBirthDate}, EmpMaritalStatus : {_empMaritalStatus}, EmpGender : {_empGender}, EmpHireDate : {_empHireDate}, EmpSalariedFlag : {_empSalariedFlag}, EmpVacationHours : {_empVacationHours}, EmpSickHours : {_empSickleaveHours}, EmpCurrentFlag : {_empCurrentFlag}, EmpPhoto : {_empPhoto}, EmpModifiedDate : {_empModifiedDate}, EmpEmpId : {_empEmpId}, EmpJoroId : {_empJoroId}"
        End Function

        Public Property EmpId As Integer
            Get
                Return _empId
            End Get
            Set(value As Integer)
                _empId = value
            End Set
        End Property

        Public Property EmpNationalId As String
            Get
                Return _empNationalId
            End Get
            Set(value As String)
                _empNationalId = value
            End Set
        End Property

        Public Property EmpBirthDate As Date
            Get
                Return _empBirthDate
            End Get
            Set(value As Date)
                _empBirthDate = value
            End Set
        End Property

        Public Property EmpMaritalStatus As Char
            Get
                Return _empMaritalStatus
            End Get
            Set(value As Char)
                _empMaritalStatus = value
            End Set
        End Property

        Public Property EmpGender As Char
            Get
                Return _empGender
            End Get
            Set(value As Char)
                _empGender = value
            End Set
        End Property

        Public Property EmpHireDate As Date
            Get
                Return _empHireDate
            End Get
            Set(value As Date)
                _empHireDate = value
            End Set
        End Property

        Public Property EmpSalariedFlag As Char
            Get
                Return _empSalariedFlag
            End Get
            Set(value As Char)
                _empSalariedFlag = value
            End Set
        End Property

        Public Property EmpVacationHours As Integer
            Get
                Return _empVacationHours
            End Get
            Set(value As Integer)
                _empVacationHours = value
            End Set
        End Property

        Public Property EmpSickleaveHours As Integer
            Get
                Return _empSickleaveHours
            End Get
            Set(value As Integer)
                _empSickleaveHours = value
            End Set
        End Property

        Public Property EmpCurrentFlag As Integer
            Get
                Return _empCurrentFlag
            End Get
            Set(value As Integer)
                _empCurrentFlag = value
            End Set
        End Property

        Public Property EmpPhoto As String
            Get
                Return _empPhoto
            End Get
            Set(value As String)
                _empPhoto = value
            End Set
        End Property

        Public Property EmpModifiedDate As Date
            Get
                Return _empModifiedDate
            End Get
            Set(value As Date)
                _empModifiedDate = value
            End Set
        End Property

        Public Property EmpEmpId As Integer
            Get
                Return _empEmpId
            End Get
            Set(value As Integer)
                _empEmpId = value
            End Set
        End Property

        Public Property EmpJoroId As Integer
            Get
                Return _empJoroId
            End Get
            Set(value As Integer)
                _empJoroId = value
            End Set
        End Property


    End Class

End Namespace