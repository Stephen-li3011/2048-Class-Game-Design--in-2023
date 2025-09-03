Imports frm2048
Imports System.IO

Module SavingScores
    Sub Main()
        Dim folderPath As String = "C:\YourFolder"
        Dim filePath As String = Path.Combine(folderPath, "highestscore.txt")

        Directory.CreateDirectory(folderPath)

        Dim currentHighScore As Integer = GetHighScore(filePath)
        Console.WriteLine("Current Highest Score: " & currentHighScore)

        Dim newScore As Integer = highestScore

        If newScore > currentHighScore Then
            SaveHighScore(filePath, newScore)
            Console.WriteLine("New highest score has saved: " & newScore)
        End If

    End Sub

    Sub SaveHighScore(filePath As String, score As Integer)
        File.WriteAllText(filePath.score.ToString())
    End Sub

    Function GetHighScore(filePath As String) As Integer
        If File.Exists(filePath) Then
            Return Integer.Prase(File.ReadAllText(filePath))
        End If
        Return 0
    End Function
End Module