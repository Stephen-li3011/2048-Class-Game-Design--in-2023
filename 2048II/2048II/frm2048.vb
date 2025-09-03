Public Class frm2048
#Region "私有变量"
    ''' <summary>
    ''' 2048合成已经提示标志
    ''' </summary>
    Private hasShownMessage = False
    Private currentScore As Integer
    Private highestScore As Integer
    Private gameGrid(3, 3) As Label
    Private numberOfRollbacks As Integer = 0
    ''' <summary>
    ''' 合成回退步数的分数的一半
    ''' </summary>
    Private RollbackScore As Integer = 32
    Private SavedGameGrids As New Stack(Of List(Of String))
#End Region

    ''' <summary>
    ''' 表示4*4网格，用label来表示每个格子的数字
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frm2048_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(900, 650)
        InitializeGameBoard()
        UpdateHighestScores()
        UpdateScores()
        AddNewRandomNumber()
        AddNewRandomNumber()
        Dim row, column As Integer
        For row = 0 To 3
            For column = 0 To 3
                If gameGrid(row, column).Text <> "" Then
                    gameGrid(row, column).ForeColor = Color.Blue
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 向上移动
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyUp_Click(sender As Object, e As EventArgs) Handles KeyUp.Click
        Dim row, column As Integer
        Dim gameGridCopy(3, 3) As String
        Dim moved As Boolean
        Dim PriviousBlocksText As New List(Of String)
        PriviousBlocksText.Add(currentScore.ToString)

        For row = 0 To 3
            Dim queue As New Queue(Of Integer)
            For column = 0 To 3
                gameGridCopy(column, row) = gameGrid(column, row).Text
                If gameGrid(column, row).Text <> "" Then
                    queue.Enqueue(CInt(gameGrid(column, row).Text))
                End If
                gameGrid(column, row).Text = ""
            Next
            Dim k As Integer = 0
            While queue.Count > 0
                Dim value As Integer = queue.Dequeue()
                If queue.Count > 0 AndAlso value = queue.Peek() Then
                    If value = Me.RollbackScore Then
                        numberOfRollbacks += 1
                    End If
                    value += queue.Dequeue()
                    currentScore += value
                End If
                gameGrid(k, row).Text = value.ToString()
                UpdateBlockColour()
                k += 1
            End While
        Next
        For row = 0 To 3
            For column = 0 To 3
                If gameGrid(row, column).Text <> gameGridCopy(row, column) Then
                    moved = True
                End If
            Next
        Next

        For row = 0 To 3
            For column = 0 To 3
                PriviousBlocksText.Add(gameGridCopy(row, column))
            Next
        Next

        SavedGameGrids.Push(PriviousBlocksText)

        If moved Then
            AddNewRandomNumber()
            UpdateScores()
            CheckWin()
            CheckGameOver()
        Else
            MsgBox("This direction cannot be moved, please choose another direction.")
        End If
    End Sub
    ''' <summary>
    ''' 向下移动
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyDown_Click(sender As Object, e As EventArgs) Handles KeyDown.Click
        Dim row, column As Integer
        Dim gameGridCopy(3, 3) As String
        Dim moved As Boolean
        Dim PriviousBlocksText As New List(Of String)
        PriviousBlocksText.Add(currentScore.ToString)

        For row = 0 To 3
            Dim queue As New Queue(Of Integer)
            For column = 3 To 0 Step -1
                gameGridCopy(column, row) = gameGrid(column, row).Text
                If gameGrid(column, row).Text <> "" Then
                    queue.Enqueue(CInt(gameGrid(column, row).Text))
                End If
                gameGrid(column, row).Text = ""
            Next
            Dim k As Integer = 3
            While queue.Count > 0
                Dim value As Integer = queue.Dequeue()
                If queue.Count > 0 AndAlso value = queue.Peek() Then
                    If value = Me.RollbackScore Then
                        numberOfRollbacks += 1
                    End If
                    value += queue.Dequeue()
                    currentScore += value
                End If
                gameGrid(k, row).Text = value.ToString()
                UpdateBlockColour()
                k -= 1
            End While
        Next

        For row = 0 To 3
            For column = 0 To 3
                If gameGrid(row, column).Text <> gameGridCopy(row, column) Then
                    moved = True
                End If
            Next
        Next

        For row = 0 To 3
            For column = 0 To 3
                PriviousBlocksText.Add(gameGridCopy(row, column))
            Next
        Next

        SavedGameGrids.Push(PriviousBlocksText)

        If moved Then
            AddNewRandomNumber()
            UpdateScores()
            CheckWin()
            CheckGameOver()
        Else
            MsgBox("This direction cannot be moved, please choose another direction.")
        End If
    End Sub
    ''' <summary>
    ''' 向左移动
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyLeft_Click(sender As Object, e As EventArgs) Handles KeyLeft.Click
        Dim row, column As Integer
        Dim gameGridCopy(3, 3) As String
        Dim moved As Boolean = False
        Dim PriviousBlocksText As New List(Of String)
        PriviousBlocksText.Add(currentScore.ToString)

        For row = 0 To 3
            '使用queue来表示每一行里非空的格子'
            Dim queue As New Queue(Of Integer)
            For column = 0 To 3
                '将原本的格子复制一遍'
                gameGridCopy(row, column) = gameGrid(row, column).Text
                '将非空格子压入队列中'
                If gameGrid(row, column).Text <> "" Then
                    queue.Enqueue(CInt(gameGrid(row, column).Text))
                End If
                '清空该行'
                gameGrid(row, column).Text = ""
            Next
            Dim k As Integer = 0
            While queue.Count > 0
                Dim value As Integer = queue.Dequeue()
                '判断相邻的两个非空格子的数值是否相等'
                If queue.Count > 0 AndAlso value = queue.Peek() Then
                    If value = Me.RollbackScore Then
                        numberOfRollbacks += 1
                    End If
                    value += queue.Dequeue()
                    currentScore += value
                End If
                '将数字重新加到该行中'
                gameGrid(row, k).Text = value.ToString()
                UpdateBlockColour()
                k += 1
            End While
        Next

        For row = 0 To 3
            For column = 0 To 3
                '判断是否移动'
                If gameGrid(row, column).Text <> gameGridCopy(row, column) Then
                    moved = True
                End If
            Next
        Next

        For row = 0 To 3
            For column = 0 To 3
                PriviousBlocksText.Add(gameGridCopy(row, column))
            Next
        Next

        SavedGameGrids.Push(PriviousBlocksText)

        '如果成功移动，添加随机数字并且更新分数'
        If moved Then
            AddNewRandomNumber()
            UpdateScores()
            CheckWin()
            CheckGameOver()
        Else
            MsgBox("This direction cannot be moved, please choose another direction.")
        End If
    End Sub
    ''' <summary>
    ''' 向右移动
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyRight_Click(sender As Object, e As EventArgs) Handles KeyRight.Click
        Dim moved As Boolean = False
        Dim gameGridCopy(3, 3) As String
        Dim row, column As Integer
        Dim PriviousBlocksText As New List(Of String)
        PriviousBlocksText.Add(currentScore.ToString)

        For row = 0 To 3
            Dim queue As New Queue(Of Integer)
            For column = 3 To 0 Step -1
                gameGridCopy(row, column) = gameGrid(row, column).Text
                If gameGrid(row, column).Text <> "" Then
                    queue.Enqueue((CInt(gameGrid(row, column).Text)))
                End If
                gameGrid(row, column).Text = ""
            Next
            Dim k As Integer = 3
            While queue.Count > 0
                Dim value As Integer = queue.Dequeue()
                If queue.Count > 0 AndAlso value = queue.Peek() Then
                    If value = Me.RollbackScore Then
                        numberOfRollbacks += 1
                    End If
                    value += queue.Dequeue()
                    currentScore += value
                End If
                gameGrid(row, k).Text = value.ToString()
                UpdateBlockColour()
                k -= 1
            End While
        Next

        For row = 0 To 3
            For column = 0 To 3
                If gameGrid(row, column).Text <> gameGridCopy(row, column) Then
                    moved = True
                End If
            Next
        Next


        For row = 0 To 3
            For column = 0 To 3
                PriviousBlocksText.Add(gameGridCopy(row, column))
            Next
        Next

        SavedGameGrids.Push(PriviousBlocksText)

        If moved Then
            AddNewRandomNumber()
            UpdateScores()
            CheckWin()
            CheckGameOver()
        Else
            MsgBox("This direction cannot be moved, please choose another direction.")
        End If
    End Sub


    ''' <summary>
    ''' 生成16个label并且把他们添加到4*4的网格中
    ''' </summary>
    Private Sub InitializeGameBoard()
        Dim row, column As Integer
        For row = 0 To 3
            For column = 0 To 3
                Dim Block As New Label()
                Block.Text = ""
                Block.BackColor = Color.LightGray
                Block.TextAlign = ContentAlignment.MiddleCenter
                Block.AutoSize = False
                Block.Size = New Size(100, 100)
                Block.Font = New Font("Times New Roman", 20, FontStyle.Bold)
                gameGrid(row, column) = Block
                '将空白的标签添加到表格中，从（0， 0）开始'
                GamePanel.Controls.Add(gameGrid(row, column), column, row)
            Next
        Next
    End Sub
    ''' <summary>
    ''' 增加随机数字2或4
    ''' </summary>
    Private Sub AddNewRandomNumber()
        Dim emptyBlocks As New List(Of Point)
        Dim row, column As Integer
        For row = 0 To 3
            For column = 0 To 3
                '判断格子是否为空，如果为空，将坐标以点的形式放入列表中'
                If gameGrid(row, column).Text = "" Then
                    emptyBlocks.Add(New Point(row, column))
                End If
            Next
        Next
        If emptyBlocks.Count > 0 Then
            Dim randomBlock As New Random()
            Dim randomNumber As New Random()
            '随机选择空的方块所代表的index作为添加数字的目标'
            Dim randomIndex As Integer = randomBlock.Next(0, emptyBlocks.Count)
            Dim newValue As Integer
            '设置概率，生成2的概率为80%，生成4的概率为20%'
            If randomNumber.Next(0, 5) = 1 Then
                newValue = 4
            Else
                newValue = 2
            End If
            Dim selectedCell As Point = emptyBlocks(randomIndex)
            '将数字添加到网格中'
            gameGrid(selectedCell.X, selectedCell.Y).Text = newValue.ToString
            UpdateBlockColour()
            gameGrid(selectedCell.X, selectedCell.Y).ForeColor = Color.Blue
        End If
    End Sub
    ''' <summary>
    ''' 更新当前的分数以及最高分
    ''' </summary>
    Private Sub UpdateScores()
        Score.Text = "Current Score:" & currentScore.ToString
        rollbackCount.Text = "Rollback Chance:" & numberOfRollbacks.ToString
    End Sub
    ''' <summary>
    ''' 点击restart按钮后重新开始游戏
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RestartKey_Click(sender As Object, e As EventArgs) Handles RestartKey.Click
        RestartGame()
    End Sub
    ''' <summary>
    ''' 重新开始游戏
    ''' </summary>
    Private Sub RestartGame()

        SaveScores()
        '将回退次数减为0'
        numberOfRollbacks = 0
        Dim row, column As Integer
        For row = 0 To 3
            For column = 0 To 3
                gameGrid(row, column).Text = ""
            Next
        Next
        currentScore = 0
        UpdateScores()
        UpdateHighestScores()
        '增加两个随机数字'
        AddNewRandomNumber()
        AddNewRandomNumber()
        For row = 0 To 3
            For column = 0 To 3
                If gameGrid(row, column).Text <> "" Then
                    gameGrid(row, column).ForeColor = Color.Blue
                End If
            Next
        Next

    End Sub

    ''' <summary>
    ''' 根据数值不同给每个数字方块添加背景色
    ''' </summary>
    Private Sub UpdateBlockColour()
        Dim row, column As Integer
        For row = 0 To 3
            For column = 0 To 3
                Dim number As String = gameGrid(row, column).Text
                Select Case number
                    Case "2"
                        gameGrid(row, column).BackColor = Color.LightYellow
                    Case "4"
                        gameGrid(row, column).BackColor = Color.LightGoldenrodYellow
                    Case "8"
                        gameGrid(row, column).BackColor = Color.Orange
                    Case "16"
                        gameGrid(row, column).BackColor = Color.OrangeRed
                    Case "32"
                        gameGrid(row, column).BackColor = Color.Red
                    Case "64"
                        gameGrid(row, column).BackColor = Color.DarkRed
                    Case "128"
                        gameGrid(row, column).BackColor = Color.Yellow
                    Case "256"
                        gameGrid(row, column).BackColor = Color.Gold
                    Case "512"
                        gameGrid(row, column).BackColor = Color.GreenYellow
                    Case "1024"
                        gameGrid(row, column).BackColor = Color.Green
                    Case "2048"
                        gameGrid(row, column).BackColor = Color.DarkGreen
                    Case ""
                        gameGrid(row, column).BackColor = Color.LightGray
                    Case Else
                        gameGrid(row, column).BackColor = Color.Blue
                End Select
                gameGrid(row, column).ForeColor = Color.Black
            Next
        Next

    End Sub
    ''' <summary>
    ''' 检查是否生成数字2048
    ''' </summary>
    Private Sub CheckWin()
        Dim row, column As Integer
        Dim result As MsgBoxResult
        For row = 0 To 3
            For column = 0 To 3
                If gameGrid(row, column).Text = "2048" AndAlso hasShownMessage = False Then
                    hasShownMessage = True
                    result = MsgBox("Congratulations! You got 2048, Do you want to continue?", MsgBoxStyle.YesNo)
                    If result = MsgBoxResult.No Then
                        RestartGame()
                    Else
                        CheckGameOver()
                    End If
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 判断游戏是否结束
    ''' </summary>
    Private Sub CheckGameOver()
        Dim gameOver As Boolean = True
        Dim row, column As Integer
        Dim result As MsgBoxResult
        '判断是否还有空格子'
        If CheckEmpty(gameGrid) Then
            gameOver = False
        Else
            '判断是否有相邻的两个格子数值相等的情况'
            For row = 0 To 3
                For column = 0 To 2
                    If gameGrid(row, column).Text = gameGrid(row, column + 1).Text Then
                        gameOver = False
                    End If
                Next
            Next
            For column = 0 To 3
                For row = 0 To 2
                    If gameGrid(row, column).Text = gameGrid(row + 1, column).Text Then
                        gameOver = False
                    End If
                Next
            Next
        End If

        If gameOver = True Then
            SaveScores()
            result = MsgBox("Game Over! Do you want to restart the game?", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.Yes Then
                RestartGame()
            End If
        End If
    End Sub
    Private Function CheckEmpty(gameGridExample(,) As Label) As Boolean
        Dim rows As Integer = gameGridExample.GetLength(0)
        Dim columns As Integer = gameGridExample.GetLength(1)

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To columns - 1
                If gameGridExample(i, j).Text = "" Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function

    Private Sub RollbackKey_Click(sender As Object, e As EventArgs) Handles RollbackKey.Click
        If numberOfRollbacks >= 1 Then
            numberOfRollbacks = numberOfRollbacks - 1
            Dim PriviousBoard As List(Of String) = SavedGameGrids.Pop()
            currentScore = PriviousBoard(0)
            Score.Text = "Current Score:" & PriviousBoard(0)
            gameGrid(0, 0).Text = PriviousBoard(1)
            gameGrid(0, 1).Text = PriviousBoard(2)
            gameGrid(0, 2).Text = PriviousBoard(3)
            gameGrid(0, 3).Text = PriviousBoard(4)
            gameGrid(1, 0).Text = PriviousBoard(5)
            gameGrid(1, 1).Text = PriviousBoard(6)
            gameGrid(1, 2).Text = PriviousBoard(7)
            gameGrid(1, 3).Text = PriviousBoard(8)
            gameGrid(2, 0).Text = PriviousBoard(9)
            gameGrid(2, 1).Text = PriviousBoard(10)
            gameGrid(2, 2).Text = PriviousBoard(11)
            gameGrid(2, 3).Text = PriviousBoard(12)
            gameGrid(3, 0).Text = PriviousBoard(13)
            gameGrid(3, 1).Text = PriviousBoard(14)
            gameGrid(3, 2).Text = PriviousBoard(15)
            gameGrid(3, 3).Text = PriviousBoard(16)
            UpdateBlockColour()
            rollbackCount.Text = "Rollback Chance:" & numberOfRollbacks.ToString
        End If
    End Sub
    ''' <summary>
    ''' lixinAdd
    ''' </summary>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean

        If keyData = Keys.Left Or keyData = Keys.Right Or keyData = Keys.Up Or keyData = Keys.Down Then

            If keyData = Keys.Left Then Me.KeyLeft_Click(Nothing, Nothing)
            If keyData = Keys.Right Then Me.KeyRight_Click(Nothing, Nothing)
            If keyData = Keys.Up Then Me.KeyUp_Click(Nothing, Nothing)
            If keyData = Keys.Down Then Me.KeyDown_Click(Nothing, Nothing)
            Return False
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Private Sub SaveScores()

        Dim transaction As System.Data.Odbc.OdbcTransaction

        Dim OdbcConnection As New System.Data.Odbc.OdbcConnection("Dsn=SQL Anywhere 17 CustDB;uid=lixin;pwd=lixin1234;databasefile=D:\A02-Me\20240818-2048\2048II\DB\DB1.db;servername=DB1;startline='C:\Program Files\SQL Anywhere 17\Bin64\dbsrv17.exe -x tcpip(localonly=yes)';autostop=YES;integrated=NO;description='SQL Anywhere 17 UltraLite Sample'")

        Try

            OdbcConnection.Open()

            transaction = OdbcConnection.BeginTransaction()

            Dim sqlHighestScoreUpdate As String = "insert into scoretop (NameX,Score,DtimeX)values ('liyiming', " & currentScore.ToString() & ",'" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
            Dim OdbcCommand As New System.Data.Odbc.OdbcCommand(sqlHighestScoreUpdate, OdbcConnection)
            OdbcCommand.Transaction = transaction
            OdbcCommand.ExecuteNonQuery()

            Dim sqlHighestScoreUpdate2 As String = "insert into scoretop (NameX,Score,DtimeX)values ('liyiming', " & currentScore.ToString() & ",'" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
            Dim OdbcCommand2 As New System.Data.Odbc.OdbcCommand(sqlHighestScoreUpdate, OdbcConnection)
            OdbcCommand2.Transaction = transaction
            OdbcCommand2.ExecuteNonQuery()

            transaction.Commit()
        Catch ex As Exception

            Try
                transaction.Rollback()

            Catch
                ' Do nothing here; transaction is not active.
            End Try

        Finally
            OdbcConnection.Close()
        End Try




    End Sub

    Private Sub UpdateHighestScores()
        Dim OdbcConnection As New System.Data.Odbc.OdbcConnection("Dsn=SQL Anywhere 17 CustDB;uid=lixin;pwd=lixin1234;databasefile=D:\A02-Me\20240818-2048\2048II\DB\DB1.db;servername=DB1;startline='C:\Program Files\SQL Anywhere 17\Bin64\dbsrv17.exe -x tcpip(localonly=yes)';autostop=YES;integrated=NO;description='SQL Anywhere 17 UltraLite Sample'")

        OdbcConnection.Open()

        Dim sqlUpdateScoreSorted As String = "select max(Score) as highest_score from scoretop"

        Dim OdbcCommand2 As New System.Data.Odbc.OdbcCommand(sqlUpdateScoreSorted, OdbcConnection)

        Dim savedHighestScore As Integer = CInt(OdbcCommand2.ExecuteScalar())

        highScore.Text = "Highest Score:" & savedHighestScore.ToString

        OdbcConnection.Close()

    End Sub
End Class