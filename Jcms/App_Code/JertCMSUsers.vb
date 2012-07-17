Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports Jertix.Functions

Namespace JertCMSUsers

    Public Structure _cms_UsersLevels
        Dim L1_NonLoggato As Long
        Dim L2_PermessiDiModificaLimitati_Blogger As Long
        Dim L3_GestioneContenutiSito As Long
        Dim L4_AmministratoreSito As Long
        Dim L5_ProgrammatoreSito As Long
        Dim L6_SuperUser As Long
        Dim L3_BackOfficeUser As Long
    End Structure

    Public Structure _UserInfo
        Dim idUser As Long
        Dim NomeUtente As String
        Dim Pass As String
        Dim idRole As Long
        Dim idLingua As Long

        Dim Module_Name_Default As String
        Dim Module_Id_Default As Long
        Dim Module_RedirectURL_Default As String
        Dim Module_Have_Default_Setted As Boolean
    End Structure

    Public Structure _Module
        Dim idModule As Long
        Dim Name As String
        Dim DataBaseName As String
        Dim DefaultRedirectURL As String
    End Structure

    Public Class JertCMSCookies

        Public Function ReadCookie(ByVal Name As String) As String
            Dim retValue As String = ""
            If Not HttpContext.Current.Request.Cookies(Name) Is Nothing Then
                Dim aCookie As HttpCookie = HttpContext.Current.Request.Cookies(Name)
                retValue = HttpContext.Current.Server.HtmlEncode(aCookie.Value)
            End If
            Return retValue
        End Function

        Public Sub DeleteCookie(ByVal Name As String)
            SaveCookie(Name, "", -1)
        End Sub

        Public Sub SaveCookie(ByVal Name As String, ByVal Value As String, Optional ByVal NumDaysToExpires As Long = 30)
            Dim aCookie As New HttpCookie(Name, Value)
            aCookie.Expires = DateTime.Now.AddDays(NumDaysToExpires)
            HttpContext.Current.Response.Cookies.Add(aCookie)
        End Sub
    End Class

    Public Class JertCMSUsers

        Dim db As New DBFunctions
        Dim myReader As OleDbDataReader
        Dim Sql As String

        Public UserLevels As _cms_UsersLevels

        Sub New()
            InitUserLevels()
        End Sub

        Private Sub InitUserLevels()
            With UserLevels
                .L1_NonLoggato = GetidRoleByRoleDescription("L1_NonLoggato")
                .L2_PermessiDiModificaLimitati_Blogger = GetidRoleByRoleDescription("L2_PermessiDiModificaLimitati_Blogger")

                .L3_GestioneContenutiSito = GetidRoleByRoleDescription("L3_GestioneContenutiSito")
                .L3_BackOfficeUser = GetidRoleByRoleDescription("L3_BackOfficeUser")

                .L4_AmministratoreSito = GetidRoleByRoleDescription("L4_AmministratoreSito")
                .L5_ProgrammatoreSito = GetidRoleByRoleDescription("L5_ProgrammatoreSito")
                .L6_SuperUser = GetidRoleByRoleDescription("L6_SuperUser")
            End With
        End Sub

        Public ReadOnly Property UsersLevels() As _cms_UsersLevels
            Get
                Return UserLevels
            End Get
        End Property

        Public Function isLogged() As Boolean
            'If HttpContext.Current.Session Is Nothing Then Return False
            If HttpContext.Current.Request.QueryString("n") = "" Then
                Return HttpContext.Current.Session("Logged")
            Else
                If HttpContext.Current.Request.QueryString("n") = "n1f" Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Public Sub LogOut()
            HttpContext.Current.Session("idUser") = ""
            HttpContext.Current.Session("UserName") = ""
            HttpContext.Current.Session("Password") = ""
            HttpContext.Current.Session("Livello") = UserLevels.L1_NonLoggato
            HttpContext.Current.Session("idRole") = ""
            HttpContext.Current.Session("Logged") = False
        End Sub

        Public Function Login(ByVal UserName As String, ByVal Password As String, Optional ByVal AlternativeLoginConnectionString As String = "", Optional ByVal AlternativeUsersTable As String = "", Optional ByVal AlternativeUserFieldName As String = "", Optional ByVal AlternativeUserPasswordName As String = "", Optional ByVal AlternativeidUserName As String = "") As Boolean
            Dim retValue As Boolean = False

            UserName = UserName.Replace("'", "").Replace("""", "").Trim.ToLower
            Password = Password.Replace("'", "").Replace("""", "").Trim.ToLower

            If AlternativeLoginConnectionString = "" Then
                Sql = "SELECT Utenti.idUser, Utenti.NomeUtente, Utenti.Pass, Roles.Livello, Utenti.idRole FROM Utenti INNER JOIN Roles ON Utenti.idRole = Roles.idRole WHERE NomeUtente = '" & UserName & "' AND Pass = '" & Password & "'"

                db.OpenConn(Sql)
                myReader = db.ExecuteReader

                While myReader.Read
                    retValue = True
                    HttpContext.Current.Session("idUser") = myReader("idUser")
                    HttpContext.Current.Session("UserName") = myReader("NomeUtente")
                    HttpContext.Current.Session("Password") = myReader("Pass")
                    HttpContext.Current.Session("Livello") = myReader("Livello")
                    HttpContext.Current.Session("idRole") = myReader("idRole")
                    HttpContext.Current.Session("Logged") = True
                End While
                myReader.Close()
                db.CloseConn()
            Else
                Sql = "SELECT * From [" & AlternativeUsersTable & "] WHERE [" & AlternativeUserFieldName & "] = '" & UserName & "' AND [" & AlternativeUserPasswordName & "] = '" & Password & "'"
                Dim ConnString As String = ConfigurationManager.ConnectionStrings(AlternativeLoginConnectionString).ConnectionString

                db.OpenConn(Sql, , , , , , ConnString)
                myReader = db.ExecuteReader

                While myReader.Read
                    retValue = True

                    HttpContext.Current.Session("idRole") = UserLevels.L3_BackOfficeUser
                    HttpContext.Current.Session("idUser") = myReader(AlternativeidUserName)
                    HttpContext.Current.Session(AlternativeUserFieldName) = myReader(AlternativeUserFieldName)
                    HttpContext.Current.Session(AlternativeUserPasswordName) = myReader(AlternativeUserPasswordName)

                    HttpContext.Current.Session("Logged") = True
                End While
                myReader.Close()
                db.CloseConn()

                If HttpContext.Current.Session("Logged") = False Then
                    Sql = "SELECT Utenti.idUser, Utenti.NomeUtente, Utenti.Pass, Roles.Livello, Utenti.idRole FROM Utenti INNER JOIN Roles ON Utenti.idRole = Roles.idRole WHERE NomeUtente = '" & UserName & "' AND Pass = '" & Password & "'"

                    db.OpenConn(Sql)
                    myReader = db.ExecuteReader

                    While myReader.Read
                        retValue = True
                        HttpContext.Current.Session("idUser") = myReader("idUser")
                        HttpContext.Current.Session("UserName") = myReader("NomeUtente")
                        HttpContext.Current.Session("Password") = myReader("Pass")
                        HttpContext.Current.Session("Livello") = myReader("Livello")
                        HttpContext.Current.Session("idRole") = myReader("idRole")
                        HttpContext.Current.Session("Logged") = True
                    End While
                    myReader.Close()
                    db.CloseConn()
                End If

            End If

            If Not retValue Then
                LogOut()
            End If

            Return retValue
        End Function

        Function GetLivelloByRoleDescription(ByVal Description As String) As Long
            Dim retValue As Long = -1

            Sql = "SELECT Livello From Roles Where Description = '" & Description & "';"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("Livello")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Function GetidRoleByRoleDescription(ByVal Description As String) As Long
            Dim retValue As Long = -1

            Sql = "SELECT idRole From Roles Where Description = '" & Description & "';"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("idRole")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Function GetDefaultModuleName(ByVal UserID As Long) As String
            Dim retValue As String = ""

            Sql = "SELECT ModulesInstalled.Name FROM ModuleUsers INNER JOIN ModulesInstalled ON ModuleUsers.idModule = ModulesInstalled.idModule WHERE ModuleUsers.isDefaultModule = True AND ModuleUsers.idUser = " & UserID & ";"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("Name")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Function GetDefaultModuleID(ByVal UserID As Long) As String
            Dim retValue As Long = -1

            Sql = "SELECT ModulesInstalled.idModule FROM ModuleUsers INNER JOIN ModulesInstalled ON ModuleUsers.idModule = ModulesInstalled.idModule WHERE ModuleUsers.isDefaultModule = True AND ModuleUsers.idUser = " & UserID & ";"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("idModule")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Function getRedirectURL(ByVal UserID As Long, ByVal ModuleID As Long) As String
            Dim retValue As String = ""
            If ModuleID = -1 Then Return retValue

            Sql = "SELECT RedirectUrl From ModuleUsers Where idModule = " & ModuleID & " AND idUser = " & UserID & " AND isDefaultModule = True"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("RedirectUrl")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

    End Class

End Namespace