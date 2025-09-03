Module Modulehighscore
    Sub Main()
        Dim folderPath As String = "C:/HighestScore"

        If Not System.IO.Directory.Exists(folderPath) Then
            System.IO.Directory.CreateDirectory(folderPath)
        End If

        Dim filePath As String = Application.StartupPath & "\score.txt"

        'If Not System.IO.File.Exists(filePath) Then
        '    System.IO.File.CreateText(filePath)
        'End If

        System.IO.File.WriteAllText(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        Dim temp As String() = System.IO.File.ReadLines(filePath)


    End Sub
End Module
